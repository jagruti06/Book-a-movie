using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project5Services
{
    public class GmailCredentials
    {

        private string username;
        private string password;

        public static string getUsername()
        {
             return System.Configuration.ConfigurationManager.AppSettings["emailId"];
        }

        public static string getPassword()
        {
            return System.Configuration.ConfigurationManager.AppSettings["password"];
        }

    }
}