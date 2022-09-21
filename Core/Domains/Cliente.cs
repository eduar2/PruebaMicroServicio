using System;
using System.Collections.Generic;


namespace Core.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuenta>();
        }

        public int Id { get; set; }
        public string Contrasena { get; set; }
        public bool Estado { get; set; }
        public string Identificacion { get; set; }

        public virtual Persona IdentificacionNavigation { get; set; }
        public virtual ICollection<Cuenta> Cuenta { get; set; }
    }
}
