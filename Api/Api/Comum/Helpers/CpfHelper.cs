using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Comum.Helpers
{
    public class CpfHelper
    {
        private static int Mod(int dividendo, int divisor)
        {
            return dividendo % divisor;
        }

        public static bool ValidarCpf(string cpf)
        {
            if (cpf == null) return false;

            cpf = Regex.Replace(cpf, @"[^\d]", "");

            if (cpf.Length != 11 || Regex.IsMatch(cpf, "(^1{11}$)|(^2{11}$)|(^3{11}$)|(^4{11}$)|(^5{11}$)|(^6{11}$)|(^7{11}$)|(^8{11}$)|(^9{11}$)|(^0{11}$)"))
                return false;

            for (var x = 0; x <= 1; x++)
            {
                var n1 = 0;

                for (var i = 0; i <= 8 + x; i++)
                    n1 += Convert.ToInt32(cpf.Substring(i, 1)) * (10 + x - i);

                var n2 = 11 - (n1 - (n1 / 11 * 11));

                if (n2 == 10 || n2 == 11)
                    n2 = 0;

                if (n2 != Convert.ToInt32(cpf.Substring(9 + x, 1)))
                    return false;
            }

            return true;
        }
    }
}
