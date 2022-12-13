using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Marfrig.Core
{
    public class CompraGado
    {
        private readonly string _url;
        public CompraGado(string url) => (_url) = (url);

        public List<Model.data_model.CompraGado> Get()
        {
            try
            {
                using (var client = new HttpClient())
                { 
                    var response =  client.GetAsync($"{_url}api/compragado/get").Result;
                    var conteudo =  response.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<List<Model.data_model.CompraGado>>(conteudo);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public void Save(Model.data_model.CompraGado comnprGado)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.PostAsync($"{_url}api/compragado/post", new StringContent(
                        JsonConvert.SerializeObject(comnprGado), Encoding.UTF8, "application/json")).Result; 
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }

        public void Put(int Id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.PutAsync($"{_url}api/compragado/put/{Id}", new StringContent(
                        JsonConvert.SerializeObject(Id), Encoding.UTF8, "application/json")).Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteItem(int itemId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response =  client.DeleteAsync($"{_url}api/compragado/deleteitem/{itemId}").Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var response = client.DeleteAsync($"{_url}api/compragado/delete/{id}").Result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
