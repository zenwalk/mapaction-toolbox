﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using ESRI.ArcGIS.ArcMap;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Desktop;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Framework;
using Alpha_ConfigTool;


namespace Prototype1_ExportTool
{
    public partial class frmMain : Form
    {
        //Set the dataframe that you are searching for in the layouts.  This is used in many methods below.
        //Need a better solution for sorting this out
        private string targetMapFrame = "Main map";
        
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnUserRight_Click(object sender, EventArgs e)
        {
            tabExportTool.SelectedTab = tabPageExport;
        }

        private void btnUserLeft_Click(object sender, EventArgs e)
        {
            tabExportTool.SelectedTab = tabPageLayout;
        }

        private void btnLayoutRight_Click(object sender, EventArgs e)
        {
            tabExportTool.SelectedTab = tabPageUser;
        }

        private void btnExportLeft_Click(object sender, EventArgs e)
        {
            tabExportTool.SelectedTab = tabPageUser;
        }

        private void btnExportZipPath_Click(object sender, EventArgs e)
        {
            //set up select folder dialog properties 
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            //set the intial path
            dlg.SelectedPath = @"c:\";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbxExportZipPath.Text = dlg.SelectedPath;
            }
            else
            {
                return;
            }
        }

       

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;

            var dict = new Dictionary<string, string>();
            dict = MapAction.PageLayoutProperties.getLayoutTextElements(pMxDoc, targetMapFrame);

            if (dict.ContainsKey("title")) { tbxMapTitle.Text = dict["title"]; }
            if (dict.ContainsKey("summary")) { tbxMapSummary.Text = dict["summary"]; }
            if (dict.ContainsKey("mxd_name")) { tbxMapDocument.Text = dict["mxd_name"]; }
            //if (dict.ContainsKey("scale_text")) { tbxMapDocument.Text = dict["scale_text"]; }
            
            // Remove formatting from data source before updating the textbox
            string datasource;
            string unformatedDataSource = string.Empty;
            if (dict.ContainsKey("data_source")) { unformatedDataSource = dict["data_source"]; };
            datasource = Regex.Replace(unformatedDataSource, "\\<.*?\\>", String.Empty);
            if (dict.ContainsKey("data_source")) { tbxDataSources.Text = datasource; }

            // Get values from the config xml
            var dictXML = new Dictionary<string, string>();
            string path = Alpha_ConfigTool.Properties.Settings.Default.crash_move_folder_path;
            string filePath = path + @"\operation_config.xml";
            dictXML = MapAction.Utilities.getOperationConfigValues(filePath);
            if (dictXML.ContainsKey("GlideNo")) { tbxGlideNo.Text = dictXML["GlideNo"]; }
            if (dictXML.ContainsKey("Language")) { tbxLanguage.Text = dictXML["Language"]; }
            if (dictXML.ContainsKey("OperationId")) { tbxOperationId.Text = dictXML["OperationId"]; }
            if (dictXML.ContainsKey("DefaultPathToExportDir")) { tbxExportZipPath.Text = dictXML["DefaultPathToExportDir"]; }
            if (dictXML.ContainsKey("DefaultJpegResDPI")) { nudJpegResolution.Value = Convert.ToDecimal(dictXML["DefaultJpegResDPI"]); }
            if (dictXML.ContainsKey("DefaultPdfResDPI")) { nudPdfResolution.Value = Convert.ToDecimal(dictXML["DefaultPdfResDPI"]); }
            if (dictXML.ContainsKey("DefaultEmfResDPI")) { nudEmfResolution.Value = Convert.ToDecimal(dictXML["DefaultPdfResDPI"]); }


            // Set the spatial reference information on load
            var dictSpatialRef = new Dictionary<string, string>();
            dictSpatialRef  = MapAction.Utilities.getDataFrameSpatialReference(pMxDoc, targetMapFrame);
            tbxDatum.Text = dictSpatialRef["datum"];
            tbxProjection.Text = dictSpatialRef["projection"];

