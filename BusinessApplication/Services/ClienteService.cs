using BusinessApplication.Interfaces;
using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessApplication.Services
{
    public sealed class ClienteService : IClienteService
    { 
        private readonly IClienteRepository clienteRepository;
        private readonly IPersonaRepository personaRepository;
        public ClienteService(IClienteRepository clienteRepository, IPersonaRepository personaRepository)
        {
            this.clienteRepository = clienteRepository;
            this.personaRepository = personaRepository;
        }
        public List<Cliente> ConsultClientes()
        {
            try
            {
                string mensaje = null;
                IEnumerable <Cliente> result = clienteRepository.GetAll();
                foreach (Cliente cliente in result)
                {
                    Persona persona = personaRepository.Get(cliente.Identificacion);
                    
                }

                if (result == null) throw new Exception(mensaje);
                return result.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CreateCliente(ref Cliente cliente, ref string mensaje)
        {
            try
            {
                clienteRepository.Insert(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCliente(ref Cliente cliente, ref string mensaje)
        {
            try
            {
                clienteRepository.Update(cliente); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCliente(int idCliente, ref string mensaje)
        {
            try
            {
                var cliente = new Cliente() { Id = idCliente};
                clienteRepository.Delete(cliente);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Cliente FindCliente(string identificacion)
        {
            try
            {
                Cliente cliente = clienteRepository.Get(identificacion);
                if (cliente != null)
                {
                    return cliente;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }
        }

    }
}
