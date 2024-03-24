
using System.Collections.Generic;
using TESTE.Cep.Dominio.Entidades;

namespace TESTE.PesquisaClima.Aplicacao.Interfaces
{

    public interface IPesquisaClimaCidadeAplicacao
    {
        PCCidadeModels Obter(string id);
    }
}
