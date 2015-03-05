using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Net.Mail;

/// <summary>
/// Summary description for Mails2Send
/// </summary>
public class Mails2Send
{
    public static string from = "staffappraisal@cdlnigeria.com";
    public static string bcc = "diamonddemola@yahoo.co.uk";
    //public static string cc = "tbabayi@cdlnigeria.com";
    public static string cc = "";
	public Mails2Send()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    public static string sendMail2SubordinateForBCApproval(string to, string subName, string supSenderName)
    {
        //emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody

        //string from = "no-reply@cdlnigeria.com";
        //string to = "fogunyemi@cdlnigeria.com";
        // LblName.Text
        string subject = "CDL Staff Appraisal: Goal Settings for Behavioural Competencies";
        string body = "Dear <i>" + subName + "</i>,<br/> Congratulations! This is to inform you that your supervisor: <i>" + supSenderName + "</> has approved your goal settings for both Performance Results and Behavioural Competencies for this appraisal period. We wish you healthy life to be able to exceed your expectations.<br/><br/> Best Regards <br/><br/>Performance System Team.";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }//sendMail2SubordinateForBCApproval
    public static string sendMail2SubordinateForBC(string to, string subName, string supSenderName)
    {
        //emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody

        //string from = "no-reply@cdlnigeria.com";
        //string to = "fogunyemi@cdlnigeria.com";
        // LblName.Text
        string subject = "CDL Staff Appraisal: Goal Settings for Behavioural Competencies";
        string body = "Dear <i>" + subName + "</i>,<br/> This is to inform you that your supervisor: <i>" + supSenderName + "</> want you to review the goals set in the behavioural competencies for this appraisal period. please contact him and make necessary ammendments.<br/><br/> Best Regards <br/><br/>Performance System Team.";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }//sendMail2SupervisorForBC

    public static string sendMail2SupervisorForBC(string to, string supName, string senderName)
    { 
                //emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody
                
                //string from = "no-reply@cdlnigeria.com";
                //string to = "fogunyemi@cdlnigeria.com";
                 // LblName.Text
                string subject = "CDL Staff Appraisal: Goal Settings for Behavioural Competencies";
                string body = "Dear "+supName+",<br/> This is to inform you that one of your subordinates:" + senderName + " has completed his behavioural competencies goal settings. Your input is needed.<br/><br/> Best Regards";
                string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
                return bcGSSendMail;
    
    }//sendMail2SupervisorForBC

