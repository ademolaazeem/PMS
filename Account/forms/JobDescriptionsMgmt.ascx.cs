using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Collections.Specialized;

public partial class Account_forms_JobDescriptionsMgmt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "User Management: User " + username + " successfully views Job Description Interface", "View");

        DataTable table = crudsbLL.getJDList();
        Gridview1.DataSource = table;
        Gridview1.DataBind();

        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        DDLPositions.Items.Insert(0, new ListItem("Select Position", ""));
        //
        DDLReportsTo.DataSource = crudsbLL.getPositions();
        DDLReportsTo.DataTextField = "position";
        DDLReportsTo.DataValueField = "id";
        DDLReportsTo.DataBind();
        DDLReportsTo.Items.Insert(0, new ListItem("Select Position", ""));

        DDLConcurrent.DataSource = crudsbLL.getConcurrent();
        DDLConcurrent.DataTextField = "position";
        DDLConcurrent.DataValueField = "id";
        DDLConcurrent.DataBind();
        DDLConcurrent.Items.Insert(0, new ListItem("Select Concurrent Signoff", ""));

        //
        DDLSupervises.DataSource = crudsbLL.getPositions();
        DDLSupervises.DataTextField = "position";
        DDLSupervises.DataValueField = "id";
        DDLSupervises.DataBind();

        Gridview1.Columns[1].Visible = false;
        Gridview1.Columns[2].Visible = false;
        Gridview1.Columns[4].Visible = false;
        Gridview1.Columns[5].Visible = false;
        Gridview1.Columns[9].Visible = false;
        Gridview1.Columns[10].Visible = false;
        
        

    }//Page_Load

    private void ClearBoxes()
    {
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        DDLPositions.Items.Insert(0, new ListItem("Select Positions", ""));
        //
        DDLReportsTo.DataSource = crudsbLL.getPositions();
        DDLReportsTo.DataTextField = "position";
        DDLReportsTo.DataValueField = "id";
        DDLReportsTo.DataBind();
        DDLReportsTo.Items.Insert(0, new ListItem("Select Reports to", ""));

        DDLConcurrent.DataSource = crudsbLL.getConcurrent();
        DDLConcurrent.DataTextField = "position";
        DDLConcurrent.DataValueField = "id";
        DDLConcurrent.DataBind();
        DDLConcurrent.Items.Insert(0, new ListItem("Select Concurrent Signoff", ""));

        DDLSupervises.DataSource = crudsbLL.getPositions();
        DDLSupervises.DataTextField = "position";
        DDLSupervises.DataValueField = "id";
        DDLSupervises.DataBind();

        TxtJobSummary.Text = "";
        TxtPDnResp.Text = "";
        TxtCnSReq.Text = "";

        DataTable table = crudsbLL.getJDList();
        Gridview1.DataSource = table;
        Gridview1.DataBind();
    
    }//end ClearBoxes
    protected void btnUpdateJD_Click(object sender, EventArgs e)
    {
        string loggedInUser = Session["usr"].ToString();
        if (TxtJobSummary.Text == string.Empty)
        {
            lblStatus.Text = "Please specify the Job Summary";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (TxtPDnResp.Text == string.Empty)
        {
            lblStatus.Text = "Please specify the Principal Duties and Responsibilities";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if (TxtCnSReq.Text == string.Empty)
        {
            lblStatus.Text = "Please specify the Competencies and Skill";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
        if(DDLConcurrent.SelectedIndex <= 0 )
        {
            lblStatus.Text = "Please specify Concurrent Sign off for this position";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            ClearBoxes();
            return;
        }
        
        try
        {
            


            //string positionMsg = DDLPositions.Text;
            string positionMsg = DDLPositions.SelectedValue;
            string usernameMsg = loggedInUser;
            string reportMsg = DDLReportsTo.SelectedValue;
            string supervisesMsg = "";
                //DDLSupervises.SelectedValue;
            string jobSummaryMsg = Server.HtmlEncode(TxtJobSummary.Text);
            string principalDutiesMsg = Server.HtmlEncode(TxtPDnResp.Text);
            string competencySkillsReqmt = Server.HtmlEncode(TxtCnSReq.Text);
            string jdMsg = JDId.Value;
            string concurrentMsg = DDLConcurrent.SelectedValue;
            

            string usr = crudsbLL.addOrUpdateJD(jdMsg, usernameMsg, positionMsg, reportMsg, supervisesMsg,
        jobSummaryMsg, principalDutiesMsg, competencySkillsReqmt, concurrentMsg);
            if (usr == "10"|| usr=="20")
            {
                String username = Session["usr"].ToString();
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Job Description Management: User " + username + " successfully updated position with id: "
                    + positionMsg, "Update");

                ////////////////////////////////////////////////////////
                    if (DDLSupervises.SelectedIndex >= 0)
                    {
                        string delPos = crudsbLL.deleteSupervises(positionMsg);

                        foreach (ListItem item in DDLSupervises.Items)
                        {
                            if (item.Selected)
                            {
                                string sup = crudsbLL.updateSupervisor(positionMsg, item.Value);

                            }
                        }
                    }//end if
                    else 
                    {

                        string delPos = crudsbLL.deleteSupervises(positionMsg); 
                        string sup = crudsbLL.updateSupervisor(positionMsg, "");
                    }
                /////////////////////////////////////////////////////
                ClearBoxes();
                lblStatus.Text = "Job Description setup has been updated";
                lblStatus.ForeColor = System.Drawing.Color.Blue;

            }
            else if (usr == "30")
            {
                lblStatus.Text = "The position already exist, please specify another, Thank you!";// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                //lblstatus.Text = "Error: Operation failed " + chkCustId.ToString();// +rst.ToString();
                lblStatus.Text = "Error: Operation failed " + usr.ToString();// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;

            }//end else usr
            //}//end checkUsername

            




            /*
            if (DDLSupervisesHide.SelectedIndex <= 0 && DDLSupervises.SelectedIndex > 0)
            {
                foreach (ListItem item in DDLSupervises.Items)
                {
                    if (item.Selected)
                    {
                        string sup = crudsbLL.updateSupervisor(supIdMsg, positionMsg, item.Value);//supIdMsg is empty, this means insert.

                    }
                }
            }
            else if(DDLSupervises.SelectedIndex > 0 && DDLSupervisesHide.SelectedIndex > 0)
            { 
                
                     foreach (ListItem item in DDLSupervisesHide.Items)
                    {
                        if (item.Selected)
                        {
                    
                            string sup = crudsbLL.updateSupervisor(item.Value, positionMsg, item.Text);

                        }
                    }
            
            }
            
            */




           

            //if (supervisesMsg != "")
            //{
            //    supervisesMsg = supervisesMsg.Remove(0, 1);
            //}

            //InsertRecords(sc);

            //end added for listbox
        }
        catch (Exception ex)
        {
            lblStatus.Text = "Object Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }
    }//end btnUpdateJD

    protected void Gridview1_SelectedIndexChanged(object sender, EventArgs e)
    {
        JDId.Value = Gridview1.SelectedRow.Cells[1].Text;
         positionId.Value = Gridview1.SelectedRow.Cells[2].Text;
         string positionNewId = positionId.Value;
         string positionName = Gridview1.SelectedRow.Cells[3].Text;
         string reportsToName = Gridview1.SelectedRow.Cells[4].Text;
         string supervisesId = Gridview1.SelectedRow.Cells[5].Text;
         //string result = Gridview1.SelectedRow.Cells[5].Text;
         TxtJobSummary.Text = Server.HtmlEncode(Gridview1.SelectedRow.Cells[6].Text);
         TxtPDnResp.Text = Server.HtmlEncode(Gridview1.SelectedRow.Cells[7].Text);
         TxtCnSReq.Text = Server.HtmlEncode(Gridview1.SelectedRow.Cells[8].Text);
         string concurrentId = Gridview1.SelectedRow.Cells[9].Text;
         string reportsToId = Gridview1.SelectedRow.Cells[10].Text;

        //DDLReportsTo.SelectedValue = Gridview1.SelectedRow.Cells[2].Text;
        //DDLSupervises.SelectedValue = Gridview1.SelectedRow.Cells[3].Text;


        //DDLPositions.SelectedValue = Gridview1.SelectedRow.Cells[3].Text;
        //DDLReportsTo.SelectedValue = Gridview1.SelectedRow.Cells[4].Text;

         if (positionName == string.Empty || positionName == "&nbsp;")
        {
            refreshPositionDropDown();
        }
        else
        {

            DDLPositions.DataSource = crudsbLL.getPositions();
            DDLPositions.DataTextField = "position";
            DDLPositions.DataValueField = "id";
            DDLPositions.DataBind();
            DDLPositions.Items.Insert(0, new ListItem(positionName, positionNewId));

        }

         if (reportsToName == string.Empty || reportsToName == "&nbsp;")
        {
            refreshReportsToDropDown();
        }
        else
        {

            DDLReportsTo.DataSource = crudsbLL.getPositions();
            DDLReportsTo.DataTextField = "position";
            DDLReportsTo.DataValueField = "id";
            DDLReportsTo.DataBind();
            DDLReportsTo.Items.Insert(0, new ListItem(reportsToName, reportsToId));

        }


        //DDLSupervises.SelectedValue = Gridview1.SelectedRow.Cells[5].Text;
         if (supervisesId == string.Empty || supervisesId == "&nbsp;")
        {
            refreshSupervisesDropDown();
        }
        else 
        {
            string[] sepSupervise = supervisesId.Split(',');
            foreach (string s in sepSupervise)
            {

            }
        }
        //empName = sepsess[0];
        //empDept = sepsess[1];


        //TxtJobSummary.Text =Server.HtmlEncode(Gridview1.SelectedRow.Cells[6].Text);
        //TxtPDnResp.Text = Server.HtmlEncode(Gridview1.SelectedRow.Cells[7].Text);
        //TxtCnSReq.Text = Server.HtmlEncode(Gridview1.SelectedRow.Cells[8].Text);

        if (concurrentId == string.Empty || concurrentId == "&nbsp;")
        {
            refreshConcurrentDropDown();
        }
        else
        {
            
            DDLConcurrent.DataSource = crudsbLL.getConcurrent();
            DDLConcurrent.DataTextField = "position";
            DDLConcurrent.DataValueField = "id";
            DDLConcurrent.DataBind();
            DDLConcurrent.Items.Insert(0, new ListItem(concurrentId, concurrentId));

        }


       



        /*

        List<SupervisesRequest> supList;
        supList = crudsbLL.getSupervisesLists(positionId.Value);
        
        //foreach (SupervisesRequest supRq in supList)
        //{
        //    ListItem newItem = new ListItem();
        //    newItem.Text = supRq.SUPERVISES_ID;
        //    newItem.Value = supRq.ID;
        //    DDLSupervisesHide.Items.Add(newItem);
            
        //}

        foreach (SupervisesRequest supRq in supList)
        {
            //DDLReportsTo.DataSource = crudsbLL.getPositions();
            //DDLReportsTo.DataTextField = "position";
            //DDLReportsTo.DataValueField = "id";
            //DDLReportsTo.DataBind();
            //DDLReportsTo.Items.Insert(0, new ListItem("Select Department", ""));
            ListItem newItem = new ListItem();
            newItem.Text = supRq.SUPERVISES;
            newItem.Value = supRq.ID;
            // DDLSupervises.Items.Add(newItem);
            DDLSupervisesHide.Items.Insert(0, newItem);

        }


        */














        ///////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////
        //string supervisesId;
        //string positionSuperviseeId;


        //try
        //{
        //    //codes here
        //    string rst = crudsbLL.getSupervisesContent(positionId.Value);
        //    //string rst = crudsbLL.getDepartmentContent(positionId.Value);
        //    if (rst != string.Empty)
        //    {
        //        lblStatus.Text = "Supervisees information found!";// +rst.ToString();
        //        lblStatus.ForeColor = System.Drawing.Color.Blue;
        //        string[] sepsess = rst.Split('_');

        //        for (int kount = 0; kount <= sepsess.Length - 1; kount++)
        //        {
        //            supervisesId = sepsess[0];
        //            positionSuperviseeId = sepsess[1];


        //        }

        //        //supervisesId = sepsess[0];
        //        //positionSuperviseeId = sepsess[1];


        //    }
        //    else
        //    {

        //        lblStatus.Text = "No supervisee information had been provided for this position";// +rst.ToString();
        //        lblStatus.ForeColor = System.Drawing.Color.Red;


        //    }
        //}
        //catch (Exception ex)
        //{
        //    lblStatus.Text = "Object Error: " + ex.Message;
        //    lblStatus.ForeColor = System.Drawing.Color.Red;
        //    //return;
        //}
        ///////////////////////////////////////////////////////////////////////
    }

    private void refreshConcurrentDropDown()
    {
        DDLConcurrent.DataSource = crudsbLL.getConcurrent();
        DDLConcurrent.DataTextField = "position";
        DDLConcurrent.DataValueField = "id";
        DDLConcurrent.DataBind();
        DDLConcurrent.Items.Insert(0, new ListItem("Select Concurrent Signoff", ""));
    }//end refreshPositionDropDown
    private void refreshPositionDropDown()
    {
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        DDLPositions.Items.Insert(0, new ListItem("Select Position", ""));
    }//end refreshPositionDropDown


    private void refreshSupervisesDropDown()
    {
        DDLSupervises.DataSource = crudsbLL.getPositions();
        DDLSupervises.DataTextField = "position";
        DDLSupervises.DataValueField = "id";
        DDLSupervises.DataBind();
    }


    private void refreshReportsToDropDown()
    {
        DDLPositions.DataSource = crudsbLL.getPositions();
        DDLPositions.DataTextField = "position";
        DDLPositions.DataValueField = "id";
        DDLPositions.DataBind();
        DDLPositions.Items.Insert(0, new ListItem("Select Position", ""));
    }//end refreshReportsToDropDown
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
    }//end ConvertSortDirectionToSql

    protected void Gridview1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridview1.PageIndex = e.NewPageIndex;
        Gridview1.DataBind();
    }//_PageIndexChanging

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
}