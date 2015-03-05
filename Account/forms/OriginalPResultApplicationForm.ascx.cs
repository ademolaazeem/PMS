using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using System.Collections.Specialized;
using System.Text;

public partial class Account_forms_OriginalPResultApplicationForm : System.Web.UI.UserControl
{
      //decimal grdTotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        String username = Session["usr"].ToString();
        string empName;
        string empGradeLevel;
        string empDept;
        
        ////////////////////////////////////Pretest/////////////////////////////////////////////
        
        for (int i = 2013; i <= 2020; i++)
        {
            ddlYear.Items.Add(i.ToString());
        }
        ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {


            ddlMonth.Items.Add(i.ToString());


        }
        ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
       
        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Goal Settings Application Form: User " + username + " successfully views actual Performance result page for Application Form Interface", "View");

      try
        {
            //codes here
            string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

            if (rst != string.Empty)
            {
                lblStatus.Text = "User record found";// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Blue;
                //
                //authPanel.Visible = true;

                //S[LIT CONTENT
                string[] sepsess = rst.Split('_');
                //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                empName = sepsess[0];
                empDept = sepsess[1];
                empGradeLevel = sepsess[2];
                LblEmpNo.Text = sepsess[3];
                LblPositionId.Text = sepsess[4];
                LblName.Text = empName;
                LblGroupDepartment.Text = empDept;
                LblGradeLevel.Text = empGradeLevel;

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


        sessionDimension(username);

        GrdViewKPI.Columns[4].Visible = false;

        GrdViewBrand.Columns[1].Visible = false;
        GrdViewFinancial.Columns[1].Visible = false;
        GrdViewProcessEfficiency.Columns[1].Visible = false;
        GrdViewPeople.Columns[1].Visible = false;
        GrdViewCustomer.Columns[1].Visible = false;

        GrdViewBrand.Columns[0].Visible = false;
        GrdViewFinancial.Columns[0].Visible = false;
        GrdViewProcessEfficiency.Columns[0].Visible = false;
        GrdViewPeople.Columns[0].Visible = false;
        GrdViewCustomer.Columns[0].Visible = false;






    }//_Load


    private void sessionPeriodDimension(string appraisalPeriod, string sessionDep)
    {
        /////////////////////////////////////////////////
        //DataTable tablePhaseTwo = crudsbLL.getPhaseTwoList(sessionDep);
        DataTable tablePhaseTwo = crudsbLL.getPhaseTwoList(sessionDep);
        GrdViewKPI.DataSource = tablePhaseTwo;
        GrdViewKPI.DataBind();

        DataTable tableFinancial = crudsbLL.getFinancialList(appraisalPeriod, sessionDep);
        if (tableFinancial.Rows.Count > 0)
        {
            GrdViewFinancial.DataSource = tableFinancial;
            GrdViewFinancial.DataBind();
            lblFinancialComments.Visible = true;
            TxtFinancialComments.Visible = true;
        }
        else
        {
            //tableFinancial.Rows.Add(tableFinancial.NewRow());
            //GrdViewFinancial.DataSource = tableFinancial;
            //GrdViewFinancial.DataBind();
            //int totalcolums = GrdViewFinancial.Rows[0].Cells.Count;
            //GrdViewFinancial.Rows[0].Cells.Clear();
            //GrdViewFinancial.Rows[0].Cells.Add(new TableCell());
            //GrdViewFinancial.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //GrdViewFinancial.Rows[0].Cells[0].Text = "No Financial KPI for the Employee";
            lblFinancialComments.Visible = false;
            TxtFinancialComments.Visible = false;
        }
        //GrdViewFinancial.DataSource = tableFinancial;
        //GrdViewFinancial.DataBind();

        DataTable tableCustomer = crudsbLL.getCustomerList(appraisalPeriod, sessionDep);
        if (tableCustomer.Rows.Count > 0)
        {
            GrdViewCustomer.DataSource = tableCustomer;
            GrdViewCustomer.DataBind();
            lblCustomerComments.Visible = true;
            TxtCustomerComments.Visible = true;
        }
        else
        {
            lblCustomerComments.Visible = false;
            TxtCustomerComments.Visible = false;
        }

        //GrdViewCustomer.DataSource = tableCustomer;
        //GrdViewCustomer.DataBind();

        DataTable tablePEff = crudsbLL.getProcessEfficiencyList(appraisalPeriod, sessionDep);
        if (tablePEff.Rows.Count > 0)
        {
            GrdViewProcessEfficiency.DataSource = tablePEff;
            GrdViewProcessEfficiency.DataBind();
            lblProcessEfficiencyComments.Visible = true;
            TxtProcessEfficiencyComments.Visible = true;
        }
        else
        {
            lblProcessEfficiencyComments.Visible = false;
            TxtProcessEfficiencyComments.Visible = false;
        }
        //GrdViewProcessEfficiency.DataSource = tablePEff;
        //GrdViewProcessEfficiency.DataBind();


        DataTable tablePeople = crudsbLL.getPeopleList(appraisalPeriod, sessionDep);
        if (tablePeople.Rows.Count > 0)
        {
            GrdViewPeople.DataSource = tablePeople;
            GrdViewPeople.DataBind();
            lblPeopleComments.Visible = true;
            TxtPeopleComments.Visible = true;
        }
        else
        {
            lblPeopleComments.Visible = false;
            TxtPeopleComments.Visible = false;
        }
        //GrdViewPeople.DataSource = tablePeople;
        //GrdViewPeople.DataBind();

        DataTable tableBrand = crudsbLL.getBrandList(appraisalPeriod, sessionDep);
        if (tableBrand.Rows.Count > 0)
        {
            GrdViewBrand.DataSource = tableBrand;
            GrdViewBrand.DataBind();
            lblBrandComments.Visible = true;
            TxtBrandComments.Visible = true;
        }
        else
        {
            lblBrandComments.Visible = false;
            TxtBrandComments.Visible = false;
        }

        //GrdViewBrand.DataSource = tableBrand;
        //GrdViewBrand.DataBind();


        ///////////////////////////////////////////////
        if (tableBrand.Rows.Count <= 0 && tableCustomer.Rows.Count <= 0 && tableFinancial.Rows.Count <= 0 && tablePEff.Rows.Count <= 0
            && tablePeople.Rows.Count <= 0 && tablePhaseTwo.Rows.Count <= 0)
        {

            lblStatus.Text = "The KPI Template for the username:<i><strong>" + LblName.Text + "</i></strong>, an email has been sent to the HR department to notify them of the need to setup your KPI Template, or contact HR to the setup.";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            //delibrately commented
            //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);
            btnSavePRAF.Visible = false;
        }
        else if (tableBrand.Rows.Count <= 0 && tableCustomer.Rows.Count <= 0 && tableFinancial.Rows.Count <= 0 && tablePEff.Rows.Count <= 0
           && tablePeople.Rows.Count <= 0 && tablePhaseTwo.Rows.Count > 0)
        {

            lblStatus.Text = "Sorry! You need to set your Goal first before you can complete application form. Please select <i><strong>Goal Settings Management -> Performance Result </i></strong> in the main menu.";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);
            btnSavePRAF.Visible = false;
        }


    }
    private void sessionDimension(string sessionDep)
    {
        /////////////////////////////////////////////////
        //DataTable tablePhaseTwo = crudsbLL.getPhaseTwoAPPFormList(sessionDep);
        DataTable tablePhaseTwo = crudsbLL.getPhaseTwoList(sessionDep);
        GrdViewKPI.DataSource = tablePhaseTwo;
        GrdViewKPI.DataBind();








        DataTable tableFinancial = crudsbLL.getFinancialList(sessionDep);
        if (tableFinancial.Rows.Count > 0)
        {
            GrdViewFinancial.DataSource = tableFinancial;
            GrdViewFinancial.DataBind();
            lblFinancialComments.Visible = true;
            TxtFinancialComments.Visible = true;
        }
        else
        {
            //tableFinancial.Rows.Add(tableFinancial.NewRow());
            //GrdViewFinancial.DataSource = tableFinancial;
            //GrdViewFinancial.DataBind();
            //int totalcolums = GrdViewFinancial.Rows[0].Cells.Count;
            //GrdViewFinancial.Rows[0].Cells.Clear();
            //GrdViewFinancial.Rows[0].Cells.Add(new TableCell());
            //GrdViewFinancial.Rows[0].Cells[0].ColumnSpan = totalcolums;
            //GrdViewFinancial.Rows[0].Cells[0].Text = "No Financial KPI for the Employee";
            lblFinancialComments.Visible = false;
            TxtFinancialComments.Visible = false;
        }
        //GrdViewFinancial.DataSource = tableFinancial;
        //GrdViewFinancial.DataBind();

        DataTable tableCustomer = crudsbLL.getCustomerList(sessionDep);
        if (tableCustomer.Rows.Count > 0)
        {
            GrdViewCustomer.DataSource = tableCustomer;
            GrdViewCustomer.DataBind();
            lblCustomerComments.Visible = true;
            TxtCustomerComments.Visible = true;
        }
        else
        {
            lblCustomerComments.Visible = false;
            TxtCustomerComments.Visible = false;
        }

        //GrdViewCustomer.DataSource = tableCustomer;
        //GrdViewCustomer.DataBind();

        DataTable tablePEff = crudsbLL.getProcessEfficiencyList(sessionDep);
        if (tablePEff.Rows.Count > 0)
        {
            GrdViewProcessEfficiency.DataSource = tablePEff;
            GrdViewProcessEfficiency.DataBind();
            lblProcessEfficiencyComments.Visible = true;
            TxtProcessEfficiencyComments.Visible = true;
        }
        else
        {
            lblProcessEfficiencyComments.Visible = false;
            TxtProcessEfficiencyComments.Visible = false;
        }
        //GrdViewProcessEfficiency.DataSource = tablePEff;
        //GrdViewProcessEfficiency.DataBind();


        DataTable tablePeople = crudsbLL.getPeopleList(sessionDep);
        if (tablePeople.Rows.Count > 0)
        {
            GrdViewPeople.DataSource = tablePeople;
            GrdViewPeople.DataBind();
            lblPeopleComments.Visible = true;
            TxtPeopleComments.Visible = true;
        }
        else
        {
            lblPeopleComments.Visible = false;
            TxtPeopleComments.Visible = false;
        }
        //GrdViewPeople.DataSource = tablePeople;
        //GrdViewPeople.DataBind();

        DataTable tableBrand = crudsbLL.getBrandList(sessionDep);
        if (tableBrand.Rows.Count > 0)
        {
            GrdViewBrand.DataSource = tableBrand;
            GrdViewBrand.DataBind();
            lblBrandComments.Visible = true;
            TxtBrandComments.Visible = true;
        }
        else
        {
            lblBrandComments.Visible = false;
            TxtBrandComments.Visible = false;
        }

        //GrdViewBrand.DataSource = tableBrand;
        //GrdViewBrand.DataBind();


        if (tableBrand.Rows.Count <= 0 && tableCustomer.Rows.Count <= 0 && tableFinancial.Rows.Count <= 0 && tablePEff.Rows.Count <= 0
           && tablePeople.Rows.Count <= 0 && tablePhaseTwo.Rows.Count <= 0)
        {

            lblStatus.Text = "The KPI Template for the username:<i><strong>" + LblName.Text + "</i></strong>, an email has been sent to the HR department to notify them of the need to setup your KPI Template, or contact HR to the setup.";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            //delibrately commented
            //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);
            btnSavePRAF.Visible = false;
        }
        else if (tableBrand.Rows.Count <= 0 && tableCustomer.Rows.Count <= 0 && tableFinancial.Rows.Count <= 0 && tablePEff.Rows.Count <= 0
           && tablePeople.Rows.Count <= 0 && tablePhaseTwo.Rows.Count > 0)
        {

            lblStatus.Text = "Sorry! You need to set your Goal first before you can complete application form. Please select <i><strong>Goal Settings Management -> Performance Result </i></strong> in the main menu.";
            lblStatus.ForeColor = System.Drawing.Color.Red;
            //string bcGSSendMail = BLLMail2Send.sendMail2HRForKPITemplate(LblName.Text);
            btnSavePRAF.Visible = false;
        }

        ///////////////////////////////////////////////

    }
    private void InsertRecords(StringCollection sc)
    {

        // SqlConnection conn = new SqlConnection(GetConnectionString());

        StringBuilder sb = new StringBuilder(string.Empty);

        string[] splitItems = null;
        string kpiDimensionComments = "";
        string appraisalPeriod;
        string monthValue;

        try
        {
            foreach (string item in sc)
            {



                // const string sqlStatement = "INSERT INTO SampleTable (Column1,Column2,Column3) VALUES";

                if (item.Contains(","))
                {

                    splitItems = item.Split(",".ToCharArray());
                    if (splitItems[0].Trim().ToLower() == "financial")
                    {
                        kpiDimensionComments = TxtFinancialComments.Text;
                    }
                    else if (splitItems[0].Trim().ToLower() == "customer")
                    {
                        kpiDimensionComments = TxtCustomerComments.Text;
                    }
                    else if (splitItems[0].Trim().ToLower() == "process efficiency")
                    {
                        kpiDimensionComments = TxtProcessEfficiencyComments.Text;
                    }
                    else if (splitItems[0].Trim().ToLower() == "people")
                    {
                        kpiDimensionComments = TxtPeopleComments.Text;
                    }
                    else if (splitItems[0].Trim().ToLower() == "brand")
                    {
                        kpiDimensionComments = TxtBrandComments.Text;
                    }

                    if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
                    {
                        monthValue = "00" + ddlMonth.SelectedValue;
                    }
                    else
                    {
                        monthValue = "0" + ddlMonth.SelectedValue;
                    }

                    appraisalPeriod = ddlYear.SelectedValue + monthValue;

                    //sb.AppendFormat("{0}('{1}','{2}','{3}'); ", sqlStatement, splitItems[0], splitItems[1], splitItems[2]);
                    //kpiDimension=splitItems[0], totalKPINumber.Text=splitItems[1],totalObtainableScore.Text=splitItems[2],empNo.Text=splitItems[3]
                    string usr = crudsbLL.addOrUpdateAPKPIView(splitItems[0], splitItems[3], kpiDimensionComments, appraisalPeriod);
                    //string usr = crudsbLL.addOrUpdateKPIView(splitItems[0], splitItems[1], splitItems[2], splitItems[3], kpiDimensionComments, appraisalPeriod);
                }



            }



            //try
            //{

            //conn.Open();

            //SqlCommand cmd = new SqlCommand(sb.ToString(), conn);

            //cmd.CommandType = CommandType.Text;

            //cmd.ExecuteNonQuery();



            //Display a popup which indicates that the record was successfully inserted
            //lblStatus.Text = "Records Successfuly Saved!";
            //lblStatus.ForeColor = System.Drawing.Color.Blue;
            //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



        }

        catch (Exception ex)
        {
            lblStatus.Text = "Object Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }

        //finally
        //{

        //    conn.Close();

        //}

    }//end InsertRec
    private void InsertAFDimensionRec(StringCollection sc)
    {
        StringBuilder sb = new StringBuilder(string.Empty);
        string[] splitItems = null;
        string appraisalPeriod;
        string monthValue;

        try
        {
            foreach (string item in sc)
            {



                // const string sqlStatement = "INSERT INTO SampleTable (Column1,Column2,Column3) VALUES";

                if (item.Contains(","))
                {

                    splitItems = item.Split(",".ToCharArray());
                    if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
                    {
                        monthValue = "00" + ddlMonth.SelectedValue;
                    }
                    else
                    {
                        monthValue = "0" + ddlMonth.SelectedValue;
                    }

                    appraisalPeriod = ddlYear.SelectedValue + monthValue;
                    string employeeNo = LblEmpNo.Text;
                    string positionId = LblPositionId.Text;
                    string kpiId = splitItems[0];
                    string weight = splitItems[1];
                    string target = "0";
                    // string target = splitItems[2];
                    string actual = splitItems[2];
                   
                    // scBrand.Add(kpiIdBrand + "," + weightBrand + "," + targetBrand + "," + actualBrand);
                    //kpiIdFinancial + "," + kpiTypeFinancial + "," + weightFinancial + "," + targetFinancial + "," + kpiDimensionFinancial
                    //scFinancial.Add(kpiIdFinancial+ ","+ actualFinancial + "," + scoreFinancial);
                    //string usr = crudsbLL.addOrUpdateApplicationFormKpiDimDetails(employeeNo, kpiId, actual, score, appraisalPeriod);

                    string usr = crudsbLL.addOrUpdateApplicationFormKpiDimDetails(employeeNo, kpiId, weight, target, actual, appraisalPeriod);
                    //string usr = crudsbLL.addOrUpdateKpiDimDetails(employeeNo, positionId, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], appraisalPeriod);
                }



            }
            //lblStatus.Text = "Records Successfuly Saved!";
            //lblStatus.ForeColor = System.Drawing.Color.Blue;
            //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



        }

        catch (Exception ex)
        {
            lblStatus.Text = "Object Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }



    }//end InsertAFDimensionRec
    private void InsertDimensionRecords(StringCollection sc)
    {
        StringBuilder sb = new StringBuilder(string.Empty);
        string[] splitItems = null;
        string appraisalPeriod;
        string monthValue;

        try
        {
            foreach (string item in sc)
            {



                // const string sqlStatement = "INSERT INTO SampleTable (Column1,Column2,Column3) VALUES";

                if (item.Contains(","))
                {

                    splitItems = item.Split(",".ToCharArray());
                    if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
                    {
                        monthValue = "00" + ddlMonth.SelectedValue;
                    }
                    else
                    {
                        monthValue = "0" + ddlMonth.SelectedValue;
                    }

                    appraisalPeriod = ddlYear.SelectedValue + monthValue;
                    string employeeNo = LblEmpNo.Text;
                    string positionId = LblPositionId.Text;
                    //kpiIdFinancial + "," + kpiTypeFinancial + "," + weightFinancial + "," + targetFinancial + "," + kpiDimensionFinancial
                    string usr = crudsbLL.addOrUpdateKpiDimDetails(employeeNo, positionId, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], appraisalPeriod);
                }



            }
            //lblStatus.Text = "Records Successfuly Saved!";
            //lblStatus.ForeColor = System.Drawing.Color.Blue;
            //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);



        }

        catch (Exception ex)
        {
            lblStatus.Text = "Object Error: " + ex.Message;
            lblStatus.ForeColor = System.Drawing.Color.Red;
            return;
        }



    }//end InsertDimensionRec
    protected void btnSavePRAF_Click(object sender, EventArgs e)
    {
        
            string kpiDimension = "";
            string totalKPINumber = "";
            string totalObtainableScore = "";
            string empNo;




            bool emptyTextbox = false;
            if (GrdViewFinancial.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrdViewFinancial.Rows)
                {

                    TextBox txt = row.FindControl("ACTUAL") as TextBox;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        emptyTextbox = true;
                        break;
                    }
                }//end foreach
            }//Financial

