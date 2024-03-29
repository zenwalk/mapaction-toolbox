# ---------------------------------------------------------------------------
# Cookie.py
# Created on: Tue Jan 22 2008 09:34:56 PM
#   (generated by ArcGIS/ModelBuilder)
# Usage: Cookie Cutter
# 1. Set the three variables below. These are the main project directory (note the double slash), DEM (.img) and spatial resolution (or cellsize).
# 2. You MUST have a license for Spatial Analyst
# 3. This script will create 28 files for each volume calculation. Plenty of disc space should be allowed for.
# 4. All calculations are put inthe "output" directory. volume_clip are the final volume data.
# 5. All volume calculation stats are placed in the Volume_Master.dbf in the project directory.
# ---------------------------------------------------------------------------

# Import system modules
import sys, string, os, arcgisscripting,glob
import struct, datetime, decimal, itertools, csv

# Create the Geoprocessor object
gp = arcgisscripting.create(9.3)
gp.overwriteoutput = 1

#-----------------------------------------------------------------------------
# Variables
#-----------------------------------------------------------------------------
project_directory = "C:\\temp\\c_test"
nextmap_dsm_img = "C:\\temp\\c_test\\nextmap_dsm.img"
gp.cellSize = "5"
tension_parameter = "100"
buffer_parameter = "20"
#project_directory = sys.argv[1]
#nextmap_dsm_img = sys.argv[2]
#gp.cellSize = sys.argv[3]
#tension_parameter = sys.argv[4]
#buffer_parameter = sys.argv[5]
#-----------------------------------------------------------------------------

# For loop counter
count = 0

# Project Directory
dirprj = project_directory +"\\input"
if not os.path.exists(dirprj) :
    print "  Dir path not found", dirprj
    sys.exit()

# Create Volume Table
if not os.path.exists(project_directory +"\\Volume_Master.dbf") :
    gp.CreateTable(project_directory, "Volume_Master.dbf")
    gp.AddField(project_directory+"/Volume_Master.dbf","VALUE","long")
    gp.AddField(project_directory+"/Volume_Master.dbf","COUNT","long")
    gp.AddField(project_directory+"/Volume_Master.dbf","AREA","long")
    gp.AddField(project_directory+"/Volume_Master.dbf","MIN","float")
    gp.AddField(project_directory+"/Volume_Master.dbf","MAX","float")
    gp.AddField(project_directory+"/Volume_Master.dbf","RANGE","float")
    gp.AddField(project_directory+"/Volume_Master.dbf","MEAN","float")
    gp.AddField(project_directory+"/Volume_Master.dbf","STD","float")
    gp.AddField(project_directory+"/Volume_Master.dbf","SUM","float")
    gp.deletefield (project_directory+"/Volume_Master.dbf", "Field1")

# Check out any necessary licenses
gp.CheckOutExtension("spatial")

# Load required toolboxes...
gp.AddToolbox("C:/Program Files/ArcGIS/ArcToolbox/Toolboxes/Spatial Analyst Tools.tbx")
gp.AddToolbox("C:/Program Files/ArcGIS/ArcToolbox/Toolboxes/Conversion Tools.tbx")
gp.AddToolbox("C:/Program Files/ArcGIS/ArcToolbox/Toolboxes/Analysis Tools.tbx")

# Set first Geoprocessing environment...
gp.scratchWorkspace = project_directory +"\\temp"

# change to directory
os.chdir(dirprj)

# get list of shapefiles here
shps = glob.glob('*.shp')
total = len(shps)
#print "Total shapefiles: " total

# START THE LOOPING STRUCTURE

for shp in shps:
    count = count + 1

# call model and pass it full path to shapefile.
    print "Starting processing ", shp, " Count ",count," / ",total
    gp.AddMessage("Processing "+shp+" Count "+str(count)+"/"+str(total))

