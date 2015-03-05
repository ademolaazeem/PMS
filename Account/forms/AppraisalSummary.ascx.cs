using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using System.Collections.Specialized;
using System.Text;

public partial class Account_forms_AppraisalSummary : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
         String username = Session["usr"].ToString();
        //string appraisalPeriod;
        string employeeNo;
        string empName;
        string empGradeLevel;
        string empDept;
        
        //////////////////////////////////Pretest/////////////////////////////////////////////
        string countSubordinate = crudsbLL.getPositionsCount(username);
        if (countSubordinate == "1")
        {
            //////////////////////////////////Get Subordinate/////////////////////////////////////
            DDLSubName.DataSource = crudsbLL.getSubordinateNameDropDown(username);
            DDLSubName.DataTextField = "NAME";
            DDLSubName.DataValueField = "USERNAME";
            DDLSubName.DataBind();
            DDLSubName.Items.Insert(0, new ListItem("Select Subordinate", ""));
            //////////////////////////////////End Get Subordinate/////////////////////////////////
            btnShowSubBCAppraisalForm.Text = "Show Subordinate BC Goal Settings";
            DDLSubName.Visible = true;
            LblSubName.Visible = true;

        }
        else if (countSubordinate == "0")
        {
            lblStatusSub.Text = "Your Subordinate(s) is/are not available, Please Continue";
            btnShowSubBCAppraisalForm.Text = "Show your BC Goal Settings";
            lblStatusSub.ForeColor = System.Drawing.Color.Red;
            DDLSubName.Visible = false;
            LblSubName.Visible = false;
            chkMyDetails.Visible = false;
        }


        PnlSub.Visible = true;
        PnlMain.Visible = false;

        //int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Form: User " + username + " successfully views behavioural competencies page for Goal Settings Interface", "View");
            
            
         ////////////////////////////////////Date/////////////////////////////////////////////
        for (int i = 2013; i <= 2030; i++)
        {
            ddlYear.Items.Add(i.ToString());
        }
        ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        for (int i = 1; i <= 12; i++)
        {


            ddlMonth.Items.Add(i.ToString());


        }
        ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
        
        ////////////////////////////////End Date/////////////////////////////////////////////












        //////////////////////Date/////////////////////////////////////////////////
        for (int i = 2013; i <= 2030; i++)
        {
            DDLHolderYear.Items.Add(i.ToString());
        }
        DDLHolderYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {
            DDLHolderMonth.Items.Add(i.ToString());
        }
        DDLHolderMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

        //Fill days
        FillHolderDays();

        for (int i = 2013; i <= 2030; i++)
        {
            DDLAppraiserYear.Items.Add(i.ToString());
        }
        DDLAppraiserYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {
            DDLAppraiserMonth.Items.Add(i.ToString());
        }
        DDLAppraiserMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

        //Fill days
        FillAppraiserDays();


        for (int i = 2013; i <= 2030; i++)
        {
            DDLConcurrentYear.Items.Add(i.ToString());
        }
        DDLConcurrentYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

        //Fill Months
        for (int i = 1; i <= 12; i++)
        {
            DDLConcurrentMonth.Items.Add(i.ToString());
        }
        DDLConcurrentMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

        //Fill days
        FillConcurrentDays();
        ///////////////////////End Date/////////////////////////////////////////

       

       

    }//_Load


    public void FillHolderDays()
    {
       
            DDLHolderDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLHolderYear.SelectedValue), Convert.ToInt32(DDLHolderMonth.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                DDLHolderDay.Items.Add(i.ToString());
            }
            DDLHolderDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected

       
    }
    public void FillAppraiserDays()
    {
        DDLAppraiserDay.Items.Clear();
        //getting numbner of days in selected month & year
        int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLAppraiserYear.SelectedValue), Convert.ToInt32(DDLAppraiserMonth.SelectedValue));

        //Fill days
        for (int i = 1; i <= noofdays; i++)
        {
            DDLAppraiserDay.Items.Add(i.ToString());
        }
        DDLAppraiserDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
    }

    public void FillConcurrentDays()
    {
        DDLConcurrentDay.Items.Clear();
        //getting numbner of days in selected month & year
        int noofdays = DateTime.DaysInMonth(Convert.ToInt32(DDLConcurrentYear.SelectedValue), Convert.ToInt32(DDLConcurrentMonth.SelectedValue));

        //Fill days
        for (int i = 1; i <= noofdays; i++)
        {
            DDLConcurrentDay.Items.Add(i.ToString());
        }
        DDLConcurrentDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
    }
    
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
    
   
   
   

    private void refillSession()
    {
        LblName.Text = Session["employeeName"].ToString();
        LblGradeLevel.Text = Session["gLevel"].ToString();
        LblGroupDepartment.Text = Session["dept"].ToString();
        LblAppraisalPeriod.Text = Session["appPeriod"].ToString();
       
        PnlSub.Visible = false;
        PnlMain.Visible = true;
    }


    
   
  
    protected void chkMyDetails_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMyDetails.Checked == true)
        {
            DDLSubName.Visible = false;
            LblSubName.Visible = false;
            DDLConcurrent.Visible = false;
            LblConcurrent.Visible = false;
            chkSignConcurrent.Checked = false;
            chkSignConcurrent.Visible = false;
            
        }
        else
        {
            DDLSubName.Visible = true;
            LblSubName.Visible = true;
            DDLConcurrent.Visible = true;
            LblConcurrent.Visible = true; 
            chkSignConcurrent.Checked = false;
            chkSignConcurrent.Visible = true;
           
        }
    }
    protected void chkSignConcurrent_CheckedChanged(object sender, EventArgs e)
    {
        if (chkSignConcurrent.Checked == true)
        {
            DDLSubName.Visible = false;
            LblSubName.Visible = false;
            chkMyDetails.Checked = false;
            chkMyDetails.Visible = false;
            
        }
        else
        {
            DDLSubName.Visible = true;
            LblSubName.Visible = true;
            chkMyDetails.Checked = false;
            chkMyDetails.Visible = true;
        }
    }

    protected void  btnShowSubBCAppraisalForm_Click(object sender, EventArgs e)
     {
        String username = Session["usr"].ToString();
        string monthValue;
        string appraisalPeriod;
        string employeeNo;

        if (Convert.ToInt32(ddlMonth.SelectedValue) >= 1 && Convert.ToInt32(ddlMonth.SelectedValue) <= 9)
        {
            monthValue = "00" + ddlMonth.SelectedValue;
        }
        else
        {
            monthValue = "0" + ddlMonth.SelectedValue;
        }

        appraisalPeriod = ddlYear.SelectedValue + monthValue;
        Session["apprPeriod"]=appraisalPeriod;
        //employeeNo = LblEmpNo.Text;
        //if (DDLSubName.Items.Count > 1)
       if (DDLSubName.Visible==true)
        {

            Session["visble"] = "Yes";
            //DDLSubName.Enabled = true;
            if (string.IsNullOrEmpty(DDLSubName.SelectedValue))
            {
                lblStatusSub.Text = "Please Specify the Subordinate Name";
                lblStatusSub.ForeColor = System.Drawing.Color.Red;
                return;
            }


            try
            {
                string countSubordinate = crudsbLL.getPositionsCount(username);
                //string countSubordinate = crudsbLL.getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate.Equals("1"))
                {
                    string subSelectedValue = DDLSubName.SelectedValue;
                   

                    string empName;
                    string empGradeLevel;
                    string empDept;
                    string empNoSess = subSelectedValue;
                    string subEmail;
                    string positionId;


                    try
                    {
                        //codes here
                        //string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());
                        string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());
                        string rstPr = crudsbLL.checkPerformanceResult(empNoSess.Trim().ToLower(), appraisalPeriod);
                        string rstBc = crudsbLL.checkBehaviouralCompetencies(empNoSess.Trim().ToLower(), appraisalPeriod);



                        if (rst != string.Empty && rstPr != "0" && rstBc != "0")
                        {
                            string[] sepsess = rst.Split('_');
                            empName = sepsess[0];
                            empDept = sepsess[1];
                            empGradeLevel = sepsess[2];
                            employeeNo = sepsess[3];
                            positionId = sepsess[4];
                            subEmail = sepsess[6]; 
                            LblName.Text = empName;
                            LblGroupDepartment.Text = empDept;
                            LblGradeLevel.Text = empGradeLevel;
                            LblHolderSignature.Text = sepsess[0];
                            LblAppraisalPeriod.Text = appraisalPeriod;

                            Session["employeeName"] = empName;
                            Session["gLevel"] = empGradeLevel;
                            Session["dept"] = empDept;
                            //Session["appPeriod"] = LblAppraisalPeriod.Text;
                            Session["empNo"] = employeeNo;
                            Session["usrname"] = empNoSess;
                            Session["mail"] = subEmail;
                            Session["posJobrole"] = positionId;
                            Session["holderSign"] = LblHolderSignature.Text;
                            
                            sessionDimension(appraisalPeriod, empNoSess);

                            string rstSupervisor = crudsbLL.getPhaseOneContent(username.ToString().Trim().ToLower());
                            string[] sepSup = rstSupervisor.Split('_');
                            if (rstSupervisor != string.Empty)
                            {
                                string supName = sepSup[0];
                                LblAppraiserSignature.Text = supName;
                                Session["appraiserSig"] = supName;
                            }

                            //////Decide the what's enabled/////////////
                            TxtRating.Enabled = true;
                            TxtKeyStr.Enabled = true;
                            TxtKeyAch.Enabled = false;
                            TxtImpArea.Enabled = true;
                            TxtProposedDev.Enabled = true;
                            TxtConcurrentCmt.Enabled = false;
                            rdoAccept.Enabled = false;
                            rdoReject.Enabled = false;
                            TxtReasons.Enabled = false;
                            DDLHolderYear.Enabled = false;
                            DDLHolderMonth.Enabled = false;
                            DDLHolderDay.Enabled = false;

                            DDLAppraiserYear.Enabled = true;
                            DDLAppraiserMonth.Enabled = true;
                            DDLAppraiserDay.Enabled = true;

                            DDLConcurrentYear.Enabled = false;
                            DDLConcurrentMonth.Enabled = false;
                            DDLConcurrentDay.Enabled = false;

                            //LblHolderSignature.Text = empName;
                            btnRateSubordinate.Text = "Submit Subordinate Rating";

                            ////////////End Decide the what's enabled//////////////

                            PnlSub.Visible = false;
                            PnlMain.Visible = true;
                        }
                        else
                        {
                            PnlMain.Visible = false;
                            PnlSub.Visible = true;
                            lblStatusSub.Text = "Please check if the user information or the Performance Result/Behavioural competencies for the employee for this period is configured already or not. User information must be completed before summary could be generated";// +rst.ToString();
                            lblStatusSub.ForeColor = System.Drawing.Color.Red;


                        }
                    }
                    catch (Exception ex)
                    {
                        lblStatusSub.Text = "Object Error: " + ex.Message;
                        lblStatusSub.ForeColor = System.Drawing.Color.Red;
                        PnlMain.Visible = false;
                        //return;
                    }//end try catch

                }// end countSubordinate
                else
                {
                    PnlMain.Visible = false;
                    PnlSub.Visible = true;
                    lblStatusSub.Text = "Sorry you do not have subordinate(s)!";
                    lblStatusSub.ForeColor = System.Drawing.Color.Red;
                    

                }//end else countSubordinate

            }
            catch (Exception ex)
            {
                PnlMain.Visible = false;
                PnlSub.Visible = true;
                lblStatusSub.Text = "Object Error: " + ex.Message;
                lblStatusSub.ForeColor = System.Drawing.Color.Red;
                return;
            }//end catch

        }//end if visible
       else if (DDLSubName.Visible == false && DDLConcurrent.Visible==false)
        {

            Session["visble"] = "No";
           
           ///////////////////////////display for the logged in guy/////////////////////////
            string empName;
            string empGradeLevel;
            string empDept;
            string positionId;

            //btnRateSubordinate.Text = "Rate yourself";
            



            try
            {
                //codes here


                string rst11 = crudsbLL.getPhaseOneContent(username.Trim().ToLower());
                string rstPr = crudsbLL.checkPerformanceResult(username.Trim().ToLower(), appraisalPeriod);
                string rstBc = crudsbLL.checkBehaviouralCompetencies(username.Trim().ToLower(), appraisalPeriod);



                if (rst11 != string.Empty && rstPr != "0" && rstBc != "0")
                {
                                
                    string[] sepsess = rst11.Split('_');
                    empName = sepsess[0];
                    empDept = sepsess[1];
                    empGradeLevel = sepsess[2];
                    LblEmpNo.Text = sepsess[3];
                    positionId = sepsess[4];
                    LblPositionId.Text = sepsess[4];
                    employeeNo=LblEmpNo.Text;
                    LblAppraisalPeriod.Text = appraisalPeriod;
                    LblName.Text = empName;
                    LblGroupDepartment.Text = empDept;
                    LblGradeLevel.Text = empGradeLevel;


                    Session["employeeName"] = empName;
                    Session["gLevel"] = empGradeLevel;
                    Session["dept"] = empDept;
                    Session["appPeriod"] = appraisalPeriod;
                    Session["empNo"] = employeeNo;
                    Session["mail"] = sepsess[6]; 
                    Session["usrname"] =username;
                    Session["posJobrole"] = positionId;

                    LblHolderSignature.Text = empName;
                    
                    sessionDimension(appraisalPeriod, username);

                    //////Decide the what's enabled/////////////
                    TxtRating.Enabled = false;
                    TxtKeyStr.Enabled = false;
                    TxtKeyAch.Enabled = true;
                    TxtImpArea.Enabled = false;
                    TxtProposedDev.Enabled = false;
                    TxtConcurrentCmt.Enabled = false;
                    rdoAccept.Enabled = true;
                    rdoReject.Enabled = true;
                    TxtReasons.Enabled = true;
                    
                    DDLHolderYear.Enabled = true;
                    DDLHolderMonth.Enabled = true;
                    DDLHolderDay.Enabled = true;

                    DDLAppraiserYear.Enabled = false;
                    DDLAppraiserMonth.Enabled = false;
                    DDLAppraiserDay.Enabled = false;
                    
                    DDLConcurrentYear.Enabled = false;
                    DDLConcurrentMonth.Enabled = false;
                    DDLConcurrentDay.Enabled = false;
                    btnRateSubordinate.Text = "Submit your Rating";

                    //////End Decide the what's enabled/////////////
                    
                    PnlSub.Visible = false;
                    PnlMain.Visible = true;
                   
                }
                else
                {
                    PnlMain.Visible = false;
                    PnlSub.Visible = true;
                    lblStatusSub.Text = "Please check if the user information or the Performance Result/Behavioural competencies for the employee for this period is configured already or not. User information must be completed before summary could be generated";// +rst.ToString();
                    lblStatusSub.ForeColor = System.Drawing.Color.Red;

                }
            }
            catch (Exception ex)
            {
                PnlMain.Visible = false;
                PnlSub.Visible = true;
                lblStatusSub.Text = "Object Error: " + ex.Message;
                lblStatusSub.ForeColor = System.Drawing.Color.Red;
                //return;
            }


            
        }//end else if
       else if (DDLConcurrent.Visible == true)
       {

           Session["visble"] = "YesNo";
           if (string.IsNullOrEmpty(DDLConcurrent.SelectedValue))
           {
               lblStatusSub.Text = "Please Specify the Employee that you want to concurrently sign for!";
               lblStatusSub.ForeColor = System.Drawing.Color.Red;
               return;
           }


           try
           {
               string countSubordinate = crudsbLL.getConcurrentCount(username);
               //string countSubordinate = crudsbLL.getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
               if (countSubordinate.Equals("1"))
               {
                   string subSelectedValue = DDLConcurrent.SelectedValue;


                   string empName;
                   string empGradeLevel;
                   string empDept;
                   string empNoSess = subSelectedValue;
                   string subEmail;
                   string positionId;


                   try
                   {
                       //codes here
                       //string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());
                       string rst = crudsbLL.getPhaseOneContent(empNoSess.Trim().ToLower());
                       string rstPr = crudsbLL.checkPerformanceResult(empNoSess.Trim().ToLower(), appraisalPeriod);
                       string rstBc = crudsbLL.checkBehaviouralCompetencies(empNoSess.Trim().ToLower(), appraisalPeriod);

                       string rstCSign = crudsbLL.getAppraisalSummaryData(empNoSess.Trim().ToLower(), appraisalPeriod);

                       if (rstCSign != string.Empty)
                       {
                           string[] sepCon = rstCSign.Split('_');
                           string appraiserName = sepCon[10];

                           if (rst != string.Empty && rstPr != "0" && rstBc != "0")
                           {
                               string[] sepsess = rst.Split('_');
                               empName = sepsess[0];
                               empDept = sepsess[1];
                               empGradeLevel = sepsess[2];
                               employeeNo = sepsess[3];
                               positionId = sepsess[4];
                               subEmail = sepsess[6];
                               LblName.Text = empName;
                               LblGroupDepartment.Text = empDept;
                               LblGradeLevel.Text = empGradeLevel;
                               //LblHolderSignature.Text = sepsess[0];
                               LblAppraisalPeriod.Text = appraisalPeriod;

                               Session["employeeName"] = empName;
                               Session["gLevel"] = empGradeLevel;
                               Session["dept"] = empDept;
                               Session["appPeriod"] = LblAppraisalPeriod.Text;
                               Session["empNo"] = employeeNo;
                               Session["usrname"] = empNoSess;
                               Session["mail"] = subEmail;
                               Session["posJobrole"] = positionId;

                               LblHolderSignature.Text = empName;
                               LblAppraiserSignature.Text = appraiserName;
                               


                               string rstConcurrent = crudsbLL.getConcurrentSign(username.ToString().Trim().ToLower());
                               string[] sepConCurrent = rstConcurrent.Split('_');
                               if (rstConcurrent != string.Empty)
                               {
                                   string concurrentName = sepConCurrent[0];
                                   LblConcurrentSignShow.Text = concurrentName;
                                   Session["concurrentSig"] = concurrentName;
                               }

                               string rstSupervisor = crudsbLL.getSupervisorInformation(empNoSess.Trim().ToLower());
                               string[] sepSupervisor = rstSupervisor.Split('_');
                               if (rstSupervisor != string.Empty)
                               {
                                   string supvisorEmail = sepSupervisor[1];
                                   string supvisorName = sepSupervisor[2];
                                   Session["supervisorMail"] = supvisorEmail;
                                   Session["supervisorName"] = supvisorName;
                               }



                               sessionDimension(appraisalPeriod, empNoSess);

                               //////Decide the what's enabled/////////////
                               TxtRating.Enabled = false;
                               TxtKeyStr.Enabled = false;
                               TxtKeyAch.Enabled = false;
                               TxtImpArea.Enabled = false;
                               TxtProposedDev.Enabled = false;
                               TxtConcurrentCmt.Enabled = false;
                               rdoAccept.Enabled = false;
                               rdoReject.Enabled = false;
                               TxtReasons.Enabled = false;
                               DDLHolderYear.Enabled = false;
                               DDLHolderMonth.Enabled = false;
                               DDLHolderDay.Enabled = false;

                               DDLAppraiserYear.Enabled = false;
                               DDLAppraiserMonth.Enabled = false;
                               DDLAppraiserDay.Enabled = false;

                               DDLConcurrentYear.Enabled = true;
                               DDLConcurrentMonth.Enabled = true;
                               DDLConcurrentDay.Enabled = true;
                               btnRateSubordinate.Text = "Sign Concurrent Signature";

                               //////End Decide the what's enabled/////////////

                               PnlSub.Visible = false;
                               PnlMain.Visible = true;
                           }//end rst
                           else
                           {
                               PnlMain.Visible = false;
                               PnlSub.Visible = true;
                               lblStatusSub.Text = "Please check if the user information or the Performance Result/Behavioural competencies for the employee for this period is configured already or not. User information must be completed before summary could be generated";// +rst.ToString();
                               lblStatusSub.ForeColor = System.Drawing.Color.Red;


                           }

                       }//rstCSign
                       else 
                       {
                           PnlMain.Visible = false;
                           PnlSub.Visible = true;
                           lblStatusSub.Text = "There exists no data to concurrently sign, both Jobholder and supervisor must sign first before you can sign";
                           lblStatusSub.ForeColor = System.Drawing.Color.Red;
                       }





                   }
                   catch (Exception ex)
                   {
                       lblStatusSub.Text = "Object Error: " + ex.Message;
                       lblStatusSub.ForeColor = System.Drawing.Color.Red;
                       PnlMain.Visible = false;
                       //return;
                   }//end try catch

               }// end countSubordinate
               else
               {
                   PnlMain.Visible = false;
                   PnlSub.Visible = true;
                   lblStatusSub.Text = "Sorry you do not have subordinate(s)!";
                   lblStatusSub.ForeColor = System.Drawing.Color.Red;


               }//end else countSubordinate

           }
           catch (Exception ex)
           {
               PnlMain.Visible = false;
               PnlSub.Visible = true;
               lblStatusSub.Text = "Object Error: " + ex.Message;
               lblStatusSub.ForeColor = System.Drawing.Color.Red;
               return;
           }//end catch
           


       
       }//end if ddlconcurrent is true


    }//method

   
        

    private void sessionDimension(string appraisalPeriod, string sessionDep)
    {
        /////////////////////////////////////////////////
        
        //DataTable tablePhaseTwo = crudsbLL.getPhaseTwoAPPFormList(appraisalPeriod, sessionDep);
        string bring70 = crudsbLL.getAppraisal70List(appraisalPeriod, sessionDep);
        string bring30 = crudsbLL.getAppraisal30List(appraisalPeriod, sessionDep);
        lblPR.Text = bring70 + "%";
        lblBC.Text = bring30 + "%";
        decimal plus=Convert.ToDecimal(bring30) + Convert.ToDecimal(bring70);
        lblTotalPerformanceScore.Text = plus.ToString() + "%";


        string rstASD = crudsbLL.getAppraisalSummaryData(sessionDep.Trim().ToLower(), appraisalPeriod);


        if (rstASD != string.Empty)
        {
            string[] sepsess = rstASD.Split('_');
            ////  content = reader["ID"].ToString() + "_" + reader["OVERALL_RATING"].ToString() + "_" + reader["KEY_ACHIVEMENT"].ToString() + "_" + reader["KEY_STRENGTH"].ToString() +
            //"_" + reader["IMPROVEMENT_AREA"].ToString() + "_" + reader["PROPOSED_DEV"].ToString() + "_" + reader["CONCURRENT_SUP_CMMTS"].ToString() +
            //"_" + reader["AGREEMENT"].ToString() + "_" + reader["EMPLOYEE_NO"].ToString() + "_" + reader["APPRAISAL_PERIOD"].ToString();
            
            string appId = sepsess[0];
            string appORating = sepsess[1];
            string appKAch = sepsess[2];
            string appKStr=sepsess[3];
            string appImpArea = sepsess[4];
            string appPropDev = sepsess[5];
            string appConSupCmmts = sepsess[6];
            string appAgreement = sepsess[7];
            string appEmp = sepsess[8];
            string appAppPeriod = sepsess[9];

            TxtRating.Text = appORating;
            TxtKeyAch.Text = appKAch;
            TxtKeyStr.Text = appKStr;
            TxtImpArea.Text = appImpArea;
            TxtProposedDev.Text = appImpArea;
            TxtConcurrentCmt.Text = appConSupCmmts;
            if (appAgreement == "Accept")
            {
                rdoAccept.Checked = true;
                rdoReject.Checked = false;
            }
            else if (appAgreement == "Reject")
            {
                rdoReject.Checked = true;
                rdoAccept.Checked = false;
            }



            ////////Decide the what's enabled/////////////
            //TxtRating.Enabled = false;
            //TxtKeyStr.Enabled = false;
            //TxtKeyAch.Enabled = false;
            //TxtImpArea.Enabled = false;
            //TxtProposedDev.Enabled = false;
            //TxtConcurrentCmt.Enabled = false;
            //rdoAccept.Enabled = false;
            //rdoReject.Enabled = false;
            //TxtReasons.Enabled = false;
            //DDLHolderYear.Enabled = false;
            //DDLHolderMonth.Enabled = false;
            //DDLHolderDay.Enabled = false;

            //DDLAppraiserYear.Enabled = false;
            //DDLAppraiserMonth.Enabled = false;
            //DDLAppraiserDay.Enabled = false;

            //DDLConcurrentYear.Enabled = true;
            //DDLConcurrentMonth.Enabled = true;
            //DDLConcurrentDay.Enabled = true;
            //btnRateSubordinate.Text = "Sign Concurrent Signature";

            ////////End Decide the what's enabled/////////////

            //PnlSub.Visible = false;
            //PnlMain.Visible = true;
        }
        //else
        //{
        //    PnlMain.Visible = false;
        //    PnlSub.Visible = true;
        //    lblStatusSub.Text = "Please check if the user information or the Performance Result/Behavioural competencies for the employee for this period is configured already or not. User information must be completed before summary could be generated";// +rst.ToString();
        //    lblStatusSub.ForeColor = System.Drawing.Color.Red;


        //}

 }//sessionDimension

   protected void btnRateSubordinate_Click(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();
        string appraisalPeriod;
        string employeeNo;

        string supUsername = "";
        string supEmail = "";
        string supName = "";

        employeeNo = Session["empNo"].ToString();
        appraisalPeriod = Session["apprPeriod"].ToString();

        string subName = LblName.Text;
        string mailToSub = Session["mail"].ToString();

        if (Session["visble"] == "Yes")
        {
            
            string appraiserSign=Session["appraiserSig"].ToString();
            string appraiserYear = DDLAppraiserYear.SelectedValue;
            string appraiserMonth = DDLAppraiserMonth.SelectedValue;
            string appraiserDay = DDLAppraiserDay.SelectedValue;
            string appraiserDate = appraiserDay + "/" + appraiserMonth + "/" + appraiserYear;
            
            
            
            
            string countSubordinate = crudsbLL.getPositionsCount(username);

            if (countSubordinate.Equals("1"))
            {
                string rst = crudsbLL.getSupervisorInformation(Session["usrname"].ToString().Trim().ToLower());
                if (rst != string.Empty)
                {
                    string[] sepsess = rst.Split('_');
                    // content = reader["username"].ToString() + "_" + reader["email"].ToString() + "_" + reader["name"].ToString();
                    supUsername = sepsess[0];
                    supEmail = sepsess[1];
                    supName = sepsess[2];

                }
                else
                {

                    lblStatus.Text = "You do not have a Supervisor";// +rst.ToString();
                    lblStatus.ForeColor = System.Drawing.Color.Red;


                }

                if (string.IsNullOrEmpty(TxtKeyStr.Text) || string.IsNullOrEmpty(TxtImpArea.Text) ||  string.IsNullOrEmpty(TxtProposedDev.Text))
                {
                    lblStatus.Text = "Please rate your subordinate, you need to complete all the necessary information before submission!";
                    lblStatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    string usr = crudsbLL.addOrUpdateAppraiserSummary(employeeNo, appraisalPeriod, TxtRating.Text, TxtKeyStr.Text, TxtImpArea.Text,
                    TxtProposedDev.Text, appraiserSign, appraiserDate);

                    //string usr = crudsbLL.addOrUpdateBCGoalSettings(employeeNo, holderSign, holderDate, appraisalPeriod);


                    string aSSendMail = BLLMail2Send.sendMail2Subordinate4Summary(mailToSub, supName, subName);

                    if (usr == "10" && aSSendMail == "Sent")
                    {

                        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " completed the appraisal summary for "+ subName+" employee before, the Subordinate Information has been successfully updated <i><strong>and notification sent!</strong></i>", "Update");
                        lblStatus.Text = "You have completed the appraisal summary for this employee before, the Subordinate Information has been successfully updated <i><strong>and notification sent!</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;

                    }
                    else if (usr == "10" && aSSendMail != "Sent")
                    {
                        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " completed the appraisal summary for " + subName + " employee before, the Subordinate Information has been successfully updated <i><strong>but notification cannot be sent at the moment!</strong></i>", "Update");
                        lblStatus.Text = "You have completed the appraisal summary for this employee before, the Subordinate Information has been successfully updated,<i><strong> but notification cannot be sent at the moment, please connect to the company's network.</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (usr == "20" && aSSendMail == "Sent")
                    {
                        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " successfully completed the appraisal summary for " + subName + " employee <i><strong>and Notification sent!</strong></i>", "Create");
                        lblStatus.Text = "You have successfully completed the appraisal summary for this employee <i><strong>and Notification sent!</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else if (usr == "20" && aSSendMail != "Sent")
                    {
                        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " successfully completed the appraisal summary for " + subName + " employee <i><strong>but Notification cannot be sent at the moment!</strong></i>", "Create");
                        lblStatus.Text = "You have successfully completed the appraisal summary for this employee <i><strong>but Notification cannot be sent at the moment! Contact Administrator!</strong></i>";
                        lblStatus.ForeColor = System.Drawing.Color.Blue;
                    }
                    else
                    {
                        lblStatus.Text = "<b><i>Whoa!</i></b> " + usr.ToString();// +rst.ToString();
                        lblStatus.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                }

            }//end if countsubordinate equals 1
        }
        else if (Session["visble"].Equals("No"))
        {
            
            string jHolderSign=Session["employeeName"].ToString();
            string jHolderYear = DDLHolderYear.SelectedValue;
            string jHolderMonth = DDLHolderMonth.SelectedValue;
            string jHolderDay = DDLHolderDay.SelectedValue;
            string jHolderDate = DDLHolderDay + "/" + DDLHolderMonth + "/" + DDLHolderYear;
            
            string accRej = "None";
            if (rdoAccept.Checked==true)
            {
                accRej = "Accept";
            
            }
            else if (rdoReject.Checked == true)
            {
                accRej = "Reject";
            
            }


            if(rdoReject.Checked==true && string.IsNullOrEmpty(TxtReasons.Text))
            {
                lblStatus.Text = "Please provide reasons for your rejection of the rating. Thank you!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            
            }


            string usr = crudsbLL.addOrUpdateHolderApprSummary(employeeNo, appraisalPeriod, TxtKeyAch.Text, accRej,
                TxtReasons.Text, jHolderSign, jHolderDate);


            string jhasSendMail = BLLMail2Send.sendMail2Sup4AppSummary(mailToSub, supName, subName);

            if (usr == "10" && jhasSendMail == "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " completed appraisal summary rating before, your Information has been successfully updated!<i><strong>and notification sent!</strong></i>", "Update");
                lblStatus.Text = "You have completed your appraisal summary rating before, your Information has been successfully updated!<i><strong>and notification sent!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;

            }
            else if (usr == "10" && jhasSendMail != "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " completed appraisal summary rating before, your Information has been successfully updated!<i><strong>but notification cannot be sent at the moment!</strong></i>", "Update");
                lblStatus.Text = "You have completed your appraisal summary rating before, your Information has been successfully updated,<i><strong> but notification cannot be sent at the moment, please connect to the company's network.</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (usr == "20" && jhasSendMail == "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + ", Your appraisal summary ratings have been successfully saved! <i><strong>and Notification sent!</strong></i>", "Create");
                lblStatus.Text = "Your appraisal summary ratings have been successfully saved! <i><strong>and Notification sent!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (usr == "20" && jhasSendMail != "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + " Your appraisal summary ratings have been successfully saved! <i><strong>but Notification cannot be sent at the moment!</strong></i>", "Create");
                lblStatus.Text = "Your appraisal summary ratings have been successfully saved! <i><strong>but Notification cannot be sent at the moment! Contact Administrator!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "<b><i>Whoa!</i></b> " + usr.ToString();// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }




        }//else if visible
        else if (Session["visble"].Equals("YesNo"))
        {
            //Session["visble"] = "YesNo";



            string jHolderEmail = Session["mail"].ToString();
            string concSign=Session["concurrentSig"].ToString();
            string concYear = DDLConcurrentYear.SelectedValue;
            string concMonth = DDLConcurrentMonth.SelectedValue;
            string concDay = DDLConcurrentDay.SelectedValue;
            string concDate = concDay + "/" + concMonth + "/" + concYear;



            if (string.IsNullOrEmpty(TxtConcurrentCmt.Text))
            {
                lblStatus.Text = "Please your comment is needed. Thank you!";
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            
            }


            string usr = crudsbLL.addOrUpdateConcurrentApprSummary(employeeNo, appraisalPeriod, TxtConcurrentCmt.Text, concSign, concDate);

            string supervisorMail = Session["supervisorMail"].ToString();
            string supervisorName = Session["supervisorName"].ToString();
            string mailTo = mailToSub + "," + supervisorMail;
            string ccSendMail = BLLMail2Send.sendMail2Sub4ccAppSummary(mailTo, subName, supervisorName, concSign);

            //Session["supervisorMail"] = supvisorEmail;
            //Session["supervisorName"] = supvisorName;

            if (usr == "10" && ccSendMail == "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;

                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + ", you have concurrently signed for " + subName + " before, the Information has been successfully updated!<i><strong>and notification sent!</strong></i>", "Update");
                lblStatus.Text = "You have concurrently signed for "+subName +" before, the Information has been successfully updated!<i><strong>and notification sent!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;

            }
            else if (usr == "10" && ccSendMail != "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + ", you have concurrently signed for " + subName + " before, the Information has been successfully updated!<i><strong>but notification cannot be sent at the moment!</strong></i>", "Update");
                lblStatus.Text = "You have concurrently signed for " + subName + " before, the Information has been successfully updated,<i><strong> but notification cannot be sent at the moment, please connect to the company's network.</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (usr == "20" && ccSendMail == "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + ", your concurrent signature information has been successfully saved for " + subName + "! <i><strong>and Notification sent!</strong></i>", "Create");
                lblStatus.Text = "Your concurrent signature information has been successfully saved for "+subName+ "! <i><strong>and Notification sent!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else if (usr == "20" && ccSendMail != "Sent")
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "Appraisal Summary: User " + username + ", Your concurrent signature information has been successfully saved for " + subName + "! <i><strong>but Notification cannot be sent at the moment!</strong></i>", "Create");
                lblStatus.Text = "Your concurrent signature information has been successfully saved for " + subName + "! <i><strong>but Notification cannot be sent at the moment! Contact Administrator!</strong></i>";
                lblStatus.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                PnlMain.Visible = true;
                PnlSub.Visible = false;
                lblStatus.Text = "<b><i>Whoa!</i></b> " + usr.ToString();// +rst.ToString();
                lblStatus.ForeColor = System.Drawing.Color.Red;
                return;
            }


        
        }
        
       




            //////////////////////////////////////Clear box////////////////////////////////////////
            CleartextBoxes(this);
            ////////////////////////////////End Clear box///////////////////////////////////////////

           
           
            
           

           
            



    }//btnRateSubordinate_Click



   
}