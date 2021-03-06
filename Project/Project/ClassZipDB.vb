﻿
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient

Public Class ClassZipDB
    'Purpose: connect to tblEmployee and create dataset 
    'Arguments: tblEMployee fields
    'Returns: Dataset containing information from tblEMployee
    'Author: Aida Mojica
    'Date: 17 March 2015

    ' these module variables are internal to object
    Dim mDatasetZip As New DataSet
    Dim mstrQuery As String
    Dim mdbDataAdapter As New SqlDataAdapter
    Dim mdbConn As SqlConnection
    Dim mMyView As New DataView
    Dim mstrConnection As String = "workstation id=COMPUTER;packet size=4096;data source=missql.mccombs.utexas.edu;integrated security=False;initial catalog=MIS333K_20152_Team14;user id=msbcn211;password=Aida90210"

    ' define a public read only property for the outside world to access the dataset filled by this class
    Public ReadOnly Property ZipDataset() As DataSet
        Get
            ' return dataset to user
            Return mDatasetZip
        End Get
    End Property

    Public ReadOnly Property MyView() As DataView
        Get
            'return dataview to user 
            Return mMyView
        End Get
    End Property




    Public Sub RunProcedure(ByVal strName As String)
        'Purpose: run any select query 
        'Arguments: strQuery 
        'Returns: filled dataset
        'Author: Aida Mojica
        'Date: 17 March  2015

        ' CREATES INSTANCES OF THE CONNECTION AND COMMAND OBJECT
        Dim objConnection As New SqlConnection(mstrConnection)
        ' Tell SQL server the name of the stored procedure you will be executing
        Dim mdbDataAdapter As New SqlDataAdapter(strName, objConnection)
        Try
            ' SETS THE COMMAND TYPE TO "STORED PROCEDURE"
            mdbDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
            ' clear dataset
            Me.mDatasetZip.Clear()
            ' OPEN CONNECTION AND FILL DATASET
            mdbDataAdapter.Fill(mDatasetZip, "tblZip")
            ' copy dataset to dataview
            mMyView.Table = mDatasetZip.Tables("tblZip")
        Catch ex As Exception
            Throw New Exception("stored procedure is " & strName.ToString & " error is " & ex.Message)
        End Try
    End Sub



    Public Sub GetAllZip()
        'Purpose: get all employees from tblEmployee
        'Arguments: N/A
        'Returns: all employees
        'Author: Aida Mojica
        'Date: 17 March 2015

        RunProcedure("usp_zip_get_all")
    End Sub

<<<<<<< HEAD
    Public Sub SearchByZip(strIn As Integer) 'changed from string to int
=======
    Public Sub SearchByZip(strIn As String)
>>>>>>> d81be794ee9d8a9a47f178f1ac6dad353610c831
        'Purpose: filter by empID in dataview 
        'Arguments: strIn
        'Returns: sorted dataview by EmpID
        'Author: Aida Mojica
        'Date: 17 March 2015

<<<<<<< HEAD
        mMyView.RowFilter = "ZipCode = '" & strIn & "'"
=======
        mMyView.RowFilter = "ZipCode ='" & strIn & "'"
>>>>>>> d81be794ee9d8a9a47f178f1ac6dad353610c831
    End Sub
End Class
