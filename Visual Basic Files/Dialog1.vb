
'Imports System.Runtime.InteropServices
'Imports System.Windows.Forms
'Imports ASCOM.LX200Classic64
'Imports ASCOM.Utilities
'Imports ASCOM.Astrometry.AstroUtils
Imports Microsoft.VisualBasic.Strings
Imports System.Math
'Imports System.IO
Imports System.IO.Ports

Public Class frmLibrary
    Dim stars(32) As String
    Dim planets(9) As String
    Dim RAstr As String
    Dim DECstr As String
    Dim Longitude As Double
    Dim Latitude As Double
    Dim Slewing As Boolean
    Dim NotFound As String = "LX200 NOT FOUND"
    Const RAD2DEG As Double = 57.29577951
    Const DEG2RAD As Double = 1 / RAD2DEG
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If lblStatus.Text <> NotFound Then
            SerialCommand("Sr" + RAstr, 1)
            SerialCommand("Sd" + DECstr, 1)
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub frmLibrary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        stars(0) = "013 ERI ACHERNAR"
        stars(1) = "121 CRU ACRUX A"
        stars(2) = "223 CYG ALBIREO"
        stars(3) = "140 UMA ALKAID"
        stars(4) = "033 TAU ALDEBARAN"
        stars(5) = "050 ORI ALNILAM"
        stars(6) = "095 HYA ALPHARD"
        stars(7) = "165 CRB ALPHEKKA"
        stars(8) = "226 AQL ALTAIR"
        stars(9) = "177 SCO ANTARES"
        stars(10) = "147 BOO ARCTURUS"
        stars(11) = "056 ORI BETELGUESE"
        stars(12) = "058 AUR BOGARDUS"
        stars(13) = "063 CAR CANOPUS"
        stars(14) = "042 AUR CAPELLA"
        stars(15) = "078 GEM CASTOR A"
        stars(16) = "232 CYG DENEB"
        stars(17) = "114 LEO DENEBOLA"
        stars(18) = "008 CET DIPHDA"
        stars(19) = "238 PEG ENIF"
        stars(20) = "247 PSA FOMALHAUT"
        stars(21) = "144 CET HADAR"
        stars(22) = "017 ARI HAMAL"
        stars(23) = "249 PEG MARKAB"
        stars(24) = "020 CET MIRA"
        stars(25) = "019 UMI POLARIS"
        stars(26) = "081 GEM POLLUX"
        stars(27) = "080 CMI PROCYON"
        stars(28) = "100 LEO REGULUS"
        stars(29) = "041 ORI RIGEL"
        stars(30) = "067 CMA SIRIUS"
        stars(31) = "138 VIR SPICA"
        stars(32) = "214 LYR VEGA"
        For i = 0 To 32
            cbxNamedStars.Items.Add(Mid(stars(i), 9, 20))
        Next
        cbxNamedStars.SelectedItem = Mid(stars(0), 9, 20)
        planets(0) = "900 THE SUN"
        planets(1) = "901 MERCURY"
        planets(2) = "902 VENUS"
        planets(3) = "903 THE MOON"
        planets(4) = "904 MARS"
        planets(5) = "905 JUPITER"
        planets(6) = "906 SATURN"
        planets(7) = "907 URANUS"
        planets(8) = "908 NEPTUNE"
        planets(9) = "909 PLUTO"
        For i = 0 To 9
            cbxSolarSystem.Items.Add(Mid(planets(i), 5, 20))
        Next
        cbxSolarSystem.SelectedItem = Mid(planets(3), 5, 20)
        radSolarSystem.Checked = True
        If SerialCommand("GT", -1) <> "" Then
            RAstr = LongFormat("GR")
            DECstr = LongFormat("GD")
            ShowDetails()
        Else
            lblStatus.Text = NotFound
            Timer1.Interval = 1000
        End If
    End Sub
    Private Sub ShowDetails()
        lblConst.Text = ""
        lblDec.Text = ""
        lblMag.Text = ""
        lblName.Text = ""
        lblQuality.Text = ""
        lblRA.Text = ""
        lblSize.Text = ""
        lblType.Text = ""
        lstDetails.Items.Clear()
        Dim sun As Boolean = False
        If SerialCommand("GT", -1) = "" Then
            lblStatus.Text = NotFound
            Exit Sub
        End If
        Try
            Dim name As String = ""
            If radNamedStars.Checked Then
                Dim star As String = stars(cbxNamedStars.SelectedIndex)
                name = star.Substring(8)
                lblConst.Text = star.Substring(4, 3)
                SerialCommand("Ls0", 1)
                SerialCommand("LS" + star.Substring(0, 3), 0)
            End If
            If radSolarSystem.Checked Then
                Dim planet As String = planets(cbxSolarSystem.SelectedIndex)
                name = planet.Substring(4)
                If name = "THE SUN" Then
                    CalcSunCoords()
                    sun = True
                Else
                    SerialCommand("Ls0", 1)
                    SerialCommand("LS" + planet.Substring(0, 3), 0)
                End If
            End If
            If radMessier.Checked Then
                name = "M" + nudMessier.Value.ToString
                SerialCommand("LM" + nudMessier.Value.ToString, 0)
            End If
            If radNGC.Checked Then
                name = "NGC" + nudNGC.Value.ToString
                SerialCommand("Lo0", 1)
                SerialCommand("LC" + nudNGC.Value.ToString, 0)
            End If
            If radUGC.Checked Then
                name = "UGC" + nudUGC.Value.ToString
                SerialCommand("Lo2", 1)
                SerialCommand("LC" + nudUGC.Value.ToString, 0)
            End If
            If radIC.Checked Then
                name = "IC" + nudIC.Value.ToString
                SerialCommand("Lo1", 1)
                SerialCommand("LC" + nudIC.Value.ToString, 0)
            End If
            If radAlignment.Checked Then
                name = "Alignment Star " + nudAlignmentStars.Value.ToString
                SerialCommand("Ls0", 1)
                SerialCommand("LS" + nudAlignmentStars.Value.ToString, 0)
            End If
            If name = "" Then Exit Sub
            lblName.Text = name
            Dim str As String = LongFormat("Gr")
            lblRA.Text = str.Substring(0, 2) + "h " + str.Substring(3, 2) + "m " + str.Substring(6, 2) + "s"
            str = LongFormat("Gd")
            lblDec.Text = str.Substring(0, 3) + "° " + str.Substring(4, 2) + "' " + str.Substring(7, 2) + """"
            If sun Then
                lblMag.Text = "-26.7"
                lblSize.Text = "32'"
                lblType.Text = "Star"
            Else
                Dim details As String = SerialCommand("LI", -1)
                If details = "Too close to    the sun.        " Then
                    lblRA.Text = ""
                    lblDec.Text = ""
                End If
                lstDetails.Items.Add(Mid(details, 1, 16))
                    lstDetails.Items.Add(Mid(details, 17, 16))
                    If Mid(details, 17, 3) = "MAG" Then lblMag.Text = Trim(Mid(details, 20, 5))
                If Mid(details, 17, 6) = "Phase:" Then lblSize.Text = Trim(Mid(details, 24, 9))
                If Mid(details, 25, 2) = "SZ" Then lblSize.Text = Trim(Mid(details, 27, 6))
                    Select Case Mid(details, 10, 2)
                        Case "SU"
                            lblQuality.Text = "Superb"
                        Case "EX"
                            lblQuality.Text = "Excellent"
                        Case "VG"
                            lblQuality.Text = "Very good"
                        Case "GD"
                            lblQuality.Text = "Good"
                        Case "FR"
                            lblQuality.Text = "Fair"
                        Case "PR"
                            lblQuality.Text = "Poor"
                        Case "VP"
                            lblQuality.Text = "Very poor"
                    End Select
                    Select Case Trim(Mid(details, 13, 4))
                        Case "PNEB"
                            lblType.Text = "Planetary nebula"
                        Case "GLOB"
                            lblType.Text = "Globular cluster"
                        Case "OPEN"
                            lblType.Text = "Open cluster"
                        Case "OPNB"
                            lblType.Text = "Open cluster & nebula"
                        Case "GAL"
                            lblType.Text = "Galaxy"
                        Case "MLTG"
                            lblType.Text = "Multiple galaxies/stars"
                        Case "DNEB"
                            lblType.Text = "Diffuse nebula"
                        Case "STAR"
                            lblType.Text = "Star"
                        Case "MLTS"
                            lblType.Text = "Multiple stars"
                    End Select
                End If
        Catch ex As Exception
            lblStatus.Text = "LX200 NOT FOUND"
        End Try
    End Sub
    Private Sub CalcSunCoords()
        'Jean Meeus Astronomical Algorithms First Edition page 151 ISBN 0-943396-35-2
        Dim T As Double
        Dim L0 As Double
        Dim M As Double
        Dim e As Double
        Dim C As Double
        Dim Th As Double
        Dim v As Double
        Dim R As Double
        Dim Om As Double
        Dim Lam As Double
        Dim Ep As Double
        Dim Ep0 As Double
        Dim now As DateTime = DateTime.UtcNow
        Dim Yr As Double = now.Year
        Dim Mth As Double = now.Month
        Dim JD As Double
        Dim A As Double
        Dim B As Double
        Dim DEC As Double
        Dim RA As Double

        If Mth <= 2 Then
            Yr -= 1
            Mth += 12
        End If
        A = Int(Yr / 100)
        B = 2 - A + Int(A / 4)
        JD = Int(365.25 * (Yr + 4716)) + Int(30.6001 * (Mth + 1)) + now.Day + B - 1524.5
        JD += (now.Hour * 3600 + now.Minute * 60 + now.Second) / 86400

        T = (JD - 2451545) / 36525
        L0 = Norm360(280.46645 + 36000.76983 * T + 0.0003032 * T * T)
        M = Norm360(357.5291 + 35999.0503 * T - 0.0001559 * T * T - 0.0001559 * T * T - 0.00000048 * T * T * T)
        e = 0.016708617 - 0.000042037 * T - 0.0000001236 * T * T
        C = (1.9146 - 0.004817 * T - 0.000014 * T * T) * Sind(M)
        C += (0.019993 - 0.000101 * T) * Sind(2 * M)
        C += 0.00029 * Sind(3 * M)
        Th = Norm360(L0 + C)
        v = M + C
        R = (1.000001018 * (1 - e * e)) / (1 + e * Cosd(v))
        Om = Norm360(125.04 - 1934.136 * T)
        Lam = Norm360(Th - 0.00569 - 0.00478 * Sind(Om))
        Ep0 = (23 + 26 / 60 + 21.448 / 3600) - (46.815 / 3600) * T - (0.00059 / 3600) * T * T + (0.001813 / 3600) * T * T * T
        Ep = Ep0 + 0.00256 * Cosd(Om)
        RA = Norm360(Atan2d(Cosd(Ep) * Sind(Lam), Cosd(Lam)))
        DEC = Asind(Sind(Ep) * Sind(Lam))
        If lblStatus.Text <> NotFound Then
            SerialCommand("Sr" + Hrs2HMS(RA / 15), 1)
            SerialCommand("Sd" + Degs2sDMS(DEC), 1)
        End If
    End Sub
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

    Private Function Sind(d As Double) As Double
        Return Sin(d * DEG2RAD)
    End Function
    Private Function Cosd(d As Double) As Double
        Return Cos(d * DEG2RAD)
    End Function
    Private Function Atan2d(a As Double, b As Double) As Double
        Return Atan2(a, b) * RAD2DEG
    End Function
    Private Function Asind(d As Double) As Double
        Return Asin(d) * RAD2DEG
    End Function
    Private Function Norm360(d As Double) As Double
        Return d - Int(d / 360) * 360
    End Function

    Private Function SerialCommand(cmdStr As String, n As Integer) As String
        If Not cmdStr.StartsWith(":") Then cmdStr = ":" + cmdStr
        If Not cmdStr.EndsWith("#") Then cmdStr += "#"
        Dim retStr As String = ""
        Dim objSerial As New SerialPort
        Do
            Try
                With objSerial
                    .PortName = Telescope.comPort
                    .BaudRate = 9600
                    .ReadTimeout = 1000
                    .WriteTimeout = 1000
                    .Open()
                End With
            Catch ex As Exception
            End Try
        Loop Until objSerial.IsOpen

        Try
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
        Return retStr
    End Function
    Private Function LongFormat(cmd As String) As String
        Dim respStr As String = SerialCommand(cmd, -1)
        If respStr.Length < 8 Then
            SerialCommand("U", 0)
            respStr = SerialCommand(cmd, -1)
        End If
        Return respStr
    End Function

    Private Sub cbxNamedStars_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxNamedStars.SelectedIndexChanged
        If cbxNamedStars.Focused Then radNamedStars.Checked = True
        If radNamedStars.Checked Then ShowDetails()
    End Sub
    Private Sub cbxSolarSystem_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSolarSystem.SelectedIndexChanged
        If cbxSolarSystem.Focused Then radSolarSystem.Checked = True
        If radSolarSystem.Checked Then ShowDetails()
    End Sub
    Private Sub nudMessier_ValueChanged(sender As Object, e As EventArgs) Handles nudMessier.ValueChanged
        If nudMessier.Focused Then radMessier.Checked = True
        If radMessier.Checked Then ShowDetails()
    End Sub
    Private Sub nudNGC_ValueChanged(sender As Object, e As EventArgs) Handles nudNGC.ValueChanged
        If nudNGC.Focused Then radNGC.Checked = True
        If radNGC.Checked Then ShowDetails()
    End Sub
    Private Sub nudIC_ValueChanged(sender As Object, e As EventArgs) Handles nudIC.ValueChanged
        If nudIC.Focused Then radIC.Checked = True
        If radIC.Checked Then ShowDetails()
    End Sub
    Private Sub nudUGC_ValueChanged(sender As Object, e As EventArgs) Handles nudUGC.ValueChanged
        If nudUGC.Focused Then radUGC.Checked = True
        If radUGC.Checked Then ShowDetails()
    End Sub
    Private Sub nudAlignmentStars_ValueChanged(sender As Object, e As EventArgs) Handles nudAlignmentStars.ValueChanged
        If nudAlignmentStars.Focused Then radAlignment.Checked = True
        If radAlignment.Checked Then ShowDetails()
    End Sub
    Private Sub radNamedStars_CheckedChanged(sender As Object, e As EventArgs) Handles radNamedStars.CheckedChanged
        If radNamedStars.Checked Then ShowDetails()
    End Sub
    Private Sub radSolarSystem_CheckedChanged(sender As Object, e As EventArgs) Handles radSolarSystem.CheckedChanged
        If radSolarSystem.Checked Then ShowDetails()
    End Sub
    Private Sub radMessier_CheckedChanged(sender As Object, e As EventArgs) Handles radMessier.CheckedChanged
        If radMessier.Checked Then ShowDetails()
    End Sub
    Private Sub radNGC_CheckedChanged(sender As Object, e As EventArgs) Handles radNGC.CheckedChanged
        If radNGC.Checked Then ShowDetails()
    End Sub
    Private Sub radIC_CheckedChanged(sender As Object, e As EventArgs) Handles radIC.CheckedChanged
        If radIC.Checked Then ShowDetails()
    End Sub
    Private Sub radUGC_CheckedChanged(sender As Object, e As EventArgs) Handles radUGC.CheckedChanged
        If radUGC.Checked Then ShowDetails()
    End Sub
    Private Sub radAlignment_CheckedChanged(sender As Object, e As EventArgs) Handles radAlignment.CheckedChanged
        If radAlignment.Checked Then ShowDetails()
    End Sub

    Private Sub btnGoto_Click(sender As Object, e As EventArgs) Handles btnGoto.Click
        If lblStatus.Text = NotFound Then
            MsgBox(NotFound,, "SLEW ABORTED")
            Exit Sub
        End If
        If lblStatus.Text = "Parked" Then
            MsgBox("Telescope parked",, "SLEW ABORTED")
            Exit Sub
        End If
        SerialCommand("Sw3", 1)
        Dim str As String = SerialCommand("MS", 1)
        If str = "1" Then
            MsgBox("Object below horizon",, "SLEW ABORTED")
            Exit Sub
        End If
        Slewing = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Timer1.Interval = 1000
            Dim currRA As String = LongFormat("GR")
            Dim currDEC As String = LongFormat("GD")
            lblCurrRA.Text = currRA.Substring(0, 2) + "h " + currRA.Substring(3, 2) + "m " + currRA.Substring(6, 2) + "s"
            lblCurrDec.Text = currDEC.Substring(0, 3) + "° " + currDEC.Substring(4, 2) + "' " + currDEC.Substring(7, 2) + """"
            If Trim(SerialCommand("G2", -1)) <> "LAND" Then
                'If lblCurrRA.Text = "00h 00m 00s" AndAlso lblCurrDec.Text = "+00° 00' 00""" Then
                lblStatus.Text = "Parked"
                Timer1.Interval = 5000
            ElseIf Trim(LongFormat("D")) = "" Then
                lblStatus.Text = "Tracking"
                Slewing = False
            ElseIf Slewing Then
                lblStatus.Text = "Slewing"
            Else
                lblStatus.Text = "Tracking"
            End If
        Catch ex As Exception
            lblStatus.Text = NotFound
            Timer1.Interval = 5000
        End Try
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If lblStatus.Text = NotFound Or lblStatus.Text = "Parked" Then Exit Sub
        SerialCommand("Q", 0)
        SerialCommand("Sr" + LongFormat("GR"), 1)
        SerialCommand("Sd" + LongFormat("GD"), 1)
        lblStatus.Text = "STOPPED"
        Slewing = False
    End Sub
End Class
