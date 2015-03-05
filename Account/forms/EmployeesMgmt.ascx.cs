using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Text.RegularExpressions;
using System.Data;

public partial class Account_forms_EmployeesMgmt : System.Web.UI.UserControl
{
    string employeeValue = "";

    public string EmployeeValue
    {
        get { return employeeValue; }
        set { employeeValue = value; }
    }

    //public string EmployeeValue
    //{
    //    get { return employeeValue; }
    //    set { employeeValue = value; }
    //}
    
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["emp"] = "";
        String username = Session["usr"].ToString();       
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Employee Management: User " + username + " successfully views Employee Management Interface", "View");

        //if (!IsPostBack)
        //{
        //DDLPositions.Text = "Select Positions";
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        //}


       //// if (!IsPostBack)
       //// {
       //     //DDLDepartments.Text = "Select Department";
       //     DDLDepartments.DataSource = crudsbLL.getDepartments();
       //     DDLDepartments.DataTextField = "name";
       //     DDLDepartments.DataValueField = "id";
       //     DDLDepartments.DataBind();

       // //}


            DDLUsername.DataSource = crudsbLL.getUsernameDropDown();
            DDLUsername.DataTextField = "USERNAME";
            DDLUsername.DataValueField = "EMPLOYEE_NO";
            DDLUsername.DataBind();
            DDLUsername.Items.Insert(0, new ListItem("Select Username", ""));
        
