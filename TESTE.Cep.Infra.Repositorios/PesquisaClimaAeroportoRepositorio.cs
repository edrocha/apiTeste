using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
using System.Numerics;
using System.Security.Claims;
using System.Text.Json.Serialization;
using TESTE.Cep.Dominio.Entidades;
using TESTE.Cep.Dominio.Interfaces;
using TESTE.PesquisaClima.Dominio.Interfaces;
using static System.Net.WebRequestMethods;

namespace TESTE.PesquisaClima.Infra.Repositorios
{
    public class PesquisaClimaAeroportoRepositorio : IPesquisaClimaAeroporto    {

        public void SalvaAeroporto(PCModels obj)
        {
            string connectionString = @"server=conhecimentoe.mysql.dbaas.com.br;uid=conhecimentoe;pwd=Ebr715900!;database=conhecimentoe";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string insertData = "INSERT INTO climaAeroporto ( umidade,visibilidade,intensidade,Age," +
                        "codigo_icao,pressao_atmosferica, vento,direcao_vento, condicao,condicao_desc,temp,atualizado_em)" +
                        " VALUES(" + "@Fumidade, @Fvisibilidade, @Fintensidade" +
                        "@Fcodigo_icao,@Fpressao_atmosferica, @Fvento,@Fdirecao_vento,"+
                        "@Fcondicao,@Fcondicao_desc,@Ftemp,@Fatualizado_em)";

                    MySqlCommand command = new MySqlCommand(insertData, connection);

                    command.Parameters.AddWithValue("@Fumidade", obj.umidade);
                     command.Parameters.AddWithValue("@Fvisibilidade", obj.visibilidade);
                     command.Parameters.AddWithValue("@Fintensidade", obj.intensidade);
                     
                    //------------------------------------------------------------------
                     command.Parameters.AddWithValue("@Fcondicao", obj.condicao);
                     command.Parameters.AddWithValue("@Fcondicao_desc", obj.condicao_desc);
                     command.Parameters.AddWithValue("@Fvento", obj.vento);
                     command.Parameters.AddWithValue("@Fdirecao_vento", obj.direcao_vento);
                    //------------------------------------------------------------------
                    command.Parameters.AddWithValue("@Fcodigo_icao", obj.codigo_icao);
                    command.Parameters.AddWithValue("@Fpressao_atmosferica", obj.pressao_atmosferica);
                    command.Parameters.AddWithValue("@Ftemp", obj.temp);
                    command.Parameters.AddWithValue("@Fatualizado_em", obj.atualizado_em);
                    //------------------------------------------------------------------

                    int result = command.ExecuteNonQuery();
                     connection.Open();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public PCModels Obter(string id)
        {
            var url = "https://brasilapi.com.br/api/cptec/v1/clima/aeroporto/";
            string clima;
            PCModels objretorno = new PCModels();
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
                 clima = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                return objretorno;  // mando o objeto vazio sem nada
            }
            PCModels Result = JsonConvert.DeserializeObject<PCModels>(clima);
            SalvaAeroporto(Result);
            return Result;
            
        }

    }
    }
