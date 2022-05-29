using Api.Comum.Dominio;
using Api.Comum.Excecoes;
using Api.Comum.Excecoes.MensagensDeExcecao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dominio.Usuarios
{
    public class Salario : Entidade<Salario>
    {
        public double Valor { get; set; }
        public DateTime DataRecorrencia { get; set; }
        public bool NaoPossuiData { get; set; } = false;

        public Salario(double valor, DateTime dataRecorrencia, bool naoPossuiData = false)
        {
            ValidarDadosObrigatorios(valor);
            Valor = valor;
            DataRecorrencia = dataRecorrencia;
            NaoPossuiData = naoPossuiData;
        }

        private void ValidarDadosObrigatorios(double valor)
        {
            ExcecaoDeDominio.UmaExcecao()
                .Quando(valor <= 0,MensagensDeExcecao.ValorDoSalarioInvalido)
                .EntaoDispara();
        }

        public void AlterarSalario(double valor)
        {
            ValidarDadosObrigatorios(valor);
            Valor = valor;
        }

        public void AlterarData(DateTime data)
        {
            DataRecorrencia = data;
        }

        public void ExcluirData()
        {
            NaoPossuiData = true;
        }
    }
}
