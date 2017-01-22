using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SalesApp.Service
{
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices.WindowsRuntime;

    using Newtonsoft.Json;

    public static class ServiceProvider
    {
        public static async Task<T> Request<T>(string route) where T : new()
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://desktop-hiepdas/Customer");
            //request.BeginGetResponse(new AsyncCallback(FinishWebRequest), request);

            var client = new System.Net.Http.HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1/");
            try
            {
                var response = await client.GetAsync(route);
                var placesJson = response.Content.ReadAsStringAsync().Result;
                T placeobject = new T();
                if (placesJson != "")
                {
                    placeobject = JsonConvert.DeserializeObject<T>(placesJson);
                }
                return placeobject;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public static async Task<List<T>> RequestCollection<T>(string route) where T : new()
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://desktop-hiepdas/Customer");
            //request.BeginGetResponse(new AsyncCallback(FinishWebRequest), request);
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync("http://192.168.1.99/" + route).Result;

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

        public static async Task<T> PosTask<T>(string route, T data) where T : new()
        {
            using (var client = new HttpClient())
            {
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                HttpContent httpContent = new StringContent(content.ToString(), Encoding.UTF8);
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "http://192.168.1.99/" + route);
                request.Content = httpContent;

                // string postBody = content.ToString();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // HttpResponseMessage wcfResponse = await client.PostAsync("http://192.168.1.99/" + route, content);
                //await DisplayTextResult(wcfResponse, OutputField);

                try
                {
                    var response = client.PostAsync("http://192.168.1.99/" + route, content).Result;
                    //var response = client.SendAsync(request).Result;
                    //var response = client.PostAsync("http://192.168.1.99/" + route, httpContent).Result;

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
