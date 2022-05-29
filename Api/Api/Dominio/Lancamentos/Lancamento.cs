using Api.Comum.Dominio;
using Api.Comum.Excecoes;
using Api.Comum.Excecoes.MensagensDeExcecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dominio
{
    public class Lancamento : Entidade<Lancamento>
    {
        public DateTime Data { get; set; }
        public bool EhSaida { get; set; }
        public double Valor { get; set; }
        public TipoLancamento TipoLancamento { get; set; }

        public Lancamento(bool ehSaida, double valor , TipoLancamento tipoLancamento)
        {
            ValidarDadosObrigatorios(ehSaida, valor, tipoLancamento);
            Data = DateTime.Now;
            EhSaida = ehSaida;
            Valor = valor;
            TipoLancamento = tipoLancamento;
        }

        private void ValidarDadosObrigatorios(bool ehSaida, double valor, TipoLancamento tipoLancamento)
        {
            new ExcecaoDeDominio()
                .QuandoEhNulo(ehSaida, MensagensDeExcecao.EhObrigatorioInformarOTipoEntradaOuSaidaDoLancamento)
                .Quando(valor < 0 || valor == 0, MensagensDeExcecao.ValorDoLancamentoInvalido)
                .QuandoEhNulo(tipoLancamento, MensagensDeExcecao.EhObrigatorioInformarOTipoDoLancamento)
                .EntaoDispara();
        }
    }
}
