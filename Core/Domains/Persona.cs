using System;
using System.Collections.Generic;

namespace Core.Domains
{
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public int Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
