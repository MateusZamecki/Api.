using Api.Controllers.DTOs;
using Api.Dominio;
using Api.Infra.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Aplicacao.Lancamentos
{
    public class AdicionaLancamentoAoUsuario
    {
        private readonly IRepositorioLancamento _repostorioLancamento;
        public AdicionaLancamentoAoUsuario(IRepositorioLancamento repostorioLancamento)
        {
            _repostorioLancamento = repostorioLancamento;
        }

        public void Adicionar(LancamentoDto lancamentoDto)
        {
            var tipo = lancamentoDto.TipoLancamento == 0 ? TipoLancamento.Debito : TipoLancamento.Credito;
            var lancamento = new Lancamento(lancamentoDto.EhSaida, lancamentoDto.Valor, tipo);

            _repostorioLancamento.Adicionar(lancamento);
        }
    }
}
