//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IdentityModel.Selectors;
using System.ServiceModel.Description;
using System.ServiceModel;
using System.IO;

namespace Microsoft.ServiceModel.Samples.CustomToken
{
    /// <summary>
    /// UsernameClientCredentials for use with Username Token
    /// </summary>
    public class UsernameClientCredentials : ClientCredentials
    {
        UsernameInfo _usernameInfo;

        public UsernameClientCredentials()
        {
            this._usernameInfo = new UsernameInfo("User1", "P@ssw0rd");
        }

        public UsernameClientCredentials(UsernameInfo usernameInfo)
            : base()
        {
            if (usernameInfo == null)
                throw new ArgumentNullException("usernameInfo");

            _usernameInfo = usernameInfo;
        }

        public UsernameInfo UsernameInfo
        {
            get { return _usernameInfo; }
        }
        
        protected override ClientCredentials CloneCore()
        {
            return new UsernameClientCredentials(_usernameInfo);
        }

        public override SecurityTokenManager CreateSecurityTokenManager()
        {
            this._usernameInfo = new UsernameInfo(this.UserName.UserName, this.UserName.Password);
            return new UsernameClientCredentialsSecurityTokenManager(this);
        }

    }
}
