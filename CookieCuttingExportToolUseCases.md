# Introduction #
The Cookie cutting and export tool is use to create a copy of subset of a GDB (by geography or otherwise), and name the feature classes appropriately. There are a number of use cases

  1. During data scramble
  1. Handover to other organization
  1. Pre-deployment data preparation.
  1. Extraction by end user through web interface
  1. Ad-hoc use


# Details #

## Case one: during data scramble ##
  1. The user should be able to indentify the geographic AOI either has a polygon feature, from either a layer or graphics class or a bounding box.
  1. The user should be able to define a buffer, either in absolute or percentage terms, around the area of interest.
  1. The user should be able to define the geoextent name of the clipped area - hereafter the “clipgeoextentname”.
  1. The source layers can be any collection of layers such as a gdb, a dir of shapefile, an MXD, or other arbitrary collection of layers defined by the user
  1. A valid set of datanaming clause tables must be indentified with reference to the source layers. This can be done automatically or selected manually.
  1. The destination may either be a gdb or a dir of shapefiles. This should already exist and may or may not the empty.
  1. When a source layer is completely enclosed or overlaps less than 100% of the buffered clipping area then it should be clipped and copied to the destination, with its name in unchanged. This would typically include country datalayers and neighboring country datalayers, but not continental or global datalayers.
  1. Where a source layer entirely encloses the buffered clipping area, the layer should be clipped and renamed. Its existing geoextent clause should be replaced with the clipgeoextentname. This would typically be for subsets of global and/or continental datalayers.
  1. The dataname clause tables should be copied to the destination. If the clipgeoextentname does not exist in the source dataname table, it should be inserted to the new copy in the destination.
  1. If a polygon is used to define the clipping area (rather than a bounding box), then the user can select whether to use the polygon's bounding box is used for clipping rather than the polygon itself to clip source layers. The use should be able to define this separately for vector and raster layers.
  1. The clipping process may need to be reproduced on a replica of the GDB. Typically this will be internet facing GDB and the LFO gdb. It is essential that the exact parameters/options used are accessible and/or savable in a form that can be directly passed back as parameters to the tool in different locations.
  1. Layers which are erroneously named should be ignored and not copied.
  1. The user should have options of how to handle duplicate destination datanames, which should include automatically altering the free text clause (as described below) or throwing an error before any datalayers are clipped and copied..
  1. For performance reasons the tool should do a dummy run first to test for duplicate destination datanames, before doing the actual clip.
  1. Where a layer becomes a duplicate of another from the same source, due to having its geoextent changed, then its old geoextent should be added to the free text.
  1. Where a layer is or become a duplicate of a pre-existing layer (where the source was not empty) a user defined suffix can be included in the free text.
  1. Where possible any existing Free Text should be preserved. It the combination of preserving free text and automatic suffixes to deal with duplicate names, would result in a dataname that is too long, either a method of intelligently altering the free text should be devised or an error thrown.
  1. When exporting to Shapefiles in a directory, there should be an option to create nested subdirectories relating to either data type or data category or both. The directory names should be based on the “description” field in the naming tables and any spaces replaced by underscores. If this is done the data type and or category should still be included in the filenames as before.


## Case two: Handover to other organization ##


## Case three: Pre-deployment data preparation ##


## Case four: Extraction by end user through web interface ##


## Case five: Ad-hoc use ##