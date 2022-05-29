using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Excecoes.MensagensDeExcecao
{
    public static class MensagensDeExcecao
    {
        public const string ValorDoLancamentoInvalido = "Valor do lançamento inválido";
        public const string ValorDoSalarioInvalido = "Valor do Salario inválido";
        public const string EhObrigatorioInformarOTipoDoLancamento = "É obrigatorio informar um tipo, debito ou credito, para o lançamento";
        public const string EhObrigatorioInformarOTipoEntradaOuSaidaDoLancamento = "É obrigatorio informar um tipo, entrada ou saida, para o lançamento";
        public const string EhObrigatorioInformarONomeDoUsuario = "É obrigatorio informar o nome do Usuario";
        public const string CpfInformadoEhInvalido = "O CPF informado é inválido.";
        public const string OsLancamentosAdicionadosEstaoInvalidos = "Os lancamentos adicionados estao inválidos";
        public const string OSalarioInformadoEstaInvalido = "O salário informado esta inválido";
    }
}
