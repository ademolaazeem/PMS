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
using DAL;

namespace BLL
{
    /// <summary>
    /// Summary description for testDal
    /// </summary>
    public class testBLL
    {
        //public testDal()
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //}
        public static DataTable GetByUsername()
        {
            return testDal.GetByUsername();
        }
    }
}