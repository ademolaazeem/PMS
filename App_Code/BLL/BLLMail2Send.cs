using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLMail2Send
/// </summary>
public class BLLMail2Send
{
    public static string sendMail2SubordinateForBCApproval(string to, string subName, string supSenderName)
    {
        return Mails2Send.sendMail2SubordinateForBCApproval(to, subName, supSenderName);

    }//sendMail2SubordinateForBCApproval

   public static string sendMail2SubordinateForBC(string to, string subName, string supSenderName)
   {
       return Mails2Send.sendMail2SubordinateForBC(to, subName, supSenderName);
    
   }//sendMail2SubordinateForBC
    public static string sendMail2SupervisorForBC(string to, string supName, string senderName)
    {
        return Mails2Send.sendMail2SupervisorForBC(to, supName, senderName);
    }
    
   


    
    
    public static string sendMail2Subordinate4BCAppForm(string  to, string supName, string subName)
    {
        return Mails2Send.sendMail2Subordinate4BCAppForm(to, supName, subName);
    }

    public static string sendMail2Subordinate4Summary(string to, string supName, string subName)
    {
        return Mails2Send.sendMail2Subordinate4BCAppForm(to, supName, subName);
    }//sendMail2Subordinate4Summary



    public static string sendMail2Sup4BCAppForm(string to, string supName, string subName)
    {
        return Mails2Send.sendMail2Sup4BCAppForm(to, supName, subName);
    }
    
    public static string sendMail2Sup4AppSummary(string to, string supName, string subName)
    {
        return Mails2Send.sendMail2Sup4AppSummary(to, supName, subName);
    }//

    public static string sendMail2Sub4ccAppSummary(string to, string subName, string supName, string concSign)
    {
        return Mails2Send.sendMail2Sub4ccAppSummary(to, subName, supName, concSign);
        //return Mails2Send.sendMail2Sup4AppSummary(to, supName, subName);
    }//

    public static string sendMail2HRForKPITemplate(string senderName)
    {
        return Mails2Send.sendMail2HRForKPITemplate(senderName);
    }
}