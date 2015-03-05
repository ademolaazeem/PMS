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

public partial class Account_forms_OriginalBCGoalSettings : System.Web.UI.UserControl
{
    decimal grdTotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        
        String username = Session["usr"].ToString();
        //string appraisalPeriod;
        string employeeNo;
        string empName;
        string empGradeLevel;
        string empDept;
        try
            {
                //codes here
                string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

                if (rst != string.Empty)
                {
                    lblStatus.Text = "Employee record found";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    //
                    //authPanel.Visible = true;

                    //S[LIT CONTENT
                    string[] sepsess = rst.Split('_');
                    //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                    empName = sepsess[0];
                    empDept = sepsess[1];
                    empGradeLevel = sepsess[2];
                    LblEmpNo.Text = sepsess[3];
                    LblPositionId.Text = sepsess[4];
                    employeeNo = LblEmpNo.Text;
                    //LblAppraisalPeriod.Text = appraisalPeriod;
                    LblName.Text = empName;
                    LblGroupDepartment.Text = empDept;
                    LblGradeLevel.Text = empGradeLevel;
                    //LblHolderSignature.Text = sepsess[5];
                    LblHolderSignature.Text = sepsess[0];
                    
                    sessionDimension(username);
                    btnApprove.Visible = false;
                    btnReview.Visible = false;
                    btnSendToSupervisor.Visible = true;
                    DDLAppraiserDay.Enabled = false;
                    DDLAppraiserMonth.Enabled = false;
                    DDLAppraiserYear.Enabled = false;
                    ////////////////////////End display for the logged in guy///////////////////////
                    



                }
                else
                {

                    lblStatus.Text = "Employee record not found";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Object Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //return;
            }


            













            

       
        
        ////////////////////////////////////Date/////////////////////////////////////////////
        for (int i = 2013; i <= 2030; i++)
        {
            ddlYear.Items.Add(i.ToString());
        }
        ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        for (int i = 1; i <= 12; i++)
        {


            ddlMonth.Items.Add(i.ToString());


        }
        ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected


        ////////////////////////////////End Date/////////////////////////////////////////////
       
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Goal Settings: User " + username + " successfully views behavioural competencies page for Goal Settings Interface", "View");

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
    private void sessionDimension(string sessionDep)
    {
        //String username = Session["usr"].ToString();
        /////////////////////////////////////////////////
        DataTable tablePhaseTwo = crudsbLL.getBCPhaseTwoList();
        GrdViewKPI.DataSource = tablePhaseTwo;
        GrdViewKPI.DataBind();
        




        //DataTable tableProf = crudsbLL.getProfList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tableProf = crudsbLL.getProfList();
        //if (tableProf.Rows.Count > 0)
        //{
        GrdViewProfessionalism.DataSource = tableProf;
        GrdViewProfessionalism.DataBind();
        
        //}
        //DataTable tableComm = crudsbLL.getCommList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tableComm = crudsbLL.getCommList();
        GrdViewCommunication.DataSource = tableComm;
        GrdViewCommunication.DataBind();

        //DataTable tableTeam = crudsbLL.getTeamList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tableTeam = crudsbLL.getTeamList();
        GrdViewTeamwork.DataSource = tableTeam;
        GrdViewTeamwork.DataBind();

        
        //DataTable tableCust = crudsbLL.getCustList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tableCust = crudsbLL.getCustList();
        GrdViewCustomerCentricity.DataSource = tableCust;
        GrdViewCustomerCentricity.DataBind();

       //DataTable tableInno = crudsbLL.getInnoList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tableInno = crudsbLL.getInnoList();
        GrdViewInnovation.DataSource = tableInno;
        GrdViewInnovation.DataBind();

        //DataTable tableLead = crudsbLL.getLeadList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tableLead = crudsbLL.getLeadList();
        GrdViewLeadership.DataSource = tableLead;
        GrdViewLeadership.DataBind();

        //DataTable tablePEffectAcct = crudsbLL.getPEffectAcctList(sessionDep, employeeNo, appraisalPeriod);
        DataTable tablePEffectAcct = crudsbLL.getPEffectAcctList();
        GrdViewPersEffectAccount.DataSource = tablePEffectAcct;
        GrdViewPersEffectAccount.DataBind();


        ///////////////////////////////////////////////

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

    protected void btnSendToSupervisor_Click(object sender, EventArgs e)
    {
        
        string appraisalPeriod, monthValue;
        string holderSign, holderYear, holderMonth, holderDay;
        string holderDate, employeeNo;
        //appraisalPeriod = LblAppraisalPeriod.Text;
        //ddlYear.SelectedValue + monthValue;
        //holderSign = LblHolderSignature.Text;
        holderYear = DDLHolderYear.SelectedValue;
        holderMonth = DDLHolderMonth.SelectedValue;
        holderDay = DDLHolderDay.SelectedValue;
        holderDate = holderDay + "/" + holderMonth + "/" + holderYear;
        employeeNo = LblEmpNo.Text;
        holderSign = LblHolderSignature.Text;
        //18/3/2014
        if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
        {
            monthValue = "00" + ddlMonth.SelectedValue;
        }
        else
        {
            monthValue = "0" + ddlMonth.SelectedValue;
        }

        appraisalPeriod = ddlYear.SelectedValue + monthValue;
        
        bool emptyTextbox = false;
        //int countmyRows = GrdViewProfessionalism.Rows.Count();
        foreach (GridViewRow row in GrdViewProfessionalism.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_PROF") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
                {
                 emptyTextbox = true;
                 break;
                }
        }//end foreach
        foreach (GridViewRow row in GrdViewCommunication.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_COMM") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                emptyTextbox = true;
                break;
            }
        }//end foreach
        foreach (GridViewRow row in GrdViewTeamwork.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_TEAM") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                emptyTextbox = true;
                break;
            }
        }//end foreach
        foreach (GridViewRow row in GrdViewInnovation.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_INNO") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                emptyTextbox = true;
                break;
            }
        }//end foreach
        foreach (GridViewRow row in GrdViewLeadership.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_LEAD") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                emptyTextbox = true;
                break;
            }
        }//end foreach

        foreach (GridViewRow row in GrdViewCustomerCentricity.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_CUST") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                emptyTextbox = true;
                break;
            }
        }//end foreach

        foreach (GridViewRow row in GrdViewPersEffectAccount.Rows)
        {
            TextBox txt = row.FindControl("ACTION_PLANS_PEA") as TextBox;
            if (string.IsNullOrEmpty(txt.Text))
            {
                emptyTextbox = true;
                break;
            }
        }//end foreach

        if (emptyTextbox)
        {
            lblStatus.Text = "Please fill every empty necessary information";
            lblStatus.ForeColor = System.Drawing.Color.Red;
        }
        else
        {

            string usr = crudsbLL.addOrUpdateBCGoalSettings(employeeNo, holderSign, holderDate, appraisalPeriod);
            ////////////////////////////////End Test for Textbox Emptiness///////////////////////////////////////////////////
            //////////////////////////////////Professionalism////////////////////////////////////////////////////////////
            StringCollection scProf = new StringCollection();

            foreach (GridViewRow r in GrdViewProfessionalism.Rows)
            {
                //extract the TextBox values
                //string kpiDimensionProf = "Professionalism";
                string kpiDimId = r.Cells[0].Text;
                TextBox actPProf = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_PROF");
                string actionPlanProf = actPProf.Text;
                scProf.Add(kpiDimId + "," + actionPlanProf);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scProf);
            ///////////////////////////////////End Professionalism///////////////////////////////////////////////////////
            //////////////////////////////////Communication/////////////////////////////////////////////////////////////////
            StringCollection scComm = new StringCollection();

            foreach (GridViewRow r in GrdViewCommunication.Rows)
            {
                //extract the TextBox values
                string kpiDimId = r.Cells[0].Text;
                TextBox actComm = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_COMM");
                string actionPlanComm = actComm.Text;
                scComm.Add(kpiDimId + "," + actionPlanComm);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scComm);
            ///////////////////////////////////End Communication////////////////////////////////////////////////////////////

            //////////////////////////////////Teamwork/////////////////////////////////////////////////////////////////////
            StringCollection scTeam = new StringCollection();

            foreach (GridViewRow r in GrdViewTeamwork.Rows)
            {
                //extract the TextBox values
                //string kpiDimensionProf = "Professionalism";
                string kpiDimId = r.Cells[0].Text;
                TextBox actTeam = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_TEAM");
                string actionPlanTeam = actTeam.Text;
                scTeam.Add(kpiDimId + "," + actionPlanTeam);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scTeam);
            ///////////////////////////////////End Teamwork/////////////////////////////////////////////////////////////////

            //////////////////////////////////Customer Centricity/////////////////////////////////////////////////////////////////
            StringCollection scCust = new StringCollection();

            foreach (GridViewRow r in GrdViewCustomerCentricity.Rows)
            {
                //extract the TextBox values
                //string kpiDimensionProf = "Professionalism";
                string kpiDimId = r.Cells[0].Text;
                TextBox actPCust = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_CUST");
                string actionPlanCust = actPCust.Text;
                scCust.Add(kpiDimId + "," + actionPlanCust);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scCust);
            ///////////////////////////////////End Customer Centricity/////////////////////////////////////////////////////////////////
            //////////////////////////////////Start Innovation/////////////////////////////////////////////////////////////////
            StringCollection scInno = new StringCollection();

            foreach (GridViewRow r in GrdViewInnovation.Rows)
            {
                //extract the TextBox values
                //string kpiDimensionProf = "Professionalism";
                string kpiDimId = r.Cells[0].Text;
                TextBox actPInno = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_INNO");
                string actionPlanInno = actPInno.Text;
                scInno.Add(kpiDimId + "," + actionPlanInno);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scInno);
            ///////////////////////////////////End Innovation/////////////////////////////////////////////////////////////////
            //////////////////////////////////Start Leadership/////////////////////////////////////////////////////////////////
            StringCollection scLead = new StringCollection();

            foreach (GridViewRow r in GrdViewLeadership.Rows)
            {
                //extract the TextBox values
                //string kpiDimensionProf = "Professionalism";
                string kpiDimId = r.Cells[0].Text;
                TextBox actPLead = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_LEAD");
                string actionPlanLead = actPLead.Text;
                scLead.Add(kpiDimId + "," + actionPlanLead);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scLead);
            ///////////////////////////////////End Leadership/////////////////////////////////////////////////////////////////
            //////////////////////////////////Start Personal Effect and Accountability///////////////////////////////////////
            StringCollection scPEA = new StringCollection();

            foreach (GridViewRow r in GrdViewPersEffectAccount.Rows)
            {
                //extract the TextBox values
                //string kpiDimensionProf = "Professionalism";
                string kpiDimId = r.Cells[0].Text;
                TextBox actPPEA = (TextBox)r.Cells[2].FindControl("ACTION_PLANS_PEA");
                string actionPlanPEA = actPPEA.Text;
                scPEA.Add(kpiDimId + "," + actionPlanPEA);


            }//end for

            //Call the method for executing inserts
            InsertDimensionRecords(scPEA);
            ///////////////////////////////////End Personal Effect and Accountability////////////////////////////////////
            //////////////////////////////////save goal settings/////////////////////////////////////////////////////////
            //String username = Session["usr"].ToString();
            // string monthValue;
            //string appraisalPeriod;
            //string holderSign, holderYear, holderMonth, holderDay;
            //string holderDate, employeeNo;
            //appraisalPeriod = LblAppraisalPeriod.Text;
            ////ddlYear.SelectedValue + monthValue;
            //holderSign = LblHolderSignature.Text;
            //holderYear = DDLHolderYear.SelectedValue;
            //holderMonth = DDLHolderMonth.SelectedValue;
            //holderDay = DDLHolderDay.SelectedValue;
            //holderDate = holderDay + "/" + holderMonth + "/" + holderYear;
            //employeeNo = LblEmpNo.Text;
            ////18/3/2014

            //string usr = crudsbLL.addOrUpdateBCGoalSettings(employeeNo, holderSign, holderDate, appraisalPeriod);
            
            //////////////////////////////////end save goal settings/////////////////////////////////////////////////


            //////////////////////////////////////Clear box////////////////////////////////////////
            CleartextBoxes(this);
            ////////////////////////////////End Clear box///////////////////////////////////////////


            //////////////////////////////////////Send mail////////////////////////////////////////
            ////emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody
            //string from = "akazeem@cdlnigeria.com";
            ////string from = "no-reply@cdlnigeria.com";
            //string to = "fogunyemi@cdlnigeria.com";
            //string bcc = "diamonddemola@yahoo.co.uk";
            //string cc = "tbabayi@cdlnigeria.com";
            //string subject = "Goal Settings Behavioural Competencies";
            //string body = "Dear Sir,<br/> This is to inform you that one of your subordinates " + LblName.Text + " has completed his behavioural competencies goal settings. Your input is needed.<br/><br/> Best Regards";
            //string bcGSSendMail = crudsbLL.SendMail(from, to, bcc, cc, subject, body);
            
            
            
            
            
            

            
            
            
            
            String username = Session["usr"].ToString();
            string supUsername="";
            string supEmail="";
            string supName="";
            //string senderName = LblHolderSignature.Text;
            string senderName = holderSign;

            string rst = crudsbLL.getSupervisorInformation(username.Trim().ToLower());

            if (rst != string.Empty)
            {
                string[] sepsess = rst.Split('_');
                // content = reader["username"].ToString() + "_" + reader["email"].ToString() + "_" + reader["name"].ToString();
                supUsername = sepsess[0];
                supEmail = sepsess[1];
                supName  = sepsess[2];
                //string bcGSSendMail = BLLMail2Send.sendMail2SupervisorForBC(supEmail, senderName);
                //LblEmpNo.Text = sepsess[3];
                //LblPositionId.Text = sepsess[4];
             }
            else
            {

                lblStatus.Text = "You do not have a Supervisor";// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;


            }

            string bcGSSendMail = BLLMail2Send.sendMail2SupervisorForBC(supEmail, supName, senderName);










            //////////////////////////////////End Send mail///////////////////////////////////////////
            //if (usr == "10" || usr == "20")
            //{
            //    lblStatusSub.Text = "Records Successfuly Saved!";
            //    lblStatusSub.ForeColor = System.Drawing.Color.Blue;
            //    Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
            //}
            //else
            //{
            //    lblStatusSub.Text = "<b><i>Whoa!</i></b> " + usr.ToString();// +rst.ToString();
            //    lblStatusSub.ForeColor = System.Drawing.Color.Red; 
            //    return;
            //}










        }//end else test for empty

    }//btnSendToSupervisor_Click


    //protected void btnSendReview_Click(object sender, EventArgs e)
    //{

    //    string usernameMsg = Session["usr"].ToString();
    //    string monthValue;
    //    string appraisalPeriod;
    //     if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
    //    {
    //        monthValue = "00" + ddlMonth.SelectedValue;
    //    }
    //    else
    //    {
    //        monthValue = "0" + ddlMonth.SelectedValue;
    //    }

    //    appraisalPeriod = ddlYear.SelectedValue + monthValue;
    //    string employeeNo = LblEmpNo.Text;
    //    string appraiserComments=TxtComment.Text;
    //    //string positionId = LblPositionId.Text;
    //    // string kpiDimId, actionPlan
    //    string usr = crudsbLL.UpdateBCAppraiserComments(employeeNo, appraisalPeriod, appraiserComments);
    //    //UpdateBCAppraiserComments
    //    if(usr=="10")
    //    {
    //        lblStatus.Text = "Records Successfuly Saved!";
    //        lblStatus.ForeColor = System.Drawing.Color.Blue;
    //        Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
        
    //    }

    //    //////////////////////////////////////Send mail////////////////////////////////////////
    //        ////emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody
    //        //string from = "staffappraisal@cdlnigeria.com";
    //        ////string from = "no-reply@cdlnigeria.com";
    //        //string to = "fogunyemi@cdlnigeria.com";
    //        //string bcc = "diamonddemola@yahoo.co.uk";
    //        //string cc = "tbabayi@cdlnigeria.com";
    //        //string subject = "Goal Settings Behavioural Competencies";
    //        //string body = "Dear Sir,<br/> This is to inform you that one of your subordinates " + LblName.Text + " has completed his behavioural competencies goal settings. Your input is needed.<br/><br/> Best Regards";
    //        //string bcGSSendMail = crudsbLL.SendMail(from, to, bcc, cc, subject, body);
    //        ////////////////////////////////End Send mail///////////////////////////////////////////

       

    //}//btnSend

    public void CleartextBoxes(Control parent)
    {

        foreach (Control c in parent.Controls)
        {
            if ((c.GetType() == typeof(TextBox)))
            {

                ((TextBox)(c)).Text = "";
            }

            if (c.HasControls())
            {
                CleartextBoxes(c);
            }
        }
    }
    private void InsertDimensionRecords(StringCollection sc)
    {
        StringBuilder sb = new StringBuilder(string.Empty);
        string[] splitItems = null;
        string appraisalPeriod;
        string monthValue;

        try
        {
            foreach (string item in sc)
            {



                // const string sqlStatement = "INSERT INTO SampleTable (Column1,Column2,Column3) VALUES";

                if (item.Contains(","))
                {

                    splitItems = item.Split(",".ToCharArray());
                    if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
                    {
                        monthValue = "00" + ddlMonth.SelectedValue;
                    }
                    else
                    {
                        monthValue = "0" + ddlMonth.SelectedValue;
                    }

                    appraisalPeriod = ddlYear.SelectedValue + monthValue;
                    string employeeNo = LblEmpNo.Text;
                    //string positionId = LblPositionId.Text;
                    // string kpiDimId, actionPlan
                    string usr = crudsbLL.addOrUpdateBCKpiDimDetails(splitItems[0], splitItems[1], employeeNo, appraisalPeriod);
                }



            }
            lblStatus.Text = "Records Successfuly Saved!";
            lblStatus.ForeColor = System.Drawing.Color.Blue;
            //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



        }

        catch (Exception ex)
        {
            lblStatus.Text = "KPI Dimension Save Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }



    }//end InsertDimensionRec
    


    protected void btnReview_Click(object sender, EventArgs e)
    {

    }
    protected void btnApprove_Click(object sender, EventArgs e)
    {

    }
}