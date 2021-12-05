'tabs=4

' This definition is used to select code that's only applicable for one device type
#Const Device = "Telescope"

'Imports System
'Imports System.Collections
'Imports System.Collections.Generic
'Imports System.Globalization
'Imports System.IO
'Imports System.Runtime.InteropServices
'Imports System.Text
'Imports ASCOM
Imports System.IO.Ports
Imports ASCOM.Astrometry
Imports ASCOM.Astrometry.AstroUtils
Imports ASCOM.DeviceInterface
Imports ASCOM.Utilities

<Guid("AD1585B6-0186-4901-A601-7240993BCC7A")>
<ClassInterface(ClassInterfaceType.None)>
Public Class Telescope

    Implements ITelescopeV3

    ' Driver ID and descriptive string that shows in the Chooser
    Friend Shared driverID As String = "ASCOM.MeadeLX200Classic.Telescope"
    Private Shared driverDescription As String = "Meade LX200 Classic"

    ' Constants used for Profile persistence
    Friend Shared comPortProfileName As String = "COM Port"
    Friend Shared updateClockName As String = "Update LX200 clock"
    Friend Shared traceStateProfileName As String = "Trace Level"
    Friend Shared homePositionHAName As String = "Home Position Hour Angle"
    Friend Shared homePositionDECName As String = "Home Position Declination"
    Friend Shared modelName As String = "LX200 Model"
    Friend Shared focalReducerName As String = "Focal Reducer"
    Friend Shared maxSlewRateName As String = "Max Slew Rate"
    Friend Shared elevationName As String = "Elevation"
    Friend Shared maxSlewDECName As String = "Max Slew Dec"

    Friend Shared comPortDefault As String = "COM1"
    Friend Shared updateClockDefault As String = "True"
    Friend Shared traceStateDefault As String = "False"
    Friend Shared homePositionHADefault As Decimal = 0
    Friend Shared homePositionDECDefault As Decimal = -35
    Friend Shared modelDefault As String = "10"" SCT F10"
    Friend Shared focalReducerDefault As Decimal = 100
    Friend Shared maxSlewRateDefault As Decimal = 3
    Friend Shared elevationDefault As Decimal = 65
    Friend Shared maxSlewDECDefault As Decimal = 70

    Friend Shared comPort As String ' Variables to hold the current device configuration
    Friend Shared updateClock As Boolean
    Friend Shared traceState As Boolean
    Friend Shared homePositionHA As Decimal
    Friend Shared homePositionDEC As Decimal
    Friend Shared model As String
    Friend Shared focalReducer As Decimal
    Friend Shared maxSlewRate As Decimal
    Friend Shared elevation As Decimal
    Friend Shared maxSlewDEC As Decimal

    Private connectedState As Boolean ' Private variable to hold the connected state
    Private utilities As Util ' Private variable to hold an ASCOM Utilities object
    Private astroUtilities As AstroUtils ' Private variable to hold an AstroUtils object to provide the Range method
    Private TL As TraceLogger ' Private variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
    Private lxTracking As Boolean = True
    Private lxAtHome As Boolean = False
    Private lxSlewSettleTime As Double = 3
    Private lxLatitude As Double = 0
    Private lxLongitude As Double = 0
    Private lxTargetDEC As Double = 0
    Private lxTargetRA As Double = 0
    Private lxSlewing As Boolean = 0
    Private lxTrackingRate As DriveRates
    Private lxIsPulseGuiding As Boolean = False
    Private lxSlewingCoords As String = ""
    Private pad As Integer = -1

    '
    ' Constructor - Must be public for COM registration!
    '
    Public Sub New()
        pad += 1
        ReadProfile() ' Read device configuration from the ASCOM Profile store
        TL = New TraceLogger("", driverDescription)
        TL.Enabled = traceState
        TL.LogMessage(Space(pad) + "Telescope", "Starting initialisation")

        connectedState = False ' Initialise connected to false
        utilities = New Util() ' Initialise util object
        astroUtilities = New AstroUtils 'Initialise new astro utilities object

        'TODO: Implement your additional construction here

        TL.LogMessage(Space(pad) + "Telescope", "Completed initialisation")
        pad -= 1
    End Sub

    '
    ' PUBLIC COM INTERFACE ITelescopeV3 IMPLEMENTATION
    '

