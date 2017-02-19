using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Reflection;

namespace SalesApp.Service
{
    using SalesApp.Model.Attributes;
    using SalesApp.Model.Model;

    public class ServiceProvider<T> where T : BaseModel, new()
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

        public async Task<List<T>> RequestCollectionAsync()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(uri + $"{typeof(T).Name}s");

                    if (response.IsSuccessStatusCode)
                    {
                        // by calling .Result you are performing a synchronous call
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        var placesJson = responseContent.ReadAsStringAsync().Result;
                        var placeobject = new List<T>();
                        if (placesJson != "")
                        {
                            placeobject = JsonConvert.DeserializeObject<List<T>>(placesJson);
                        }
                        return placeobject;

                    }
                }
                catch (Exception ex)
                {
                    // ignored
                }
            }
            return new List<T>();
        }

        public List<T> RequestCollection()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = client.GetAsync(uri + this.GetUri(typeof(T))).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // by calling .Result you are performing a synchronous call
                        var responseContent = response.Content;

                        // by calling .Result you are synchronously reading the result
                        var placesJson = responseContent.ReadAsStringAsync().Result;
                        var placeobject = new List<T>();
                        if (placesJson != "")
                        {
                            placeobject = JsonConvert.DeserializeObject<List<T>>(placesJson);
                        }
                        return placeobject;

                    }
                }
                catch (Exception ex)
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
                var t = JsonConvert.SerializeObject(data);
                var content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var response = client.PostAsync(this.uri + this.GetUri(data), content).Result;
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
                catch (Exception ex)
                {
                    // ignored
                }
            }
            return default(T);
        }

        private string GetUri<T>(T data) where T : BaseModel
        {
            var uri = typeof(T).GetTypeInfo().GetCustomAttribute<UriAttribute>().Uri;
            if (uri.Contains("{"))
            {
                var property = uri.Substring(uri.IndexOf("{") + 1, uri.IndexOf("}") - uri.IndexOf("{") -1);
                var val = data.GetType().GetRuntimeProperty(property).GetValue(data, null);
                uri = uri.Replace("{" + property + "}", val.ToString());
            }
            return uri;
        }

        private string GetUri(Type type)
        {
            return typeof(T).GetTypeInfo().GetCustomAttribute<UriAttribute>().Uri;
        }
    }

}
