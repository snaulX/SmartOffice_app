using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartOfficeApp
{
    public static class Client
    {
        private const string HostIp = "https://127.0.0.1:5000/";
        private static HttpClient client;

        static Client()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, c, chain, errors) => true;
            client = new HttpClient();
            client.BaseAddress = new Uri(HostIp);
            Console.WriteLine(client.BaseAddress.ToString());
        }

        public static async Task<string> Request(string address)
        {
            return await client.GetStringAsync(address);
        }
    }
}
