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
//using DAL.Dalcs;


namespace DAL
{


    /// <summary>
    /// Summary description for userAuditDal
    /// </summary>
    public class userAuditDal
    {
        //public userAuditDal()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}

        public static int Add_Permission(string username, string action_performed, string createdby)
        {
            int retVal =0;
            try
            {
                OracleConnection conn = new OracleConnection();


                conn.ConnectionString = Dalcs.PMSConnectionString;

                OracleCommand cmd = new OracleCommand();

                cmd.Connection = conn;
                //
                //set stored procedure
                cmd.CommandText = "pkg_acc_bill_ops.add_user_permission";
                // refNo = refNo.Trim();
                cmd.CommandType = CommandType.StoredProcedure;
                // OracleDbType.Varchar2
                cmd.Parameters.Add("p_username", OracleDbType.Varchar2, 100).Value = username;
                cmd.Parameters.Add("p_action_performed", OracleDbType.Varchar2, 500).Value = action_performed;
                cmd.Parameters.Add("p_createdby", OracleDbType.Varchar2, 100).Value = createdby;
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
            }

        }
    }
}