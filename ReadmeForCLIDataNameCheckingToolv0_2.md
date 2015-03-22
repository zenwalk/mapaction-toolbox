# Readme for ma-datanaming tool v0.2 #
Below is a brief summary of what can and can't be achieved with the v0.2 of the Data Name Check tool. This applies only to the commandline (CLI) version of the tool.

This version of the CLI does not read the names directly from shapefiles or feature classes. Data names must be past to it as string on the commandline. A quick way to get a list of all the shapefile name within a directory and into a text file would be:
```
dir /B /S *.shp > myfile.txt
```

For more details see:
```
dir /?
```

# Installation #
Download the msi from here:
http://mapaction-toolbox.googlecode.com/hg/experimental/datanamingAPI/CLI_setup/Debug/CLI_setup_v0.2.msi?r=c75035d58932efc3fac9396343259e9ffd2c82f7

By default the tool will be install in:
```
C:\Program Files\MapAction\DatanamingCLI
```

The setup program does not alter the PATH environmental variable. Hence to run the program you will need to open the Command Prompt and change directory the installation directory:
```
C:
cd \Program Files\MapAction\DatanamingCLI
```

# Usage #
```
ma-datanaming [-t <path_to_lookup_mdb>] [ <data_names>... ]
```

  * If the -l path\_to\_lookup\_mdb is not specified then a default copy in the installation directory is used.
  * If no datanames are used then a hardcoded default list of names is used

# Feedback #
Please note any bugs / issues by clicking on the New Issue link on this page:
http://code.google.com/p/mapaction-toolbox/issues/list