using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Text.RegularExpressions;

public partial class Account_forms_KPIPoolTemplate : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            FillDepartment();
        //}
        String username = Session["usr"].ToString();

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "KPI Pool Template Management: User " + username + " successfully views KPI Pool Template Management Interface", "View");
        
       
       // DataTable table = crudsbLL.getDepartmentsList();
        DataTable table = crudsbLL.getKPIPoolTemplateTable();
        Gridview1.DataSource = table;
        Gridview1.DataBind();

       
        refreshPositionKPIDropDown();
        
        for (int count = 10; count <= 60; count = count + 10)
        {
            DDLImpFactor.Items.Insert(0, new ListItem(count.ToString(), count.ToString()));
        
       }//end for
      DDLImpFactor.Items.Insert(0, new ListItem("Select Important Factor", ""));

        //Start make invisible those that are not useful to see
        Gridview1.Columns[2].Visible = false;
        Gridview1.Columns[3].Visible = false;
        Gridview1.Columns[4].Visible = false;
        Gridview1.Columns[5].Visible = false;
        Gridview1.Columns[6].Visible = false;
        Gridview1.Columns[7].Visible = false;
        Gridview1.Columns[8].Visible = false;
        Gridview1.Columns[9].Visible = false;
        Gridview1.Columns[10].Visible = false;
        Gridview1.Columns[11].Visible = false;
        Gridview1.Columns[12].Visible = false;
        Gridview1.Columns[13].Visible = false;
        Gridview1.Columns[18].Visible = false;
        //End Start make invisible those that are not useful to see


    }

    private void FillDepartment()
    {
        
            DDLDepartments.DataSource = crudsbLL.getDepartments();
            DDLDepartments.DataTextField = "name";
            DDLDepartments.DataValueField = "id";
            DDLDepartments.DataBind();
            DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
        
    
    }
    private void refreshPositionKPIDropDown()
    {
        DDLResponsibility.DataSource = crudsbLL.getDepartments();
        DDLResponsibility.DataTextField = "name";
        DDLResponsibility.DataValueField = "id";
        DDLResponsibility.DataBind();
        DDLResponsibility.Items.Insert(0, new ListItem("Select Department", ""));

        //DDLDepartments.Text = "Select Department";
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        DDLPositions.Items.Insert(0, new ListItem("Select Position", ""));


        DDLSearchPositions.DataSource = crudsbLL.getPositions();
        DDLSearchPositions.DataTextField = "position";
        DDLSearchPositions.DataValueField = "id";
        DDLSearchPositions.DataBind();
        DDLSearchPositions.Items.Insert(0, new ListItem("Select Position", ""));
        
        //DDLDepartments.Text = "Select Department";
        DDLKPIName.DataSource = crudsbLL.getKPINameDropDown();
        DDLKPIName.DataTextField = "KPI_NAME";
        DDLKPIName.DataValueField = "id";
        DDLKPIName.DataBind();
        DDLKPIName.Items.Insert(0, new ListItem("Select KPI", ""));
    }//end refreshPositionKPIDropDown



    //protected void TxtWeight_TextChanged(object sender, EventArgs e)
    //{
    //    TxtWeight.Text = TxtWeight.Text + "%";
    //}


    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
            
       kpiTemplateId.Value=Gridview1.SelectedRow.Cells[2].Text;
        //
         //DDLDepartments.Text = "Select Department";
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        
        DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLDepartments.DataTextField = "name";
        DDLDepartments.DataValueField = "id";
        DDLDepartments.DataBind();
        //
        DDLDepartments.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[14].Text, Gridview1.SelectedRow.Cells[3].Text));
        DDLPositions.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[15].Text, Gridview1.SelectedRow.Cells[4].Text));
        TxtSerialNo.Text =Gridview1.SelectedRow.Cells[5].Text;
        DDLKPIDimension.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[16].Text, Gridview1.SelectedRow.Cells[16].Text));

        DDLKPIDimension.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[16].Text, Gridview1.SelectedRow.Cells[16].Text));

        DDLKPIName.DataSource = crudsbLL.getKPINameDropDown();
        //DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLKPIName.DataTextField = "kpi_name";
        DDLKPIName.DataValueField = "id";
        DDLKPIName.DataBind();
        DDLKPIName.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[17].Text, Gridview1.SelectedRow.Cells[18].Text));
        DDLKPIGroup.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[19].Text, Gridview1.SelectedRow.Cells[19].Text));
        TxtKPIDefinition.Text=Gridview1.SelectedRow.Cells[20].Text;
        
        TxtFormula.Text=Gridview1.SelectedRow.Cells[6].Text;
        DDLSigLevel.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[7].Text, Gridview1.SelectedRow.Cells[7].Text));
        DDLInfLevel.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[8].Text, Gridview1.SelectedRow.Cells[8].Text));
        
        for (int count = 10; count <= 60; count = count + 10)
        {
            DDLImpFactor.Items.Insert(0, new ListItem(count.ToString(), count.ToString()));
        
       }//end for
      DDLImpFactor.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[9].Text, Gridview1.SelectedRow.Cells[9].Text));
      TxtWeight.Text = Gridview1.SelectedRow.Cells[10].Text;
      TxtSource.Text = Gridview1.SelectedRow.Cells[11].Text;
      DDLResponsibility.Text=Gridview1.SelectedRow.Cells[12].Text;
      DDLExisting.Items.Insert(0, new ListItem(Gridview1.SelectedRow.Cells[13].Text, Gridview1.SelectedRow.Cells[13].Text));

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




    protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if(!IsPostBack)
        //{
            
        //string selectedValue = DDLDepartments.SelectedValue;
        //DDLPositions.DataSource = crudsbLL.getDeptForPositions(selectedValue);
        //DDLPositions.DataTextField = "position";
        //DDLPositions.DataValueField = "id";
        //DDLPositions.DataBind();
        //DDLPositions.SelectedIndex = 0;
       //}
    }
    protected void btnSaveKPITemplate_Click(object sender, EventArgs e)
    {
        string usernameMsg = Session["usr"].ToString();
        string kpiTemplateIdMsg = kpiTemplateId.Value; 
        string departmentMsg = DDLDepartments.SelectedValue;
        string positionMsg = DDLPositions.SelectedValue;

        string serialNoMsg = TxtSerialNo.Text;
        string totalSerialNoMsg = "";
        string kpiDimensionMsg = DDLKPIDimension.SelectedValue;
        string kpiMsg = DDLKPIName.SelectedValue;
        string kpiGroupMsg = DDLKPIGroup.SelectedValue;
        string kpiDefMsg = TxtKPIDefinition.Text;
        string formulaMsg = TxtFormula.Text;
        string sigLevelMsg = DDLSigLevel.SelectedValue;
        string infLevelMsg = DDLInfLevel.SelectedValue;
        string impFactMsg = DDLImpFactor.SelectedValue;
        string weightMsg = TxtWeight.Text;
        string sourceMsg = TxtSource.Text;
        string respMsg = DDLResponsibility.Text;
        string existMsg = DDLExisting.SelectedValue;


       


        if (string.IsNullOrEmpty(DDLDepartments.SelectedValue))
        {
            lblStatus.Text = "Please Specify the Department Name";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (string.IsNullOrEmpty(DDLPositions.SelectedValue))
        {
            lblStatus.Text = "Please Specify the Position";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        //add user permissions
        try
        {

            string fulltext = DDLDepartments.SelectedItem.ToString();
            //Console.WriteLine("Full Text: {0}", fulltext);
            Regex rgx = new Regex("[^A-Z]");
           // Console.WriteLine("Abbreviated Text : {0}",
            totalSerialNoMsg = rgx.Replace(fulltext, "") + "_" + serialNoMsg;
           // Console.ReadLine();


           // string usr = crudsbLL.addOrUpdateDepartments(usernameMsg, departmentMsg, groupNameMsg, departmentIdMsg);
            string usr = crudsbLL.addOrUpdateKPITemplate(usernameMsg, kpiTemplateIdMsg, departmentMsg, positionMsg, totalSerialNoMsg,
                kpiDimensionMsg, kpiMsg, kpiGroupMsg, kpiDefMsg, formulaMsg, sigLevelMsg, infLevelMsg, 
                impFactMsg, weightMsg, sourceMsg, respMsg, existMsg);

            if (usr == "20")
            {
                //String username = Session["usr"].ToString();
                int retLog = crudsbLL.saveAuditLog(usernameMsg, Request.UserHostAddress, "KPI Template Management: User " + usernameMsg + " successfully added new KPI Pool Template: "
                    + DDLKPIName.SelectedItem, "Create");
                lblStatus.Text = "KPI Pool Template Information  <i><strong>" + DDLKPIName.SelectedItem + "</strong></i> has been Successfully Added";
                lblStatus.ForeColor = System.Drawing.Color.Blue;

                refreshPositionKPIDropDown();
                FillDepartment();
                TxtSerialNo.Text = "";
                DDLKPIDimension.SelectedIndex = 0;
                kpiTemplateId.Value = null;
                DDLKPIGroup.SelectedIndex = 0;
                DDLKPIDimension.SelectedIndex = 0;
                TxtKPIDefinition.Text = "";
                TxtFormula.Text = "";
                DDLSigLevel.SelectedIndex = 0;
                DDLInfLevel.SelectedIndex = 0;
                DDLImpFactor.SelectedIndex = 0;
                //for (int count = 10; count <= 60; count = count + 10)
                //{
                //    DDLImpFactor.Items.Insert(0, new ListItem(count.ToString(), count.ToString()));

                //}//end for
                //DDLImpFactor.Items.Insert(0, new ListItem("Select Important Factor", ""));
                TxtWeight.Text = "";
                TxtSource.Text = "";
                DDLExisting.SelectedIndex = 0;
                


            }
            else if (usr == "10")
            {
                String username = Session["usr"].ToString();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "KPI Template Management: User " + username + " successfully updated existing KPI Information to: "
                    + DDLKPIName.SelectedItem, "Update");
                lblStatus.Text = "KPI Template Information <i><strong>" + DDLKPIName.SelectedItem + "</strong></i> has been Successfully Updated";
                lblStatus.ForeColor = System.Drawing.Color.Blue;


                refreshPositionKPIDropDown();
                FillDepartment();
                TxtSerialNo.Text = "";
                DDLKPIDimension.SelectedIndex = 0;
                kpiTemplateId.Value = null;
                DDLKPIGroup.SelectedIndex = 0;
                DDLKPIDimension.SelectedIndex = 0;
                TxtKPIDefinition.Text = "";
                TxtFormula.Text = "";
                DDLSigLevel.SelectedIndex = 0;
                DDLInfLevel.SelectedIndex = 0;
                DDLImpFactor.SelectedIndex = 0;
                //for (int count = 10; count <= 60; count = count + 10)
                //{
                //    DDLImpFactor.Items.Insert(0, new ListItem(count.ToString(), count.ToString()));

                //}//end for
                //DDLImpFactor.Items.Insert(0, new ListItem("Select Important Factor", ""));
                TxtWeight.Text = "";
                TxtSource.Text = "";
                DDLExisting.SelectedIndex = 0;


            }
            else if (usr == "30")
            {
                lblStatus.Text = "Please specify another KPI Name, this already exists!";
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


    protected void DDLKPITemplate_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DDLKPITemplate.SelectedIndex > 0)
        {
            string selected = DDLKPITemplate.SelectedValue;
            Session["searchKPITemplate"] = selected;
            lblTest0.Text = "The session value for KPI Template:" + Session["searchKPITemplate"].ToString();
        }
    }
    protected void DDLSearchPositions_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = DDLSearchPositions.SelectedValue;
        Session["searchPosition"] = selected;
        lblTest.Text = "The session value for Position:" + Session["searchPosition"].ToString();
        DDLKPITemplate.DataSource = crudsbLL.getKPINameDropDown(selected);
        DDLKPITemplate.DataTextField = "KPI_NAME";
        DDLKPITemplate.DataValueField = "ID";
        DDLKPITemplate.DataBind();
        DDLKPITemplate.Items.Insert(0, new ListItem("Select KPI Name", ""));

       
    }
    protected void btnSearchKPIPoolTemplate_Click(object sender, EventArgs e)
    {
       if (string.IsNullOrEmpty(DDLSearchPositions.SelectedValue)|| DDLSearchPositions.SelectedValue==""
           ||string.IsNullOrEmpty(DDLKPITemplate.SelectedValue)||DDLKPITemplate.SelectedValue=="")
        {
            // DDLDepartments.Items.Insert(0, "Select Department");
            lblStatus.Text = "Please Specify the Position and/or the KPI Template to search!";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
         else
        {
            //string gottenPosition = DDLSearchPositions.SelectedValue;
            //string gottenKPI = DDLKPITemplate.SelectedValue;
            //DataTable table = crudsbLL.getDepartmentsList();
            //Gridview1.DataSource = table;
            //Gridview1.DataBind();
           string gottenPosition, gottenKPI;
        DataTable table = crudsbLL.getKPIPoolTemplateTable(gottenPosition, gottenKPI);
        Gridview1.DataSource = table;
        Gridview1.DataBind();
           

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

    }
}