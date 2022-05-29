using Api.Comum.Dominio;
using Api.Comum.Excecoes;
using Api.Comum.Excecoes.MensagensDeExcecao;
using Api.Comum.Helpers;
using Api.Comum.String;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dominio.Usuarios
{
    public class Usuario : Entidade<Usuario>
    {
        public List<Lancamento> Lancamentos { get; set; } = new List<Lancamento>();
        public Salario Salario { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }

        public Usuario(string nome, string cpf)
        {
            ValidarDadosObrigatorios(nome, cpf);
            Nome = nome;
            Cpf = cpf;
        }

        public void AdicionarLancamentos(List<Lancamento> lancamentos)
        {
            ValidarLancamentos(lancamentos);
            Lancamentos.AddRange(lancamentos);
        }

        public void AdicionarSalario(Salario salario)
        {
            ValidarSalario(salario);
            Salario = salario;
        }

        private void ValidarDadosObrigatorios(string nome, string cpf)
        {
            ValidarCpf(cpf);
            ValidarNome(nome);
        }

        private void ValidarNome(string nome)
        {
            ExcecaoDeDominio.UmaExcecao()
                .QuandoEhNulo(nome, MensagensDeExcecao.EhObrigatorioInformarONomeDoUsuario)
                .EntaoDispara();
        }

        private void ValidarCpf(string cpf)
        {
            ExcecaoDeDominio.UmaExcecao()
                .Quando(!CpfHelper.ValidarCpf(cpf), MensagensDeExcecao.CpfInformadoEhInvalido)
                .EntaoDispara();
        }

        private void ValidarLancamentos(List<Lancamento> lancamentos)
        {
            ExcecaoDeDominio.UmaExcecao()
                .QuandoEhListaNulaOuVazia(lancamentos, MensagensDeExcecao.OsLancamentosAdicionadosEstaoInvalidos)
                .EntaoDispara();
        }

        private void ValidarSalario(Salario salario)
        {
            ExcecaoDeDominio.UmaExcecao()
                .QuandoEhNulo(salario, MensagensDeExcecao.OSalarioInformadoEstaInvalido)
                .EntaoDispara();
        }
    }
}