#Region "Common properties And methods"
    ''' <summary>
    ''' Displays the Setup Dialog form.
    ''' If the user clicks the OK button to dismiss the form, then
    ''' the new settings are saved, otherwise the old values are reloaded.
    ''' THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
    ''' </summary>
    Public Sub SetupDialog() Implements ITelescopeV3.SetupDialog
        ' consider only showing the setup dialog if not connected
        ' or call a different dialog if connected
        'If IsConnected Then System.Windows.Forms.MessageBox.Show("Already connected, just press OK")

        Using F As frmSetup = New frmSetup()
            Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
            If result = DialogResult.OK Then
                WriteProfile() ' Persist device configuration values to the ASCOM Profile store
            End If
        End Using
    End Sub

    Public ReadOnly Property SupportedActions() As ArrayList Implements ITelescopeV3.SupportedActions
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "SupportedActions Get", "Returning empty arraylist")
            pad -= 1
            Return New ArrayList()
        End Get
    End Property

    Public Function Action(ByVal ActionName As String, ByVal ActionParameters As String) As String Implements ITelescopeV3.Action
        Throw New ActionNotImplementedException("Action " & ActionName & " Is Not supported by this driver")
    End Function

    Public Sub CommandBlind(ByVal Command As String, Optional ByVal Raw As Boolean = False) Implements ITelescopeV3.CommandBlind
        CheckConnected("CommandBlind")
        ' Call CommandString and return as soon as it finishes
        Me.CommandString(Command, Raw)
        ' or
        Throw New MethodNotImplementedException("CommandBlind")
    End Sub

    Public Function CommandBool(ByVal Command As String, Optional ByVal Raw As Boolean = False) As Boolean _
        Implements ITelescopeV3.CommandBool
        CheckConnected("CommandBool")
        Dim ret As String = CommandString(Command, Raw)
        ' TODO decode the return string and return true or false
        ' or
        Throw New MethodNotImplementedException("CommandBool")
    End Function

    Public Function CommandString(ByVal Command As String, Optional ByVal Raw As Boolean = False) As String _
        Implements ITelescopeV3.CommandString
        CheckConnected("CommandString")
        ' it's a good idea to put all the low level communication with the device here,
        ' then all communication calls this function
        ' you need something to ensure that only one command is in progress at a time
        Throw New MethodNotImplementedException("CommandString")
    End Function

    Public Property Connected() As Boolean Implements ITelescopeV3.Connected
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "Connected Get", "Connect Get:" + IsConnected.ToString())
            pad -= 1
            Return IsConnected
        End Get
        Set(value As Boolean)
            'If traceState Andalso Not Value Then MsgBox("Trace file: " + TL.LogFileName)
            pad += 1
            TL.LogMessage(Space(pad) + "Connected Set", "Connect Set: " + value.ToString())
            If value = IsConnected Then
                pad -= 1
                Return
            End If

            If value Then
                If Len(SerialCommand("GT", -1)) = 4 Then          ' Check connection to LX200
                    TL.LogMessage(Space(pad) + "Connected Set", "Connected To port " + comPort)
                    ' TODO connect to the device
                    LX200Startup()
                    connectedState = True
                Else
                    connectedState = False
                End If
            Else
                connectedState = False
                TL.LogMessage(Space(pad) + "Connected Set", "Disconnected from port " + comPort)
                ' TODO disconnect from the device
            End If
            pad -= 1
        End Set
    End Property

    Public ReadOnly Property Description As String Implements ITelescopeV3.Description
        Get
            ' this pattern seems to be needed to allow a public property to return a private field
            Dim d As String = driverDescription
            pad += 1
            TL.LogMessage(Space(pad) + "Description Get", d)
            pad -= 1
            Return d
        End Get
    End Property

    Public ReadOnly Property DriverInfo As String Implements ITelescopeV3.DriverInfo
        Get
            pad += 1
            Dim m_version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version
            ' TODO customise this driver description
            Dim s_driverInfo As String = "For the Meade LX200 Classic with firmware 3.30+, version: " + m_version.Major.ToString() + "." + m_version.Minor.ToString()
            TL.LogMessage(Space(pad) + "DriverInfo Get", s_driverInfo)
            pad -= 1
            Return s_driverInfo
        End Get
    End Property

    Public ReadOnly Property DriverVersion() As String Implements ITelescopeV3.DriverVersion
        Get
            ' Get our own assembly and report its version number
            pad += 1
            TL.LogMessage(Space(pad) + "DriverVersion Get", Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2))
            pad -= 1
            Return Reflection.Assembly.GetExecutingAssembly.GetName.Version.ToString(2)
        End Get
    End Property

    Public ReadOnly Property InterfaceVersion() As Short Implements ITelescopeV3.InterfaceVersion
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "InterfaceVersion Get", "3")
            pad -= 1
            Return 3
        End Get
    End Property

    Public ReadOnly Property Name As String Implements ITelescopeV3.Name
        Get
            pad += 1
            Dim s_name As String = "LX200 Classic"
            TL.LogMessage(Space(pad) + "Name Get", s_name)
            pad -= 1
            Return s_name
        End Get
    End Property

    Public Sub Dispose() Implements ITelescopeV3.Dispose
        ' Clean up the trace logger and util objects
        TL.Enabled = False
        TL.Dispose()
        TL = Nothing
        utilities.Dispose()
        utilities = Nothing
        astroUtilities.Dispose()
        astroUtilities = Nothing
    End Sub

#End Region

