using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Controllers.DTOs;

namespace Api.Controllers
{
    [RoutePrefix("[Lancamento]")]
    public class LancamentoController : ApiController
    {

        [Route(""), HttpPost]
        public IHttpActionResult AdicionarLancamento(LancamentoDto lancamentoDto)
        {
            return Ok(lancamentoDto);
        }

        [Route(""), HttpGet]
        public IHttpActionResult ObterTodosOsLancamentos()
        {
            return Ok();
        }
    }
}
