Backup Program
==============

Purpose
-------
Provide a quick and repeatable way to perform common lightweight backups

Functionality
-------------

### Main ###
* Save a backup configuration that can be executed later
* Save multiple configurations and allow easy switching between them
* Have a common/default backup spot or specify a custom folder
* Backups somehow marked with a date but with preserved filenames
* Optionally tag backups
* See when the last backup was performed
* Show a count of how many backups exist

### Extra ###
* Export configuration to file/Import configuration from file

Backup configuration
--------------------
### Global ###
* Default root : Specify a common location that all backups can use. Dynamic, changing it will cause all future backups appear in the new location
* Default tag : How to name the individual backup folders (e.g. %yyyy-%MM-%dd) by default

### Per backup configuration ###
* Name : Specify a name which can be used for the backup containing folder. Must be valid characters for a folder in windows.
* Description : Notes on the backup configuration
* Source : A file or folder which will be copied to the backup location. Must be valid characters for a folder in windows.
* Destination : Location to copy the source. Can specify to use the default root or a custom one. Must be valid characters for a folder in windows.

Backup structure
----------------
#### Global settings ####
* Default root : `C:\Backups`
* Default tag : `%yyyy-%MM-%dd_%hh%mm`

#### Example 1 ####
* Name : `Payday 2`
* Description : `Backups the Payday 2 save folder in userdata`
* Source : `C:\Program Files\Steam\userdata\19389756\218620\remote`
* Destination: `<default>(C:\Backups\Payday 2)`

		C:\Backups\Payday 2
				|-->\2014-08-21_1548\remote
										|-->\save000.sav
										|-->\save098.sav
				|-->\2014-12-08_0934\remote
										|-->\save000.sav
										|-->\save098.sav
										
#### Example 2
* Name : `Dark Souls II`
* Description : `Backups the Dark Souls II save file`
* Source : `C:\Users\Alex\AppData\Roaming\DarkSoulsII\011000010127826a\DARKSII0000.sl2`
* Destination : `C:\Users\Alex\Desktop`

		C:\Users\Alex\Desktop
				|-->\2014-03-18_2340\DARKSII0000.sl2
				|-->\2014-10-30_0014\DARKSII0000.sl2


Performing a backup
-------------------
Once a configuration is selected, an editable field called 'Tag' should be visible near the 'Perform backup' button.
This field allows you to add extra characters to the end of the date stamped backup folder. The tag field must only support valid Windows folder characters. e.g.

Tag: `<none>`

		C:\Backups\Batman
			|-->\2014-03-18_2340\bm-aa01.sav

Tag: `Before the Joker`

		C:\Backups\Batman
			|-->\2014-04-01_1958_Before the Joker\bm-aa01.sav

Handling existing files
-----------------------
* If a folder/file cannot be created, display an error message and do nothing
* If a folder under the destination has the same tag (i.e. same date), show an warning and do nothing

Viewing a configuration
-----------------------
Should be able to see all the specified details in the configuration plus

* Time when the last backup was performed (learned from reading latest file in the backup location)
* Count of how many backups exist (learned from counting files in the backup location)
* Button to open explorer in the source and backup folder 


GUI Construction
----------------

* Scrollable list view on the left border of all configurations, clicking one opens it's details in the main view. Delete config buttons should appear here
* Main configuration view in the center and right, 
	- Use default/custom destination has a checkbox. Disable text input when default (still display the resultant source though)
	- Specifying Source and custom Destination should either be text input or File/folder selection popup
	- Default to view config as read only but click a button to edit and each field becomes editable. Either save or discard to go back to read only view. Last saved date and save count are always read only 
	- Peform backups button here only enabled if main view is in read only

* Menu bar in top border. Minimal functions here apart from Export/Import, backup all, New config
* Exceptions when saving appear as a error popup.

Technical
---------
* Save config as JSON?
* Language: Probably Java. Maybe C# depending on JSON support. Python if making .exe and drawing GUIs seems approachable