        refreshEmpl();
        refreshEmployeeDropDown();


     


    }//page_load


    private void refreshEmpl()
    {
        DataTable table = crudsbLL.getEmployees();
        Gridview1.DataSource = table;
        Gridview1.DataBind();
        DDLUsername.Items.Insert(0, new ListItem("Select Username", ""));
        DDLPositions.Items.Insert(0, new ListItem("Select Positions", ""));
   }//end refreshEmpl

    private void refreshEmployeeDropDown()
    {

        DDLEmployee.DataSource = crudsbLL.getEmployeeDropDown();
        DDLEmployee.DataTextField = "name";
        //+" (" + "employee_no" + ")";
        DDLEmployee.DataValueField = "employee_no";
        DDLEmployee.DataBind();
        DDLEmployee.Items.Insert(0, new ListItem("Select Employee", ""));
    }//end refreshDepartmentDropDown



    protected void btnRefreshDb_Click(object sender, EventArgs e)
    {
        refreshEmployeeList();
        refreshEmpl();
        return;
    }

    
    private void refreshEmployeeList()
    {
        string loggedInUser = Session["usr"].ToString();
            
        List<EmployeeRequest> empList;
        empList = crudsbLL.getEmployeeLists();
         //List<EmployeeRequest> empList = new List<EmployeeRequest>();
            foreach(EmployeeRequest empRq in empList)
            {
                string empName=empRq.EMPLOYEE_SURNAME + " " + empRq.EMPLOYEE_OTHERNAMES;
                Match empUsernameMsg = Regex.Match(empRq.EMAIL, @"^.*?(?=@)");
                string saveEmp = crudsbLL.addOrUpdateEmpRcdFromHM(empRq.EMPLOYEE_NO, empName, empRq.GRADE_LEVEL, empRq.EMAIL,
                    empUsernameMsg.ToString(), loggedInUser, empRq.EMPLOYMENT_DATE);
                if (saveEmp.Equals("20") || saveEmp.Equals("10"))
                {

                    lblStatus.Text = "Employees information Successfully Updated";
                    lblStatus.ForeColor = System.Drawing.Color.Blue;
                }
                else
                {
                    lblStatus.Text = "Error: Operation failed " + saveEmp.ToString();// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                    break;
                
                }
            }
           
    
    }

    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
       // string empValue = "";
        
       //if ((empValue == ""))
       // {
       //     lblStatus.Text = "Employee: <i><strong>" + Gridview1.SelectedRow.Cells[3].Text +" </strong></i> has been selected!";// +rst.ToString();
       //     lblStatus.ForeColor = System.Drawing.Color.Blue;
       //     employeeId.Value = Gridview1.SelectedRow.Cells[2].Text;
       //     DDLPositions.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[4].Text, Gridview1.SelectedRow.Cells[4].Text));
       //     //DDLDepartments.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[5].Text, Gridview1.SelectedRow.Cells[5].Text));


       //     //departmentId.Value = Gridview1.SelectedRow.Cells[2].Text;
       //     //TxtDepartments.Text = Gridview1.SelectedRow.Cells[3].Text;
       //     //TxtGroupName.Text = Gridview1.SelectedRow.Cells[4].Text;

       // }
       // else
       // {
       //     string empId;
       //     string empName;
       //     //string deptId;
       //    try
       //     {
       //         //codes here
       //         string rst = crudsbLL.getEmployeeContent(empValue.Trim());
                
       //         if (rst != string.Empty)
       //         {
       //             lblStatus.Text = "Employee Record found";// +rst.ToString();
       //             lblStatus.ForeColor = System.Drawing.Color.Blue;
       //             string[] sepsess = rst.Split('_');
       //             //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
       //             empId = sepsess[0];
       //             empName = sepsess[1];
                   
       //             //display user record
       //             employeeId.Value = empId;
       //             lblStatus.Text = "Employee with Name: <i><strong>"+ empName + " </strong></i> has been selected!";
       //             //TxtGroupName.Text = grpName;

       //         }
       //         else
       //         {

       //             lblStatus.Text = "Employee Record not found";// +rst.ToString();
       //             lblStatus.ForeColor = System.Drawing.Color.Red;


       //         }
       //     }
       //     catch (Exception ex)
       //     {
       //         lblStatus.Text = "Object Error: " + ex.Message;
       //         lblStatus.ForeColor = System.Drawing.Color.Red;
       //         //return;
       //     }
       // }//end else


       // //Session["emp"]="";






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

    protected void btnUpdateEmployees_Click(object sender, EventArgs e)
    {
              
       // string match = crudsbLL.checkMatchingPositionDepartment(positionMsg, departmentMsg);
        if (DDLPositions.SelectedIndex <= 0)
        {
            lblStatus.Text = "Please Specify the Position";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
        if (hDeptId.Value == "")
        {
            lblStatus.Text = "Please Department is not Specified";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        // string positionMsg = DDLPositions.SelectedValue;
        //if (match.Equals("0"))
        //{
        //    lblStatus.Text = "The Department you selected: <i><strong>" + DDLDepartments.SelectedItem + "</strong></i> does not contain the Position: <i><strong>"
        //        + DDLPositions.SelectedItem + " </strong></i> please select matching department and Position.";
        //    lblStatus.ForeColor = System.Drawing.Color.Red;
        //    refreshPositionDept();
        //    return;
        //}
        //add user permissions
        try
        {
            string userID = Session["usr"].ToString();
            string employeeNoMsg = DDLUsername.SelectedValue;
            string positionMsg = DDLPositions.SelectedValue;
            string departmentMsg = Session["dId"].ToString();
            string usr = crudsbLL.updateEmployees(userID, employeeNoMsg, positionMsg, departmentMsg);
            if (usr == "20")
            {
                lblStatus.Text = "Please select the Employee, no employee is selected";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                refreshPositionDept();



            }
            else if (usr == "10")
            {
                String username = Session["usr"].ToString();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Employee Management: User " + username + " successfully updated Employee with Employee No: "
                    + employeeNoMsg, "Update");

                lblStatus.Text = "Employee information has been Successfully Updated";
                lblStatus.ForeColor = System.Drawing.Color.Blue;

                // TxtPositions.Text = "";
                refreshPositionDept();
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

    //protected void btnUpdateEmployees_Click(object sender, EventArgs e)
    //{
    //    string userID = Session["usr"].ToString();
    //    //string employeeNoMsg = employeeId.Value;
    //    string positionMsg = DDLPositions.SelectedValue;
    //    string departmentMsg = DDLDepartments.SelectedValue;
    //    string employeeNoMsg = DDLUsername.SelectedValue;

    //    //string deptMsg = DDLDepartments.SelectedValue;
    //    string match = crudsbLL.checkMatchingPositionDepartment(positionMsg, departmentMsg); 
    //    if (DDLPositions.SelectedIndex <= 0)
    //    {
    //        lblStatus.Text = "Please Specify the Position";
    //        lblStatus.ForeColor = System.Drawing.Color.Red;
    //        return;
    //    }
    //    //if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
    //    if (DDLDepartments.SelectedIndex <= 0)
    //    {
    //        lblStatus.Text = "Please Specify the Department";
    //        lblStatus.ForeColor = System.Drawing.Color.Red;
    //        return;
    //    }
    //   // string positionMsg = DDLPositions.SelectedValue;
        
    //    if (match.Equals("0"))
    //    {
    //        lblStatus.Text = "The Department you selected: <i><strong>" + DDLDepartments.SelectedItem + "</strong></i> does not contain the Position: <i><strong>"
    //            + DDLPositions.SelectedItem + " </strong></i> please select matching department and Position.";
    //        lblStatus.ForeColor = System.Drawing.Color.Red;
    //        refreshPositionDept();
    //        return;
    //    }
    //    //add user permissions
    //    try
    //    {

    //        string usr = crudsbLL.updateEmployees(userID, employeeNoMsg, positionMsg, departmentMsg);

    //        if (usr == "20")
    //        {
    //            lblStatus.Text = "Please select the Employee, no employee is selected";
    //            lblStatus.ForeColor = System.Drawing.Color.Red;
    //            refreshPositionDept();
               
                

    //        }
    //        else if (usr == "10")
    //        {
    //            String username = Session["usr"].ToString();
    //            int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Employee Management: User " + username + " successfully updated Employee with Employee No: "
    //                +employeeNoMsg, "Update");

    //            lblStatus.Text = "Employee information has been Successfully Updated";
    //            lblStatus.ForeColor = System.Drawing.Color.Blue;

    //           // TxtPositions.Text = "";
    //            refreshPositionDept();
    //        }
    //        else
    //        {
    //            //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
    //            lblStatus.Text = "Error: Operation failed " + usr.ToString();// +rst.ToString();
    //            lblStatus.ForeColor = System.Drawing.Color.Red;
    //            return;

    //        }//end else usr
    //        //}//end checkUsername
    //    }
    //    catch (Exception ex)
    //    {
    //        lblStatus.Text = "Object Error: " + ex.Message;
    //        lblStatus.ForeColor = System.Drawing.Color.Red;
    //        return;
    //    }
    //}


    public void refreshPositionDept()
    {
        //////////////////////////////////////////////////////////
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        txtDepartment.Text = "";
        
        DDLUsername.DataSource = crudsbLL.getUsernameDropDown();
        DDLUsername.DataTextField = "USERNAME";
        DDLUsername.DataValueField = "EMPLOYEE_NO";
        DDLUsername.DataBind();
        DDLUsername.Items.Insert(0, new ListItem("Select Username", ""));
        //////////////////////////////////////////////////////////

        refreshEmpl();
    
    }
   



    protected void btnSearchEmployee_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(DDLEmployee.SelectedValue))
        {
            // DDLDepartments.Items.Insert(0, "Select Department");
            lblStatus.Text = "Please Specify the Employee to search!";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        else
        {
            Session["emp"] = DDLEmployee.SelectedValue;
            employeeValue = Session["emp"].ToString();
            
            
            //employeeValue = DDLEmployee.SelectedValue;
            //Session["emp"] = employeeValue;
           // DataTable table = crudsbLL.getEmployeeTableList(Session["emp"].ToString());
            DataTable table = crudsbLL.getEmployeeTableList(employeeValue);
            //DataTable table = crudsbLL.getDepartmentsList(employeeValue);
            Gridview1.DataSource = table;
            Gridview1.DataBind();
        }
    }

    protected void DDLPositions_SelectedIndexChanged(object sender, EventArgs e)
    {
                    string selectedValue = DDLPositions.SelectedValue;
                    string deptId;
                    string deptName;
                  try
                    {
                        //codes here
                        string rstDept = crudsbLL.getDepartmentFromPosition(selectedValue);
                        if (rstDept != string.Empty)
                        {
                            lblStatus.Text = "Department found for the the position selected!";// +rst.ToString();
                            lblStatus.ForeColor = System.Drawing.Color.Blue;
                            string[] sepDept = rstDept.Split('_');
                            deptId = sepDept[0];
                            deptName = sepDept[1];
                            Session["dId"]=sepDept[0];
                            Session["dName"] = sepDept[1];
                            txtDepartment.Text = sepDept[1];
                            hDeptId.Value = deptId;
                        }
                        else
                        {

                            lblStatus.Text = "Department not found, please assign a department to the position selected before continue!";
                            lblStatus.ForeColor = System.Drawing.Color.Red;


                        }
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = "Error occurs while getting department information: " + ex.Message;
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        
                    }





         
        
    
    }
}
