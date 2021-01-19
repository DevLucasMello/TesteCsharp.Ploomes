using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ploomes
{
    public static class Helper
    {
        public static async Task Post(object objeto, Textos textos)
        {
            using (var client = new HttpClient())
            {
                var constantes = new Constantes();
                client.BaseAddress = new Uri(constantes.Site);
                client.DefaultRequestHeaders.Add(constantes.Chave, constantes.Valor);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(constantes.TipoRetorno));


                var response = await client.PostAsJsonAsync(textos.Url, objeto);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(textos.MessageSuccess);
                }
                else
                {
                    Console.WriteLine(textos.MessageError);
                }
            }
        }

        public static async Task<int> Get(Textos textos)
        {
            int id = 0;

            using (var client = new HttpClient())
            {
                var constantes = new Constantes();

                client.BaseAddress = new Uri(constantes.Site);
                client.DefaultRequestHeaders.Add(constantes.Chave, constantes.Valor);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(constantes.TipoRetorno));

                HttpResponseMessage response = await client.GetAsync(textos.Url);

                if (response.IsSuccessStatusCode)
                {
                    if (textos.NumeroConsulta == 1)
                    {
                        var dados = await response.Content.ReadAsAsync<ContactsFull>();

                        foreach (var d in dados.value)
                        {
                            if (textos.Email == d.Email)
                            {
                                id = d.Id;
                            }
                        }
                    }
                    if (textos.NumeroConsulta == 2)
                    {
                        var dados = await response.Content.ReadAsAsync<DealsFull>();

                        foreach (var d in dados.value)
                        {
                            if (textos.ContactId == d.ContactId)
                            {
                                id = d.Id;
                            }
                        }
                    }
                    if (textos.NumeroConsulta == 3)
                    {
                        var dados = await response.Content.ReadAsAsync<TasksFull>();

                        foreach (var d in dados.value)
                        {
                            if (textos.DealId == d.DealId)
                            {
                                id = d.Id;
                            }
                        }
                    }
                }
            }
            return id;
        }
        public static async Task Patch(object objeto, Textos textos)
        {
            
            using (var client = new HttpClient())
            {
                var constantes = new Constantes();
                client.BaseAddress = new Uri(constantes.Site);
                client.DefaultRequestHeaders.Add(constantes.Chave, constantes.Valor);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(constantes.TipoRetorno));

                var json = JsonConvert.SerializeObject(objeto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PatchAsync(textos.Url, data);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine(textos.MessageSuccess);
                }
                else
                {
                    Console.WriteLine(textos.MessageError);
                }
            }
        }
    }
}