#Region "ITelescope Implementation"
    Public Sub AbortSlew() Implements ITelescopeV3.AbortSlew
        pad += 1
        TL.LogMessage(Space(pad) + "AbortSlew", "Aborting slew")
        SerialCommand("Q", 0)                                   ' Stop any slewing
        SerialCommand("Qn", 0)                                  ' Stop any other motion
        SerialCommand("Qs", 0)
        SerialCommand("Qw", 0)
        If Not lxTracking Then SerialCommand("Qe", 0)
        utilities.WaitForMilliseconds(200)
        SerialCommand("Q", 0)                                   ' Send Abort command twice to ensure telescope stops
        SerialCommand("Qn", 0)
        SerialCommand("Qs", 0)
        SerialCommand("Qw", 0)
        If Not lxTracking Then SerialCommand("Qe", 0)
        utilities.WaitForMilliseconds(lxSlewSettleTime * 1000)  ' Wait some time to settle
        Dim str As String = LongFormat("GR")                    ' Make LX200's target coordinates the same as the current ones
        SerialCommand("Sr" + str, 1)
        lxTargetRA = HMS2Hrs(str)
        str = LongFormat("GD")
        SerialCommand("Sd" + str, 1)
        lxTargetDEC = DMS2Degs(str)
        lxSlewing = False                                       ' No longer slewing
        pad -= 1
    End Sub

    Public ReadOnly Property AlignmentMode() As AlignmentModes Implements ITelescopeV3.AlignmentMode
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "AlignmentMode Get", "Polar mode")
            pad -= 1
            Return AlignmentModes.algPolar
        End Get
    End Property

    Public ReadOnly Property Altitude() As Double Implements ITelescopeV3.Altitude
        Get
            Dim alt As String
            alt = SerialCommand(":GA#", -1)
            pad += 1
            TL.LogMessage(Space(pad) + "Altitude", "Got altitude: " + alt)
            pad -= 1
            Return DMS2Degs(alt)
        End Get
    End Property

    Public ReadOnly Property ApertureArea() As Double Implements ITelescopeV3.ApertureArea
        Get ' Returns aperture area, less obstructions, in squared metres
            pad += 1
            Dim Area As Double = 0.174915422
            If model = "7"" Mak F15" Then Area = 0.103102648    ' 12.8% Secondary mirror obstruction
            If model = "8"" SCT F6.3" Then Area = 0.10538198    ' 18.6%
            If model = "8"" SCT F10" Then Area = 0.111207765    ' 14.1%
            If model = "10"" SCT F6.3" Then Area = 0.170253713  ' 16.0%
            If model = "10"" SCT F10" Then Area = 0.174915422   ' 13.7%
            If model = "12"" SCT F10" Then Area = 0.259807278   ' 11.1 %
            If model = "16"" SCT F10" Then Area = 0.467098505   ' 9.8%
            TL.LogMessage(Space(pad) + "ApertureArea Get", "Aperture Area for " + model + " = " + Area.ToString)
            pad -= 1
            Return Area
        End Get
    End Property

    Public ReadOnly Property ApertureDiameter() As Double Implements ITelescopeV3.ApertureDiameter
        Get ' Returns aperture diameter in metres
            pad += 1
            Dim Diameter As Double = 0.254
            If model = "7"" Mak F15" Then Diameter = 0.194
            If model = "8"" SCT F6.3" Then Diameter = 0.203
            If model = "8"" SCT F10" Then Diameter = 0.203
            If model = "10"" SCT F6.3" Then Diameter = 0.254
            If model = "10"" SCT F10" Then Diameter = 0.254
            If model = "12"" SCT F10" Then Diameter = 0.305
            If model = "16"" SCT F10" Then Diameter = 0.406
            TL.LogMessage(Space(pad) + "ApertureDiameter Get", "Aperture Diameter for " + model + " = " + Diameter.ToString)
            pad -= 1
            Return Diameter
        End Get
    End Property

    Public ReadOnly Property AtHome() As Boolean Implements ITelescopeV3.AtHome
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "AtHome", "Get - " & AtPark.ToString())
            If AtPark Then lxAtHome = True
            pad -= 1
            Return lxAtHome
        End Get
    End Property

    Public ReadOnly Property AtPark() As Boolean Implements ITelescopeV3.AtPark
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "AtPark", "Getting AtPark...")
            Dim lxAtPark As Boolean = (Trim(SerialCommand("G2", -1)) <> "LAND")
            TL.LogMessage(Space(pad) + "AtPark", "Get: " & lxAtPark.ToString())
            lxAtHome = lxAtPark
            pad -= 1
            Return lxAtPark
        End Get
    End Property

    Public Function AxisRates(Axis As TelescopeAxes) As IAxisRates Implements ITelescopeV3.AxisRates
        pad += 1
        TL.LogMessage(Space(pad) + "AxisRates", "Get - " & Axis.ToString())
        pad -= 1
        Return New AxisRates(Axis)
    End Function

    Public ReadOnly Property Azimuth() As Double Implements ITelescopeV3.Azimuth
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "Azimuth Get", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("Azimuth", False)
        End Get
    End Property

    Public ReadOnly Property CanFindHome() As Boolean Implements ITelescopeV3.CanFindHome
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanFindHome", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public Function CanMoveAxis(Axis As TelescopeAxes) As Boolean Implements ITelescopeV3.CanMoveAxis
        pad += 1
        TL.LogMessage(Space(pad) + "CanMoveAxis", "Get: " & Axis.ToString())
        pad -= 1
        Select Case Axis
            Case TelescopeAxes.axisPrimary
                Return False
            Case TelescopeAxes.axisSecondary
                Return False
            Case TelescopeAxes.axisTertiary
                Return False
            Case Else
                Throw New InvalidValueException("CanMoveAxis", Axis.ToString(), "0 to 2")
        End Select
    End Function

    Public ReadOnly Property CanPark() As Boolean Implements ITelescopeV3.CanPark
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanPark", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanPulseGuide() As Boolean Implements ITelescopeV3.CanPulseGuide
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanPulseGuide", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSetDeclinationRate() As Boolean Implements ITelescopeV3.CanSetDeclinationRate
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSetDeclinationRate", "Get: " & False.ToString())
            pad -= 1
            Return False
        End Get
    End Property

    Public ReadOnly Property CanSetGuideRates() As Boolean Implements ITelescopeV3.CanSetGuideRates
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSetGuideRates", "Get: " & False.ToString())
            pad -= 1
            Return False
        End Get
    End Property

    Public ReadOnly Property CanSetPark() As Boolean Implements ITelescopeV3.CanSetPark
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSetPark", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSetPierSide() As Boolean Implements ITelescopeV3.CanSetPierSide
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSetPierSide", "Get: " & False.ToString())
            pad -= 1
            Return False
        End Get
    End Property

    Public ReadOnly Property CanSetRightAscensionRate() As Boolean Implements ITelescopeV3.CanSetRightAscensionRate
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSetRightAscensionRate", "Get: " & False.ToString())
            pad -= 1
            Return False
        End Get
    End Property

    Public ReadOnly Property CanSetTracking() As Boolean Implements ITelescopeV3.CanSetTracking
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSetTracking", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSlew() As Boolean Implements ITelescopeV3.CanSlew
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSlew", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSlewAltAz() As Boolean Implements ITelescopeV3.CanSlewAltAz
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSlewAltAz", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSlewAltAzAsync() As Boolean Implements ITelescopeV3.CanSlewAltAzAsync
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSlewAltAzAsync", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSlewAsync() As Boolean Implements ITelescopeV3.CanSlewAsync
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSlewAsync", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSync() As Boolean Implements ITelescopeV3.CanSync
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSync", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanSyncAltAz() As Boolean Implements ITelescopeV3.CanSyncAltAz
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanSyncAltAz", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property CanUnpark() As Boolean Implements ITelescopeV3.CanUnpark
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "CanUnpark", "Get: " & True.ToString())
            pad -= 1
            Return True
        End Get
    End Property

    Public ReadOnly Property Declination() As Double Implements ITelescopeV3.Declination
        Get
            pad += 1
            Dim DEC As Double
            If AtPark Then
                DEC = homePositionDEC
            Else
                DEC = DMS2Degs(LongFormat("GD"))
            End If
            TL.LogMessage(Space(pad) + "Declination", "Get: " & utilities.DegreesToDMS(DEC, ":", ":"))
            pad -= 1
            Return DEC
        End Get
    End Property

    Public Property DeclinationRate() As Double Implements ITelescopeV3.DeclinationRate
        Get
            Dim declination As Double = 0.0
            pad += 1
            TL.LogMessage(Space(pad) + "DeclinationRate", "Get: " & declination.ToString())
            pad -= 1
            Return declination
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "DeclinationRate Set", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("DeclinationRate", True)
        End Set
    End Property

    Public Function DestinationSideOfPier(RightAscension As Double, Declination As Double) As PierSide Implements ITelescopeV3.DestinationSideOfPier
        pad += 1
        TL.LogMessage(Space(pad) + "DestinationSideOfPier Get", "Not implemented")
        pad -= 1
        Throw New ASCOM.MethodNotImplementedException("DestinationSideOfPier")
    End Function

    Public Property DoesRefraction() As Boolean Implements ITelescopeV3.DoesRefraction
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "DoesRefraction Get", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("DoesRefraction", False)
        End Get
        Set(value As Boolean)
            pad += 1
            TL.LogMessage(Space(pad) + "DoesRefraction Set", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("DoesRefraction", True)
        End Set
    End Property

    Public ReadOnly Property EquatorialSystem() As EquatorialCoordinateType Implements ITelescopeV3.EquatorialSystem
        Get
            Dim equatorialSystem__1 As EquatorialCoordinateType = EquatorialCoordinateType.equTopocentric
            pad += 1
            TL.LogMessage(Space(pad) + "EquatorialSystem", "Get: " & equatorialSystem__1.ToString())
            pad -= 1
            Return equatorialSystem__1
        End Get
    End Property

    Public Sub FindHome() Implements ITelescopeV3.FindHome
        pad += 1
        TL.LogMessage(Space(pad) + "FindHome", "Going to Home Position")
        Throw New ASCOM.MethodNotImplementedException("FindHome")
        lxTargetDEC = homePositionDEC
        lxTargetRA = Norm24(HMS2Hrs(LongFormat("GS")) - homePositionHA)
        SlewToCoordinatesAsync(lxTargetRA, lxTargetDEC)
        Tracking = False
        lxAtHome = True
        pad -= 1
    End Sub

    Public ReadOnly Property FocalLength() As Double Implements ITelescopeV3.FocalLength
        Get
            pad += 1
            Dim focal As Double = 2.5
            TL.LogMessage(Space(pad) + "FocalLength Get", "Focal Length for " + model)
            'Throw New ASCOM.PropertyNotImplementedException("FocalLength", False)
            If model = "7"" Mak F15" Then focal = 2.67
            If model = "8"" SCT F6.3" Then focal = 1.28
            If model = "8"" SCT F10" Then focal = 2.0
            If model = "10"" SCT F6.3" Then focal = 1.6
            If model = "10"" SCT F10" Then focal = 2.5
            If model = "12"" SCT F10" Then focal = 3.048
            If model = "16"" SCT F10" Then focal = 4.064
            pad -= 1
            Return focal * focalReducer / 100
        End Get
    End Property

    Public Property GuideRateDeclination() As Double Implements ITelescopeV3.GuideRateDeclination
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "GuideRateDeclination Get", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("GuideRateDeclination", False)
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "GuideRateDeclination Set", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("GuideRateDeclination", True)
        End Set
    End Property

    Public Property GuideRateRightAscension() As Double Implements ITelescopeV3.GuideRateRightAscension
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "GuideRateRightAscension Get", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("GuideRateRightAscension", False)
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "GuideRateRightAscension Set", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("GuideRateRightAscension", True)
        End Set
    End Property

    Public ReadOnly Property IsPulseGuiding() As Boolean Implements ITelescopeV3.IsPulseGuiding
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "IsPulseGuiding Get", IIf(lxIsPulseGuiding, True.ToString, False.ToString))
            pad -= 1
            Return lxIsPulseGuiding
        End Get
    End Property

    Public Sub MoveAxis(Axis As TelescopeAxes, Rate As Double) Implements ITelescopeV3.MoveAxis
        pad += 1
        TL.LogMessage(Space(pad) + "MoveAxis", "Not implemented")
        pad -= 1
        Throw New ASCOM.MethodNotImplementedException("MoveAxis")
    End Sub

    Public Sub Park() Implements ITelescopeV3.Park
        Dim CoordsBefore As String
        Dim CoordsAfter As String
        Dim i As Integer
        pad += 1
        TL.LogMessage(Space(pad) + "Park", "Parking scope at home postion")
        If Not AtPark Then
            Dim parkRA As Double
            For i = 1 To 3                                                  ' Slew to home 3 times for accuracy
                TL.LogMessage(Space(pad) + "Park iteration: ", i.ToString)
                parkRA = Norm24(HMS2Hrs(LongFormat("GS")) - homePositionHA) ' Calculate home position RA
                SlewToCoordinatesAsync(parkRA, homePositionDEC)             ' Slew home
                If i = 1 Then
                    Using F As frmParking = New frmParking()
                        F.Timer1.Enabled = False
                        F.Timer1.Interval = 200
                        F.ParkRA = parkRA
                        F.ParkDEC = homePositionDEC
                        F.LastRA = LongFormat("GR")
                        F.LastDEC = LongFormat("GD")
                        F.Timer1.Enabled = True
                        TL.LogMessage(Space(pad) + "Park", "Opening Parking form")
                        Dim result As System.Windows.Forms.DialogResult = F.ShowDialog()
                        F.Timer1.Enabled = False
                        If result = DialogResult.Abort Then
                            AbortSlew()
                            TL.LogMessage(Space(pad) + "Park", "Parking aborted")
                            pad -= 1
                            Exit Sub
                        End If
                    End Using
                Else
                    While Slewing
                    End While
                End If
            Next i
            SerialCommand("Q", 0)                                           ' Kill all slewing
            SerialCommand("Qn", 0)
            SerialCommand("Qe", 0)
            SerialCommand("Qw", 0)
            SerialCommand("Qs", 0)
            SerialCommand("AL", 0)                                          ' Put into land mode to switch off LX200's drive

            Do Until Trim(SerialCommand("D", -1)) = ""                       ' Make absolutely sure the LX200 is parked!
                utilities.WaitForMilliseconds(200)
            Loop
            CoordsAfter = LongFormat("GA") + LongFormat("GZ")
            For i = 1 To 20
                CoordsBefore = CoordsAfter
                TL.LogMessage(Space(pad) + "Coords", "Before " + CoordsBefore)
                SerialCommand("AL", 0)
                utilities.WaitForMilliseconds(100)
                CoordsAfter = LongFormat("GA") + LongFormat("GZ")
                TL.LogMessage(Space(pad) + "Coords", "After  " + CoordsAfter)
                If CoordsAfter = CoordsBefore Then Exit For
            Next
        End If
        TL.LogMessage(Space(pad) + "Park", "Scope parked at home postion")
        pad -= 1
    End Sub

    Public Sub PulseGuide(Direction As GuideDirections, Duration As Integer) Implements ITelescopeV3.PulseGuide
        pad += 1
        Dim dir As String = LCase(Mid(Direction.ToString, 6, 1))        ' dir will be either "n", "e", "s" or "w"
        TL.LogMessage(Space(pad) + "PulseGuide", Direction.ToString + " for " + Duration.ToString + "ms")
        pad -= 1
        If dir = "" Then Return
        If Duration = 0 Then Return
        pad += 1
        lxIsPulseGuiding = True
        SerialCommand("RG", 0)                                          ' Make sure in Guide speed mode
        SerialCommand("M" + dir, 0)
        utilities.WaitForMilliseconds(Duration)                         ' Move for "duration" milliseconds
        SerialCommand("Q" + dir, 0)                                     ' Stop the motion
        utilities.WaitForMilliseconds(200)                              ' For LX200 Classics, the Q command is sometimes needed twice  
        SerialCommand("Q" + dir, 0)
        TL.LogMessage(Space(pad) + "PulseGuide", "Pulsing complete")
        lxIsPulseGuiding = False
        pad -= 1
    End Sub

    Public ReadOnly Property RightAscension() As Double Implements ITelescopeV3.RightAscension
        Get
            pad += 1
            Dim RA As Double
            If AtPark Then
                RA = Norm24(HMS2Hrs(LongFormat("GS")) - homePositionHA)
            Else
                RA = HMS2Hrs(LongFormat("GR"))
            End If
            TL.LogMessage(Space(pad) + "RightAscension", "Get: " & utilities.HoursToHMS(RA))
            pad -= 1
            Return RA
        End Get
    End Property

    Public Property RightAscensionRate() As Double Implements ITelescopeV3.RightAscensionRate
        Get
            pad += 1
            Dim rightAscensionRate__1 As Double = 0.0
            TL.LogMessage(Space(pad) + "RightAscensionRate", "Get: " & rightAscensionRate__1.ToString())
            pad -= 1
            Return rightAscensionRate__1
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "RightAscensionRate Set", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("RightAscensionRate", True)
        End Set
    End Property

    Public Sub SetPark() Implements ITelescopeV3.SetPark
        pad += 1
        homePositionDEC = DMS2Degs(LongFormat("GD"))                            ' Get current DEC
        homePositionHA = HMS2Hrs(HMS2Hrs(LongFormat("GS") - LongFormat("GR")))  ' Subtract RA from Sid Time to get Hour Angle
        homePositionDEC = Int(homePositionDEC + 0.5)                            ' Whole degrees
        homePositionHA = Int(homePositionHA * 10) / 10                          ' Decimal hours
        WriteProfile()
        TL.LogMessage(Space(pad) + "SetPark", "Home postion set to DEC: " + homePositionDEC.ToString + ", HA: " + homePositionHA.ToString)
        pad -= 1
    End Sub

    Public Property SideOfPier() As PierSide Implements ITelescopeV3.SideOfPier
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "SideOfPier Get", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("SideOfPier", False)
        End Get
        Set(value As PierSide)
            pad += 1
            TL.LogMessage(Space(pad) + "SideOfPier Set", "Not implemented")
            pad -= 1
            Throw New ASCOM.PropertyNotImplementedException("SideOfPier", True)
        End Set
    End Property

    Public ReadOnly Property SiderealTime() As Double Implements ITelescopeV3.SiderealTime
        Get
            pad += 1
            Dim jd As Double = utilities.DateUTCToJulian(DateTime.UtcNow)
            Dim T As Double = (jd - 2451545) / 36525
            Dim lst As Double = (280.46061837 + 360.98564736629 * (jd - 2451545) + T * T * 0.000387933 + T * T * T / 38710000) + SiteLongitude
            lst = (lst - Int(lst / 360) * 360 + (lst < 0) * 360) / 15   ' Normalise the local sidereal time

            TL.LogMessage(Space(pad) + "SiderealTime", "Get: " & Hrs2HMS(lst))
            pad -= 1
            Return lst
        End Get
    End Property

    Public Property SiteElevation() As Double Implements ITelescopeV3.SiteElevation
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "SiteElevation Get", elevation.ToString)
            pad -= 1
            Return elevation
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "SiteElevation Set", elevation.ToString)
            elevation = value
            WriteProfile()
            pad -= 1
        End Set
    End Property

    Public Property SiteLatitude() As Double Implements ITelescopeV3.SiteLatitude
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "SiteLatitude Get", "Latitude: " + lxLatitude.ToString)
            pad -= 1
            Return lxLatitude
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "SiteLatitude Set", "Set latitude to: " + lxLatitude.ToString)
            SerialCommand("St" + Degs2sDM(value), 1)
            pad -= 1
        End Set
    End Property

    Public Property SiteLongitude() As Double Implements ITelescopeV3.SiteLongitude
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "SiteLongitude Get", "Longitude: " + Degs2DM(lxLongitude))
            pad -= 1
            Return lxLongitude
        End Get
        Set(value As Double)
            pad += 1
            If value > 0 Then
                value = 360 - value
            Else
                value = -value
            End If
            TL.LogMessage(Space(pad) + "SiteLongitude Set", "Set longitude to: " + value.ToString)
            SerialCommand("Sg" + Degs2DM(value), 1)
            lxLongitude = -DM2Degs(Degs2DM(value))
            If lxLongitude < -180 Then lxLongitude += 360
            pad -= 1
        End Set
    End Property

    Public Property SlewSettleTime() As Short Implements ITelescopeV3.SlewSettleTime
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "SlewSettleTime Get", "Settle Time: " + lxSlewSettleTime.ToString)
            pad -= 1
            Return lxSlewSettleTime     'Settle time in seconds
        End Get
        Set(value As Short)
            pad += 1
            If value < 0 Or value > 20 Then
                Throw New ASCOM.InvalidValueException("Illegal SlewSettleTime")
                pad -= 1
                Exit Property
            End If
            lxSlewSettleTime = value
            TL.LogMessage(Space(pad) + "SlewSettleTime Set", "Set Settle Time to: " + lxSlewSettleTime.ToString)
            pad -= 1
        End Set
    End Property

    Public Sub SlewToAltAz(Azimuth As Double, Altitude As Double) Implements ITelescopeV3.SlewToAltAz
        pad += 1
        TL.LogMessage(Space(pad) + "SlewToAltAz", "Not implemented")
        pad -= 1
        Throw New ASCOM.MethodNotImplementedException("SlewToAltAz")
    End Sub

    Public Sub SlewToAltAzAsync(Azimuth As Double, Altitude As Double) Implements ITelescopeV3.SlewToAltAzAsync
        pad += 1
        TL.LogMessage(Space(pad) + "SlewToAltAzAsync", "Not implemented")
        pad -= 1
        Throw New ASCOM.MethodNotImplementedException("SlewToAltAzAsync")
    End Sub

    Public Sub SlewToCoordinates(RightAscension As Double, Declination As Double) Implements ITelescopeV3.SlewToCoordinates
        pad += 1
        TL.LogMessage(Space(pad) + "SlewToCoordinates", "Slewing to RA: " + Hrs2HMS(RightAscension) + ", DEC: " + Degs2sDMS(Declination))
        SlewToCoordinatesAsync(RightAscension, Declination)                                 ' Start the slew

        ' This routine cannot return until slewing is complete
        Do While Slewing
            'System.Threading.Thread.Sleep(1000)
            utilities.WaitForMilliseconds(1000)                                             ' Wait a second before interrogating the LX200
        Loop
        pad -= 1
    End Sub

    Public Sub SlewToCoordinatesAsync(RightAscension As Double, Declination As Double) Implements ITelescopeV3.SlewToCoordinatesAsync
        pad += 1
        TL.LogMessage(Space(pad) + "SlewToCoordinatesAsync", "ASync Slew to RA: " + Hrs2HMS(RightAscension) + ", DEC: " + Degs2sDMS(Declination))
        If AtPark Then
            TL.LogMessage(Space(pad) + "SlewToCoordinatesAsync", "Telescope is parked - aborted")
            pad -= 1
            Throw New ASCOM.InvalidOperationException("Telescope is parked - aborted")
            Exit Sub
        End If
        If Declination > maxSlewDEC Then
            TL.LogMessage(Space(pad) + "SlewToCoordinatesAsync", "Illegal Declination - aborted")
            pad -= 1
            Throw New ASCOM.InvalidOperationException("Illegal Declination - aborted")
            Exit Sub
        End If

        SerialCommand("Sr" + Hrs2HMS(RightAscension), 1)                            ' Set target RA
        lxTargetRA = RightAscension
        SerialCommand("Sd" + Degs2sDMS(Declination), 1)                             ' Set target DEC
        lxTargetDEC = Declination
        SerialCommand("Sw" + maxSlewRate.ToString, 1)                               ' Set the slew rate
        Dim resp As String = SerialCommand("MS", 1)                                 ' Start the LX200 slewing

        lxSlewing = True
        If resp <> "0" Then                                                         ' Can we slew?
            lxSlewing = False                                                       ' No we can't
            TL.LogMessage(Space(pad) + "SlewToCoordinatesAsync", "Target below horizon - aborted")
            SerialCommand("", -1)
            pad -= 1
            Throw New ASCOM.InvalidOperationException("Target below horizon - aborted")  ' Object below horizon
            Exit Sub
        End If
        lxSlewingCoords = LongFormat("GR") + LongFormat("GD")                       ' Remember starting coords for later
        pad -= 1
    End Sub

    Public Sub SlewToTarget() Implements ITelescopeV3.SlewToTarget
        pad += 1
        TL.LogMessage(Space(pad) + "SlewToTarget", "Slew to RA: " + Hrs2HMS(lxTargetRA) + ", DEC: " + Degs2sDMS(lxTargetDEC))
        SlewToCoordinates(lxTargetRA, lxTargetDEC)
        pad -= 1
    End Sub

    Public Sub SlewToTargetAsync() Implements ITelescopeV3.SlewToTargetAsync
        pad += 1
        TL.LogMessage(Space(pad) + "SlewToTargetAsync", "ASync Slew to Target RA: " + Hrs2HMS(lxTargetRA) + ", DEC: " + Degs2sDMS(lxTargetDEC))
        SlewToCoordinatesAsync(lxTargetRA, lxTargetDEC)
        pad -= 1
    End Sub

    Public ReadOnly Property Slewing() As Boolean Implements ITelescopeV3.Slewing
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "Slewing Get", "Slewing state on entry: " + IIf(lxSlewing, "Slewing", "Not slewing"))
            Dim Coords As String = LongFormat("GR") + LongFormat("GD")
            If Coords = lxSlewingCoords Then
                If lxSlewing AndAlso Coords <> LongFormat("Gr") + LongFormat("Gd") Then utilities.WaitForMilliseconds(lxSlewSettleTime * 1000)
                If Trim(SerialCommand("D", -1)) = "" Then lxSlewing = False
            End If
            lxSlewingCoords = Coords
            TL.LogMessage(Space(pad) + "Slewing Get", "Slewing state on exit: " + IIf(lxSlewing, "Slewing", "Not slewing"))
            pad -= 1
            Return lxSlewing
        End Get
    End Property

    'pad += 1
    'TL.LogMessage(Space(pad) + "Slewing Get", "Slewing state on entry: " + IIf(lxSlewing, "Slewing", "Not slewing"))
    'If Trim(SerialCommand("D", -1)) = "" Then                                       ' If Distance Bars are empty then LX200 not slewing
    'If lxSlewing Then System.Threading.Thread.Sleep(lxSlewSettleTime * 1000)    ' Allow settle time if just finished slewing
    'lxSlewing = False
    'End If
    'TL.LogMessage(Space(pad) + "Slewing Get", "Slewing state on exit: " + IIf(lxSlewing, "Slewing", "Not slewing"))
    'pad -= 1
    'Return lxSlewing
    'End Get
    'End Property

    Public Sub SyncToAltAz(Azimuth As Double, Altitude As Double) Implements ITelescopeV3.SyncToAltAz
        pad += 1
        TL.LogMessage(Space(pad) + "SyncToAltAz", "Not implemented")
        pad -= 1
        Throw New ASCOM.MethodNotImplementedException("SyncToAltAz")
    End Sub

    Public Sub SyncToCoordinates(RightAscension As Double, Declination As Double) Implements ITelescopeV3.SyncToCoordinates
        pad += 1
        TL.LogMessage(Space(pad) + "SyncToCoordinates", "Synching to RA: " + Hrs2HMS(RightAscension) + ", DEC: " + Degs2sDMS(Declination))
        lxTargetRA = RightAscension
        lxTargetDEC = Declination
        SyncToTarget()
        pad -= 1
    End Sub

    Public Sub SyncToTarget() Implements ITelescopeV3.SyncToTarget
        pad += 1
        TL.LogMessage(Space(pad) + "SyncToTarget", "Synching to Target RA: " + Hrs2HMS(lxTargetRA) + ", DEC: " + Degs2sDMS(lxTargetDEC))
        SerialCommand("Sr" + Hrs2HMS(lxTargetRA), 1)            ' Set RA to sync to
        SerialCommand("Sd" + Degs2sDMS(lxTargetDEC), 1)         ' Set DEC to sync to
        SerialCommand("CM", -1)                                 ' Sync LX200's current RA & DEC coords to above values
        pad -= 1
    End Sub

    Public Property TargetDeclination() As Double Implements ITelescopeV3.TargetDeclination
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "TargetDeclination Get", "Get Target DEC: " + lxTargetDEC.ToString)
            pad -= 1
            Return lxTargetDEC
        End Get
        Set(value As Double)
            TL.LogMessage(Space(pad) + "TargetDeclination Set", "Set Target DEC: " + lxTargetDEC.ToString)
            lxTargetDEC = value
        End Set
    End Property

    Public Property TargetRightAscension() As Double Implements ITelescopeV3.TargetRightAscension
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "TargetRightAscension Get", "Get Target RA: " + lxTargetRA.ToString)
            pad -= 1
            Return lxTargetRA
        End Get
        Set(value As Double)
            pad += 1
            TL.LogMessage(Space(pad) + "TargetRightAscension Set", "Set Target RA: " + lxTargetRA.ToString)
            lxTargetRA = value
            pad -= 1
        End Set
    End Property

    Public Property Tracking() As Boolean Implements ITelescopeV3.Tracking
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "Tracking", "Get: " & lxTracking.ToString())
            pad -= 1
            Return lxTracking
        End Get
        Set(value As Boolean)
            pad += 1
            TL.LogMessage(Space(pad) + "Tracking Set", "Set Tracking: " + value.ToString)
            If value Then
                SerialCommand(":Qe#", 0)        'Cancel slewing East at guide rate
                SerialCommand("Q", 0)
                lxTracking = True
            Else
                SerialCommand(":RG#:Me#", 0)    'Constantly slewing East at guide rate stops the sidereal drive
                lxTracking = False
            End If
            pad -= 1
        End Set
    End Property

    Public Property TrackingRate() As DriveRates Implements ITelescopeV3.TrackingRate
        Get
            pad += 1
            TL.LogMessage(Space(pad) + "TrackingRate Get", "Get Tracking Rate: ", Choose(lxTrackingRate, "Sidereal", "Solar", "Lunar", "King"))
            pad -= 1
            Return lxTrackingRate
        End Get
        Set(value As DriveRates)
            pad += 1
            TL.LogMessage(Space(pad) + "TrackingRate Set", "Set Tracking Rate to:  " + Choose(lxTrackingRate, "Sidereal", "Solar", "Lunar", "King"))
            lxTrackingRate = value
            SerialCommand(Choose(lxTrackingRate, "TQ", ":TM#:ST60.0#", ":TM#:ST57.9#", ":TM#:ST60.2#"), 1)
            pad -= 1
        End Set
    End Property

    Public ReadOnly Property TrackingRates() As ITrackingRates Implements ITelescopeV3.TrackingRates
        'Sidereal = 60.1 Hz, Solar = 60.0 Hz, Lunar = 57.9 Hz, King = 60.1 Hz (actually 60.1475hz)
        Get
            pad += 1
            Dim trackingRates__1 As ITrackingRates = New TrackingRates()
            TL.LogMessage(Space(pad) + "TrackingRates", "Get: ")
            For Each driveRate As DriveRates In trackingRates__1
                TL.LogMessage(Space(pad) + "TrackingRates", "Get: " & driveRate.ToString())
            Next
            pad -= 1
            Return trackingRates__1
        End Get
    End Property

    Public Property UTCDate() As DateTime Implements ITelescopeV3.UTCDate
        Get
            pad += 1
            Dim utcDate__1 As DateTime = DateTime.UtcNow
            TL.LogMessage(Space(pad) + "UTCDate", String.Format("Get: {0}", utcDate__1))
            pad -= 1
            Return utcDate__1
        End Get
        Set(value As DateTime)
            Throw New ASCOM.PropertyNotImplementedException("UTCDate", True)
        End Set
    End Property

    Public Sub Unpark() Implements ITelescopeV3.Unpark
        pad += 1
        TL.LogMessage(Space(pad) + "Unpark", "Unparking telescope")
        SerialCommand("AP", 0)                                              ' Put into Polar alignment mode to start tracking
        utilities.WaitForMilliseconds(1000)
        SerialCommand("TQ", 0)                                              ' Set tracking rate to 60.1 hz
        SyncToCoordinates(Norm24(SiderealTime - homePositionHA), homePositionDEC)
        LX200Startup()
        pad -= 1
    End Sub

