using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

public partial class Account_forms_ContainerPositionRpt : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string dbUsername = "cdl_appraisal";
        string dbPassword = "cdl_appraisal"; 
        //string dbServerName = "orcl";
        //string dbDatabaseName = "cdl_appraisal";
       


        ReportDocument reportdocument = new ReportDocument();
        reportdocument.Load(Server.MapPath("~/Account/Report/PositionReport.rpt"));
        reportdocument.SetDatabaseLogon(dbUsername, dbPassword);
        //, dbServerName, dbDatabaseName
        CRptViewer.ReportSource = reportdocument;
        //reportdocument.Load(Server.MapPath("~/Report/PositionReport.rpt"));
        //reportdocument.SetDatabaseLogon("username", "password", "SureshDasari", "MySampleDB");
        //reportdocument.SetDatabaseLogon("cdl_appraisal", "cdl_appraisal", "orcl", "cdl_appraisal");
        


        //ConnectionInfo ConnInfo = new ConnectionInfo();
        //var _with1 = ConnInfo;
        //_with1.ServerName = "orcl";
        //_with1.DatabaseName = "cdl_appraisal";
        //_with1.UserID = "cdl_appraisal";
        //_with1.Password = "cdl_appraisal";
        ////
        //CRptViewer.ParameterFieldInfo.Clear();
        ////if (DDLDepartments.SelectedIndex >= 0)
        ////{
        ////CRptViewer.ReportSource = Server.MapPath("~/Account/Report/PositionReport.rpt");
        //CRptViewer.ReportSource = Server.MapPath("~/Account/Report/PositionReport.rpt");
        //ParameterFields ParamFields = CRptViewer.ParameterFieldInfo;
        //ParameterField p_OrderDateRange = new ParameterField();
        //ParameterField p_EmpID = new ParameterField();
        //p_EmpID.Name = "Position Name";
        //ParameterDiscreteValue p_EmpID_Value = new ParameterDiscreteValue();
        ////p_EmpID_Value.Value = this.DDLDepartments.SelectedValue;
        ////p_EmpID.CurrentValues.Add(p_EmpID_Value);
        //ParamFields.Add(p_EmpID);
        ////}
        //foreach (TableLogOnInfo cnInfo in CRptViewer.LogOnInfo)
        //{
        //    cnInfo.ConnectionInfo = ConnInfo;
        //}
        //CRptViewer.RefreshReport();
        ////
    }
    
}