using log4net.Repository.Hierarchy;
using System;

namespace TESTE.PesquisaClima.Infra.Data
{
    public class Contexto
    {
        public  bool TesteConnection()
        {
            var cnn = new TESTE.Cep.CrossCutting.Sistema.Chaves().ConnectionString;
           try
            {
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Logger.Error("Contexto/TesteConnection", ex);
                return false;

            }
        }
    }
}
