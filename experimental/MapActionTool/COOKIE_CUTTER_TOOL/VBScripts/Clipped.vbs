' ---------------------------------------------------------------------------
' 1.vbs
' Created on: Sun Nov 15 2009 10:07:40 PM
'   (generated by ArcGIS/ModelBuilder)
' ---------------------------------------------------------------------------

' Create the Geoprocessor object
set gp = WScript.CreateObject("esriGeoprocessing.GPDispatch.1")

' Load required toolboxes...
gp.AddToolbox "C:/Program Files/ArcGIS/ArcToolbox/Toolboxes/Analysis Tools.tbx"


' Local variables...
v1_shp = "C:\Documents and Settings\Andy\Desktop\ClippedData\1.shp"
StreamsF = "StreamsF"
NestBuff = "NestBuff"

' Process: Clip...
gp.Clip_analysis StreamsF, NestBuff, v1_shp, "10 Meters"