# Local variables...
    (fileBaseName, fileExt) = os.path.splitext(shp)
    (dirName, fileBaseName) = os.path.split(shp)
    (dumbName, fileName) = os.path.split(fileBaseName)
    (fileName, dumbName) = os.path.splitext(fileName)

# Local variables...
        
    Outline = project_directory +"\\input\\" + fileBaseName
    Buffered_Outline = project_directory +"\\output\\" + fileName+"_buffer.shp"

    Value_field = "BACKGROUND"
    Raster_Outline = project_directory +"\\output\\" + fileName+"_poly.img"

    Null_Outline = project_directory +"\\output\\" + fileName+"_null.img"
    Map_Algebra_expression = "Con ( IsNull ( "+Raster_Outline+" ) , -32767 , ( "+Raster_Outline+" ) )"

    Expression = "Value = -32767"
    NullExpression = "Value = -32768"

    Output_Dataset = project_directory +"\\output\\" + fileName+"_output.img"
    Output_Null = project_directory +"\\output\\" + fileName+"_output_null.img"
    Output_Feature = project_directory +"\\output\\" + fileName+"_features.shp"

    spline_base = project_directory +"\\output\\" + fileName+"_base.img"
    volume = project_directory +"\\output\\volume_" + fileName+".img"
    volume_clip = project_directory +"\\output\\volume_clip_" + fileName+".img"
    volume_zone = project_directory +"\\output\\" + fileName+"_zone.img"
    stats_table = project_directory +"\\output\\volume_stats_" + fileName+".dbf"
    master_table = project_directory +"\\Volume_Master.dbf"

# Process: Instantiate extent at beginning of each iteration
    #gp.extent = "N/A"
    gp.extent = project_directory +"\\input\\" + fileName+".shp"
    extent = gp.extent
    print "The mask is..." , extent
    
# Process: Buffer...
    gp.Buffer_analysis(Outline, Buffered_Outline, buffer_parameter, "FULL", "ROUND", "NONE", "")

# Set second Geoprocessing environment...
    gp.extent = project_directory +"\\output\\" + fileName+"_buffer.shp"
    gp.mask = project_directory +"\\output\\" + fileName+"_buffer.shp"
    mask = gp.mask
    extent = gp.extent
    print "The mask is..." , mask, extent

# Process: Polygon to Raster...
    gp.PolygonToRaster_conversion(Outline, Value_field, Raster_Outline, "MAXIMUM_AREA", "NONE", gp.cellSize)

# Process: Single Output Map Algebra: null values in hole converted to -32767
    gp.SingleOutputMapAlgebra_sa(Map_Algebra_expression, Null_Outline, Raster_Outline)

# Process: Con: overlay the hole on the DEM and extract the buffer
    gp.Con_sa(Null_Outline, nextmap_dsm_img, Output_Dataset, Null_Outline, Expression)

# Process: Set Null for hole
    gp.SetNull_sa(Output_Dataset, Output_Dataset, Output_Null, NullExpression)

# Process: RasterToPoint_conversion
    gp.RasterToPoint_conversion(Output_Null, Output_Feature)

# Process: Spline Interpolation
    gp.Spline_sa(Output_Feature, "GRID_CODE", spline_base, gp.cellSize, "TENSION", tension_parameter)

# Process: Subtract base from DEM
    gp.Minus_sa(nextmap_dsm_img, spline_base, volume)

# Process: Clip the volume to the original outline
    gp.ExtractByMask_sa(volume, Outline, volume_clip)

# Process: Create zone
    gp.EqualTo_sa(volume_clip, volume_clip, volume_zone)

# Process: Volume stats
    gp.ZonalStatisticsAsTable_sa(volume_zone, "Value", volume_clip, stats_table, "DATA")

# Process: Append stats
    gp.Append_management(stats_table, master_table, "NO_TEST")

# END FOR LOOP
else:
        print count
        gp.AddMessage("Finished "+str(count))
