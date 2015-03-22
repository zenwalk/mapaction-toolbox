# Readme for maDataNameChecker tool v0.9 beta #
Below is a brief summary of what can and can't be achieved with the v0.9 beta of the Data Name Check tool. This applies only to the commandline (CLI) version of the tool.

This version of the CLI does directly read the names of shapefiles and features classes etc, from any of list provided (eg a GDB, an MXD, a directory etc). The path to the list must be given using the "-l" option.

The the user wishes to the, they may specify the location of the dataname clause lookup tables explicitly using the "-t" options. If the "-t" option is not specified then the tool will attempt to automatically locate suitable copies of the tables relative to the list. See [here](SearchForDefaultDataNameClauseLookupTables.md) for more details.


# Installation #
The tool is dependent on having ArcGIS 9.3.1 installed and licensed. Also far it can only been tested using ArcEditor with a standalone license. Other editions of ArcGIS (ArcView and ArcInfo) should work, though it is not known whether all functionality will be available in all the different editions.

Download the msi from here:
http://code.google.com/p/mapaction-toolbox/source/browse/#hg/v1.0/dataNameTools/setup/Release

By default the tool will be install in:
```
C:\Program Files\MapAction\dataNameTools
```

The setup program does not alter the PATH environmental variable. Hence to run the program you will need to open the Command Prompt and change directory the installation directory:
```
C:
cd \Program Files\MapAction\dataNameTools
```

# Usage #
```
Usage: maDataNameChecker

maDataNameChecker {-l <path to data list> [-r|-n] [-t <path to non-default clause lookup tables>] |
-v | -h | -? }

Options:
 -v       Print the name and version number and quit
 -h or -? Print this usage message and quit
 -l <path to data list> Specify the path of the list of datanames to be checked. This may be an MXD
file (*.mxd), a personal GDB (*.mdb), a filebased GDB (*.gdb), a directory of shapefiles (<dir>), or
 an SDE connection file (*.sde)
 -r       (default) Recuse the list if appropriate (eg for a directory)
 -n       Do not recuse the list if appropriate (eg for a directory)
 -t       Optional: Override the default clause table locations by speficing a location of an MDB or
 GDB containing the clause tables. If this option is not specified then the program will attempt to
automatically detrive their location. If they cannot be automatically located then the program will
quit with an error.
```



# Feedback #
Please note any bugs / issues by clicking on the New Issue link on this page:
http://code.google.com/p/mapaction-toolbox/issues/list