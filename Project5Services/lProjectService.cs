using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Project5Services
{
    [ServiceContract]
    public interface lProjectService
    {
        /*string Sender, 
                string MovieName, 
                string Receiver, 
                string Subject, 
                string DateTime*/
        [OperationContract]
        string sendMail(string to, string details);
    }

}
