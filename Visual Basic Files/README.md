Meade LX200 Classic ASCOM Driver
================================

Things still to do:

1)  Ability to pulse guide on both axes simultaneously
2)  Incorporate control of the LX200 Classic's focuser motor
3)  Self installation file for the driver

25 April 2021
-------------

At the time of writing, I cannot find an ASCOM driver for the Meade LX200 Classic SCT telesope which provides me with my needs,
so I set about writing this one. This ASCOM driver should work for all models of the LX200 Classic telescopes, namely the
7" Maksutov-Cassegrain, the 8", 10", 12" and 16" F10, and the 8" and 10" F6.3 Schmidt-Cassegrain telescopes.

Connection to the telescope via this ASCOM driver by the client application is much quicker.  The telescope's date and time is 
updated on connection or when unparking.

This ASCOM driver has been written in Visual Basic .NET and has the following features which others do not have or perform as well:

Setup Dialog
------------

1)  Lists all COM ports in order to make it easy to select the correct one connected to the LX200.
2)  A "Check Connection" button so that the user can see straight away if the LX200 responds on the selected COM port.
3)  The user can select one of the seven LX200 Classic models.  The driver can now supply the client application with the
    correct aperture, diameter and focal length without any additional input from the user.
4)  If a focal reducer is being used then the F-number of reducer can be entered as a percentage, e.g. F6.3 will be entered as 63%.
5)  The maximum slew rate can be set (default is 3 degrees per second) instead of 8 degs per sec.  This saves the LX200's motors!
6)  The telescope's site elevation in metres above sea level can be defined here for the client application to use.
7)  The maximum declination in degrees that the telescope can slew to can be set.  This helps to avoid camera equipment from
    colliding with LX200's mount.
8)  The home position for parking the telescope can set by the user supplying the hour angle and declination of the home positions.
9)  The LX200's own on-board library can be accessed by clicking on the "Library" button.

The LX200 (except the 16") does not have a facility for parking.  This driver allows the LX200 to park at a given hour angle,
given in hours, from the meridian (south is 0 hours).  The home declination is also given here.  When thec lient application asks 
the driver to park the LX200, the LX200 will be parked at this home position.  While parking, a pop-up window shows the progress of
the parking with an "Abort" button to halt the process.  For the 16" LX200, its own parking feature is not used.

When parked, the LX200 is put into LAND mode which stops the LX200's mount from being driven and respond to any go-to slew
commands.  When unparked, the home position can be calculated by getting local sidereal time and adding the hour angle to it to
get the LX200's Right Ascension.  The telescope's Declination is simply the same as when it was parked.  All of this assumes that
the clutches on each axis haven't been released.

Once parked, it is best to leave the LX200 powered on if possible.  If turned off, the LX200 RA motor drive turns during the
LX200's initailisation procedure - it does it to find the magnet on it's worm gear so that it knows the worm's position.  The
amount of turning is random meaning the assumed home position when unparking will likely be wrong.

Library Dialog
--------------

If the correct COM port has been selected and the telescope is not parked, then the objects from the LX200 library can be selected
and slewed to.  Selecting the radio button beside the chosen object and clicking on the "Go to" button will make the LX200 slew to
that object.

The objects available include:

1)  The LX200's named stars
2)  Solar Sytem objects, including the Sun*, Moon, the Planets and Pluto
3)  110 Messier objects
4)  7840 CNGC objects
5)  5386 IC objects
7)  12921 UGC objects
8)  LX200's 315 alignment stars

*The Sun is not in the LX200's library - it is calculated by the driver and added to the list.

There are other catalogues in the LX200's firmware but some versions of the firmware do not allow serial port access to them.
When an object is selected, the object details held in the LX200's firmware are displayed, where applicable, such as:

-   Object name
-   Constellation
-   Right Ascension
-   Declination
-   Magnitude
-   Object type
-   Size (or moon phase)
-   Quality of the object