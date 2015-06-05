//This code is written to learn the dependency injection from the book: Mastering Ninject for dependency injection by Daniel Baharestani
//Simple Dependency Injection test program 


using System.Net.Mail;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            var mailservice = new MailService(new EventLogger());
            mailservice.SendMail("abc@gmail.com","sazzadhossain@live.com", "My first DI app", "Hello World");
        }
    }
}
