﻿Imports System.Data.SqlClient
Imports System.Data
Public Class Form9
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer
    Public balance, current As Integer
    Private Sub Form9_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.ACE.OLEDB.12.0;"

        dbsource = "Data Source=C:\Users\Public\Videos\atm.accdb"


        con.ConnectionString = dbprovider & dbsource
        con.Open()
        sql = "SELECT * FROM master"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, currentrow As Integer
        i = 0
        While i <> maxrows + 1
            If Label2.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                current = ds.Tables("atm").Rows(i)("amnt")
                balance = current - TextBox2.Text
                Dim cb As New OleDb.OleDbCommandBuilder(da)
                ds.Tables("atm").Rows(i).Item("amnt") = balance
                da.Update(ds, "atm")
                MsgBox("Data updated")

                Exit While
            ElseIf i = maxrows Then
                MsgBox("INVALID PIN number!!!")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Form3.Show()
    End Sub
End Class