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
using WebAPITest.Utils;
using WebAPITest.Contracts;

namespace WebAPITest.Controllers
{
    [ApiController]
    [Route("/cuentas")]
    public class CuentasController : ControllerBase
    {
        private readonly ICuentaService cuentaService;

        public CuentasController(ICuentaService cuentaService)
        {
            this.cuentaService = cuentaService;
        }

        // GET: /cuentas
        [HttpGet]
        public  List<Cuenta> GetCuentas()
        {
            var result = cuentaService.ConsultCuentas();
            if (result == null) { throw new Exception(null); }
            Response.StatusCode = StatusCodes.Status200OK;
            return result;
        }

        // GET: api/Cuentas/5
        [HttpGet("{numeroCuenta}")]
        public Cuenta GetCuenta(string numeroCuenta)
        {
            var cuenta = cuentaService.FindCuenta(numeroCuenta);

            if (cuenta == null)
            {
                return null;
            }

            return cuenta;
        }

        // POST: api/Cuentas
        [HttpPost]
        public  IActionResult Crear(ContractCuenta cuenta)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                Cuenta newCuenta = cuenta.MapToCuenta();
                result = cuentaService.CreateCuenta(ref newCuenta, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                return StatusCode(StatusCodes.Status200OK, "Cuenta registrada correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        // PUT: api/Cuentas
        [HttpPut]
        public  IActionResult ActualizarCuenta(ContractCuenta cuenta)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                Cuenta newCuenta = cuenta.MapToCuenta();
                result = cuentaService.UpdateCuenta(ref newCuenta, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        // DELETE: api/Cuentas/5
        [HttpDelete("{numeroCuenta}")]
        public  IActionResult DeleteCuenta(string numeroCuenta)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                result = cuentaService.DeleteCuenta(numeroCuenta, ref mensaje);
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
