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
using System.Globalization;
//
//
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Configuration;
//using DAL.Dalcs;
using System.IO;
using System.Data.SqlClient;
using System.Net.Mail;


namespace DAL
{

    /// <summary>
    /// Summary description for Data Access Layer
    /// </summary>
    public class cruds
    {
        public static string checkUsername(string usernameMsg)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = usernameMsg.ToLower();

                OracleDataReader reader = cmd.ExecuteReader();

                string fail = "0";
                //string ctval;
                //end
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                       // ctval  = reader["c_username"].ToString();

                        if (reader["c_username"].ToString() == fail)
                        {
                            return "0";
                        }
                        else
                            return "1";
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }

        public static string checkPerformanceResult(string usernameMsg, string appraisalPeriod)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                // cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                cmd.CommandText = "select count(a.id)c_id from KPI_SETUP a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:p_username and a.APPRAISAL_PERIOD=:p_app_period";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_app_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);

                OracleDataReader reader = cmd.ExecuteReader();

                string fail = "0";
                //string ctval;
                //end

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // ctval  = reader["c_username"].ToString();

                        if (reader["c_id"].ToString() == fail)
                        {
                            return "0";
                        }
                        else
                            return "1";
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//checkPerformanceResult
        public static string checkBehaviouralCompetencies(string usernameMsg, string appraisalPeriod)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                // cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                //cmd.CommandText = "select count(a.id)c_id from KPI_SETUP a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:p_username and a.APPRAISAL_PERIOD=:p_app_period";
                cmd.CommandText = "select count(id) c_id from BC_APPRAISAL_FORM a, EMPLOYEE_SETUP b where A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))=:p_username and a.APPRAISAL_PERIOD=:p_app_period";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_app_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);

                OracleDataReader reader = cmd.ExecuteReader();

                string fail = "0";
                //string ctval;
                //end

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // ctval  = reader["c_username"].ToString();

                        if (reader["c_id"].ToString() == fail)
                        {
                            return "0";
                        }
                        else
                            return "1";
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
               return ex.Message;
            }
            
        }//checkBehaviouralCompetencies
        
        public static string addUserPermission(string usernameMsg, string positionMsg, string deptMsg, string userMsg, string appraisalMsg, string goalMsg, string behMsg, string loggedinUser, string vGoalMsg, string vAppMsg)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.update_user_perms";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 30).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_position", OracleDbType.Varchar2, 30).Value = positionMsg;
                cmd.Parameters.Add("p_dept", OracleDbType.Varchar2, 5).Value = deptMsg;
                cmd.Parameters.Add("p_user_access", OracleDbType.Varchar2, 5).Value = userMsg;
                cmd.Parameters.Add("p_appraisal_access", OracleDbType.Varchar2, 5).Value = appraisalMsg;
                cmd.Parameters.Add("p_goal_access", OracleDbType.Varchar2, 5).Value = goalMsg;
                cmd.Parameters.Add("p_beh_access", OracleDbType.Varchar2, 5).Value = behMsg;
                cmd.Parameters.Add("p_logged_user", OracleDbType.Varchar2, 35).Value = loggedinUser;
                               
                cmd.Parameters.Add("p_v_goal_access", OracleDbType.Varchar2, 5).Value =vGoalMsg;
                cmd.Parameters.Add("p_v_app_access", OracleDbType.Varchar2, 5).Value = vAppMsg;
                



                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }
        public static DataTable getPositions()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select id, position from position_setup order by position";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                // cmd.Parameters.AddWithValue(":BANKFIID", bankFIID);
                //cmd.Parameters.Add(":TERMCLASS", deviceType);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getPositions

        public static DataTable getMenus()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select ID, NAME from MENU_SETUP order by id";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getMenus

        public static DataTable getRoles()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select id, ROLE_NAME from ROLE_SETUP";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getRoles


        public static DataTable getConcurrent()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select id, position from position_setup where lower(position) like '%head%' or lower(position)='financial controller'or lower(position)='chief operating officer' or lower(position)='managing director' or lower(position)='board of directors' order by position";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                // cmd.Parameters.AddWithValue(":BANKFIID", bankFIID);
                //cmd.Parameters.Add(":TERMCLASS", deviceType);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getPositions
        public static DataTable getUsernameDropDown()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select EMPLOYEE_NO, lower(USERNAME)USERNAME from EMPLOYEE_SETUP where username is not null order by USERNAME asc";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getUsernameDropDown
        public static DataTable getPositions(string username)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                //string sql = "select a.id id, a.position position from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where b.id=c.position_id and a.id=b.POSITION_OR_JOBROLE and USERNAME='"+ username +"'  order by position";

                string sql = "select a.id id, a.position position from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where a.id=c.supervises and b.POSITION_OR_JOBROLE=c.position_id and trim(lower(b.USERNAME))= '" + username.ToLower().Trim() + "' order by position";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                // cmd.Parameters.AddWithValue(":BANKFIID", bankFIID);
                //cmd.Parameters.Add(":TERMCLASS", deviceType);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getPositions
        public static string getPositionsCount(string usernameMsg)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                //cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                cmd.CommandText = "select count(a.id) p_count from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where a.id=c.supervises and b.POSITION_OR_JOBROLE=c.position_id and trim(lower(b.USERNAME))=:p_username";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = usernameMsg.ToLower().Trim();

                OracleDataReader reader = cmd.ExecuteReader();

                string fail = "0";
                //string ctval;
                //end

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // ctval  = reader["c_username"].ToString();

                        if (reader["p_count"].ToString() == fail)
                        {
                            return "0";
                        }
                        else if (Convert.ToInt32(reader["p_count"]) >= Convert.ToInt32(fail))
                        {
                            return "1";
                        }
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//end getPositions result

        public static string getConcurrentCount(string usernameMsg)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                //cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                //cmd.CommandText = "select count(a.id) p_count from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where a.id=c.supervises and b.POSITION_OR_JOBROLE=c.position_id and trim(lower(b.USERNAME))=:p_username";
                cmd.CommandText = "select count(a.id) p_count from position_setup a, EMPLOYEE_SETUP b, JOB_DISCRIPTION_SETUP c  where a.id=C.POSITION_ID and b.POSITION_OR_JOBROLE=C.CONCURRENT_SIGN_OFF and trim(lower(b.USERNAME))=:p_username";
                // A.POSITION refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = usernameMsg.ToLower().Trim();

                OracleDataReader reader = cmd.ExecuteReader();

                string fail = "0";
                //string ctval;
                //end

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // ctval  = reader["c_username"].ToString();

                        if (reader["p_count"].ToString() == fail)
                        {
                            return "0";
                        }
                        else if (Convert.ToInt32(reader["p_count"]) >= Convert.ToInt32(fail))
                        {
                            return "1";
                        }
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//end getConcurrentCount

        public static string getAppraisal70List(string appraisalPeriod, string userSession)
        {
            string score70 = "0";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                cmd.CommandText = "select (SUM(A.SCORE)/sum(A.WEIGHT) *70)score from KPI_SETUP a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:p_username and a.APPRAISAL_PERIOD=:p_app_period";
                //cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                //cmd.CommandText = "select count(a.id) p_count from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where a.id=c.supervises and b.POSITION_OR_JOBROLE=c.position_id and trim(lower(b.USERNAME))=:p_username";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = userSession.ToLower().Trim();
                cmd.Parameters.Add("p_app_period", OracleDbType.Varchar2, 50).Value = Convert.ToInt32(appraisalPeriod);

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                       score70 = reader["score"].ToString();
                       
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return score70.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//getAppraisalList

        public static string getAppraisal30List(string appraisalPeriod, string userSession)
        {
            string score30 = "0";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                cmd.CommandText = "select a.TOTAL_SCORE score from BC_APPRAISAL_FORM a, EMPLOYEE_SETUP b where A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))=:p_username and a.APPRAISAL_PERIOD=:p_app_period";
                //cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                //cmd.CommandText = "select count(a.id) p_count from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where a.id=c.supervises and b.POSITION_OR_JOBROLE=c.position_id and trim(lower(b.USERNAME))=:p_username";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = userSession.ToLower().Trim();
                cmd.Parameters.Add("p_app_period", OracleDbType.Varchar2, 50).Value = Convert.ToInt32(appraisalPeriod);

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        score30 = reader["score"].ToString();

                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return score30.ToString();//return val
            }
            catch (Exception ex)
            {
                
                return ex.Message;
            }
            //  return 0;
        }//getAppraisal30List
        public static string getEmpNoAppPeriodCount(string employeeNo, string appraisalPeriod)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                //cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                cmd.CommandText = "select count(id) p_count from BC_DIM_DETAILS where EMPLOYEE_NO=:p_employee_no and APPRAISAL_PERIOD=:p_appraisal_period";
                //cmd.CommandText = "select count(a.id) p_count from position_setup a, EMPLOYEE_SETUP b, SUPERVISEES c  where a.id=c.supervises and b.POSITION_OR_JOBROLE=c.position_id and trim(lower(b.USERNAME))=:p_username";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.Text;
                //
                //
                cmd.Parameters.Add("p_employee_no", OracleDbType.Varchar2, 50).Value = employeeNo.ToLower().Trim();
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                

                OracleDataReader reader = cmd.ExecuteReader();

                string fail = "0";
                //string ctval;
                //end

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // ctval  = reader["c_username"].ToString();

                        if (reader["p_count"].ToString() == fail)
                        {
                            return "0";
                        }
                        else if (Convert.ToInt32(reader["p_count"]) >= Convert.ToInt32(fail))
                        {
                            return "1";
                        }
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//
        public static DataTable getDepartments()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select id, name from DEPARTMENT_SETUP order by name";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                // cmd.Parameters.AddWithValue(":BANKFIID", bankFIID);
                //cmd.Parameters.Add(":TERMCLASS", deviceType);
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getDepartments
        public static DataTable getKPINameDropDown()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select id, KPI_NAME from GROUP_DEPTAL_KPI order by KPI_NAME";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getKPINameDropDown
        public static DataTable getKPINameDropDown(string selectedPosition)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();
                string sql = "select a.KPI ID, c.kpi_name KPI_NAME  from kpi_template a, position_setup b, GROUP_DEPTAL_KPI c where a.kpi=c.id and a.position_id=b.id and a.position_id='" + selectedPosition + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getKPINameDropDown
        public static DataTable getEmployeeDropDown()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select employee_no, name from EMPLOYEE_SETUP order by name";

                //where country='NG' and bankfiid is not null

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }//end using
        }//end getEmployeeDropDown
        public static DataTable getDeptForPositions(string deptValue)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select id, position from POSITION_SETUP where trim(department_id)=:v_departmentMsg  order by position";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_departmentMsg", deptValue.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
               }//end using
        }//getDeptForPositions
        public static DataTable getSubordinateInfoDropDown(string subValue)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select EMPLOYEE_NO, name from EMPLOYEE_SETUP where trim(POSITION_OR_JOBROLE) =:v_subordinateMsg order by name";
               // string sql = "select id, position from POSITION_SETUP where trim(department_id)=:v_departmentMsg  order by position";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_subordinateMsg", subValue.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }//end using
        }//getDeptForPositions
        public static DataTable getSubordinateNameDropDown(string username)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;
                con.Open();

                string sql = "select B.USERNAME USERNAME, B.NAME NAME from SUPERVISEES a, EMPLOYEE_SETUP b, EMPLOYEE_SETUP c  where A.SUPERVISES=B.POSITION_OR_JOBROLE and a.POSITION_ID=c.POSITION_OR_JOBROLE and trim(lower(c.USERNAME))=:v_subordinateMsg order by b.name";
                //string sql = "select EMPLOYEE_NO, name from EMPLOYEE_SETUP where trim(POSITION_OR_JOBROLE) =:v_subordinateMsg order by name";
                // string sql = "select id, position from POSITION_SETUP where trim(department_id)=:v_departmentMsg  order by position";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_subordinateMsg", username.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }//end using
        }//getSubordinateNameDropDown




        public static DataTable getUserlist()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select a.user_id user_id, a.USERNAME username, b.POSITION position, c.name department, a.IP_ADDRESS ip_address, a.LAST_LOGON last_logon  from user_setup a, POSITION_SETUP b, DEPARTMENT_SETUP c where a.POSITION_OR_JOBROLE=b.id and a.DEPARTMENT=c.id";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue(":USERNAME", username);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }

        public static DataTable getJDList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

               // string sql = "select a.id id, b.position position, c.position reports_to, d.position supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, POSITION_SETUP d where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and a.SUPERVISES=d.id";
                //string sql = "select distinct a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.position, ', ') within group (order by g.id) as supervises from position_setup g, SUPERVISEES h where g.ID=h.position_id)supervises,  a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, SUPERVISEES d, position_setup e where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and A.POSITION_ID=d.position_id and e.id=d.SUPERVISES";

                string sql = "select  a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.supervises, ', ') within group (order by g.id) from SUPERVISEES g where g.position_id=a.position_id)supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF, a.REPORTS_TO reports_to_id  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c where a.POSITION_ID=b.id and a.REPORTS_TO=c.id order by B.POSITION";

                //
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue(":USERNAME", username);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }

        public static DataTable getMenuRole()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                // string sql = "select a.id id, b.position position, c.position reports_to, d.position supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, POSITION_SETUP d where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and a.SUPERVISES=d.id";
                //string sql = "select distinct a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.position, ', ') within group (order by g.id) as supervises from position_setup g, SUPERVISEES h where g.ID=h.position_id)supervises,  a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, SUPERVISEES d, position_setup e where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and A.POSITION_ID=d.position_id and e.id=d.SUPERVISES";
                //string sql = "select  a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.supervises, ', ') within group (order by g.id) from SUPERVISEES g where g.position_id=a.position_id)supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF, a.REPORTS_TO reports_to_id  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c where a.POSITION_ID=b.id and a.REPORTS_TO=c.id order by B.POSITION";

                string sql = "select c.id, A.ROLE_NAME, B.NAME, B.MENU_ALIAS from role_setup a, menu_setup b, ASSIGN_MENU_ROLE c where C.ROLE_ID=a.id and C.MENU_ID=B.ID order by A.ROLE_NAME";
                
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }

        public static DataTable getUserRole()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                // string sql = "select a.id id, b.position position, c.position reports_to, d.position supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, POSITION_SETUP d where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and a.SUPERVISES=d.id";
                //string sql = "select distinct a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.position, ', ') within group (order by g.id) as supervises from position_setup g, SUPERVISEES h where g.ID=h.position_id)supervises,  a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, SUPERVISEES d, position_setup e where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and A.POSITION_ID=d.position_id and e.id=d.SUPERVISES";
                //string sql = "select  a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.supervises, ', ') within group (order by g.id) from SUPERVISEES g where g.position_id=a.position_id)supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF, a.REPORTS_TO reports_to_id  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c where a.POSITION_ID=b.id and a.REPORTS_TO=c.id order by B.POSITION";

                string sql = "select B.ID, b.role_name, a.username  from user_setup a, role_setup b where a.ROLE_ID=b.id order by B.ROLE_NAME";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }



        public static DataTable getAuditTrail()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where operation != 'View' order by datetime";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrail(string username)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                // string sql = "select a.id id, b.position position, c.position reports_to, d.position supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, POSITION_SETUP d where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and a.SUPERVISES=d.id";
                //string sql = "select distinct a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.position, ', ') within group (order by g.id) as supervises from position_setup g, SUPERVISEES h where g.ID=h.position_id)supervises,  a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, SUPERVISEES d, position_setup e where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and A.POSITION_ID=d.position_id and e.id=d.SUPERVISES";
                //string sql = "select  a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.supervises, ', ') within group (order by g.id) from SUPERVISEES g where g.position_id=a.position_id)supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF, a.REPORTS_TO reports_to_id  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c where a.POSITION_ID=b.id and a.REPORTS_TO=c.id order by B.POSITION";

                string sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username='" + username + "'  order by datetime";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrailOps(string operation)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                // string sql = "select a.id id, b.position position, c.position reports_to, d.position supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, POSITION_SETUP d where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and a.SUPERVISES=d.id";
                //string sql = "select distinct a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.position, ', ') within group (order by g.id) as supervises from position_setup g, SUPERVISEES h where g.ID=h.position_id)supervises,  a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, SUPERVISEES d, position_setup e where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and A.POSITION_ID=d.position_id and e.id=d.SUPERVISES";
                //string sql = "select  a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.supervises, ', ') within group (order by g.id) from SUPERVISEES g where g.position_id=a.position_id)supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF, a.REPORTS_TO reports_to_id  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c where a.POSITION_ID=b.id and a.REPORTS_TO=c.id order by B.POSITION";

                string sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where operation='" + operation + "'  order by datetime";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrailFromDate(string dDate)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                // string sql = "select a.id id, b.position position, c.position reports_to, d.position supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, POSITION_SETUP d where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and a.SUPERVISES=d.id";
                //string sql = "select distinct a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.position, ', ') within group (order by g.id) as supervises from position_setup g, SUPERVISEES h where g.ID=h.position_id)supervises,  a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c, SUPERVISEES d, position_setup e where a.POSITION_ID=b.id and a.REPORTS_TO=c.id and A.POSITION_ID=d.position_id and e.id=d.SUPERVISES";
                //string sql = "select  a.id id, a.position_id position_id, b.position position, c.position reports_to, (select listagg(g.supervises, ', ') within group (order by g.id) from SUPERVISEES g where g.position_id=a.position_id)supervises, a.JOB_SUMMARY job_summary, a.PPAL_DUTIES_N_RESP PRINCIPAL_DUTIES, a.COMPETENCY_N_SKILL_RQMT COMPETENCY, a.CONCURRENT_SIGN_OFF CONCURRENT_SIGN_OFF, a.REPORTS_TO reports_to_id  from JOB_DISCRIPTION_SETUP a, POSITION_SETUP b, POSITION_SETUP c where a.POSITION_ID=b.id and a.REPORTS_TO=c.id order by B.POSITION";

                string sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where trunc(datetime)=:p_date  order by datetime";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_date", OracleDbType.Date, 100).Value = Convert.ToDateTime(dDate.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrail(string username, string operation, string andOr)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql="";
                if (andOr == "AND")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username and operation=:p_operation  order by datetime";
                }
                else if (andOr == "OR")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username or operation=:p_operation  order by datetime";
                }
                
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value =username.Trim();
                cmd.Parameters.Add("p_operation", OracleDbType.Varchar2, 100).Value = operation.Trim();
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrail(string username, string operation, string fromDate, string andOr0, string andOr1)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                if (andOr0 == "AND" && andOr1 =="AND")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username and operation=:p_operation and trunc(datetime)=:p_date order by datetime";
                }
                else if (andOr0=="AND" && andOr1 == "OR")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username and operation=:p_operation OR trunc(datetime)=:p_date order by datetime";
                }
                else if (andOr0 == "OR" && andOr1 == "AND")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username or operation=:p_operation and trunc(datetime)=:p_date order by datetime";
                }
                else if (andOr0 == "OR" && andOr1 == "OR")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username or operation=:p_operation and trunc(datetime)=:p_date order by datetime";
                }

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = username.Trim();
                cmd.Parameters.Add("p_operation", OracleDbType.Varchar2, 100).Value = operation.Trim();
                cmd.Parameters.Add("p_date", OracleDbType.Date, 100).Value = Convert.ToDateTime(fromDate.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrail(string username, string operation, string fromDate, string toDate, string andOr0, string andOr1)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                if (andOr0 == "AND" && andOr1 == "AND")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username and operation=:p_operation and (trunc(datetime) between p_from_date and p_to_date) order by datetime";
                }
                else if (andOr0 == "AND" && andOr1 == "OR")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username and operation=:p_operation or (trunc(datetime) between p_from_date and p_to_date) order by datetime";
                }
                else if (andOr0 == "OR" && andOr1 == "AND")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username or operation=:p_operation and (trunc(datetime) between p_from_date and p_to_date) order by datetime";
                }
                else if (andOr0 == "OR" && andOr1 == "OR")
                {
                    sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where username=:p_username or operation=:p_operation or (trunc(datetime) between p_from_date and p_to_date) order by datetime";
                }

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = username.Trim();
                cmd.Parameters.Add("p_operation", OracleDbType.Varchar2, 100).Value = operation.Trim();
                cmd.Parameters.Add("p_from_date", OracleDbType.Date, 100).Value = Convert.ToDateTime(fromDate.Trim());
                cmd.Parameters.Add("p_to_date", OracleDbType.Date, 100).Value = Convert.ToDateTime(toDate.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getAuditTrail(string fromDate, string toDate)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select USERNAME, DETAILS, IPADDRESS, DATETIME, OPERATION from APPRAISAL_AUDIT where trunc(datetime) between p_from_date and p_to_date order by datetime"; 
                

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_from_date", OracleDbType.Date, 100).Value = Convert.ToDateTime(fromDate.Trim());
                cmd.Parameters.Add("p_to_date", OracleDbType.Date, 100).Value = Convert.ToDateTime(toDate.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }



        public static String addUser(string username, string login_ip, string status)
        {
            int retVal = -1;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;
                //
                //set stored procedure
                //string Oracle = "insert into taccountbilling_summary(unit,institutioncode,institution,volume,value,transtype, devicetype,settlementservice,affilateflag,countrycode,month,year,description,created_by,created_date)" +
                // " values (:unit,:instcode,:instname,:volume,:value,:trantype,:devtype,:sservice,:affflag,:country,:month,:year)";

                cmd.CommandText = "pkg_appraisal.prc_man_user";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = username.ToLower();
                cmd.Parameters.Add("p_ipaddress", OracleDbType.Varchar2, 100).Value = login_ip;
                cmd.Parameters.Add("p_status", OracleDbType.Varchar2, 100).Value = status;

                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                return "-1";
                //return ex.Message;
            }
            //  return 0;
        }//End addUser

        public static int saveAuditLog(string username, string login_ip, string details, string operation)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;
                //
                //set stored procedure
                //string Oracle = "insert into taccountbilling_summary(unit,institutioncode,institution,volume,value,transtype, devicetype,settlementservice,affilateflag,countrycode,month,year,description,created_by,created_date)" +
                // " values (:unit,:instcode,:instname,:volume,:value,:trantype,:devtype,:sservice,:affflag,:country,:month,:year)";

                cmd.CommandText = "pkg_appraisal.prc_audit_log";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = username.ToLower();
                cmd.Parameters.Add("p_ipaddress", OracleDbType.Varchar2, 100).Value = login_ip;
                cmd.Parameters.Add("p_details", OracleDbType.Varchar2, 100).Value = details;
                cmd.Parameters.Add("p_operation", OracleDbType.Varchar2, 50).Value = operation;

                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal;//return val
            }
            catch (Exception ex)
            {
                return 0;
                //return ex.Message;
            }
            //  return 0;
        }

        public static string addOrUpdateJD(string jdMsg, string usernameMsg, string positionMsg, string reportMsg, string supervisesMsg,
            string jobSummaryMsg, string principalDutiesMsg, string competencySkillsReqmt, string concurrentMsg)
        {
           // int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_jd";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);

                cmd.Parameters.Add("p_jd_id", OracleDbType.Varchar2, 30).Value = jdMsg;
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 30).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 30).Value = positionMsg;
                cmd.Parameters.Add("p_report_to_id", OracleDbType.Varchar2, 20).Value = reportMsg;
                cmd.Parameters.Add("p_supervises_id", OracleDbType.Varchar2, 20).Value = supervisesMsg;
                cmd.Parameters.Add("p_job_summary", OracleDbType.Varchar2, 4000).Value = jobSummaryMsg;
                cmd.Parameters.Add("p_p_duties", OracleDbType.Varchar2, 4000).Value = principalDutiesMsg;
                cmd.Parameters.Add("p_cmp_n_sk_reqmt", OracleDbType.Varchar2, 4000).Value = competencySkillsReqmt;
                cmd.Parameters.Add("p_concurrent", OracleDbType.Varchar2, 20).Value = concurrentMsg;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed
                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val





            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//end addOrUpdateJD



        public static string addSentEmails(string emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody, string emailStatus)
        {
           try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_sent_mails";
                cmd.CommandType = CommandType.StoredProcedure;

                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);
                
                cmd.Parameters.Add("p_from_email", OracleDbType.Varchar2, 100).Value = emailFrom;
                cmd.Parameters.Add("p_to_email", OracleDbType.Varchar2, 100).Value = emailTo.ToLower();
                cmd.Parameters.Add("p_bcc_email", OracleDbType.Varchar2, 100).Value = emailBcc;
                cmd.Parameters.Add("p_cc_email", OracleDbType.Varchar2, 100).Value = emailCc;
                cmd.Parameters.Add("p_subject", OracleDbType.Varchar2, 3000).Value = emailSubject;
                cmd.Parameters.Add("p_body", OracleDbType.Varchar2, 6000).Value = emailBody;
                cmd.Parameters.Add("p_status", OracleDbType.Varchar2, 4000).Value = emailStatus;
                
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;
               
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//end addSentEmails

        public static string addOrUpdatePositions(string usernameMsg, string positionMsg, string positionIdMsg, string departmentMsg)
        {
           //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_position";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_position", OracleDbType.Varchar2, 100).Value = positionMsg;
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 100).Value = positionIdMsg;
                cmd.Parameters.Add("p_department", OracleDbType.Varchar2, 100).Value = departmentMsg;

                


                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

               // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdatePostions

        public static DataTable getPositionList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select a.id id, a.position position,  B.NAME department, A.DEPARTMENT_ID DEPARTMENT_ID, a.created_by creator, a.created_date from POSITION_SETUP a, department_setup b where A.DEPARTMENT_ID=B.ID order by POSITION, department";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue(":USERNAME", username);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPositionList
        public static string addOrUpdateDepartments(string usernameMsg, string departmentMsg, string groupNameMsg, string departmentIdMsg)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_department";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                //
                //I added this now
                //OracleParameter retval = new OracleParameter("ret", OracleDbType.Varchar2, 30);
                //retval.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add(retval);


                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 50).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_department", OracleDbType.Varchar2, 100).Value = departmentMsg;
                cmd.Parameters.Add("p_groupName", OracleDbType.Varchar2, 100).Value = groupNameMsg;
                cmd.Parameters.Add("p_department_id", OracleDbType.Varchar2, 50).Value = departmentIdMsg;




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateDepartments
        public static string addOrUpdateKPITemplate(string usernameMsg, string kpiTemplateIdMsg, string departmentMsg, string positionMsg,
            string serialNoMsg, string kpiDimensionMsg, string kpiMsg, string kpiGroupMsg, string kpiDefMsg, string formulaMsg,
            string sigLevelMsg, string infLevelMsg, string impFactMsg, string weightMsg, string sourceMsg, string respMsg, string existMsg)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_kpitemplate";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);
                //End I added this now
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 70).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_kpi_templ_id", OracleDbType.Varchar2, 20).Value = kpiTemplateIdMsg;
                cmd.Parameters.Add("p_department_id", OracleDbType.Varchar2, 20).Value = departmentMsg;
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 20).Value = positionMsg;
                cmd.Parameters.Add("p_serial_no", OracleDbType.Varchar2, 50).Value = serialNoMsg;
                cmd.Parameters.Add("p_kpi_dimension", OracleDbType.Varchar2, 70).Value = kpiDimensionMsg;
                cmd.Parameters.Add("p_kpi_id", OracleDbType.Varchar2, 20).Value = kpiMsg;
                cmd.Parameters.Add("p_kpi_group", OracleDbType.Varchar2, 20).Value = kpiGroupMsg;
                cmd.Parameters.Add("p_kpi_definition", OracleDbType.Varchar2, 500).Value = kpiDefMsg;
                cmd.Parameters.Add("p_formula", OracleDbType.Varchar2, 500).Value = formulaMsg;

                cmd.Parameters.Add("p_significance_level", OracleDbType.Varchar2, 20).Value = sigLevelMsg;
                cmd.Parameters.Add("p_influence_level", OracleDbType.Varchar2, 50).Value = infLevelMsg;
                cmd.Parameters.Add("p_importance_factor", OracleDbType.Int32, 70).Value = Convert.ToInt32(impFactMsg);
                cmd.Parameters.Add("p_weight", OracleDbType.Double, 70).Value = Convert.ToDouble(weightMsg);
                cmd.Parameters.Add("p_source", OracleDbType.Varchar2, 200).Value = sourceMsg;
                cmd.Parameters.Add("p_responsibility", OracleDbType.Varchar2, 200).Value = respMsg;
                cmd.Parameters.Add("p_existing_yes_no", OracleDbType.Varchar2, 50).Value = existMsg;







                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateDepartments
        
        
        public static string addOrUpdateKPIView(string kpiDimension, string totalKPINumber, string totalObtainableScore, string empNo, string kpiDimensionComments, string appraisalPeriod)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_kpiview";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_kpi_dimension", OracleDbType.Varchar2, 50).Value = kpiDimension;
                cmd.Parameters.Add("p_total_kpi_no", OracleDbType.Int32, 100).Value =Convert.ToInt32(totalKPINumber);
                cmd.Parameters.Add("p_total_obtainablescore", OracleDbType.Double, 100).Value = Convert.ToDouble(totalObtainableScore);
                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = empNo;
                cmd.Parameters.Add("p_kpi_dimension_comments", OracleDbType.Varchar2, 500).Value = kpiDimensionComments;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 100).Value = Convert.ToInt32(appraisalPeriod);
               




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateKPIView


        public static string addOrUpdateAPKPIView(string kpiDimension, string empNo, string kpiDimensionComments, string appraisalPeriod)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_ap_kpiview";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_kpi_dimension", OracleDbType.Varchar2, 50).Value = kpiDimension;
                //cmd.Parameters.Add("p_total_kpi_no", OracleDbType.Int32, 100).Value = Convert.ToInt32(totalKPINumber);
                //cmd.Parameters.Add("p_total_obtainablescore", OracleDbType.Double, 100).Value = Convert.ToDouble(totalObtainableScore);
                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = empNo;
                cmd.Parameters.Add("p_kpi_dimension_comments", OracleDbType.Varchar2, 500).Value = kpiDimensionComments;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 100).Value = Convert.ToInt32(appraisalPeriod);





                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateKPIView



        public static string addOrUpdateApplicationFormKpiDimDetails(string employeeNo, string kpiId, string weight, string target, string actual, string appraisalPeriod)
            //addOrUpdateApplicationFormKpiDimDetails(string employeeNo, string kpiId, string actual, string score, string appraisalPeriod)
        {
            
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_ap_dim_details";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_kpi_id", OracleDbType.Varchar2, 50).Value = kpiId;
                //cmd.Parameters.Add("p_weight", OracleDbType.Double, 100).Value = Convert.ToDouble(weight);
                //cmd.Parameters.Add("p_target", OracleDbType.Double, 100).Value = Convert.ToDouble(target);
                cmd.Parameters.Add("p_actual", OracleDbType.Double, 100).Value = Convert.ToDouble(actual);
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);


                //addOrUpdateKpiApplicationFormDimDetails


                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateKpiDimDetails




        public static string addOrUpdateKpiDimDetails(string employeeNo, string positionId, string kpiId, string kpiType, string weight, 
            string target, string kpiDimension, string appraisalPeriod)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_kpi_dim_details";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 50).Value = positionId;
                cmd.Parameters.Add("p_kpi_id", OracleDbType.Varchar2, 50).Value = kpiId;
                cmd.Parameters.Add("p_kpi_type", OracleDbType.Varchar2, 50).Value = kpiType;
                cmd.Parameters.Add("p_weight", OracleDbType.Double, 100).Value = Convert.ToDouble(weight);
                cmd.Parameters.Add("p_target", OracleDbType.Double, 100).Value = Convert.ToDouble(target);
                cmd.Parameters.Add("p_kpi_dimension", OracleDbType.Varchar2, 50).Value = kpiDimension;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);


                //addOrUpdateKpiApplicationFormDimDetails


                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateKpiDimDetails
        public static string addOrUpdateBCKpiDimDetails(string kpiDimId, string actionPlan, string employeeNo, string appraisalPeriod)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_bc_kpi_dim";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);

                cmd.Parameters.Add("p_kpi_dim_id", OracleDbType.Int32, 50).Value = Convert.ToInt32(kpiDimId);
                cmd.Parameters.Add("p_action_plan", OracleDbType.Varchar2, 1500).Value = actionPlan;
                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod); 
                
               





                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateBCKpiDimDetails
        public static string approveBCompetencies(string employeeNo, string appraisalPeriod, string appraiserSign, string appraiserDate, string status)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.approve_bc_goal";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraiser_sign", OracleDbType.Varchar2, 100).Value = appraiserSign;
                cmd.Parameters.Add("p_appraiser_date", OracleDbType.Date, 50).Value = Convert.ToDateTime(appraiserDate);
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                cmd.Parameters.Add("p_status", OracleDbType.Varchar2, 50).Value = status;
                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Approving BC Goal Settings Error: " + ex.Message;
            }
            //  return 0;
        }//approveBCompetencies
        public static string addOrUpdateBCGoalSettings(string employeeNo, string holderSign, string holderDate, string appraisalPeriod)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_bc_goal";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);

                
                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_holder_sign", OracleDbType.Varchar2, 100).Value = holderSign;
                cmd.Parameters.Add("p_holder_date", OracleDbType.Date, 50).Value = Convert.ToDateTime(holderDate);
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Saving or Updating BC Goal Settings Error: "+ex.Message;
            }
            //  return 0;
        }//addOrUpdateBCKpiDimDetails
        public static string addOrUpdateBCAppraisalForm(string employeeNo, string appraisalPeriod, string profSupText, string profSupLbl,
         string commSupText, string commSupLbl, string innoSupText, string innoSupLbl, string leadSupText, string leadSupLbl, string ccSupText,
             string ccSupLbl, string peSupText, string peSupLbl, string teamSupText, string teamSupLbl)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_bcs_app_form";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                cmd.Parameters.Add("p_prof_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(profSupLbl);
                cmd.Parameters.Add("p_prof_sup_comment", OracleDbType.Varchar2, 2000).Value = profSupText;
                cmd.Parameters.Add("p_comm_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(commSupLbl);
                cmd.Parameters.Add("p_comm_sup_comment", OracleDbType.Varchar2, 2000).Value = commSupText;
                cmd.Parameters.Add("p_inno_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(innoSupLbl);
                cmd.Parameters.Add("p_inno_sup_comment", OracleDbType.Varchar2, 2000).Value = innoSupText;
                cmd.Parameters.Add("p_lead_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(leadSupLbl);
                cmd.Parameters.Add("p_lead_sup_comment", OracleDbType.Varchar2, 2000).Value = leadSupText;
                cmd.Parameters.Add("p_cc_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(ccSupLbl);
                cmd.Parameters.Add("p_cc_sup_comment", OracleDbType.Varchar2, 2000).Value = ccSupText;
                cmd.Parameters.Add("p_pe_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(peSupLbl);
                cmd.Parameters.Add("p_pe_sup_comment", OracleDbType.Varchar2, 2000).Value = peSupText;
                cmd.Parameters.Add("p_team_sup_score", OracleDbType.Double, 50).Value = Convert.ToDouble(teamSupLbl);
                cmd.Parameters.Add("p_team_sup_comment", OracleDbType.Varchar2, 2000).Value = teamSupText;
                
                                
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Saving or Updating BC Appraisal Form Error: " + ex.Message;
            }
            //  return 0;
        }




        public static string addOrUpdateAppraiserSummary(string employeeNo, string appraisalPeriod, string rating, string keyStr, string impArea,
        string proposedDev, string appraiserSign, string appraiserDate)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_appr_summary";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                cmd.Parameters.Add("p_rating", OracleDbType.Varchar2, 2000).Value = rating;
                cmd.Parameters.Add("p_key_strength", OracleDbType.Varchar2, 2000).Value = keyStr;
                cmd.Parameters.Add("p_imp_area", OracleDbType.Varchar2, 2000).Value = impArea;
                cmd.Parameters.Add("p_proposed_development", OracleDbType.Varchar2, 2000).Value = proposedDev;
                cmd.Parameters.Add("p_app_sign", OracleDbType.Varchar2, 60).Value = appraiserSign;
                cmd.Parameters.Add("p_appraiser_date", OracleDbType.Date, 50).Value = Convert.ToDateTime(appraiserDate);
                
                
               


                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Saving or Updating Appraisal Summary Error: " + ex.Message;
            }
            //  return 0;
        }


        public static string addOrUpdateHolderApprSummary(string employeeNo, string appraisalPeriod, string KeyAch, string accRej, string reasons,
            string jHolderSign, string jHolderDate)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_appr_summary";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                cmd.Parameters.Add("p_key_achievement", OracleDbType.Varchar2, 2000).Value = KeyAch;
                cmd.Parameters.Add("p_acc_rej", OracleDbType.Varchar2, 2000).Value = accRej;
                cmd.Parameters.Add("p_reasons", OracleDbType.Varchar2, 2000).Value = reasons;
                cmd.Parameters.Add("p_holder_sign", OracleDbType.Varchar2, 60).Value = jHolderSign;
                cmd.Parameters.Add("p_holder_date", OracleDbType.Date, 50).Value = Convert.ToDateTime(jHolderDate);





                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Saving or Updating Job Holder Appraisal Summary Error: " + ex.Message;
            }
            //  return 0;
        }

       public static string addOrUpdateConcurrentApprSummary(string employeeNo, string appraisalPeriod, string concurrentComment, string concSign, string concDate)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_cc_appr_summary";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                cmd.Parameters.Add("p_conc_comment", OracleDbType.Varchar2, 2000).Value = concurrentComment;
                cmd.Parameters.Add("p_concurrent_sign", OracleDbType.Varchar2, 60).Value = concSign;
                cmd.Parameters.Add("p_concurrent_date", OracleDbType.Date, 50).Value = Convert.ToDateTime(concDate);





                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Saving or Updating Concurrent Signature Error: " + ex.Message;
            }
            //  return 0;
        }

        public static string addOrUpdateBCHolderAppraisalForm(string employeeNo, string appraisalPeriod, string profJHText, string profJHLbl,
        string commJHText, string commJHLbl, string innoJHText, string innoJHLbl, string leadJHText, string leadJHLbl, string ccJHText,
            string ccJHLbl, string peJHText, string peJHLbl, string teamJHText, string teamJHLbl)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.add_or_update_bcj_app_form";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appraisalPeriod);
                cmd.Parameters.Add("p_prof_score", OracleDbType.Double, 50).Value = Convert.ToDouble(profJHLbl);
                cmd.Parameters.Add("p_prof_comment", OracleDbType.Varchar2, 2000).Value = profJHText;
                cmd.Parameters.Add("p_comm_score", OracleDbType.Double, 50).Value = Convert.ToDouble(commJHLbl);
                cmd.Parameters.Add("p_comm_comment", OracleDbType.Varchar2, 2000).Value = commJHText;
                cmd.Parameters.Add("p_inno_score", OracleDbType.Double, 50).Value = Convert.ToDouble(innoJHLbl);
                cmd.Parameters.Add("p_inno_comment", OracleDbType.Varchar2, 2000).Value = innoJHText;
                cmd.Parameters.Add("p_lead_score", OracleDbType.Double, 50).Value = Convert.ToDouble(leadJHLbl);
                cmd.Parameters.Add("p_lead_comment", OracleDbType.Varchar2, 2000).Value = leadJHText;
                cmd.Parameters.Add("p_cc_score", OracleDbType.Double, 50).Value = Convert.ToDouble(ccJHLbl);
                cmd.Parameters.Add("p_cc_comment", OracleDbType.Varchar2, 2000).Value = ccJHText;
                cmd.Parameters.Add("p_pe_score", OracleDbType.Double, 50).Value = Convert.ToDouble(peJHLbl);
                cmd.Parameters.Add("p_pe_comment", OracleDbType.Varchar2, 2000).Value = peJHText;
                cmd.Parameters.Add("p_team_score", OracleDbType.Double, 50).Value = Convert.ToDouble(teamJHLbl);
                cmd.Parameters.Add("p_team_comment", OracleDbType.Varchar2, 2000).Value = teamJHText;
                

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                //re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return "Saving or Updating BC J Appraisal Form Error: " + ex.Message;
            }
            //  return 0;
        }
        public static string UpdateBCAppraiserComments(string employeeNo, string appPeriod, string appraiserComments, string status)
        {
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                cmd.CommandText = "pkg_appraisal.update_bc_sup_comments";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);

                cmd.Parameters.Add("p_emp_no", OracleDbType.Varchar2, 50).Value = employeeNo;
                cmd.Parameters.Add("p_appraisal_period", OracleDbType.Int32, 50).Value = Convert.ToInt32(appPeriod);
                cmd.Parameters.Add("p_comments", OracleDbType.Varchar2, 3000).Value = appraiserComments;
                cmd.Parameters.Add("p_status", OracleDbType.Varchar2, 1500).Value = status;
                
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//UpdateBCAppraiserComments

        public static DataTable getDepartmentsList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP order by NAME";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue(":USERNAME", username);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }
        public static DataTable getKPIPoolTemplateTable()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, D.KPI_NAME KPI_NAME, a.KPI KPI, A.KPI_GROUP KPI_GROUP, a.KPI_DEFINITION KPI_DEFINITION, A.FORMULA FORMULA," +
