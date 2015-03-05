using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Security.Principal.IPrincipal;
//using System.Web
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;
//System.Web.Profile
using System.Web.Security;
//
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
//
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
//
using DAL;
using BLL;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

//namespace MyMasterPage
//{
public partial class Account_newSite : LoadingControlPath
    //public partial class Account_newSite : System.Web.UI.MasterPage
    {
       
    
        // public const string BASE_PATH = "";// "~/DynamicControlLoading/";
       // public string controlPath;//= string.Empty;
        
    
    
    //UpdatePanel1
        
        public void UpdatePanel1_PreRender(object sender, EventArgs e)
        {
            // This code will only be executed if the partial postback
            //  was raised by a __doPostBack('UpdatePanel1', '')
            if (Request["__EVENTTARGET"] == UpdatePanel1.ClientID)
            {
                // Insert magic here.
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //
            // Label1.Text = HttpContext.Context.User.Identity.Name;
            if (Session["usr"] == null)
            {
                Response.Redirect("~/login.aspx");//rtlHome.aspx...newPage.aspx
            }
            Label1.Text = Session["usr"].ToString();

            string user = Session["usr"].ToString();
            //
            // SendMailPane.Visible = false;

            //
            LoadUserControl();
            //
            //CheckAccess(user);
            verifyAccess(user);
            //
            //menu5.Visible = false;
            //menu1.Visible = false;
            //menu4.Visible = false;

            //
            string ipAddress = Request.UserHostAddress;
            string ipAddress2 = HttpContext.Current.Request.UserHostAddress;
            YearLabel.Text = DateTime.Now.Year.ToString();

        }
        //


        //
        private void verifyAccess(string username)
        {
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = Dalcs.PMSConnectionString;
            if (conn.State == ConnectionState.Closed)
                conn.Open();//re open if connection closed

            //string sql = "select * from  USER_SETUP where USERNAME=:v_username";

            string sql = "select A.USERNAME, B.ROLE_NAME, c.MENU_ALIAS from user_setup  a, ROLE_SETUP b, MENU_SETUP c, ASSIGN_MENU_ROLE d where b.id=d.ROLE_ID and C.ID=d.MENU_ID and a.ROLE_ID=b.id and lower(USERNAME)=:v_username";
            OracleCommand cmd = new OracleCommand(sql, conn);
            cmd.CommandType = CommandType.Text;


            cmd.Parameters.Add(":v_username", OracleDbType.Varchar2, 100).Value = username.ToLower().Trim();


            OracleDataReader reader;
            reader = cmd.ExecuteReader();
            string menuAlias;
            Boolean uPane=false;
            Boolean apPane=false;
            Boolean gPane=false;
            Boolean aFpane= false;
            Boolean aSPane =false;
            Boolean vGSPane =false;
            Boolean vAFPane =false;
            Boolean aPane =false; 
            Boolean rPane=false;
                        
            while (reader.Read())
            {
                menuAlias = reader["MENU_ALIAS"].ToString();

                if (menuAlias == "UserPane")
                    uPane = true;
           else if (menuAlias == "ApprPane")
                    apPane = true;
           else if (menuAlias == "GoalPane")
                    gPane = true;
           else if (menuAlias == "ApprFormPane")
                    aFpane = true;
           else if (menuAlias == "ApprSummaryPane")
                    aSPane = true;
           else if (menuAlias == "VGSettingsPane")
                    vGSPane = true;
           else if (menuAlias == "VAFormPane")
                    vAFPane = true;
           else if (menuAlias == "AuditPane")
                    aPane = true;
           else if (menuAlias == "ReportPane")
                    rPane = true;
                    
                //if (menuAlias == "GoalPane")
                //    UserPane.Visible = true;
                //else
                //    UserPane.Visible = false;

                
            }//end of while

            reader.Close();
            //
            conn.Close();

            UserPane.Visible = uPane;
            ApprPane.Visible = apPane;
            GoalPane.Visible = gPane;
            ApprFormPane.Visible = aFpane;
            ApprSummary.Visible = aSPane; 
            VGSettingsPane.Visible = vGSPane; 
            VAFormPane.Visible = vAFPane;
            AuditPane.Visible = aPane;
            ReportPane.Visible = rPane; 
            


        }//end of CheckAccess method






        //private void CheckAccess(string username)
        //{
        //    OracleConnection conn = new OracleConnection();
        //    conn.ConnectionString = Dalcs.PMSConnectionString;
        //    if (conn.State == ConnectionState.Closed)
        //        conn.Open();//re open if connection closed

        //    string sql = "select * from  USER_SETUP where USERNAME=:v_username";

        //    OracleCommand cmd = new OracleCommand(sql, conn);
        //    cmd.CommandType = CommandType.Text;


        //    cmd.Parameters.Add(":v_username", OracleDbType.Varchar2, 100).Value = username;


        //    OracleDataReader reader;
        //    reader = cmd.ExecuteReader();
        //    string usr_mg;
        //    string appr_mg;
        //    string goal_mg;
        //    string appr_form_mg;

        //    while (reader.Read())
        //    {
        //        usr_mg = reader["USER_MGT"].ToString();
        //        appr_mg = reader["APPRAISAL_MGT"].ToString();
        //        goal_mg = reader["GOAL_SETTINGS_MGT"].ToString();
        //        appr_form_mg = reader["APPR_SETTINGS_MGT"].ToString();
        //        //
        //        if (usr_mg == "1")
        //            UserPane.Visible = true;
        //        else
        //            UserPane.Visible = false;

        //        if (appr_mg == "1")
        //            ApprPane.Visible = true;
        //        else
        //            ApprPane.Visible = false;

        //        if (goal_mg == "1")
        //            GoalPane.Visible = true;
        //        else
        //            GoalPane.Visible = false;

        //        if (appr_form_mg == "1")
        //            ApprFormPane.Visible = true;
        //        else
        //            ApprFormPane.Visible = false;
        //        // }
        //    }//end of while
        //    reader.Close();
        //    //
        //    conn.Close();
        //    //
        //    //return created;

        //}//end of CheckAccess method


        //public string LastLoadedControl
        //{
        //    get
        //    {
        //        return ViewState["LastLoaded"] as string;
        //    }
        //    set
        //    {
        //        ViewState["LastLoaded"] = value;
        //    }
        //}


        //public void LoadUserControl()
        //{
        //    controlPath = LastLoadedControl;

        //    if (!string.IsNullOrEmpty(controlPath))
        //    {
        //        ContentPlaceHolder1.Controls.Clear();
        //        UserControl uc = (UserControl)LoadControl(controlPath);
        //        ContentPlaceHolder1.Controls.Add(uc);
        //    }
        //}
        
    
    protected void lnkMngGrpDptKPI_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Group/Departmental KPIs Section";
            //
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/GroupDepartmentalKPIMgmt.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkUserManager_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Users Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/userManager.ascx";
            //
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }

        //New Added
        protected void lnkMngJD_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Job Descriptions Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/JobDescriptionsMgmt.ascx";
            //
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkMngEmp_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Employees Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/EmployeesMgmt.ascx";
            //
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }

        protected void lnkMngPos_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Positions Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/PositionsMgmt.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkMngDpt_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Departments Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/DepartmentsMgmt.ascx";
            //
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }

        protected void lnkMngKPITmp_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "KPI Template Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/KPIPoolTemplate.ascx";
            //
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }

        protected void lnkMngKPI_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "KPI Management Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/userManager.ascx";
            //
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkMngAFPR_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Appraisal Forms Performance Results Management Section";
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/OriginalPResultApplicationForm.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();


            //lblPageTtile.Text = "Application Form Performance Results Management Section";
            //String username = Session["usr"].ToString();
            //string countSubordinate = crudsbLL.getPositionsCount(username);
            //if (countSubordinate == "1")
            //{
            //    Session["empNoSession"] = "";
            //    //controlPath = string.Empty;
            //    //controlPath = BASE_PATH + "~/Account/forms/LeadPResultApplicationForm.aspx";
            //    //LastLoadedControl = controlPath;
            //    //LoadUserControl();


            //    var response = base.Response;
            //    response.Redirect("~/Account/forms/LeadPResultApplicationForm.aspx", false);
            //}
            //else if (countSubordinate == "0")
            //{
            //    Session["empNoSession"] = "";
            //    //controlPath = string.Empty;
            //    //controlPath = BASE_PATH + "~/Account/forms/PResultApplicationForm.aspx";
            //    //LastLoadedControl = controlPath;
            //    //LoadUserControl();


            //    var response = base.Response;
            //    response.Redirect("~/Account/forms/PResultApplicationForm.aspx", false);
            //}




        }//lnkMngAFPR_Click
        protected void lnkMngAFBC_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Appraisal Form Behavioural Competencies Management Section";
            Session["empNoSession"] = "";
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/OriginalBCApplicationForm.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();
        }


        protected void lnkMngGSPR_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Goal Settings Performance Results Management Section";
            //String username = Session["usr"].ToString();
            //string countSubordinate = crudsbLL.getPositionsCount(username);
            //if (countSubordinate == "1")
            //{
            //    Session["empNoSession"] = "";
            //    controlPath = string.Empty;
            //    controlPath = BASE_PATH + "~/Account/forms/LeadtoPResultGoalSettings.ascx";
            //    LastLoadedControl = controlPath;
            //    LoadUserControl();
            //}
            //else if (countSubordinate == "0")
            //{
            //    Session["empNoSession"] = "";
            //    controlPath = string.Empty;
            //    controlPath = BASE_PATH + "~/Account/forms/PResultGoalSettings.ascx";
            //    LastLoadedControl = controlPath;
            //    LoadUserControl();
            //}


            //Session["empNoSession"] = "";
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/OriginalPResultGoalSettings.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();


            //else {

            //    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error! " + countSubordinate + "');", true);
            //    //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);
            //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Error! " + countSubordinate + "')", true);
            //    }

        }


        protected void lnkMngGSBC_Click(object sender, EventArgs e)
        {

            //lblPageTtile.Text = "Goal Settings Behavioural Competencies Management Section";
            //String username = Session["usr"].ToString();
            //string countSubordinate = crudsbLL.getPositionsCount(username);
            //if (countSubordinate == "1")
            //{
            //    Session["empNoSession"] = "";
            //    controlPath = string.Empty;
            //    controlPath = BASE_PATH + "~/Account/forms/LeadtoPResultGoalSettings.ascx";
            //    LastLoadedControl = controlPath;
            //    LoadUserControl();
            //}
            //else if (countSubordinate == "0")
            //{
            //    Session["empNoSession"] = "";
            //    controlPath = string.Empty;
            //    controlPath = BASE_PATH + "~/Account/forms/BCGoalSettings.ascx";
            //    LastLoadedControl = controlPath;
            //    LoadUserControl();
            //}

            lblPageTtile.Text = "Goal Settings Behavioural Competencies Management Section";
            Session["empNoSession"] = "";
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/OriginalBCGoalSettings.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();




        }//lnkMngGSBC

        //End New Added














        protected void lnkPersoForm_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Upload Credit Card Statement Customer";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/bulkupload.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }


        //protected void lnkRptDet_Click(object sender, EventArgs e)
        //{
        //    //reportDetails.ascx
        //    lblPageTtile.Text = "Monthly Detail Report Section";
        //    //WebUserControl.ascx
        //    //approveadj.ascx
        //    controlPath = string.Empty;
        //    //
        //    // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
        //    controlPath = BASE_PATH + "~/Account/forms/statementReport.ascx";
        //    //tabControl.ascx
        //    LastLoadedControl = controlPath;
        //    LoadUserControl();
        //}
        protected void lnkRptSummary_Click(object sender, EventArgs e)
        {
            //reportSummary.ascx
            //reportDetails.ascx
            lblPageTtile.Text = "View Report Summary Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/reportSummary.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkInvDet_Click(object sender, EventArgs e)
        {
            //InvoiceSum.ascx
            //reportSummary.ascx
            //reportDetails.ascx
            lblPageTtile.Text = "View Report Details Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/InvoiceDet.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
       
       
        
        protected void lnklogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            //
            Session.Clear();
            //
            Response.Redirect("~/login.aspx");//rtlHome.aspx...newPage.aspx


        }
        
        protected void lnkRoleMenus_Click(object sender, EventArgs e)
        {

            
            lblPageTtile.Text = "Role Assignment to Menus Section";
           
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/AssignMenuRole.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkStmtTrail_Click(object sender, EventArgs e)
        {
            //loginTrail.ascx
            lblPageTtile.Text = "Login Activities Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/loginTrail.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkAuditUpload_Click(object sender, EventArgs e)
        {
            //bulkUploadTrail.ascx
            lblPageTtile.Text = "Bulk Upload Trail Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/bulkUploadTrail.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkmthRpt_Click(object sender, EventArgs e)
        {
            //bulkUploadTrail.ascx
            lblPageTtile.Text = "Monthly Report Bulk Upload Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/up_monthlyReport.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkAlert_Click(object sender, EventArgs e)
        {
            //bulkUploadTrail.ascx
            lblPageTtile.Text = "Schedule Alerts Section";
            //WebUserControl.ascx
            //approveadj.ascx
            controlPath = string.Empty;
            //
            // controlPath = BASE_PATH + "~/Account/forms/WebUserControl.ascx";
            controlPath = BASE_PATH + "~/Account/forms/scheduleAlert.ascx";
            //tabControl.ascx
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkDefaulter_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Manage Defaulter Lists Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/manageDefaulters.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
            //
        }
        protected void lnkdefaulterlist_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Defaulter Lists Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/defaulter_report.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        

        protected void LnkDeptReport_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Department Report Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/DepartmentReport.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkVwGSPR_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "View Performance Result for Goal Settings Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ViewPResultGoalSettings.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkVwGSBC_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "View Behavioural Competencies for Goal Settings Section";
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/ViewBCGoalSettings.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();

        }//lnkVwGSBC_Click
        protected void lnkVwBCPR_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "View Performance Result For Appraisal Form Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ViewPResultApplicationForm.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkVwBCBC_Click(object sender, EventArgs e)
        {
             lblPageTtile.Text = "View Performance Result For Appraisal Form Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ViewBCApplicationForm.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkApprSummary_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Appraisal Summary Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/AppraisalSummary.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkUserRole_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Assign user to Role Section";
            controlPath = string.Empty;
            controlPath = BASE_PATH + "~/Account/forms/AssignUserToRole.ascx";
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkPositionReport_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Position Report";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ContainerPositionRpt.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();

        }//lnkPositionReport
        protected void lnkUserRoleReport_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "User Role Report";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ContainerUserRoleRpt.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkAuditTrail_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Audit Trail Section";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/AuditTrail.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkEmployeeReport_Click(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Employee Report";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ContainerEmployeeReport.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
        protected void lnkRptJD_Click1(object sender, EventArgs e)
        {
            lblPageTtile.Text = "Job Description Report";
            //
            controlPath = string.Empty;
            //
            controlPath = BASE_PATH + "~/Account/forms/ContainerJD.ascx";
            //
            LastLoadedControl = controlPath;
            LoadUserControl();
        }
}
//}