//using System.Security.Principal.IPrincipal;
//using System.Web
//System.Web.Profile
//
//
using System.Configuration;
//
//
//
namespace DAL
{
/// <summary>
/// Summary description for Dalcs
/// </summary>
public class Dalcs
{
	///public Dalcs()
	//{
		//
		// TODO: Add constructor logic here
		//
	//}
    public static string PMSConnectionString
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["PMSConnectionString"].ConnectionString;
        }
    }

   
    public static string ApplicationURL
    {
        get
        {
            return ConfigurationManager.AppSettings["ApplicationURL"];
        }
    }

    public static string hm42ConnectionString 
    {
        get
        {
            return ConfigurationManager.ConnectionStrings["hm42ConnectionString"].ConnectionString;
        }    
    }
}
}