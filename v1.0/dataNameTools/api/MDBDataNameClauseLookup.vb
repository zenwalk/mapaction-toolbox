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

Imports System.Data
Imports System.Data.Common
Imports System.Data.OleDb
Imports System.Data.Odbc
Imports System.IO
Imports ADODB

''' <summary>
''' Provides a specfic implenmentation of the IDataNameClauseLookup, based on storing the
''' Data Name Clause Lookup Tables in an Access Database file.
''' </summary>
''' <remarks>
''' Provides a specfic implenmentation of the IDataNameClauseLookup, based on storing the
''' Data Name Clause Lookup Tables in an Access Database file.
'''
''' There is no public constructor for this class. New instances should be generated using 
''' the DataNameClauseLookupFactory factory class.
''' </remarks>
Public Class MDBDataNameClauseLookup
    Inherits AbstractDataNameClauseLookup

    Private m_DBConnection As DbConnection = Nothing
    Private m_fInfoPath As FileInfo
    Private m_blnIsFallBack As Boolean

    ''' <summary>
    ''' The constuctor. This should only be called from within the relevant 
    ''' factory class.
    ''' </summary>
    ''' <param name="strFullName">A string of the full path to the Access MDB file</param>
    ''' <remarks>
    ''' The constuctor. This should only be call from within the relevant 
    ''' factory class.
    ''' </remarks>
    Protected Friend Sub New(ByVal strFullName As String, ByVal lngReadWriteMode As Long)
        Me.New(strFullName, lngReadWriteMode, False)
    End Sub

    Protected Friend Sub New(ByVal strFullName As String, ByVal lngReadWriteMode As Long, ByVal blnIsFallBack As Boolean)
        Dim fInfoArg As FileInfo

        If strFullName Is Nothing Then
            Throw New ArgumentException("Invalid path passed to New MDBDataNameClauseLookup(args)")
        Else
            fInfoArg = New FileInfo(strFullName)
            m_fInfoPath = fInfoArg
            m_lngReadWriteMode = lngReadWriteMode
            m_blnIsFallBack = blnIsFallBack
            'System.Console.WriteLine("args(0)= " & args(0))
            'initialiseConnectionObject(fInfoArg)
            initialiseAllTables()
        End If
    End Sub


    ''' <summary>
    ''' The constuctor. This should only be call from within the relevant 
    ''' factory class.
    ''' </summary>
    ''' <param name="fileInfoArg">A FileInfo object pointing to the full 
    ''' path to the Access MDB file</param>
    ''' <remarks>
    ''' The constuctor. This should only be call from within the relevant 
    ''' factory class.
    ''' </remarks>
    Protected Friend Sub New(ByRef fileInfoArg As FileInfo, ByVal lngReadWriteMode As Long)
        m_fInfoPath = fileInfoArg
        m_lngReadWriteMode = lngReadWriteMode
        'initialiseConnectionObject(fileInfoArg)
        initialiseAllTables()
    End Sub


    '''' <summary>
    '''' Sets up the m_DBConnection object. Only called from within the constructor
    '''' </summary>
    '''' <param name="fInfoPathToMDB">A string of the full path to the Access MDB file</param>
    '''' <remarks>
    '''' Sets up the m_DBConnection object. Only called from within the constructor
    '''' </remarks>
    'Private Sub initialiseConnectionObject(ByRef fInfoPathToMDB As FileInfo)

    '    Dim strPrefixCon As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source="

    '    If Not fInfoPathToMDB.Exists Then
    '        Throw New ArgumentException("Invalid path passed to New MDBDataNameClauseLookup(fileInfoArg)")

    '        m_DBConnection = New OleDbConnection(strPrefixCon & fInfoPathToMDB.FullName)
    '        m_DBConnection.Open()

    '        m_fInfoPath = fInfoPathToMDB
    '    End If
    'End Sub


    Protected Friend Overrides Function getDBDataAdapter() As System.Data.Common.DbDataAdapter
        Dim daResult As DbDataAdapter
        Dim strConnectPattern As String
        Dim oleCommand As OleDbCommand = New OleDbCommand
        Dim odbcCommand As OdbcCommand = New OdbcCommand
        Dim odbcConnection As OdbcConnection = Nothing
        Dim oleDBConnection As OleDbConnection = Nothing

        If Not m_fInfoPath.Exists() Then
            MsgBox(m_fInfoPath.FullName)
            Throw New ArgumentException("Invalid path passed to New MDBDataNameClauseLookup(fileInfoArg)")
        Else
            'strConnectPattern = System.Configuration.ConfigurationManager.AppSettings.Item(APP_CONF_MDB_OLE_CONNECT_STRING)
            If m_blnIsFallBack Then
                strConnectPattern = String.Format(FALLBACK_MDB_OLE_CONNECT_STRING, m_fInfoPath.FullName)
                'strConnectPattern = FALLBACK_MDB_OLE_CONNECT_STRING
                If (m_DBConnection Is Nothing) Or (Not (TypeOf m_DBConnection Is OdbcConnection)) Then
                    odbcConnection = New Odbc.OdbcConnection(strConnectPattern)
                    odbcConnection.Open()
                    m_DBConnection = odbcConnection
                Else
                    odbcConnection = TryCast(m_DBConnection, OdbcConnection)
                End If

                odbcCommand.Connection = odbcConnection
                daResult = New Odbc.OdbcDataAdapter(odbcCommand)
            Else
                strConnectPattern = String.Format(MDB_OLE_CONNECT_STRING, m_lngReadWriteMode, m_fInfoPath.FullName)

                If (m_DBConnection Is Nothing) Or (Not (TypeOf m_DBConnection Is OleDbConnection)) Then
                    oleDBConnection = New OleDbConnection(strConnectPattern)
                    oleDBConnection.Open()
                    m_DBConnection = oleDBConnection
                Else
                    oleDBConnection = TryCast(m_DBConnection, OleDbConnection)
                End If

                oleCommand.Connection = oleDBConnection
                daResult = New OleDbDataAdapter(oleCommand)
            End If
        End If

        Return daResult
    End Function

    '''' <summary>
    '''' This method opens the individual named flat table from as a DataTable object from the 
    '''' Access DB.
    '''' </summary>
    '''' <param name="strTableName">The name of the table to open. This should normally be passed
    '''' using one of the API constants with the prefix "TABLENAME_"</param>
    '''' <returns>A DataTable object representing the named table</returns>
    '''' <remarks>
    '''' This method opens the individual named flat table from as a DataTable object from the 
    '''' Access DB.
    '''' </remarks>
    'Protected Overrides Function openTable(ByVal strTableName As String) As System.Data.DataTable
    '    Dim strQuery As String
    '    Dim dbCommand As IDbCommand = New OleDbCommand
    '    'Dim da As IDbDataAdapter = New OleDbDataAdapter
    '    Dim dtb As DataTable

    '    strQuery = "SELECT * FROM " & strTableName

    '    dbCommand.CommandText = strQuery
    '    dbCommand.Connection = m_DBConnection

    '    dtb = getTableFromReader(dbCommand.ExecuteReader())

    '    Return dtb

    'End Function


    ''' <summary>
    ''' Returns the ConnectionString used to connect to the Acess DB.
    ''' </summary>
    ''' <returns>the ConnectionString used to connect to the Acess DB.</returns>
    ''' <remarks>
    ''' Returns the ConnectionString used to connect to the Acess DB.
    ''' </remarks>
    Public Overrides Function getDetails() As String
        Return m_DBConnection.ConnectionString
    End Function


    ''' <summary>
    ''' Returns the operating system file path to the Access DataBase.
    ''' </summary>
    ''' <returns>A FileInfo object representing the operating system file path to the  
    ''' Access DataBase.</returns>
    ''' <remarks>
    ''' Returns the operating system file path to the Access DataBase.
    ''' </remarks>
    Public Overrides Function getPath() As System.IO.FileInfo
        Return m_fInfoPath
    End Function


    ''' <summary>
    ''' A convenence function to produce a new disconnected rewindable datatable
    ''' object based data read from the dataReader object.
    ''' </summary>
    ''' <param name="sqldr">A readonly, read-foward DataReader object</param>
    ''' <returns>A new DataTable object</returns>
    ''' <remarks>
    ''' A convenence function to produce a new disconnected rewindable datatable
    ''' object based data read from the dataReader object.
    ''' </remarks>
    Private Function getTableFromReader(ByVal sqldr As IDataReader) As DataTable

        Dim i As Int32
        Dim dtSchema As DataTable = sqldr.GetSchemaTable()
        Dim dtNew As DataTable = New System.Data.DataTable
        Dim dc As DataColumn
        'Dim _row As DataRow

        'set the schema of the new datatable to match the Data reader
        For i = 0 To dtNew.Rows.Count - 1
            dc = New DataColumn
            dc.ColumnName = dtSchema.Rows(i)("ColumnName").ToString()
            dc.DataType = CType(dtSchema.Rows(i)("DataType"), System.Type)
            dc.Unique = Convert.ToBoolean(dtSchema.Rows(i)("IsUnique"))
            dc.AllowDBNull = Convert.ToBoolean(dtSchema.Rows(i)("AllowDBNull"))
            dc.ReadOnly = Convert.ToBoolean(dtSchema.Rows(i)("IsReadOnly"))
            dtNew.Columns.Add(dc)
        Next

        'now copy across the contents
        While sqldr.Read()
            Dim dr As DataRow = dtNew.NewRow()
            For i = 0 To sqldr.FieldCount - 1
                dr(i) = sqldr.GetValue(i)
            Next
            dtNew.Rows.Add(dr)
        End While

        Return dtNew

    End Function

End Class
