using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Account_forms_AuditTrail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ////////////////////////////////////Date/////////////////////////////////////////////
        DDLFromYear.Items.Insert(0, new ListItem("Year", ""));
        for (int i = 2013; i <= 2030; i++)
        {
           DDLFromYear.Items.Add(i.ToString());
        }
        //DDLFromYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected
        DDLFromMonth.Items.Insert(0, new ListItem("Month", ""));
        for (int i = 1; i <= 12; i++)
        {
            DDLFromMonth.Items.Add(i.ToString());
         }
       // DDLFromMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
        DDLFromDay.Items.Insert(0, new ListItem("Day", ""));
        for (int i = 1; i <= 31; i++)
        {
            DDLFromDay.Items.Add(i.ToString());
        }
        
        
        // FillFromDays();
        DDLToYear.Items.Insert(0, new ListItem("Year", ""));
        for (int i = 2013; i <= 2030; i++)
        {
            DDLToYear.Items.Add(i.ToString());
        }
        //DDLToYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected
        DDLToMonth.Items.Insert(0, new ListItem("Month", ""));
        for (int i = 1; i <= 12; i++)
        {
            DDLToMonth.Items.Add(i.ToString());
        }
        //DDLToMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
        DDLToDay.Items.Insert(0, new ListItem("Day", ""));
        for (int i = 1; i <= 31; i++)
        {
            DDLToDay.Items.Add(i.ToString());
        }
        
        //FillToDays();

        ////////////////////////////////End Date/////////////////////////////////////////////

        refreshDropDowns();

    }

    private void refreshDropDowns()
    {

        DDLUsername.DataSource = crudsbLL.getUsernameDropDown();
        DDLUsername.DataTextField = "USERNAME";
        DDLUsername.DataValueField = "USERNAME";
        DDLUsername.DataBind();
        DDLUsername.Items.Insert(0, new ListItem("Select Username", ""));


        DataTable table = crudsbLL.getAuditTrail();
        if (table.Rows.Count <= 0)
        {
            table.Rows.Add(table.NewRow());
            GrdAuditTrail.DataSource = table;
            GrdAuditTrail.DataBind();
            int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
            GrdAuditTrail.Rows[0].Cells.Clear();
            GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
            GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
            GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
        }
        else
        {
            //DataTable table = crudsbLL.getAuditTrail();
            GrdAuditTrail.DataSource = table;
            GrdAuditTrail.DataBind();
        }


       

    }//end refreshDropDowns

    public void FillFromDays()
    {
        if (IsPostBack)
        {
            DDLFromDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLFromDay.SelectedValue), Convert.ToInt32(DDLFromDay.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                DDLFromDay.Items.Add(i.ToString());
            }
            DDLFromDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected

        }//end postback
    }

    public void FillToDays()
    {
        if (IsPostBack)
        {
            DDLToDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLToDay.SelectedValue), Convert.ToInt32(DDLToDay.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                DDLToDay.Items.Add(i.ToString());
            }
            DDLToDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected

        }//end postback
    }

    protected void btnSearchAudit_Click(object sender, EventArgs e)
    {
        //holderDate = holderDay + "/" + holderMonth + "/" + holderYear;
        string fromDate;
        string toDate;
        string uName = DDLUsername.SelectedValue;
        string andOr0 = DDLAndOr0.SelectedValue;
        string ops = DDLOperation.SelectedValue;
        string andOr1 = DDLAndOr1.SelectedValue;

        
        string fromYear = DDLFromYear.SelectedValue;
        string fromMonth = DDLFromMonth.SelectedValue;
        string fromDay = DDLFromDay.SelectedValue;

        string toYear = DDLToYear.SelectedValue;
        string toMonth = DDLToMonth.SelectedValue;
        string toDay = DDLToDay.SelectedValue;

        //if (string.IsNullOrEmpty(uName) && string.IsNullOrEmpty(ops) && string.IsNullOrEmpty(fromYear) && string.IsNullOrEmpty(fromMonth) &&
        //    string.IsNullOrEmpty(fromDay) && string.IsNullOrEmpty(toYear) && string.IsNullOrEmpty(toMonth) && string.IsNullOrEmpty(toDay)
        //    )
        if(DDLUsername.SelectedIndex <= 0 && DDLOperation.SelectedIndex <= 0 && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && 
            DDLFromDay.SelectedIndex <= 0 && DDLToYear.SelectedIndex <= 0  && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        {

            lblStatus.Text = "All cannot be blank!, specify your criteria";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        
        }
        //else if (DDLUsername.SelectedIndex > 0 && string.IsNullOrEmpty(ops) && string.IsNullOrEmpty(fromYear) && string.IsNullOrEmpty(fromMonth) &&
        //    string.IsNullOrEmpty(fromDay) && string.IsNullOrEmpty(toYear) && string.IsNullOrEmpty(toMonth) && string.IsNullOrEmpty(toDay))
        
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex <= 0 && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && 
            DDLFromDay.SelectedIndex <= 0 && DDLToYear.SelectedIndex <= 0  && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        
        {

            DataTable table = crudsbLL.getAuditTrail(uName);
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            
            
            //DataTable table = crudsbLL.getAuditTrail(uName);
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        
        }//username alone specified
        //else if (string.IsNullOrEmpty(uName) && DDLOperation.SelectedIndex > 0 && string.IsNullOrEmpty(fromYear) && string.IsNullOrEmpty(fromMonth) &&
        //    string.IsNullOrEmpty(fromDay) && string.IsNullOrEmpty(toYear) && string.IsNullOrEmpty(toMonth) && string.IsNullOrEmpty(toDay))
        else if (DDLUsername.SelectedIndex <= 0 && DDLOperation.SelectedIndex > 0 && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && 
            DDLFromDay.SelectedIndex <= 0 && DDLToYear.SelectedIndex <= 0  && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
            {
                DataTable table = crudsbLL.getAuditTrailOps(ops);
                if (table.Rows.Count <= 0)
                {
                    table.Rows.Add(table.NewRow());
                    GrdAuditTrail.DataSource = table;
                    GrdAuditTrail.DataBind();
                    int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                    GrdAuditTrail.Rows[0].Cells.Clear();
                    GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                    GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                    GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
                }
                else
                {
                    //DataTable table = crudsbLL.getAuditTrail();
                    GrdAuditTrail.DataSource = table;
                    GrdAuditTrail.DataBind();
                }
            
            
            //DataTable table = crudsbLL.getAuditTrailOps(ops);
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//operation alone specified

        //else if (string.IsNullOrEmpty(uName) && string.IsNullOrEmpty(ops) && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 &&
        //   DDLFromDay.SelectedIndex > 0 && string.IsNullOrEmpty(toYear) && string.IsNullOrEmpty(toMonth) && string.IsNullOrEmpty(toDay))
        else if (DDLUsername.SelectedIndex <= 0 && DDLOperation.SelectedIndex <= 0 && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && 
            DDLFromDay.SelectedIndex > 0 && DDLToYear.SelectedIndex <= 0  && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
            {

            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;


            DataTable table = crudsbLL.getAuditTrailFromDate(fromDate);
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            
            
            //DataTable table = crudsbLL.getAuditTrailFromDate(fromDate);
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//fromdate alone specified
        //else if (string.IsNullOrEmpty(uName) && string.IsNullOrEmpty(ops) && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 &&
        //  DDLToDay.SelectedIndex > 0 && string.IsNullOrEmpty(fromYear) && string.IsNullOrEmpty(fromMonth) && string.IsNullOrEmpty(fromDay))
        //
        else if (DDLUsername.SelectedIndex <= 0 && DDLOperation.SelectedIndex <= 0 && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 &&
            DDLFromDay.SelectedIndex <= 0 && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0)
        {

            toDate = toDay + "/" + toMonth + "/" + toYear;

            DataTable table = crudsbLL.getAuditTrailFromDate(toDate);
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            
            
            
            //DataTable table = crudsbLL.getAuditTrailFromDate(toDate);
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//todate alone specified
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue=="AND"
            && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 &&
            DDLFromDay.SelectedIndex <= 0 && DDLToYear.SelectedIndex <= 0 && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        {

            DataTable table = crudsbLL.getAuditTrail(uName, ops, "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }

            //DataTable table = crudsbLL.getAuditTrail(uName, ops, "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//BOTH USERNAME AND OPERATION SPECIFIED WITH AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
            && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 &&
            DDLFromDay.SelectedIndex <= 0 && DDLToYear.SelectedIndex <= 0 && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        {

            DataTable table = crudsbLL.getAuditTrail(uName, ops, "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }

            //DataTable table = crudsbLL.getAuditTrail(uName, ops, "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//BOTH USERNAME AND OPERATION SPECIFIED WITH OR

        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "AND"
            && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "AND"
            && DDLToYear.SelectedIndex <= 0 && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <=0)
        {

            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "AND", "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "AND", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND FROMDATE WITH AND AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "AND"
        && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "OR"
        && DDLToYear.SelectedIndex <= 0 && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        {

            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "AND", "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "AND", "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND FROMDATE WITH AND OR
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
           && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "AND"
           && DDLToYear.SelectedIndex <= 0 && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        {

            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "OR", "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "OR", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND FROMDATE WITH OR AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
       && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "OR"
       && DDLToYear.SelectedIndex <= 0 && DDLToMonth.SelectedIndex <= 0 && DDLToDay.SelectedIndex <= 0)
        {

            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "OR", "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, "OR", "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND FROMDATE WITH OR OR




        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "AND"
       && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "AND"
       && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && DDLFromDay.SelectedIndex <= 0)
        {
            toDate = toDay + "/" + toMonth + "/" + toYear;

            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "AND", "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "AND", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH AND AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "AND"
       && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "OR"
       && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && DDLFromDay.SelectedIndex <= 0)
        {

            toDate = toDay + "/" + toMonth + "/" + toYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "AND", "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "AND", "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH AND OR
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
       && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "AND"
       && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && DDLFromDay.SelectedIndex <= 0)
        {

            toDate = toDay + "/" + toMonth + "/" + toYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH OR AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
       && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "OR"
       && DDLFromYear.SelectedIndex <= 0 && DDLFromMonth.SelectedIndex <= 0 && DDLFromDay.SelectedIndex <= 0)
        {

            toDate = toDay + "/" + toMonth + "/" + toYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH OR OR
        





        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "AND"
   && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "AND"
   && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0)
        {
            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            toDate = toDay + "/" + toMonth + "/" + toYear;

            DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, toDate, "AND", "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, toDate, "AND", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH AND AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "AND"
   && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "OR"
   && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0)
        {
            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            toDate = toDay + "/" + toMonth + "/" + toYear;

            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "AND", "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "AND", "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH AND OR
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
   && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "AND"
   && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0)
        {
            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            toDate = toDay + "/" + toMonth + "/" + toYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "AND");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH OR AND
        else if (DDLUsername.SelectedIndex > 0 && DDLOperation.SelectedIndex > 0 && DDLAndOr0.SelectedValue == "OR"
   && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 && DDLAndOr1.SelectedValue == "OR"
   && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0)
        {
            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            toDate = toDay + "/" + toMonth + "/" + toYear;
            DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "OR");
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, toDate, "OR", "OR");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH OR OR
        else if (DDLUsername.SelectedIndex <= 0 && DDLOperation.SelectedIndex <= 0 
          && DDLFromYear.SelectedIndex > 0 && DDLFromMonth.SelectedIndex > 0 && DDLFromDay.SelectedIndex > 0 
          && DDLToYear.SelectedIndex > 0 && DDLToMonth.SelectedIndex > 0 && DDLToDay.SelectedIndex > 0)
        {
            fromDate = fromDay + "/" + fromMonth + "/" + fromYear;
            toDate = toDay + "/" + toMonth + "/" + toYear;

            DataTable table = crudsbLL.getAuditTrail(fromDate, toDate);
            if (table.Rows.Count <= 0)
            {
                table.Rows.Add(table.NewRow());
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
                int totalcolums = GrdAuditTrail.Rows[0].Cells.Count;
                GrdAuditTrail.Rows[0].Cells.Clear();
                GrdAuditTrail.Rows[0].Cells.Add(new TableCell());
                GrdAuditTrail.Rows[0].Cells[0].ColumnSpan = totalcolums;
                GrdAuditTrail.Rows[0].Cells[0].Text = "No Data found for this Search, Search another!";
            }
            else
            {
                //DataTable table = crudsbLL.getAuditTrail();
                GrdAuditTrail.DataSource = table;
                GrdAuditTrail.DataBind();
            }
            //DataTable table = crudsbLL.getAuditTrail(uName, ops, fromDate, toDate, "AND", "AND");
            //GrdAuditTrail.DataSource = table;
            //GrdAuditTrail.DataBind();

        }//USERNAME, OPERATION, AND TODATE WITH AND AND
        else
        {
            lblStatus.Text = "Please specify appropriate criteria to search!";
            lblStatus.ForeColor = System.Drawing.Color.Red;

        }





       


    }



    protected void GrdAuditTrail_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdAuditTrail.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdAuditTrail.DataSource = dataView;
            GrdAuditTrail.DataBind();
        }

    }//end _Sorting
    protected void GrdAuditTrail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdAuditTrail.PageIndex = e.NewPageIndex;
        GrdAuditTrail.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewLeadership_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    private string ConvertSortDirectionToSql(SortDirection sortDirection)
    {
        string newSortDirection = String.Empty;

        switch (sortDirection)
        {
            case SortDirection.Ascending:
                newSortDirection = "ASC";
                break;

            case SortDirection.Descending:
                newSortDirection = "DESC";
                break;
        }

        return newSortDirection;
    }
}