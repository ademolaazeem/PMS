using System;
using System.Web;
using System.Web.Security;
using System.Security.Principal;

public class clsGlobal : System.Web.HttpApplication {
    
    protected void Application_AuthenticateRequest(object sender, EventArgs e) {
        if (HttpContext.Current.User != null) {
            if (HttpContext.Current.User.Identity.IsAuthenticated) {
                if (HttpContext.Current.User.Identity is FormsIdentity) {
                    FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
                    FormsAuthenticationTicket ticket = id.Ticket;
                    string userData = ticket.UserData;
                    int i = 1;
                    while (!((userData.Substring((userData.Length - i)).IndexOf("|") + 1) > 0)) {
                        i++;
                    }
                    string userDataFinal = userData.Substring((userData.Length - (i - 1)));
                    string[] roles = userDataFinal.Split(new Char[] {','});

					HttpContext.Current.User = new GenericPrincipal(id, roles);
                }
            }
        }
    }
}