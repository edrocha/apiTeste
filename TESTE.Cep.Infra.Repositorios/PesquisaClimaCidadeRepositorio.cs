using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text.Json.Serialization;
using TESTE.Cep.Dominio.Entidades;
using TESTE.Cep.Dominio.Interfaces;
using TESTE.PesquisaClima.Dominio.Interfaces;
using static System.Net.WebRequestMethods;

namespace TESTE.PesquisaClima.Infra.Repositorios
{
    public class PesquisaClimaCidadeRepositorio : IPesquisaClimaCidade { 
        public PCCidadeModels Obter(string id)
        {
            var url = "https://brasilapi.com.br/api/cptec/v1/clima/previsao/";
            string climaCidade;
            PCCidadeModels objretorno = new PCCidadeModels();
            url = url + id;
            var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //chamando a api pela url
            System.Net.Http.HttpResponseMessage response = client.GetAsync(url).Result;
            //se retornar com sucesso busca os dados
            if (response.IsSuccessStatusCode)
            {
                //Pegando os dados do Rest e armazenando na variável usuários
                climaCidade = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return objretorno;  // mando o objeto vazio sem nada
            }
            PCCidadeModels Result = JsonConvert.DeserializeObject<PCCidadeModels>(climaCidade);
            return Result;
        }

        public void SalvaAeroporto(PCModels obj)
        {
            throw new NotImplementedException();
        }
    }
    }
