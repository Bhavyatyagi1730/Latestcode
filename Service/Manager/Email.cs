using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;

namespace Service.Class
{
    public class Email : IEmail
    {
       
        public void SendEmail(string to, string subject, string body)
        {

            ////var body = $"Dear <br /><br />Welcome to My HelpDesk System!<br /><br />Thank you for Creating a Ticket.";
            //var message = new MailMessage("abhishek.gautam@credextechnology.com", to, subject, body);
            //_smtpClient.Send(message);


            string smtpServer = "smtp.gmail.com";
            string smtpUsername = "abhishek.gautam@credextechnology.com";
            string smtpPassword = "CRedex@1234";
            int smtpPort = 587;

            SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);

            MailMessage message = new MailMessage("abhishek.gautam@credextechnology.com", "abhigautam.5678@gmail.com");
            //message.To.Add(to);
            message.Subject = subject;
            message.Body = body;

            smtpClient.Send(message);



        }
    }
}

