using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for LoadingControlPath
/// </summary>
/// 
  //public class BaseMaster
public class LoadingControlPath:System.Web.UI.MasterPage
   // public class BaseMaster:System.Web.UI.MasterPage
{
    public const string BASE_PATH = "";// "~/DynamicControlLoading/";
    public string controlPath;//= string.Empty;
    public Label lblPageTtile;
    ContentPlaceHolder mpContentPlaceHolder;
       
	public LoadingControlPath()
	{
        lblPageTtile = (Label)this.FindControl("lblPageTtile");
        //lblPageTitle = (Label)Master.FindControl("lblPageTtile");
        

	}

    
    public void LoadUserControl()
    {
        //ContentPlaceHolder mpContentPlaceHolder = new ContentPlaceHolder();
        //mpContentPlaceHolder = (ContentPlaceHolder)this.FindControl("ContentPlaceHolder1");
        //mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");

        mpContentPlaceHolder = (ContentPlaceHolder)this.FindControl("ContentPlaceHolder1");
        controlPath = LastLoadedControl;
        if (!string.IsNullOrEmpty(controlPath))
        {
            if (mpContentPlaceHolder != null)
            {
                //mpContentPlaceHolder = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
                // ContentPlaceHolder1.Controls.Clear();
                //mpContentPlaceHolder.Controls.Count
                mpContentPlaceHolder.Controls.Clear();
                UserControl uc = (UserControl)LoadControl(controlPath);
                //ContentPlaceHolder1.Controls.Add(uc);
                mpContentPlaceHolder.Controls.Add(uc);
                //Session["mpCPH"] = mpContentPlaceHolder.Controls.Add(uc);
            }
            
        }
        return;
    }//end LoadUserControl


    public string LastLoadedControl
    {
        get
        {
            return ViewState["LastLoaded"] as string;
        }
        set
        {
            ViewState["LastLoaded"] = value;
        }

       
    }//end LastLoadedControl

    //public void MyLabel()
    //{
    //    lblPageTitle = (Label)Master.FindControl("lblPageTtile");
    //    return;
    
    
    //}



}