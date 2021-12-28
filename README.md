Meade LX200 Classic ASCOM Driver
================================


27 December 2021
----------------

At the time of writing, I cannot find an ASCOM driver for the Meade LX200 Classic SCT telesope which provides me with my needs,
so I set about writing this one. This ASCOM driver should work for all models of the LX200 Classic telescopes, namely the
7" Maksutov-Cassegrain, the 8", 10", 12" and 16" F10, and the 8" and 10" F6.3 Schmidt-Cassegrain telescopes.

Connection to the telescope via this ASCOM driver by the client application is much quicker.  The telescope's date and time can
optonally be updated on connection or when unparking using the PC's clock.

This ASCOM driver has been written in Visual Basic .NET and has the following features which others do not have or perform as well:

Notable Features
----------------

•	Check connection with the telescope on the driver’s setup window

•	Telescope model selection – the driver knows the telescope’s focal length, aperture area and aperture diameter.

•	Focal reducer setting

•	Optional automatic telescope clock update, including local sidereal time

•	Optional mini hand controller with Meade focuser control

•	Maximum Declination for slew – helps to prevent cameras from hitting the telescope’s mount!

•	Maximum slew rate to save the LX200’s motors

•	Set observing site’s elevation

•	Parking the telescope with progress window

•	Dual pulse guiding that can allow corrections to both telescope axes simultaneously

•	Access to the LX200’s native library of objects, including the sun, for slewing to.

•	Optional voice announcements when using the ASCOM driver

•	32 and 64-bit versions are available

•	Multiple applications can access the LX200 simultaneously


The LX200 (except the 16") does not have a facility for parking.  This driver allows the LX200 to park at a given hour angle,
given in hours, from the meridian (south is 0 hours).  The home declination is also given here.  When the client application asks 
the driver to park the LX200, the LX200 will be parked at this home position.  While parking, a pop-up window shows the progress of
the parking with an "Abort" button to halt the process.  For the 16" LX200, its own parking feature is not used.

When parked, the LX200 is put into LAND mode which stops the LX200's mount from being driven and respond to any go-to slew
commands.  When unparked, the home position can be calculated by getting local sidereal time and adding the hour angle to it to
get the LX200's Right Ascension.  The telescope's Declination is simply the same as when it was parked.  All of this assumes that
the clutches on each axis haven't been released.

Once parked, it is best to leave the LX200 powered on if possible.  If turned off, the LX200 RA motor drive turns during the
LX200's initailisation procedure - it does it to find the magnet on its worm gear so that it knows the worm's position.  The
amount of turning is random meaning the assumed home position when unparking will likely be wrong.
