//This code is written to learn the dependency injection from the book: Mastering Ninject for dependency injection by Daniel Baharestani
//Simple Dependency Injection test program 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class MailService
    {
     
        private readonly ILogger _logger;
        public MailService(ILogger logger)
        {
            _logger = logger;
        }
        public void SendMail(string from, string address, string subject, string body)
        {
            _logger.Log("Creating mail service.....");
            var mail = new MailMessage {From = new MailAddress(@from)};
            mail.To.Add(address);
            mail.Subject = subject;
            mail.Body = body;
            mail.Priority = MailPriority.High;

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false
            };


            _logger.Log("Sending Message..");
            //setup client with smtp address and port here
            client.Send(mail);
            _logger.Log("Message sent successfully");
        }

       
    }


}
