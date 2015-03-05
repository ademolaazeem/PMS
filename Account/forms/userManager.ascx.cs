using System.Linq;
//
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
//using System.Web.Profile;
//using System.Web.Security;
using System.Web.Security;
using System.Web.Profile;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
//

//
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
//
using System.IO;
//

//using Oracle.Web.Profile.OracleProfileProvider;
using BLL;
using DAL;

public partial class Account_forms_userManager : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User "+username+" successfully views Usermanagement Interface", "View");

        refreshUserList();
        
        //ddBankList.Visible = false;
        //lblBanks.Visible = false;
        ////
        txtuser.DataSource = crudsbLL.getUsernameDropDown();
        txtuser.DataTextField = "USERNAME";
        txtuser.DataValueField = "USERNAME";
        txtuser.DataBind();
        txtuser.Items.Insert(0, new ListItem("Select Username", ""));


        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        
        //DDLPositions.Text = "Select Position";
        //

        DDLDepartment.DataSource = crudsbLL.getDepartments();
        DDLDepartment.DataTextField = "name";
        DDLDepartment.DataValueField = "id";
        DDLDepartment.DataBind();
        
        
        //string strName = "";
        //if (Session["usr"] == null)
        //{
        //    strName = Session["usr"].ToString();
        //}
        ////
        ////string strName = HttpContext.Current.User.Identity.Name.ToString();
        //lblstatus0.Text = strName;
        //
        Button1.Visible = false;
        //
        DateTime today = DateTime.Now;
        DateTime meetingAppt = new DateTime(today.Year, today.Month, today.Day, today.Hour, today.Minute, today.Second);
       // lblstatus0.Text = today.Day.ToString() + "" + today.Hour.ToString ();


       // btnUpdateProfile0.Visible = false;
    }

    private void refreshUserList()
    {
        DataTable table = crudsbLL.getUserlist();
        // table
        //
        Gridview1.DataSource = table;
        Gridview1.DataBind();
    
    }
    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // txtfname.Text = Gridview1.SelectedRow.Cells[1].Text;
       
        //txtuser.Text = Gridview1.SelectedRow.Cells[1].Text; 
        //DDLPositions.Text = Gridview1.SelectedRow.Cells[2].Text;
        //DDLDepartment.Text = Gridview1.SelectedRow.Cells[3].Text;

        //DDLPositions.SelectedValue = Gridview1.SelectedRow.Cells[2].Text;
        //DDLDepartment.SelectedValue = Gridview1.SelectedRow.Cells[3].Text;

        txtuser.DataSource = crudsbLL.getUsernameDropDown();
        txtuser.DataTextField = "USERNAME";
        txtuser.DataValueField = "USERNAME";
        txtuser.DataBind();
        //txtuser.Items.Insert(0, new ListItem("Select Username", ""));
        txtuser.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[1].Text, Gridview1.SelectedRow.Cells[1].Text));

        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        DDLPositions.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[2].Text, Gridview1.SelectedRow.Cells[2].Text));
        //DDLPositions.Text = "Select Position";
        //

        DDLDepartment.DataSource = crudsbLL.getDepartments();
        DDLDepartment.DataTextField = "name";
        DDLDepartment.DataValueField = "id";
        DDLDepartment.DataBind();
        DDLDepartment.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[3].Text, Gridview1.SelectedRow.Cells[3].Text));


        string selectedUsername = Gridview1.SelectedRow.Cells[1].Text;

        // if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
        if ((selectedUsername == ""))
        {
            lblstatus.Text = "No username selected";
            lblstatus.ForeColor = System.Drawing.Color.Red;
        }
        else
        {
            string brUsername;
            string usrMgt;
            string appMgt;
            string goalSettingsMgt;
            string apprSettingsMgt;
            string viewGoalSettings;
            string viewAppForm;

            try
            {
                //codes here
                string rst = crudsbLL.getUserContent(selectedUsername.Trim());
                if (rst != string.Empty)
                {
                   
                    string[] sepsess = rst.Split('_');
                    //content = reader["USERNAME"].ToString() + "_" + reader["USER_MGT"].ToString() + "_" + reader["APPRAISAL_MGT"].ToString() +
                    //"_" + reader["GOAL_SETTINGS_MGT"].ToString() + "_" + reader["APPR_SETTINGS_MGT"].ToString() + "_" + reader["VIEW_GOAL_SETTINGS"].ToString() + "_" + reader["VIEW_APP_FORM"].ToString();
                    brUsername = sepsess[0];
                    usrMgt = sepsess[1];
                    appMgt = sepsess[2];
                    goalSettingsMgt = sepsess[3];
                    apprSettingsMgt = sepsess[4];
                    viewGoalSettings = sepsess[5];
                    viewAppForm = sepsess[6];

                    if (usrMgt == "1")
                    {
                        chkAccess_user.Checked = true;
                    }
                    else {

                        chkAccess_user.Checked = false;
                    }//end usrMgt

                    if (appMgt == "1")
                    {
                        chkAccess_appraisal.Checked = true;
                    }
                    else
                    {

                        chkAccess_appraisal.Checked = false;
                    }//end appMgt
                    if (goalSettingsMgt == "1")
                    {
                        chkAccess_goal.Checked = true;
                    }
                    else
                    {

                        chkAccess_goal.Checked = false;
                    }//end goalSettingsMgt
                     if (apprSettingsMgt == "1")
                    {
                        chkAccess_beh.Checked = true;
                    }
                    else
                    {

                        chkAccess_beh.Checked = false;
                    }//end apprSettingsMgt



                     if (viewGoalSettings == "1")
                    {
                        chkAccess_v_goal_settings.Checked = true;
                    }
                    else
                    {

                        chkAccess_v_goal_settings.Checked = false;
                    }//end viewGoalSettings

                     if (viewAppForm == "1")
                    {
                        chkAccess_v_app_form.Checked = true;
                    }
                    else
                    {

                        chkAccess_v_app_form.Checked = false;
                    }//viewAppForm









                }
                else
                {

                    lblstatus.Text = "User record not found";// +rst.ToString();
                    lblstatus.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblstatus.Text = "Object Error: " + ex.Message;
                lblstatus.ForeColor = System.Drawing.Color.Red;
                //return;
            }
        }//end else










        
        
        
        
        //DDLKPIType.SelectedValue = Gridview1.SelectedRow.Cells[4].Text;
        //DDLDeptFxn.SelectedValue = Gridview1.SelectedRow.Cells[5].Text;
        //DDLDepartments.SelectedValue = Gridview1.SelectedRow.Cells[6].Text;


        //retrieve user profile: permissions
        //ProfileCommon profile = this.Profile;

        //profile = this.Profile.GetProfile(txtuser.Text);
        //chkAccess_user.Checked = profile.usermgt.usermgtRole;
        ////
        //chkAccess_adj.Checked =profile.Upload.UploadRole ;
        ////
        //chkAccess_ojc.Checked = profile.Report.ReportRole;
        ////
        //chkAccess_audit.Checked = profile.Compute.ComputeRole;
    }

    //
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

    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview1.PageIndex = e.NewPageIndex;
        Gridview1.DataBind();
    }

    protected void Gridview1_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = Gridview1.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            Gridview1.DataSource = dataView;
            Gridview1.DataBind();
        }
    }
    //
    protected void btnUpdateProfile_Click(object sender, EventArgs e)
    {
        //if (txtuser.Text == string.Empty)
        //{
        //    lblstatus.Text = "Enter Username";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //if (txtfName.Text  == string.Empty)
        //{
        //    lblstatus.Text = "Enter Full Name";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        //if (txtEmail.Text == string.Empty)
        //{
        //    lblstatus.Text = "Enter Email Address";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //    return;
        //}
        ////txtEmail
        //string bankfid="";
        //int bankfid_new = 0;

        //if (ddCategory.SelectedValue == "2")
        //{
        //    if (ddBankList.Visible == true)
        //    {

        //        bankfid = ddBankList.SelectedValue;
        //    }
        //    //else
        //    //{
        //    //    bankfid = "";
        //    //}
        //}
        //else
        //{
        //    bankfid_new = 1;
        //}
        
        //// defaultPassword = Membership.GeneratePassword(8, 2);
        ////
        //string  defaultPassword = Membership.GeneratePassword(8, 2);
        //int rst = crudsbLL.CreateUser(txtuser.Text, txtfName.Text, txtEmail.Text, ddCategory.SelectedValue, bankfid_new, Profile.UserName, defaultPassword);
        ////check for exsiting username
        //if (rst == 3)
        //{
        //    lblstatus.Text = "User: " + txtuser.Text + " already created";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;

        //    btnUpdateProfile0.Visible = true;
        //    btnUpdateProfile.Visible = false;
        //    return;//3;//duplicate username
        //}
        //if (rst == -1)
        //{
        //    ProfileCommon profile = this.Profile;
        //    profile = this.Profile.GetProfile(txtuser.Text);

        //    //cannot delete and modify current profile
        //    //if (Context.User.Identity.Name == txtuser.Text)
        //    // {
        //    //  lblstatus.Text = "You cannot modify current profile";
        //    //  lblstatus.ForeColor = System.Drawing.Color.Red;
        //    // return;
        //    //}
        //    //
        //    if (chkAccess_admin.Checked)
        //    {


        //        profile.usermgt.usermgtRole = chkAccess_user.Checked = true;
        //        //
        //        profile.Upload.UploadRole = chkAccess_adj.Checked = true;
        //        //
        //        profile.Report.ReportRole = chkAccess_ojc.Checked = true;
        //        //
        //        profile.Compute.ComputeRole = chkAccess_audit.Checked = true;

        //    }
        //    else
        //    {

        //        // profile.Admin.AdminRole = chkAccess_admin.Checked == true ? true : false;
        //        //
        //        profile.usermgt.usermgtRole = chkAccess_user.Checked == true ? true : false;
        //        //
        //        profile.Upload.UploadRole = chkAccess_adj.Checked == true ? true : false;
        //        //
        //        profile.Report.ReportRole = chkAccess_ojc.Checked == true ? true : false;
        //        //
        //        profile.Compute.ComputeRole = chkAccess_audit.Checked == true ? true : false;
        //        //
        //    }
        //    profile.Save();
        //    //
           
        //    //KEEP AUDIT LOG
        //    string action_performed = "PERMISSION GRANTED: ";
        //    //chkAccess_GeneralSetUpModule.Checked == true
        //    if (chkAccess_user.Checked == true)
        //        action_performed += "User Managements";
        //    else if (chkAccess_adj.Checked == true)
        //        action_performed += "Setup Data Module";
        //    else if (chkAccess_ojc.Checked == true)
        //        action_performed += "Process Module";
        //    else if (chkAccess_audit.Checked == true)
        //        action_performed += "Reports Module";
        //    else
        //        action_performed += "Admin Permission";

        //    userAuditBLL.Add_Permission(txtuser.Text, action_performed, Profile.UserName);
        //    //txtuser.Text, txtfName.Text, txtEmail.Text
        //    crudsbLL.SendEmailToUser(txtEmail.Text, txtuser.Text, defaultPassword, "Your account has been created ");
        //    lblstatus.Text = "Username Profile has been created";
        //    lblstatus.ForeColor = System.Drawing.Color.Blue;

        //    //RESET CONTROLS
        //    btnUpdateProfile0.Visible = false;
        //    btnUpdateProfile.Visible = true;
        //    //clear text boxes
        //}
        //else
        //{
        //    lblstatus.Text = "Error: Operation failed ";
        //    lblstatus.ForeColor = System.Drawing.Color.Red;
        //}
        ////
        
        //int audit= userAuditBLL.Add_Permission(txtuser.Text, action_performed, Profile.UserName);
        //if (audit == -1)
        //{
        //    lblstatus0.Text = audit.ToString();
        //}
        //
       
    }
    //protected void ddCategory_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddCategory.SelectedValue == "2")
    //    {
    //        ddBankList.Visible = true;
    //        lblBanks.Visible = true;
    //    }
    //}
    

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //txtuserSearch

        //DataTable table;
        //table = crudsbLL.customer_lists_all_users(txtuserSearch.Text);
        ////
        //Gridview1.DataSource = table;
        //Gridview1.DataBind();
        //
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        //try
        //{
        //    Response.Clear();
        //    Response.Buffer = true;
        //    Response.AddHeader("content-disposition", "attachment;filename=gridviewdata.xls");
        //    Response.Charset = "";
        //    Response.ContentType = "application/vnd.ms-excel";
        //    StringWriter sWriter = new StringWriter();
        //    HtmlTextWriter hWriter = new HtmlTextWriter(sWriter);
        //    Gridview1.RenderControl(hWriter);
        //    Response.Output.Write(sWriter.ToString());
        //    Response.Flush();
        //    Response.End();
        //}
        //catch (Exception ex)
        //{
        //    lblstatus.Text = ex.ToString();
        //}
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition",
        "attachment;filename=GridViewExport.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        Gridview1.AllowPaging = false;
        Gridview1.DataBind();

        //Change the Header Row back to white color
        Gridview1.HeaderRow.Style.Add("background-color", "#FFFFFF");

        //Apply style to Individual Cells
        Gridview1.HeaderRow.Cells[1].Style.Add("background-color", "green");
        Gridview1.HeaderRow.Cells[2].Style.Add("background-color", "green");
        Gridview1.HeaderRow.Cells[3].Style.Add("background-color", "green");
        Gridview1.HeaderRow.Cells[4].Style.Add("background-color", "green");

        for (int i = 0; i < Gridview1.Rows.Count; i++)
        {
            GridViewRow row = Gridview1.Rows[i];

            //Change Color back to white
            row.BackColor = System.Drawing.Color.White;

            //Apply text style to each Row
           row.Attributes.Add("class", "textmode");

            //Apply style to Individual Cells of Alternating Row
            if (i % 2 != 0)
            {
                row.Cells[0].Style.Add("background-color", "#C2D69B");
                row.Cells[1].Style.Add("background-color", "#C2D69B");
                row.Cells[2].Style.Add("background-color", "#C2D69B");
                row.Cells[3].Style.Add("background-color", "#C2D69B");
            }
        }
        Gridview1.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();

    }

    protected void btnUpdateProfileNow_Click(object sender, EventArgs e)
    {
        string userID = Session["usr"].ToString();
        //
        string user = "0";
        if (chkAccess_user.Checked == true)//? true : false;
            user = "1";
        //else
        string appraisal = "0";
        if (chkAccess_appraisal.Checked == true)//? true : false;
            appraisal = "1";

        //
        string goal = "0";
        if (chkAccess_goal.Checked == true)//? true : false;
            goal = "1";
        //else
        string beh = "0";
        if (chkAccess_beh.Checked == true)//? true : false;
            beh = "1";

        string vGoal = "0";
        if (chkAccess_v_goal_settings.Checked == true)//? true : false;
            vGoal = "1";

        string vApp = "0";
        if (chkAccess_v_app_form.Checked == true)//? true : false;
            vApp = "1";

        //
        if (txtuser.Text == string.Empty)
        {
            lblstatus.Text = "Enter Username";
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //add user permissions
        try
        {
            string chkUsername = crudsbLL.checkUsername(txtuser.Text);
            if (chkUsername == "-1")
            {
                lblstatus.Text = "The username you specified is not an Employee of this organization!";
                lblstatus.ForeColor = System.Drawing.Color.Red;
                return;

            }
            else
            {
                string usr = crudsbLL.addUserPermission(txtuser.Text, DDLPositions.SelectedValue, DDLDepartment.SelectedValue, user, appraisal, goal, beh, userID, vGoal, vApp);
                if (usr == "-1")
                {
                    lblstatus.Text = "Username Profile has been updated";
                    lblstatus.ForeColor = System.Drawing.Color.Blue;
                    refreshUserList();

                }
                else
                {
                    //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                    lblstatus.Text = "Error: Operation failed " + usr.ToString();// +rst.ToString();
                    lblstatus.ForeColor = System.Drawing.Color.Red;
                    return;

                }//end else usr
            }//end checkUsername
        }
        catch (Exception ex)
        {
            lblstatus.Text = "Object Error: " + ex.Message;
            lblstatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //
    }//end btnUpdateProfileNow_Click
   
}