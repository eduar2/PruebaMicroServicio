using BusinessApplication.Interfaces;
using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessApplication.Services
{
    public sealed class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository personaRepository;
        private readonly IClienteRepository clienteRepository;

        public PersonaService(IPersonaRepository personaRepository, IClienteRepository clienteRepository)
        {
            this.personaRepository = personaRepository;
            this.clienteRepository = clienteRepository;
        }
        public List<Persona> ConsultPersonas()
        {
            try
            {
                string mensaje = "Internal error en el método ConsultPersonas";
                IEnumerable<Persona> resultPartial = personaRepository.GetAll();
                List<Persona> result = new List<Persona>();
                foreach (Persona persona in resultPartial)
                {
                    Cliente cliente = clienteRepository.Get(persona.Identificacion);
                    persona.Clientes.Add(cliente);
                    result.Add(persona);
                }
                if (result == null) throw new Exception (mensaje);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool CreatePersona(ref Persona persona, ref string mensaje)
        {
            try
            {
                personaRepository.Insert(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePersona(ref Persona persona, ref string mensaje)
        {
            try
            {
                personaRepository.Update(persona); 
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeletePersona(string identificacion, ref string mensaje)
        {
            try
            {
                var persona = new Persona() { Identificacion = identificacion};
                personaRepository.Delete(persona);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Persona FindPersona(string identificacion)
        {
            try
            {
                Persona persona = personaRepository.Get(identificacion);
                
                if (persona != null)
                {
                    Cliente cliente = clienteRepository.Get(persona.Identificacion);
                    persona.Clientes.Add(cliente);
                    return persona;
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

        public Persona FindPersona(int id)
        {
            try
            {
                Persona persona = personaRepository.Get(id);

                if (persona != null)
                {
                    Cliente cliente = clienteRepository.Get(persona.Identificacion);
                    persona.Clientes.Add(cliente);
                    return persona;
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
