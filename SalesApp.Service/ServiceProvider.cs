using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SalesApp.Service
{
    public class ServiceProvider<T> where T : new()
    {
        private readonly Uri uri;

        public ServiceProvider()
        {

#if DEBUG
            uri = new Uri("http://192.168.1.99/");
#else
            uri = new Uri("http://anandaa.azurewebsites.net");
#endif

        }

        public async Task<List<T>> RequestCollection()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(uri + $"{typeof(T).Name}s").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // by calling .Result you are performing a synchronous call
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        string placesJson = responseContent.ReadAsStringAsync().Result;
                        var placeobject = new List<T>();
                        if (placesJson != "")
                        {
                            placeobject = JsonConvert.DeserializeObject<List<T>>(placesJson);
                        }
                        return placeobject;

                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return new List<T>();
        }

        public async Task<T> PostTask(T data)
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsync(uri + $"{typeof(T).Name}s", content).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        // by calling .Result you are performing a synchronous call
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        string placesJson = responseContent.ReadAsStringAsync().Result;
                        var placeobject = new T();
                        if (placesJson != "")
                        {
                            placeobject = JsonConvert.DeserializeObject<T>(placesJson);
                        }
                        return placeobject;

                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return default(T);
        }

    }

}
