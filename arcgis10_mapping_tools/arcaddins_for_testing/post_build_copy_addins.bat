del /q %~dp0Alpha_ConfigTool.esriAddIn
del /q %~dp0Alpha_ExportTool.esriAddIn
del /q %~dp0Alpha_LayoutTool.esriAddIn
del /q %~dp0MapActionToolbars.esriAddIn
xcopy /y %~dp0..\Alpha_ConfigTool\Alpha_ConfigTool\bin\Debug\Alpha_ConfigTool.esriAddIn %~dp0
xcopy /y %~dp0..\Alpha_ExportTool\Alpha_ExportTool\bin\Debug\Alpha_ExportTool.esriAddIn %~dp0
xcopy /y %~dp0..\Alpha_LayoutTool\Alpha_LayoutTool\bin\Debug\Alpha_LayoutTool.esriAddIn %~dp0
xcopy /y %~dp0..\MapActionToolbars\bin\Debug\MapActionToolbars.esriAddIn %~dp0