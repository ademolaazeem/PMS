using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Security.Principal.IPrincipal;
//using System.Web
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Profile;
//System.Web.Profile
using System.Web.Security;
//
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System.Data;
//
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
//
//
using System.Net.Mail;
using System.Net;
using System.Net.Mime;
using System.Text.RegularExpressions;
//
using System.Web.Security;
using System.Security.Cryptography;
using System.IO;
//
using System.Globalization;

using System.ComponentModel;// for backgroundworker class
//
using System.Threading;
//
using iTextSharp.text.pdf;
//
using DAL;

namespace BLL
{


    /// <summary>
    /// Summary description for Business Logic Layer
    /// </summary>
    public class crudsbLL
    {

        public static string addUserPermission(string usernameMsg, string positionMsg, string deptMsg, string userMsg, string appraisalMsg, string goalMsg, string behMsg, string loggedinUser, string vGoalMsg, string vAppMsg)
        {
            return cruds.addUserPermission(usernameMsg, positionMsg, deptMsg, userMsg, appraisalMsg, goalMsg, behMsg, loggedinUser, vGoalMsg, vAppMsg);
        }
        public static DataTable getPositions()
        {
            return cruds.getPositions();
        }


        public static DataTable getMenus()
        {
            return cruds.getMenus();
        }


        
        
        public static DataTable getRoles()
        {
            return cruds.getRoles();
        }

        public static DataTable getConcurrent()
        {
            return cruds.getConcurrent();
        }

        public static DataTable getUsernameDropDown()
        {
            return cruds.getUsernameDropDown();
        }

        
        public static DataTable getPositions(string username)
        {
            return cruds.getPositions(username);
        }


        public static string getPositionsCount(string username)
        {
            return cruds.getPositionsCount(username);
        }

        public static string getConcurrentCount(string username)
        {
            return cruds.getConcurrentCount(username);
        }

        public static DataTable getDepartments()
        {
            return cruds.getDepartments();
        }


        public static DataTable getKPINameDropDown()
        {
            return cruds.getKPINameDropDown();
        }//getKPINameDropDown

        public static DataTable getKPINameDropDown(string selectedPosition)
        {
            return cruds.getKPINameDropDown(selectedPosition);
        }//getKPINameDropDown
        public static DataTable getEmployeeDropDown()
        {
            return cruds.getEmployeeDropDown();
        }//getEmployeeDropDown
        public static DataTable getSubordinateNameDropDown(string username)
        {
            return cruds.getSubordinateNameDropDown(username);
        }//getSubordinateNameDropDown

        public static string addSentEmails(string emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody, string emailStatus)
        {
            return cruds.addSentEmails(emailFrom, emailTo, emailBcc, emailCc, emailSubject, emailBody, emailStatus);
        }//addSentEmails
        public static DataTable getDeptForPositions(string positionValue)
        {
            return cruds.getDeptForPositions(positionValue);
        }

        public static DataTable getSubordinateInfoDropDown(string subValue)
        {
            return cruds.getSubordinateInfoDropDown(subValue);
        }//getSubordinateInfoDropDown(string subValue)

        public static string checkUsername(string username)
        {
            return cruds.checkUsername(username);
        }
        public static DataTable getUserlist()
        {
            return cruds.getUserlist();
        }
        public static String addUser(string username, string login_ip, string status)
        {
            return cruds.addUser(username, login_ip, status);
        }//end Add user
        public static int saveAuditLog(string username, string login_ip, string status, string operation)
        {
            return cruds.saveAuditLog(username, login_ip, status, operation);
        }//end Add user
        public static string addOrUpdateJD(string jdMsg, string usernameMsg, string positionMsg, string reportMsg, string supervisesMsg, 
            string jobSummaryMsg, string principalDutiesMsg, string competencySkillsReqmt, string concurrentMsg)
        {
            return cruds.addOrUpdateJD(jdMsg, usernameMsg, positionMsg, reportMsg, supervisesMsg,
            jobSummaryMsg, principalDutiesMsg, competencySkillsReqmt, concurrentMsg);
        }//end jd
        public static DataTable getJDList()
        {
            return cruds.getJDList();
        }//end getJDList


        public static DataTable getMenuRole()
        {
            return cruds.getMenuRole();
        }//end getMenuRole

        public static DataTable getUserRole()
        {
            return cruds.getUserRole();
        }//end getMenuRole