            // Set the 'metadata' tab elements
            var date = System.DateTime.Today.ToString("dd/MM/yyyy");
            var time = System.DateTime.Now.ToString("HH:mm:ss");
            tbxDate.Text = date;
            tbxTime.Text = time;
            tbxPaperSize.Text = MapAction.PageLayoutProperties.getPageSize(pMxDoc, targetMapFrame);
            tbxScale.Text = MapAction.PageLayoutProperties.getScale(pMxDoc, targetMapFrame);
            
        }

        private void btnCreateZip_Click(object sender, EventArgs e)
        {

            // Create and start a stopwatch to measure the function performance
            Stopwatch sw = Stopwatch.StartNew();

            // Start checks before running the the acutal create elements
            if (tbxMapDocument.Text == string.Empty)
            {
                MessageBox.Show("A document name is required. It is used as a part of the output file names.",
                    "Update document name", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tabExportTool.SelectedTab = tabPageLayout;
                tbxMapDocument.Focus();
                return;
            }
            
            //!!!!!!!!!!Need a method to check to see if the user has write access to the set path !!!!!!!!!!!!!!//
            var path = tbxExportZipPath.Text;
            //check the path exists and ideally check for write permissions
            if (!Directory.Exists(@path))
            {
                Debug.WriteLine("Exiting createZip function as path is not valid");
                //set up a timer and flash the background of the tbxExportZipPath control red for .25 of a second
                //then take the form focus
                System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
                t.Interval = 250;
                t.Tick += delegate(System.Object o, System.EventArgs error)
                {
                    t.Stop();
                    t.Dispose();
                    tbxExportZipPath.Focus();
                    tbxExportZipPath.BackColor = System.Drawing.Color.White;
                };
                t.Start();
                tbxExportZipPath.BackColor = ColorTranslator.FromHtml("#FFE5EB");
                return;
            }
            Debug.WriteLine("checks on export complete");

            // Get the path and file name to pass to the various functions
            string exportPathFileName = getExportPathFileName(tbxExportZipPath.Text, tbxMapDocument.Text);

            // Disable the button after the export checks are complete to prevent multiple clicks
            this.Enabled = false;

            // this method doesn't correctly in checking for permissions, requires updating.  
            // MapAction.Utilities.detectWriteAccessToPath(path);

            IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;
            IActiveView pActiveView = pMxDoc.ActiveView;

            // Call to export the images and return a dictionary of the file sizes
            Dictionary<string, string> dictFilePaths = exportAllImages();

            // Create a dictionary to store the image file sizes to add to the output xml
            Dictionary<string, long> dictImageFileSizes = new Dictionary<string, long>();
            // Calculate the file size of each image and add it to the dictionary
            dictImageFileSizes.Add("pdf", MapAction.Utilities.getFileSize(dictFilePaths["pdf"]));
            System.Windows.Forms.Application.DoEvents();
            dictImageFileSizes.Add("jpeg", MapAction.Utilities.getFileSize(dictFilePaths["jpeg"]));
            dictImageFileSizes.Add("emf", MapAction.Utilities.getFileSize(dictFilePaths["emf"]));

            // Create a dictionary to get and store the map frame extents to pass to the output xml
            Dictionary<string, string> dictFrameExtents = MapAction.PageLayoutProperties.getDataframeProperties(pMxDoc, "Main map");

            // Export KML
            string kmzPathFileName = exportPathFileName + ".kmz";
            string kmzScale;
            if (dictFrameExtents.ContainsKey("scale")) {kmzScale = dictFrameExtents["scale"];} else {kmzScale = null;};
            MapAction.MapExport.exportMapFrameKmlAsRaster(pMxDoc, "Main map", @kmzPathFileName, kmzScale);

            // Get the mxd filename
            string mxdName = ArcMap.Application.Document.Title;
            System.Windows.Forms.Application.DoEvents();
            // Create the output xml file & return the xml path           
            string xmlPath = string.Empty;
            try
            {
                Dictionary<string, string> dict = getExportToolValues(dictImageFileSizes, dictFilePaths, dictFrameExtents, mxdName);
                xmlPath = MapAction.Utilities.createXML(dict, "mapdata", path, tbxMapDocument.Text, 2);
            }
            catch (Exception xml_e)
            {
                Debug.WriteLine("Error writing out xml file.");
                Debug.WriteLine(xml_e.Message);
                return;
            }

            // Add the xml path to the dictFilePaths, which is the input into the creatZip method
            dictFilePaths.Add("xml", xmlPath);

            // Create zip
            MapAction.MapExport.createZip(dictFilePaths);
            // close the wait dialog
            // dlg.lblWaitMainMessage.Text = "Export complete";
            // int milliseconds = 1250;
            // Thread.Sleep(milliseconds);
            this.Close();

            // the output filepath

            MessageBox.Show("Files successfully output to: " + Environment.NewLine + path,
                "Export complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // If open explorer checkbox is ticked, open windows explorer to the directory 
            if (chkOpenExplorer.Checked)
            {
                MapAction.MapExport.openExplorerDirectory(tbxExportZipPath.Text);
            }

            sw.Stop();
            string timeTaken = Math.Round((sw.Elapsed.TotalMilliseconds / 1000),2).ToString();
            Debug.WriteLine("Time taken: ", timeTaken);

        }

        private Dictionary<string, string> getExportToolValues(Dictionary<string, long> dictImageFileSizes, 
            Dictionary<string, string> dictFilePaths, Dictionary<string, string> dictFrameExtents, string mxdName)
        {
            // Create a dictionary and add values from Export form
            var dict = new Dictionary<string, string>()
            {
                {"operationID",     tbxOperationId.Text},
                {"sourceorg",       "MapAction"}, //this is hard coded in the existing applicaton
                {"title",           tbxMapTitle.Text},
                {"ref",             tbxMapDocument.Text},
                {"language",        tbxLanguage.Text},
                {"countries",       tbxCountries.Text},
                {"createdate",      tbxDate.Text},
                {"createtime",      tbxTime.Text},
                {"status",          cboStatus.Text},
                {"xmax",            dictFrameExtents["xMax"]},
                {"xmin",            dictFrameExtents["xMin"]},
                {"ymax",            dictFrameExtents["yMax"]},
                {"ymin",            dictFrameExtents["yMin"]},
                {"proj",            tbxProjection.Text},
                {"datum",           tbxDatum.Text},
                {"jpgfilename",     System.IO.Path.GetFileName(dictFilePaths["jpeg"])},
                {"pdffilename",     System.IO.Path.GetFileName(dictFilePaths["pdf"])},
                {"qclevel",         cboQualityControl.Text},
                {"qcname",          ""},
                {"access",          cboAccess.Text},
                {"glideno",         tbxGlideNo.Text},
                {"summary",         tbxMapSummary.Text},
                {"imagerydate",     tbxImageDate.Text},
                {"datasource",      tbxDataSources.Text},
                {"location",        tbxImageLocation.Text},
                {"theme",           cboTheme.Text},
                {"scale",           tbxScale.Text},
                {"papersize",       tbxPaperSize.Text},
                {"jpgfilesize",     dictImageFileSizes["jpeg"].ToString()},
                {"jpgresolutiondpi",nudJpegResolution.Value.ToString()},
                {"pdffilesize",     dictImageFileSizes["pdf"].ToString()},
                {"pdfresolutiondpi",nudPdfResolution.Value.ToString()},
                {"mxdfilename",     mxdName},
                {"paperxmax",       ""},
                {"paperxmin",       ""},
                {"paperymax",       ""},
                {"paperymin",       ""},
                {"kmzfilename",     ""},
                {"accessnotes",     tbxImageAccessNotes.Text}
            };
            return dict;
            //string filename = Path.GetFileName(path);
        }

        private void btnValidate_Click(object sender, EventArgs e)
        {
            // Start validation procedures
            // List<string> lstEmptyFields = validation.getEmptyRequiredFieldList(getExportToolValues());

            //lblEmptyXmlFieldCount.Text = lstEmptyFields.Count.ToString();
            //string returnString = string.Join(Environment.NewLine, lstEmptyFields.ToArray());
            //lblEmptyFields.Text = returnString;
        }

        private Dictionary<string, string> exportAllImages()
        {
            IMxDocument pMxDoc = ArcMap.Application.Document as IMxDocument;
            //IActiveView pActiveView = pMxDoc.ActiveView;
            var dict = new Dictionary<string, string>();

            // Get the path and file name to pass to the various functions
            string exportPathFileName = getExportPathFileName(tbxExportZipPath.Text, tbxMapDocument.Text);

            //check to see variable exists
            if (!Directory.Exists(@tbxExportZipPath.Text) || tbxMapDocument.Text == "" || tbxMapDocument.Text == string.Empty)
            {
                Debug.WriteLine("Image export variables not valid.");
                return dict;
            }
            else
            {
                //Output 3 image formats pdf, jpeg & emf
                dict.Add("pdf", MapAction.MapExport.exportImage(pMxDoc, "pdf", nudPdfResolution.Value.ToString(), exportPathFileName, null));
                dict.Add("jpeg", MapAction.MapExport.exportImage(pMxDoc, "jpeg", nudJpegResolution.Value.ToString(), exportPathFileName, null));
                dict.Add("emf", MapAction.MapExport.exportImage(pMxDoc, "emf", nudEmfResolution.Value.ToString(), exportPathFileName, null));
                MapAction.MapExport.exportImage(pMxDoc, "emf", nudEmfResolution.Value.ToString(), exportPathFileName, "Main map");
                MapAction.MapExport.exportImage(pMxDoc, "jpeg", nudEmfResolution.Value.ToString(), exportPathFileName, "Main map");

            }

            return dict;
        }

        private void chkEditAllFields_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEditAllFields.Checked)
            {
                tbxMapTitle.ReadOnly = false;
                tbxMapSummary.ReadOnly = false;
                tbxMapDocument.ReadOnly = false;
                tbxDatum.ReadOnly = false;
                tbxProjection.ReadOnly = false;
                tbxDate.ReadOnly = false;
                tbxTime.ReadOnly = false;
                tbxPaperSize.ReadOnly = false;
                tbxScale.ReadOnly = false;
                tbxOperationId.ReadOnly = false;
                tbxGlideNo.ReadOnly = false; 
            }
            else
            {
                tbxMapTitle.ReadOnly = true;
                tbxMapSummary.ReadOnly = true;
                tbxMapDocument.ReadOnly = true;
                tbxDatum.ReadOnly = true;
                tbxProjection.ReadOnly = true;
                tbxDate.ReadOnly = true;
                tbxTime.ReadOnly = true;
                tbxPaperSize.ReadOnly = true;
                tbxScale.ReadOnly = true;
                tbxOperationId.ReadOnly = true;
                tbxGlideNo.ReadOnly = true; 
            }
        }

        private string getExportPathFileName(string path, string documentName)
        {
            // Concatenate the 
            string pathFileName = @path + "\\" + documentName;
            return pathFileName; 
        
        }



    }
}
