using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartOfficeApp
{
    public static class Client
    {
        private const string HostIp = "http://127.0.0.1:5000/";
        private static readonly HttpClient client;

        static Client()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, c, chain, errors) => true;
            client = new HttpClient();
            client.BaseAddress = new Uri(HostIp);
        }

        public static async Task Post(string address, string content)
        {
            await client.PostAsync(address, new StringContent(content));
        }

        public static async Task<string> Get(string address)
        {
            return await client.GetStringAsync(address);
        }
    }
}
