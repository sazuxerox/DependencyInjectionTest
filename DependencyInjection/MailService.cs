//This code is written to learn the dependency injection from the book: Mastering Ninject for dependency injection by Daniel Baharestani
//Simple Dependency Injection test program 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInjection
{
    class MailService
    {
     
        private  ILogger _logger;
        private SmtpClient client;
        private string sender;
        public MailService(MailServerConfig config, ILogger logger)
        {
            _logger = logger;
            InitializeClient(config);
            sender = config.SenderEmail;
        }

      
        public void SendMail( string address, string subject, string body)
        {
            _logger.Log("initializing........");
            var mail = new MailMessage(sender, address);
            mail.To.Add(address);
            mail.Subject = subject;
            mail.Body = body;
          

            _logger.Log("Sending Message..");
            //setup client with smtp address and port here
            client.Send(mail);
            _logger.Log("Message sent successfully");
        }

        private void InitializeClient(MailServerConfig config)
        {
            client = new SmtpClient();
            client.Host = config.SmtpServer;
            client.Port = config.SmtpPort;
            client.EnableSsl = true;
            var credentials = new NetworkCredential();
            credentials.UserName = config.SenderEmail;
            credentials.Password = config.SenderPassword;
            client.Credentials = credentials;
        }

       
    }


}
