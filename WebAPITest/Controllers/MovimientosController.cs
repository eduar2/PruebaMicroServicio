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
    [Route("/movimientos")]
    public class MovimientosController : ControllerBase
    {
        private readonly IMovimientoService movimientoService;

        public MovimientosController(IMovimientoService movimientoService)
        {
            this.movimientoService = movimientoService;
        }

        // GET: /movimientos
        [HttpGet]
        public  List<Movimiento> GetMovimientos()
        {
            var result = movimientoService.ConsultMovimientos();
            if (result == null) { throw new Exception(null); }
            Response.StatusCode = StatusCodes.Status200OK;
            return result;
        }

        // GET: api/Movimientos/5
        [HttpGet("{id}")]
        public Movimiento GetMovimiento(int id)
        {
            var movimiento = movimientoService.FindMovimiento(id);

            if (movimiento == null)
            {
                return null;
            }

            return movimiento;
        }

        // POST: api/Movimientos
        [HttpPost]
        public  IActionResult Crear(ContractMovimiento movimiento)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                Movimiento newMovimiento = movimiento.MapToMovimiento();
                result = movimientoService.CreateMovimiento(ref newMovimiento, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                return StatusCode(StatusCodes.Status200OK, "El movimiento se registró correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        // PUT: api/Movimientos
        [HttpPut]
        public  IActionResult UpdateMovimiento(ContractMovimiento movimiento)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                Movimiento newMovimiento = movimiento.MapToMovimiento();
                result = movimientoService.UpdateMovimiento(ref newMovimiento, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };
                return StatusCode(StatusCodes.Status200OK, "Registro actualizado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }

        // DELETE: api/Movimientos/5
        [HttpDelete("{id}")]
        public  IActionResult DeleteMovimiento(int id)
        {
            string mensaje = "";
            bool result = false;
            try
            {
                result = movimientoService.DeleteMovimiento(id, ref mensaje);
                if (!result) return new ObjectResult(mensaje) { StatusCode = StatusCodes.Status500InternalServerError };

                return StatusCode(StatusCodes.Status200OK, "Registro eliminado correctamente");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error interno, por favor vuelva a intentar");
            }
        }


        [Route("/reportes")]
        [HttpGet]
        public List<EstadoCuenta> ConsultarMovimientosXFechas(DateTime FechaInicio, DateTime FechaFin, string IdentificacionCliente)
        {
            try
            {
                var fechaInicio = FechaInicio.ToString("yyyy-MM-dd");
                var fechaFin = FechaFin.ToString("yyyy-MM-dd");
                var result = movimientoService.ConsultMovimientosPorFechas(FechaInicio, FechaFin, IdentificacionCliente);
                Response.StatusCode = StatusCodes.Status200OK;
                return result;
            }
            catch (Exception ex)
            {
                Response.StatusCode = StatusCodes.Status500InternalServerError;
                return null;
            }
        }

    }
}
