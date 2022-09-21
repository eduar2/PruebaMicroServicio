
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPITest.Contracts
{
    public class ContractPersona
    {
        [Required]
        public string Identificacion { get; set; }

        [Required]
        public string Nombres { get; set; }
        
        public long Genero { get; set; }
        public DateTime FechaNacimiento { get; set; } 
        public string Direccion { get; set; } 
        public string Telefono { get; set; }
    }    
}
