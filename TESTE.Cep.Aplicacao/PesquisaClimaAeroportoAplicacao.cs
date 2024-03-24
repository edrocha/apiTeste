using TESTE.Cep.Dominio.Entidades;
using TESTE.Cep.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using TESTE.PesquisaClima.Dominio.Interfaces;
using TESTE.PesquisaClima.Aplicacao.Interfaces;
using TESTE.Cep.CrossCutting.Log;

namespace TESTE.Cep.Aplicacao
{
    public class PesquisaClimaAeroportoAplicacao : IPesquisaClimaAeroportoAplicacao
    {
        public IPesquisaClimaAeroporto _PesquisaClimaAeroportoRepositorio { get; set; }

        public PesquisaClimaAeroportoAplicacao(IPesquisaClimaAeroporto _PesquisaRepositorio)
        {
            _PesquisaClimaAeroportoRepositorio = _PesquisaRepositorio;
        }
        public PCModels Obter(string id)
        {
            try
            {
                return _PesquisaClimaAeroportoRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                Logger.Error("CidadeAplicacao", ex);
                throw;
            }
        }
        
    }
}
