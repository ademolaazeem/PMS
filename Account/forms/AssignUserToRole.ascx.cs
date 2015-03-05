using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Account_forms_AssignUserToRole : System.Web.UI.UserControl
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        //DDLUsername.DataSource = crudsbLL.getUsernameDropDown();
        //DDLUsername.DataTextField = "USERNAME";
        //DDLUsername.DataValueField = "USERNAME";
        //DDLUsername.DataBind();
        //DDLUsername.Items.Insert(0, new ListItem("Select Username", ""));

        //DDLRole.DataSource = crudsbLL.getRoles();
        //DDLRole.DataTextField = "ROLE_NAME";
        //DDLRole.DataValueField = "id";
        //DDLRole.DataBind();
        //DDLRole.Items.Insert(0, new ListItem("Select Role", ""));

        //DataTable table = crudsbLL.getUserRole();
        //GrdUserRole.DataSource = table;
        //GrdUserRole.DataBind();

        refreshDropDowns();
         
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User " + username + " successfully Assign Role to User Interface", "View");

        

        GrdUserRole.Columns[1].Visible = false;

    }
    
    protected void GrdUserRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        assignId.Value = GrdUserRole.SelectedRow.Cells[1].Text;


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
    }//end ConvertSortDirectionToSql

    protected void GrdUserRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdUserRole.PageIndex = e.NewPageIndex;
        GrdUserRole.DataBind();
    }//_PageIndexChanging

    protected void GrdUserRole_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdUserRole.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdUserRole.DataSource = dataView;
            GrdUserRole.DataBind();
        }
    }//end _Sorting







    protected void btnUpdateRoleMenu_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        
        string sup = "0";

        if (DDLUsername.SelectedIndex >= 0 && DDLRole.SelectedIndex >= 0)
        {
           string userMsg = DDLUsername.SelectedValue;
           string roleMsg = DDLRole.SelectedValue;
           sup = crudsbLL.addOrUpdateUserRole(userMsg, username, roleMsg);
           if(sup=="10") 
            {
                refreshDropDowns();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User " + username + " successfully updated user:"+userMsg+ "assigned role", "Update");
                lblStatus.Text = "User assignment to Role has been successfully updated";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (sup == "20")
            {
                refreshDropDowns();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User " + username + " successfully added user:" + userMsg + "assigned role", "Create");
                lblStatus.Text = "User assignment to Role has been successfully added";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (sup == "30")
            {
                lblStatus.Text = "Please specify another role, this already exists!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                lblStatus.Text = "Error: Operation failed " + sup.ToString();// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;

            }//end else usr
        }//end if
        else
        {

            lblStatus.Text = "Please specify the role as well as the User! Thank you!";// +rst.ToString();
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

    }

    private void refreshDropDowns()
    {

        DDLUsername.DataSource = crudsbLL.getUsernameDropDown();
        DDLUsername.DataTextField = "USERNAME";
        DDLUsername.DataValueField = "USERNAME";
        DDLUsername.DataBind();
        DDLUsername.Items.Insert(0, new ListItem("Select Username", ""));

        DDLRole.DataSource = crudsbLL.getRoles();
        DDLRole.DataTextField = "ROLE_NAME";
        DDLRole.DataValueField = "id";
        DDLRole.DataBind();
        DDLRole.Items.Insert(0, new ListItem("Select Role", ""));

        DataTable table = crudsbLL.getUserRole();
        GrdUserRole.DataSource = table;
        GrdUserRole.DataBind();

    }//end refreshDropDowns


    
}