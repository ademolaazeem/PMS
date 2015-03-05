using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

public partial class Account_forms_KPISupervisorIntface : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String username = Session["usr"].ToString();

        int retLog = crudsbLL.saveAuditLog(username, Request.UserHostAddress, "KPI Supervisor Interface: User " + username + " successfully views KPI Supervisor Interface");


    }
}