Imports System.IO.Ports

Public Class frmParking
    Dim ParkRAstr As String
    Dim ParkDECstr As String
    Dim ParkRAval As Double
    Dim ParkDECval As Double

    Dim LastRAstr As String
    Dim LastDECstr As String
    Dim LastRAval As Double
    Dim LastDECval As Double

    Public WriteOnly Property ParkRA() As Double
        Set(RA As Double)
            ParkRAstr = Hrs2HMS(RA)
            ParkRAval = RA * 15
        End Set
    End Property

    Public WriteOnly Property ParkDEC() As Double
        Set(DEC As Double)
            ParkDECstr = Degs2sDMS(DEC)
            ParkDECval = DEC
        End Set
    End Property

    Public WriteOnly Property LastRA() As String
        Set(RA As String)
            LastRAstr = RA
            LastRAval = HMS2Hrs(RA) * 15
            prgRA.Maximum = IIf(LastRAval > ParkRAval, LastRAval - ParkRAval, ParkRAval - LastRAval)
            prgRA.Value = prgRA.Maximum
        End Set
    End Property

    Public WriteOnly Property LastDEC() As String
        Set(DEC As String)
            LastDECstr = DEC
            LastDECval = DMS2Degs(DEC)
            prgDEC.Maximum = IIf(LastDECval > ParkDECval, LastDECval - ParkDECval, ParkDECval - LastDECval)
            prgDEC.Value = prgDEC.Maximum
        End Set
    End Property


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim CurrRA As String = LongFormat("GR")
        Dim CurrDEC As String = LongFormat("GD")
        Dim CurrRAval As Double = HMS2Hrs(CurrRA) * 15
        Dim CurrDECval As Double = DMS2Degs(CurrDEC)


        If CurrRA = LastRAstr AndAlso CurrDEC = LastDECstr Then
            If (CurrRA = ParkRAstr And CurrDEC = ParkDECstr) Or Timer1.Interval = 1000 Then
                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()
            Else
                Timer1.Interval = 1000
            End If
        End If

        Dim RAdiff As Double = IIf(CurrRAval > ParkRAval, CurrRAval - ParkRAval, ParkRAval - CurrRAval)
        If RAdiff > 180 Then RAdiff -= 180
        prgRA.Value = RAdiff
        prgDEC.Value = IIf(CurrDECval > ParkDECval, CurrDECval - ParkDECval, ParkDECval - CurrDECval)

        LastRAstr = CurrRA
        LastDECstr = CurrDEC
        LastRAval = CurrRAval
        LastDECval = CurrDECval
    End Sub

    Private Sub btnAbort_Click(sender As Object, e As EventArgs) Handles btnAbort.Click
        Timer1.Enabled = False
        Me.DialogResult = System.Windows.Forms.DialogResult.Abort
        Me.Close()
    End Sub

    Private Function HMS2Hrs(HMS As String) As Double
        Timer1.Enabled = False
        Timer1.Enabled = True
        Return Val(HMS.Substring(0, 2)) + Val(HMS.Substring(3, 2)) / 60 + Val(HMS.Substring(6, 2)) / 3600
    End Function

    Private Function DMS2Degs(DMS As String) As Double
        Timer1.Enabled = False
        Timer1.Enabled = True
        Return Val(DMS.Substring(0, 3)) + Val(DMS.Substring(3, 2)) / 60 + Val(DMS.Substring(6, 2)) / 3600
    End Function

    Private Function Hrs2HMS(hours As Double) As String
        Dim hr As Integer, min As Integer, sec As Integer
        hr = Int(hours)
        min = Int((hours - hr) * 60)
        sec = Int((hours * 3600) - hr * 3600 - min * 60)
        Return Strings.Right("0" + hr.ToString, 2) + ":" + Strings.Right("0" + min.ToString, 2) + ":" + Strings.Right("0" + sec.ToString, 2)
    End Function

    Private Function Degs2sDMS(Degs As Double) As String
        Dim deg As Double, min As Double, sec As Double, sign As String
        sign = "+"
        If Degs < 0 Then
            sign = "-"
            Degs = -Degs
        End If
        deg = Int(Degs)
        min = Int((Degs - deg) * 60)
        sec = Int((Degs * 3600) - deg * 3600 - min * 60)
        Return sign + Strings.Right("0" + deg.ToString, 2) + ChrW(223) + Strings.Right("0" + min.ToString, 2) + ":" + Strings.Right("0" + sec.ToString, 2)
    End Function

    Private Function LongFormat(cmd As String) As String
        Dim respStr As String = SerialCommand(cmd, -1)
        If respStr.Length < 8 Then
            SerialCommand("U", 0)
            respStr = SerialCommand(cmd, -1)
        End If
        Return respStr
    End Function

    Private Function SerialCommand(cmdStr As String, n As Integer) As String
        If Not cmdStr.StartsWith(":") Then cmdStr = ":" + cmdStr
        If Not cmdStr.EndsWith("#") Then cmdStr += "#"
        Dim retStr As String = ""
        Dim objSerial As New SerialPort

        Try
            With objSerial
                .PortName = Telescope.comPort
                .BaudRate = 9600
                .ReadTimeout = 500
                .WriteTimeout = 100
                .Open()
            End With
            objSerial.Write(cmdStr)
            If n <= -1 Then retStr = objSerial.ReadTo("#")  ' Get a # terminated string
            If n <= -2 Then retStr = objSerial.ReadTo("#")  ' Get another if required
            If n = 0 Then retStr = ""                       ' Expect no response
            If n >= 1 Then
                For i = 1 To n                              ' Read in 'n' characters
                    retStr += ChrW(objSerial.ReadChar())    ' Read in one character at a time
                Next
            End If
        Catch ex As Exception
            retStr = ""
        End Try
        Try
            objSerial.Close()
            objSerial.Dispose()
        Catch ex As Exception
        End Try
        'MsgBox(cmdStr + " -> " + retStr)
        Return retStr
    End Function
End Class