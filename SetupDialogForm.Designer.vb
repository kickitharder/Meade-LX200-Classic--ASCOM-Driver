<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.label2 = New System.Windows.Forms.Label()
        Me.chkTrace = New System.Windows.Forms.CheckBox()
        Me.ComboBoxComPort = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.nudHA = New System.Windows.Forms.NumericUpDown()
        Me.nudDEC = New System.Windows.Forms.NumericUpDown()
        Me.cbxLX200 = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnCheck = New System.Windows.Forms.Button()
        Me.lblCxnGood = New System.Windows.Forms.Label()
        Me.lblCxnBad = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.pbxMeade = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.pbxASCOM = New System.Windows.Forms.PictureBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nudFocalReducer = New System.Windows.Forms.NumericUpDown()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.nudElevation = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.nudMaxSlewRate = New System.Windows.Forms.NumericUpDown()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnLibrary = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.nudMaxDec = New System.Windows.Forms.NumericUpDown()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.nudHA, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDEC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxMeade, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbxASCOM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudFocalReducer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudElevation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxSlewRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMaxDec, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(246, 404)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(14, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(186, 13)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Select port the LX200 is connected to"
        '
        'chkTrace
        '
        Me.chkTrace.AutoSize = True
        Me.chkTrace.Location = New System.Drawing.Point(323, 302)
        Me.chkTrace.Name = "chkTrace"
        Me.chkTrace.Size = New System.Drawing.Size(69, 17)
        Me.chkTrace.TabIndex = 8
        Me.chkTrace.Text = "Trace on"
        Me.chkTrace.UseVisualStyleBackColor = True
        '
        'ComboBoxComPort
        '
        Me.ComboBoxComPort.FormattingEnabled = True
        Me.ComboBoxComPort.Location = New System.Drawing.Point(116, 71)
        Me.ComboBoxComPort.Name = "ComboBoxComPort"
        Me.ComboBoxComPort.Size = New System.Drawing.Size(71, 21)
        Me.ComboBoxComPort.TabIndex = 9
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Hour Angle:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Declination:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(345, 34)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Meade LX200 Classic Driver"
        '
        'nudHA
        '
        Me.nudHA.DecimalPlaces = 1
        Me.nudHA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudHA.Location = New System.Drawing.Point(96, 20)
        Me.nudHA.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudHA.Minimum = New Decimal(New Integer() {1159, 0, 0, -2147352576})
        Me.nudHA.Name = "nudHA"
        Me.nudHA.Size = New System.Drawing.Size(54, 20)
        Me.nudHA.TabIndex = 15
        Me.nudHA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudDEC
        '
        Me.nudDEC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudDEC.Location = New System.Drawing.Point(96, 49)
        Me.nudDEC.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.nudDEC.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.nudDEC.Name = "nudDEC"
        Me.nudDEC.Size = New System.Drawing.Size(54, 20)
        Me.nudDEC.TabIndex = 16
        Me.nudDEC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxLX200
        '
        Me.cbxLX200.FormattingEnabled = True
        Me.cbxLX200.Location = New System.Drawing.Point(116, 155)
        Me.cbxLX200.Name = "cbxLX200"
        Me.cbxLX200.Size = New System.Drawing.Size(100, 21)
        Me.cbxLX200.TabIndex = 21
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 159)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "Model"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(14, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "COM port"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(12, 107)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(73, 34)
        Me.btnCheck.TabIndex = 25
        Me.btnCheck.Text = "Check Connection"
        Me.btnCheck.UseVisualStyleBackColor = True
        '
        'lblCxnGood
        '
        Me.lblCxnGood.AutoSize = True
        Me.lblCxnGood.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCxnGood.Location = New System.Drawing.Point(86, 115)
        Me.lblCxnGood.Name = "lblCxnGood"
        Me.lblCxnGood.Size = New System.Drawing.Size(142, 20)
        Me.lblCxnGood.TabIndex = 26
        Me.lblCxnGood.Text = "Telescope found"
        Me.lblCxnGood.Visible = False
        '
        'lblCxnBad
        '
        Me.lblCxnBad.AutoSize = True
        Me.lblCxnBad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCxnBad.Location = New System.Drawing.Point(91, 115)
        Me.lblCxnBad.Name = "lblCxnBad"
        Me.lblCxnBad.Size = New System.Drawing.Size(161, 20)
        Me.lblCxnBad.TabIndex = 27
        Me.lblCxnBad.Text = "Unable to connect!"
        Me.lblCxnBad.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(243, 386)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(144, 13)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "By keithrickard@hotmail.com"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(128, 378)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(61, 56)
        Me.PictureBox3.TabIndex = 31
        Me.PictureBox3.TabStop = False
        '
        'pbxMeade
        '
        Me.pbxMeade.Image = CType(resources.GetObject("pbxMeade.Image"), System.Drawing.Image)
        Me.pbxMeade.Location = New System.Drawing.Point(66, 378)
        Me.pbxMeade.Name = "pbxMeade"
        Me.pbxMeade.Size = New System.Drawing.Size(56, 56)
        Me.pbxMeade.TabIndex = 24
        Me.pbxMeade.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(264, 48)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(125, 199)
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'pbxASCOM
        '
        Me.pbxASCOM.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbxASCOM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.pbxASCOM.Image = CType(resources.GetObject("pbxASCOM.Image"), System.Drawing.Image)
        Me.pbxASCOM.Location = New System.Drawing.Point(14, 378)
        Me.pbxASCOM.Name = "pbxASCOM"
        Me.pbxASCOM.Size = New System.Drawing.Size(48, 56)
        Me.pbxASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pbxASCOM.TabIndex = 2
        Me.pbxASCOM.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(151, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 13)
        Me.Label7.TabIndex = 20
        Me.Label7.Text = "South is 0 hours"
        '
        'nudFocalReducer
        '
        Me.nudFocalReducer.Location = New System.Drawing.Point(116, 183)
        Me.nudFocalReducer.Maximum = New Decimal(New Integer() {400, 0, 0, 0})
        Me.nudFocalReducer.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudFocalReducer.Name = "nudFocalReducer"
        Me.nudFocalReducer.Size = New System.Drawing.Size(44, 20)
        Me.nudFocalReducer.TabIndex = 32
        Me.nudFocalReducer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudFocalReducer.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.nudHA)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.nudDEC)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(249, 79)
        Me.GroupBox1.TabIndex = 34
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Home position"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(152, 47)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 24)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "°"
        '
        'nudElevation
        '
        Me.nudElevation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nudElevation.Location = New System.Drawing.Point(110, 234)
        Me.nudElevation.Maximum = New Decimal(New Integer() {4190, 0, 0, 0})
        Me.nudElevation.Minimum = New Decimal(New Integer() {400, 0, 0, -2147483648})
        Me.nudElevation.Name = "nudElevation"
        Me.nudElevation.Size = New System.Drawing.Size(50, 20)
        Me.nudElevation.TabIndex = 21
        Me.nudElevation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudElevation.Value = New Decimal(New Integer() {65, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(14, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 33
        Me.Label10.Text = "Focal reduction"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(163, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 15)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(14, 212)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(92, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Max Slew Rate"
        '
        'nudMaxSlewRate
        '
        Me.nudMaxSlewRate.Location = New System.Drawing.Point(116, 209)
        Me.nudMaxSlewRate.Maximum = New Decimal(New Integer() {8, 0, 0, 0})
        Me.nudMaxSlewRate.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.nudMaxSlewRate.Name = "nudMaxSlewRate"
        Me.nudMaxSlewRate.Size = New System.Drawing.Size(44, 20)
        Me.nudMaxSlewRate.TabIndex = 36
        Me.nudMaxSlewRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMaxSlewRate.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(162, 205)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(16, 24)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "°"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(173, 211)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 13)
        Me.Label14.TabIndex = 38
        Me.Label14.Text = "per sec"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 237)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Elevation"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(162, 237)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Metres"
        '
        'btnLibrary
        '
        Me.btnLibrary.Location = New System.Drawing.Point(312, 271)
        Me.btnLibrary.Name = "btnLibrary"
        Me.btnLibrary.Size = New System.Drawing.Size(75, 23)
        Me.btnLibrary.TabIndex = 39
        Me.btnLibrary.Text = "Library"
        Me.btnLibrary.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(328, 370)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "V1.210425"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(14, 262)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 13)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Max slew DEC"
        '
        'nudMaxDec
        '
        Me.nudMaxDec.Location = New System.Drawing.Point(110, 259)
        Me.nudMaxDec.Maximum = New Decimal(New Integer() {90, 0, 0, 0})
        Me.nudMaxDec.Minimum = New Decimal(New Integer() {90, 0, 0, -2147483648})
        Me.nudMaxDec.Name = "nudMaxDec"
        Me.nudMaxDec.Size = New System.Drawing.Size(50, 20)
        Me.nudMaxDec.TabIndex = 42
        Me.nudMaxDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudMaxDec.Value = New Decimal(New Integer() {70, 0, 0, 0})
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(161, 256)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(16, 24)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "°"
        '
        'frmSetup
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(404, 445)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.nudMaxDec)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnLibrary)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.nudElevation)
        Me.Controls.Add(Me.nudMaxSlewRate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.nudFocalReducer)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.lblCxnBad)
        Me.Controls.Add(Me.lblCxnGood)
        Me.Controls.Add(Me.btnCheck)
        Me.Controls.Add(Me.pbxMeade)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cbxLX200)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.ComboBoxComPort)
        Me.Controls.Add(Me.chkTrace)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.pbxASCOM)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Meade LX200 Classic Driver Setup"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.nudHA, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDEC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxMeade, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbxASCOM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudFocalReducer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudElevation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxSlewRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMaxDec, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents pbxASCOM As System.Windows.Forms.PictureBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents chkTrace As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxComPort As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents nudHA As NumericUpDown
    Friend WithEvents nudDEC As NumericUpDown
    Friend WithEvents cbxLX200 As ComboBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents pbxMeade As PictureBox
    Friend WithEvents btnCheck As Button
    Friend WithEvents lblCxnGood As Label
    Friend WithEvents lblCxnBad As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents nudFocalReducer As NumericUpDown
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents nudMaxSlewRate As NumericUpDown
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents nudElevation As NumericUpDown
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents btnLibrary As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents nudMaxDec As NumericUpDown
    Friend WithEvents Label19 As Label
End Class
