using Api.Comum.Excecoes;
using Api.Comum.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Api.Comum.String
{
    public static class ExtensoesDeString
    {
        public static string RemoverAcentos(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return "";

            var bytes = Encoding.GetEncoding("iso-8859-8").GetBytes(input);
            return Encoding.UTF8.GetString(bytes);
        }

        public static string TornarMinusculoERemoverAcentos(this string input)
        {
            return RemoverAcentos(input).ToLower();
        }

        public static string TornarMinusculoRemoverAcentosELimparEspacosInicioFim(this string input)
        {
            return TornarMinusculoERemoverAcentos(input)?.Trim();
        }

        public static bool ContemTextoIgnorandoAcentuacaoECaixa(this string texto, string termoDaBusca)
        {
            return texto.RemoverAcentos().IndexOf(termoDaBusca.RemoverAcentos(), StringComparison.InvariantCultureIgnoreCase) > -1;
        }

        public static string TitleCase(this string texto)
        {
            const int tamanhoMinimoDaPalavra = 3;
            var regexPattern = $@"(?<=(^|\.)\s*)\w|\b\w(?=\w{{{tamanhoMinimoDaPalavra}}})";
            return Regex.Replace(texto, regexPattern, m => m.Value.ToUpperInvariant());
        }

        public static bool ContemCaracteresEspeciais(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            if (Regex.IsMatch(texto, "^[a-zA-Z0-9]*$", RegexOptions.IgnoreCase))
                return false;

            return true;
        }

        public static string ProtegerCpf(this string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
            {
                return "";
            }

            new ExcecaoDeParametroInvalido()
                .Quando(!CpfHelper.ValidarCpf(cpf), "O CPF informado é inválido.")
                .EntaoDispara();

            var digitosComplementares = cpf.Substring(6, 3);
            var digitosVerificadores = cpf.Substring(9, 2);

            return $"***.***.{digitosComplementares}-{digitosVerificadores}";
        }

        public static string ProtegerOutrosDocumentos(this string documentoDeIdentificacao)
        {
            documentoDeIdentificacao = documentoDeIdentificacao.Replace(" ", "").Trim();
            var quantidadeDeCaracteresDoDocumento = documentoDeIdentificacao.Length;

            if (string.IsNullOrWhiteSpace(documentoDeIdentificacao))
            {
                return "";
            }

            var meioDaString = Math.Abs(quantidadeDeCaracteresDoDocumento / 2);
            var meioDoMeioDaString = Math.Abs(meioDaString / 2);
            var digitosParaExibir = documentoDeIdentificacao.Substring(meioDoMeioDaString, meioDaString);

            return $"**{digitosParaExibir}**";
        }

        public static string ApenasNumeros(this string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(str, "");
        }

        //public static string AplicarMascaraDoNumeroDoProcesso(this string numeroDoProcesso)
        //{
        //    if (string.IsNullOrWhiteSpace(numeroDoProcesso))
        //        return numeroDoProcesso;

        //    if (numeroDoProcesso.Any(caracter => !char.IsLetterOrDigit(caracter)))
        //        return numeroDoProcesso;

        //    var mascara = ConfiguracoesDoAmbiente.ObterMascaraParaNumeroDoProcesso;

        //    if (string.IsNullOrWhiteSpace(mascara))
        //        return numeroDoProcesso;

        //    new ExcecaoDeParametroInvalido()
        //        .Quando(
        //            ValidarTamanhoDaMascaraEDoNumeroDoProcessoDiferentes(numeroDoProcesso, mascara),
        //            "Número do processo e máscara possuem tamanho diferentes.")
        //        .EntaoDispara();

        //    return AplicarMascara(numeroDoProcesso, mascara);
        //}

        private static string AplicarMascara(string numeroDoProcesso, string mascara)
        {
            var delimitadoresDaMascara = mascara.Where(caracter => !char.IsLetterOrDigit(caracter))
                .Distinct().ToList();
            var indicesEncontrados = new Dictionary<int, char>();
            foreach (var delimitador in delimitadoresDaMascara)
            {
                var indice = mascara.IndexOf(delimitador);
                while (indice >= 0)
                {
                    indicesEncontrados.Add(indice, delimitador);
                    indice = mascara.IndexOf(delimitador, indice + 1);
                }
            }

            foreach (var indice in indicesEncontrados)
            {
                numeroDoProcesso = numeroDoProcesso.Insert(indice.Key, indice.Value.ToString());
            }

            return numeroDoProcesso;
        }

        private static bool ValidarTamanhoDaMascaraEDoNumeroDoProcessoDiferentes(string numeroDoProcesso, string mascara)
        {
            var mascaraSomenteNumerosELetras = Regex.Replace(mascara, "[^0-9a-zA-Z]+", "");

            return mascaraSomenteNumerosELetras.Length != numeroDoProcesso.Length;
        }
    }
}
