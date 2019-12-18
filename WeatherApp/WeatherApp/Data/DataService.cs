using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Data
{
    class DataService
    {
        public static async Task<string> GetDataFromService(string queryString)
        {
            var data = string.Empty;
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(queryString).ConfigureAwait(false);
                    if (response != null)
                    {
                        data = response.Content.ReadAsStringAsync().Result;
                    }
                }
                catch (Exception ex)
                {
                    var error = ex.Message;
                    Console.WriteLine(error);
                }
            }
            return data;
        }
    }
}