"A.SIGNIFICANCE_LEVEL SIGNIFICANCE_LEVEL, A.INFLUENCE_LEVEL INFLUENCE_LEVEL, A.IMPORTANCE_FACTOR IMPORTANCE_FACTOR, A.WEIGHT weight, A.SOURCE source,"+
"A.RESPONSIBILITY RESPONSIBILITY, A.EXISTING_YES_NO EXISTING_YES_NO, A.S_N s_n, A.POSITION_ID POSITION_ID, B.POSITION POSITION, A.DEPARTMENT_ID DEPARTMENT_ID, C.NAME department from KPI_TEMPLATE a, position_setup b," +
"department_setup c, GROUP_DEPTAL_KPI d where A.POSITION_ID=B.ID and A.DEPARTMENT_ID=C.ID and A.KPI=D.ID order by POSITION, KPI_DIMENSION";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }


        public static DataTable getKPIPoolTemplateTable(string position, string kpiName)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, D.KPI_NAME KPI_NAME, a.KPI KPI, A.KPI_GROUP KPI_GROUP, a.KPI_DEFINITION KPI_DEFINITION, A.FORMULA FORMULA," +
"A.SIGNIFICANCE_LEVEL SIGNIFICANCE_LEVEL, A.INFLUENCE_LEVEL INFLUENCE_LEVEL, A.IMPORTANCE_FACTOR IMPORTANCE_FACTOR, A.WEIGHT weight, A.SOURCE source," +
"A.RESPONSIBILITY RESPONSIBILITY, A.EXISTING_YES_NO EXISTING_YES_NO, A.S_N s_n, A.POSITION_ID POSITION_ID, B.POSITION POSITION, A.DEPARTMENT_ID DEPARTMENT_ID, C.NAME department from KPI_TEMPLATE a, position_setup b," +
"department_setup c, GROUP_DEPTAL_KPI d where A.POSITION_ID=B.ID and A.DEPARTMENT_ID=C.ID and A.KPI=D.ID "+
"and a.position_id='"+position+"' and lower(d.kpi_name)='"+kpiName.ToLower()+"'";

                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getKPIPoolTemplateTable

        public static List<EmployeeRequest> getEmployeeLists()
        {
            List<EmployeeRequest> empList = new List<EmployeeRequest>();

            //using (OracleConnection con = new OracleConnection())
            //{
            //    con.ConnectionString = Dalcs.MisportalConnection;
            //    con.Open();
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = Dalcs.hm42ConnectionString;

                con.Open();

                string sql = "select employee_number, employee_surname, other_names, pay_group, date_of_employment, e_mail1 from mast1 where SUBSTRING( employee_number ,1 , 2 )!='IT' AND SUBSTRING( employee_number ,1 , 2 )!='CT'";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add("v_bankfiid", SqlDbType.VarChar, 100).Value = bankfiid;

                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        EmployeeRequest emp = new EmployeeRequest();
                        // mailList.Add(reader["mailaddress"].ToString());
                        emp.EMPLOYEE_NO = reader["employee_number"].ToString();
                        emp.EMPLOYEE_SURNAME = reader["employee_surname"].ToString();
                        emp.EMPLOYEE_OTHERNAMES = reader["other_names"].ToString();
                        emp.GRADE_LEVEL = reader["pay_group"].ToString();
                        emp.EMPLOYMENT_DATE = reader["date_of_employment"].ToString();
                        emp.EMAIL = reader["e_mail1"].ToString();
                        
                        //
                        empList.Add(emp);
                    }
                }
                //add to colections

                //return lists


            }
            return empList;
        }//getEmployeeListList
        public static string addOrUpdateEmpRcdFromHM(string employeeNoMsg, string nameMsg, string gradeLevelMsg,
            string emailMsg, string empUsernameMsg, string usernameMsg, string employmentDateMsg)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_emp_from_hm";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                //
                //I added this now
                //OracleParameter retval = new OracleParameter("ret", OracleDbType.Varchar2, 30);
                //retval.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add(retval);


                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_employee_no", OracleDbType.Varchar2, 30).Value = employeeNoMsg;
                cmd.Parameters.Add("p_name", OracleDbType.Varchar2, 30).Value = nameMsg;
                cmd.Parameters.Add("p_grade_level", OracleDbType.Varchar2, 30).Value = gradeLevelMsg;
                cmd.Parameters.Add("p_email", OracleDbType.Varchar2, 100).Value = emailMsg;
                cmd.Parameters.Add("p_employee_username", OracleDbType.Varchar2, 30).Value = empUsernameMsg;
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 30).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_employment_date", OracleDbType.Varchar2, 100).Value = employmentDateMsg;

              




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateEmployeesRecords

        public static string updateEmployees(string usernameMsg, string empNoMsg, string positionIdMsg, string deptMsg)
        {
            //int retVal = 0;

            
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.update_employee";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                //
                //I added this now
                //OracleParameter retval = new OracleParameter("ret", OracleDbType.Varchar2, 30);
                //retval.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add(retval);


                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 30).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_employee_no", OracleDbType.Varchar2, 100).Value = empNoMsg;
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 100).Value = positionIdMsg;
                cmd.Parameters.Add("p_dept_id", OracleDbType.Varchar2, 100).Value = deptMsg;
               

                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdatePostions
        public static DataTable getEmployees()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm


                string sql = "select  a.EMPLOYEE_NO, a.NAME, b. name DEPARTMENT, c.POSITION POSITION_OR_JOBROLE, a.GRADE_LEVEL, a.EMAIL, a.USERNAME  from EMPLOYEE_SETUP a, department_setup b, position_setup c where a.department_id=b.id(+) and A.POSITION_OR_JOBROLE=C.ID(+) order by name asc";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";
                //string sql = "select a.EMPLOYEE_NO EMPLOYEE_NO, a.NAME NAME, b.name DEPARTMENT, C.POSITION POSITION_OR_JOBROLE, A.GRADE_LEVEL, A.EMAIL, A.USERNAME  from EMPLOYEE_SETUP a, DEPARTMENT_SETUP b, POSITION_SETUP c WHERE A.DEPARTMENT=B.ID AND A.POSITION_OR_JOBROLE=C.ID order by a.name asc";

                //
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue(":USERNAME", username);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getEmployees
        public static DataTable getPositionList(string positionMsg)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                //string sql = "select id, position, department, created_by creator, created_date from POSITION_SETUP where lower(position) like :v_positionMsg order by POSITION";
                //string sql = "select a.id, a.position, b.name department, a.created_by creator, a.created_date from POSITION_SETUP a, department_setup b where b.id=a.department_id and lower(a.position) like '%chief%' order by a.POSITION";
                string sql = "select a.id, a.position position, b.name department, a.created_by creator, a.created_date from POSITION_SETUP a, department_setup b where b.id=a.department_id and lower(a.position)=:v_positionMsg order by a.POSITION";
                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_positionMsg", positionMsg.ToLower().Trim()); 
                //cmd.Parameters.Add("v_positionMsg", "%" + positionMsg.ToLower().Trim() + "%"); 
               
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPositionList
        public static string getPositionPopulate(string positionMsg)
        {
            string content = "";
            try
            {
               

                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();


                /////////////////////////////
                string sql = "select a.id id, a.position position, b.name department, a.department_id department_id, a.created_by creator, a.created_date from POSITION_SETUP a, department_setup b where b.id=a.department_id and lower(a.position)=:v_positionMsg order by a.POSITION";
                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_positionMsg", positionMsg.ToLower().Trim());
           
                ////////////////////////////
                //string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where trim(lower(name))='"+ department.ToLower().Trim() +"' order by NAME";
                //OracleCommand cmd = new OracleCommand(sql, conn);
                //cmd.CommandType = CommandType.Text;
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    content = reader["id"].ToString() + "_" + reader["position"].ToString() + "_" + reader["department"].ToString() + "_" + reader["department_id"].ToString();
                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                
            }
            catch (Exception ex)
            {
                return ex.Message;
            }    
            
        }//end getPositionList
        public static DataTable getDepartmentsList(string departmentMsg)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where trim(lower(name)) like :v_departmentMsg order by NAME";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_departmentMsg", "%" + departmentMsg.ToLower().Trim() + "%"); 

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }

        public static string getDepartmentPopulate(string departmentMsg)
        {

            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where trim(lower(name)) =:v_departmentMsg order by NAME";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_departmentMsg", departmentMsg.ToLower().Trim());
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    content = reader["id"].ToString() + "_" + reader["name"].ToString() + "_" + reader["GROUPNAME"].ToString();
                }//end of while
                reader.Close();
                conn.Close();
                return content;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }    
            




                
                
               
               
        }


        public static string getKPIPopulate(string kpiMsg)
        {

            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sql = "select a.id id, a.KPI_NAME KPI_NAME, b.name department, a.KPI_TYPE KPI_TYPE, a.KPI_KIND KPI_KIND,a.department_id department_id from GROUP_DEPTAL_KPI a,  department_setup b where a.department_id=b.id and lower(a.kpi_name)=:v_kpiMsg";
                //string sql = "select a.id id, a.KPI_NAME KPI_NAME, b.name department, a.KPI_TYPE KPI_TYPE, a.KPI_KIND KPI_KIND, a.department_id department_id from GROUP_DEPTAL_KPI a, department_setup b where trim(lower(name)) =:v_kpiMsg and a.department_id=b.id";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_kpiMsg", kpiMsg.ToLower().Trim());
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    content = reader["id"].ToString() + "_" + reader["KPI_NAME"].ToString() + "_" + reader["department"].ToString() + "_" + reader["KPI_TYPE"].ToString() + "_" + reader["KPI_KIND"].ToString() + "_" + reader["department_id"].ToString();
                }//end of while
                reader.Close();
                conn.Close();
                return content;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }









        }//


        public static DataTable getEmployeeTableList(string employeeMsg)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select  a.EMPLOYEE_NO, a.NAME, b. name DEPARTMENT, c.POSITION POSITION_OR_JOBROLE, a.GRADE_LEVEL, a.EMAIL, a.USERNAME  from EMPLOYEE_SETUP a, department_setup b, position_setup c where a.department_id=b.id(+) and A.POSITION_OR_JOBROLE=C.ID(+) and trim(a.EMPLOYEE_NO)=:v_employee_no order by name asc";
               // string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where trim(lower(name)) like :v_departmentMsg order by NAME";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_employee_no",employeeMsg.Trim());

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//getEmployeeTableList
        
        public static DataTable getKPIInfoTable()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select a.id id, a.KPI_NAME KPI_NAME, b.name department, a.KPI_TYPE KPI_TYPE, a.KPI_KIND KPI_KIND, a.created_by creator, a.created_date created_date from GROUP_DEPTAL_KPI a, department_setup b where a.department_id=b.id order by department, kpi_type";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getKPIInfoTable
        public static string addOrUpdateGroupDeptKPI(string usernameMsg, string kpiNameMsg, string groupDeptIdMsg, string departmentMsg, 
            string kpiTypeMsg, string kpiKindMsg)
        {
            //int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_GROUP_DEPTAL_KPI";
                // refNo = refNo.Trim();

                cmd.CommandType = CommandType.StoredProcedure;
                //
                //
                //I added this now
                //OracleParameter retval = new OracleParameter("ret", OracleDbType.Varchar2, 30);
                //retval.Direction = ParameterDirection.ReturnValue;
                //cmd.Parameters.Add(retval);


                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


              
                //End I added this now
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = usernameMsg.ToLower();
                cmd.Parameters.Add("p_kpi_name", OracleDbType.Varchar2, 100).Value = kpiNameMsg;
                cmd.Parameters.Add("p_department", OracleDbType.Varchar2, 100).Value = departmentMsg;
                cmd.Parameters.Add("p_group_dept_id", OracleDbType.Varchar2, 100).Value = groupDeptIdMsg;
                cmd.Parameters.Add("p_kpi_type", OracleDbType.Varchar2, 100).Value = kpiTypeMsg;
                cmd.Parameters.Add("p_kpi_kind", OracleDbType.Varchar2, 100).Value = kpiKindMsg;
                




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdateGroupDeptKPI
        public static DataTable getKPIInfoTable(string searchMsg)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select a.id id, a.KPI_NAME KPI_NAME, b.name department, a.KPI_TYPE KPI_TYPE, a.KPI_KIND KPI_KIND, a.created_by creator, a.created_date created_date from GROUP_DEPTAL_KPI a, department_setup b where a.department_id=b.id and lower(a.kpi_name) =:v_searchMsg";
                //string sql = "select id, KPI_NAME, department_id department, KPI_TYPE, KPI_KIND, created_by creator, created_date from GROUP_DEPTAL_KPI  where lower(kpi_name) =:v_searchMsg order by kpi_name, department";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_searchMsg", searchMsg.ToLower()); 
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getKPIInfoTable
        public static string checkMatchingPositionDepartment(string positionMsg, string deptMsg)
        {
            int retVal = 0;
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                //cmd.CommandText = "pkg_appraisal.check_username";
                //cmd.CommandText = "select count(username) c_username from employee_setup where username=:p_username";
                cmd.CommandText = "select count(1) c_count from position_setup where trim(id)=:p_position and trim(department_id)=:p_department";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("p_position", OracleDbType.Varchar2, 100).Value = positionMsg.Trim();
                cmd.Parameters.Add("p_department", OracleDbType.Varchar2, 100).Value = deptMsg.Trim();
                OracleDataReader reader = cmd.ExecuteReader();

                string response = "0";
                //string ctval;
                //end

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        // ctval  = reader["c_username"].ToString();

                        if (reader["c_count"].ToString() == response)
                        {
                            return "0";
                        }
                        else
                            return "1";
                    }

                }
                //retVal = cmd.ExecuteNonQuery();

                //close connection
                conn.Close();

                return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }
        public static DataSet getDSDepartmentsList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP order by NAME";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue(":USERNAME", username);

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                con.Close();
                return dataSet;
            }
        }
        ////////////////////////////////////////////////////////////////////////////////
        public static DataSet getDSDepartmentsList(string departmentMsg)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where lower(name) like :v_departmentMsg order by NAME";
                //string sql = "select distinct a.username,a.userid,a.lastactivitydate from ora_aspnet_users a,tuserinfo_acc_bill b where a.username=b.username and APPLICATIONID='8A2B966BDEC14770B4A0F885004E6E06'";

                //created_date created_date
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_departmentMsg", "%" + departmentMsg.ToLower() + "%");

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataSet ds = new DataSet();
                adapter.Fill(ds);
                con.Close();
                return ds;
            }
        }
        /////////////////////////////////////////////////////////////////////////////////

        public static string getDepartmentContent(string department)
        {
            // int value;
            //  int created = 0;
           // string userBranch = get_user_branchid(username);

            string content = "";
            try
            {
                //using (OracleConnection con = new OracleConnection())
                //{

                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                //OracleCommand cmd = new OracleCommand();

                //c//md.Connection = conn;

                // con.ConnectionString = Dalcs.MisportalConnection;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed
                //
                string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where trim(lower(name))='"+ department.ToLower().Trim() +"' order by NAME";
                // :v_departmentMsg order by NAME
                //string sql = " select account_teller,fullname,email,branch_name,a.username,branch_tillacc from paycol_users a, paycol_perm b, paycol_bank_branch c where a.username = b.username and a.branchcode = c.branchid and trim(b.username)= '" + department.lower().Trim() + "'";
                //
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                //


                //cmd.Parameters.Add("p_bankname", OracleDbType.Varchar2, 100).Value = username;
                // cmd.Parameters.Add("p_bankname", OracleDbType.Varchar2, 100).Value = bankname;


                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    content = reader["id"].ToString() + "_" + reader["name"].ToString() +"_" + reader["GROUPNAME"].ToString() + "_" + reader["creator"].ToString() + "_" + reader["created_date"].ToString();
                    //

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getDepartmentContent
        public static string getUserContent(string username)
        {
            // int value;
            //  int created = 0;
            // string userBranch = get_user_branchid(username);

            string content = "";
            try
            {
                //using (OracleConnection con = new OracleConnection())
                //{

                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                //OracleCommand cmd = new OracleCommand();

                //c//md.Connection = conn;

                // con.ConnectionString = Dalcs.MisportalConnection;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed
                //
                //string sql = "select id, name, GROUPNAME, created_by creator, created_date from DEPARTMENT_SETUP where trim(lower(name))='" + department.ToLower().Trim() + "' order by NAME";
                string sql = "select USERNAME,USER_MGT,APPRAISAL_MGT,GOAL_SETTINGS_MGT,APPR_SETTINGS_MGT, VIEW_GOAL_SETTINGS,VIEW_APP_FORM from USER_SETUP where trim(lower(USERNAME))='" + username.ToLower().Trim() + "' order by USERNAME";
                // :v_departmentMsg order by NAME
                //string sql = " select account_teller,fullname,email,branch_name,a.username,branch_tillacc from paycol_users a, paycol_perm b, paycol_bank_branch c where a.username = b.username and a.branchcode = c.branchid and trim(b.username)= '" + department.lower().Trim() + "'";
                //
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    content = reader["USERNAME"].ToString() + "_" + reader["USER_MGT"].ToString() + "_" + reader["APPRAISAL_MGT"].ToString() + "_" + reader["GOAL_SETTINGS_MGT"].ToString() + "_" + reader["APPR_SETTINGS_MGT"].ToString() + "_" + reader["VIEW_GOAL_SETTINGS"].ToString() + "_" + reader["VIEW_APP_FORM"].ToString();
                    //

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getUserContent


        public static string getDepartmentFromPosition(string position)
        {
            string content = "";
            try
            {
            OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string sql = "select a.department_id dept_id, b.NAME department_name from POSITION_SETUP a, DEPARTMENT_SETUP b where a.department_id=b.id and a.id='" + position.ToLower().Trim() + "'";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    content = reader["dept_id"].ToString() + "_" + reader["department_name"].ToString();
                }//end of while
                reader.Close();
                conn.Close();
                return content;
             }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getDepartmentFromPosition



        public static string getSupervisesContent(string position_id)
        {
        
            string content = "";
            try
            {
               
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                string sql = "select id, SUPERVISES, POSITION_ID from SUPERVISEES where position_id='" + position_id + " order by NAME";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    content = reader["id"].ToString() + "_" + reader["SUPERVISES"].ToString();
                    //supervisesMsg = supervisesMsg + "," + item.Valu

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                content = content.Remove(0, 1);
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getDepartmentContent
        public static string getEmployeeContent(string employeeNo)
        {
            // int value;
            //  int created = 0;
            // string userBranch = get_user_branchid(username);

            string content = "";
            try
            {
                //using (OracleConnection con = new OracleConnection())
                //{

                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                //OracleCommand cmd = new OracleCommand();

                //c//md.Connection = conn;

                // con.ConnectionString = Dalcs.MisportalConnection;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed
                //
                string sql = "select EMPLOYEE_NO, NAME from employee_SETUP where trim(EMPLOYEE_NO)='" + employeeNo.Trim() + "' order by NAME";
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    content = reader["EMPLOYEE_NO"].ToString() + "_" + reader["name"].ToString();
                    
                    


                }//end of while
                reader.Close();
                //
                conn.Close();
                //
               
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getEmployeeContent
        public static string updateSupervisor(string positionIdMsg, string supervisorMsg)
        {
            //int retVal = 0;


            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.update_supervisor";
                cmd.CommandType = CommandType.StoredProcedure;
               


                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
               // cmd.Parameters.Add("p_sup_id", OracleDbType.Varchar2, 100).Value = supIdMsg;
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 50).Value = positionIdMsg;
                cmd.Parameters.Add("p_supervisees_id", OracleDbType.Varchar2, 100).Value = supervisorMsg;
               
                
                

                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//addOrUpdatePostions
        public static string deleteSupervises(string positionIdMsg)
        {
            //int retVal = 0;


            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.delete_supervises";
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);


                //End I added this now
                // cmd.Parameters.Add("p_sup_id", OracleDbType.Varchar2, 100).Value = supIdMsg;
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 50).Value = positionIdMsg;
                //cmd.Parameters.Add("p_supervisees_id", OracleDbType.Varchar2, 100).Value = supervisorMsg;




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
               return ex.Message;
            }
            
        }
       
        public static string addOrUpdateRoleMenu(string roleIdMsg, string menuIdMsg)
        {
          try
            {

                //int roleMenuId;
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.update_role_menu";
                cmd.CommandType = CommandType.StoredProcedure;



                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);

                //if (Convert.ToInt32(roleMenuIdMsg) > 1)
                //{
                //    roleMenuId = Convert.ToInt32(roleMenuIdMsg);
                //}
                //else
                //{
                //    roleMenuId = 0;                
                //}
                //cmd.Parameters.Add("p_role_menu_id", OracleDbType.Int32, 50).Value = roleMenuId; 
                cmd.Parameters.Add("p_role_id", OracleDbType.Int32, 50).Value = Convert.ToInt32(roleIdMsg);
                cmd.Parameters.Add("p_menu_id", OracleDbType.Int32, 50).Value = Convert.ToInt32(menuIdMsg);




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
            //  return 0;
        }//

        public static string addOrUpdateUserRole(string userMsg, string username, string roleIdMsg)
        {
          try
            {

               OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.add_or_update_user_role";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);
                //p_username varchar2, p_maker_name varchar2, p_maker_date date, p_role_id
                cmd.Parameters.Add("p_user", OracleDbType.Varchar2, 80).Value = userMsg;
                cmd.Parameters.Add("p_maker_name", OracleDbType.Varchar2, 80).Value = username;  
                cmd.Parameters.Add("p_role_id", OracleDbType.Int32, 50).Value = Convert.ToInt32(roleIdMsg);
                
              
              if (conn.State == ConnectionState.Closed)
                    conn.Open();

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                conn.Close();
                return returnNow;

              
            }
            catch (Exception ex)
            {
                //return 0;
                return ex.Message;
            }
          
        }//addOrUpdateUserRole

        
        public static string deleteRolesMenus(string roleIdMsg)
        {
            //int retVal = 0;


            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;

                cmd.CommandText = "pkg_appraisal.delete_roles_menus";
                cmd.CommandType = CommandType.StoredProcedure;
                OracleParameter result = new OracleParameter();
                result.ParameterName = "ReturnValue";
                result.OracleDbType = OracleDbType.Decimal;
                result.Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add(result);
                cmd.Parameters.Add("p_position_id", OracleDbType.Varchar2, 50).Value = roleIdMsg;
                




                //end
                if (conn.State == ConnectionState.Closed)
                    conn.Open();//re open if connection closed

                cmd.ExecuteNonQuery();
                string returnNow = result.Value.ToString();

                //close connection
                conn.Close();
                return returnNow;

                // return retVal.ToString();//return val
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
        
        
        public static List<SupervisesRequest> getSupervisesLists(string position_id)
        {
            List<SupervisesRequest> supList = new List<SupervisesRequest>();
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select a.id id, b.SUPERVISES supervises from supervisees a, position_setup b where a.supervises=b.id and  a.position_id='" + position_id + "'";
                string sql = "select id, SUPERVISES where position_id='" + position_id + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                // cmd.Parameters.Add("v_bankfiid", SqlDbType.VarChar, 100).Value = bankfiid;

                OracleDataReader reader = cmd.ExecuteReader();


                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        SupervisesRequest sup = new SupervisesRequest();
                        // mailList.Add(reader["mailaddress"].ToString());
                        sup.ID = reader["id"].ToString();
                        sup.SUPERVISES = reader["SUPERVISES"].ToString();
                        supList.Add(sup);
                    }
                }
                //add to colections

                //return lists


            }
            return supList;
        }//getEmployeeListList
        public static string getPhaseOneContent(string username)
        {
           string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
     
                //string sql ="select a.EMPLOYEE_NO emp_no, a.NAME name, b.NAME department, c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, A.USERNAME USERNAME from EMPLOYEE_SETUP a, "+
                //"DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + department.ToLower().Trim() + "'";

                string sql = "select a.NAME name, b.NAME department, a.EMPLOYEE_NO EMPLOYEE_NO, a.POSITION_OR_JOBROLE POSITION_OR_JOBROLE,  c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, a.username username, a.email email from EMPLOYEE_SETUP a, " +
                "DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + username.ToLower().Trim() + "'";
                
                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
               

                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                 //content = reader["emp_no"].ToString() + "_" + reader["name"].ToString() + "_" + reader["department"].ToString()
                 //+ "_" + reader["position"].ToString() + "_" + reader["GRADE_LEVEL"].ToString() + "_" + reader["USERNAME"].ToString();

                 content = reader["name"].ToString() + "_" + reader["department"].ToString() + "_" + reader["GRADE_LEVEL"].ToString()+
                    "_" + reader["EMPLOYEE_NO"].ToString() + "_" + reader["POSITION_OR_JOBROLE"].ToString() + "_" + reader["USERNAME"].ToString() + "_" + reader["email"].ToString();
                    //

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getPhaseOneContent


        public static string getConcurrentSign(string username)
        {
            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string sql = "select  B.NAME concurrent_name, a.CONCURRENT_SIGN_OFF from JOB_DISCRIPTION_SETUP a, EMPLOYEE_SETUP b, EMPLOYEE_SETUP c where"+
                "B.POSITION_OR_JOBROLE=A.CONCURRENT_SIGN_OFF and C.POSITION_OR_JOBROLE=A.POSITION_ID and trim(lower(A.USERNAME))='" + username.ToLower().Trim() + "'";
                
                
                //string sql = "select a.NAME name, b.NAME department, a.EMPLOYEE_NO EMPLOYEE_NO, a.POSITION_OR_JOBROLE POSITION_OR_JOBROLE,  c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, a.username username, a.email email from EMPLOYEE_SETUP a, " +
                //"DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + username.ToLower().Trim() + "'";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;


                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    content = reader["concurrent_name"].ToString() + "_" + reader["CONCURRENT_SIGN_OFF"].ToString();
                    
                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getPhaseOneContent


        public static string getAppraisalSummaryData(string username, string appraisalPeriod)
        {
            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                //string sql ="select a.EMPLOYEE_NO emp_no, a.NAME name, b.NAME department, c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, A.USERNAME USERNAME from EMPLOYEE_SETUP a, "+
                //"DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + department.ToLower().Trim() + "'";

                string sql = "select ID, OVERALL_RATING, KEY_ACHIVEMENT, KEY_STRENGTH, IMPROVEMENT_AREA, PROPOSED_DEV, CONCURRENT_SUP_CMMTS, "+
                "AGREEMENT, a.EMPLOYEE_NO, APPRAISAL_PERIOD, A.APPRAISER_SIGN APPRAISER_SIGN  from APPRAISAL_SUMMARY_TBL a, EMPLOYEE_SETUP b where A.EMPLOYEE_NO=B.EMPLOYEE_NO and" +
                " trim(lower(B.USERNAME))="+ username.ToLower().Trim() + " and a.APPRAISAL_PERIOD="+Convert.ToInt32(appraisalPeriod);
                
                //string sql = "select a.NAME name, b.NAME department, a.EMPLOYEE_NO EMPLOYEE_NO, a.POSITION_OR_JOBROLE POSITION_OR_JOBROLE,  c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, a.username username, a.email email from EMPLOYEE_SETUP a, " +
                //"DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + username.ToLower().Trim() + "'";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;


                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    //content = reader["emp_no"].ToString() + "_" + reader["name"].ToString() + "_" + reader["department"].ToString()
                    //+ "_" + reader["position"].ToString() + "_" + reader["GRADE_LEVEL"].ToString() + "_" + reader["USERNAME"].ToString();

     content = reader["ID"].ToString() + "_" + reader["OVERALL_RATING"].ToString() + "_" + reader["KEY_ACHIVEMENT"].ToString() +
      "_" + reader["KEY_STRENGTH"].ToString() + "_" + reader["IMPROVEMENT_AREA"].ToString() + "_" + reader["PROPOSED_DEV"].ToString() + 
      "_" + reader["CONCURRENT_SUP_CMMTS"].ToString() + "_" + reader["AGREEMENT"].ToString() + "_" + reader["EMPLOYEE_NO"].ToString() +
      "_" + reader["APPRAISAL_PERIOD"].ToString() + "_" + reader["APPRAISER_SIGN"].ToString();
            //

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getAppraisalSummaryData

        public static string getBCApplicationFormContent(string appraisalPeriod, string employeeNo)
        {
            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                //string sql ="select a.EMPLOYEE_NO emp_no, a.NAME name, b.NAME department, c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, A.USERNAME USERNAME from EMPLOYEE_SETUP a, "+
                //"DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + department.ToLower().Trim() + "'";

                string sql = "select * from BC_APPRAISAL_FORM where EMPLOYEE_NO='" + employeeNo + "' and APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;


                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    //content = reader["emp_no"].ToString() + "_" + reader["name"].ToString() + "_" + reader["department"].ToString()
                    //+ "_" + reader["position"].ToString() + "_" + reader["GRADE_LEVEL"].ToString() + "_" + reader["USERNAME"].ToString();

          content = reader["J_HOLDER_PROF_RATINGS"].ToString() + "_" + reader["SUP_PROF_RATINGS"].ToString() + "_" + reader["J_HOLDER_PROF_COMMENTS"].ToString() + "_" + reader["SUP_PROF_COMMENTS"].ToString() + "_"+
                    reader["J_HOLDER_COMM_RATINGS"].ToString() + "_" + reader["SUP_COMM_RATINGS"].ToString() + "_" + reader["J_HOLDER_COMM_COMMENTS"].ToString() + "_" + reader["SUP_COMM_COMMENTS"].ToString() + "_" +
                    reader["J_HOLDER_TEAM_RATINGS"].ToString() + "_" + reader["SUP_TEAM_RATINGS"].ToString() + "_" + reader["J_HOLDER_TEAM_COMMENTS"].ToString() + "_" + reader["SUP_TEAM_COMMENTS"].ToString() + "_" +
                    reader["J_HOLDER_CUST_RATINGS"].ToString() + "_" + reader["SUP_CUST_RATINGS"].ToString() + "_" + reader["J_HOLDER_CUST_COMMENTS"].ToString() + "_" + reader["SUP_CUST_COMMENTS"].ToString() + "_" +
                    reader["J_HOLDER_INNO_RATINGS"].ToString() + "_" + reader["SUP_INNO_RATINGS"].ToString() + "_" + reader["J_HOLDER_INNO_COMMENTS"].ToString() + "_" + reader["SUP_INNO_COMMENTS"].ToString() + "_" +
                    reader["J_HOLDER_LEAD_RATINGS"].ToString() + "_" + reader["SUP_LEAD_RATINGS"].ToString() + "_" + reader["J_HOLDER_LEAD_COMMENTS"].ToString() + "_" + reader["SUP_LEAD_COMMENTS"].ToString() + "_" +
                    reader["J_HOLDER_PERS_RATINGS"].ToString() + "_" + reader["SUP_PERS_RATINGS"].ToString() + "_" + reader["J_HOLDER_PERS_COMMENTS"].ToString() + "_" + reader["SUP_PERS_COMMENTS"].ToString() + "_" +
                    reader["EMPLOYEE_NO"].ToString() + "_" + reader["APPRAISAL_PERIOD"].ToString();
                    

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return ex.Message;
            }
        }//getBCApplicationFormContent

        public static string getGoalSettingsComments(string kpiDimension, string appraisalPeriod, string username)
        {
            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

               //string sql = "select COMMENTS, APPLICATION_FORM_COMMENTS, KPI_DIMENSION, EMPLOYEE_NO, APPRAISAL_PERIOD from PR_GOAL_SETTINGS where lower(kpi_dimension)='"+kpiDimension+"' and employee_no='" + employeeNo + "' and appraisal_period=" + appraisalPeriod + "";
               string sql = "select A.COMMENTS COMMENTS, A.APPLICATION_FORM_COMMENTS APPLICATION_FORM_COMMENTS, A.KPI_DIMENSION KPI_DIMENSION, A.EMPLOYEE_NO EMPLOYEE_NO, A.APPRAISAL_PERIOD APPRAISAL_PERIOD from PR_GOAL_SETTINGS A, EMPLOYEE_SETUP B where A.EMPLOYEE_NO=B.EMPLOYEE_NO and lower(a.kpi_dimension)='"+kpiDimension+"' and B.USERNAME='"+username+"' and appraisal_period="+appraisalPeriod+"";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;


                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //content = reader["COMMENTS"].ToString() + "_" + reader["APPLICATION_FORM_COMMENTS"].ToString() + "_" + reader["KPI_DIMENSION"].ToString();
                    content = reader["COMMENTS"].ToString() + "_" + reader["APPLICATION_FORM_COMMENTS"].ToString();
                    
                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return "Get Goal Settings Comments Error:" + ex.Message;
            }
        }//getGoalSettingsComments

        public static string getSupervisorInformation(string username)
        {
            string content = "";
            try
            {
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = Dalcs.PMSConnectionString;
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                //string sql ="select a.EMPLOYEE_NO emp_no, a.NAME name, b.NAME department, c.POSITION position, a.GRADE_LEVEL GRADE_LEVEL, A.USERNAME USERNAME from EMPLOYEE_SETUP a, "+
                //"DEPARTMENT_SETUP b, position_setup c where a.DEPARTMENT_ID=b.id and a.POSITION_OR_JOBROLE=c.id and trim(lower(A.USERNAME))='" + department.ToLower().Trim() + "'";

                string sql = "select c.USERNAME username, c.EMAIL email, c.name name  from SUPERVISEES a, EMPLOYEE_SETUP b, EMPLOYEE_SETUP c where a.position_id=c.POSITION_OR_JOBROLE and a.supervises=B.POSITION_OR_JOBROLE and trim(lower(b.USERNAME))='" + username.ToLower().Trim() + "'";

                OracleCommand cmd = new OracleCommand(sql, conn);
                cmd.CommandType = CommandType.Text;


                //
                OracleDataReader reader;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    //get alert_content
                    //content = reader["emp_no"].ToString() + "_" + reader["name"].ToString() + "_" + reader["department"].ToString()
                    //+ "_" + reader["position"].ToString() + "_" + reader["GRADE_LEVEL"].ToString() + "_" + reader["USERNAME"].ToString();

                    content = reader["username"].ToString() + "_" + reader["email"].ToString() + "_" + reader["name"].ToString();
                    //

                }//end of while
                reader.Close();
                //
                conn.Close();
                //
                return content;
                //}
            }
            catch (Exception ex)
            {
                //return 2;
                return "Get Supervisor Information Error:" + ex.Message;
            }
        }//getDepartmentContent

        public static DataTable getPhaseTwoAPPFormList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                //string sql = "select a.KPI_DIMENSION KPI_DIMENSION, count(a.KPI_DIMENSION)TOTAL_KPI_NUMBER ,sum(A.WEIGHT) TOTAL_OBTAINABLE_SCORE, (select 0 from dual)INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO EMPLOYEE_NO  from KPI_TEMPLATE a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:v_user_session group by a.KPI_DIMENSION, INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO";
                string sql = "select a.KPI_DIMENSION KPI_DIMENSION, count(a.KPI_DIMENSION)TOTAL_KPI_NUMBER ,sum(A.WEIGHT) TOTAL_OBTAINABLE_SCORE, SUM(A.SCORE)INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO EMPLOYEE_NO  from KPI_SETUP a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:v_user_session group by a.KPI_DIMENSION, INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO";
                //order by a.KPI_DIMENSION
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_user_session", userSession.Trim());

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//getPhaseTwoAPPFormList

        public static DataTable getPhaseTwoAPPFormList(string appraisalPeriod, string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                //string sql = "select a.KPI_DIMENSION KPI_DIMENSION, count(a.KPI_DIMENSION)TOTAL_KPI_NUMBER ,sum(A.WEIGHT) TOTAL_OBTAINABLE_SCORE, (select 0 from dual)INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO EMPLOYEE_NO  from KPI_TEMPLATE a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:v_user_session group by a.KPI_DIMENSION, INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO";
                string sql = "select a.KPI_DIMENSION KPI_DIMENSION, count(a.KPI_DIMENSION)TOTAL_KPI_NUMBER ,sum(A.WEIGHT) TOTAL_OBTAINABLE_SCORE, SUM(A.SCORE)INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO EMPLOYEE_NO  from KPI_SETUP a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:v_user_session and a.APPRAISAL_PERIOD=:v_app_period group by a.KPI_DIMENSION, INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO";
                //order by a.KPI_DIMENSION
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_user_session", userSession.Trim());
                cmd.Parameters.Add("v_app_period", appraisalPeriod.Trim());
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//getPhaseTwoAPPFormList
        
             
        // PhaseTwo consist of Financial, Customer, Process Efficiency, People and Brand
        public static DataTable getPhaseTwoList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select a.KPI_DIMENSION KPI_DIMENSION, count(a.KPI_DIMENSION)TOTAL_KPI_NUMBER ,sum(A.WEIGHT) TOTAL_OBTAINABLE_SCORE, (select 0 from dual)INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO EMPLOYEE_NO  from KPI_TEMPLATE a, EMPLOYEE_SETUP b where A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(B.USERNAME))=:v_user_session group by a.KPI_DIMENSION, INDIVIDUAL_PERFORMANCE_SCORE, B.EMPLOYEE_NO";
                //order by a.KPI_DIMENSION
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("v_user_session", userSession.Trim());

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//getPhaseTwoList

        public static DataTable getFinancialList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='financial' and trim(lower(B.USERNAME))='" + userSession + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getFinancialList
        public static DataTable getCustomerList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='customer' and trim(lower(B.USERNAME))='" + userSession + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCustomerList
        public static DataTable getProcessEfficiencyList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='process efficiency' and trim(lower(B.USERNAME))='" + userSession + "'";
                //string sql = "select A.ID ID, A.KPI_DIMENSION KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET from KPI_TEMPLATE A, EMPLOYEE_SETUP b where  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='process efficiency' and trim(lower(B.USERNAME))='" + userSession + "'";
                //, A.ACTUAL ACTUAL, A.SCORE SCORE
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getProcessEfficiencyList
        public static DataTable getPeopleList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='people' and trim(lower(B.USERNAME))='" + userSession + "'";
                //string sql = "select A.ID ID, A.KPI_DIMENSION KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET from KPI_TEMPLATE A, EMPLOYEE_SETUP b where  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='people' and trim(lower(B.USERNAME))='" + userSession + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPeopleList
        public static DataTable getBrandList(string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='brand' and trim(lower(B.USERNAME))='" + userSession + "'";
                //string sql = "select A.ID ID, A.KPI_DIMENSION KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET from KPI_TEMPLATE A, EMPLOYEE_SETUP b where  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='brand' and trim(lower(B.USERNAME))='" + userSession + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getbrandList


        public static DataTable getFinancialList(string appraisalPeriod, string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                //string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL, A.SCORE SCORE from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='financial' and trim(lower(B.USERNAME))='" + userSession + "'";
                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.TARGET TARGET, A.ACTUAL ACTUAL, round(A.SCORE,4) SCORE from KPI_SETUP A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI_id=C.ID AND  trim(lower(A.KPI_DIMENSION ))='financial' and A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))='" + userSession + "' AND A.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod);
                
                
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getFinancialList
        public static DataTable getCustomerList(string appraisalPeriod, string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                //string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL, A.SCORE SCORE from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='customer' and trim(lower(B.USERNAME))='" + userSession + "'";
                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.TARGET TARGET, A.ACTUAL ACTUAL, round(A.SCORE,4) SCORE from KPI_SETUP A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI_id=C.ID AND  trim(lower(A.KPI_DIMENSION ))='customer' and A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))='" + userSession + "' AND A.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod);
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                //adapter.SafeMapping.Add
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCustomerList
        public static DataTable getProcessEfficiencyList(string appraisalPeriod, string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                //string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL, A.SCORE SCORE from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='process efficiency' and trim(lower(B.USERNAME))='" + userSession + "'";
                //string sql = "select A.ID ID, A.KPI_DIMENSION KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET from KPI_TEMPLATE A, EMPLOYEE_SETUP b where  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='process efficiency' and trim(lower(B.USERNAME))='" + userSession + "'";
                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.TARGET TARGET, A.ACTUAL ACTUAL,  round(A.SCORE,4) SCORE from KPI_SETUP A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI_id=C.ID AND trim(lower(A.KPI_DIMENSION ))='process efficiency' and A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))='" + userSession + "' AND A.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod);
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getProcessEfficiencyList
        public static DataTable getPeopleList(string appraisalPeriod, string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm

                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.TARGET TARGET, A.ACTUAL ACTUAL,  round(A.SCORE,4) SCORE from KPI_SETUP A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI_id=C.ID AND  trim(lower(A.KPI_DIMENSION ))='people' and A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))='" + userSession + "' AND A.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod);
                //string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL, A.SCORE SCORE from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='people' and trim(lower(B.USERNAME))='" + userSession + "'";
                //string sql = "select A.ID ID, A.KPI_DIMENSION KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET from KPI_TEMPLATE A, EMPLOYEE_SETUP b where  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='people' and trim(lower(B.USERNAME))='" + userSession + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPeopleList
        public static DataTable getBrandList(string appraisalPeriod, string userSession)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.TARGET TARGET, A.ACTUAL ACTUAL,  round(A.SCORE,4) SCORE from KPI_SETUP A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI_id=C.ID AND  trim(lower(A.KPI_DIMENSION ))='brand' and A.EMPLOYEE_NO=B.EMPLOYEE_NO and trim(lower(B.USERNAME))='" + userSession + "' AND A.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod);
                // string sql = "select A.ID ID, c.id KPI_ID, C.KPI_NAME KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET, A.ACTUAL ACTUAL, A.SCORE SCORE from KPI_TEMPLATE A, EMPLOYEE_SETUP b, GROUP_DEPTAL_KPI c where A.KPI=C.ID AND  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='brand' and trim(lower(B.USERNAME))='" + userSession + "'";
                //string sql = "select A.ID ID, A.KPI_DIMENSION KPI_NAME, A.kpi_type KPI_TYPE, A.weight WEIGHT, A.PERIOD_TARGET TARGET from KPI_TEMPLATE A, EMPLOYEE_SETUP b where  A.POSITION_ID=B.POSITION_OR_JOBROLE and trim(lower(A.KPI_DIMENSION ))='brand' and trim(lower(B.USERNAME))='" + userSession + "'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getbrandList












        ///////////////////////Behavioural Competencies starts now//////////////////////////////
        public static DataTable getBCPhaseTwoList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "select KPI_DIMENSION, WEIGHT from BC_GOAL_SETTINGS_SETUP";
                //order by a.KPI_DIMENSION
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.Add("v_user_session", userSession.Trim());

                OracleDataAdapter adapter = new OracleDataAdapter(cmd);

                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//getBCPhaseTwoList
                
        public static DataTable getProfList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='professionalism'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getProfList
        public static DataTable getCommList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='communication'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCommList
        public static DataTable getTeamList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='teamwork'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getTeamList
        public static DataTable getCustList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='customer centricity'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCustList
        public static DataTable getInnoList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='innovation'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getInnoList
        public static DataTable getLeadList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='leadership'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getLeadList
        public static DataTable getPEffectAcctList()
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql ="select a.id, a.KPI_DIMENSION, a.KPI_DIMENSION_DETAILS, b.ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='personal effectiveness & accountability' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='2013107' and B.APPRAISAL_PERIOD=" + 2014003 + "";
                string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='personal effectiveness & accountability'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPEffectAcctList
        public static DataTable getProfViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();

                //string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='professionalism'";
  string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='professionalism' and B.EMPLOYEE_NO='"+employeeNo+"' and B.APPRAISAL_PERIOD="+appraisalPeriod+"";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getProfList
        public static DataTable getCommViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='communication'";
                string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='communication' and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + appraisalPeriod + "";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCommList
        public static DataTable getTeamViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='teamwork'";
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='teamwork'";
                string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='teamwork' and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + appraisalPeriod + "";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getTeamList
        public static DataTable getCustViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='customer centricity'";
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='customer centricity'";
                string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='customer centricity' and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + appraisalPeriod + "";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCustList
        public static DataTable getInnoViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='innovation'";
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='innovation'";
                string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='innovation' and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + appraisalPeriod + "";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getInnoList
        public static DataTable getLeadViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='leadership'";
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='leadership'";
                string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='leadership' and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + appraisalPeriod + "";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getLeadList
        public static DataTable getPEffectAcctViewList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='personal effectiveness & accountability'";
                //sql ="select a.id, a.KPI_DIMENSION, a.KPI_DIMENSION_DETAILS, b.ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='personal effectiveness & accountability' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='2013107' and B.APPRAISAL_PERIOD=" + 2014003 + "";
                string sql = "select b.id id, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where A.ID=B.BC_KPI_DIMENSION_ID and lower(a.kpi_dimension)='personal effectiveness & accountability' and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + appraisalPeriod + "";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPEffectAcctList








        public static DataTable getProfList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                //string countSubordinate = getPositionsCount(username);
                string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate == "1")
                {
                    sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='professionalism' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
                }
                else if (countSubordinate == "0")
                {
                    sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='professionalism'";
                }
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='professionalism'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getProfList
        public static DataTable getCommList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                //string countSubordinate = getPositionsCount(username);
                string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate == "1")
                {
                    sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='communication' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
                }
                else if (countSubordinate == "0")
                {
                    sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='communication'";
                }
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='communication'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCommList
        public static DataTable getTeamList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                //credit_card_perm
                string sql = "";
                //string countSubordinate = getPositionsCount(username);
                string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate == "1")
                {
                    sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='teamwork' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
                }
                else if (countSubordinate == "0")
                {
                    sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='teamwork'";
                }
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='teamwork'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getTeamList
        public static DataTable getCustList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                //string countSubordinate = getPositionsCount(username);
                string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate == "1")
                {
                    sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='customer centricity' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
                }
                else if (countSubordinate == "0")
                {
                    sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='customer centricity'";
                }
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='customer centricity'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getCustList
        public static DataTable getInnoList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                //string countSubordinate = getPositionsCount(username);
                string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate == "1")
                {
                    sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='innovation' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
                }
                else if (countSubordinate == "0")
                {
                    sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='innovation'";
                }
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='innovation'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getInnoList
        public static DataTable getLeadList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                //string countSubordinate = getPositionsCount(username);
                string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
                if (countSubordinate == "1")
                {
                    sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='leadership' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
                }
                else if (countSubordinate == "0")
                {
                    sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='leadership'";
                }
                           //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='leadership'";
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getLeadList
        public static DataTable getPEffectAcctList(string username, string employeeNo, string appraisalPeriod)
        {
            using (OracleConnection con = new OracleConnection())
            {
                con.ConnectionString = Dalcs.PMSConnectionString;

                con.Open();
                string sql = "";
                //credit_card_perm
                //string employeeNo, string appraisalPeriod, string employeeName
                //string sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='personal effectiveness & accountability'";

                
        //string countSubordinate = getPositionsCount(username);
        string countSubordinate = getEmpNoAppPeriodCount(employeeNo, appraisalPeriod);
        if (countSubordinate == "1")
        {
            sql = "select a.id id, a.KPI_DIMENSION KPI_DIMENSION, a.KPI_DIMENSION_DETAILS KPI_DIMENSION_DETAILS, b.ACTION_PLANS ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='personal effectiveness & accountability' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='" + employeeNo + "' and B.APPRAISAL_PERIOD=" + Convert.ToInt32(appraisalPeriod) + "";
        }
        else if (countSubordinate == "0")
        {
            sql = "select id, KPI_DIMENSION, KPI_DIMENSION_DETAILS, ACTION_PLANS  from BC_GOAL_SETTINGS_SETUP where lower(kpi_dimension)='personal effectiveness & accountability'";
        }
                
                
                
                //sql ="select a.id, a.KPI_DIMENSION, a.KPI_DIMENSION_DETAILS, b.ACTION_PLANS from BC_GOAL_SETTINGS_SETUP a, BC_DIM_DETAILS b where lower(a.kpi_dimension)='personal effectiveness & accountability' and a.id=b.BC_KPI_DIMENSION_ID and B.EMPLOYEE_NO='2013107' and B.APPRAISAL_PERIOD=" + 2014003 + "";
                
                OracleCommand cmd = new OracleCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                con.Close();
                return table;
            }
        }//end getPEffectAcctList
        ////////////////////////////End Behavioural Competencies/////////////////////////////////////


        

    }
}