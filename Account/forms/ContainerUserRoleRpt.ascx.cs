using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;

public partial class Account_forms_ContainerUserRoleRpt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dbUsername = "cdl_appraisal";
        string dbPassword = "cdl_appraisal";
        ReportDocument reportdocument = new ReportDocument();
        reportdocument.Load(Server.MapPath("~/Account/Report/UserRole.rpt"));
        reportdocument.SetDatabaseLogon(dbUsername, dbPassword);
        CRptViewer.ReportSource = reportdocument;
       
    }
}