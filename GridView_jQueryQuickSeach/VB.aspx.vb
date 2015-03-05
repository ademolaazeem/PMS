Imports System.Data

Partial Class VB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Not Me.IsPostBack Then
            Dim dt As New DataTable()
            dt.Columns.AddRange(New DataColumn(2) {New DataColumn("Id", GetType(Integer)), New DataColumn("Name", GetType(String)), New DataColumn("Country", GetType(String))})
            dt.Rows.Add(1, "John Hammond", "United States")
            dt.Rows.Add(2, "Mudassar Khan", "India")
            dt.Rows.Add(3, "Suzanne Mathews", "France")
            dt.Rows.Add(4, "Robert Schidner", "Russia")
            GridView1.DataSource = dt
            GridView1.DataBind()
        End If
    End Sub

    Protected Sub OnDataBound(sender As Object, e As EventArgs)
        Dim row As New GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal)
        For i As Integer = 0 To GridView1.Columns.Count - 1
            Dim cell As New TableHeaderCell()
            Dim txtSearch As New TextBox()
            txtSearch.Attributes("placeholder") = GridView1.Columns(i).HeaderText
            txtSearch.CssClass = "search_textbox"
            cell.Controls.Add(txtSearch)
            row.Controls.Add(cell)
        Next
        GridView1.HeaderRow.Parent.Controls.AddAt(1, row)
    End Sub
End Class
