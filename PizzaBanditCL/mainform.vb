Public Class Mainform

    Dim firstFootForward As Boolean
    Dim direction As Integer
    Dim vroads(3) As PictureBox
    Dim hroads(1) As PictureBox
    Dim cages(3) As PictureBox
    Dim cagesdirection(3) As Integer
    Dim cagestate(3) As Integer
    Public Const INHOME As Integer = 0
    Public Const LEAVINGHOME As Integer = 1
    Public Const NORMAL As Integer = 2
    Dim cagenum As Integer
    Dim pizzas(81) As PictureBox
    Dim lives(3) As PictureBox
    Dim numlives As Integer
    Dim pizzaeaten As Integer
    Dim touchingpizza As Boolean
    Dim reggiespeed As Integer
    Dim reggiewithspeed As Boolean
    Dim speeds(1) As PictureBox
    Dim speedcounter As Integer
    Public seconds As Integer
    Dim timercounter As Integer






    Private Sub Mainform_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.W Or e.KeyCode = Keys.S Or e.KeyCode = Keys.A Or e.KeyCode = Keys.D Then
            direction = e.KeyCode
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim index As Integer
        Call movereggie()
        Call animatereggie()
        Call collectpizza()
        Call checkbeatlevel()
        Call checkspeedreggie()


        timercounter += 1
        seconds = timercounter / 17
        clockscore.Text = (seconds).ToString
        For index = 0 To 3
            If cagestate(index) = NORMAL Then
                Call movecages(index)
                If atIntersection(index) = True Then
                    Call chasereggie(index)
                End If
            Else
                Call intogame()
            End If


            If touching(Reggie, cages(index)) Then
                Timer1.Stop()
                My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\sounds\capture.wav", AudioPlayMode.WaitToComplete)
                numlives -= 1
                Call updatelives()
                CaptureForm1.ShowDialog()
                Call resetlevel()
                Timer1.Start()

                If numlives < 0 Then
                    Timer1.Stop()
                    GameOverForm1.ShowDialog()
                    Call resetlevel()
                    Timer1.Start()
                End If
            End If

        Next index

        If quit = True Then
            Me.Close()

        End If


    End Sub

    Private Sub Mainform_Load(sender As Object, e As EventArgs) Handles Me.Load

        vroads(0) = vroad0
        vroads(1) = vroad1
        vroads(2) = vroad2
        vroads(3) = vroad3

        hroads(0) = hroad0
        hroads(1) = hroad1

        numlives = 3

        begingame = True


        Call resetlevel()
        begingame = False




        quit = False

        Timer1.Start()

    End Sub

    Private Sub moveup(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Top <= 0 - guy.Height Then
            guy.Top = 780
        Else
            guy.Top -= speed
        End If
    End Sub
    Private Sub movedown(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Top >= 780 + guy.Height Then
            guy.Top = 0
        Else
            guy.Top += speed
        End If
    End Sub
    Private Sub moveleft(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Left <= 0 - guy.Width Then
            guy.Left = 1200
        Else

            guy.Left -= speed
        End If

    End Sub
    Private Sub moveright(ByVal guy As PictureBox, ByVal speed As Integer)
        If guy.Left >= 1200 + guy.Width Then
            guy.Left = 0
        Else
            guy.Left += speed
        End If
    End Sub
    Private Sub animateup()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrup2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrup1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animatedown()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrdn2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrdn1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animateleft()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrlt1.png")
            firstFootForward = True
        End If
    End Sub
    Private Sub animateright()
        If firstFootForward = True Then
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrrt2.png")
            firstFootForward = False
        Else
            Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrrt1.png")
            firstFootForward = True
        End If
    End Sub
    Private Function touching(ByVal object1 As PictureBox, ByVal object2 As PictureBox)
        If object1.Right > object2.Left And object1.Left < object2.Right Then
            If object1.Top < object2.Bottom And object1.Bottom > object2.Top Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Sub movereggie()
        Dim index As Integer
        For index = 0 To 3

            If touching(Reggie, vroads(index)) Then
                If direction = Keys.W Then
                    Call moveup(Reggie, reggiespeed)

                    Reggie.Left = vroads(index).Left
                End If

                If direction = Keys.S Then
                    Call movedown(Reggie, reggiespeed)

                    Reggie.Left = vroads(index).Left
                End If
            End If
        Next index
        For index = 0 To 1
            If touching(Reggie, hroads(index)) Then
                If direction = Keys.A Then
                    Call moveleft(Reggie, reggiespeed)

                    Reggie.Top = hroads(index).Top
                End If
                If direction = Keys.D Then
                    Call moveright(Reggie, reggiespeed)

                    Reggie.Top = hroads(index).Top
                End If
            End If
        Next index
    End Sub

    Private Sub animatereggie()
        If direction = Keys.W Then
            animateup()

        ElseIf direction = Keys.S Then
            animatedown()

        ElseIf direction = Keys.A Then
            animateleft()

        ElseIf direction = Keys.D Then
            animateright()

        End If
    End Sub

    Private Sub movecages(ByVal cindex As Integer)
        Dim index As Integer
        For index = 0 To 3
            If touching(cages(cindex), vroads(index)) Then
                If cagesdirection(cindex) = Keys.W Then
                    Call moveup(cages(cindex), 5)

                    cages(cindex).Left = vroads(index).Left
                End If

                If cagesdirection(cindex) = Keys.S Then
                    Call movedown(cages(cindex), 5)

                    cages(cindex).Left = vroads(index).Left
                End If
            End If
        Next index
        For index = 0 To 1
            If touching(cages(cindex), hroads(index)) Then
                If cagesdirection(cindex) = Keys.A Then
                    Call moveleft(cages(cindex), 5)

                    cages(cindex).Top = hroads(index).Top
                End If
                If cagesdirection(cindex) = Keys.D Then
                    Call moveright(cages(cindex), 5)

                    cages(cindex).Top = hroads(index).Top
                End If
            End If
        Next index
    End Sub
    Private Function atIntersection(ByVal cindex As Integer)
        Dim index As Integer
        For index = 0 To 3
            If touching(vroads(index), cages(cindex)) And touching(hroad0, cages(cindex)) Then
                Return True
            ElseIf touching(cages(cindex), vroads(index)) And touching(cages(cindex), hroad1) Then
                Return True

            End If

        Next index

        Return False
    End Function

    Private Sub chasereggie(ByVal cindex As Integer)
        Dim xdistance
        Dim ydistance
        ydistance = Math.Abs(cages(cindex).Top - Reggie.Top)
        xdistance = Math.Abs(cages(cindex).Left - Reggie.Left)
        If xdistance > ydistance Then
            If Reggie.Left < cages(cindex).Left Then
                cagesdirection(cindex) = Keys.A
            ElseIf Reggie.Left > cages(cindex).Left Then
                cagesdirection(cindex) = Keys.D
            End If
        ElseIf xdistance < ydistance Then
            If Reggie.Top < cages(cindex).Top Then
                cagesdirection(cindex) = Keys.W
            ElseIf Reggie.Top > cages(cindex).Top Then
                cagesdirection(cindex) = Keys.S
            End If
        End If
    End Sub

    Private Sub resetlevel()
        Call setreggie()
        Call setcages()


        scoretext.Text = "82"
        timercounter = 0
        My.Computer.Audio.Play(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\sounds\backgroundmusic.wav", AudioPlayMode.BackgroundLoop)
        reggiespeed = 10
        If begingame = True Then
            Call setpizza()
            speed0.Visible = True
            speed1.Visible = True
        End If
    End Sub

    Private Sub setreggie()
        Reggie.Image = Image.FromFile(IO.Path.GetDirectoryName(Application.ExecutablePath) & "\pics\reggie\rrdn1.png")
        Reggie.Left = 518
        Reggie.Top = 622
    End Sub

    Private Sub setcages()
        cages(0) = cage0
        cages(1) = cage1
        cages(2) = cage2
        cages(3) = cage3

        cagesdirection(0) = Keys.A
        cagesdirection(1) = Keys.D
        cagesdirection(2) = Keys.A
        cagesdirection(3) = Keys.D

        cage0.Left = 491
        cage0.Top = 392
        cage1.Left = 559
        cage1.Top = 392
        cage2.Left = 491
        cage2.Top = 456
        cage3.Left = 559
        cage3.Top = 456

        cagestate(0) = INHOME
        cagestate(1) = INHOME
        cagestate(2) = INHOME
        cagestate(3) = INHOME

        cagenum = 0

    End Sub

    Private Sub intogame()
        If cagestate(cagenum) = INHOME Then
            cagestate(cagenum) = LEAVINGHOME
            cages(cagenum).Left = 526
            cages(cagenum).Top = 420
        ElseIf cagestate(cagenum) = LEAVINGHOME Then
            cages(cagenum).Top -= 2


            If touching(cages(cagenum), hroad0) Then
                cagestate(cagenum) = NORMAL
                cagenum += 1

            End If
        End If
    End Sub
    Private Sub setpizza()

        Dim index As Integer


        pizzas(0) = PictureBox1
        pizzas(1) = PictureBox2
        pizzas(2) = PictureBox3
        pizzas(3) = PictureBox4
        pizzas(4) = PictureBox5
        pizzas(5) = PictureBox6
        pizzas(6) = PictureBox7
        pizzas(7) = PictureBox8
        pizzas(8) = PictureBox9
        pizzas(9) = PictureBox10
        pizzas(10) = PictureBox11
        pizzas(11) = PictureBox12
        pizzas(12) = PictureBox13
        pizzas(13) = PictureBox14
        pizzas(14) = PictureBox15
        pizzas(15) = PictureBox16
        pizzas(16) = PictureBox17
        pizzas(17) = PictureBox18
        pizzas(18) = PictureBox19
        pizzas(19) = PictureBox20
        pizzas(20) = PictureBox21
        pizzas(21) = PictureBox22
        pizzas(22) = PictureBox23
        pizzas(23) = PictureBox24
        pizzas(24) = PictureBox25
        pizzas(25) = PictureBox26
        pizzas(26) = PictureBox27
        pizzas(27) = PictureBox28
        pizzas(28) = PictureBox29
        pizzas(29) = PictureBox30
        pizzas(30) = PictureBox31
        pizzas(31) = PictureBox32
        pizzas(32) = PictureBox33
        pizzas(33) = PictureBox34
        pizzas(34) = PictureBox35
        pizzas(35) = PictureBox36
        pizzas(36) = PictureBox37
        pizzas(37) = PictureBox38
        pizzas(38) = PictureBox39
        pizzas(39) = PictureBox40
        pizzas(40) = PictureBox41
        pizzas(41) = PictureBox42
        pizzas(42) = PictureBox43
        pizzas(43) = PictureBox44
        pizzas(44) = PictureBox45
        pizzas(45) = PictureBox46
        pizzas(46) = PictureBox47
        pizzas(47) = PictureBox48
        pizzas(48) = PictureBox49
        pizzas(49) = PictureBox50
        pizzas(50) = PictureBox51
        pizzas(51) = PictureBox52
        pizzas(52) = PictureBox53
        pizzas(53) = PictureBox54
        pizzas(54) = PictureBox55
        pizzas(55) = PictureBox57
        pizzas(56) = PictureBox58
        pizzas(57) = PictureBox61
        pizzas(58) = PictureBox64
        pizzas(59) = PictureBox67
        pizzas(60) = PictureBox70
        pizzas(61) = PictureBox71
        pizzas(62) = PictureBox72
        pizzas(63) = PictureBox73
        pizzas(64) = PictureBox74
        pizzas(65) = PictureBox75
        pizzas(66) = PictureBox76
        pizzas(67) = PictureBox77
        pizzas(68) = PictureBox78
        pizzas(69) = PictureBox79
        pizzas(70) = PictureBox80
        pizzas(71) = PictureBox81
        pizzas(72) = PictureBox82
        pizzas(73) = PictureBox83
        pizzas(74) = PictureBox85
        pizzas(75) = PictureBox86
        pizzas(76) = PictureBox87
        pizzas(77) = PictureBox88
        pizzas(78) = PictureBox89
        pizzas(79) = PictureBox90
        pizzas(80) = PictureBox91
        pizzas(81) = PictureBox92

        For index = 0 To 81


            pizzas(index).Visible = True

        Next index

    End Sub
    Private Sub collectpizza()
        Dim index As Integer
        For index = 0 To 81

            If touching(Reggie, pizzas(index)) And pizzas(index).Visible = True Then
                pizzas(index).Visible = False
                pizzaeaten += 1

                scoretext.Text = (82 - pizzaeaten).ToString

            End If

        Next index
    End Sub

    Private Sub updatelives()
        If numlives = 2 Then
            life3.Visible = False
        ElseIf numlives = 1 Then
            life2.Visible = False
        ElseIf numlives = 0 Then
            life1.Visible = False
        ElseIf numlives = -1 Then
            life0.Visible = False

        End If
    End Sub

    Private Sub checkbeatlevel()
        If pizzaeaten = 82 Then
            Timer1.Stop()
            VictoryForm1.ShowDialog()

            begingame = True
            pizzaeaten = 0
            numlives = 4
            life3.Visible = True
            life2.Visible = True
            life1.Visible = True
            life0.Visible = True
            resetlevel()
            Timer1.Start()
        End If
    End Sub

    Private Sub checkspeedreggie()

        If touching(Reggie, speed0) And speed0.Visible = True Then
            speedcounter = 0
            reggiewithspeed = True
            speed0.Visible = False

        ElseIf touching(Reggie, speed1) And speed1.Visible = True Then
            speedcounter = 0
            reggiewithspeed = True
            speed1.Visible = False
        End If



        If reggiewithspeed = True Then
            speedcounter += 1
            If speedcounter <= 25 Then
                reggiespeed = 20
            Else
                reggiespeed = 10
                reggiewithspeed = False




            End If

        End If
    End Sub


End Class
