using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace reader_connector.Shared
{
    class RestAPIHelper
    {
        private static readonly string baseUrl = "https://hcmiu-presence.herokuapp.com";
        //private static readonly string baseUrl = "http://localhost:8080";

        public static async Task<string> Get(string path)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync($"{baseUrl}/{path}"))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        if (data != null)
                            return data;
                    }
                }
            }
            return string.Empty;
        }
    }
}