            if (GrdViewCustomer.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrdViewCustomer.Rows)
                {

                    TextBox txt = row.FindControl("ACTUAL") as TextBox;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        emptyTextbox = true;
                        break;
                    }
                }//end foreach
            }//Customer

            if (GrdViewPeople.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrdViewPeople.Rows)
                {

                    TextBox txt = row.FindControl("ACTUAL") as TextBox;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        emptyTextbox = true;
                        break;
                    }
                }//end foreach
            }//People
            if (GrdViewProcessEfficiency.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrdViewProcessEfficiency.Rows)
                {

                    TextBox txt = row.FindControl("ACTUAL") as TextBox;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        emptyTextbox = true;
                        break;
                    }
                }//end foreach
            }//PE
            if (GrdViewBrand.Rows.Count > 0)
            {
                foreach (GridViewRow row in GrdViewBrand.Rows)
                {

                    TextBox txt = row.FindControl("ACTUAL") as TextBox;
                    if (string.IsNullOrEmpty(txt.Text))
                    {
                        emptyTextbox = true;
                        break;
                    }
                }//end foreach
            }//PE
        
            if (emptyTextbox)
            {
                lblStatus.Text = "Please fill every empty necessary information";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {


            StringCollection sc = new StringCollection();

            foreach (GridViewRow r in GrdViewKPI.Rows)
            {
                //extract the TextBox values
                kpiDimension = r.Cells[0].Text;
                Label totalObtainableScore1 = (Label)r.Cells[1].FindControl("TOTAL_OBTAINABLE_SCORE1");
                Label totalKPINumber1 = (Label)r.Cells[2].FindControl("TOTAL_KPI_NUMBER1");
                empNo = r.Cells[4].Text;
                totalKPINumber = totalKPINumber1.Text;
                totalObtainableScore = totalObtainableScore1.Text;
                sc.Add(kpiDimension + "," + totalKPINumber + "," + totalObtainableScore + "," + empNo);
            }//end for
            //Call the method for executing inserts
            InsertRecords(sc);
            //////////////////////////////////Financial//////////////////////////////////////////////////////////////
            StringCollection scFinancial = new StringCollection();

            foreach (GridViewRow r1 in GrdViewFinancial.Rows)
            {
                //extract the TextBox values
                
                
                //string kpiDimensionFinancial = "Financial";
                //DropDownList kpiTypeFin = (DropDownList)r1.Cells[3].FindControl("KPI_TYPE");
                //string kpiTypeFinancial = kpiTypeFin.SelectedValue;
                //string weightFinancial = r1.Cells[4].Text;
                //TextBox targetFin = (TextBox)r1.Cells[5].FindControl("TARGET");
                //string targetFinancial = targetFin.Text;

                
                string idFinancial = r1.Cells[0].Text;
                string kpiIdFinancial = r1.Cells[1].Text;
                string weightFinancial = r1.Cells[3].Text;
                //string targetFinancial = r1.Cells[5].Text;
                TextBox actualFin = (TextBox)r1.Cells[4].FindControl("ACTUAL");
                string actualFinancial = actualFin.Text;

                //TextBox scoreFin = (TextBox)r1.Cells[7].FindControl("SCORE");
                //string scoreFinancial = scoreFin.Text;

                scFinancial.Add(kpiIdFinancial + "," + weightFinancial +  "," + actualFinancial);
                //scFinancial.Add(kpiIdFinancial + "," + weightFinancial + "," + targetFinancial+ "," + actualFinancial);
            }//end for
            //Call the method for executing inserts
            InsertAFDimensionRec(scFinancial);
            ///////////////////////////////////End Financial////////////////////////////////////////////////////////////
            //////////////////////////////////Customer/////////////////////////////////////////////////////////////////
            StringCollection scCustomer = new StringCollection();

            foreach (GridViewRow r1 in GrdViewCustomer.Rows)
            {
                string idCustomer = r1.Cells[0].Text;
                string kpiIdCustomer = r1.Cells[1].Text;
                string weightCustomer = r1.Cells[3].Text;
                //string targetCustomer = r1.Cells[5].Text;
                TextBox actualCust = (TextBox)r1.Cells[4].FindControl("ACTUAL");
                string actualCustomer = actualCust.Text;

                //TextBox scoreFin = (TextBox)r1.Cells[7].FindControl("SCORE");
                //string scoreCustomer = scoreFin.Text;


                scCustomer.Add(kpiIdCustomer + "," + weightCustomer + "," + actualCustomer);

            }//end for
            //Call the method for executing inserts
            InsertAFDimensionRec(scCustomer);
            
            ///////////////////////////////////End Customer////////////////////////////////////////////////////////////

            //////////////////////////////////ProcessEfficiency/////////////////////////////////////////////////////////////////
            StringCollection scProcessEfficiency = new StringCollection();

            foreach (GridViewRow r in GrdViewProcessEfficiency.Rows)
            {
                string idProcessEfficiency = r.Cells[0].Text;
                string kpiIdProcessEfficiency = r.Cells[1].Text;
                string weightProcessEfficiency = r.Cells[3].Text;
                //string targetProcessEfficiency = r.Cells[5].Text;
                TextBox actualPE = (TextBox)r.Cells[4].FindControl("ACTUAL");
                string actualProcessEfficiency = actualPE.Text;
                //scProcessEfficiency.Add(kpiIdProcessEfficiency + "," + weightProcessEfficiency + "," + targetProcessEfficiency + "," + actualProcessEfficiency);
                scProcessEfficiency.Add(kpiIdProcessEfficiency + "," + weightProcessEfficiency + ","  + actualProcessEfficiency);
            }//end for
            //Call the method for executing inserts
            InsertAFDimensionRec(scProcessEfficiency);
            ///////////////////////////////////End ProcessEfficiency////////////////////////////////////////////////////////////

            //////////////////////////////////People/////////////////////////////////////////////////////////////////
            StringCollection scPeople = new StringCollection();

            foreach (GridViewRow r in GrdViewPeople.Rows)
            {
                string idPeople = r.Cells[0].Text;
                string kpiIdPeople = r.Cells[1].Text;
                string weightPeople = r.Cells[3].Text;
                //string targetPeople = r.Cells[5].Text;
                TextBox actualPple = (TextBox)r.Cells[4].FindControl("ACTUAL");
                string actualPeople = actualPple.Text;
                //scPeople.Add(kpiIdPeople + "," + weightPeople + "," + targetPeople + "," + actualPeople);
                scPeople.Add(kpiIdPeople + "," + weightPeople + "," + actualPeople);
            
            }//end for
            //Call the method for executing inserts
            InsertAFDimensionRec(scPeople);
            ///////////////////////////////////End People////////////////////////////////////////////////////////////

            //////////////////////////////////Brand/////////////////////////////////////////////////////////////////
            StringCollection scBrand = new StringCollection();

            foreach (GridViewRow r in GrdViewBrand.Rows)
            {
            //    //extract the TextBox values
            //    string idBrand = r.Cells[0].Text;
            //    string kpiIdBrand = r.Cells[1].Text;
            //    string kpiDimensionBrand = "Brand";
            //    DropDownList kpiTypeBr = (DropDownList)r.Cells[3].FindControl("KPI_TYPE");
            //    string kpiTypeBrand = kpiTypeBr.SelectedValue;
            //    string weightBrand = r.Cells[4].Text;
            //    TextBox targetP = (TextBox)r.Cells[5].FindControl("TARGET");
            //    string targetBrand = targetP.Text;
            //    scBrand.Add(kpiIdBrand + "," + kpiTypeBrand + "," + weightBrand + "," + targetBrand + "," + kpiDimensionBrand);
            //}//end for
            ////Call the method for executing inserts
            //InsertDimensionRecords(scBrand);
                string idBrand = r.Cells[0].Text;
                string kpiIdBrand = r.Cells[1].Text;
                string weightBrand = r.Cells[3].Text;
               // string targetBrand = r.Cells[5].Text;
                TextBox actualBrd = (TextBox)r.Cells[4].FindControl("ACTUAL");
                string actualBrand = actualBrd.Text;
                scBrand.Add(kpiIdBrand + "," + weightBrand + "," + actualBrand);
               // scBrand.Add(kpiIdBrand + "," + weightBrand + "," + targetBrand + "," + actualBrand);
            }//end for
            //Call the method for executing inserts
            InsertAFDimensionRec(scBrand);
            ///////////////////////////////////End Brand////////////////////////////////////////////////////////////


            //////////////////////////////////////Clear box////////////////////////////////////////
            //TxtBrandComments.Text = "";
            //TxtCustomerComments.Text = "";
            //TxtFinancialComments.Text = "";
            //TxtPeopleComments.Text = "";
            //TxtProcessEfficiencyComments.Text = "";


            CleartextBoxes(this);





            ////////////////////////////////End Clear box///////////////////////////////////////////
       
        lblStatus.Text = "Records Successfuly Saved!";
        lblStatus.ForeColor = System.Drawing.Color.Blue;

    }
        //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);
    }//end btnSavePRAF_Click



    public void CleartextBoxes(Control parent)
    {

        foreach (Control c in parent.Controls)
        {
            if ((c.GetType() == typeof(TextBox)))
            {

                ((TextBox)(c)).Text = "";
            }

            if (c.HasControls())
            {
                CleartextBoxes(c);
            }
        }
    }


    //totalObtainableScore = r.Cells[2].Text;
    //Label empNo = (Label)r.Cells[4].FindControl("EMPLOYEE_NO");
    //Label totalKPINumber = (Label)r.Cells[1].FindControl("TOTAL_KPI_NUMBER");
    //Label totalObtainableScore = (Label)r.Cells[2].FindControl("TOTAL_KPI_NUMBER");
    //Label empNo = (Label)r.Cells[4].FindControl("EMPLOYEE_NO");

    // TextBox box2 = (TextBox)GrdViewKPI.Rows[rowIndex].Cells[2].FindControl("TextBox2");
    //TextBox box3 = (TextBox)GrdViewKPI.Rows[rowIndex].Cells[3].FindControl("TextBox3");
    //get the values from the TextBoxes
    //then add it to the collections with a comma "," as the delimited values
    //protected void btnSavePRGS_Click(object sender, EventArgs e)
    //{
    //    int rowIndex = 0;
    //    string kpiDimension;
    //    // string totalKpiNo;
    //    //string totalObtainableScore;

    //    StringCollection sc = new StringCollection();

    //    if (ViewState["CurrentTable"] != null)
    //    {

    //        DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];

    //        if (dtCurrentTable.Rows.Count > 0)
    //        {

    //            for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
    //            {

    //                //extract the TextBox values
    //                kpiDimension = GrdViewKPI.Rows[rowIndex].Cells[0].Text;
    //                Label totalKPINumber = (Label)GrdViewKPI.Rows[rowIndex].Cells[1].FindControl("TOTAL_KPI_NUMBER");
    //                Label totalObtainableScore = (Label)GrdViewKPI.Rows[rowIndex].Cells[2].FindControl("TOTAL_KPI_NUMBER");
    //               // TextBox box2 = (TextBox)GrdViewKPI.Rows[rowIndex].Cells[2].FindControl("TextBox2");
    //               //TextBox box3 = (TextBox)GrdViewKPI.Rows[rowIndex].Cells[3].FindControl("TextBox3");



    //                //get the values from the TextBoxes
    //                //then add it to the collections with a comma "," as the delimited values

    //                sc.Add(kpiDimension + "," + totalKPINumber.Text + "," + totalObtainableScore.Text);

    //                rowIndex++;

    //            }//end for

    //            //Call the method for executing inserts

    //            InsertRecords(sc);

    //        }

    //    }
    //}//end btnSavePRGS_Click

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
    protected void GrdViewKPI_SelectedIndexChanged(object sender, EventArgs e)
    {


    }//GrdViewKPI_SelectedIndexChanged
    protected void GrdViewKPI_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewKPI.PageIndex = e.NewPageIndex;
        GrdViewKPI.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewKPI_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewKPI.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewKPI.DataSource = dataView;
            GrdViewKPI.DataBind();
        }





    }//end _Sorting
    protected void GrdViewKPI_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    decimal grdTotal = 0;
    protected void GrdViewKPI_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        //decimal grdTotal = 0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TOTAL_OBTAINABLE_SCORE"));
            
              //(DataBinder.Eval(e.Row.DataItem, "TOTAL_OBTAINABLE_SCORE"));
            grdTotal = grdTotal + rowTotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbl100percent");
            Label lbl70 = (Label)e.Row.FindControl("lbl70percent");
            Label lblWS = (Label)e.Row.FindControl("lblWeightedScore");

            Label lbl00First = (Label)e.Row.FindControl("Lbl001");
            Label lbl00Second = (Label)e.Row.FindControl("Lbl002");
            //decimal tot = grdTotal / 100;
            decimal tot = grdTotal;
            if (tot > 101)
            {
                decimal tot200 = tot / 200;
                lbl.Text = tot200.ToString("P");
            }
            else 
            {
                lbl.Text = tot.ToString()+"%";
            }
            //lbl.Text = tot.ToString("P");
            lbl70.Text = "70.0%";
            lblWS.Text = "Weighted Score";
            lbl00First.Text = "0.0%";
            lbl00Second.Text = "0.0%";
        }
    }//GrdViewKPI_RowDataBound



    //private Decimal orderTotal = 0.0M;

    //protected void GrdViewKPI_RowCreated(Object sender, GridViewRowEventArgs e)
    //{

    //    if (e.Row.RowType == DataControlRowType.Footer)
    //    {
    //        // Get the OrderTotalLabel Label control in the footer row.
    //        Label total = (Label)e.Row.FindControl("lbl70percent");
    //        // Display the grand total of the order formatted as currency.
    //        if (total != null)
    //        {
    //            total.Text = orderTotal.ToString("c");
    //        }
    //     }

    //}
    //int totalObtainableScore = 0;
    //foreach (GridViewRow r in GrdViewKPI.Rows)
    //{
    //    Label totalObtainableScore1 = (Label)r.Cells[2].FindControl("TOTAL_OBTAINABLE_SCORE1");
    //    totalObtainableScore += Convert.ToInt32(totalObtainableScore1.Text);

    //}//end for

    //if (e.Row.RowType == DataControlRowType.DataRow)
    //{

    //    // Get the cell that contains the item total.
    //    TableCell cell = e.Row.Cells[2];

    //    // Get the DataBoundLiteralControl control that contains the 
    //    // data-bound value.
    //    DataBoundLiteralControl boundControl = (DataBoundLiteralControl)cell.Controls[0];

    //    // Remove the '$' character so that the type converter works properly.
    //    String itemTotal = boundControl.Text;
    //    //.Replace("$", "")
    //    // Add the total for an item (row) to the order total.
    //    orderTotal += Convert.ToDecimal(itemTotal);

    //}







    protected void GrdViewFinancial_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Financial (Job holder’s direct contribution to CDL's profitability in quantitative terms and financial management capabilities)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);
            GrdViewFinancial.Controls[0].Controls.AddAt(0, gvrow);
        }
    }
    protected void GrdViewFinancial_SelectedIndexChanged(object sender, EventArgs e)
    {

    }//GrdViewFinancial_SelectedIndexChanged
    protected void GrdViewFinancial_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewFinancial.PageIndex = e.NewPageIndex;
        GrdViewFinancial.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewFinancial_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewFinancial.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewFinancial.DataSource = dataView;
            GrdViewFinancial.DataBind();
        }





    }//end _Sorting
    protected void GrdViewFinancial_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand


    protected void GrdViewCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Customer (Job holder’s ability to grow, maintain and retain CDL's customer base)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewCustomer.Controls[0].Controls.AddAt(0, gvrow);






        }
    }//end _RowDataBound
    protected void GrdViewCustomer_SelectedIndexChanged(object sender, EventArgs e)
    {

    }//_SelectedIndexChanged
    protected void GrdViewCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewCustomer.PageIndex = e.NewPageIndex;
        GrdViewCustomer.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewCustomer_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewCustomer.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewCustomer.DataSource = dataView;
            GrdViewCustomer.DataBind();
        }





    }//end _Sorting
    protected void GrdViewCustomer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand



    //protected void GrdViewProcessEfficiency_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{

    //    TextBox txtActual = (TextBox)GrdViewProcessEfficiency.Rows[e.RowIndex].FindControl("ACTUAL");

    //    //string content = reader["name"].ToString() + "_" + reader["department"].ToString() + "_" + reader["GRADE_LEVEL"].ToString() +
    //    //           "_" + reader["EMPLOYEE_NO"].ToString() + "_" + reader["POSITION_OR_JOBROLE"].ToString() + "_" + reader["USERNAME"].ToString();
    //    string content = txtActual.Text + "_"; 
    //    ////string[] sepsess = rst.Split('_');
    //    ////                //        empName = sepsess[0];
    //    ////                //        empDept = sepsess[1];


    //    TextBox txtPartETA = (TextBox)rwGridView.Rows[e.RowIndex].FindControl("part_ETA");
    //    DropDownList drpDownLst = (DropDownList)rwGridView.Rows[e.RowIndex].FindControl("part_status");
    //    string svin = rwGridView.Rows[e.RowIndex].Cells[0].Text;

    //  }

    protected void GrdViewProcessEfficiency_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdViewProcessEfficiency_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewProcessEfficiency.PageIndex = e.NewPageIndex;
        GrdViewProcessEfficiency.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewProcessEfficiency_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewProcessEfficiency.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewProcessEfficiency.DataSource = dataView;
            GrdViewProcessEfficiency.DataBind();
        }





    }//end _Sorting
    protected void GrdViewProcessEfficiency_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewProcessEfficiency_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Process Efficiency (Job holder’s ability to achieve CDL's defined internal process standards)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewProcessEfficiency.Controls[0].Controls.AddAt(0, gvrow);






        }
    }//_RowDataBound

    protected void GrdViewPeople_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdViewPeople_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewPeople.PageIndex = e.NewPageIndex;
        GrdViewPeople.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewPeople_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewPeople.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewPeople.DataSource = dataView;
            GrdViewPeople.DataBind();
        }





    }//end _Sorting
    protected void GrdViewPeople_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewPeople_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "People (Job holder's innovation and learning capabilities)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewPeople.Controls[0].Controls.AddAt(0, gvrow);
        }
    }//_RowDataBound

    protected void GrdViewBrand_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GrdViewBrand_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GrdViewBrand.PageIndex = e.NewPageIndex;
        GrdViewBrand.DataBind();
    }//end _PageIndexChanging
    protected void GrdViewBrand_Sorting(object sender, GridViewSortEventArgs e)
    {
        DataTable dataTable = GrdViewBrand.DataSource as DataTable;

        if (dataTable != null)
        {
            DataView dataView = new DataView(dataTable);
            dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

            GrdViewBrand.DataSource = dataView;
            GrdViewBrand.DataBind();
        }





    }//end _Sorting
    protected void GrdViewBrand_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Select")
        {

            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);

            int RowIndex = gvr.RowIndex;

        }
    }//_RowCommand
    protected void GrdViewBrand_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow gvRow = e.Row;
        if (gvRow.RowType == DataControlRowType.Header)
        {
            GridViewRow gvrow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
            TableCell cell0 = new TableCell();
            cell0.Text = "Brand (How external parties view CDL)";
            cell0.HorizontalAlign = HorizontalAlign.Center;
            cell0.ColumnSpan = 8;
            // TableCell cell1 = new TableCell();
            // cell1.Text = "No. Of Employees";
            // cell1.HorizontalAlign = HorizontalAlign.Center;
            //cell1.ColumnSpan = 2;
            gvrow.Cells.Add(cell0);
            // gvrow.Cells.Add(cell1);

            cell0.Attributes.Add("class", "GVheader");
            GrdViewBrand.Controls[0].Controls.AddAt(0, gvrow);
        }
    }//_RowDataBound



    //protected void btnShowSubPRGoalSettings_Click(object sender, EventArgs e)
    //{
    //    String username = Session["usr"].ToString();
    //    string monthValue;
    //    string appraisalPeriod;
    //    //string employeeNo;

    //    if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
    //    {
    //        monthValue = "00" + ddlMonth.SelectedValue;
    //    }
    //    else
    //    {
    //        monthValue = "0" + ddlMonth.SelectedValue;
    //    }

    //    appraisalPeriod = ddlYear.SelectedValue + monthValue;

    //    if (DDLSubName.Visible == true)
    //    {
    //        //DDLSubName.Enabled = true;
    //        if (string.IsNullOrEmpty(DDLSubName.SelectedValue))
    //        {
    //            lblStatusSub.Text = "Please Specify the Subordinate Name";
    //            lblStatusSub.ForeColor = System.Drawing.Color.Red;
    //            return;
    //        }


    //        try
    //        {
    //            string countSubordinate = crudsbLL.getPositionsCount(username);
    //            if (countSubordinate.Equals("1"))
    //            {
    //                string subSelectedValue = DDLSubName.SelectedValue;
    //                //Session["empNoSession"] = subSelectedValue.Trim();
    //                ///////////////////////Display the selected guy///////////////////////////////////////////

    //                string empName;
    //                string empGradeLevel;
    //                string empDept;
    //                string empNoSess = subSelectedValue;


    //                //try
    //                //{
    //                //    //codes here
    //                //    string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());

    //                //    if (rst != string.Empty)
    //                //    {
    //                //        lblStatus.Text = "Employee record found";// +rst.ToString();
    //                //        lblStatus.ForeColor = System.Drawing.Color.Blue;
    //                //        string[] sepsess = rst.Split('_');
    //                //        empName = sepsess[0];
    //                //        empDept = sepsess[1];
    //                //        empGradeLevel = sepsess[2];
    //                //        employeeNo = sepsess[3];
    //                //        LblName.Text = empName;
    //                //        LblGroupDepartment.Text = empDept;
    //                //        LblGradeLevel.Text = empGradeLevel;
    //                //        LblHolderSignature.Text = sepsess[0];
    //                //        LblAppraisalPeriod.Text = appraisalPeriod;

    //                //        Session["appPeriod"]=LblAppraisalPeriod.Text;
    //                //        Session["holderSign"] = LblHolderSignature.Text;
    //                //        Session["empNo"] = employeeNo;

    //                //        DDLHolderDay.Enabled = false;
    //                //        DDLHolderMonth.Enabled = false;
    //                //        DDLHolderYear.Enabled = false;

    //                //        //////////////////////////////////////
    //                //        sessionDimension(username, employeeNo, appraisalPeriod);
    //                //        //DataTable tablePEffectAcct = crudsbLL.getPEffectAcctList(username, employeeNo, appraisalPeriod);
    //                //        //GrdViewPersEffectAccount.DataSource = tablePEffectAcct;
    //                //        //GrdViewPersEffectAccount.DataBind();
    //                //        ///////////////////////////////////

    //                //        string rstSupervisor = crudsbLL.getPhaseOneContent(username.ToString().Trim().ToLower());
    //                //        string[] sepSup = rstSupervisor.Split('_');
    //                //        if (rstSupervisor != string.Empty)
    //                //        {
    //                //            string supName = sepSup[0];
    //                //            LblAppraiserSignature.Text = supName;
    //                //        }

    //                //    }
    //                //    else
    //                //    {

    //                //        lblStatus.Text = "User record not found";// +rst.ToString();
    //                //        lblStatus.ForeColor = System.Drawing.Color.Red;


    //                //    }
    //                try
    //                {
    //                    //codes here
    //                    string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());

    //                    if (rst != string.Empty)
    //                    {
    //                        lblStatus.Text = "User record found";// +rst.ToString();
    //                        lblStatus.ForeColor = System.Drawing.Color.Blue;
    //                        //
    //                        //authPanel.Visible = true;

    //                        //S[LIT CONTENT
    //                        string[] sepsess = rst.Split('_');
    //                        //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
    //                        empName = sepsess[0];
    //                        empDept = sepsess[1];
    //                        empGradeLevel = sepsess[2];
    //                        LblName.Text = empName;
    //                        LblGroupDepartment.Text = empDept;
    //                        LblGradeLevel.Text = empGradeLevel;
    //                        LblAppraisalPeriod.Text = appraisalPeriod;

    //                        PnlSub.Visible = false;
    //                        PnlMain.Visible = true;

    //                    }
    //                    else
    //                    {

    //                        lblStatus.Text = "User record not found";// +rst.ToString();
    //                        lblStatus.ForeColor = System.Drawing.Color.Red;


    //                    }
    //                }
    //                catch (Exception ex)
    //                {
    //                    lblStatus.Text = "Object Error: " + ex.Message;
    //                    lblStatus.ForeColor = System.Drawing.Color.Red;
    //                    //return;
    //                }


    //                //employeeNo = LblEmpNo.Text;
    //                /////////////////////////////////////////////////

    //                //sessionDimension(empNoSess, employeeNo, appraisalPeriod);

    //                /////////////////////////////////////////////////
    //                sessionDimension(empNoSess);
    //                ////////////////////////////////////////////////



    //                ////////////////////////I Just added this to solve a problem///////////////////////
    //                //string kpiDimension = "";
    //                //string totalKPINumber = "";
    //                //string totalObtainableScore = "";
    //                //string empNo = "";
    //                //StringCollection sc = new StringCollection();
    //                //foreach (GridViewRow r in GrdViewKPI.Rows)
    //                //{
    //                //    //extract the TextBox values
    //                //    kpiDimension = r.Cells[0].Text;
    //                //    //Session['kpiDimension']=kpiDimension.ToString();
    //                //    //totalKPINumber = r.Cells[1].Text;
    //                //    Label totalObtainableScore1 = (Label)r.Cells[1].FindControl("TOTAL_OBTAINABLE_SCORE1");
    //                //    Label totalKPINumber1 = (Label)r.Cells[2].FindControl("TOTAL_KPI_NUMBER1");
    //                //    empNo = r.Cells[4].Text;
    //                //    totalKPINumber = totalKPINumber1.Text;
    //                //    totalObtainableScore = totalObtainableScore1.Text;
    //                //    sc.Add(kpiDimension + "," + totalKPINumber + "," + totalObtainableScore + "," + empNo);
    //                //}//end for

    //                ////////////////////////I Just added this to solve a problem////////////////////////////////





    //                //btnSendToSupervisor.Visible = false;
    //                PnlSub.Visible = false;
    //                PnlMain.Visible = true;


    //            }
    //            else
    //            {
    //                lblStatusSub.Text = "Sorry you do not have subordinate(s)!";
    //                lblStatusSub.ForeColor = System.Drawing.Color.Red;
    //                PnlMain.Visible = false;

    //            }

    //        }
    //        catch (Exception ex)
    //        {
    //            lblStatus.Text = "Object Error: " + ex.Message;
    //            lblStatus.ForeColor = System.Drawing.Color.Red;
    //            return;
    //        }
    //    }//end if > 1
    //    else
    //    {
    //        ///////////////////////////display for the logged in guy/////////////////////////
    //        //string empName;
    //        //string empGradeLevel;
    //        //string empDept;


    //        ////String username = Session["usr"].ToString();
    //        //// string empNoSess = Session["empNoSession"].ToString();



    //        //try
    //        //{
    //        //    //codes here
    //        //    string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

    //        //    if (rst != string.Empty)
    //        //    {
    //        //        lblStatus.Text = "Employee record found";// +rst.ToString();
    //        //        lblStatus.ForeColor = System.Drawing.Color.Blue;
    //        //        //
    //        //        //authPanel.Visible = true;

    //        //        //S[LIT CONTENT
    //        //        string[] sepsess = rst.Split('_');
    //        //        //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
    //        //        empName = sepsess[0];
    //        //        empDept = sepsess[1];
    //        //        empGradeLevel = sepsess[2];
    //        //        LblEmpNo.Text = sepsess[3];
    //        //        LblPositionId.Text = sepsess[4];
    //        //        employeeNo=LblEmpNo.Text;
    //        //        LblAppraisalPeriod.Text = appraisalPeriod;
    //        //        LblName.Text = empName;
    //        //        LblGroupDepartment.Text = empDept;
    //        //        LblGradeLevel.Text = empGradeLevel;
    //        //        //LblHolderSignature.Text = sepsess[5];
    //        //        LblHolderSignature.Text = sepsess[0];


    //        //        Session["appPeriod"] = LblAppraisalPeriod.Text;
    //        //        Session["holderSign"] = LblHolderSignature.Text;
    //        //        Session["empNo"] = employeeNo;




    //        //sessionDimension(username, employeeNo, appraisalPeriod);
    //        //btnApprove.Visible = false;
    //        //btnReview.Visible = false;
    //        //btnSendToSupervisor.Visible = true;
    //        //DDLAppraiserDay.Enabled = false;
    //        //DDLAppraiserMonth.Enabled = false;
    //        //DDLAppraiserYear.Enabled = false;
    //        //////////////////////////End display for the logged in guy///////////////////////
    //        //PnlSub.Visible = false;
    //        //PnlMain.Visible = true;




    //        //    }
    //        //    else
    //        //    {

    //        //        lblStatusSub.Text = "Employee record not found";// +rst.ToString();
    //        //        lblStatusSub.ForeColor = System.Drawing.Color.Red;


    //        //    }
    //        //}
    //        //catch (Exception ex)
    //        //{
    //        //    lblStatus.Text = "Object Error: " + ex.Message;
    //        //    lblStatus.ForeColor = System.Drawing.Color.Red;
    //        //    //return;
    //        //}
    //        string empName;
    //        string empGradeLevel;
    //        string empDept;

    //        try
    //        {
    //            //codes here
    //            string rst = crudsbLL.getPhaseOneContent(username.Trim().ToLower());

    //            if (rst != string.Empty)
    //            {
    //                lblStatus.Text = "User record found";// +rst.ToString();
    //                lblStatus.ForeColor = System.Drawing.Color.Blue;
    //                //
    //                //authPanel.Visible = true;

    //                //S[LIT CONTENT
    //                string[] sepsess = rst.Split('_');
    //                //ontent = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
    //                empName = sepsess[0];
    //                empDept = sepsess[1];
    //                empGradeLevel = sepsess[2];
    //                LblEmpNo.Text = sepsess[3];
    //                LblPositionId.Text = sepsess[4];

    //                LblName.Text = empName;
    //                LblGroupDepartment.Text = empDept;
    //                LblGradeLevel.Text = empGradeLevel;
    //                LblAppraisalPeriod.Text = appraisalPeriod;

    //                PnlSub.Visible = false;
    //                PnlMain.Visible = true;

    //            }
    //            else
    //            {

    //                lblStatus.Text = "User record not found";// +rst.ToString();
    //                lblStatus.ForeColor = System.Drawing.Color.Red;


    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            lblStatus.Text = "Object Error: " + ex.Message;
    //            lblStatus.ForeColor = System.Drawing.Color.Red;
    //            //return;
    //        }


    //        sessionDimension(username);








    //    }//end else




    //}//btnShowSubPRGoalSettings_Click
    protected void lnkbtnSavePRGS_Click(object sender, EventArgs e)
    {
        //PnlMain.
        // int rowIndex = 0;
        string kpiDimension = "";
        string totalKPINumber = "";
        string totalObtainableScore = "";
        string empNo = "";
        StringCollection sc = new StringCollection();

        foreach (GridViewRow r in GrdViewKPI.Rows)
        {
            //extract the TextBox values
            kpiDimension = r.Cells[0].Text;
            //Session['kpiDimension']=kpiDimension.ToString();
            //totalKPINumber = r.Cells[1].Text;
            Label totalObtainableScore1 = (Label)r.Cells[1].FindControl("TOTAL_OBTAINABLE_SCORE1");
            Label totalKPINumber1 = (Label)r.Cells[2].FindControl("TOTAL_KPI_NUMBER1");
            empNo = r.Cells[4].Text;
            totalKPINumber = totalKPINumber1.Text;
            totalObtainableScore = totalObtainableScore1.Text;
            sc.Add(kpiDimension + "," + totalKPINumber + "," + totalObtainableScore + "," + empNo);
        }//end for
        //Call the method for executing inserts
        InsertRecords(sc);
        //////////////////////////////////Financial//////////////////////////////////////////////////////////////
        StringCollection scFinancial = new StringCollection();

        foreach (GridViewRow r1 in GrdViewFinancial.Rows)
        {
            //extract the TextBox values
            string idFinancial = r1.Cells[0].Text;
            string kpiIdFinancial = r1.Cells[1].Text;
            string kpiDimensionFinancial = "Financial";
            DropDownList kpiTypeFin = (DropDownList)r1.Cells[3].FindControl("KPI_TYPE");
            string kpiTypeFinancial = kpiTypeFin.SelectedValue;
            string weightFinancial = r1.Cells[4].Text;
            TextBox targetFin = (TextBox)r1.Cells[5].FindControl("TARGET");
            string targetFinancial = targetFin.Text;
            scFinancial.Add(kpiIdFinancial + "," + kpiTypeFinancial + "," + weightFinancial + "," + targetFinancial + "," + kpiDimensionFinancial);
        }//end for
        //Call the method for executing inserts
        InsertDimensionRecords(scFinancial);
        ///////////////////////////////////End Financial////////////////////////////////////////////////////////////
        //////////////////////////////////Customer/////////////////////////////////////////////////////////////////
        StringCollection scCustomer = new StringCollection();

        foreach (GridViewRow r in GrdViewCustomer.Rows)
        {
            //extract the TextBox values
            string idCustomer = r.Cells[0].Text;
            string kpiIdCustomer = r.Cells[1].Text;
            string kpiDimensionCustomer = "Customer";
            DropDownList kpiTypeCus = (DropDownList)r.Cells[3].FindControl("KPI_TYPE");
            string kpiTypeCustomer = kpiTypeCus.SelectedValue;
            string weightCustomer = r.Cells[4].Text;
            TextBox targetCus = (TextBox)r.Cells[5].FindControl("TARGET");
            string targetCustomer = targetCus.Text;
            scCustomer.Add(kpiIdCustomer + "," + kpiTypeCustomer + "," + weightCustomer + "," + targetCustomer + "," + kpiDimensionCustomer);
        }//end for
        //Call the method for executing inserts
        InsertDimensionRecords(scCustomer);
        ///////////////////////////////////End Customer////////////////////////////////////////////////////////////

        //////////////////////////////////ProcessEfficiency/////////////////////////////////////////////////////////////////
        StringCollection scProcessEfficiency = new StringCollection();

        foreach (GridViewRow r in GrdViewProcessEfficiency.Rows)
        {
            //extract the TextBox values
            string idProcessEfficiency = r.Cells[0].Text;
            string kpiIdProcessEfficiency = r.Cells[1].Text;
            string kpiDimensionProcessEfficiency = "Process Efficiency";
            DropDownList kpiTypePE = (DropDownList)r.Cells[3].FindControl("KPI_TYPE");
            string kpiTypeProcessEfficiency = kpiTypePE.SelectedValue;
            string weightProcessEfficiency = r.Cells[4].Text;
            TextBox targetPE = (TextBox)r.Cells[5].FindControl("TARGET");
            string targetProcessEfficiency = targetPE.Text;
            scProcessEfficiency.Add(kpiIdProcessEfficiency + "," + kpiTypeProcessEfficiency + "," + weightProcessEfficiency + "," + targetProcessEfficiency + "," + kpiDimensionProcessEfficiency);
        }//end for
        //Call the method for executing inserts
        InsertDimensionRecords(scProcessEfficiency);
        ///////////////////////////////////End ProcessEfficiency////////////////////////////////////////////////////////////

        //////////////////////////////////People/////////////////////////////////////////////////////////////////
        StringCollection scPeople = new StringCollection();

        foreach (GridViewRow r in GrdViewPeople.Rows)
        {
            //extract the TextBox values
            string idPeople = r.Cells[0].Text;
            string kpiIdPeople = r.Cells[1].Text;
            string kpiDimensionPeople = "People";
            DropDownList kpiTypePE = (DropDownList)r.Cells[3].FindControl("KPI_TYPE");
            string kpiTypePeople = kpiTypePE.SelectedValue;
            string weightPeople = r.Cells[4].Text;
            TextBox targetP = (TextBox)r.Cells[5].FindControl("TARGET");
            string targetPeople = targetP.Text;
            scPeople.Add(kpiIdPeople + "," + kpiTypePeople + "," + weightPeople + "," + targetPeople + "," + kpiDimensionPeople);
        }//end for
        //Call the method for executing inserts
        InsertDimensionRecords(scPeople);
        ///////////////////////////////////End People////////////////////////////////////////////////////////////

        //////////////////////////////////Brand/////////////////////////////////////////////////////////////////
        StringCollection scBrand = new StringCollection();

        foreach (GridViewRow r in GrdViewBrand.Rows)
        {
            //extract the TextBox values
            string idBrand = r.Cells[0].Text;
            string kpiIdBrand = r.Cells[1].Text;
            string kpiDimensionBrand = "Brand";
            DropDownList kpiTypeBr = (DropDownList)r.Cells[3].FindControl("KPI_TYPE");
            string kpiTypeBrand = kpiTypeBr.SelectedValue;
            string weightBrand = r.Cells[4].Text;
            TextBox targetP = (TextBox)r.Cells[5].FindControl("TARGET");
            string targetBrand = targetP.Text;
            scBrand.Add(kpiIdBrand + "," + kpiTypeBrand + "," + weightBrand + "," + targetBrand + "," + kpiDimensionBrand);
        }//end for
        //Call the method for executing inserts
        InsertDimensionRecords(scBrand);
        ///////////////////////////////////End Brand////////////////////////////////////////////////////////////


        //////////////////////////////////////Clear box////////////////////////////////////////
        //TxtBrandComments.Text = "";
        //TxtCustomerComments.Text = "";
        //TxtFinancialComments.Text = "";
        //TxtPeopleComments.Text = "";
        //TxtProcessEfficiencyComments.Text = "";
        CleartextBoxes(this);
        ////////////////////////////////End Clear box///////////////////////////////////////////


    }
    protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
    {
        //String username = Session["usr"].ToString();
        //string monthValue, appraisalPeriod;
        //if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
        //{
        //    monthValue = "00" + ddlMonth.SelectedValue;
        //}
        //else
        //{
        //    monthValue = "0" + ddlMonth.SelectedValue;
        //}

        //appraisalPeriod = ddlYear.SelectedValue + monthValue;


        //sessionPeriodDimension(appraisalPeriod, username);

        //GrdViewKPI.Columns[4].Visible = false;
        //GrdViewBrand.Columns[1].Visible = false;
        //GrdViewFinancial.Columns[1].Visible = false;
        //GrdViewProcessEfficiency.Columns[1].Visible = false;
        //GrdViewPeople.Columns[1].Visible = false;
        //GrdViewCustomer.Columns[1].Visible = false;

        //GrdViewBrand.Columns[0].Visible = false;
        //GrdViewFinancial.Columns[0].Visible = false;
        //GrdViewProcessEfficiency.Columns[0].Visible = false;
        //GrdViewPeople.Columns[0].Visible = false;
        //GrdViewCustomer.Columns[0].Visible = false;

        //lblStatus.Text = "New User information Displayed";
    }
    protected void ddlMonth_TextChanged(object sender, EventArgs e)
    {
        //String username = Session["usr"].ToString();
        //string monthValue, appraisalPeriod;
        //if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
        //{
        //    monthValue = "00" + ddlMonth.SelectedValue;
        //}
        //else
        //{
        //    monthValue = "0" + ddlMonth.SelectedValue;
        //}

        //appraisalPeriod = ddlYear.SelectedValue + monthValue;


        //sessionPeriodDimension(appraisalPeriod, username);

        //GrdViewKPI.Columns[4].Visible = false;
        //GrdViewBrand.Columns[1].Visible = false;
        //GrdViewFinancial.Columns[1].Visible = false;
        //GrdViewProcessEfficiency.Columns[1].Visible = false;
        //GrdViewPeople.Columns[1].Visible = false;
        //GrdViewCustomer.Columns[1].Visible = false;

        //GrdViewBrand.Columns[0].Visible = false;
        //GrdViewFinancial.Columns[0].Visible = false;
        //GrdViewProcessEfficiency.Columns[0].Visible = false;
        //GrdViewPeople.Columns[0].Visible = false;
        //GrdViewCustomer.Columns[0].Visible = false;

        //lblStatus.Text = "New User information Displayed";
    }
}