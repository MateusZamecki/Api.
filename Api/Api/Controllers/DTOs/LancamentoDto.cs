using System;

namespace Api.Controllers.DTOs
{
    public class LancamentoDto
    {
        public bool EhSaida { get; set; }
        public double Valor { get; set; }
        public int TipoLancamento { get; set; }
    }
}
