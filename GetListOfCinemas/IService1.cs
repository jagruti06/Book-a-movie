using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace GetListOfCinemas
{
    public interface IService1
    {
        [OperationContract]
        List<string> TheatreList(string zip, string name);
    }
}
