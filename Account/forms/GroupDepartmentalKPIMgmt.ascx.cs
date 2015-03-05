using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

public partial class Account_forms_GroupDepartmentalKPIMgmt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Group/Department KPI Info Management: User " + username + " successfully views Group/Departmental KPI Information management Interface", "View");

        DataTable table = crudsbLL.getKPIInfoTable();
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        Gridview1.Columns[0].Visible = false;
        Gridview1.Columns[2].Visible = false;

        refreshDepartmentDropDown();


        DDLKPIName.DataSource = crudsbLL.getKPINameDropDown();
        DDLKPIName.DataTextField = "KPI_NAME";
        DDLKPIName.DataValueField = "KPI_NAME";
        DDLKPIName.DataBind();
        DDLKPIName.Items.Insert(0, new ListItem("Select KPI Name", ""));


}
    private void refreshDepartmentDropDown()
    {
        DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLDepartments.DataTextField = "name";
        DDLDepartments.DataValueField = "id";
        DDLDepartments.DataBind();
        DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
    }//end refreshDepartmentDropDown
    private void refreshKPIInfoTable()
    {
        DataTable table = crudsbLL.getKPIInfoTable();
        Gridview1.DataSource = table;
        Gridview1.DataBind();
       // DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));

    }

    protected void btnUpdateKPIInfo_Click(object sender, EventArgs e)
    {
        string userID = Session["usr"].ToString();
        string kpiNameMsg = TxtKPIName.Text;
        string groupDeptIdMsg = groupDeptId.Value;
        string departmentMsg = DDLDepartments.SelectedValue;
        string kpiTypeMsg = DDLKPIType.SelectedValue;
        string deptFxnMsg = DDLDeptFxn.SelectedValue;

        if (TxtKPIName.Text == string.Empty)
        {
            lblStatus.Text = "Please Specify the KPI Name";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //if (DDLDepartments.DataTextField == "Select Department")
        
        //if (DDLKPIType.DataTextField == "Select KPI Type")
        if (string.IsNullOrEmpty(DDLKPIType.SelectedValue))
        {
            // DDLDepartments.Items.Insert(0, "Select Department");
            lblStatus.Text = "Please Specify the KPI Type";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
      //  if (DDLDeptFxn.DataTextField == "Select Departmental Fxn")
        if (string.IsNullOrEmpty(DDLDeptFxn.SelectedValue))
        {
            // DDLDepartments.Items.Insert(0, "Select Department");
            lblStatus.Text = "Please Specify the Departmental Fxn";
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

            string usr = crudsbLL.addOrUpdateGroupDeptKPI(userID, kpiNameMsg, groupDeptIdMsg, departmentMsg, kpiTypeMsg, deptFxnMsg);

            if (usr == "20")
            {
                int retLog = crudsbLL.saveAuditLog(userID, Request.UserHostAddress, "Group/Departmental KPIs Setup Management: User " + userID + " successfully added new Group/Departmental KPIS <i><strong>" + kpiNameMsg + "</i></strong>", "Create");
                lblStatus.Text = "KPI <i><strong>" + kpiNameMsg + "</strong></i> has been Successfully Added";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                TxtKPIName.Text = "";
                groupDeptId.Value = "";
                refreshKPIInfoTable();
                DDLKPIType.SelectedIndex = 0;
                DDLDeptFxn.SelectedIndex = 0;
                refreshDepartmentDropDown();
                //DDLDepartments.SelectedIndex = 0;
                //DDLKPIType.Items.Insert(0, "Select KPI Type");
                //DDLDeptFxn.Items.Insert(0, "Select Departmental Fxn");
                //DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));

            }
            else if (usr == "10")
            {
                int retLog = crudsbLL.saveAuditLog(userID, Request.UserHostAddress, "Group/Departmental KPIs Management: User " + userID + " successfully updated existing Group/Departmental KPI to <i><strong>" + kpiNameMsg + "</i></strong>", "Update");
                lblStatus.Text = "KPI  <i><strong>" + kpiNameMsg + "</strong></i> has been Successfully Updated";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                TxtKPIName.Text = "";
                groupDeptId.Value = "";

                refreshKPIInfoTable(); 
               // DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
                DDLKPIType.SelectedIndex = 0;
                DDLDeptFxn.SelectedIndex = 0;
                refreshDepartmentDropDown();
               // DDLDepartments.SelectedIndex = 0;
                //DDLKPIType.Items.Insert(0, "Select KPI Type");
                //DDLDeptFxn.Items.Insert(0, "Select KPI Kind");
               
            }
            else if (usr == "30")
            {
                lblStatus.Text = "Please specify another KPI Name, this already exists!";
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (DDLKPIName.SelectedIndex<=0 || DDLKPIName.SelectedValue=="")
        {
            lblStatus.Text = "Please Specify the KPI to search";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            
           
            //////////////////////////////
            string kpiValue = DDLKPIName.SelectedValue;
            DataTable table = crudsbLL.getKPIInfoTable(kpiValue);
            Gridview1.DataSource = table;
            Gridview1.DataBind();


            try
            {
                //codes here
                string rstDept = crudsbLL.getKPIPopulate(kpiValue);
                if (rstDept != string.Empty)
                {
                    lblStatus.Text = "KPI Name Found!";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                    string[] sepDept = rstDept.Split('_');
                    string kId = sepDept[0];
                    string kName = sepDept[1];
                    string dName = sepDept[2];
                    string kType = sepDept[3];
                    string kKind = sepDept[4];
                    string dId = sepDept[5];
                    
                    Session["kId"] = sepDept[0];
                    Session["kName"] = sepDept[1];
                    Session["dName"] = sepDept[2];
                    Session["kType"] = sepDept[3];
                    Session["kKind"] = sepDept[4];
                    Session["dId"] = sepDept[5];

                    TxtKPIName.Text = kName;
                    groupDeptId.Value = kId;
                    DDLDepartments.DataSource = crudsbLL.getDepartments();
                    DDLDepartments.DataTextField = "name";
                    DDLDepartments.DataValueField = "id";
                    DDLDepartments.DataBind();
                    DDLDepartments.Items.Insert(0, new ListItem(dName, dId));

                    DDLKPIType.SelectedItem.Text = kType;
                    DDLKPIType.SelectedValue = kType;
                    DDLDeptFxn.SelectedItem.Text = kKind;
                    DDLDeptFxn.SelectedValue = kKind;


                   
                }
                else
                {

                    lblStatus.Text = "KPI information not found!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;


                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error occurs while getting KPIName information: " + ex.Message;
                lblStatus.ForeColor = System.Drawing.Color.Red;

            }//catch






        }
    }
    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string grpDeptId = "";
        //string kpiName = "";
        //string deptName = "";
        //string ddpt = "";
        ////Session["usr"] = username;
        //grpDeptId = Gridview1.SelectedRow.Cells[2].Text;
        //kpiName = Gridview1.SelectedRow.Cells[3].Text;
        //deptName = Gridview1.SelectedRow.Cells[4].Text;

        //Session["gDI"] = grpDeptId;
        //Session["kpi"] = kpiName;
        //Session["dpt"] = deptName;
        //groupDeptId.Value = Session["gDI"].ToString();
        //TxtKPIName.Text = Session["kpi"].ToString();
        //DDLDepartments.Items.Insert(0, new ListItem(Session["dpt"].ToString(), Session["dpt"].ToString()));

        //////////////////////////////////////////////////////////////
       
        //////////////////////////////////////////////////////////////
        // DDLDepartments.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[5].Text, Gridview1.SelectedRow.Cells[5].Text));
        //DDLKPIType.SelectedValue = Gridview1.SelectedRow.Cells[4].Text;
        //DDLDeptFxn.SelectedValue = Gridview1.SelectedRow.Cells[5].Text;
       // DDLDepartments.SelectedValue = Gridview1.SelectedRow.Cells[6].Text;

        groupDeptId.Value = Gridview1.SelectedRow.Cells[2].Text;
        TxtKPIName.Text = Gridview1.SelectedRow.Cells[3].Text;
             DDLDepartments.DataSource = crudsbLL.getDepartments();
             DDLDepartments.DataTextField = "name";
             DDLDepartments.DataValueField = "id";
             DDLDepartments.DataBind();
        DDLDepartments.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[4].Text, Gridview1.SelectedRow.Cells[4].Text));
       // DDLKPIType.SelectedValue = Gridview1.SelectedRow.Cells[4].Text;
        DDLKPIType.SelectedValue = Gridview1.SelectedRow.Cells[5].Text;
        DDLDeptFxn.SelectedValue = Gridview1.SelectedRow.Cells[6].Text;
        //DDLKPIType.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[5].Text, Gridview1.SelectedRow.Cells[5].Text));
        //DDLDeptFxn.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[6].Text, Gridview1.SelectedRow.Cells[6].Text));

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


    protected void DDLDepartments_DataBound(object sender, EventArgs e)
    {
        DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
    }

}
