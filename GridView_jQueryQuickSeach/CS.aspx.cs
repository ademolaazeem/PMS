﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                            new DataColumn("Name", typeof(string)),
                            new DataColumn("Country",typeof(string)) });
            dt.Rows.Add(1, "John Hammond", "United States");
            dt.Rows.Add(2, "Mudassar Khan", "India");
            dt.Rows.Add(3, "Suzanne Mathews", "France");
            dt.Rows.Add(4, "Robert Schidner", "Russia");
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }

    protected void OnDataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        for (int i = 0; i < GridView1.Columns.Count; i++)
        {
            TableHeaderCell cell = new TableHeaderCell();
            TextBox txtSearch = new TextBox();
            txtSearch.Attributes["placeholder"] = GridView1.Columns[i].HeaderText;
            txtSearch.CssClass = "search_textbox";
            cell.Controls.Add(txtSearch);
            row.Controls.Add(cell);
        }
        GridView1.HeaderRow.Parent.Controls.AddAt(1, row);
    }

}