    public static string sendMail2Subordinate4BCAppForm(string to, string supName, string subName)
    {
        string subject = "CDL Staff Appraisal: Appraisal Form for Behavioural Competencies";
        string body = "Dear " + subName + ",<br/> This is to inform you that one of your supervisor:" + supName + " has completed your Appraisal form rating, kindly login into the system and rate yourself too, if you have done so, kindly review the rating for management review.<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }

    public static string sendMail2Subordinate4Summary(string to, string supName, string subName)
    {
        string subject = "CDL Staff Appraisal: Appraisal Summary Supervisor Rating";
        string body = "Dear " + subName + ",<br/> This is to inform you that one of your supervisor:" + supName + " has completed your Appraisal Summary rating, kindly login into the system and complete your part of the summary, if you have done so, You will be notified when the Concurrent staff signs.<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }

    public static string sendMail2Sup4BCAppForm(string to, string supName, string subName)
    {
        string subject = "CDL Staff Appraisal: Appraisal Form for Behavioural Competencies";
        string body = "Dear " + supName + ",<br/> This is to inform you that one of your subordinate:" + subName + " has completed his Appraisal form rating, kindly login into the system in order to rate the subordinate accordingly, if you have done so, you may discard this mail.<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }

    public static string sendMail2Sup4AppSummary(string to, string supName, string subName)
    {
        string subject = "CDL Staff Appraisal: Appraisal Job Holder Appraisal Summary!";
        string body = "Dear " + supName + ",<br/> This is to inform you that one of your subordinate:" + subName + " has completed his Appraisal Summary rating, kindly login into the system in order to help complete the rating of the subordinate accordingly, if you have done so, you may discard this mail.<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }//

    public static string sendMail2Sub4ccAppSummary(string to, string subName, string supName, string concSign)
    {
        string subject = "CDL Staff Appraisal: Appraisal Appraisal Summary Concurrent Signature by "+concSign+"!";
        string body = "Dear " + subName + ",<br/> This is to inform you that Mr: "+concSign+ " has concurrently sign for your Appraisal Summary supervised by " + supName + " kindly login into the system in order to confirm the signature accordingly, if you have done so, you may discard this mail.<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }//


    public static string sendMail2Sup4CCAppSummary(string to, string supName, string subName)
    {
        string subject = "CDL Staff Appraisal: Appraisal Concurrently Sign Appraisal Summary!";
        string body = "Dear " + subName + ",<br/> This is to inform you that your appraisal summary has been successfully concurrently signed" + 
            "<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }//



    public static string sendMail2HRForKPITemplate(string senderName)
    {
        string to = "hr&admin@cdlnigeria.com";
        string subject = "CDL Staff Appraisal: KPI Template Setup";
        string body = "Dear HR,<br/> This is to inform you KPI Template has not been set for employee: " + senderName + ". This would not allow him to set Goal settings for the appraisal period. Kindly help setup KPI Template for his position by clicking on: <strong><i>Appraisal Management->Manage KPI Template.</i></strong>. on Performance Management and Appraisal System.<br/><br/> Best Regards";
        string bcGSSendMail = SendMail(from, to, bcc, cc, subject, body);
        return bcGSSendMail;

    }//sendMail2SupervisorForBC


    //////////////////////////////Email Module//////////////////////////////////////////////////

    public static string SendMail(string emailFrom, string emailTo, string emailBcc, string emailCc, string emailSubject, string emailBody)
    {
        //MailMessage msg = new MailMessage();
        //msg.To = to;
        //msg.From = from;
        //msg.Subject = subject;
        //msg.Body = emailBody;

        ////lblStatus.Text = "Sending...";
        //SmtpMail.SmtpServer = "192.168.0.21";
        //SmtpMail.Send(msg);
        ////lblStatus.Text = "Sent email (" + txtSubject.Text + ") to " + txtTo.Text;
        string displayName = "CDL Performance Management & Appraisal System";

        MailMessage mMailMessage = new MailMessage();

        // address of sender
        mMailMessage.From = new MailAddress(emailFrom, displayName);
        // recipient address

        string[] multiTo = emailTo.Split(',');
        foreach(string multiEmailTo in multiTo)
        {
            mMailMessage.To.Add(new MailAddress(emailTo));
        }

        //mMailMessage.To.Add(new MailAddress(emailTo));
        
        
        // Check if the bcc value is empty
        if (emailBcc != string.Empty)
        {
            // Set the Bcc address of the mail message
            //mMailMessage.Bcc.Add(new MailAddress(emailBcc));

            string[] multiBcc = emailBcc.Split(',');
            foreach (string multiEmailBcc in multiBcc)
            {
                mMailMessage.Bcc.Add(new MailAddress(emailBcc));
            }
        }

        // Check if the cc value is empty
        if (emailCc != string.Empty)
        {
            // Set the CC address of the mail message
            //mMailMessage.CC.Add(new MailAddress(emailCc));

            string[] multiCc = emailCc.Split(',');
            foreach (string multiEmailCc in multiCc)
            {
                mMailMessage.CC.Add(new MailAddress(emailCc));
            }
        }     // Set the subject of the mail message
        mMailMessage.Subject = emailSubject;
        // Set the body of the mail message
        mMailMessage.Body = emailBody;
        // Set the format of the mail message body as HTML
        mMailMessage.IsBodyHtml = true;
        // Set the priority of the mail message to normal
        mMailMessage.Priority = MailPriority.Normal;

        // Instantiate a new instance of SmtpClient
        SmtpClient mSmtpClient = new SmtpClient();
        // Send the mail message
        try
        {
            mSmtpClient.Send(mMailMessage);
            string emailStatus = "Sent";
            string emailSent=crudsbLL.addSentEmails(emailFrom, emailTo, emailBcc, emailCc, emailSubject, emailBody, emailStatus);
            return "Sent";
        }
        catch (Exception ex)
        {
            
            string emailStatus = ex.Message;
            string emailSent = crudsbLL.addSentEmails(emailFrom, emailTo, emailBcc, emailCc, emailSubject, emailBody, emailStatus);
            return "Send Mail Error: " + ex.Message;
            //;//log error
            //lblMessage.Text = ex.Message;
        }
        finally
        {
            mMailMessage.Dispose();
        }

    }

    ////////////////////////////End Email Module/////////////////////////////////////////////////



    
}