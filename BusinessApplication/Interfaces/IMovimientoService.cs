using Core.Domains;
using System;
using System.Collections.Generic;

namespace BusinessApplication.Interfaces
{
    public interface IMovimientoService
    {
        List<Movimiento> ConsultMovimientos(); 
        bool CreateMovimiento(ref Movimiento movimiento, ref string mensaje);
        bool UpdateMovimiento(ref Movimiento movimiento, ref string mensaje);
        bool DeleteMovimiento(int idMovimiento, ref string mensaje);
        List<EstadoCuenta> ConsultMovimientosPorFechas(DateTime FechaInicio, DateTime FechaFin, string IdentificacionCliente);

        public Movimiento FindMovimiento(int id);
    }
}
