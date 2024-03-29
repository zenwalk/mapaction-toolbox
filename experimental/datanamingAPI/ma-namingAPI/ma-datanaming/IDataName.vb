﻿
Public Interface IDataName

    'Why can;t I put constants in an interface?!?
    'Const DATANAME_UNKNOWN_STATUS = 0
    'Const DATANAME_VALID = -1

    'Const DATANAME_ERROR = 2
    'Const DATANAME_WARN = 4

    'Const DATANAME_ERROR_TOO_FEW_CLAUSES = DATANAME_ERROR + (2 ^ 3)
    'Const DATANAME_ERROR_INVALID_GEOEXTENT = DATANAME_ERROR + (2 ^ 4)
    'Const DATANAME_ERROR_INVALID_DATACATEGORY = DATANAME_ERROR + (2 ^ 5)
    'Const DATANAME_ERROR_INVALID_DATATHEME = DATANAME_ERROR + (2 ^ 6)
    'Public Const DATANAME_ERROR_INVALID_DATATYPE = DATANAME_ERROR + (2 ^ 7)
    ''Const DATANAME_ERROR_INCORRECT_DATATYPE = DATANAME_ERROR + (2^8)
    ''Const DATANAME_ERROR_OTHER_ERROR = DATANAME_ERROR + (2^9)

    'Const DATANAME_WARN_MISSING_SCALE_CLAUSE = DATANAME_WARN + (2 ^ 10)
    'Const DATANAME_WARN_MISSING_PERMISSIONS_CLAUSE = DATANAME_WARN + (2 ^ 11)
    'Const DATANAME_WARN_CONTAINS_HYPHENS = DATANAME_WARN + (2 ^ 12)
    ''Const DATANAME_WARN


    ''' <summary>
    ''' Returns the current Data Name as a String. No path is included
    ''' </summary>
    ''' <returns>a string of the current Data Name</returns>
    ''' <remarks>
    ''' Returns the current Data Name as a String
    ''' </remarks>
    Function getNameStr() As String

    ''' <summary>
    ''' Returns the path of the current Data Name as a String, if a suitable meaning of path is applicable. If
    ''' there is no easy or meaningful sense of a path (eg for a RDBMS) then a null or zero length string is 
    ''' returned
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function getPathStr() As String


    ''' <summary>
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks>
    ''' Returns getPathStr() + "\" + getNameStr()
    ''' </remarks>
    Function getNameAndFullPathStr() As String

    
    ''' <summary>
    ''' This method does the core processing to determine whether or not the particular name represented by 
    ''' this class is valid or not. 
    ''' 
    ''' </summary>
    ''' <returns>An integer based on the various contants defined in AbstractDataName class</returns>
    ''' <remarks>
    ''' This method does the core processing to determine whether or not the particular name represented by 
    ''' this class is valid or not. 
    ''' 
    ''' If the name is not valid, it will attempt to estimate what the mistake is. These are classified as either
    ''' "Errors" or "Warnings"
    ''' Error = The name cannot be understood
    ''' Warning = The name can be understood, but there is a risk that it will be misinterprited
    ''' </remarks>
    Function checkNameStatus() As Long

    Function isNameParseable() As Boolean
    Function isNameValid() As Boolean

    ''' <summary>
    ''' Does this name include the optional "Scale" clause in it?
    ''' </summary>
    ''' <returns>
    ''' TRUE = The optional scale clause is present
    ''' FALSE = The optional scale clause is not present
    ''' </returns>
    ''' <remarks>Does this name include the optional "Scale" clause in it?</remarks>
    Function hasOptionalScaleClause() As Boolean

    ''' <summary>
    ''' Does this name include the optional "Data Permissions" clause in it?
    ''' </summary>
    ''' <returns>
    ''' TRUE = The optional Data Permissions clause is present
    ''' FALSE = The optional Data Permissions clause is not present
    ''' </returns>
    ''' <remarks>Does this name include the optional "Data Permissions" clause in it?</remarks>
    Function hasOptionalPermissionClause() As Boolean

    ''' <summary>
    ''' Does this name include the optional "Free Text" clause?
    ''' </summary>
    ''' <returns>
    ''' TRUE = The optional Free Text clause is present
    ''' FALSE = The optional Free Text clause is not present
    ''' </returns>
    ''' <remarks>Does this name include the optional "Data Permissions" clause in it?</remarks>
    Function hasOptionalFreeText() As Boolean

    ''' <summary>
    ''' Is it possible for the Name of this data layer to be changed? For example this made be no 
    ''' if the underlying file system is readony, or the data resides on a webservice such as
    ''' WMS/WFS 
    ''' </summary>
    ''' <returns>
    ''' TRUE = the name of the data layer can be changed.
    ''' FALSE = the name of the data layer cannot be changed.
    ''' </returns>
    ''' <remarks></remarks>
    Function isRenameable() As Boolean

    Function changeGeoExtentClause(ByVal newGeoExtent As String) As Integer

    Function changeDataCategoryClause(ByVal newDataCategory As String) As Integer

    Function changeDataThemeClause(ByVal newDataTheme As String) As Integer

    Function changeDataTypeClause(ByVal newDataTheme As String) As Integer

    Function changePermissionsClause(ByVal newDataTheme As String) As Integer

    Function changeScaleCodesClause(ByVal newDataTheme As String) As Integer

    Function changeSourceCodesClause(ByVal newDataTheme As String) As Integer

    Function changeFreeTextClause(ByVal newDataTheme As String) As Integer

End Interface
