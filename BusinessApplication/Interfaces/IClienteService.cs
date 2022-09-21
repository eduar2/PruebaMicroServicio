using Core.Domains;
using System.Collections.Generic;

namespace BusinessApplication.Interfaces
{
    public interface IClienteService
    {
        bool CreateCliente(ref Cliente cliente, ref string mensaje);
        bool UpdateCliente(ref Cliente cliente, ref string mensaje);
        bool DeleteCliente(int idCliente, ref string mensaje);
        List<Cliente> ConsultClientes();

        public Cliente FindCliente(string identificacion);
    }
}
