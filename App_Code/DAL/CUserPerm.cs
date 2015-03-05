using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Collections.Generic;
using System.Text;

/// <summary>
/// Summary description for CUserPerm
/// </summary>
public class CUserPerm
{
    //[Serializable]
    public CUserPerm()
	{
		//
		// TODO: Add constructor logic here
		//
        usr_mg = "";
        cust_mg = "";
        rpt_mg = "";
        mail_mg = "";

	}
    public string usr_mg { set; get; }
    public string cust_mg { set; get; }
    public string rpt_mg { set; get; }
    public string mail_mg { set; get; }
    //public string file_to_sent { set; get; }
}