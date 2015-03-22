# Use Case for Cartographic Tools

This page describes a possible use case for a software tool, running as an extension to ArcGIS, which could extract information about map layer using the data naming convention and use that to apply default cartographic options / elements.

The data naming convention allows certain information about a map (or data) layer to be extracted pro grammatically.

## Symbology and labels ##

The problem of defining a good default symbology is divided into two parts:
  * Defining a suitable collection of cartographically good quality, clear, readable, attractive symbols and labels styles.
  * Creating procedure and tools by which knowledge of these symbols can be readily captured and disseminated.

The following assumptions are made:
  * Where a single symbology and label style is appropriate for all features in a layer then in many cases just three pieces of information about the layer are sufficient to select a suitable default symbol and label style and label expression:
  1. Data Category
  1. Data Theme
  1. Data Type
  * For reference (base map) layers where there is variation of symbology by attribute, then for many cases just four pieces of information about a particular data layer are sufficient to select a suitable default symbol and label style and label expression:
  1. Data Category
  1. Data Theme
  1. Source
  1. Data Type

Implicit in the data source is the information about the layer’s attributes.

Simple and label style information can be persisted individually as stylesheets, layer files or collectively in MXD files. Label expression information can be persisted individually as label expression files or collectively in MXD files.



A layer and/or label expression file will be searched for in the following order
```
<symbolsroot>\<datacategory>\<datatheme>\<source>_<datatype>.lyr
<symbolsroot>\<datacategory>\<datatheme>_<datatype>.lyr
<symbolsroot>\<datacategory>_<datatype>.lyr
```
A background layer and/or label expression file will be searched for in the following order:
```
<symbolsroot>\<datacategory>\<datatheme>\<source>_<datatype>_bg.lyr
<symbolsroot>\<datacategory>\<datatheme>_<datatype>_bg.lyr
<symbolsroot>\<datacategory>_<datatype>_bg.lyr
```




## Marginalia ##
  * Data Sources
The text to be included in the Data Sources element of the marginalia could be automatically extracted based on the “source” clause in the data name and the “marginalia\_notes” columns of the “datanaming\_clause\_source” table.
  * Layer Name
The Layer Name could be set automatically - syntax to be decided.
  * Layer Description
The Layer Description could be set automatically, by simply expanding each of the clauses in the dataname to the related "description" field in the DNCLTs.
  * Distribution permissions



## Default Map Templates ##