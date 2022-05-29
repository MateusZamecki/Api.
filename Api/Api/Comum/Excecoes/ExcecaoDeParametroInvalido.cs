using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Comum.Excecoes
{
    public class ExcecaoDeParametroInvalido : Excecao
    {
        public ExcecaoDeParametroInvalido() : base("") { }

        public ExcecaoDeParametroInvalido(string message) : base(message) { }
    }
}
