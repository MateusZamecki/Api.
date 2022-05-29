using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Excecoes
{
    public class ExcecaoDeDominio : Excecao
    {
        public ExcecaoDeDominio() : base("") { }

        public ExcecaoDeDominio(string message) : base(message)
        {
        }

        public static ExcecaoDeDominio UmaExcecao()
        {
            return new ExcecaoDeDominio();
        }
    }
}
