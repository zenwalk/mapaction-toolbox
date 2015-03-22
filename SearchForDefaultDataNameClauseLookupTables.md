# Introduction #

Below are the key components of the bronze custom software tools
How does the automatic search for DataName Clause Lookup tables work?

# Details #

Where is your list of table names?


## List of layers from a GeoDatabase ##
  1. Do the DataName Clause Tables exist within the GDB?
  * Yes: These will be used
  * No: go to next

  1. Does the path to the GDB or it's connection file include the root of the MapAction  Directory structure? (eg `2_Active_Data`)
  * Yes: Apply rules for the root directory
  * No: No the fallback DataNaming Clause Lookup Tables are found

## List of layers from an MXD ##
  1. Does the path for the MXD include the root to the MapAction MXD directory? (eg `33_MXD_Maps`)
  * Yes: Does the relative path `..\..\2_Active_Data` exist?
  * Yes: Apply rules for the root directory

  * No: Search the layers in the MXD and search the directories they refer to in order of frequency

## List of layers from a Directory ##
  1. Does the path to the GDB or it's connection file include the root of the MapAction Active Data Directory? (eg `2_Active_Data`)
  * Yes: Goto the root directory and search there
  * No: Use the current directory and search there

  1. Having established the directory to search, is there exactly one MDB or other GDB which contains the relevant DataNameing Clause Tables?
  * Yes: use that one
  * No: No default DataNaming Clause Lookup Tables are found