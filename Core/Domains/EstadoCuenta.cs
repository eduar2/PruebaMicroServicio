using System;
using System.Collections.Generic;

namespace Core.Domains
{
    public class EstadoCuenta
    {

        public DateTime Fecha { get; set; }
        public string Cliente { get; set; }
        public string NumeroCuenta { get; set; }
        public int Tipo { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Valor { get; set; }
        public decimal SaldoDisponible { get; set; }
        public string Identificacion { get; set; }
    }
}
