
using System.Collections.Generic;
using TESTE.Cep.Dominio.Entidades;

namespace TESTE.PesquisaClima.Aplicacao.Interfaces
{

    public interface IPesquisaClimaAeroportoAplicacao
    {
        PCModels Obter(string id);
    }
}
