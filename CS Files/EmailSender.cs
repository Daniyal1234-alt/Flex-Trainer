using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Web;
namespace DB_Milestone_2
{
    class EmailSender
    {
        public void SendEmail(string memberName, string memberPass, string memberEmail)
        {
            string fromEmail = "fastflexerfitness@gmail.com";
            string fromPassword = "dqqu wcmu btiu wuvh";
            MailMessage m = new MailMessage();
            m.From = new MailAddress(fromEmail);
            m.Subject = "Welcome Member!";
            m.To.Add(new MailAddress(memberEmail));
            m.Body = "<html><body>Dear "+memberName+ ",<hr> Welcome to Flexer! We're excited to have you on board. <hr> Your account has been successfully created. Below are your login details:</p><ul><li><strong>Username:</strong> "+memberName+"</li><li><strong>Password:</strong> "+memberPass+"</li></ul><hr>Best regards,<hr>The Flexer Team <hr>Dani, Hussain, Hamza</body></html>";
            m.IsBodyHtml = true;
           
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromEmail, fromPassword),
                 EnableSsl = true,
            };
            smtpClient.Send(m);
        }
    }
}
