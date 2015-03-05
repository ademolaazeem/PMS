using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Account_forms_DepartmentsMgmt : System.Web.UI.UserControl
{
    string departmentValue = "";
    
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Department Management: User " + username + " successfully views Department management Interface", "View");

        DataTable table = crudsbLL.getDepartmentsList();
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        Gridview1.Columns[0].Visible = false;
        Gridview1.Columns[2].Visible = false;

        refreshDepartmentDropDown();
     }//end Page_Load

    private void refreshDepartmentDropDown()
    {
        DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLDepartments.DataTextField = "name";
        DDLDepartments.DataValueField = "name";
        DDLDepartments.DataBind();
        DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
    }//end refreshDepartmentDropDown
    private void refreshDepartmentList()
    {
        DataTable table = crudsbLL.getDepartmentsList();
        Gridview1.DataSource = table;
        Gridview1.DataBind();

        //DataSet ds = crudsbLL.getDSDepartmentsList();
        //Gridview1.DataSource = ds;
        //Gridview1.DataBind();

    }
    protected void btnUpdateDepartments_Click(object sender, EventArgs e)
    {
        string usernameMsg = Session["usr"].ToString();
        string departmentMsg = TxtDepartments.Text;
        string groupNameMsg = TxtGroupName.Text;
        string departmentIdMsg = departmentId.Value;

        if (TxtDepartments.Text == string.Empty)
        {
            lblStatus.Text = "Please Specify the Department Name";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (TxtGroupName.Text == string.Empty)
        {
            lblStatus.Text = "Please Specify the Group Name";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //add user permissions
        try
        {

            string usr = crudsbLL.addOrUpdateDepartments(usernameMsg, departmentMsg, groupNameMsg, departmentIdMsg);

            if (usr == "20")
            {
                String username = Session["usr"].ToString();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Department Management: User " + username + " successfully added new department: "
                    + departmentMsg, "Create");
                lblStatus.Text = "Department <i><strong>" + departmentMsg + "</strong></i> has been Successfully Added";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                TxtDepartments.Text = "";
                TxtGroupName.Text = "";
                departmentId.Value = null;
                refreshDepartmentDropDown();
                refreshDepartmentList();
                

            }
            else if (usr == "10")
            {
                String username = Session["usr"].ToString();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Department Management: User " + username + " successfully updated existing department to: "
                    + departmentMsg, "Update");
                lblStatus.Text = "Department <i><strong>" + departmentMsg + "</strong></i> has been Successfully Updated";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                TxtDepartments.Text = "";
                TxtGroupName.Text = "";
                departmentId.Value = null;
                refreshDepartmentList();
            }
            else if (usr == "30")
            {
                lblStatus.Text = "Please specify another Department Name, this already exists!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                lblStatus.Text = "Error: Operation failed " + usr.ToString();// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;

            }//end else usr
            //}//end checkUsername
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Object Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }
    protected void  btnSearchDeparment_Click(object sender, EventArgs e)
{
         if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
        {
            // DDLDepartments.Items.Insert(0, "Select Department");
            lblStatus.Text = "Please Specify the Department to search!";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
         else
        {
            departmentValue = DDLDepartments.SelectedValue;
            DataTable table = crudsbLL.getDepartmentsList(departmentValue);
            Gridview1.DataSource = table;
            Gridview1.DataBind();
            //DataTable table = crudsbLL.getPositionList(DDLSearchPosition.SelectedItem.ToString());
            //Gridview1.DataSource = table;
            //Gridview1.DataBind();


            try
            {
                //codes here
                string rstDept = crudsbLL.getDepartmentPopulate(departmentValue);
                if (rstDept != string.Empty)
                {
                    lblStatus.Text = "Department Found!";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    string[] sepDept = rstDept.Split('_');
                    string dId = sepDept[0];
                    string dName = sepDept[1];
                    string gName = sepDept[2];
                    
                    Session["dId"] = sepDept[0];
                    Session["dName"] = sepDept[1];
                    Session["gName"] = sepDept[2];
                    

                    TxtDepartments.Text = dName;
                    TxtGroupName.Text = gName;
                    departmentId.Value = dId;

                    DDLDepartments.DataSource = crudsbLL.getDepartments();
                    DDLDepartments.DataTextField = "name";
                    DDLDepartments.DataValueField = "name";
                    DDLDepartments.DataBind();
                    DDLDepartments.Items.Insert(0, new ListItem(dName, dId));

                   
                }
                else
                {

                    lblStatus.Text = "Position information not found!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error occurs while getting position information: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;

            }



       }//else
}//End btnSearchDepartment
    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {

       // if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
        if ((departmentValue==""))
        {
            departmentId.Value = Gridview1.SelectedRow.Cells[2].Text;
            TxtDepartments.Text = Gridview1.SelectedRow.Cells[3].Text;
            TxtGroupName.Text = Gridview1.SelectedRow.Cells[4].Text;

        }
        else
        {
            string dptId;
            string name;
            string grpName;
            string crtdBy;
            string crtdDt;

            try
            {
                //codes here
                string rst = crudsbLL.getDepartmentContent(departmentValue.Trim());
                if (rst != string.Empty)
                {
                    lblStatus.Text = "User record found";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    //
                    //authPanel.Visible = true;

                    //S[LIT CONTENT
                    string[] sepsess = rst.Split('_');
                    //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                    dptId = sepsess[0];
                    name = sepsess[1];
                    grpName = sepsess[2];
                    crtdBy = sepsess[3];
                    crtdDt = sepsess[4];
                    //display user record
                    departmentId.Value = dptId;
                    TxtDepartments.Text = name;
                    TxtGroupName.Text = grpName;
                    
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
        }//end else
    }//Gridview1_SelectedIndexChanged
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
    }//end _PageIndexChanging
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

       



    }//end _Sorting
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand


   
}