        public static DataTable getAuditTrail()
        {
            return cruds.getAuditTrail();
        }//end getAuditTrail
        
        public static DataTable getAuditTrail(string username)
        {
            return cruds.getAuditTrail(username);
        }//end getAuditTrail
        
        public static DataTable getAuditTrail(string username, string operation, string andOr)
        {
            return cruds.getAuditTrail(username, operation, andOr);
        }//end 
        public static DataTable getAuditTrail(string username, string operation, string fromDate, string andOr0, string andOr1)
        {
            return cruds.getAuditTrail(username, operation, fromDate, andOr0, andOr1);
        }//end
        public static DataTable getAuditTrail(string username, string operation, string fromDate, string toDate, string andOr0, string andOr1)
        {
            return cruds.getAuditTrail(username, operation, fromDate, toDate, andOr0, andOr1);
        }//end

        public static DataTable getAuditTrail(string fromDate, string toDate)
        {
            return cruds.getAuditTrail(fromDate, toDate);
        }//end

        public static DataTable getAuditTrailOps(string operation)
        {
            return cruds.getAuditTrailOps(operation);
        }//end getAuditTrail
        public static DataTable getAuditTrailFromDate(string dDate)
        {
            return cruds.getAuditTrailFromDate(dDate);
        }//end






        public static string checkPerformanceResult(string usernameMsg, string appraisalPeriod)
        {
            return cruds.checkPerformanceResult(usernameMsg, appraisalPeriod);

        }//end checkPerformanceResult

        public static string checkBehaviouralCompetencies(string usernameMsg, string appraisalPeriod)
        {
            return cruds.checkBehaviouralCompetencies(usernameMsg, appraisalPeriod);
        }//end checkBehaviouralCompetencies



        public static string addOrUpdatePositions(string usernameMsg, string positionMsg, string positionIdMsg, string departmentMsg)
        {
            return cruds.addOrUpdatePositions(usernameMsg, positionMsg, positionIdMsg, departmentMsg);
        }//end addOrUpdatePositions
        public static DataTable getPositionList()
        {
            return cruds.getPositionList();
        }//end getPositionList


        public static string addOrUpdateDepartments(string usernameMsg, string departmentMsg, string groupNameMsg, string departmentIdMsg)
        {
            return cruds.addOrUpdateDepartments(usernameMsg,  departmentMsg, groupNameMsg, departmentIdMsg);
        }//end addOrUpdatePositions
        

        public static string addOrUpdateKPITemplate(string usernameMsg, string kpiTemplateIdMsg, string departmentMsg, string positionMsg, 
            string serialNoMsg, string kpiDimensionMsg, string kpiMsg, string kpiGroupMsg, string kpiDefMsg, string formulaMsg,
            string sigLevelMsg, string infLevelMsg, string impFactMsg, string weightMsg, string sourceMsg, string respMsg, string existMsg)
        {

            return cruds.addOrUpdateKPITemplate(usernameMsg, kpiTemplateIdMsg, departmentMsg, positionMsg, serialNoMsg,
                    kpiDimensionMsg, kpiMsg, kpiGroupMsg, kpiDefMsg, formulaMsg, sigLevelMsg, infLevelMsg,
                    impFactMsg, weightMsg, sourceMsg, respMsg, existMsg);
        }

        //splitItems[0], splitItems[1], splitItems[2], splitItems[3], kpiDimensionComments, period
        //kpiDimension=splitItems[0], totalKPINumber.Text=splitItems[1],totalObtainableScore.Text=splitItems[2],empNo.Text=splitItems[3]
        public static string addOrUpdateKPIView(string kpiDimension, string totalKPINumber, string totalObtainableScore, string empNo, string kpiDimensionComments, string appraisalPeriod)
        {
            return cruds.addOrUpdateKPIView(kpiDimension, totalKPINumber, totalObtainableScore, empNo, kpiDimensionComments, appraisalPeriod);
        }//end addOrUpdateKPIView

        //kpiDimension=splitItems[0], totalKPINumber.Text=splitItems[1],totalObtainableScore.Text=splitItems[2],empNo.Text=splitItems[3]
        public static string addOrUpdateAPKPIView(string kpiDimension, string empNo, string kpiDimensionAPComments, string appraisalPeriod)
        {
            return cruds.addOrUpdateAPKPIView(kpiDimension, empNo, kpiDimensionAPComments, appraisalPeriod);
        }//end addOrUpdateKPIView

