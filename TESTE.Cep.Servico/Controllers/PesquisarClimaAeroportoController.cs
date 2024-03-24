
using System.Collections.Generic;
using TESTE.Cep.Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using TESTE.PesquisaClima.Aplicacao.Interfaces;

namespace TESTE.Cep.Servico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisarClimaAeroportoController : ControllerBase
    {
        public IPesquisaClimaAeroportoAplicacao _PesquisaClimaAeroportoAplicacao { get; set; }

        public PesquisarClimaAeroportoController(IPesquisaClimaAeroportoAplicacao PesquisaClimaAeroportoAplicacao)
        {
            _PesquisaClimaAeroportoAplicacao = PesquisaClimaAeroportoAplicacao;
        }
        // GET: api/PesquisaClima/ID
        [HttpGet("{id}", Name = "Get")]
        public PCModels Get(string id)
        {
            return _PesquisaClimaAeroportoAplicacao.Obter(id);
        }

        
    }
}

