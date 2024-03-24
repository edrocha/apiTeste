using GCOM.Marcas.CrossCutting.Log;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace GCOM.Marcas.Infra.Data
{
    public class Contexto
    {
        public bool TesteConnection()
        {
            var cnn = new CrossCutting.Sistema.Chaves().ConnectionString;
            using OracleConnection con = new OracleConnection(cnn);
            using OracleCommand cmd = con.CreateCommand();
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Error("Contexto/TesteConnection", ex);
                return false;

            }
        }
    }
}
