using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Marfrig.Core
{
    public class Animal
    {
        private string _url;
        public Animal(string url) => (_url) = (url);

        public List<Model.data_model.Animal> Get()
        {
            try
            {
                using (var client = new HttpClient())
                { 
                    var response =  client.GetAsync($"{_url}api/animal/get").Result;
                    var conteudo =  response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Model.data_model.Animal>>(conteudo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        private void SetHeaderParameters(WebClient client)
        {
            client.Headers.Clear();
            client.Headers.Add("Content-Type", "application/json");
            client.Encoding = Encoding.UTF8;
        }

    }
}