        public static string addOrUpdateApplicationFormKpiDimDetails(string employeeNo, string kpiId, string weight, string target, string actual, string appraisalPeriod)
            //addOrUpdateApplicationFormKpiDimDetails(string employeeNo, string kpiId, string actual, string score, string appraisalPeriod)
            
        {
            return cruds.addOrUpdateApplicationFormKpiDimDetails(employeeNo, kpiId, weight, target, actual, appraisalPeriod);
              //  return cruds.addOrUpdateApplicationFormKpiDimDetails(employeeNo, kpiId, actual, score, appraisalPeriod);
               
        }//end addOrUpdateApplicationFormKpiDimDetails



        //kpiIdFinancial + "," + kpiTypeFinancial + "," + weightFinancial + "," + targetFinancial + "," + kpiDimensionFinancial
        public static string addOrUpdateKpiDimDetails(string employeeNo, string positionId, string kpiId, string kpiType, string weight, string target, string kpiDimension, string appraisalPeriod)
        {
            return cruds.addOrUpdateKpiDimDetails(employeeNo, positionId, kpiId, kpiType, weight, target, kpiDimension, appraisalPeriod);
        }//end addOrUpdateKpiDimDetails

        public static string addOrUpdateBCKpiDimDetails(string kpiDimId, string actionPlan, string employeeNo, string appraisalPeriod)
        {
            return cruds.addOrUpdateBCKpiDimDetails(kpiDimId, actionPlan, employeeNo, appraisalPeriod);
        }//end addOrUpdateKpiDimDetails
        public static string approveBCompetencies(string employeeNo, string appPeriod, string appraiserSign, string appraiserDate, string status)
        {
            return cruds.approveBCompetencies(employeeNo, appPeriod, appraiserSign, appraiserDate, status);
        }//approveBCompetencies

        public static string UpdateBCAppraiserComments(string employeeNo, string appPeriod, string appraiserComments, string status)
        {
            return cruds.UpdateBCAppraiserComments(employeeNo, appPeriod, appraiserComments, status);
        }//UpdateBCAppraiserComments
        public static string addOrUpdateBCGoalSettings(string employeeNo, string holderSign, string holderDate, string appraisalPeriod)
        {
            return cruds.addOrUpdateBCGoalSettings(employeeNo, holderSign, holderDate, appraisalPeriod);
        }//end addOrUpdateBCGoalSettings


        public static string addOrUpdateBCAppraisalForm(string employeeNo, string appraisalPeriod, string profSupText, string profSupLbl,
        string commSupText, string commSupLbl, string innoSupText, string innoSupLbl, string leadSupText, string leadSupLbl, string ccSupText, 
            string ccSupLbl, string peSupText, string peSupLbl, string teamSupText, string teamSupLbl)
        {
            return cruds.addOrUpdateBCAppraisalForm(employeeNo, appraisalPeriod, profSupText, profSupLbl, commSupText, commSupLbl, innoSupText, 
                innoSupLbl, leadSupText, leadSupLbl, ccSupText, ccSupLbl, peSupText, peSupLbl, teamSupText, teamSupLbl);
                
        }//end addOrUpdateBCAppraisalForm


        public static string addOrUpdateAppraiserSummary(string employeeNo, string appraisalPeriod, string rating, string keyStr, string impArea,
        string proposedDev, string appraiserSign, string appraiserDate)
            
        {
            return cruds.addOrUpdateAppraiserSummary(employeeNo, appraisalPeriod, rating, keyStr, impArea, proposedDev, appraiserSign, appraiserDate);

        }//end addOrUpdateAppraiserSummary

        
        public static string addOrUpdateHolderApprSummary(string employeeNo, string appraisalPeriod, string KeyAch, string accRej, string reasons,
            string jHolderSign, string jHolderDate)
        {
            return cruds.addOrUpdateHolderApprSummary(employeeNo, appraisalPeriod, KeyAch, accRej, reasons, jHolderSign, jHolderDate);

        }//end addOrUpdateHolderApprSummary


        public static string addOrUpdateConcurrentApprSummary(string employeeNo, string appraisalPeriod, string concurrentComment, string concSign, string concDate)
        {
            return cruds.addOrUpdateConcurrentApprSummary(employeeNo, appraisalPeriod, concurrentComment, concSign, concDate);

        }//end addOrUpdateConcurrentApprSummary



