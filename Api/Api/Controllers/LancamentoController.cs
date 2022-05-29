using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Controllers.DTOs;
using Api.Infra.Repositorios;

namespace Api.Controllers
{
    [RoutePrefix("[Lancamento]")]
    public class LancamentoController : ApiController
    {
        private readonly IRepositorioLancamento _repositorioLancamento;
        public LancamentoController(IRepositorioLancamento repositorioLancamento)
        {
            _repositorioLancamento = repositorioLancamento;
        }

        [Route(""), HttpPost]
        public IHttpActionResult AdicionarLancamento(LancamentoDto lancamentoDto)
        {
            return Ok(lancamentoDto);
        }

        [Route(""), HttpGet]
        public IHttpActionResult ObterTodosOsLancamentos()
        {
            return Ok(_repositorioLancamento.SelecionarTodos());
        }
    }
}
