<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLibrary
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.cbxSolarSystem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudMessier = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.nudNGC = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.nudUGC = New System.Windows.Forms.NumericUpDown()
        Me.nudIC = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cbxNamedStars = New System.Windows.Forms.ComboBox()
        Me.nudAlignmentStars = New System.Windows.Forms.NumericUpDown()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpDetails = New System.Windows.Forms.GroupBox()
        Me.lstDetails = New System.Windows.Forms.ListBox()
        Me.lblQuality = New System.Windows.Forms.Label()
        Me.lblSize = New System.Windows.Forms.Label()
        Me.lblType = New System.Windows.Forms.Label()
        Me.lblMag = New System.Windows.Forms.Label()
        Me.lblDec = New System.Windows.Forms.Label()
        Me.lblRA = New System.Windows.Forms.Label()
        Me.lblConst = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.radNamedStars = New System.Windows.Forms.RadioButton()
        Me.radSolarSystem = New System.Windows.Forms.RadioButton()
        Me.radMessier = New System.Windows.Forms.RadioButton()
        Me.radNGC = New System.Windows.Forms.RadioButton()
        Me.radIC = New System.Windows.Forms.RadioButton()
        Me.radUGC = New System.Windows.Forms.RadioButton()
        Me.radAlignment = New System.Windows.Forms.RadioButton()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnGoto = New System.Windows.Forms.Button()
        Me.grpTelescope = New System.Windows.Forms.GroupBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblCurrDec = New System.Windows.Forms.Label()
        Me.lblCurrRA = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnStop = New System.Windows.Forms.Button()
        CType(Me.nudMessier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudNGC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudUGC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudIC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAlignmentStars, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDetails.SuspendLayout()
        Me.grpTelescope.SuspendLayout()
        Me.SuspendLayout()
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(9, 285)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "Done"
        '
        'cbxSolarSystem
        '
        Me.cbxSolarSystem.FormattingEnabled = True
        Me.cbxSolarSystem.Location = New System.Drawing.Point(118, 73)
        Me.cbxSolarSystem.Name = "cbxSolarSystem"
        Me.cbxSolarSystem.Size = New System.Drawing.Size(121, 21)
        Me.cbxSolarSystem.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Solar System"
        '
        'nudMessier
        '
        Me.nudMessier.Location = New System.Drawing.Point(118, 99)
        Me.nudMessier.Maximum = New Decimal(New Integer() {110, 0, 0, 0})
        Me.nudMessier.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMessier.Name = "nudMessier"
        Me.nudMessier.Size = New System.Drawing.Size(59, 20)
        Me.nudMessier.TabIndex = 3
        Me.nudMessier.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Messier"
        '
        'nudNGC
        '
        Me.nudNGC.Location = New System.Drawing.Point(118, 124)
        Me.nudNGC.Maximum = New Decimal(New Integer() {7840, 0, 0, 0})
        Me.nudNGC.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudNGC.Name = "nudNGC"
        Me.nudNGC.Size = New System.Drawing.Size(58, 20)
        Me.nudNGC.TabIndex = 5
        Me.nudNGC.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 129)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "NGC"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(30, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "UGC"
        '
        'nudUGC
        '
        Me.nudUGC.Location = New System.Drawing.Point(118, 174)
        Me.nudUGC.Maximum = New Decimal(New Integer() {12921, 0, 0, 0})
        Me.nudUGC.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudUGC.Name = "nudUGC"
        Me.nudUGC.Size = New System.Drawing.Size(58, 20)
        Me.nudUGC.TabIndex = 8
        Me.nudUGC.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'nudIC
        '
        Me.nudIC.Location = New System.Drawing.Point(118, 149)
        Me.nudIC.Maximum = New Decimal(New Integer() {5386, 0, 0, 0})
        Me.nudIC.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudIC.Name = "nudIC"
        Me.nudIC.Size = New System.Drawing.Size(58, 20)
        Me.nudIC.TabIndex = 9
        Me.nudIC.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(30, 154)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "IC"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(30, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Named Stars"
        '
        'cbxNamedStars
        '
        Me.cbxNamedStars.FormattingEnabled = True
        Me.cbxNamedStars.Location = New System.Drawing.Point(118, 48)
        Me.cbxNamedStars.Name = "cbxNamedStars"
        Me.cbxNamedStars.Size = New System.Drawing.Size(121, 21)
        Me.cbxNamedStars.TabIndex = 12
        '
        'nudAlignmentStars
        '
        Me.nudAlignmentStars.Location = New System.Drawing.Point(117, 198)
        Me.nudAlignmentStars.Maximum = New Decimal(New Integer() {351, 0, 0, 0})
        Me.nudAlignmentStars.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudAlignmentStars.Name = "nudAlignmentStars"
        Me.nudAlignmentStars.Size = New System.Drawing.Size(59, 20)
        Me.nudAlignmentStars.TabIndex = 15
        Me.nudAlignmentStars.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(30, 203)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Alignment Stars"
        '
        'grpDetails
        '
        Me.grpDetails.Controls.Add(Me.lstDetails)
        Me.grpDetails.Controls.Add(Me.lblQuality)
        Me.grpDetails.Controls.Add(Me.lblSize)
        Me.grpDetails.Controls.Add(Me.lblType)
        Me.grpDetails.Controls.Add(Me.lblMag)
        Me.grpDetails.Controls.Add(Me.lblDec)
        Me.grpDetails.Controls.Add(Me.lblRA)
        Me.grpDetails.Controls.Add(Me.lblConst)
        Me.grpDetails.Controls.Add(Me.lblName)
        Me.grpDetails.Controls.Add(Me.Label19)
        Me.grpDetails.Controls.Add(Me.Label16)
        Me.grpDetails.Controls.Add(Me.Label15)
        Me.grpDetails.Controls.Add(Me.Label14)
        Me.grpDetails.Controls.Add(Me.Label13)
        Me.grpDetails.Controls.Add(Me.Label12)
        Me.grpDetails.Controls.Add(Me.Label11)
        Me.grpDetails.Controls.Add(Me.Label10)
        Me.grpDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDetails.Location = New System.Drawing.Point(301, 32)
        Me.grpDetails.Name = "grpDetails"
        Me.grpDetails.Size = New System.Drawing.Size(179, 227)
        Me.grpDetails.TabIndex = 19
        Me.grpDetails.TabStop = False
        Me.grpDetails.Text = "Object Details"
        '
        'lstDetails
        '
        Me.lstDetails.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDetails.FormattingEnabled = True
        Me.lstDetails.ItemHeight = 14
        Me.lstDetails.Location = New System.Drawing.Point(14, 187)
        Me.lstDetails.Name = "lstDetails"
        Me.lstDetails.Size = New System.Drawing.Size(154, 32)
        Me.lstDetails.TabIndex = 41
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = True
        Me.lblQuality.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuality.Location = New System.Drawing.Point(55, 165)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New System.Drawing.Size(10, 13)
        Me.lblQuality.TabIndex = 40
        Me.lblQuality.Text = " "
        '
        'lblSize
        '
        Me.lblSize.AutoSize = True
        Me.lblSize.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSize.Location = New System.Drawing.Point(55, 145)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(10, 13)
        Me.lblSize.TabIndex = 39
        Me.lblSize.Text = " "
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblType.Location = New System.Drawing.Point(55, 125)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(10, 13)
        Me.lblType.TabIndex = 38
        Me.lblType.Text = " "
        '
        'lblMag
        '
        Me.lblMag.AutoSize = True
        Me.lblMag.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMag.Location = New System.Drawing.Point(55, 105)
        Me.lblMag.Name = "lblMag"
        Me.lblMag.Size = New System.Drawing.Size(10, 13)
        Me.lblMag.TabIndex = 37
        Me.lblMag.Text = " "
        '
        'lblDec
        '
        Me.lblDec.AutoSize = True
        Me.lblDec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDec.Location = New System.Drawing.Point(55, 85)
        Me.lblDec.Name = "lblDec"
        Me.lblDec.Size = New System.Drawing.Size(10, 13)
        Me.lblDec.TabIndex = 34
        Me.lblDec.Text = " "
        '
        'lblRA
        '
        Me.lblRA.AutoSize = True
        Me.lblRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRA.Location = New System.Drawing.Point(55, 65)
        Me.lblRA.Name = "lblRA"
        Me.lblRA.Size = New System.Drawing.Size(10, 13)
        Me.lblRA.TabIndex = 33
        Me.lblRA.Text = " "
        '
        'lblConst
        '
        Me.lblConst.AutoSize = True
        Me.lblConst.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConst.Location = New System.Drawing.Point(55, 45)
        Me.lblConst.Name = "lblConst"
        Me.lblConst.Size = New System.Drawing.Size(10, 13)
        Me.lblConst.TabIndex = 32
        Me.lblConst.Text = " "
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(55, 25)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(10, 13)
        Me.lblName.TabIndex = 31
        Me.lblName.Text = " "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(10, 45)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 30
        Me.Label19.Text = "Const"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(10, 165)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Quality"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 145)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(27, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Size"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(10, 125)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Type"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(28, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Mag"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Object"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 85)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Dec"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 65)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "RA"
        '
        'radNamedStars
        '
        Me.radNamedStars.AutoSize = True
        Me.radNamedStars.Location = New System.Drawing.Point(244, 53)
        Me.radNamedStars.Name = "radNamedStars"
        Me.radNamedStars.Size = New System.Drawing.Size(14, 13)
        Me.radNamedStars.TabIndex = 20
        Me.radNamedStars.TabStop = True
        Me.radNamedStars.UseVisualStyleBackColor = True
        '
        'radSolarSystem
        '
        Me.radSolarSystem.AutoSize = True
        Me.radSolarSystem.Location = New System.Drawing.Point(244, 78)
        Me.radSolarSystem.Name = "radSolarSystem"
        Me.radSolarSystem.Size = New System.Drawing.Size(14, 13)
        Me.radSolarSystem.TabIndex = 21
        Me.radSolarSystem.TabStop = True
        Me.radSolarSystem.UseVisualStyleBackColor = True
        '
        'radMessier
        '
        Me.radMessier.AutoSize = True
        Me.radMessier.Location = New System.Drawing.Point(244, 102)
        Me.radMessier.Name = "radMessier"
        Me.radMessier.Size = New System.Drawing.Size(14, 13)
        Me.radMessier.TabIndex = 22
        Me.radMessier.TabStop = True
        Me.radMessier.UseVisualStyleBackColor = True
        '
        'radNGC
        '
        Me.radNGC.AutoSize = True
        Me.radNGC.Location = New System.Drawing.Point(244, 127)
        Me.radNGC.Name = "radNGC"
        Me.radNGC.Size = New System.Drawing.Size(14, 13)
        Me.radNGC.TabIndex = 23
        Me.radNGC.TabStop = True
        Me.radNGC.UseVisualStyleBackColor = True
        '
        'radIC
        '
        Me.radIC.AutoSize = True
        Me.radIC.Location = New System.Drawing.Point(244, 152)
        Me.radIC.Name = "radIC"
        Me.radIC.Size = New System.Drawing.Size(14, 13)
        Me.radIC.TabIndex = 24
        Me.radIC.TabStop = True
        Me.radIC.UseVisualStyleBackColor = True
        '
        'radUGC
        '
        Me.radUGC.AutoSize = True
        Me.radUGC.Location = New System.Drawing.Point(244, 177)
        Me.radUGC.Name = "radUGC"
        Me.radUGC.Size = New System.Drawing.Size(14, 13)
        Me.radUGC.TabIndex = 25
        Me.radUGC.TabStop = True
        Me.radUGC.UseVisualStyleBackColor = True
        '
        'radAlignment
        '
        Me.radAlignment.AutoSize = True
        Me.radAlignment.Location = New System.Drawing.Point(244, 201)
        Me.radAlignment.Name = "radAlignment"
        Me.radAlignment.Size = New System.Drawing.Size(14, 13)
        Me.radAlignment.TabIndex = 27
        Me.radAlignment.TabStop = True
        Me.radAlignment.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(178, 104)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(37, 13)
        Me.Label20.TabIndex = 29
        Me.Label20.Text = "of 110"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(178, 129)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(43, 13)
        Me.Label21.TabIndex = 30
        Me.Label21.Text = "of 7840"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(178, 154)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 13)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "of 5386"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(178, 179)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 13)
        Me.Label23.TabIndex = 32
        Me.Label23.Text = "of 12921"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(178, 203)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 13)
        Me.Label25.TabIndex = 34
        Me.Label25.Text = "of 315"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Comic Sans MS", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 3)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(184, 34)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "LX200 Library"
        '
        'btnGoto
        '
        Me.btnGoto.Location = New System.Drawing.Point(9, 236)
        Me.btnGoto.Name = "btnGoto"
        Me.btnGoto.Size = New System.Drawing.Size(67, 23)
        Me.btnGoto.TabIndex = 36
        Me.btnGoto.Text = "Go to"
        Me.btnGoto.UseVisualStyleBackColor = True
        '
        'grpTelescope
        '
        Me.grpTelescope.Controls.Add(Me.lblStatus)
        Me.grpTelescope.Controls.Add(Me.lblCurrDec)
        Me.grpTelescope.Controls.Add(Me.lblCurrRA)
        Me.grpTelescope.Controls.Add(Me.Label26)
        Me.grpTelescope.Controls.Add(Me.Label24)
        Me.grpTelescope.Controls.Add(Me.Label9)
        Me.grpTelescope.Location = New System.Drawing.Point(93, 230)
        Me.grpTelescope.Name = "grpTelescope"
        Me.grpTelescope.Size = New System.Drawing.Size(178, 78)
        Me.grpTelescope.TabIndex = 37
        Me.grpTelescope.TabStop = False
        Me.grpTelescope.Text = "Telescope Position"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(60, 58)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(41, 13)
        Me.lblStatus.TabIndex = 5
        Me.lblStatus.Text = "Parked"
        '
        'lblCurrDec
        '
        Me.lblCurrDec.AutoSize = True
        Me.lblCurrDec.Location = New System.Drawing.Point(60, 38)
        Me.lblCurrDec.Name = "lblCurrDec"
        Me.lblCurrDec.Size = New System.Drawing.Size(69, 13)
        Me.lblCurrDec.TabIndex = 4
        Me.lblCurrDec.Text = "+00°  00' 00"""
        '
        'lblCurrRA
        '
        Me.lblCurrRA.AutoSize = True
        Me.lblCurrRA.Location = New System.Drawing.Point(60, 18)
        Me.lblCurrRA.Name = "lblCurrRA"
        Me.lblCurrRA.Size = New System.Drawing.Size(68, 13)
        Me.lblCurrRA.TabIndex = 3
        Me.lblCurrRA.Text = "00h 00m 00s"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(11, 58)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 13)
        Me.Label26.TabIndex = 2
        Me.Label26.Text = "Status"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(11, 38)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(27, 13)
        Me.Label24.TabIndex = 1
        Me.Label24.Text = "Dec"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 13)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "RA"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'btnStop
        '
        Me.btnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(9, 261)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(67, 23)
        Me.btnStop.TabIndex = 38
        Me.btnStop.Text = "STOP"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'frmLibrary
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(505, 320)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.grpTelescope)
        Me.Controls.Add(Me.btnGoto)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.OK_Button)
        Me.Controls.Add(Me.radAlignment)
        Me.Controls.Add(Me.radUGC)
        Me.Controls.Add(Me.radIC)
        Me.Controls.Add(Me.radNGC)
        Me.Controls.Add(Me.radMessier)
        Me.Controls.Add(Me.radSolarSystem)
        Me.Controls.Add(Me.radNamedStars)
        Me.Controls.Add(Me.grpDetails)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.nudAlignmentStars)
        Me.Controls.Add(Me.cbxNamedStars)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nudIC)
        Me.Controls.Add(Me.nudUGC)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.nudNGC)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.nudMessier)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cbxSolarSystem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLibrary"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Meade LX200 Classic Library"
        CType(Me.nudMessier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudNGC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudUGC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudIC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAlignmentStars, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDetails.ResumeLayout(False)
        Me.grpDetails.PerformLayout()
        Me.grpTelescope.ResumeLayout(False)
        Me.grpTelescope.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents cbxSolarSystem As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents nudMessier As NumericUpDown
    Friend WithEvents Label2 As Label
    Friend WithEvents nudNGC As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents nudUGC As NumericUpDown
    Friend WithEvents nudIC As NumericUpDown
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents cbxNamedStars As ComboBox
    Friend WithEvents nudAlignmentStars As NumericUpDown
    Friend WithEvents Label8 As Label
    Friend WithEvents grpDetails As GroupBox
    Friend WithEvents radNamedStars As RadioButton
    Friend WithEvents radSolarSystem As RadioButton
    Friend WithEvents radMessier As RadioButton
    Friend WithEvents radNGC As RadioButton
    Friend WithEvents radIC As RadioButton
    Friend WithEvents radUGC As RadioButton
    Friend WithEvents radAlignment As RadioButton
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents lblQuality As Label
    Friend WithEvents lblSize As Label
    Friend WithEvents lblType As Label
    Friend WithEvents lblMag As Label
    Friend WithEvents lblDec As Label
    Friend WithEvents lblRA As Label
    Friend WithEvents lblConst As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lstDetails As ListBox
    Friend WithEvents Label7 As Label
    Friend WithEvents btnGoto As Button
    Friend WithEvents grpTelescope As GroupBox
    Friend WithEvents lblStatus As Label
    Friend WithEvents lblCurrDec As Label
    Friend WithEvents lblCurrRA As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents btnStop As Button
End Class