        public static string addOrUpdateBCHolderAppraisalForm(string employeeNo, string appraisalPeriod, string profJHText, string profJHLbl,
        string commJHText, string commJHLbl, string innoJHText, string innoJHLbl, string leadJHText, string leadJHLbl, string ccJHText,
            string ccJHLbl, string peJHText, string peJHLbl, string teamJHText, string teamJHLbl)
        {
            return cruds.addOrUpdateBCHolderAppraisalForm(employeeNo, appraisalPeriod, profJHText, profJHLbl, commJHText, commJHLbl, innoJHText,
                innoJHLbl, leadJHText, leadJHLbl, ccJHText, ccJHLbl, peJHText, peJHLbl, teamJHText, teamJHLbl);

        }//end addOrUpdateBCHolderAppraisalForm
        public static List<EmployeeRequest> getEmployeeLists()
        {
            return cruds.getEmployeeLists();
        }//end getEmployeeLists



        public static List<SupervisesRequest> getSupervisesLists(string position_id)
        {
            return cruds.getSupervisesLists(position_id);
        }//getSupervisesLists(position_id)

        public static string addOrUpdateEmpRcdFromHM(string employeeNoMsg, string nameMsg, string gradeLevelMsg,
            string emailMsg, string empUsernameMsg, string usernameMsg, string employmentDateMsg)
         {
             return cruds.addOrUpdateEmpRcdFromHM(employeeNoMsg, nameMsg, gradeLevelMsg,
            emailMsg, empUsernameMsg, usernameMsg, employmentDateMsg);
        }//end addOrUpdatePositions

        public static string getDepartmentFromPosition(string position)
        {
            return cruds.getDepartmentFromPosition(position);
        }
        public static string updateEmployees(string usernameMsg, string empNoMsg, string positionIdMsg, string deptMsg)
        {
            return cruds.updateEmployees(usernameMsg, empNoMsg, positionIdMsg, deptMsg);
        }//end addOrUpdatePositions

        public static DataTable getEmployees()
        {
            return cruds.getEmployees();
        }//end getEmployees
        public static DataTable getPositionList(string positionMsg)
        {
            return cruds.getPositionList(positionMsg);
        }//end getPositionList with argument
        public static string getPositionPopulate(string positionMsg)
        {
            return cruds.getPositionPopulate(positionMsg);
        }//end getPositionPopulate with argument
        /////////////////////////////////////////////////////////////////////////
        public static DataTable getDepartmentsList(string departmentMsg)
        {
            return cruds.getDepartmentsList(departmentMsg);
        }//end getDepartmentsList
        public static string getDepartmentPopulate(string departmentMsg)
        {
            return cruds.getDepartmentPopulate(departmentMsg);
        }//end getDepartmentPopulate

        public static string getKPIPopulate(string kpiMsg)
        {
            return cruds.getKPIPopulate(kpiMsg);
        }//end getDepartmentPopulate


        public static DataTable getEmployeeTableList(string employeeMsg)
        {
            return cruds.getEmployeeTableList(employeeMsg);
        }//getEmployeeTableList

        public static DataTable getDepartmentsList()
        {
            return cruds.getDepartmentsList();
        }//end getDepartmentsList

        ////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public static DataTable getKPIPoolTemplateTable()
        {
            return cruds.getKPIPoolTemplateTable();
        }//getKPIPoolTemplateTable

        public static DataTable getKPIPoolTemplateTable(string position, string kpiName)
        {
            return cruds.getKPIPoolTemplateTable(position, kpiName);
        }//getKPIPoolTemplateTable


        public static DataTable getKPIInfoTable()
        {
            return cruds.getKPIInfoTable();
        }//end getKPIInfoTable
        public static DataTable getKPIInfoTable(string searchMsg)
        {
            return cruds.getKPIInfoTable(searchMsg);

        }//end getKPIInfoTable

        public static string addOrUpdateGroupDeptKPI(string usernameMsg, string kpiNameMsg, string groupDeptIdMsg, string departmentMsg,
            string kpiTypeMsg, string kpiKindMsg)
        {
            return cruds.addOrUpdateGroupDeptKPI(usernameMsg, kpiNameMsg, groupDeptIdMsg, departmentMsg, kpiTypeMsg, kpiKindMsg);
        }//end addOrUpdateGroupDeptKPI
       
       
        public static string checkMatchingPositionDepartment(string positionMsg, string deptMsg)
        {
            return cruds.checkMatchingPositionDepartment(positionMsg, deptMsg);

        }//end getKPIInfoTable


