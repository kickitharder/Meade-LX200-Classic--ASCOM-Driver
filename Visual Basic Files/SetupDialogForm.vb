Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ASCOM.LX200Classic
'Imports ASCOM.Utilities
Imports System.IO.Ports

<ComVisible(False)>
Public Class frmSetup

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click ' OK button event handler
        ' Persist new values of user settings to the ASCOM profile
        Telescope.comPort = ComboBoxComPort.SelectedItem ' Update the state variables with results from the dialogue
        Telescope.traceState = chkTrace.Checked
        Telescope.model = cbxLX200.SelectedItem
        Telescope.homePositionDEC = nudDEC.Value
        Telescope.homePositionHA = nudHA.Value
        Telescope.focalReducer = nudFocalReducer.Value
        Telescope.maxSlewRate = nudMaxSlewRate.Value
        Telescope.elevation = nudElevation.Value
        Telescope.maxSlewDEC = nudMaxDec.Value

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click 'Cancel button event handler
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub ShowAscomWebPage(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbxASCOM.DoubleClick, pbxASCOM.Click
        ' Click on ASCOM logo event handler
        Try
            System.Diagnostics.Process.Start("http://ascom-standards.org/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub SetupDialogForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load ' Form load event handler
        ' Retrieve current values of user settings from the ASCOM Profile
        Me.TopMost = True
        Me.TopMost = False
        InitUI()
    End Sub

    Private Sub InitUI()
        chkTrace.Checked = Telescope.traceState
        ' set the list of com ports to those that are currently available
        ComboBoxComPort.Items.Clear()
        ComboBoxComPort.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames()) ' use System.IO because it's static
        Dim listLength As Integer = ComboBoxComPort.Items.Count - 1
        Dim list(listLength) As Integer
        For i = 0 To listLength
            list(i) = Str(Mid(ComboBoxComPort.Items(i), 4, 3))
        Next
        Array.Sort(list)
        ComboBoxComPort.Items.Clear()
        For i = 0 To listLength
            ComboBoxComPort.Items.Add("COM" + list(i).ToString)
        Next

        ' select the current port if possible
        'Telescope.comPort = "COM2"
        If ComboBoxComPort.Items.Contains(Telescope.comPort) Then
            ComboBoxComPort.SelectedItem = Telescope.comPort
        End If
        cbxLX200.Items.Add("7"" Mak F15")
        cbxLX200.Items.Add("8"" SCT F6.3")
        cbxLX200.Items.Add("8"" SCT F10")
        cbxLX200.Items.Add("10"" SCT F6.3")
        cbxLX200.Items.Add("10"" SCT F10")
        cbxLX200.Items.Add("12"" SCT F10")
        cbxLX200.Items.Add("16"" SCT F10")
        If cbxLX200.Items.Contains(Telescope.model) Then
            cbxLX200.SelectedItem = Telescope.model
        End If
        nudDEC.Value = Telescope.homePositionDEC
        nudHA.Value = Telescope.homePositionHA
        nudFocalReducer.Value = Telescope.focalReducer
        nudMaxSlewRate.Value = Telescope.maxSlewRate
        nudElevation.Value = Telescope.elevation
        nudMaxDec.Value = Telescope.maxSlewDEC
    End Sub

    Private Sub CheckConnection_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        lblCxnBad.Visible = False
        lblCxnGood.Visible = False
        Dim resp As String
        Dim objSerial As New SerialPort
        Try
            With objSerial
                .PortName = Telescope.comPort
                .BaudRate = 9600
                .ReadTimeout = 2000
                .Open()
                .Write(":GT#")
            End With
            resp = objSerial.ReadTo("#")                   ' Read bytes until # terminator has been found
            If resp.Length = 4 And resp.Substring(2, 1) = "." Then
                lblCxnBad.Visible = False
                lblCxnGood.Visible = True
            End If
        Catch ex As Exception
            lblCxnGood.Visible = False
            lblCxnBad.Visible = True
        End Try
        Try
            objSerial.Close()
            objSerial.Dispose()
        Catch ex As Exception
            MsgBox("Couldn't close " + Telescope.comPort)
        End Try
    End Sub

    Private Sub ComboBoxComPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxComPort.SelectedIndexChanged
        Telescope.comPort = ComboBoxComPort.SelectedItem
        lblCxnGood.Visible = False
        lblCxnBad.Visible = False
    End Sub

    Private Sub ShowMeadeWebPage_Click(sender As Object, e As EventArgs) Handles pbxMeade.Click
        Try
            System.Diagnostics.Process.Start("http://www.meade.com/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Try
            System.Diagnostics.Process.Start("http://www.crayfordmanorastro.com/")
        Catch noBrowser As System.ComponentModel.Win32Exception
            If noBrowser.ErrorCode = -2147467259 Then
                MessageBox.Show(noBrowser.Message)
            End If
        Catch other As System.Exception
            MessageBox.Show(other.Message)
        End Try
    End Sub

    Private Sub btnLibrary_Click(sender As Object, e As EventArgs) Handles btnLibrary.Click
        Dim form As New frmLibrary()
        form.ShowDialog()
    End Sub

End Class