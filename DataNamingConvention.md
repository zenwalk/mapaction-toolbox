# Syntax #

```
geoextent_datacategory_datatheme_datatype[_scale]_source[_permission][_FreeText]
```

(Square bracket denote optional clauses)

# General Notes #

  * A dataname is considered to be "correct" if both:
    * It's syntax matches the syntax given above.
    * Each individual clause is checked against and found on a collection of "datanaming tables" which contain valid values for each clause.
  * In each table in the datanaming tables there is a "Clause" column and a "Description" column. Additional columns exist in some tables as appropriate. See separate page on the structure of the data naming tables (to follow)
  * Hyphens "-" are not permitted in GDBs, hence each clause must be separated with underscores "`_`". This is enforced even when Shapefiles are being used.
  * There is no absolute constraint on the length of the Geoextent, Data Category and Data Theme clauses. Clauses created in the field may be of any length (allowing for the limit on the total length of datanames). However for general readability, it is recommended that the data in the Pre-Deployment GDB and where possible in the field the following lengths are adhered to:
    * Geoextent = Three chars
    * Data Category = Four chars
    * Data Theme = Three chars

# Details on Individual Clauses #

| Clause | Default Format | Notes |
|:-------|:---------------|:------|
| Geoextent | Any number of characters - typically three | The Spatial/Geographical Extent of the data. This may be a country or continent clause. Can also be refer to other geographies, eg individual admin districts, cities etc. Refer to Country Codes table Country codes - As Before but reformatted into single table In some cases, a combined code may be allocated, e.g. 'htidom' for Haiti and Dominican Republic. For localised datasets, include an agreed place code or place name. The master list contains the 3-letter ISO 3166 country codes, continent clause and 'wrl' for global (worldwide) layers. |
| Data Category | Any number of characters - typically four | The “Data Category” clause provides a broad description of the content of the data. Due to the lack of directories in a GDB, the additional Data Category field has been introduced to provide the equivalent description. The "master" list of Data Categories where agreed at one of the workshop sessions at LFO in Spring 2009. The only addition since then is Points of Interest category. |
| Data Theme | Any number of characters - typically three | The “Data Theme” clause provides a more detailed description of the content of the data. Valid Data Themes are nested hierarchically within Data Categories. The current (12-May-2010) master list is not considered complete and should be reviewed as the Pre-Deployment GDB is populated. |
| Data Type | 2 or 3 letter code | The geometric type of the spatial component of the layer. Valid Data Type Clauses include point (pt), line (ln), polygon (py), raster dataset (ras), raster catalog (rca), table (ta), triangulated irregular network (tin) |
| [scale](scale.md) | "'s" + 1 number | OPTIONAL<br> This clause represents the order of magnitude of the scale at with it is appropriate to display the dataset. It does not represent the survey scale, resolution or other concepts of scale. This is intended to distinguish multiple datasets that are useful at different scales. If the scale clause is excluded then it is assumed to be "scale unknown", with by default is displayed at all scale ranges. <br>
<tr><td> source </td><td> Any number of characters </td><td> The Source clause describes the origin the dataset. There is some room for interpretation of what constitutes as “source”. The List contains a mixture of organisations from which we source data, and a list of datasets which we have used. Similarly there is a mix of Clusters and the corresponding lead agencies – there are times when it would be appropriate to list one rather than the other. Further compilation is that certain datasets seem to be jointly owned by more than one agency (eg ASTER GDEM and TRMM are both distributed by both NASA and JAXA).<br>  - Data portals should not be listed as primary sources.<br>  - Whilst still subjective, the guiding principle here should be a source match one-to-one with what would need to be individually referenced in the margins of a map.<br></td></tr>
<tr><td> <a href='permission.md'>permission</a> </td><td> 2 letter code </td><td> OPTIONAL<br> The “Permissions” clause describes both the permissions for redistributing the data and for distributing maps derived from the data. The format is a two letter clause (There is no space or underscore between the letters):<br> <code>`[groups who can receive the data][groups who can receive derived maps]`</code> <br><br>Distribution Group - Character<br>Public - p<br>Humanitarian Community - h<br>MapAction Only - m<br><br>Given that the map distribution permissions will always at least as generous as the data permissions there are six possible combinations. It is likely that some of these will rarely be used.<br> </td></tr>
<tr><td> <a href='Free.md'>Text</a> </td><td> Any characters permitted within GDB table naming rules </td><td> OPTIONAL <br>Including a free text section is considered important to provide flexibility. Three reasons for this: <br> - It allows field teams to invent their own “sub-naming convention” in the field as need dictates.<br> - It allows the equivalent of attribute names for raster layers (consider the minimum of nine raster layers that make up the grump/gpw dataset – more if you include different year estimates). Otherwise these would all have the same name within naming convention.<br> - It allows for the intermediary files to be created, additional copies to be saved when ArcGIS just won't behave itself, etc etc </td></tr>