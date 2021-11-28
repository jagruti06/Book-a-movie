using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;

namespace LoginServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string addUser(string username, string password, string userType)
        {
            try
            {
                string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Member.xml";
                if (userType == "Staff")
                    filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";
                else if(userType == "TryIt")
                    filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\TryIt.xml";

                XmlDocument myDoc = new XmlDocument();
                myDoc.Load(filepath); // open file
                XmlElement rootElement = myDoc.DocumentElement;

                XmlElement myMember = myDoc.CreateElement("UserDetails", rootElement.NamespaceURI);
                rootElement.AppendChild(myMember);
                XmlElement myUser = myDoc.CreateElement("username",
                rootElement.NamespaceURI);
                myMember.AppendChild(myUser);
                myUser.InnerText = username;
                XmlElement myPwd = myDoc.CreateElement("password",
                rootElement.NamespaceURI);
                myMember.AppendChild(myPwd);
                myPwd.InnerText = password;
                myDoc.Save(filepath);

                return "true";
            }
            catch (Exception ex)
            {

                Console.WriteLine("Exception occured: ",ex.Message);
            }
            return "false";
        }
        public string[] searchUser(string username, string password, string userType)
        {
            string filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Member.xml";
            if(userType == "Staff")
                filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\Staff.xml";
            else if (userType == "TryIt")
                filepath = HttpRuntime.AppDomainAppPath + @"\App_Data\TryIt.xml";

            XmlDocument myDoc = new XmlDocument();
            myDoc.Load(filepath); // open file
            XmlNodeList nodes = myDoc.DocumentElement.SelectNodes("/Users/UserDetails");
            //XmlElement rootElement = myDoc.DocumentElement;
            foreach (XmlNode node in nodes)
            {
                if (node["username"].InnerText == username && node["password"].InnerText == password)
                {
                    return new string[] {username, password};
                }
            }
            
            return null;
        }
    }
}
