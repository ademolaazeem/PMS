using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Collections.Specialized;
using System.Text;

public partial class Account_forms_ViewPResultApplicationForm : System.Web.UI.UserControl
{
    decimal grdTotal = 0;
    decimal grdTotalIPS = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
         String username = Session["usr"].ToString();
        //////////////////////////////////Pretest/////////////////////////////////////////////
         string countSubordinate = crudsbLL.getPositionsCount(username);
         if (countSubordinate == "1")
         {
             //////////////////////////////////Get Subordinate/////////////////////////////////////
             DDLSubName.DataSource = crudsbLL.getSubordinateNameDropDown(username);
             DDLSubName.DataTextField = "NAME";
             DDLSubName.DataValueField = "USERNAME";
             DDLSubName.DataBind();
             DDLSubName.Items.Insert(0, new ListItem("Select Subordinate", ""));
             //////////////////////////////////End Get Subordinate/////////////////////////////////
             btnShowSubPRGoalSettings.Text = "Show Subordinate PR Goal Settings";
             DDLSubName.Visible = true;
             LblSubName.Visible = true;
             chkMyDetails.Visible = true;

         }
         else if (countSubordinate == "0")
         {
             lblStatusSub.Text = "You do not have Subordinate(s), Please Continue";
             btnShowSubPRGoalSettings.Text = "Show your PR Goal Settings";
             lblStatusSub.ForeColor = System.Drawing.Color.Red;
             DDLSubName.Visible = false;
             LblSubName.Visible = false;
             chkMyDetails.Visible = false;


         }

        
             PnlSub.Visible = true;
             PnlMain.Visible = false;
        
        //Fill Years
        for (int i = 2013; i <= 2020; i++)
        {
            ddlYearSub.Items.Add(i.ToString());
        }
        ddlYearSub.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {

            
                ddlMonthSub.Items.Add(i.ToString());
           
            
        }
        ddlMonthSub.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
        //}
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Goal Settings: User " + username + " successfully views actual Performance result page for Goal Settings Interface", "View");


        GrdViewKPI.Columns[4].Visible = false;
        GrdViewBrand.Columns[1].Visible = false;
        GrdViewFinancial.Columns[1].Visible = false;
        GrdViewProcessEfficiency.Columns[1].Visible = false;
        GrdViewPeople.Columns[1].Visible = false;
        GrdViewCustomer.Columns[1].Visible = false;

