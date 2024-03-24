using System.Collections.Generic;

namespace TESTE.Cep.Dominio.Entidades
{
    public class PCCidadeModels
    {
        public string cidade { get; set; }
        public string estado { get; set; }
        public string atualizado_em { get; set; }
        public List<ClimaAeroportoModels> clima { get; set; }
        public string retorno {  get; set;  }


       

    }
}
