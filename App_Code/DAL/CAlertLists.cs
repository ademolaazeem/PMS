using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CAlertLists
/// </summary>
[Serializable]
public class CAlertLists
{
    public CAlertLists()
    {
        //
        MIN_PAYMENT = "";
        GRACE_PERIOD = "";
        LATE_PAYMENT = "";
        DPD_1 = "";
        DPD_7 = "";
        DPD_30 = "";
        DPD_60 = "";
        DPD_90 = "";
        BANKFIID = "";
        //
    }
    //
    public string MIN_PAYMENT { set; get; }
    public string GRACE_PERIOD { set; get; }
    public string LATE_PAYMENT { set; get; }
    public string DPD_1 { set; get; }
    public string DPD_7 { set; get; }
    public string DPD_30 { set; get; }
    public string DPD_60 { set; get; }
    public string DPD_90 { set; get; }
    public string BANKFIID { set; get; }
}