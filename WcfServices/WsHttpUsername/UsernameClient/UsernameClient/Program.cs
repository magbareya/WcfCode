using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsernameClient
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new UsernameService.UsernamePasswordServiceClient())
            {
                client.ClientCredentials.UserName.UserName = "a";
                client.ClientCredentials.UserName.Password = "p";
                client.ClientCredentials.ServiceCertificate.Authentication.CertificateValidationMode = System.ServiceModel.Security.X509CertificateValidationMode.None;
                Console.WriteLine(client.EchoString("TEST"));
                Console.ReadLine();
                client.Close();
            }
        }
    }
}