        /////////////////////////////////////////////////////////////////////////
        public static DataSet getDSDepartmentsList(string departmentMsg)
        {
            return cruds.getDSDepartmentsList(departmentMsg);
        }//end getDSDepartmentsList

        public static DataSet getDSDepartmentsList()
        {
            return cruds.getDSDepartmentsList();
        }//end getDepartmentsList
        ////////////////////////////////////////////////////////////////////////
        public static string getDepartmentContent(string deptValue)
        {
            return cruds.getDepartmentContent(deptValue);
        }


        public static string getUserContent(string userValue)
        {
            return cruds.getUserContent(userValue);
        }



        public static string getSupervisesContent(string positionMsg)
        {
            return cruds.getSupervisesContent(positionMsg);
        }//getSupervisesContent

        public static string getEmployeeContent(string empValue)
        {
            return cruds.getEmployeeContent(empValue);
        }//getEmployeeContent

        public static string updateSupervisor(string positionIdMsg, string supervisorMsg)
        {
            return cruds.updateSupervisor(positionIdMsg, supervisorMsg);
        }//end addOrUpdatePositions
        
        public static string deleteRolesMenus(string roleIdMsg)
        {
            return cruds.deleteRolesMenus(roleIdMsg);
        }//deleteRolesMenus

        public static string addOrUpdateRoleMenu(string roleIdMsg, string menuIdMsg)
        {
            return cruds.addOrUpdateRoleMenu(roleIdMsg, menuIdMsg);
        }//end

        public static string addOrUpdateUserRole(string userMsg, string username, string roleIdMsg)
        {
            return cruds.addOrUpdateUserRole(userMsg, username, roleIdMsg);
        }//end

        

        public static string deleteSupervises(string positionIdMsg)
        {
            return cruds.deleteSupervises(positionIdMsg);
        }//

        /// <summary>
        /// /////PhaseOne consist of Employee name, gradelevel and department
        /// </summary>
        /// <param name="empSessionValue"></param>
        /// <returns></returns>
        public static string getConcurrentSign(string empSessionValue)
        {
            return cruds.getConcurrentSign(empSessionValue);
        }

        public static string getPhaseOneContent(string empSessionValue)
        {
            return cruds.getPhaseOneContent(empSessionValue);
        }

        public static string getAppraisalSummaryData(string empSessionValue, string appraisalPeriod)
        {
            return cruds.getAppraisalSummaryData(empSessionValue, appraisalPeriod);
        }

        public static string getBCApplicationFormContent(string appraisalPeriod, string employeeNo)
        {
            return cruds.getBCApplicationFormContent(appraisalPeriod, employeeNo);
        }


        public static string getGoalSettingsComments(string kpiDimension, string appraisalPeriod, string username)
        {
            return cruds.getGoalSettingsComments(kpiDimension, appraisalPeriod, username);
        }

        public static string getSupervisorInformation(string username)
        {
            return cruds.getSupervisorInformation(username);
        }
        // PhaseTwo consist of Financial, Customer, Process Efficiency, People and Brand



        public static DataTable getPhaseTwoAPPFormList(string empSessionValue)
        {
            return cruds.getPhaseTwoAPPFormList(empSessionValue);
        }//end getPhaseTwoList

        public static DataTable getPhaseTwoAPPFormList(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getPhaseTwoAPPFormList(appraisalPeriod, empSessionValue);
        }//end getPhaseTwoList

        public static string getAppraisal70List(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getAppraisal70List(appraisalPeriod, empSessionValue);
        }//end
        public static string getAppraisal30List(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getAppraisal30List(appraisalPeriod, empSessionValue);
        }

        public static DataTable getPhaseTwoList(string empSessionValue)
        {
            return cruds.getPhaseTwoList(empSessionValue);
        }//end getPhaseTwoList


        // PhaseTwo consist of only Financial KPI Details
        public static DataTable getFinancialList(string empSessionValue)
        {
            return cruds.getFinancialList(empSessionValue);
        }//end getFinancialList
        public static DataTable getCustomerList(string empSessionValue)
        {
            return cruds.getCustomerList(empSessionValue);
        }//end getCustomerList
        public static DataTable getProcessEfficiencyList(string empSessionValue)
        {
            return cruds.getProcessEfficiencyList(empSessionValue);
        }//end getProcessEfficiencyList
        public static DataTable getPeopleList(string empSessionValue)
        {
            return cruds.getPeopleList(empSessionValue);
        }//end getPeopleList
        public static DataTable getBrandList(string empSessionValue)
        {
            return cruds.getBrandList(empSessionValue);
        }//end getBrandList



