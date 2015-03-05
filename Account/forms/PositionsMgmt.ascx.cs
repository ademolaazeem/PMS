using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Account_forms_PositionsMgmt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Positions Management: User " + username + " successfully views Position management Interface", "View");

        DataTable table = crudsbLL.getPositionList();
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        refreshDepartmentDropDown();
        Gridview1.Columns[2].Visible = false;
        Gridview1.Columns[5].Visible = false;
        
        ////DDLDepartments.Text = "Select Department";
        //DDLDepartments.DataSource = crudsbLL.getDepartments();
        //DDLDepartments.DataTextField = "name";
        //DDLDepartments.DataValueField = "id";
        //DDLDepartments.DataBind();
        ////DDLDepartments.Items.Insert(0, "Select Department");
        //DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));

    }//End Page_Load
    private void refreshDepartmentDropDown()
    {
        DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLDepartments.DataTextField = "name";
        DDLDepartments.DataValueField = "id";
        DDLDepartments.DataBind();
        DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));

        DDLSearchPosition.DataSource = crudsbLL.getPositions();
        DDLSearchPosition.DataTextField = "position";
        DDLSearchPosition.DataValueField = "position";
        //DDLSearchPosition.DataValueField = "id";
        DDLSearchPosition.DataBind();
        DDLSearchPosition.Items.Insert(0, new ListItem("Select Position", ""));
    }//end refreshDepartmentDropDown

   

    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        positionId.Value = Gridview1.SelectedRow.Cells[2].Text;
        TxtPositions.Text = Gridview1.SelectedRow.Cells[3].Text;
        
        DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLDepartments.DataTextField = "name";
        DDLDepartments.DataValueField = "id";
        DDLDepartments.DataBind();
        DDLDepartments.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[4].Text, Gridview1.SelectedRow.Cells[5].Text));

        if (Gridview1.SelectedRow.Cells[4].Text == string.Empty || Gridview1.SelectedRow.Cells[4].Text=="&nbsp;")
        {
            refreshDepartmentDropDown();
        }
        else
        {

            DDLDepartments.DataSource = crudsbLL.getDepartments();
            DDLDepartments.DataTextField = "name";
            DDLDepartments.DataValueField = "id";
            DDLDepartments.DataBind();
            DDLDepartments.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[4].Text, Gridview1.SelectedRow.Cells[5].Text));

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
    }//ConvertSortDirectionToSql


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

    protected void btnUpdatePositions_Click(object sender, EventArgs e)
    {
        string userID = Session["usr"].ToString();
        string positionMsg =TxtPositions.Text;
        string positionIdMsg = positionId.Value;
        string departmentMsg = DDLDepartments.SelectedValue;
        
        if (TxtPositions.Text == string.Empty)
        {
            lblStatus.Text = "Please Specify the Position";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
        {
            // DDLDepartments.Items.Insert(0, "Select Department");
            lblStatus.Text = "Please Specify the Department";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
       
        //add user permissions
        try
        {
           
            string usr = crudsbLL.addOrUpdatePositions(userID, positionMsg, positionIdMsg, departmentMsg); 
           
                if (usr == "20")
                {
                    int retLog = crudsbLL.saveAuditLog(userID, Request.UserHostAddress, "Positions Management: User " + userID + " successfully added new Position <i><strong>" + positionMsg + "</i></strong>", "Create");
                    lblStatus.Text = "Position <i><strong>" + positionMsg + "</strong></i> has been Successfully Added";
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    TxtPositions.Text = "";
                    positionId.Value = "";
                    refreshPositionList();
                    refreshDepartmentDropDown();
                   

                }
                else if (usr == "10")
                {
                    int retLog = crudsbLL.saveAuditLog(userID, Request.UserHostAddress, "Positions Management: User " + userID + " successfully updated existing Position to <i><strong>" + positionMsg + "</i></strong>", "Update");
                    lblStatus.Text = "Position <i><strong>" + positionMsg + "</strong></i> has been Successfully Updated";
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    TxtPositions.Text = "";
                    positionId.Value = "";
                    refreshPositionList();
                    refreshDepartmentDropDown();
                   // DDLDepartments.Items.Insert(0, "Select Department");
                }
                else if (usr == "30")
                {
                    lblStatus.Text = "Please specify another Position Name, this already exists!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    //TxtPositions.Text = "";
                   // refreshPositionList();
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

    private void refreshPositionList()
    {
        
            DataTable table = crudsbLL.getPositionList();
            Gridview1.DataSource = table;
            Gridview1.DataBind();
            DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
            //DDLDepartments.Items.Insert(0, "Select Department");
       
    
    }




    protected void btnSearchPosition_Click(object sender, EventArgs e)
    {
        if (DDLSearchPosition.SelectedIndex <= 0|| DDLSearchPosition.SelectedValue=="")
        {
            lblStatus.Text = "Please Select the Position to search";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            TxtPositions.Text = "";
            DataTable table = crudsbLL.getPositionList(DDLSearchPosition.SelectedItem.ToString());
            Gridview1.DataSource = table;
            Gridview1.DataBind();


            try
            {
                //codes here
                string rstDept = crudsbLL.getPositionPopulate(DDLSearchPosition.SelectedValue);
                if (rstDept != string.Empty)
                {
                    lblStatus.Text = "Position Found!";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    string[] sepDept = rstDept.Split('_');
                    string pId = sepDept[0];
                    string pName = sepDept[1];
                    string dName = sepDept[2];
                    string dId = sepDept[3];

                    Session["pId"] = sepDept[0];
                    Session["pName"] = sepDept[1];
                    Session["dName"] = sepDept[2];
                    Session["dId"] = sepDept[3];

                    TxtPositions.Text = pName;
                    
                    DDLDepartments.DataTextField = "name";
                    DDLDepartments.DataValueField = "id";
                    DDLDepartments.DataBind();
                    DDLDepartments.Items.Insert(0, new ListItem(dName, dId));

                    //DDLDepartments.DataTextField = dName;
                    positionId.Value=pId;
                    deptId.Value = dId;
                    TxtPositions0.Text = "PositionId: " + positionId.Value + " departmentID:" + deptId.Value;
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

        }
    }


  
}