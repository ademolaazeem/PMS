using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Collections.Specialized;
using System.Text;
public partial class Account_forms_ViewBCGoalSettings : System.Web.UI.UserControl
{
    decimal grdTotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        
        String username = Session["usr"].ToString();
        
        //string appraisalPeriod;
        //string employeeNo;



        

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
            btnShowSubPRGoalSettings.Text = "Show Subordinate BC Goal Settings";
            DDLSubName.Visible = true;
            LblSubName.Visible = true;
           
        }
        else if (countSubordinate == "0")
        {
            lblStatusSub.Text = "Your Subordinate(s) is/are not available, Please Continue";
            btnShowSubPRGoalSettings.Text = "Show your BC Goal Settings";
            lblStatusSub.ForeColor = System.Drawing.Color.Red;
            DDLSubName.Visible = false;
            LblSubName.Visible = false;
            chkMyDetails.Visible = false;
        }
        //PnlSub.Visible = true;
        //PnlMain.Visible = false;
            
        
        //////////////////////////////////////Date/////////////////////////////////////////////
        //for (int i = 2013; i <= 2030; i++)
        //{
        //    ddlYearSub.Items.Add(i.ToString());
        //}
        //ddlYearSub.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //for (int i = 1; i <= 12; i++)
        //{


        //    ddlMonthSub.Items.Add(i.ToString());


        //}
        //ddlMonthSub.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected


        //////////////////////////////////End Date/////////////////////////////////////////////

        PnlSub.Visible = true;
        PnlMain.Visible = false;
        
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "View Goal Settings: User " + username + " successfully views behavioural competencies page for Goal Settings Interface", "View");

        //////////////////////Date/////////////////////////////////////////////////
        for (int i = 2013; i <= 2030; i++)
        {
            DDLHolderYear.Items.Add(i.ToString());
        }
        DDLHolderYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {
            DDLHolderMonth.Items.Add(i.ToString());
        }
        DDLHolderMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

        //Fill days
        FillHolderDays();

        for (int i = 2013; i <= 2030; i++)
        {
            DDLAppraiserYear.Items.Add(i.ToString());
        }
        DDLAppraiserYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {
            DDLAppraiserMonth.Items.Add(i.ToString());
        }
        DDLAppraiserMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

        //Fill days
        FillAppraiserDays();
        ///////////////////////End Date/////////////////////////////////////////

        ////////////////////////////New Year/month for the sub panel
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
        /////////////////////////////End New Year/month for the sub panel






        ///////////////////////Start Hide IDs///////////////////////////////////
        GrdViewCommunication.Columns[0].Visible = false;
        GrdViewCustomerCentricity.Columns[0].Visible = false;
        GrdViewTeamwork.Columns[0].Visible = false;
        GrdViewProfessionalism.Columns[0].Visible = false;
        GrdViewPersEffectAccount.Columns[0].Visible = false;
        GrdViewLeadership.Columns[0].Visible = false;
        GrdViewInnovation.Columns[0].Visible = false;
        ///////////////////////Start Hide IDs///////////////////////////////////

    }//_Load
    public void FillHolderDays()
    {
        if (IsPostBack)
        {
            DDLHolderDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLHolderYear.SelectedValue), Convert.ToInt32(DDLHolderMonth.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                DDLHolderDay.Items.Add(i.ToString());
            }
            DDLHolderDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
        
        }//end postback
    }
    public void FillAppraiserDays()
    {
        DDLAppraiserDay.Items.Clear();
        //getting numbner of days in selected month & year
        int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLAppraiserYear.SelectedValue), Convert.ToInt32(DDLAppraiserMonth.SelectedValue));

        //Fill days
        for (int i = 1; i <= noofdays; i++)
        {
            DDLAppraiserDay.Items.Add(i.ToString());
        }
        DDLAppraiserDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
    }
    private void sessionDimension(string sessionDep, string employeeNo, string appraisalPeriod)
    {
        //String username = Session["usr"].ToString();
        /////////////////////////////////////////////////
        DataTable tablePhaseTwo = crudsbLL.getBCPhaseTwoList();
        GrdViewKPI.DataSource = tablePhaseTwo;
        GrdViewKPI.DataBind();


        /////Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);


        DataTable tableProf = crudsbLL.getProfViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tableProf = crudsbLL.getProfList();
        //if (tableProf.Rows.Count > 0)
        //{
        GrdViewProfessionalism.DataSource = tableProf;
        GrdViewProfessionalism.DataBind();
        
        //}
        DataTable tableComm = crudsbLL.getCommViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tableComm = crudsbLL.getCommList();
        GrdViewCommunication.DataSource = tableComm;
        GrdViewCommunication.DataBind();

        DataTable tableTeam = crudsbLL.getTeamViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tableTeam = crudsbLL.getTeamList();
        GrdViewTeamwork.DataSource = tableTeam;
        GrdViewTeamwork.DataBind();


        DataTable tableCust = crudsbLL.getCustViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tableCust = crudsbLL.getCustList();
        GrdViewCustomerCentricity.DataSource = tableCust;
        GrdViewCustomerCentricity.DataBind();

        DataTable tableInno = crudsbLL.getInnoViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tableInno = crudsbLL.getInnoList();
        GrdViewInnovation.DataSource = tableInno;
        GrdViewInnovation.DataBind();

        DataTable tableLead = crudsbLL.getLeadViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tableLead = crudsbLL.getLeadList();
        GrdViewLeadership.DataSource = tableLead;
        GrdViewLeadership.DataBind();

        DataTable tablePEffectAcct = crudsbLL.getPEffectAcctViewList(sessionDep, employeeNo, appraisalPeriod);
        //DataTable tablePEffectAcct = crudsbLL.getPEffectAcctList();
        GrdViewPersEffectAccount.DataSource = tablePEffectAcct;
        GrdViewPersEffectAccount.DataBind();



        if (tableComm.Rows.Count <= 0 && tableCust.Rows.Count <= 0 && tableInno.Rows.Count <= 0 && tablePEffectAcct.Rows.Count <= 0
           && tableProf.Rows.Count <= 0 && tableLead.Rows.Count <= 0 && tableTeam.Rows.Count <= 0)
        {

            lblStatusMain.Text = "Sorry! The Goal Settings for Behavioural Competencies have not been created for this employee for this appraisal period. The employee can create this in the Goal Settings Management of the menu.";
            lblStatusMain.ForeColor = System.Drawing.Color.Red;
            btnApprove.Visible = false;
            btnReview.Visible = false;

            //delibrately commented
            //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);

        }
        else {

            lblStatusMain.Text = "Employee Information Found.";
            lblStatusMain.ForeColor = System.Drawing.Color.Blue;
        }
        

    }
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
    //protected void GrdViewKPI_RowDataBound(Object sender, GridViewRowEventArgs e)
    //{
    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {

    //        decimal rowTotal = Convert.ToDecimal
    //        (DataBinder.Eval(e.Row.DataItem, "WEIGHT"));
    //        grdTotal = grdTotal + rowTotal;
    //    }
    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        Label lbl = (Label)e.Row.FindControl("WEIGHT");
    //        decimal tot = grdTotal / 100;
    //        lbl.Text = tot.ToString("P");
    //        //lbl70.Text = "70.0%";
    //        //lblWS.Text = "Weighted Score";
    //        //lbl00First.Text = "0.0%";
    //        //lbl00Second.Text = "0.0%";
    //    }
    //}//GrdViewKPI_RowDataBound
    protected void GrdViewKPI_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            decimal rowTotal = Convert.ToDecimal
            (DataBinder.Eval(e.Row.DataItem, "WEIGHT"));
            grdTotal = grdTotal + rowTotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalWeight");
            decimal tot = grdTotal / 100;
            lbl.Text = tot.ToString("P");
        }
    }//GrdViewKPI_RowDataBound
    protected void GrdViewProfessionalism_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewProfessionalism.PageIndex = e.NewPageIndex;
        GrdViewProfessionalism.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewProfessionalism_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewProfessionalism.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewProfessionalism.DataSource = dataView;
            GrdViewProfessionalism.DataBind();
        }





    }//end _Sorting
    protected void GrdViewProfessionalism_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand

    protected void GrdViewCommunication_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewCommunication.PageIndex = e.NewPageIndex;
        GrdViewCommunication.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewCommunication_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewCommunication_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewCommunication.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewCommunication.DataSource = dataView;
            GrdViewCommunication.DataBind();
        }

    }//end _Sorting

    protected void GrdViewTeamwork_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewTeamwork.PageIndex = e.NewPageIndex;
        GrdViewTeamwork.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewTeamwork_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewTeamwork_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewTeamwork.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewTeamwork.DataSource = dataView;
            GrdViewTeamwork.DataBind();
        }

    }//end _Sorting
    protected void GrdViewCustomerCentricity_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewCustomerCentricity.PageIndex = e.NewPageIndex;
        GrdViewCustomerCentricity.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewCustomerCentricity_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewCustomerCentricity_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewCustomerCentricity.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewCustomerCentricity.DataSource = dataView;
            GrdViewCustomerCentricity.DataBind();
        }

    }//end _Sorting
    protected void GrdViewInnovation_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewCustomerCentricity.PageIndex = e.NewPageIndex;
        GrdViewCustomerCentricity.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewInnovation_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewInnovation_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewInnovation.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewInnovation.DataSource = dataView;
            GrdViewInnovation.DataBind();
        }

    }//end _Sorting
    protected void GrdViewLeadership_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewLeadership.PageIndex = e.NewPageIndex;
        GrdViewLeadership.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewLeadership_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewLeadership_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewLeadership.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewLeadership.DataSource = dataView;
            GrdViewLeadership.DataBind();
        }

    }//end _Sorting
    protected void GrdViewPersEffectAccount_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewPersEffectAccount.PageIndex = e.NewPageIndex;
        GrdViewPersEffectAccount.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewPersEffectAccount_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewPersEffectAccount_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewPersEffectAccount.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewPersEffectAccount.DataSource = dataView;
            GrdViewPersEffectAccount.DataBind();
        }

    }//end _Sorting
    
    protected void DDLHolderYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillHolderDays();
    }
    protected void DDLHolderMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillHolderDays();
    }
    protected void DDLAppraiserYear_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAppraiserDays();
    }
    protected void DDLAppraiserMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillAppraiserDays();
    }


    protected void btnSendReview_Click(object sender, EventArgs e)
    {
        //btnSendReview
        string usernameMsg = Session["usrname"].ToString();
        string appraisalPeriod;
        string employeeNo = LblEmpNo.Text;
        string appraiserComments = TxtComment.Text;
        appraisalPeriod = Session["appPeriod"].ToString(); ;
        employeeNo = Session["empNo"].ToString();
        string subName = Session["holderSign"].ToString();
        string supUsername = "";
        string supEmail = "";
        string supName = "";
        string status = "UNDER REVIEW";
        string subEmail= usernameMsg+"@cdlnigeria.com";

        string rst = crudsbLL.getSupervisorInformation(usernameMsg.Trim().ToLower());

        if (rst != string.Empty)
        {
            string[] sepsess = rst.Split('_');
            supUsername = sepsess[0];
            supEmail = sepsess[1];
            supName = sepsess[2];
            //string bcGSSendMail = BLLMail2Send.sendMail2SupervisorForBC(supEmail, senderName);
            //LblEmpNo.Text = sepsess[3];
            //LblPositionId.Text = sepsess[4];
        }
        else
        {

            lblStatusSub.Text = "You do not have a Supervisor";// +rst.ToString();
            lblStatusSub.ForeColor = System.Drawing.Color.Red;


        }

        string usr = crudsbLL.UpdateBCAppraiserComments(employeeNo, appraisalPeriod, appraiserComments, status);
        //UpdateBCAppraiserComments
        if (usr == "10")
        {
            string bcGSSendMail = BLLMail2Send.sendMail2SubordinateForBC(subEmail, subName, supName); 
            
            lblStatusSub.Text = "Records Successfuly Saved!";
            lblStatusSub.ForeColor = System.Drawing.Color.Blue;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);

        }
        else
        {
            lblStatusSub.Text = "Please specify the correct Appraisal Period and/or subordinates. The information you provided does not exist!";
            lblStatusSub.ForeColor = System.Drawing.Color.Red;
        }

       



    }//btnSend

    //public void CleartextBoxes(Control parent)
    //{

    //    foreach (Control c in parent.Controls)
    //    {
    //        if ((c.GetType() == typeof(TextBox)))
    //        {

    //            ((TextBox)(c)).Text = "";
    //        }

    //        if (c.HasControls())
    //        {
    //            CleartextBoxes(c);
    //        }
    //    }
    //}
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
    //                //string positionId = LblPositionId.Text;
    //                // string kpiDimId, actionPlan
    //                string usr = crudsbLL.addOrUpdateBCKpiDimDetails(splitItems[0], splitItems[1], employeeNo, appraisalPeriod);
    //            }



    //        }
    //        lblStatusSub.Text = "Records Successfuly Saved!";
    //        lblStatusSub.ForeColor = System.Drawing.Color.Blue;
    //        //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



    //    }

    //    catch (Exception ex)
    //    {
    //        lblStatusSub.Text = "KPI Dimension Save Error: " + ex.Message;
    //        lblStatusSub.ForeColor = System.Drawing.Color.Red;
    //        return;
    //    }



    //}//end InsertDimensionRec
    protected void btnShowSubPRGoalSettings_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        string monthValue;
        string appraisalPeriod;
        string employeeNo;

        if (Convert.ToInt32(ddlMonthSub.SelectedValue) >= 1 && Convert.ToInt32(ddlMonthSub.SelectedValue) <= 9)
        {
            monthValue = "00" + ddlMonthSub.SelectedValue;
        }
        else
        {
            monthValue = "0" + ddlMonthSub.SelectedValue;
        }

        appraisalPeriod = ddlYearSub.SelectedValue + monthValue;
        //employeeNo = LblEmpNo.Text;
        //if (DDLSubName.Items.Count > 1)
       if (DDLSubName.Visible==true)
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
                //string countSubordinate = crudsbLL.getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
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
                            //lblStatusMain.Text = "Employee record found";// +rst.ToString();
                            //lblStatusMain.ForeColor = System.Drawing.Color.Blue;
                            string[] sepsess = rst.Split('_');
                            empName = sepsess[0];
                            empDept = sepsess[1];
                            empGradeLevel = sepsess[2];
                            employeeNo = sepsess[3];
                            LblName.Text = empName;
                            LblGroupDepartment.Text = empDept;
                            LblGradeLevel.Text = empGradeLevel;
                            LblHolderSignature.Text = sepsess[0];
                            LblAppraisalPeriod.Text = appraisalPeriod;

                            Session["appPeriod"] = LblAppraisalPeriod.Text;
                            Session["holderSign"] = LblHolderSignature.Text;
                            Session["empNo"] = employeeNo;
                            Session["usrname"] = empNoSess;
                            
                            DDLHolderDay.Enabled = false;
                            DDLHolderMonth.Enabled = false;
                            DDLHolderYear.Enabled = false;

                            //////////////////////////////////////
                            sessionDimension(username, employeeNo, appraisalPeriod);
                            //DataTable tablePEffectAcct = crudsbLL.getPEffectAcctList(username, employeeNo, appraisalPeriod);
                            //GrdViewPersEffectAccount.DataSource = tablePEffectAcct;
                            //GrdViewPersEffectAccount.DataBind();
                            ///////////////////////////////////

                            string rstSupervisor = crudsbLL.getPhaseOneContent(username.ToString().Trim().ToLower());
                            string[] sepSup = rstSupervisor.Split('_');
                            if (rstSupervisor != string.Empty)
                            {
                                string supName = sepSup[0];
                                LblAppraiserSignature.Text = supName;
                                Session["appraiserSig"] = LblAppraiserSignature.Text;
                            }

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

                    
                    employeeNo = LblEmpNo.Text;
                    /////////////////////////////////////////////////

                    //sessionDimension(empNoSess, employeeNo, appraisalPeriod);



                    ////////////////////End Display the selected guy/////////////////////////////////////////

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
           // DDLSubName.Enabled = false;
            ///////////////////////////display for the logged in guy/////////////////////////
            string empName;
            string empGradeLevel;
            string empDept;


            //String username = Session["usr"].ToString();
            // string empNoSess = Session["empNoSession"].ToString();



            try
            {
                //codes here
                string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

                if (rst != string.Empty)
                {
                //    lblStatusMain.Text = "Employee record found";// +rst.ToString();
                //    lblStatusMain.ForeColor = System.Drawing.Color.Blue;
                   
                    string[] sepsess = rst.Split('_');
                    //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                    empName = sepsess[0];
                    empDept = sepsess[1];
                    empGradeLevel = sepsess[2];
                    LblEmpNo.Text = sepsess[3];
                    LblPositionId.Text = sepsess[4];
                    employeeNo=LblEmpNo.Text;
                    LblAppraisalPeriod.Text = appraisalPeriod;
                    LblName.Text = empName;
                    LblGroupDepartment.Text = empDept;
                    LblGradeLevel.Text = empGradeLevel;
                    //LblHolderSignature.Text = sepsess[5];
                    LblHolderSignature.Text = sepsess[0];


                    Session["appPeriod"] = LblAppraisalPeriod.Text;
                    Session["holderSign"] = LblHolderSignature.Text;
                    Session["empNo"] = employeeNo;




            sessionDimension(username, employeeNo, appraisalPeriod);
            btnApprove.Visible = false;
            btnReview.Visible = false;
            //btnSendToSupervisor.Visible = true;
            DDLAppraiserDay.Enabled = false;
            DDLAppraiserMonth.Enabled = false;
            DDLAppraiserYear.Enabled = false;
            ////////////////////////End display for the logged in guy///////////////////////
            PnlSub.Visible = false;
            PnlMain.Visible = true;




                }
                else
                {

                    lblStatusSub.Text = "Employee record not found";// +rst.ToString();
                    lblStatusSub.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblStatusMain.Text = "Object Error: " + ex.Message;
                lblStatusMain.ForeColor = System.Drawing.Color.Red;
                //return;
            }


            //string monthValue;
            //string appraisalPeriod;
            //string employeeNo;
            //if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
            //{
            //    monthValue = "00" + ddlMonth.SelectedValue;
            //}
            //else
            //{
            //    monthValue = "0" + ddlMonth.SelectedValue;
            //}

            //appraisalPeriod = ddlYear.SelectedValue + monthValue;
            //employeeNo = LblEmpNo.Text;
            //holderSign = LblHolderSignature.Text;
            //holderYear = DDLHolderYear.SelectedValue;
            //holderMonth = DDLHolderMonth.SelectedValue;
            //holderDay = DDLHolderDay.SelectedValue;
            //holderDate = holderDay + "/" + holderMonth + "/" + holderYear;



            //sessionDimension(username, employeeNo, appraisalPeriod);

            //btnApprove.Visible = false;
            //btnReview.Visible = false;
            //btnSendToSupervisor.Visible = true;
            //DDLAppraiserDay.Enabled = false;
            //DDLAppraiserMonth.Enabled = false;
            //DDLAppraiserYear.Enabled = false;
            //////////////////////////End display for the logged in guy///////////////////////
            //PnlSub.Visible = false;
            //PnlMain.Visible = true;




        
        
        }//end else



    }//btnShowSubPRGoalSettings_Click


    protected void btnReview_Click(object sender, EventArgs e)
    {

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {


        //btnSendReview
        string usernameMsg = Session["usrname"].ToString();
        string appraisalPeriod;
        string employeeNo = LblEmpNo.Text;
        appraisalPeriod = Session["appPeriod"].ToString(); ;
        employeeNo = Session["empNo"].ToString();
        string subName = Session["holderSign"].ToString();
        string supUsername = "";
        string supEmail = "";
        string supName = "";
        string status = "APPROVED";
        string subEmail = usernameMsg + "@cdlnigeria.com";
        //string appraiserSign = Session["appraiserSig"].ToString();
        string appraiserYear, appraiserMonth, appraiserDay, appraiserDate;
        appraiserYear = DDLAppraiserYear.SelectedValue;
        appraiserMonth = DDLAppraiserMonth.SelectedValue;
        appraiserDay = DDLAppraiserDay.SelectedValue;
        appraiserDate = appraiserDay + "/" + appraiserMonth + "/" + appraiserYear;

        string rst = crudsbLL.getSupervisorInformation(usernameMsg.Trim().ToLower());

        if (rst != string.Empty)
        {
            string[] sepsess = rst.Split('_');
            supUsername = sepsess[0];
            supEmail = sepsess[1];
            supName = sepsess[2];
            //string bcGSSendMail = BLLMail2Send.sendMail2SupervisorForBC(supEmail, senderName);
            //LblEmpNo.Text = sepsess[3];
            //LblPositionId.Text = sepsess[4];
        }
        else
        {

            lblStatusSub.Text = "You do not have a Supervisor";// +rst.ToString();
            lblStatusSub.ForeColor = System.Drawing.Color.Red;


        }

        string usr = crudsbLL.approveBCompetencies(employeeNo, appraisalPeriod, supName, appraiserDate, status);
            //UpdateBCAppraiserComments(employeeNo, appraisalPeriod, appraiserComments, status);
        
        //UpdateBCAppraiserComments
        if (usr == "10")
        {
            string bcGSSendMail = BLLMail2Send.sendMail2SubordinateForBCApproval(subEmail, subName, supName);

            lblStatusSub.Text = "Approval Successfully carried out. A notification email has been sent to the subordinate!";
            lblStatusSub.ForeColor = System.Drawing.Color.Blue;
            Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Approval Successfully carried out. A notification email has been sent to the subordinate!');", true);

        }
        else
        {
            lblStatusSub.Text = "Please specify the correct Appraisal Period and/or subordinates. The information you provided is not correct!";
            lblStatusSub.ForeColor = System.Drawing.Color.Red;
        }

       


    }
    protected void chkMyDetails_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMyDetails.Checked == true)
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