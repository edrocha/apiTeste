using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using TESTE.Cep.Dominio.Entidades;
using TESTE.PesquisaClima.Aplicacao.Interfaces;

namespace TESTE.PesquisaClima.Servico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisarClimaCidadeController : ControllerBase
    {
        
            public IPesquisaClimaCidadeAplicacao _PesquisaClimaAplicacao { get; set; }

            public PesquisarClimaCidadeController(IPesquisaClimaCidadeAplicacao PesquisaClimaAplicacao)
            {
                _PesquisaClimaAplicacao = PesquisaClimaAplicacao;
            }

            // GET: api/PesquisaClimaCidade/CodigoCidade
            [HttpGet("{CodigoCidade}", Name = "GetCidade")]
            public PCCidadeModels GetCidade(string CodigoCidade)
            {
                return _PesquisaClimaAplicacao.Obter(CodigoCidade);
            }
        }
    }

