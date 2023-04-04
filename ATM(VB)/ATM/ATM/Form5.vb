
Imports System.Data.SqlClient
Imports System.Data
Public Class Form5

    Dim inc As Integer
    Dim con As New OleDb.OleDbConnection
    Dim dbprovider, dbsource As String
    Dim ds, ds1 As New DataSet
    Dim da, da1 As New OleDb.OleDbDataAdapter
    Dim sql, sql1, srw As String
    Dim maxrows, mr, i, currentrow As Integer

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Public balance, current As Integer
    Dim dot As Date
    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dbprovider = "Provider=Microsoft.ACE.OLEDB.12.0;"

        dbsource = "Data Source=C:\Users\Public\Videos\atm.accdb"


        con.ConnectionString = dbprovider & dbsource
        con.Open()

        sql = "SELECT * FROM master"
        sql1 = "SELECT * FROM dailytrans"
        da = New OleDb.OleDbDataAdapter(sql, con)
        da1 = New OleDb.OleDbDataAdapter(sql1, con)
        da.Fill(ds, "atm")
        da1.Fill(ds1, "atm")
        maxrows = ds.Tables("atm").Rows.Count
        mr = ds1.Tables("atm").Rows.Count



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, currentrow As Integer
        i = 0
        While i <> maxrows + 1
            If Label2.Text = ds.Tables("atm").Rows(i)("acc_no") Then
                current = ds.Tables("atm").Rows(i)("amnt")
                balance = current - TextBox1.Text

                daily()

                Dim cb As New OleDb.OleDbCommandBuilder(da)
                ds.Tables("atm").Rows(i).Item("amnt") = balance
                da.Update(ds, "atm")
                MsgBox("amount withdrawed")

                Exit While
            ElseIf i = maxrows Then
                MsgBox("INVALID PIN number!!!")
                Exit While
            End If
            i += 1
        End While
        currentrow = i
    End Sub

    Public Sub daily()
        Dim cb1 As New OleDb.OleDbCommandBuilder(da1)

        Dim dsNewRow As DataRow

        dsNewRow = ds1.Tables("atm").NewRow()

        If Form4.RadioButton1.Checked = True Then
            srw = Form4.RadioButton1.Text
        Else
            srw = Form4.RadioButton2.Text
        End If

        dot = DateTime.Now
        dsNewRow.Item("dateoftrans") = dot
        dsNewRow.Item("acc_no") = Label6.Text
        dsNewRow.Item("transtype") = srw
        dsNewRow.Item("amtWD") = TextBox1.Text
        dsNewRow.Item("prevamt") = current
        dsNewRow.Item("curramt") = balance

        ds1.Tables("atm").Rows.Add(dsNewRow)

        da1.Update(ds1, "atm")
        MsgBox("daily transaction updated")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
        Form3.Show()
    End Sub
End Class