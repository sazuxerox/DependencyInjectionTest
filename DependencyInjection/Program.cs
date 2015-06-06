//This code is written to learn the dependency injection from the book: Mastering Ninject for dependency injection by Daniel Baharestani
//Simple Dependency Injection test program 


using System.Net.Mail;
using Ninject;

namespace DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var kernel =  new StandardKernel())
            {
                kernel.Bind<ILogger>().To<ConsoleLogger>();
                var mailservice = kernel.Get<MailService>();
                mailservice.SendMail("someone@domain.com", "Hi", "Hello World!");
            }
            
        }
    }
}
