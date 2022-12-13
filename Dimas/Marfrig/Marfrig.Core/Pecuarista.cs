using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Marfrig.Core
{
    public class Pecuarista
    {
        private string _url;
        public Pecuarista(string url) => (_url) = (url);

        public List<Model.data_model.Pecuarista> Get()
        {
            try
            {
                using (var client = new HttpClient())
                { 
                    var response =  client.GetAsync($"{_url}api/pecuarista/get").Result;
                    var conteudo =  response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Model.data_model.Pecuarista>>(conteudo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
