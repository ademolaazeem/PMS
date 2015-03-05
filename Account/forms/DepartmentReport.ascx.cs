using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using BLL;
//

public partial class Account_forms_DepartmentReport : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        refreshDepartmentDropDown();
    }
    private void refreshDepartmentDropDown()
    {
        DDLDepartments.DataSource = crudsbLL.getDepartments();
        DDLDepartments.DataTextField = "name";
        DDLDepartments.DataValueField = "name";
        DDLDepartments.DataBind();
        DDLDepartments.Items.Insert(0, new ListItem("Select Department", ""));
    }//end refreshDepartmentDropDown
    
    protected void btnShowReport_Click(object sender, EventArgs e)
    {
        ConnectionInfo ConnInfo = new ConnectionInfo();
        var _with1 = ConnInfo;

        _with1.ServerName = "orcl";

        _with1.DatabaseName = "cdl_appraisal";

        _with1.UserID = "cdl_appraisal";

        _with1.Password = "cdl_appraisal";

        //
        CRptViewer.ParameterFieldInfo.Clear();

        if (DDLDepartments.SelectedIndex >= 0)
        {
            // Me.drpcustname.SelectedIndex > -1 Then

            //~/Account/forms/alertReport.ascx
            CRptViewer.ReportSource = Server.MapPath("~/Account/Report/DepartmentReport.rpt");
            //consult2.rpt

            ParameterFields ParamFields = CRptViewer.ParameterFieldInfo;

            ParameterField p_OrderDateRange = new ParameterField();

            // p_OrderDateRange.Name = "p_date"
            //p_OrderDateRange.Name = "p_diffdate";
            //p_link
            //p_datefiff

            // ParameterRangeValue p_OrderDateRange_Value = new ParameterRangeValue();

            //p_OrderDateRange_Value.StartValue = this.txtStartDate.Text;

            //p_OrderDateRange_Value.EndValue = this.txtEndDate.Text;

            //p_OrderDateRange.CurrentValues.Add(p_OrderDateRange_Value);
            ///'''''''''''''''''''''''''''''''''''''''''''
            // p_EmpID.Name = "p_lnkacc"
            //p_link
            //p_EmpID_Value.Value = Me.drpcustname.SelectedValue
            
            
            
            
            
            ParameterField p_EmpID = new ParameterField();

            p_EmpID.Name = "Department Name";
            

            ParameterDiscreteValue p_EmpID_Value = new ParameterDiscreteValue();

            
            p_EmpID_Value.Value = this.DDLDepartments.SelectedValue;

            p_EmpID.CurrentValues.Add(p_EmpID_Value);

            ParamFields.Add(p_EmpID);
            
            ///'''''''''''''''''''''''''''''''''''''''''''

            //ParamFields.Add(p_OrderDateRange);

            // Label5.Text = this.drpcustname.SelectedValue;

            //Else

            //   Me.CrystalReportViewer1.ReportSource = Server.MapPath("SampleRpt01.rpt")

        }




        foreach (TableLogOnInfo cnInfo in CRptViewer.LogOnInfo)
        {
            cnInfo.ConnectionInfo = ConnInfo;

        }

        CRptViewer.RefreshReport();
        //

    }
  
}