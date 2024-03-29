﻿'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
''Copyright (C) 2010 MapAction UK Charity No. 1075977
''
''www.mapaction.org
''
''This program is free software; you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation; either version 3 of the License, or (at your option) any later version.
''
''This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
''
''You should have received a copy of the GNU General Public License along with this program; if not, see <http://www.gnu.org/licenses>.
''
''Additional permission under GNU GPL version 3 section 7
''
''If you modify this Program, or any covered work, by linking or combining it with 
''ESRI ArcGIS Desktop Products (ArcView, ArcEditor, ArcInfo, ArcEngine Runtime and ArcEngine Developer Kit) (or a modified version of that library), containing parts covered by the terms of ESRI's single user or concurrent use license, the licensors of this Program grant you additional permission to convey the resulting work.
'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Framework
Imports ESRI.ArcGIS.Geodatabase
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.IO


''' <summary>
''' Provides a specfic implenmentation of the IDataListConnection, based on reading the list
''' from an MXD file.
''' </summary>
''' <remarks>
''' Provides a specfic implenmentation of the IDataListConnection, based on reading the list
''' from an MXD file.
'''
''' There is no public constructor for this class. New instances should be generated using 
''' the XXXX factory class.
'''  </remarks>
Public Class DataListMXDConnection
    Inherits AbstractDataListConnection

    Private m_blnMxDocument As Boolean
    Private m_MapDocument As IMapDocument = Nothing
    Private m_MxDocument As IMxDocument = Nothing
    Private m_fInfoFullPath As FileInfo

    ''' <summary>
    ''' Constructs a new MXD list based on the MXD file in the argument. This version
    ''' of the constructor assumes that we are operating in the a non-ArcMap environment
    ''' (possibly ArcCatalog or entirely standalone).
    ''' </summary>
    ''' <param name="fInfoMXD">A FileInfo object pointing to the MXD file.</param>
    ''' <remarks>
    ''' Constructs a new MXD list based on the the MXD file in the argument. This version
    ''' of the constructor assumes that we are operating in the a non-ArcMap environment
    ''' (possibly ArcCatalog or entirely standalone).
    ''' 
    ''' This constuctor should only be call from within the relevant factory class.
    ''' </remarks>
    Protected Friend Sub New(ByRef fInfoMXD As FileInfo)
        MyClass.New(fInfoMXD.FullName)
    End Sub


    ''' <summary>
    ''' Constructs a new MXD list based on the the arguments. This version of the
    ''' constructor assumes that we are operating in the a non-ArcMap environment
    ''' (possibly ArcCatalog or entirely standalone).
    ''' </summary>
    ''' <param name="srtAry">A string array. The first member is assumed to represent 
    ''' the full path to the MXD file.</param>
    ''' <remarks>
    ''' Constructs a new MXD list based on the the arguments. This version of the
    ''' constructor assumes that we are operating in the a non-ArcMap environment
    ''' (possibly ArcCatalog or entirely standalone).
    ''' 
    ''' This constuctor should only be call from within the relevant factory class.
    ''' </remarks>
    Protected Friend Sub New(ByVal srtAry() As String)
        MyClass.New(srtAry(0))
    End Sub


    ''' <summary>
    ''' Constructs a new MXD list based on the MXD file in the argument. This version
    ''' of the constructor assumes that we are operating in the a non-ArcMap environment
    ''' (possibly ArcCatalog or entirely standalone).
    ''' </summary>
    ''' <param name="strMXDfilePath">A string with the full path pointing to the MXD file.</param>
    ''' <remarks>
    ''' Constructs a new MXD list based on the the MXD file in the argument. This version
    ''' of the constructor assumes that we are operating in the a non-ArcMap environment
    ''' (possibly ArcCatalog or entirely standalone).
    ''' 
    ''' This constuctor should only be call from within the relevant factory class.
    ''' </remarks>
    Protected Friend Sub New(ByRef strMXDfilePath As String)
        Dim mapDocArg As IMapDocument = New MapDocument
        Dim fInfoMXDfile As FileInfo

        fInfoMXDfile = New FileInfo(strMXDfilePath)

        If (Not fInfoMXDfile.Exists()) OrElse _
               Not mapDocArg.IsPresent(strMXDfilePath) Or _
               Not mapDocArg.IsMapDocument(strMXDfilePath) Or _
               mapDocArg.IsPasswordProtected(strMXDfilePath) Then
            'Cannot open MXD, throw Exception
            Throw New ArgumentException("Cannot open MXD file: " & strMXDfilePath)
        Else
            mapDocArg.Open(strMXDfilePath)
            'and mapDocArg.IsMap Then
            m_MapDocument = mapDocArg
            m_blnMxDocument = False
            m_fInfoFullPath = fInfoMXDfile
        End If
    End Sub


    ''' <summary>
    ''' Constructs a new MXD list based on the IMxDocument in the argument. This version
    ''' of the constructor assumes that we are operating in the an ArcMap environment
    ''' </summary>
    ''' <param name="app">A IApplication passed from the parent ArcMap application .</param>
    ''' <remarks>
    ''' Constructs a new MXD list based on the the IMxDocument in the argument. This version
    ''' of the constructor assumes that we are operating in the an ArcMap environment
    ''' 
    ''' This constuctor should only be call from within the relevant factory class.
    ''' </remarks>
    Protected Friend Sub New(ByRef app As IApplication)
        'Protected Friend Sub New(ByRef mxDoc As IMxDocument)
        'Dim appParent As IApplication

        'mxDoc.
        'set the mapdoc reference
        'just to be clear that this may throw an error
        Try
            m_MxDocument = CType(app.Document, IMxDocument)
            m_blnMxDocument = True
        Catch ex As Exception
            Throw ex
        End Try

        'Now set the path name....

        'I cannot believe that this is the best way to find 
        'out the name of the current MXD in ArcMap!!!!
        'Dim t As Type = Type.GetTypeFromProgID("esriFramework.AppRef")
        'Dim obj As System.Object = Activator.CreateInstance(t)
        'Dim app As IApplication = CType(obj, IApplication)
        'appParent = app

        ' get current MXD name
        m_fInfoFullPath = New FileInfo(app.Templates.Item(app.Templates.Count - 1))
    End Sub


    ''' <summary>
    ''' Gets all of the Map object (Data Frames in ArcMap) in this MXD.
    ''' </summary>
    ''' <returns>An array of all of the Map object in this MXD</returns>
    ''' <remarks>
    ''' Gets all of the Map object (Data Frames in ArcMap) in this MXD.
    ''' </remarks>
    Private Function getMaps() As IMap()
        Dim mapArray() As IMap
        Dim mapGroup As IMaps

        If m_blnMxDocument Then
            mapGroup = m_MxDocument.Maps
            ReDim mapArray(mapGroup.Count - 1)
            For i As Integer = 0 To (mapGroup.Count - 1)
                mapArray.SetValue(mapGroup.Item(i), i)
            Next
        Else
            ReDim mapArray(m_MapDocument.MapCount - 1)
            For i As Integer = 0 To (m_MapDocument.MapCount - 1)
                mapArray.SetValue(m_MapDocument.Map(i), i)
            Next
        End If

        Return mapArray
    End Function


    ''' <summary>
    ''' Gets the number of the Map object (Data Frames in ArcMap) in this MXD.
    ''' </summary>
    ''' <returns>The number of Map object in this MXD</returns>
    ''' <remarks>
    ''' Gets the number the Map object (Data Frames in ArcMap) in this MXD.
    ''' </remarks>
    Private Function getMapCount() As Integer
        If m_blnMxDocument Then
            Return m_MxDocument.Maps.Count
        Else
            Return m_MapDocument.MapCount
        End If
    End Function


    ''' <summary>
    ''' A convenience function to test whether or not the named layer is present in this MXD.
    ''' </summary>
    ''' <param name="strLayerName">The name of the layer, whose presence is being tested for.</param>
    ''' <returns>TRUE if strLayerName is present in this MXD, FALSE otherwise</returns>
    ''' <remarks>
    ''' A convenience function to test whether or not the named layer is present in this MXD.
    ''' </remarks>
    Public Overrides Function doesLayerExist(ByVal strLayerName As String) As Boolean
        'todo HIGH: implenment doesLayerExist
    End Function


    ''' <summary>
    ''' This method will attempt to physically locate a suitable set of DataNames Clause Lookup Tables, based
    ''' on the file path of the MXD.
    ''' </summary>
    ''' <returns>An IDataNameClauseLooup object representing automatically located DataNames Clause Tables</returns>
    ''' <remarks>
    ''' This method will attempt to physically locate a suitable set of DataNames Clause Lookup Tables, based
    ''' on the file path of the MXD.
    ''' 
    ''' If the one of the parent directories of the MXD contains a subdirectory "2_Active_Data", then that 
    ''' Active Data Directory is searched for GDB or Access DBs containing DataNames Clause Lookup Tables.
    ''' 
    ''' If the Data Names Clause Tables cannot be physically located becuase either they do not exist or there
    ''' is not a unquine location, then a exception is raised.
    ''' 
    ''' For more details on how this should be implenmented please see:
    ''' http://code.google.com/p/mapaction-toolbox/wiki/SearchForDefaultDataNameClauseLookupTables
    ''' </remarks>
    Public Overrides Function getDefaultDataNameClauseLookup() As IDataNameClauseLookup
        Dim dnclRef As IDataNameClauseLookup
        Dim strMxdPath As String

        ' get current MXD name
        strMxdPath = getpath().FullName

        Try
            dnclRef = DataNameClauseLookupFactory.createDataNameClauseLookup(getMAActiveDataDir(strMxdPath), True)
        Catch ex As Exception
            'todo LOW: put in some fancy foot work to loop through the layers and find the 
            'most common root for the data and try that/those path(s).
            'For now we just throw an exception
            Throw ex
        End Try

        Return dnclRef
    End Function


    ''' <summary>
    ''' Returns the operating system file path to the MXD.
    ''' </summary>
    ''' <returns>A FileInfo object representing the operating system file path
    ''' to the MXD.</returns>
    ''' <remarks>
    ''' Returns the operating system file path to the MXD.
    ''' </remarks>
    Public Overrides Function getPath() As System.IO.FileInfo
        Return m_fInfoFullPath
    End Function


    ''' <summary>
    ''' Returns FALSE to indicate that an MXD does not have a heirachical structure.
    ''' </summary>
    ''' <returns>
    ''' FALSE to indicate that an MXD does not have a heirachical structure.
    ''' </returns>
    ''' <remarks>
    ''' Returns FALSE to indicate that an MXD does not have a heirachical structure.
    ''' 
    ''' Implenmentation note: strictly an MXD is a heirachical list of layer, with the
    ''' top level of the heirachy declared as DataFrames and lower levels declared as
    ''' potenially nested Group Layers. However MXDs are typically such shallow heirachies
    ''' that it is jugded that enforcing a heirachical search of an MXD may confuse more 
    ''' users than it helps. Hence it has been decided that a DataListMXDConnection will
    ''' behave as a non-heirachical data list flattening out what heirachy does exist.
    ''' </remarks>
    Public Overrides Function isheirachical() As Boolean
        Return False
    End Function


    ''' <summary>
    ''' Returns the file path to the MXD.
    ''' </summary>
    ''' <returns>A String representing the full file path
    ''' to the MXD.</returns>
    ''' <remarks>
    ''' Returns the file path to the MXD.
    ''' </remarks>
    Public Overrides Function getDetails() As String
        Return m_fInfoFullPath.FullName
    End Function


    ''' <summary>
    ''' Returns an dnListType enumeration which represents the underlying
    ''' physical type of the connection (dnListType.MXD).
    ''' </summary>
    ''' <returns>dnListType.MXD</returns>
    ''' <remarks>
    ''' Returns an dnListType enumeration which represents the underlying
    ''' physical type of the connection.
    ''' </remarks>
    Public Overrides Function getDataListConnectionType() As dnListType
        Return dnListType.MXD
    End Function


    ''' <summary>
    ''' Returns a String which describes the type of connection.
    ''' </summary>
    ''' <returns>A String which describes the type of connection, in this case
    ''' equal to DATALIST_TYPE_MXD.
    ''' </returns>
    ''' <remarks>
    ''' Returns a String which describes the type of connection.
    ''' </remarks>
    Public Overrides Function getDataListConnectionTypeDesc() As String
        Return DATALIST_TYPE_MXD
    End Function


	''' <summary>
    ''' Returns a List of IDataName objects representing the Data names of all of the unique layers 
    ''' defined by this MXD. Layers which occur multiple time in the MXD (either within the 
    ''' same map/data frame or within different maps/data frames) are filtered out and only 
    ''' occur once in the returned list.
    ''' </summary>
    ''' <returns>
    ''' List of IDataName objects representing the names of all of the layers defined
    ''' by this MXD.
    ''' </returns>
    ''' <remarks>
    ''' Returns a List of IDataName objects representing the Data names of all of the unique layers 
    ''' defined by this MXD. Layers which occur multiple time in the MXD (either within the 
    ''' same map/data frame or within different maps/data frames) are filtered out and only 
    ''' occur once in the returned list.
    ''' </remarks>
    Public Overrides Function getLayerDataNamesList(ByRef dncl As IDataNameClauseLookup) As List(Of IDataName)
        Dim lstNames As New List(Of IDataName)

        For Each ds In getUniqueESRIDataSets()
            lstNames.Add(New DataNameESRIFeatureClass(ds, dncl, False))
        Next

        Return lstNames
    End Function


    ''' <summary>
    ''' A private convenience function, which filters out when a Dataset occurs
    ''' multiple times within an MXD.
    ''' </summary>
    ''' <returns>A duplicate-free list of datasets within the MXD</returns>
    ''' <remarks>
    ''' A private convenience function, which filters out when a Dataset occurs
    ''' multiple times within an MXD.
    ''' </remarks>
    Private Function getUniqueESRIDataSets() As List(Of IDataset)
        Dim lstStrUniqueNames As New List(Of String)
        Dim lyrCurrent As ILayer
        Dim strCurLyrName As String
        Dim lstDS As New List(Of IDataset)

        For Each map In getMaps()
            For i As Integer = 0 To (map.LayerCount - 1)
                lyrCurrent = map.Layer(i)

                If TypeOf lyrCurrent Is IDataset Then
                    Dim ds As IDataset
                    ds = DirectCast(lyrCurrent, IDataset)

                    'Get the full path name of the dataset (taken to be a unique identifier)
                    'and build a list of unique names.
                    If ds.Workspace.PathName.EndsWith(Path.DirectorySeparatorChar) Then
                        strCurLyrName = ds.Workspace.PathName & ds.Name
                    Else
                        strCurLyrName = ds.Workspace.PathName & Path.DirectorySeparatorChar & ds.Name
                    End If

                    If Not lstStrUniqueNames.Contains(strCurLyrName) Then
                        lstStrUniqueNames.Add(strCurLyrName)
                        lstDS.Add(ds)
                    End If
                End If
            Next
        Next

        Return lstDS
    End Function


    ''' <summary>
    ''' Returns a List of strings representing the names of all of the layers defined
    ''' by this MXD. Layers which occur multiple time in the MXD (either within the 
    ''' same map/data frame or within different maps/data frames) are filtered out and only 
    ''' occur once in the returned list.
    ''' </summary>
    ''' <returns>A duplicate-free of strings representing the names of all of the layers 
    ''' within the MXD.
    ''' </returns>
    ''' <remarks>
    ''' Returns a List of strings representing the names of all of the layers defined
    ''' by this MXD. Layers which occur multiple time in the MXD (either within the 
    ''' same map/data frame or within different maps/data frames) are filtered out and only 
    ''' occur once in the returned list.
    ''' </remarks>
    Public Overrides Function getLayerNamesStrings() As List(Of String)
        Dim lstStrReturn As New List(Of String)

        For Each ds In getUniqueESRIDataSets()
            lstStrReturn.Add(ds.BrowseName)
        Next

        Return lstStrReturn
    End Function
End Class
