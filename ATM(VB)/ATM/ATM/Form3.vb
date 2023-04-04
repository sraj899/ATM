Imports System.Data.SqlClient
Imports System.Data
Public Class Form3
    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds As New DataSet
    Dim da As New OleDb.OleDbDataAdapter
    Dim sql As String
    Dim maxrows, i, currentrow As Integer
    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dbprovider = "Provider=Microsoft.ACE.OLEDB.12.0;"

        dbsource = "Data Source=C:\Users\Public\Videos\atm.accdb"


        con.ConnectionString = dbprovider & dbsource
        con.Open()
        sql = "SELECT * FROM master"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da.Fill(ds, "atm")
        maxrows = ds.Tables("atm").Rows.Count
        i = 0


        While i <> maxrows + 1
            If Label1.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                Label4.Text = ds.Tables("atm").Rows(i)("cust_name")

                Form4.Label1.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form4.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form6.Label1.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form6.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")
                Form9.Label1.Text = ds.Tables("atm").Rows(i)("cust_name")
                Form9.Label2.Text = ds.Tables("atm").Rows(i)("acc_no")
                ' Form10.Label8.Text = ds.Tables("atm").Rows(i)("cust_name")
                ' Form10.Label6.Text = ds.Tables("atm").Rows(i)("acc_no")
                ' Form10.TextBox1.Text = ds.Tables("atm").Rows(i)("pin")
                'Form11.Label3.Text = ds.Tables("atm").Rows(i)("cust_name")
                ' Form11.Label6.Text = ds.Tables("atm").Rows(i)("acc_no")
                Exit While
            ElseIf i = maxrows Then
                MsgBox("ADMIN USER")
                Exit While
            End If
            i += 1
        End While
        currentrow = i

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form4.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Form6.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Form7.Show()
    End Sub
End Class