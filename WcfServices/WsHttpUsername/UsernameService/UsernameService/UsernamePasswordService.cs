using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.IdentityModel.Selectors;

namespace UsernameService
{
    // NOTE: If you change the class name "UsernamePasswordService" here, you must also update the reference to "UsernamePasswordService" in App.config.
    public class UsernamePasswordService : IUsernamePasswordService
    {
        #region IUsernamePasswordService Members

        public string EchoString(string s)
        {
            return string.Format("You entered: {0} !!!", s);
        }

        #endregion
    }

    public class UsernameValidator : UserNamePasswordValidator
    {

        public override void Validate(string userName, string password)
        {
            if (!(userName.Equals("a") && password.Equals("p")))
                throw new Exception("Wrong Username or password");
        }
    }
}