#End Region

#Region "Private properties and methods"
    ' here are some useful properties and methods that can be used as required
    ' to help with

#Region "ASCOM Registration"

    Private Shared Sub RegUnregASCOM(ByVal bRegister As Boolean)

        Using P As New Profile() With {.DeviceType = "Telescope"}
            If bRegister Then
                P.Register(driverID, driverDescription)
            Else
                P.Unregister(driverID)
            End If
        End Using

    End Sub

    <ComRegisterFunction()>
    Public Shared Sub RegisterASCOM(ByVal T As Type)

        RegUnregASCOM(True)

    End Sub

    <ComUnregisterFunction()>
    Public Shared Sub UnregisterASCOM(ByVal T As Type)

        RegUnregASCOM(False)

    End Sub

#End Region

    ''' <summary>
    ''' Returns true if there is a valid connection to the driver hardware
    ''' </summary>
    Private ReadOnly Property IsConnected As Boolean
        Get
            ' TODO check that the driver hardware connection exists and is connected to the hardware
            Return connectedState
        End Get
    End Property

    ''' <summary>
    ''' Use this function to throw an exception if we aren't connected to the hardware
    ''' </summary>
    ''' <param name="message"></param>
    Private Sub CheckConnected(ByVal message As String)
        If Not IsConnected Then
            Throw New NotConnectedException(message)
        End If
    End Sub

    ''' <summary>
    ''' Read the device configuration from the ASCOM Profile store
    ''' </summary>
    Friend Sub ReadProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Telescope"
            traceState = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, String.Empty, traceStateDefault))
            comPort = driverProfile.GetValue(driverID, comPortProfileName, String.Empty, comPortDefault)
            updateClock = Convert.ToBoolean(driverProfile.GetValue(driverID, updateClockName, String.Empty, updateClockDefault))
            homePositionHA = Convert.ToDecimal(driverProfile.GetValue(driverID, homePositionHAName, String.Empty, homePositionHADefault))
            homePositionDEC = Convert.ToDecimal(driverProfile.GetValue(driverID, homePositionDECName, String.Empty, homePositionDECDefault))
            model = driverProfile.GetValue(driverID, modelName, String.Empty, modelDefault)
            focalReducer = Convert.ToDecimal(driverProfile.GetValue(driverID, focalReducerName, String.Empty, focalReducerDefault))
            maxSlewRate = Convert.ToDecimal(driverProfile.GetValue(driverID, maxSlewRateName, String.Empty, maxSlewRateDefault))
            elevation = Convert.ToDecimal(driverProfile.GetValue(driverID, elevationName, String.Empty, elevationDefault))
            maxSlewDEC = Convert.ToDecimal(driverProfile.GetValue(driverID, maxSlewDECName, String.Empty, maxSlewDECDefault))
        End Using
    End Sub

    ''' <summary>
    ''' Write the device configuration to the  ASCOM  Profile store
    ''' </summary>
    Friend Sub WriteProfile()
        Using driverProfile As New Profile()
            driverProfile.DeviceType = "Telescope"
            driverProfile.WriteValue(driverID, traceStateProfileName, traceState.ToString())
            driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString())
            driverProfile.WriteValue(driverID, updateClockName, updateClock.ToString())
            driverProfile.WriteValue(driverID, homePositionHAName, homePositionHA.ToString())
            driverProfile.WriteValue(driverID, homePositionDECName, homePositionDEC.ToString())
            driverProfile.WriteValue(driverID, modelName, model.ToString())
            driverProfile.WriteValue(driverID, focalReducerName, focalReducer.ToString())
            driverProfile.WriteValue(driverID, maxSlewRateName, maxSlewRate.ToString())
            driverProfile.WriteValue(driverID, elevationName, elevation.ToString())
            driverProfile.WriteValue(driverID, maxSlewDECName, maxSlewDEC.ToString())
        End Using
    End Sub

#End Region

#Region "My Stuff"
    Private Function SerialCommand(cmdStr As String, n As Integer) As String
        pad += 1
        If Not cmdStr.StartsWith(":") Then cmdStr = ":" + cmdStr
        If Not cmdStr.EndsWith("#") Then cmdStr += "#"
        TL.LogMessage(Space(pad) + "SerialCommand", "Sending: " + cmdStr + " (" + n.ToString + ")")

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
            If n <> 0 Then TL.LogMessage(Space(pad) + "SerialCommand", "Got: " + retStr)
        Catch ex As Exception
            Throw New ASCOM.NotConnectedException(Telescope.comPort + " not responding when trying to send " + cmdStr)
            retStr = "Error"
        End Try

        Try
            objSerial.Close()
            objSerial.Dispose()
        Catch ex As Exception
        End Try

        pad -= 1
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

    Private Function DMS2Degs(DMS As String) As Double
        Return (Val(Left(DMS, 3)) + IIf(DMS.StartsWith("-"), -1, 1) * (Val(Mid(DMS, 5, 2)) / 60 + Val(Right(DMS, 2)) / 3600))
    End Function

    Private Function DM2Degs(DM As String) As Double
        Return Val(DM.Substring(0, 3)) + IIf(DM.StartsWith("-"), -1, 1) * Val(DM.Substring(4, 2)) / 60
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
        'MsgBox("DEC: " + sign + Right("0" + deg.ToString, 2) + ChrW(223) + Right("0" + min.ToString, 2) + ":" + Right("0" + sec.ToString, 2) + " " + Degs.ToString)
        Return sign + Right("0" + deg.ToString, 2) + ChrW(223) + Right("0" + min.ToString, 2) + ":" + Right("0" + sec.ToString, 2)
    End Function
    Private Function Degs2sDM(Degs As Double) As String
        Dim deg As Double, min As Double, sign As String
        sign = "+"
        If Degs < 0 Then
            sign = "-"
            Degs = -Degs
        End If
        deg = Int(Degs)
        min = Int((Degs - deg) * 60)
        Return sign + Right("0" + deg.ToString, 2) + ChrW(223) + Right("0" + min.ToString, 2)
    End Function

    Private Function Degs2DMS(angle As Double) As String
        Dim deg As Double, min As Double, sec As Double
        deg = Int(angle)
        min = Int((angle - deg) * 60)
        sec = Int((angle * 3600) - deg * 3600 - min * 60)
        Return Right("00" + deg.ToString, 3) + ChrW(223) + Right("0" + min.ToString, 2) + "'" + Right("0" + sec.ToString, 2)
    End Function

    Private Function Degs2DM(angle As Double) As String
        Dim deg As Double, min As Double
        deg = Int(angle)
        min = Int((angle - deg) * 60)
        Return Right("00" + deg.ToString, 3) + ChrW(223) + Right("0" + min.ToString, 2)
    End Function

    Private Function HMS2Hrs(HMS As String) As Double
        Return Val(HMS.Substring(0, 2)) + Val(HMS.Substring(3, 2)) / 60 + Val(HMS.Substring(6, 2)) / 3600
    End Function

    Private Function Hrs2HMS(hours As Double) As String
        Dim hr As Integer, min As Integer, sec As Integer
        hr = Int(hours)
        min = Int((hours - hr) * 60)
        sec = Int((hours * 3600) - hr * 3600 - min * 60)
        Return Right("0" + hr.ToString, 2) + ":" + Right("0" + min.ToString, 2) + ":" + Right("0" + sec.ToString, 2)
    End Function

    Private Function Norm24(value As Double) As Double
        Return value - Int(value / 24) * 24
    End Function
    Private Function DateTime2String(a As Integer, b As Integer, c As Integer, sep As String) As String
        Return Right("0" + a.ToString, 2) + sep + Right("0" + b.ToString, 2) + sep + Right("0" + c.ToString, 2)
    End Function

    Private Sub LX200Startup()                                              ' Executed upon connection or unparking
        pad += 1
        TL.LogMessage(Space(pad) + "LX200Startup", "Start-up begin")
        SerialCommand("Q", 0)                                               ' Stop any slewing
        SerialCommand("Qn", 0)                                              ' Stop any other movement
        SerialCommand("Qs", 0)
        SerialCommand("Qe", 0)
        SerialCommand("Qw", 0)
        lxSlewing = False                                                   ' Telescope should no longer be slewing

        If updateClock Then
            Dim dateTime As Date = Now                                      ' Get PC's date and time 
            Dim yr As Integer = dateTime.Year
            Dim mth As Integer = dateTime.Month
            Dim day As Integer = dateTime.Day
            Dim hr As Integer = dateTime.Hour
            Dim min As Integer = dateTime.Minute
            Dim sec As Integer = dateTime.Second
            Dim lxDate As String = SerialCommand("GC", -1)                  ' Get LX200's date
            SerialCommand("SL" + DateTime2String(hr, min, sec, ":"), 1)     ' Update LX200's local time with PC's (LX200's clock sucks)
            If (lxDate <> DateTime2String(mth, day, yr, "/")) Then          ' Update calendar date if necessary
                SerialCommand("SC" + DateTime2String(mth, day, yr, "/"), -2)
            End If
        End If

        lxLatitude = DM2Degs(SerialCommand("Gt", -1))                       ' Get LX200's latitude
            lxLongitude = -DM2Degs(SerialCommand("Gg", -1))                     ' Get LX200's longitude
        If lxLongitude < -180 Then lxLongitude += 360                       ' Adj LX200's longitude to actual longitude
        SerialCommand("SS" + Hrs2HMS(SiderealTime), 1)                      ' Update LX200's sidereal time

        Dim CurrRA As String = LongFormat("GR")
        Dim CurrDEC As String = LongFormat("GD")
        SerialCommand("Sr" + CurrRA, 1)                                     ' Make Target RA same as current RA - this shows LX200 is not slewing
        SerialCommand("Sd" + CurrDEC, 1)                                    ' Make Target DEC same as current DEC
        lxSlewingCoords = CurrRA + CurrDEC
        lxTargetRA = HMS2Hrs(CurrRA)                                        ' Grab current RA
        lxTargetDEC = DMS2Degs(CurrDEC)                                     ' Grab current DEC

        SerialCommand("Sw" + maxSlewRate.ToString, 1)                       ' Set maximum slew rate to preset degs per second
        Tracking = True
        TL.LogMessage(Space(pad) + "LX200Startup", "Start-up done")
        pad -= 1
    End Sub
#End Region

End Class
