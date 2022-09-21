using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Domains;
using DAL.Models;
using BusinessApplication.Interfaces;
using WebAPITest.Contracts;
using WebAPITest.Utils;

namespace WebAPITest.Controllers
{
    [ApiController]
    [Route("/clientes")]

    public class ClientesController : ControllerBase
    {
        private readonly IClienteService clienteService;
        private readonly IPersonaService personaService;

        public ClientesController(IClienteService clienteService, IPersonaService personaService)
        {
            this.clienteService = clienteService;
            this.personaService = personaService;
        }

        // GET: /clientes
        [HttpGet]
        public List<ContractCliente> GetClientes()
        {
            var personas = personaService.ConsultPersonas();
            List<ContractCliente> result = new List<ContractCliente>();
            foreach (Persona persona in personas)
            {
                ContractCliente cliente =persona.MapToContractCliente();
                cliente.Contrasena = persona.Clientes.ToList()[0].Contrasena;
                cliente.Estado = persona.Clientes.ToList()[0].Estado;
                cliente.IdCliente = persona.Clientes.ToList()[0].Id;
                result.Add(cliente);
            }
            if (result == null) { throw new Exception(null); }
            Response.StatusCode = StatusCodes.Status200OK;
            return result.ToList();
        }

        //// GET: api/Clientes/0104027040
        [HttpGet("{identificacion}")]
        public ContractCliente GetCliente(string identificacion)
        {
            var persona = personaService.FindPersona(identificacion);
            if (persona == null)
            {
                return null;
            }
            ContractCliente cliente = persona.MapToContractCliente();
            cliente.Contrasena = persona.Clientes.ToList()[0].Contrasena;
            cliente.Estado = persona.Clientes.ToList()[0].Estado;
            cliente.IdCliente = persona.Clientes.ToList()[0].Id;

            return cliente;
        }

        // GET: api/Clientes/5
        //[HttpGet("{id}")]
        //public ContractCliente GetCliente(int id)
        //{
        //    var persona = personaService.FindPersona(id);
        //    if (persona == null)
        //    {
        //        return null;
        //    }
        //    ContractCliente cliente = persona.MapToContractCliente();
        //    cliente.Contrasena = persona.Clientes.ToList()[0].Contrasena;
        //    cliente.Estado = persona.Clientes.ToList()[0].Estado;
        //    cliente.IdCliente = persona.Clientes.ToList()[0].Id;

        //    return cliente;
        //}

        // POST: api/Clientes
        [HttpPost]
        public IActionResult Crear(ContractCliente cliente)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                Persona persona = cliente.MapToPersona();
                Cliente newCliente = cliente.MapToCliente();
                if (personaService.CreatePersona(ref persona, ref mensaje))
                {
                    result = clienteService.CreateCliente(ref newCliente, ref mensaje);
                    if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                    return StatusCode(StatusCodes.Status200OK, "Cliente creado correctamente");
                }
                else
                {
                    return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        // PUT: api/Clientes
        [HttpPut]
        public IActionResult ActualizarCliente(ContractCliente cliente)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                Cliente newCliente = cliente.MapToCliente();
                newCliente.Id = cliente.IdCliente;
                Persona persona = cliente.MapToPersona();
                if (personaService.UpdatePersona(ref persona, ref mensaje))
                {
                    result = clienteService.UpdateCliente(ref newCliente, ref mensaje);
                    if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                    return StatusCode(StatusCodes.Status200OK, "Cliente actualizado correctamente");
                }
                else
                {
                    return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCliente(int id)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                result = clienteService.DeleteCliente(id, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

    }
}
