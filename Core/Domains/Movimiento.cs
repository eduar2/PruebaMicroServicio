using System;
using System.Collections.Generic;

namespace Core.Domains
{
    public partial class Movimiento
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int TipoMovimiento { get; set; }
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
        public string NumeroCuenta { get; set; }

        public virtual Cuenta NumeroCuentaNavigation { get; set; }
    }
}
