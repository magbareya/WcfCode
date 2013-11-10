using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.ServiceModel.Dispatcher;
using System.Security.Cryptography.X509Certificates;


namespace WeatherChannel
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ForacstService));
            LoadCertificate(host);
            host.Open();

            try
            {
                
                foreach (ChannelDispatcher cd in host.ChannelDispatchers)
                    foreach (EndpointDispatcher ed in cd.Endpoints)                                                
                        Console.WriteLine("Service listening at {0}", ed.EndpointAddress.Uri);

                

                Console.WriteLine("\nPress enter to exit...\n");
                Console.ReadLine();
            }
            finally
            {
                host.Close();
            }
        }

        private static void LoadCertificate(ServiceHost host)
        {
            X509Certificate2 serverCert = new X509Certificate2();
            serverCert.Import(@"Server Private.pfx", "wse2qs", X509KeyStorageFlags.DefaultKeySet);
            host.Credentials.ServiceCertificate.Certificate = serverCert;

            host.Credentials.IssuedTokenAuthentication.CertificateValidationMode = X509CertificateValidationMode.None;
            host.Credentials.IssuedTokenAuthentication.RevocationMode = X509RevocationMode.NoCheck;
            host.Credentials.IssuedTokenAuthentication.AllowUntrustedRsaIssuers = true;

            X509Certificate2 stsCert = new X509Certificate2();
            stsCert.Import(@"STS.cer");
            host.Credentials.IssuedTokenAuthentication.KnownCertificates.Add(stsCert);
        }
    }
}

