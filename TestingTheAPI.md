# Introduction #

Below are a number of tests for the Data Naming API, in order to check it's functionality.
In particular:
  * Can it read from all of the different sorts of lists of datanames it should?
  * Can it read from all the different source of Name Clause Lookup tables it should?
  * Does it then correctly identify those names with appropriate syntax errors, invalid, warnings and info messages?

These tests could be wrapped up in a number of simple batch scripts using the commandline tool.

## Different Data List sources ##

  * MXD (standalone)
  * Mx (from within ArcMap) - Can't be tested from the commandline tool
  * GDB (file)
  * GDB (personal/access)
  * GDB (SDE)
  * Directory
  * Recurse or not?

## Different DataName Clause Lookup Table options ##

  * Different DNT sources:
    * Access DB
    * GDB (file)
    * GDB (personal/access)
    * GDB (SDE)
  * Malformed datanaming tables
  * Do DNT include either an "ObjectID" column and/or an GUID column?

# Different combinations of DataLists and DataNameClauses tables #

The table below lists some of the combinations of DataLists and DataNameClauses, with some suggestions for the priority for testing this combination.

  * YES = This combination should be tested
  * NO = No need to test this combination
  * BLANK = Undecided priority

  * DataLists vertically
  * DataNameClauses horizontally

| |Access DB|GDB (file)|GDB (personal/access)|GDB (SDE)|Malformed DNT|Do DNT include either an "ObjectID" column and/or an GUID column?|
|:|:--------|:---------|:--------------------|:--------|:------------|:----------------------------------------------------------------|
| MXD (standalone)        |Y |Y |Y             |Y        |             |  |
| Mx (from within ArcMap) |Y |Y |Y             |Y        |             |  |
| GDB (file)              |  |Y |N             |N        |             |  |
| GDB (personal/access)   |  |N |Y             |N        |             |Y  |
| GDB (SDE)               |  |N |N             |Y        |Y            |Y  |
| Directory               |Y |  |              |         |Y            |Y  |
| Recurse or not?         |  |  |              |         |             |  |



---


## Some example correct and incorrect data names ##
```
   alb-popu-cas-py-s3_osm_hp
   bgd_popu_cas_py_s3_osm_hp
   bgd_popu_cas_py_osm_hp
   bgd_popu_cas_py_osm
   bgd_popu_cas_py_s2_osm
   bgd_popu_cas__py_s2_osm
   bgd_popu_cas_py_s3_osm_hp_Fe_txt
   bgd_popu_cas_py_osm_hp_Fe_txt
   bgd_popu_cas_py_osm_Fe_txt
   bgd_popu_cas_py_s2_osm_Fe_txt
   bgd_popu_cas_py_s3_osm_hp_Free_txt
   bgd_popu_cas_py_osm_hp_Free_txt
   bgd_popu_cas_py_osm_Free_txt
   bgd_popu_cas_py_s2_osm_Free_txt
   shape.file.with.dots.in.name.shp
   text.file.with.dots.in.name.txt
```