using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace UsernameService
{
    // NOTE: If you change the interface name "IUsernamePasswordService" here, you must also update the reference to "IUsernamePasswordService" in App.config.
    [ServiceContract]
    public interface IUsernamePasswordService
    {
        [OperationContract]
        string EchoString(string s);
    }
}
