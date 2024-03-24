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
    public class PesquisaClimaCidadeAplicacao : IPesquisaClimaCidadeAplicacao
    {
        public IPesquisaClimaCidade _PesquisaClimaCidadeRepositorio { get; set; }

        public PesquisaClimaCidadeAplicacao(IPesquisaClimaCidade _PesquisaRepositorio)
        {
            _PesquisaClimaCidadeRepositorio = _PesquisaRepositorio;
        }
        public PCCidadeModels Obter(string id)
        {
            try
            {
                return _PesquisaClimaCidadeRepositorio.Obter(id);
            }
            catch (Exception ex)
            {
                Logger.Error("CidadeAplicacao", ex);
                throw;
            }
        }

       
    }
}
