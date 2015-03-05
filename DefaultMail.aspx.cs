using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Net.Mail;
using System.Net;
using System.Net.Mime;


public partial class DefaultMail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            MailMessage mailMessage = new MailMessage();
            mailMessage.IsBodyHtml = true;
            //
            // mailMessage.To.Add("princedotexe@yahoo.com");
            //mailMessage.To.Add("anthony.orgah@unifiedpaymentsnigeria.com");
            mailMessage.To.Add("lukman.arogundade@unifiedpaymentsnigeria.com");

            mailMessage.From = new MailAddress("anthony.orgah@unifiedpaymentsnigeria.com");
            mailMessage.Subject = "ASP.NET e-mail test";
            mailMessage.Body = "Hello world,\n\nThis is an ASP.NET test e-mail!";

            //Attach file using FileUpload Control and put the file in memory stream
            //if (FileUpload1.HasFile)
            //{
            //    mailMessage.Attachments.Add(new Attachment(FileUpload1.PostedFile.InputStream, FileUpload1.FileName));
            //}
            SmtpClient smtpClient = new SmtpClient("172.19.2.208", 25);


            smtpClient.Credentials = new NetworkCredential("selfservice@local.vcndc.com", "User2012");

            smtpClient.Send(mailMessage);
            Label1.Text = "MAIL SENT";
        }
        catch ( Exception ex)
        {
            Label1.Text = "Error: "+ex.Message;
        }

    }
}