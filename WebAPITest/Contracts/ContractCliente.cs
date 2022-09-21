

using System.ComponentModel.DataAnnotations;

namespace WebAPITest.Contracts
{
    public sealed class ContractCliente : ContractPersona
    {
        [Required]
        public int IdCliente { get; set; }
        
        [Required]
        public string Contrasena { get; set; }
        
        [Required]
        public bool Estado { get; set; }

    } 

}
