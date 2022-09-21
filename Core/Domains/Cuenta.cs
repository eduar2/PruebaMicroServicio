using System;
using System.Collections.Generic;


namespace Core.Domains
{
    public partial class Cuenta
    {
        public Cuenta()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        public string NumeroCuenta { get; set; }
        public int TipoCuenta { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal SaldoDisponible { get; set; }
        public bool Estado { get; set; }
        public int ClienteId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
