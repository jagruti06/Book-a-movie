using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace LoginServices
{
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string addUser(string username, string password, string userType);

        [OperationContract]
        string searchUser(string username, string password, string userType);

    }

}