        GrdViewBrand.Columns[0].Visible = false;
        GrdViewFinancial.Columns[0].Visible = false;
        GrdViewProcessEfficiency.Columns[0].Visible = false;
        GrdViewPeople.Columns[0].Visible = false;
        GrdViewCustomer.Columns[0].Visible = false;



        


    }//_Load


    private void sessionDimension(string appraisalPeriod, string sessionDep)
    {
        /////////////////////////////////////////////////
        
        DataTable tablePhaseTwo = crudsbLL.getPhaseTwoAPPFormList(appraisalPeriod, sessionDep);
        GrdViewKPI.DataSource = tablePhaseTwo;
        GrdViewKPI.DataBind();
        //DataTable tablePhaseTwo = crudsbLL.getPhaseTwoAPPFormList(sessionDep);
        //DataTable tablePhaseTwo = crudsbLL.getPhaseTwoList(sessionDep);
        //DataTable tablePhaseTwo = crudsbLL.getPhaseTwoList(sessionDep);
        








        DataTable tableFinancial = crudsbLL.getFinancialList(appraisalPeriod, sessionDep);
        if (tableFinancial.Rows.Count > 0)
        {
            GrdViewFinancial.DataSource = tableFinancial;
            GrdViewFinancial.DataBind();

            string kpiDimension="financial";
            //string gsComments="";
            string appFormComments="";

            string cmtResult = crudsbLL.getGoalSettingsComments(kpiDimension.ToLower(),appraisalPeriod, sessionDep);

            if (cmtResult != string.Empty)
            {
                string[] sepsess = cmtResult.Split('_');
                //gsComments = sepsess[0];
                appFormComments = sepsess[1];
                TxtFinancialComments.Text = appFormComments;
                //
                //TxtFinancialComments.Text=gsComments;
                
            }
            
            lblFinancialComments.Visible = true;
            TxtFinancialComments.Visible = true;
        }
        else
        {
            //tableFinancial.Rows.Add(tableFinancial.NewRow());
            //GrdViewFinancial.DataSource = tableFinancial;
            //GrdViewFinancial.DataBind();
            //int totalcolums = GrdViewFinancial.Rows[0].Cells.Count;
            //GrdViewFinancial.Rows[0].Cells.Clear();
            //GrdViewFinancial.Rows[0].Cells.Add(new TableCell());
            //GrdViewFinancial.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //GrdViewFinancial.Rows[0].Cells[0].Text = "No Financial KPI for the Employee";

            lblFinancialComments.Visible = false;
            TxtFinancialComments.Visible = false;
        }
        //GrdViewFinancial.DataSource = tableFinancial;
        //GrdViewFinancial.DataBind();

        DataTable tableCustomer = crudsbLL.getCustomerList(appraisalPeriod, sessionDep);
        if (tableCustomer.Rows.Count > 0)
        {
            GrdViewCustomer.DataSource = tableCustomer;
            GrdViewCustomer.DataBind();

            string kpiDimension = "Customer";
            //string gsComments = "";
            string appFormComments="";

            string cmtResult = crudsbLL.getGoalSettingsComments(kpiDimension.ToLower(), appraisalPeriod, sessionDep);

            if (cmtResult != string.Empty)
            {
                string[] sepsess = cmtResult.Split('_');
                //gsComments = sepsess[0];
                appFormComments = sepsess[1];
                TxtCustomerComments.Text = appFormComments;
            }
            lblCustomerComments.Visible = true;
            TxtCustomerComments.Visible = true;
        }
        else
        {
            lblCustomerComments.Visible = false;
            TxtCustomerComments.Visible = false;
        }

        //GrdViewCustomer.DataSource = tableCustomer;
        //GrdViewCustomer.DataBind();

        DataTable tablePEff = crudsbLL.getProcessEfficiencyList(appraisalPeriod, sessionDep);
        if (tablePEff.Rows.Count > 0)
        {
            GrdViewProcessEfficiency.DataSource = tablePEff;
            GrdViewProcessEfficiency.DataBind();

            string kpiDimension = "Process Efficiency";
            //string gsComments = "";
            string appFormComments="";

            string cmtResult = crudsbLL.getGoalSettingsComments(kpiDimension.ToLower(), appraisalPeriod, sessionDep);

            if (cmtResult != string.Empty)
            {
                string[] sepsess = cmtResult.Split('_');
                //gsComments = sepsess[0];
                appFormComments = sepsess[1];
                TxtProcessEfficiencyComments.Text = appFormComments;
            }
            lblProcessEfficiencyComments.Visible = true;
            TxtProcessEfficiencyComments.Visible = true;
        }
        else
        {
            lblProcessEfficiencyComments.Visible = false;
            TxtProcessEfficiencyComments.Visible = false;
        }
        //GrdViewProcessEfficiency.DataSource = tablePEff;
        //GrdViewProcessEfficiency.DataBind();


        DataTable tablePeople = crudsbLL.getPeopleList(appraisalPeriod, sessionDep);
        if (tablePeople.Rows.Count > 0)
        {
            GrdViewPeople.DataSource = tablePeople;
            GrdViewPeople.DataBind();

            string kpiDimension = "People";
            //string gsComments = "";
            string appFormComments="";

            string cmtResult = crudsbLL.getGoalSettingsComments(kpiDimension.ToLower(), appraisalPeriod, sessionDep);

            if (cmtResult != string.Empty)
            {
                string[] sepsess = cmtResult.Split('_');
                //gsComments = sepsess[0];
                appFormComments = sepsess[1];
                TxtPeopleComments.Text = appFormComments;
            }
            lblPeopleComments.Visible = true;
            TxtPeopleComments.Visible = true;
        }
        else
        {
            lblPeopleComments.Visible = false;
            TxtPeopleComments.Visible = false;
        }
        //GrdViewPeople.DataSource = tablePeople;
        //GrdViewPeople.DataBind();

        DataTable tableBrand = crudsbLL.getBrandList(appraisalPeriod, sessionDep);
        if (tableBrand.Rows.Count > 0)
        {
            GrdViewBrand.DataSource = tableBrand;
            GrdViewBrand.DataBind();
            string kpiDimension = "Brand";
            //string gsComments = "";
            string appFormComments="";

            string cmtResult = crudsbLL.getGoalSettingsComments(kpiDimension.ToLower(), appraisalPeriod, sessionDep);

            if (cmtResult != string.Empty)
            {
                string[] sepsess = cmtResult.Split('_');
                //gsComments = sepsess[0];
                appFormComments = sepsess[1];
                TxtBrandComments.Text = appFormComments;
            }
            lblBrandComments.Visible = true;
            TxtBrandComments.Visible = true;
        }
        else
        {
            lblBrandComments.Visible = false;
            TxtBrandComments.Visible = false;
        }

        ///////////////////////////////////////////////

        if (tableBrand.Rows.Count <= 0 && tableCustomer.Rows.Count <= 0 && tableFinancial.Rows.Count <= 0 && tablePEff.Rows.Count <= 0
           && tablePeople.Rows.Count <= 0 && tablePhaseTwo.Rows.Count <= 0)
        {

            lblStatusMain.Text = "Sorry! The Goal Settings Performance Results have not been created for this employee. The employee can create this in the Goal Settings Management of the menu.";
            lblStatusMain.ForeColor = System.Drawing.Color.Red;
            //delibrately commented
            //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);
            
        }



        //if (tableComm.Rows.Count <= 0 && tableCust.Rows.Count <= 0 && tableInno.Rows.Count <= 0 && tablePEffectAcct.Rows.Count <= 0
        //  && tableProf.Rows.Count <= 0 && tableLead.Rows.Count <= 0 && tableTeam.Rows.Count <= 0)
        //{

        //    lblStatusMain.Text = "Sorry! The Goal Settings for Behavioural Competencies have not been created for this employee for this appraisal period. The employee can create this in the Goal Settings Management of the menu.";
        //    lblStatusMain.ForeColor = System.Drawing.Color.Red;
        //    btnApprove.Visible = false;
        //    btnReview.Visible = false;

        //    //delibrately commented
        //    //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);

        //}
        //else
        //{

        //    lblStatusMain.Text = "Employee Information Found.";
        //    lblStatusMain.ForeColor = System.Drawing.Color.Blue;
        //}









    }
    //private void InsertRecords(StringCollection sc)
    //{

    //    // SqlConnection conn = new SqlConnection(GetConnectionString());

    //    StringBuilder sb = new StringBuilder(string.Empty);

    //    string[] splitItems = null;
    //    string kpiDimensionComments = "";
    //    string appraisalPeriod;
    //    string monthValue;

    //    try
    //    {
    //        foreach (string item in sc)
    //        {



    //            // const string sqlStatement = "INSERT INTO SampleTable (Column1,Column2,Column3) VALUES";

    //            if (item.Contains(","))
    //            {

    //                splitItems = item.Split(",".ToCharArray());
    //                if (splitItems[0].Trim().ToLower() == "financial")
    //                {
    //                    kpiDimensionComments = TxtFinancialComments.Text;
    //                }
    //                else if (splitItems[0].Trim().ToLower() == "customer")
    //                {
    //                    kpiDimensionComments = TxtCustomerComments.Text;
    //                }
    //                else if (splitItems[0].Trim().ToLower() == "process efficiency")
    //                {
    //                    kpiDimensionComments = TxtProcessEfficiencyComments.Text;
    //                }
    //                else if (splitItems[0].Trim().ToLower() == "people")
    //                {
    //                    kpiDimensionComments = TxtPeopleComments.Text;
    //                }
    //                else if (splitItems[0].Trim().ToLower() == "brand")
    //                {
    //                    kpiDimensionComments = TxtBrandComments.Text;
    //                }

    //                if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
    //                {
    //                    monthValue = "00" + ddlMonth.SelectedValue;
    //                }
    //                else
    //                {
    //                    monthValue = "0" + ddlMonth.SelectedValue;
    //                }

    //                appraisalPeriod = ddlYear.SelectedValue + monthValue;

    //                //sb.AppendFormat("{0}('{1}','{2}','{3}'); ", sqlStatement, splitItems[0], splitItems[1], splitItems[2]);
    //                //kpiDimension=splitItems[0], totalKPINumber.Text=splitItems[1],totalObtainableScore.Text=splitItems[2],empNo.Text=splitItems[3]
    //                string usr = crudsbLL.addOrUpdateKPIView(splitItems[0], splitItems[1], splitItems[2], splitItems[3], kpiDimensionComments, appraisalPeriod);
    //            }



    //        }



    //        //try
    //        //{

    //        //conn.Open();

    //        //SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

    //        //cmd.CommandType = CommandType.Text;

    //        //cmd.ExecuteNonQuery();



    //        //Display a popup which indicates that the record was successfully inserted
    //        //lblStatusMain.Text = "Records Successfuly Saved!";
    //        //lblStatusMain.ForeColor = System.Drawing.Color.Blue;
    //        //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



    //    }

    //    catch (Exception ex)
    //    {
    //        lblStatusMain.Text = "Object Error: " + ex.Message;
    //        lblStatusMain.ForeColor = System.Drawing.Color.Red;
    //        return;
    //    }

    //    //finally
    //    //{

    //    //    conn.Close();

    //    //}

    //}//end InsertRec
    //private void InsertDimensionRecords(StringCollection sc)
    //{
    //    StringBuilder sb = new StringBuilder(string.Empty);
    //    string[] splitItems = null;
    //    string appraisalPeriod;
    //    string monthValue;

    //    try
    //    {
    //        foreach (string item in sc)
    //        {



    //            // const string sqlStatement = "INSERT INTO SampleTable (Column1,Column2,Column3) VALUES";

    //            if (item.Contains(","))
    //            {

    //                splitItems = item.Split(",".ToCharArray());
    //                if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
    //                {
    //                    monthValue = "00" + ddlMonth.SelectedValue;
    //                }
    //                else
    //                {
    //                    monthValue = "0" + ddlMonth.SelectedValue;
    //                }

    //                appraisalPeriod = ddlYear.SelectedValue + monthValue;
    //                string employeeNo = LblEmpNo.Text;
    //                string positionId = LblPositionId.Text;
    //                //kpiIdFinancial + "," + kpiTypeFinancial + "," + weightFinancial + "," + targetFinancial + "," + kpiDimensionFinancial
    //                string usr = crudsbLL.addOrUpdateKpiDimDetails(employeeNo, positionId, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], appraisalPeriod);
    //            }



    //        }
    //        //lblStatusMain.Text = "Records Successfuly Saved!";
    //        //lblStatusMain.ForeColor = System.Drawing.Color.Blue;
    //        //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



    //    }

    //    catch (Exception ex)
    //    {
    //        lblStatusMain.Text = "Object Error: " + ex.Message;
    //        lblStatusMain.ForeColor = System.Drawing.Color.Red;
    //        return;
    //    }



    //}//end InsertDimensionRec
    
    

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
    protected void GrdViewKPI_SelectedIndexChanged(object sender, EventArgs e)
    {


    }//GrdViewKPI_SelectedIndexChanged
    protected void GrdViewKPI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewKPI.PageIndex = e.NewPageIndex;
        GrdViewKPI.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewKPI_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewKPI.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewKPI.DataSource = dataView;
            GrdViewKPI.DataBind();
        }





    }//end _Sorting
    protected void GrdViewKPI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewKPI_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL_OBTAINABLE_SCORE"));
            decimal rowTotalIPS = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "INDIVIDUAL_PERFORMANCE_SCORE"));
            grdTotal = grdTotal + rowTotal;
            grdTotalIPS = grdTotalIPS + rowTotalIPS;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbl100percent");
            Label lbl70 = (Label)e.Row.FindControl("lbl70percent");
            Label lblWS = (Label)e.Row.FindControl("lblWeightedScore");

            Label lbl00First = (Label)e.Row.FindControl("Lbl001");
            Label lbl00Second = (Label)e.Row.FindControl("Lbl002");
            decimal tot = grdTotal / 100;
            decimal totIPS = grdTotalIPS / 100;
            lbl.Text = tot.ToString("P");
            lbl00First.Text = totIPS.ToString("P");
            decimal to70percent = totIPS/100 * 70;
            lbl70.Text = "70.0%";
            lblWS.Text = "Weighted Score";
            lbl00Second.Text = to70percent.ToString("P");
            //lbl00First.Text = "0.0%";
            //lbl00Second.Text = "0.0%";
        }
    }//GrdViewKPI_RowDataBound


    protected void GrdViewFinancial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Financial (Job holder’s direct contribution to CDL's profitability in quantitative terms and financial management capabilities)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);
            GrdViewFinancial.Controls[0].Controls.AddAt(0, gvrow);
        }
    }
    protected void GrdViewFinancial_SelectedIndexChanged(object sender, EventArgs e)
    {

    }//GrdViewFinancial_SelectedIndexChanged
    protected void GrdViewFinancial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewFinancial.PageIndex = e.NewPageIndex;
        GrdViewFinancial.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewFinancial_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewFinancial.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewFinancial.DataSource = dataView;
            GrdViewFinancial.DataBind();
        }





    }//end _Sorting
    protected void GrdViewFinancial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand


    protected void GrdViewCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Customer (Job holder’s ability to grow, maintain and retain CDL's customer base)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewCustomer.Controls[0].Controls.AddAt(0, gvrow);






        }
    }//end _RowDataBound
    protected void GrdViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }//_SelectedIndexChanged
    protected void GrdViewCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewCustomer.PageIndex = e.NewPageIndex;
        GrdViewCustomer.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewCustomer_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewCustomer.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewCustomer.DataSource = dataView;
            GrdViewCustomer.DataBind();
        }





    }//end _Sorting
    protected void GrdViewCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand

    protected void GrdViewProcessEfficiency_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdViewProcessEfficiency_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewProcessEfficiency.PageIndex = e.NewPageIndex;
        GrdViewProcessEfficiency.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewProcessEfficiency_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewProcessEfficiency.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewProcessEfficiency.DataSource = dataView;
            GrdViewProcessEfficiency.DataBind();
        }





    }//end _Sorting
    protected void GrdViewProcessEfficiency_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewProcessEfficiency_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Process Efficiency (Job holder’s ability to achieve CDL's defined internal process standards)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewProcessEfficiency.Controls[0].Controls.AddAt(0, gvrow);






        }
    }//_RowDataBound

    protected void GrdViewPeople_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdViewPeople_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewPeople.PageIndex = e.NewPageIndex;
        GrdViewPeople.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewPeople_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewPeople.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewPeople.DataSource = dataView;
            GrdViewPeople.DataBind();
        }





    }//end _Sorting
    protected void GrdViewPeople_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewPeople_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "People (Job holder's innovation and learning capabilities)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewPeople.Controls[0].Controls.AddAt(0, gvrow);
        }
    }//_RowDataBound

    protected void GrdViewBrand_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdViewBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewBrand.PageIndex = e.NewPageIndex;
        GrdViewBrand.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewBrand_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewBrand.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewBrand.DataSource = dataView;
            GrdViewBrand.DataBind();
        }





    }//end _Sorting
    protected void GrdViewBrand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewBrand_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Brand (How external parties view CDL)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewBrand.Controls[0].Controls.AddAt(0, gvrow);
        }
    }//_RowDataBound



    protected void btnShowSubPRGoalSettings_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        string monthValue;
        string appraisalPeriod;
        

        if (Convert.ToInt32(ddlMonthSub.SelectedValue) >= 1 && Convert.ToInt32(ddlMonthSub.SelectedValue) <= 9)
        {
            monthValue = "00" + ddlMonthSub.SelectedValue;
        }
        else
        {
            monthValue = "0" + ddlMonthSub.SelectedValue;
        }

        appraisalPeriod = ddlYearSub.SelectedValue + monthValue;

        if (DDLSubName.Visible == true)
        {
            //DDLSubName.Enabled = true;
            if (string.IsNullOrEmpty(DDLSubName.SelectedValue))
            {
                lblStatusSub.Text = "Please Specify the Subordinate Name";
                lblStatusSub.ForeColor = System.Drawing.Color.Red;
                return;
            }


            try
            {
                string countSubordinate = crudsbLL.getPositionsCount(username);
                if (countSubordinate.Equals("1"))
                {
                    string subSelectedValue = DDLSubName.SelectedValue;
                    //Session["empNoSession"] = subSelectedValue.Trim();
                    ///////////////////////Display the selected guy///////////////////////////////////////////

                    string empName;
                    string empGradeLevel;
                    string empDept;
                    string empNoSess = subSelectedValue;
                                      
                    try
                    {
                        //codes here
                        string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());

                        if (rst != string.Empty)
                        {
                            lblStatusMain.Text = "User record found";// +rst.ToString();
                            lblStatusMain.ForeColor = System.Drawing.Color.Blue;
                            string[] sepsess = rst.Split('_');
                            //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                            empName = sepsess[0];
                            empDept = sepsess[1];
                            empGradeLevel = sepsess[2];
                            LblName.Text = empName;
                            LblGroupDepartment.Text = empDept;
                            LblGradeLevel.Text = empGradeLevel;
                            LblAppraisalPeriod.Text = appraisalPeriod;

                            ///////////////////////////////////////////////////
                            sessionDimension(appraisalPeriod, empNoSess);
                            //////////////////////////////////////////////////

                            //PnlSub.Visible = false;
                            //PnlMain.Visible = true;

                        }
                        else
                        {

                            lblStatusSub.Text = "User record not found";// +rst.ToString();
                            lblStatusSub.ForeColor = System.Drawing.Color.Red;


                        }
                    }
                    catch (Exception ex)
                    {
                        lblStatusSub.Text = "Object Error: " + ex.Message;
                        lblStatusSub.ForeColor = System.Drawing.Color.Red;
                        //return;
                    }

                    ///////////////////////////////////////////////////
                    //sessionDimension(appraisalPeriod, empNoSess);
                    //////////////////////////////////////////////////

                    //btnSendToSupervisor.Visible = false;
                    PnlSub.Visible = false;
                    PnlMain.Visible = true;


                }
                else
                {
                    lblStatusSub.Text = "Sorry you do not have subordinate(s)!";
                    lblStatusSub.ForeColor = System.Drawing.Color.Red;
                    PnlMain.Visible = false;

                }

            }
            catch (Exception ex)
            {
                lblStatusMain.Text = "Object Error: " + ex.Message;
                lblStatusMain.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }//end if > 1
        else
        {
            
            string empName;
            string empGradeLevel;
            string empDept;

            try
            {
                //codes here
                string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

                if (rst != string.Empty)
                {
                    lblStatusMain.Text = "User record found";// +rst.ToString();
                    lblStatusMain.ForeColor = System.Drawing.Color.Blue;
                    
                    string[] sepsess = rst.Split('_');
                    //content = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                    empName = sepsess[0];
                    empDept = sepsess[1];
                    empGradeLevel = sepsess[2];
                    LblEmpNo.Text = sepsess[3];
                    LblPositionId.Text = sepsess[4];

                    LblName.Text = empName;
                    LblGroupDepartment.Text = empDept;
                    LblGradeLevel.Text = empGradeLevel;
                    LblAppraisalPeriod.Text = appraisalPeriod;


                    sessionDimension(appraisalPeriod, username);
                    PnlSub.Visible = false;
                    PnlMain.Visible = true;

                }
                else
                {

                    lblStatusMain.Text = "User record not found";// +rst.ToString();
                    lblStatusMain.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblStatusMain.Text = "Object Error: " + ex.Message;
                lblStatusMain.ForeColor = System.Drawing.Color.Red;
                //return;
            }
            
           // sessionDimension(appraisalPeriod, username);
            
           }//end else




    }//btnShowSubPRGoalSettings_Click

    protected void chkMyDetails_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMyDetails.Checked ==true)
        {
            DDLSubName.Visible = false;
            LblSubName.Visible = false;
        }
        else
        {
            DDLSubName.Visible = true;
            LblSubName.Visible = true;
        }
    }
}