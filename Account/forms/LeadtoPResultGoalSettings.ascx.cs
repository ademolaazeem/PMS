using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Account_forms_LeadtoPResultGoalSettings : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Goal Settings: User " + username + " successfully views Managerial page for Goal Settings Interface");
        //DDLDepartments.Text = "Select Department";
        //DDLPositions.DataSource = crudsbLL.getPositions();
        DDLSubName.DataSource = crudsbLL.getSubordinateNameDropDown(username);
        DDLSubName.DataTextField = "NAME";
        DDLSubName.DataValueField = "USERNAME";
        DDLSubName.DataBind();
    }

    protected void btnShowSubPRGoalSettings_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
      //if (string.IsNullOrEmpty(DDLSubordinate.SelectedValue))
      //  {
      //      lblStatus.Text = "Please Specify the Subordinate!";
      //      lblStatus.ForeColor = System.Drawing.Color.Red;
      //      return;
      //  }
        if (string.IsNullOrEmpty(DDLSubName.SelectedValue))
        {
            lblStatus.Text = "Please Specify the Subordinate Name";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
       
        try
        {
            string countSubordinate = crudsbLL.getPositionsCount(username);
            if (countSubordinate.Equals("1"))
            {
                string subSelectedValue = DDLSubName.SelectedValue;
                Session["empNoSession"] = subSelectedValue.Trim();


                var response = base.Response;
                response.Redirect("PResultGoalSettings.ascx", false);
            }
            else 
            {
                lblStatus.Text = "Sorry you do not have subordinate(s)!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            
            }

        }
        catch (Exception ex)
        {
            lblStatus.Text = "Object Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

    }

    
    //protected void DDLPositions_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    string selectedValue = DDLSubName.SelectedValue;
    //    DDLSubordinate.DataSource = crudsbLL.getSubordinateInfoDropDown(selectedValue);
    //    DDLSubordinate.DataTextField = "name";
    //    DDLSubordinate.DataValueField = "EMPLOYEE_NO";
    //    DDLSubordinate.DataBind();
    //    DDLSubordinate.Items.Insert(0, new ListItem("Select Subordinate", ""));
    //}
   
}