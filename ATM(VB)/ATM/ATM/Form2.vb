Imports System.Data.SqlClient
Imports System.Data
Public Class Form2
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows As Integer
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.ACE.OLEDB.12.0;"

        dbsource = "Data Source=C:\Users\Public\Videos\atm.accdb"

        con.ConnectionString = dbprovider & dbsource
        con.Open()
        sql = "SELECT * FROM pinno"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim SearchId, i, currentrow As Integer
        SearchId = TextBox1.Text
        i = 0
        While i <> maxrows + 1
            If SearchId = ds.Tables("atm").Rows(i)("pin") Then
                Me.Close()
                Form3.Label1.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form3.Show()
                Exit While
            ElseIf i = maxrows Then
                MsgBox("INVALID PIN number!!!")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        TextBox1.Text = ""
        TextBox1.Clear()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub btn1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn1.Click, btn9.Click, btn8.Click, btn7.Click, btn6.Click, btn5.Click, btn4.Click, btn3.Click, btn2.Click, btn0.Click
        TextBox1.Text = TextBox1.Text & sender.text
    End Sub
End Class