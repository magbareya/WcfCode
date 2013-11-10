using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;

namespace ClearUsernameWcfService
{
    class UsernameTokenValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (userName.Equals("Mahmoud") && password.Equals("1234"))
                return;
            throw new SecurityTokenException("Unkown username or password");
        }
    }
}
