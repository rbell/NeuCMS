using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Xml;
using NeuCMS.Platforms.MVC3.ContentService;

namespace NeuCMS.Platforms.MVC3
{
    internal static class ServiceClientFactory
    {
        internal static ContentServiceClient CreateClient()
        {
            var binding = new BasicHttpBinding();
            binding.CloseTimeout = TimeSpan.FromMinutes(1);
            binding.OpenTimeout = TimeSpan.FromMinutes(1);
            binding.ReceiveTimeout = TimeSpan.FromMinutes(10);
            binding.SendTimeout = TimeSpan.FromMinutes(1);
            binding.AllowCookies = false;
            binding.BypassProxyOnLocal = false;
            binding.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            binding.MaxBufferSize = 65536;
            binding.MaxBufferPoolSize = 524288;
            binding.MaxReceivedMessageSize = 65536;
            binding.MessageEncoding = WSMessageEncoding.Text;
            binding.TextEncoding = System.Text.Encoding.UTF8;
            binding.TransferMode = TransferMode.Buffered;
            binding.UseDefaultWebProxy = true;
            binding.ReaderQuotas = new XmlDictionaryReaderQuotas()
                                       {
                                           MaxDepth = 32,
                                           MaxStringContentLength = 8192,
                                           MaxArrayLength = 16384,
                                           MaxBytesPerRead = 4096,
                                           MaxNameTableCharCount = 16384
                                       };
            binding.Security = new BasicHttpSecurity()
                                   {
                                       Mode = BasicHttpSecurityMode.None,
                                       Transport = new HttpTransportSecurity()
                                                       {
                                                           ClientCredentialType = HttpClientCredentialType.None,
                                                           ProxyCredentialType = HttpProxyCredentialType.None,
                                                           Realm = string.Empty
                                                       }
                                   };

            var serviceURL = System.Configuration.ConfigurationManager.AppSettings["NeuCMSServiceURL"] as string;
            var endPoint = new EndpointAddress(serviceURL);
            var client = new ContentServiceClient(binding, endPoint);
            return client;
        }
    }
}