using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reader_connector.Shared
{
    class RestAPIHelper
    {
        public static async Task<string> Get(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(url))
                {
                    if (!res.IsSuccessStatusCode)
                    {
                        //MessageBox.Show($"Error occurred, the status code is: {res.StatusCode}");
                        return string.Empty;
                    }
                        
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
