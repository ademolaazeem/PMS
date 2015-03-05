using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;

public partial class Account_forms_AssignMenuRole : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        DDLMenu.DataSource = crudsbLL.getMenus();
        DDLMenu.DataTextField = "NAME";
        DDLMenu.DataValueField = "ID";
        DDLMenu.DataBind();

        DDLRole.DataSource = crudsbLL.getRoles();
        DDLRole.DataTextField = "ROLE_NAME";
        DDLRole.DataValueField = "id";
        DDLRole.DataBind();
        DDLRole.Items.Insert(0, new ListItem("Select Role", ""));

        DataTable table = crudsbLL.getMenuRole();
        GrdMenuRole.DataSource = table;
        GrdMenuRole.DataBind();
         
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User " + username + " successfully Assign Menu to Role Interface", "View");

        

        GrdMenuRole.Columns[1].Visible = false;

    }
    
    protected void GrdMenuRole_SelectedIndexChanged(object sender, EventArgs e)
    {
        assignId.Value = GrdMenuRole.SelectedRow.Cells[1].Text;


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

    protected void GrdMenuRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdMenuRole.PageIndex = e.NewPageIndex;
        GrdMenuRole.DataBind();
    }//_PageIndexChanging

    protected void GrdMenuRole_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdMenuRole.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdMenuRole.DataSource = dataView;
            GrdMenuRole.DataBind();
        }
    }//end _Sorting







    protected void btnUpdateRoleMenu_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        string roleMsg = DDLRole.SelectedValue;
        string sup = "0";

        if (DDLMenu.SelectedIndex >= 0 && DDLRole.SelectedIndex >= 0)
        {
           string delRole = crudsbLL.deleteRolesMenus(roleMsg);

            foreach (ListItem item in DDLMenu.Items)
            {
                if (item.Selected)
                {
                    sup = crudsbLL.addOrUpdateRoleMenu(roleMsg, item.Value);

                }
            }//end foreach

            if(sup=="10") 
            {
                refreshDropDowns();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User " + username + " successfully updated assigned role to menus", "Update");
                lblStatus.Text = "Role assignment to Menus has been successfully updated";
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

            lblStatus.Text = "Please specify the role as well as the menus! Thank you!";// +rst.ToString();
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

    }

    private void refreshDropDowns()
    {

        DDLMenu.DataSource = crudsbLL.getMenus();
        DDLMenu.DataTextField = "NAME";
        DDLMenu.DataValueField = "ID";
        DDLMenu.DataBind();
        

        DDLRole.DataSource = crudsbLL.getRoles();
        DDLRole.DataTextField = "ROLE_NAME";
        DDLRole.DataValueField = "id";
        DDLRole.DataBind();
        DDLRole.Items.Insert(0, new ListItem("Select Role", ""));

        DataTable table = crudsbLL.getMenuRole();
        GrdMenuRole.DataSource = table;
        GrdMenuRole.DataBind();

    }//end refreshDropDowns


   
}