using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net.Http;
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
            string connectionString = @"Data Source=conhecimentoe.mysql.dbaas.com.br; Database=conhecimentoe; User ID=conhecimentoe; Password=Ebr715900!";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    string insertData = "insert into signup_table(firstname,surname,mobile_number,email_address,password," +
                                        "confirm_password) values (@F_Name, @S_Name, @M_Number, @E_Address, @Password, @C_Password)";
                    MySqlCommand command = new MySqlCommand(insertData, connection);

                    /* command.Parameters.AddWithValue("@F_Name", FN_TextBox.Text);
                     command.Parameters.AddWithValue("@S_Name", SN_TextBox.Text);
                     command.Parameters.AddWithValue("@M_Number", MN_TextBox.Text);
                     command.Parameters.AddWithValue("@E_Address", EA_TextBox.Text);
                     command.Parameters.AddWithValue("@Password", P_TextBox.Text);
                     command.Parameters.AddWithValue("@C_Password", CP_TextBox.Text);
                     int result = command.ExecuteNonQuery();
                     connection.Open();
                     */
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
            //salvaAeroporto(result);
            return Result;
            
        }

    }
    }
