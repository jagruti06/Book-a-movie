using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Mail;


namespace Project5Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : lProjectService
    {
        public string sendMail(string to, string details)
        {

            //read email and password from web config
            string from = GmailCredentials.getUsername();
            string password = GmailCredentials.getPassword();

            //form mail body 
            MailMessage message = new MailMessage(from, to);
            message.Subject = "You have received a movie invite";
            message.Body = @"" + details;

            //create smtp client
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            // the server will authenticate before it will send email on the application's behalf.
            client.Credentials =
                new System.Net.NetworkCredential(from, password);
            client.EnableSsl = true;

            try
            {
                client.Send(message);
                Console.WriteLine("Message sent");
                return "Invite sent to " + to;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
                    ex.ToString());
            }

            return "Failed to send invite";
        }
    }
}