        public static DataTable getFinancialList(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getFinancialList(appraisalPeriod, empSessionValue);
        }//end getFinancialList
        public static DataTable getCustomerList(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getCustomerList(appraisalPeriod, empSessionValue);
        }//end getCustomerList
        public static DataTable getProcessEfficiencyList(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getProcessEfficiencyList(appraisalPeriod, empSessionValue);
        }//end getProcessEfficiencyList
        public static DataTable getPeopleList(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getPeopleList(appraisalPeriod, empSessionValue);
        }//end getPeopleList
        public static DataTable getBrandList(string appraisalPeriod, string empSessionValue)
        {
            return cruds.getBrandList(appraisalPeriod, empSessionValue);
        }//end getBrandList






        /// <summary>
        /// ///////////////////////////Behavioural Competencies//////////////////////
        /// </summary>
        /// <param name="empSessionValue"></param>
        /// <returns></returns>
         public static DataTable getBCPhaseTwoList()
        {
            return cruds.getBCPhaseTwoList();
        }//end getBCPhaseTwoList

        
         public static DataTable getProfList()
         {
             return cruds.getProfList();
         }//end getProfList

         public static DataTable getCommList()
         {
             return cruds.getCommList();
         }//end getCommList
         public static DataTable getTeamList()
         {
             return cruds.getTeamList();
         }//end getTeamList
         public static DataTable getCustList()
         {
             return cruds.getCustList();
         }//end getCustList
         public static DataTable getInnoList()
         {
             return cruds.getInnoList();
         }//end getInnoList
         public static DataTable getLeadList()
         {
             return cruds.getLeadList();
         }//end getLeadList
         public static DataTable getPEffectAcctList()
         {
             return cruds.getPEffectAcctList();
         }//end getPEffectAcctList




         public static DataTable getProfViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getProfViewList(username, employeeNo, appraisalPeriod);
         }//end getProfList
         public static DataTable getCommViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getCommViewList(username, employeeNo, appraisalPeriod);
         }//end getCommList
         public static DataTable getTeamViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getTeamViewList(username, employeeNo, appraisalPeriod);
         }//end getTeamList
         public static DataTable getCustViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getCustViewList(username, employeeNo, appraisalPeriod);
         }//end getCustList
         public static DataTable getInnoViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getInnoViewList(username, employeeNo, appraisalPeriod);
         }//end getInnoList
         public static DataTable getLeadViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getLeadViewList(username, employeeNo, appraisalPeriod);
         }//end getLeadList
         public static DataTable getPEffectAcctViewList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getPEffectAcctViewList(username, employeeNo, appraisalPeriod);
         }//end getPEffectAcctList






         public static DataTable getProfList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getProfList(username, employeeNo, appraisalPeriod);
         }//end getProfList
         public static DataTable getCommList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getCommList(username, employeeNo, appraisalPeriod);
         }//end getCommList
         public static DataTable getTeamList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getTeamList(username, employeeNo, appraisalPeriod);
         }//end getTeamList
         public static DataTable getCustList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getCustList(username, employeeNo, appraisalPeriod);
         }//end getCustList
         public static DataTable getInnoList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getInnoList(username, employeeNo, appraisalPeriod);
         }//end getInnoList
         public static DataTable getLeadList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getLeadList(username, employeeNo, appraisalPeriod);
         }//end getLeadList
         public static DataTable getPEffectAcctList(string username, string employeeNo, string appraisalPeriod)
         {
             return cruds.getPEffectAcctList(username, employeeNo, appraisalPeriod);
         }//end getPEffectAcctList


        /////////////////////////Start Send Email///////////////////////////////
         //public static string SendMail(string emailFrom, string emailTo, string emailBcc, 
         //    string emailCc, string emailSubject, string emailBody)
         //{
         //    return cruds.SendMail(emailFrom, emailTo, emailBcc, emailCc, emailSubject, emailBody);         
         //}
        /////////////////////////End Send Email////////////////////////////////
       




    }
}