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



public partial class Account_forms_OriginalBCApplicationForm : System.Web.UI.UserControl
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        
        
        
        String username = Session["usr"].ToString();
        //string appraisalPeriod;
        string employeeNo;
        string empName;
        string empGradeLevel;
        string empDept;
        //try
        //    {
            //    //codes here
            //    string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

            //    if (rst != string.Empty)
            //    {
            //        lblStatus.Text = "Employee record found";// +rst.ToString();
            //        lblStatus.ForeColor = System.Drawing.Color.Blue;
            //        //
            //        //authPanel.Visible = true;

            //        //S[LIT CONTENT
            //        string[] sepsess = rst.Split('_');
            //        //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
            //        empName = sepsess[0];
            //        empDept = sepsess[1];
            //        empGradeLevel = sepsess[2];
            //        LblEmpNo.Text = sepsess[3];
            //        LblPositionId.Text = sepsess[4];
            //        employeeNo = LblEmpNo.Text;
            //        //LblAppraisalPeriod.Text = appraisalPeriod;
            //        LblName.Text = empName;
            //        LblGroupDepartment.Text = empDept;
            //        LblGradeLevel.Text = empGradeLevel;
                   
            //        //sessionDimension(username);
            //        btnApprove.Visible = false;
            //        btnReview.Visible = false;
            //        btnSendToSupervisor.Visible = true;
                   
            //        ////////////////////////End display for the logged in guy///////////////////////
                    



            //    }
            //    else
            //    {

            //        lblStatus.Text = "Employee record not found";// +rst.ToString();
            //        lblStatus.ForeColor = System.Drawing.Color.Red;


            //    }
            //}
            //catch (Exception ex)
            //{
            //    lblStatus.Text = "Object Error: " + ex.Message;
            //    lblStatus.ForeColor = System.Drawing.Color.Red;
            //    //return;
            //}







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
            btnShowSubBCAppraisalForm.Text = "Show Subordinate BC Goal Settings";
            DDLSubName.Visible = true;
            LblSubName.Visible = true;

        }
        else if (countSubordinate == "0")
        {
            lblStatusSub.Text = "Your Subordinate(s) is/are not available, Please Continue";
            btnShowSubBCAppraisalForm.Text = "Show your BC Goal Settings";
            lblStatusSub.ForeColor = System.Drawing.Color.Red;
            DDLSubName.Visible = false;
            LblSubName.Visible = false;
            chkMyDetails.Visible = false;
        }


        PnlSub.Visible = true;
        PnlMain.Visible = false;

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Form: User " + username + " successfully views behavioural competencies page for Goal Settings Interface", "View");
            
            
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
       
       

       

       

    }//_Load
    
    
    //private void sessionDimension(string sessionDep)
    //{
    //    //String username = Session["usr"].ToString();
    //    /////////////////////////////////////////////////
    //    DataTable tablePhaseTwo = crudsbLL.getBCPhaseTwoList();
    //    GrdViewKPI.DataSource = tablePhaseTwo;
    //    GrdViewKPI.DataBind();
    //}
    //private string ConvertSortDirectionToSql(SortDirection sortDirection)
    //{
    //    string newSortDirection = String.Empty;

    //    switch (sortDirection)
    //    {
    //        case SortDirection.Ascending:
    //            newSortDirection = "ASC";
    //            break;

    //        case SortDirection.Descending:
    //            newSortDirection = "DESC";
    //            break;
    //    }

    //    return newSortDirection;
    //}
    //protected void GrdViewKPI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GrdViewKPI.PageIndex = e.NewPageIndex;
    //    GrdViewKPI.DataBind();
    //}//end _PageIndexChanging
    //protected void GrdViewKPI_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    DataTable dataTable = GrdViewKPI.DataSource as DataTable;

    //    if (dataTable != null)
    //    {
    //        DataView dataView = new DataView(dataTable);
    //        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

    //        GrdViewKPI.DataSource = dataView;
    //        GrdViewKPI.DataBind();
    //    }

    //}//end _Sorting
    //protected void GrdViewKPI_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    if (e.CommandName == "Select")
    //    {

    //        GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

    //        int RowIndex = gvr.RowIndex;

    //    }
    //}//_RowCommand
    ////protected void GrdViewKPI_RowDataBound(Object sender, GridViewRowEventArgs e)
    ////{
    ////    if (e.Row.RowType == DataControlRowType.DataRow)
    ////    {

    ////        decimal rowTotal = Convert.ToDecimal
    ////        (DataBinder.Eval(e.Row.DataItem, "WEIGHT"));
    ////        grdTotal = grdTotal + rowTotal;
    ////    }
    ////    if (e.Row.RowType == DataControlRowType.Footer)
    ////    {
    ////        Label lbl = (Label)e.Row.FindControl("WEIGHT");
    ////        decimal tot = grdTotal / 100;
    ////        lbl.Text = tot.ToString("P");
    ////        //lbl70.Text = "70.0%";
    ////        //lblWS.Text = "Weighted Score";
    ////        //lbl00First.Text = "0.0%";
    ////        //lbl00Second.Text = "0.0%";
    ////    }
    ////}//GrdViewKPI_RowDataBound
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
    //        Label lbl = (Label)e.Row.FindControl("lblTotalWeight");
    //        decimal tot = grdTotal / 100;
    //        lbl.Text = tot.ToString("P");
    //    }
    //}//GrdViewKPI_RowDataBound
    
   

 //   protected void btnSendToSupervisor_Click(object sender, EventArgs e)
 //   {
        
 //       string appraisalPeriod, monthValue;
 //       string holderSign, holderYear, holderMonth, holderDay;
 //       string holderDate, employeeNo;
 //         //18/3/2014
 //       if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
 //       {
 //           monthValue = "00" + ddlMonth.SelectedValue;
 //       }
 //       else
 //       {
 //           monthValue = "0" + ddlMonth.SelectedValue;
 //       }

 //       appraisalPeriod = ddlYear.SelectedValue + monthValue;
        
 //       bool emptyTextbox = false;
            

 //      foreach (Control c in this.Controls) 
 //   {

 //       if (c is TextBox) 
 //       {

 //       if (((TextBox)c).Text == string.Empty) 
 //           {
 //           //messagebox.show("Empty Textbox Found");
 //           emptyTextbox=true;
 //           ((TextBox)c).Focus();

 //           break; // TODO: might not be correct. Was : Exit For

 //       }

 //   }

 //   }

        

 //       if (emptyTextbox)
 //       {
 //           lblStatus.Text = "Please fill every empty necessary information";
 //           lblStatus.ForeColor = System.Drawing.Color.Red;
 //       }
 //       else
 //       {

           
 //          //////////////////////////////////////Clear box////////////////////////////////////////
 //           CleartextBoxes(this);
 //           ////////////////////////////////End Clear box///////////////////////////////////////////
           
 //           String username = Session["usr"].ToString();
 //           string supUsername="";
 //           string supEmail="";
 //           string supName="";
 //           //string senderName = LblHolderSignature.Text;
 //          // string senderName = holderSign;

 //           string rst = crudsbLL.getSupervisorInformation(username.Trim().ToLower());

 //           if (rst != string.Empty)
 //           {
 //               string[] sepsess = rst.Split('_');
 //               // content = reader["username"].ToString() + "_" + reader["email"].ToString() + "_" + reader["name"].ToString();
 //               supUsername = sepsess[0];
 //               supEmail = sepsess[1];
 //               supName  = sepsess[2];
                
 //            }
 //           else
 //           {

 //               lblStatus.Text = "You do not have a Supervisor";// +rst.ToString();
 //               lblStatus.ForeColor = System.Drawing.Color.Red;


 //           }

 //           string bcGSSendMail = BLLMail2Send.sendMail2SupervisorForBC(supEmail, supName, senderName);

 //}//end else test for empty

 //   }//btnSendToSupervisor_Click


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
   
    protected void rdoProfSupAlways_CheckedChanged(object sender, EventArgs e)
    {
        
        if (rdoProfSupAlways.Checked == true)
        {
            LblProfessionalism.Text = "4.3";
            lblIndProf.Text = "4.3";
            Session["supRatingProf"] = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();

            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
           
        }
        else 
        {

            LblProfessionalism.Text = "0.0";
            Session["supRatingProf"] = "0.0";

        }
    }
    protected void rdoProfSupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoProfSupRegular.Checked == true)
        {
            LblProfessionalism.Text = "3.4";
            lblIndProf.Text = "3.4";
            Session["supRatingProf"] = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";


            refillSession();
        }
        else
        {

            LblProfessionalism.Text = "0.0";
            Session["supRatingProf"] = "0.0";
        }
    }
    protected void rdoProfSupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoProfSupOften.Checked == true)
        {
            LblProfessionalism.Text = "2.6";
            lblIndProf.Text = "2.6";
            Session["supRatingProf"] = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblProfessionalism.Text = "0.0";
            Session["supRatingProf"] = "0.0";
        }
    }

    private void refillSession()
    {
        LblName.Text = Session["employeeName"].ToString();
        LblGradeLevel.Text = Session["gLevel"].ToString();
        LblGroupDepartment.Text = Session["dept"].ToString();
        LblAppraisalPeriod.Text = Session["appPeriod"].ToString();
        disableJHolderRadioButtons();
        PnlSub.Visible = false;
        PnlMain.Visible = true;
    }


    protected void rdoProfSupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoProfSupStimes.Checked == true)
        {
            LblProfessionalism.Text = "1.7";
            lblIndProf.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblProfessionalism.Text = "0.0";
            Session["supRatingProf"] = "0.0";
        }
    }
    protected void rdoProfSupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoProfSupRare.Checked == true)
        {
            LblProfessionalism.Text = "0.9";
            lblIndProf.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblProfessionalism.Text = "0.0";
            Session["supRatingProf"] = "0.0";
        }
    }
    protected void rdoComSupAlways_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoComSupAlways.Checked == true)
        {
            LblCommunication.Text = "4.3";
            lblIndComm.Text = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCommunication.Text = "0.0";
            Session["supRatingComm"] = "0.0";
        }
    }
    protected void rdoComSupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoComSupRegular.Checked == true)
        {
            LblCommunication.Text = "3.4";
            lblIndComm.Text = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCommunication.Text = "0.0";
            Session["supRatingComm"] = "0.0";
        }
    }
    protected void rdoComSupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoComSupOften.Checked == true)
        {
            LblCommunication.Text = "2.6";
            lblIndComm.Text = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCommunication.Text = "0.0";
            Session["supRatingComm"] = "0.0";
        }
    }
    protected void rdoComSupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoComSupStimes.Checked == true)
        {
            LblCommunication.Text = "1.7";
            lblIndComm.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCommunication.Text = "0.0";
            Session["supRatingComm"] = "0.0";
        }
    }
    protected void rdoComSupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoComSupRare.Checked == true)
        {
            LblCommunication.Text = "0.9";
            lblIndComm.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCommunication.Text = "0.0";
            Session["supRatingComm"] = "0.0";
        }
    }
    protected void rdoTeamSupAlways_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoTeamSupAlways.Checked == true)
        {
            LblTeamwork.Text = "4.3";
            lblIndTeam.Text = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblTeamwork.Text = "0.0";
            Session["supRatingTeam"] = "0.0";
        }
    }
    protected void rdoTeamSupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoTeamSupRegular.Checked == true)
        {
            LblTeamwork.Text = "3.4";
            lblIndTeam.Text = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblTeamwork.Text = "0.0";
            Session["supRatingTeam"] = "0.0";
        }
    }
    protected void rdoTeamSupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoTeamSupOften.Checked == true)
        {
            LblTeamwork.Text = "2.6";
            lblIndTeam.Text = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblTeamwork.Text = "0.0";
            Session["supRatingTeam"] = "0.0";
        }
    }
    protected void rdoTeamSupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoTeamSupStimes.Checked == true)
        {
            LblTeamwork.Text = "1.7";
            lblIndTeam.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblTeamwork.Text = "0.0";
            Session["supRatingTeam"] = "0.0";
        }
    }
    protected void rdoTeamSupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoTeamSupRare.Checked == true)
        {
            LblTeamwork.Text = "0.9";
            lblIndTeam.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblTeamwork.Text = "0.0";
            Session["supRatingTeam"] = "0.0";
        }
    }
    protected void rdoCCSupAlways_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCCSupAlways.Checked == true)
        {
            LblCustCentricity.Text = "4.3";
            lblIndCust.Text = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCustCentricity.Text = "0.0";
            Session["supRatingCust"] = "0.0";
        }
    }
    protected void rdoCCSupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCCSupRegular.Checked == true)
        {
            LblCustCentricity.Text = "3.4";
            lblIndCust.Text = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCustCentricity.Text = "0.0";
            Session["supRatingCust"] = "0.0";
        }
    }
    protected void rdoCCSupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCCSupOften.Checked == true)
        {
            LblCustCentricity.Text = "2.6";
            lblIndCust.Text = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCustCentricity.Text = "0.0";
            Session["supRatingCust"] = "0.0";
        }
    }
    protected void rdoCCSupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCCSupStimes.Checked == true)
        {
            LblCustCentricity.Text = "1.7";
            lblIndCust.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCustCentricity.Text = "0.0";
            Session["supRatingCust"] = "0.0";
        }

    }
    protected void rdoCCSupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoCCSupRare.Checked == true)
        {
            LblCustCentricity.Text = "0.9";
            lblIndCust.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblCustCentricity.Text = "0.0";
            Session["supRatingCust"] = "0.0";
        }

    }
    protected void rdoInnoSupAlways_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoInnoSupAlways.Checked == true)
        {
            LblInnovation.Text = "4.3";
            lblInno.Text = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblInnovation.Text = "0.0";
            Session["supRatingInno"] = "0.0";
        }
    }
    protected void rdoInnoSupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoInnoSupRegular.Checked == true)
        {
            LblInnovation.Text = "3.4";
            lblInno.Text = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblInnovation.Text = "0.0";
            Session["supRatingInno"] = "0.0";
        }
    }
    protected void rdoInnoSupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoInnoSupOften.Checked == true)
        {
            LblInnovation.Text = "2.6";
            lblInno.Text = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblInnovation.Text = "0.0";
            Session["supRatingInno"] = "0.0";
        }
    }
    protected void rdoInnoSupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoInnoSupStimes.Checked == true)
        {
            LblInnovation.Text = "1.7";
            lblInno.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblInnovation.Text = "0.0";
            Session["supRatingInno"] = "0.0";
        }
    }
    protected void rdoInnoSupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoInnoSupRare.Checked == true)
        {
            LblInnovation.Text = "0.9";
            lblInno.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblInnovation.Text = "0.0";
            Session["supRatingInno"] = "0.0";
        }
    }
    protected void rdoLeadSupAlways_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoLeadSupAlways.Checked == true)
        {
            LblLeadership.Text = "4.3";
            lblLead.Text = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblLeadership.Text = "0.0";
            Session["supRatingLead"] = "0.0";
        }
    }
    protected void rdoLeadSupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoLeadSupRegular.Checked == true)
        {
            LblLeadership.Text = "3.4";
            lblLead.Text = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblLeadership.Text = "0.0";
            Session["supRatingLead"] = "0.0";
        }
    }
    protected void rdoLeadSupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoLeadSupOften.Checked == true)
        {
            LblLeadership.Text = "2.6";
            lblLead.Text = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblLeadership.Text = "0.0";
            Session["supRatingLead"] = "0.0";
        }
    }
    protected void rdoLeadSupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoLeadSupStimes.Checked == true)
        {
            LblLeadership.Text = "1.7";
            lblLead.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblLeadership.Text = "0.0";
            Session["supRatingLead"] = "0.0";
        }
    }
    protected void rdoLeadSupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoLeadSupRare.Checked == true)
        {
            LblLeadership.Text = "0.9";
            lblLead.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblLeadership.Text = "0.0";
            Session["supRatingLead"] = "0.0";
        }
    }
    protected void rdoPESupAlways_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoPESupAlways.Checked == true)
        {
            LblPerEffect.Text = "4.3";
            lblPEffect.Text = "4.3";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblPerEffect.Text = "0.0";
            Session["supRatingPEE"] = "0.0";
        }
    }
    protected void rdoPESupRegular_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoPESupRegular.Checked == true)
        {
            LblPerEffect.Text = "3.4";
            lblPEffect.Text = "3.4";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblPerEffect.Text = "0.0";
            Session["supRatingPEE"] = "0.0";
        }
    }
    protected void rdoPESupOften_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoPESupOften.Checked == true)
        {
            LblPerEffect.Text = "2.6";
            lblPEffect.Text = "2.6";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblPerEffect.Text = "0.0";
            Session["supRatingPEE"] = "0.0";
        }
    }
    protected void rdoPESupStimes_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoPESupStimes.Checked == true)
        {
            LblPerEffect.Text = "1.7";
            lblPEffect.Text = "1.7";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {

            LblPerEffect.Text = "0.0";
            Session["supRatingPEE"] = "0.0";
        }
    }
    protected void rdoPESupRare_CheckedChanged(object sender, EventArgs e)
    {
        if (rdoPESupRare.Checked == true)
        {
            LblPerEffect.Text = "0.9";
            lblPEffect.Text = "0.9";
            double totalScore = Convert.ToDouble(LblProfessionalism.Text) + Convert.ToDouble(LblCommunication.Text) +
                Convert.ToDouble(LblTeamwork.Text) + Convert.ToDouble(LblCustCentricity.Text) + Convert.ToDouble(LblInnovation.Text) +
                Convert.ToDouble(LblLeadership.Text) + Convert.ToDouble(LblPerEffect.Text);
            LblTotalScore.Text = totalScore.ToString();
            lblTotalPerformanceScore.Text = totalScore.ToString() + "%";

            refillSession();
        }
        else
        {
            LblPerEffect.Text = "0.0";
            Session["supRatingPEE"] = "0.0";
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

    protected void  btnShowSubBCAppraisalForm_Click(object sender, EventArgs e)
     {
        String username = Session["usr"].ToString();
        string monthValue;
        string appraisalPeriod;
        string employeeNo;

        if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
        {
            monthValue = "00" + ddlMonth.SelectedValue;
        }
        else
        {
            monthValue = "0" + ddlMonth.SelectedValue;
        }

        appraisalPeriod = ddlYear.SelectedValue + monthValue;
        Session["apprPeriod"]=appraisalPeriod;
        //employeeNo = LblEmpNo.Text;
        //if (DDLSubName.Items.Count > 1)
       if (DDLSubName.Visible==true)
        {

            Session["visble"] = "Yes";
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
                    string subEmail;


                    try
                    {
                        //codes here
                        string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());

                        if (rst != string.Empty)
                        {
                            string[] sepsess = rst.Split('_');
                            empName = sepsess[0];
                            empDept = sepsess[1];
                            empGradeLevel = sepsess[2];
                            employeeNo = sepsess[3];
                            subEmail = sepsess[6]; 
                            LblName.Text = empName;
                            LblGroupDepartment.Text = empDept;
                            LblGradeLevel.Text = empGradeLevel;
                            //LblHolderSignature.Text = sepsess[0];
                            LblAppraisalPeriod.Text = appraisalPeriod;

                            Session["employeeName"] = empName;
                            Session["gLevel"] = empGradeLevel;
                            Session["dept"] = empDept;
                            Session["appPeriod"] = LblAppraisalPeriod.Text;
                            Session["empNo"] = employeeNo;
                            Session["usrname"] = empNoSess;
                            Session["mail"] = subEmail;
                        }
                        else
                        {

                            lblStatus.Text = "User record not found";// +rst.ToString();
                            lblStatus.ForeColor = System.Drawing.Color.Red;


                        }
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Object Error: " + ex.Message;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        //return;
                    }

                    
                    employeeNo = LblEmpNo.Text;
                   
                    PnlSub.Visible = false;
                    PnlMain.Visible = true;

                    disableJHolderRadioButtons();



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
                lblStatus.Text = "Object Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }//end if visible
        else 
        {

            Session["visble"] = "No";
           // DDLSubName.Enabled = false;
            ///////////////////////////display for the logged in guy/////////////////////////
            string empName;
            string empGradeLevel;
            string empDept;

            btnRateSubordinate.Text = "Rate yourself";
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


                    Session["employeeName"] = empName;
                    Session["gLevel"] = empGradeLevel;
                    Session["dept"] = empDept;
                    Session["appPeriod"] = appraisalPeriod;
                    Session["empNo"] = employeeNo;
                    Session["mail"] = sepsess[6]; 
                    Session["usrname"] =username;

                    //Session["appPeriod"] = LblAppraisalPeriod.Text;
                    //Session["empNo"] = employeeNo;

                //btnApprove.Visible = false;
                //btnReview.Visible = false;
           ////////////////////////End display for the logged in guy///////////////////////
            PnlSub.Visible = false;
            PnlMain.Visible = true;
            disableSupRadioButtons();




                }
                else
                {

                    lblStatusSub.Text = "Employee record not found";// +rst.ToString();
                    lblStatusSub.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Object Error: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;
                //return;
            }


            
        }//end else



    }//btnShowSubBCAppraisalForm_Click

    private void disableSupRadioButtons()
    {
        rdoProfSupAlways.Enabled = false;
        rdoProfSupRegular.Enabled = false;
        rdoProfSupOften.Enabled = false;
        rdoProfSupStimes.Enabled = false;
        rdoProfSupRare.Enabled = false;

        rdoComSupAlways.Enabled = false;
        rdoComSupRegular.Enabled = false;
        rdoComSupOften.Enabled = false;
        rdoComSupStimes.Enabled = false;
        rdoComSupRare.Enabled = false;

        rdoTeamSupAlways.Enabled = false;
        rdoTeamSupRegular.Enabled = false;
        rdoTeamSupOften.Enabled = false;
        rdoTeamSupStimes.Enabled = false;
        rdoTeamSupRare.Enabled = false;

        rdoLeadSupAlways.Enabled = false;
        rdoLeadSupRegular.Enabled = false;
        rdoLeadSupOften.Enabled = false;
        rdoLeadSupStimes.Enabled = false;
        rdoLeadSupRare.Enabled = false;

        rdoCCSupAlways.Enabled = false;
        rdoCCSupRegular.Enabled = false;
        rdoCCSupOften.Enabled = false;
        rdoCCSupStimes.Enabled = false;
        rdoCCSupRare.Enabled = false;

        rdoInnoSupAlways.Enabled = false;
        rdoInnoSupRegular.Enabled = false;
        rdoInnoSupOften.Enabled = false;
        rdoInnoSupStimes.Enabled = false;
        rdoInnoSupRare.Enabled = false;

        rdoPESupAlways.Enabled = false;
        rdoPESupRegular.Enabled = false;
        rdoPESupOften.Enabled = false;
        rdoPESupStimes.Enabled = false;
        rdoPESupRare.Enabled = false;


        TxtProfSupervisor.Enabled = false;
        TxtCommSupervisor.Enabled = false;
        TxtCCSupervisor.Enabled = false;
        TxtInnoSupervisor.Enabled = false;
        TxtLeadSupervisor.Enabled = false;
        TxtTeamSupervisor.Enabled = false;
        TxtPESupervisor.Enabled = false;
    }

    private void disableJHolderRadioButtons()
    {
        rdoJHProfAlways.Enabled = false;
        rdoJHProfRegular.Enabled = false;
        rdoJHProfOften.Enabled = false;
        rdoJHProfStimes.Enabled = false;
        rdoJHProfRare.Enabled = false;

        rdoCommAlways.Enabled = false;
        rdoCommRegular.Enabled = false;
        rdoCommOften.Enabled = false;
        rdoCommStimes.Enabled = false;
        rdoCommRare.Enabled = false;

        rdoTeamAlways.Enabled = false;
        rdoTeamRegular.Enabled = false;
        rdoTeamOften.Enabled = false;
        rdoTeamStimes.Enabled = false;
        rdoTeamRare.Enabled = false;

        rdoLeadAlways.Enabled = false;
        rdoLeadRegular.Enabled = false;
        rdoLeadOften.Enabled = false;
        rdoLeadStimes.Enabled = false;
        rdoLeadRare.Enabled = false;

        rdoCCAlways.Enabled = false;
        rdoCCRegular.Enabled = false;
        rdoCCOften.Enabled = false;
        rdoCCStimes.Enabled = false;
        rdoCCRare.Enabled = false;

        rdoInnoAlways.Enabled = false;
        rdoInnoRegular.Enabled = false;
        rdoInnoOften.Enabled = false;
        rdoInnoStimes.Enabled = false;
        rdoInnoRare.Enabled = false;

        rdoPEAlways.Enabled = false;
        rdoPERegular.Enabled = false;
        rdoPEOften.Enabled = false;
        rdoPEStimes.Enabled = false;
        rdoPERare.Enabled = false;

        TxtProfJHolder.Enabled = false; 
        TxtCommJHolder.Enabled = false;
        TxtCCJHolder.Enabled = false;
        TxtInnoJHolder.Enabled = false;
        TxtLeadJHolder.Enabled = false;
        TxtTeamJHolder.Enabled = false;
        TxtPEJHolder.Enabled = false;




    }//disableJHolderRadioButtons
    

    protected void btnRateSubordinate_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        string appraisalPeriod;
        string employeeNo;

        string supUsername = "";
        string supEmail = "";
        string supName = "";

        employeeNo = Session["empNo"].ToString();
        appraisalPeriod = Session["apprPeriod"].ToString();

        string profJHolderScore;
        string commJHolderScore;
        string leadJHolderScore;
        string teamJHolderScore;
        string ccJHolderScore;
        string peJHolderScore;
        string innoJHolderScore;

        string subName = LblName.Text;
        string mailToSub = Session["mail"].ToString();





        if (Session["visble"] == "Yes")
        {
            string countSubordinate = crudsbLL.getPositionsCount(username);

            if (countSubordinate.Equals("1"))
            {
                string rst = crudsbLL.getSupervisorInformation(Session["usrname"].ToString().Trim().ToLower());
                if (rst != string.Empty)
                {
                    string[] sepsess = rst.Split('_');
                    // content = reader["username"].ToString() + "_" + reader["email"].ToString() + "_" + reader["name"].ToString();
                    supUsername = sepsess[0];
                    supEmail = sepsess[1];
                    supName = sepsess[2];

                }
                else
                {

                    lblStatus.Text = "You do not have a Supervisor";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Red;


                }

                if (LblProfessionalism.Text == "0.0" || LblCommunication.Text == "0.0" || LblCustCentricity.Text == "0.0" ||
                    LblInnovation.Text == "0.0" || LblTeamwork.Text == "0.0" || LblLeadership.Text == "0.0" || LblPerEffect.Text == "0.0")
                {
                    lblStatus.Text = "Please rate your subordinate, one you need to select one of the rating!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string usr = crudsbLL.addOrUpdateBCAppraisalForm(employeeNo, appraisalPeriod, TxtProfSupervisor.Text, LblProfessionalism.Text,
                    TxtCommSupervisor.Text, LblCommunication.Text, TxtInnoSupervisor.Text, LblInnovation.Text, TxtLeadSupervisor.Text, LblLeadership.Text,
                    TxtCCSupervisor.Text, LblCustCentricity.Text, TxtPESupervisor.Text, LblPerEffect.Text, TxtTeamSupervisor.Text, LblTeamwork.Text);


                    string bcGSSendMail = BLLMail2Send.sendMail2Subordinate4BCAppForm(mailToSub, supName, subName);

                    if (usr == "10" && bcGSSendMail == "Sent")
                    {
                        
                        lblStatus.Text = "You have rated this employee before, the Subordinate Information has been successfully updated <i><strong>and notification sent!</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;

                    }
                    else if (usr == "10" && bcGSSendMail != "Sent")
                    {
                        lblStatus.Text = "You have rated this employee before, the Subordinate Information has been successfully updated,<i><strong> but notification cannot be sent at the moment, please connect to the company's network.</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (usr == "20" && bcGSSendMail == "Sent")
                    {
                        
                        lblStatus.Text = "You have successfully rated your subordinate <i><strong>and Notification sent!</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (usr == "20" && bcGSSendMail != "Sent")
                    {
                        lblStatus.Text = "You have successfully rated your subordinate <i><strong>but Notification cannot be sent at the moment! Contact Administrator!</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblStatus.Text = "<b><i>Whoa!</i></b> " + usr.ToString();// +rst.ToString();
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

            }//end if countsubordinate equals 1
        }
        else if (Session["visble"].Equals("No"))
        {

            // == "No"
            //mailToSub = Session["mail"].ToString();

            //calculateDimValues(profJHolderScore, commJHolderScore, leadJHolderScore, teamJHolderScore,
        //ccJHolderScore, peJHolderScore, innoJHolderScore);




            //////////////////////Professionalism////////////////////// 
            if (rdoJHProfAlways.Checked == true)
            {
                profJHolderScore = "4.3";
            }
            else if (rdoJHProfRegular.Checked == true)
            {
                profJHolderScore = "3.4";
            }
            else if (rdoJHProfOften.Checked == true)
            {
                profJHolderScore = "2.6";
            }
            else if (rdoJHProfStimes.Checked == true)
            {
                profJHolderScore = "1.7";
            }
            else if (rdoJHProfRare.Checked == true)
            {
                profJHolderScore = "0.9";
            }
            else
            {
                profJHolderScore = "0.0";
            }
            //////////////////////End Professionalism//////////////////////   




            //////////////////////Communication////////////////////// 
            //AROSR
            if (rdoCommAlways.Checked == true)
            {
                commJHolderScore = "4.3";
            }
            else if (rdoCommRegular.Checked == true)
            {
                commJHolderScore = "3.4";
            }
            else if (rdoCommOften.Checked == true)
            {
                commJHolderScore = "2.6";
            }
            else if (rdoCommStimes.Checked == true)
            {
                commJHolderScore = "1.7";
            }
            else if (rdoCommRare.Checked == true)
            {
                commJHolderScore = "0.9";
            }
            else
            {
                commJHolderScore = "0.0";
            }
            //////////////////////End Communication//////////////////////   

            //////////////////////Leadership////////////////////// 
            //AROSR
            if (rdoLeadAlways.Checked == true)
            {
                leadJHolderScore = "4.3";
            }
            else if (rdoLeadRegular.Checked == true)
            {
                leadJHolderScore = "3.4";
            }
            else if (rdoLeadOften.Checked == true)
            {
                leadJHolderScore = "2.6";
            }
            else if (rdoLeadStimes.Checked == true)
            {
                leadJHolderScore = "1.7";
            }
            else if (rdoLeadRare.Checked == true)
            {
                leadJHolderScore = "0.9";
            }
            else
            {
                leadJHolderScore = "0.0";
            }
            //////////////////////End Leadership////////////////////// 

            //////////////////////Innovation////////////////////// 
            //AROSR
            if (rdoInnoAlways.Checked == true)
            {
                innoJHolderScore = "4.3";
            }
            else if (rdoInnoRegular.Checked == true)
            {
                innoJHolderScore = "3.4";
            }
            else if (rdoInnoOften.Checked == true)
            {
                innoJHolderScore = "2.6";
            }
            else if (rdoInnoStimes.Checked == true)
            {
                innoJHolderScore = "1.7";
            }
            else if (rdoInnoRare.Checked == true)
            {
                innoJHolderScore = "0.9";
            }
            else
            {
                innoJHolderScore = "0.0";
            }
            //////////////////////End Innovation//////////////////////

            //////////////////////CC////////////////////// 
            //AROSR
            if (rdoCCAlways.Checked == true)
            {
                ccJHolderScore = "4.3";
            }
            else if (rdoCCRegular.Checked == true)
            {
                ccJHolderScore = "3.4";
            }
            else if (rdoCCOften.Checked == true)
            {
                ccJHolderScore = "2.6";
            }
            else if (rdoCCStimes.Checked == true)
            {
                ccJHolderScore = "1.7";
            }
            else if (rdoCCRare.Checked == true)
            {
                ccJHolderScore = "0.9";
            }
            else
            {
                ccJHolderScore = "0.0";
            }
            //////////////////////End CC//////////////////////

            //////////////////////Team////////////////////// 
            //AROSR
            if (rdoTeamAlways.Checked == true)
            {
                teamJHolderScore = "4.3";
            }
            else if (rdoTeamRegular.Checked == true)
            {
                teamJHolderScore = "3.4";
            }
            else if (rdoTeamOften.Checked == true)
            {
                teamJHolderScore = "2.6";
            }
            else if (rdoTeamStimes.Checked == true)
            {
                teamJHolderScore = "1.7";
            }
            else if (rdoTeamRare.Checked == true)
            {
                teamJHolderScore = "0.9";
            }
            else
            {
                teamJHolderScore = "0.0";
            }
            //////////////////////End Team//////////////////////
            //////////////////////PE////////////////////// 
            //AROSR
            if (rdoPEAlways.Checked == true)
            {
                peJHolderScore = "4.3";
            }
            else if (rdoPERegular.Checked == true)
            {
                peJHolderScore = "3.4";
            }
            else if (rdoPEOften.Checked == true)
            {
                peJHolderScore = "2.6";
            }
            else if (rdoPEStimes.Checked == true)
            {
                peJHolderScore = "1.7";
            }
            else if (rdoPERare.Checked == true)
            {
                peJHolderScore = "0.9";
            }
            else
            {
                peJHolderScore = "0.0";
            }
            //////////////////////End PE//////////////////////












            string usr = crudsbLL.addOrUpdateBCHolderAppraisalForm(employeeNo, appraisalPeriod, TxtProfJHolder.Text, profJHolderScore,
                TxtCommJHolder.Text, commJHolderScore, TxtInnoJHolder.Text, innoJHolderScore, TxtLeadJHolder.Text, leadJHolderScore,
                TxtCCJHolder.Text, ccJHolderScore, TxtPEJHolder.Text, peJHolderScore, TxtTeamJHolder.Text, teamJHolderScore);


            string bcGSSendMail = BLLMail2Send.sendMail2Sup4BCAppForm(mailToSub, supName, subName);

            if (usr == "10" && bcGSSendMail == "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "You have rated this yourself before, your Information has been successfully updated!<i><strong>and notification sent!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;

            }
            else if (usr == "10" && bcGSSendMail != "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "You have rated this yourself before, your Information has been successfully updated,<i><strong> but notification cannot be sent at the moment, please connect to the company's network.</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (usr == "20" && bcGSSendMail == "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "Your ratings have been successfully saved! <i><strong>and Notification sent!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (usr == "20" && bcGSSendMail != "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "Your ratings have been successfully saved! <i><strong>but Notification cannot be sent at the moment! Contact Administrator!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "<b><i>Whoa!</i></b> " + usr.ToString();// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }




        }//else if visible

                    
            //////////////////////////////////////Clear box////////////////////////////////////////
            CleartextBoxes(this);
            ////////////////////////////////End Clear box///////////////////////////////////////////

           
           
            
           

           
            
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




    }//btnRateSubordinate_Click

    public void calculateDimValues(string profJHolderScore, string commJHolderScore, string leadJHolderScore, string teamJHolderScore,
        string ccJHolderScore, string peJHolderScore, string innoJHolderScore) 
    { 
       
      
        
      //////////////////////Professionalism////////////////////// 
    if (rdoJHProfAlways.Checked == true)
        {
            profJHolderScore = "4.3";
        }
     else if (rdoJHProfRegular.Checked == true)
     {
         profJHolderScore = "3.4";
     }
     else if (rdoJHProfOften.Checked == true)
     {
         profJHolderScore = "2.6";
     }
     else if (rdoJHProfStimes.Checked == true)
     {
         profJHolderScore = "1.7";
     }
     else if (rdoJHProfRare.Checked == true)
     {
         profJHolderScore = "0.9";
     }
     else
     {
         profJHolderScore = "0.0";
     }
     //////////////////////End Professionalism//////////////////////   




     //////////////////////Communication////////////////////// 
     //AROSR
     if (rdoCommAlways.Checked == true)
     {
        commJHolderScore = "4.3";
     }
     else if (rdoCommRegular.Checked == true)
     {
         commJHolderScore = "3.4";
     }
     else if (rdoCommOften.Checked == true)
     {
         commJHolderScore = "2.6";
     }
     else if (rdoCommStimes.Checked == true)
     {
         commJHolderScore = "1.7";
     }
     else if (rdoCommRare.Checked == true)
     {
         commJHolderScore = "0.9";
     }
     else
     {
         commJHolderScore = "0.0";
     }
        //////////////////////End Communication//////////////////////   

     //////////////////////Leadership////////////////////// 
     //AROSR
     if (rdoLeadAlways.Checked == true)
     {
         leadJHolderScore = "4.3";
     }
     else if (rdoLeadRegular.Checked == true)
     {
         leadJHolderScore = "3.4";
     }
     else if (rdoLeadOften.Checked == true)
     {
         leadJHolderScore = "2.6";
     }
     else if (rdoLeadStimes.Checked == true)
     {
         leadJHolderScore = "1.7";
     }
     else if (rdoLeadRare.Checked == true)
     {
         leadJHolderScore = "0.9";
     }
     else
     {
         leadJHolderScore = "0.0";
     }
        //////////////////////End Leadership////////////////////// 

     //////////////////////Innovation////////////////////// 
     //AROSR
     if (rdoInnoAlways.Checked == true)
     {
         innoJHolderScore = "4.3";
     }
     else if (rdoInnoRegular.Checked == true)
     {
         innoJHolderScore = "3.4";
     }
     else if (rdoInnoOften.Checked == true)
     {
         innoJHolderScore = "2.6";
     }
     else if (rdoInnoStimes.Checked == true)
     {
         innoJHolderScore = "1.7";
     }
     else if (rdoInnoRare.Checked == true)
     {
         innoJHolderScore = "0.9";
     }
     else
     {
         innoJHolderScore = "0.0";
     }
        //////////////////////End Innovation//////////////////////

     //////////////////////CC////////////////////// 
     //AROSR
     if (rdoCCAlways.Checked == true)
     {
         ccJHolderScore = "4.3";
     }
     else if (rdoCCRegular.Checked == true)
     {
         ccJHolderScore = "3.4";
     }
     else if (rdoCCOften.Checked == true)
     {
         ccJHolderScore = "2.6";
     }
     else if (rdoCCStimes.Checked == true)
     {
         ccJHolderScore = "1.7";
     }
     else if (rdoCCRare.Checked == true)
     {
         ccJHolderScore = "0.9";
     }
     else
     {
         ccJHolderScore = "0.0";
     }
        //////////////////////End CC//////////////////////

     //////////////////////CC////////////////////// 
     //AROSR
     if (rdoCCAlways.Checked == true)
     {
         ccJHolderScore = "4.3";
     }
     else if (rdoCCRegular.Checked == true)
     {
         ccJHolderScore = "3.4";
     }
     else if (rdoCCOften.Checked == true)
     {
         ccJHolderScore = "2.6";
     }
     else if (rdoCCStimes.Checked == true)
     {
         ccJHolderScore = "1.7";
     }
     else if (rdoCCRare.Checked == true)
     {
         ccJHolderScore = "0.9";
     }
     else
     {
         ccJHolderScore = "0.0";
     }
        //////////////////////End CC//////////////////////
     //////////////////////PE////////////////////// 
     //AROSR
     if (rdoPEAlways.Checked == true)
     {
         peJHolderScore = "4.3";
     }
     else if (rdoPERegular.Checked == true)
     {
         peJHolderScore = "3.4";
     }
     else if (rdoPEOften.Checked == true)
     {
         peJHolderScore = "2.6";
     }
     else if (rdoPEStimes.Checked == true)
     {
         peJHolderScore = "1.7";
     }
     else if (rdoPERare.Checked == true)
     {
         peJHolderScore = "0.9";
     }
     else
     {
         peJHolderScore = "0.0";
     }
        //////////////////////End PE//////////////////////

    }//calculateDimValues
}