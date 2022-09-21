using BusinessApplication.Interfaces;
using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessApplication.Services
{
    public sealed class MovimientoService: IMovimientoService
    {
        private readonly IMovimientoRepository movimientoRepository;
        private readonly ICuentaRepository cuentaRepository;
        private readonly IEstadoCuentaRepository estadoCuentaRepository;

        public MovimientoService(IMovimientoRepository movimientoRepository, 
            ICuentaRepository cuentaRepository,
            IEstadoCuentaRepository estadoCuentaRepository)
        {
            this.movimientoRepository = movimientoRepository;
            this.cuentaRepository = cuentaRepository;
            this.estadoCuentaRepository = estadoCuentaRepository;
        }
        public List<EstadoCuenta> ConsultMovimientosPorFechas(DateTime FechaInicio, DateTime FechaFin, string IdentificacionCliente)
        {
            try
            {
                string mensaje = null;

                IEnumerable<EstadoCuenta> result = estadoCuentaRepository.GetMovimientosPorFechaCliente(IdentificacionCliente, FechaInicio, FechaFin);
                if (result == null) throw new Exception(mensaje);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }



        public List<EstadoCuenta> ConsultCupo(DateTime FechaInicio, DateTime FechaFin, string Cuenta)
        {
            try
            {
                string mensaje = null;

                IEnumerable<EstadoCuenta> result = estadoCuentaRepository.ConsultaCupo(Cuenta, FechaInicio, FechaFin);
                if (result == null) throw new Exception(mensaje);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Movimiento> ConsultMovimientos()
        {
            try
            {
                string mensaje = null;
                IEnumerable<Movimiento> result = movimientoRepository.GetAll();
                if (result == null) throw new Exception(mensaje);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool CreateMovimiento(ref Movimiento movimiento, ref string mensaje)
        {
            bool result = false;
            bool actualizar = true;
            decimal nuevoSaldo = 0;
            try
            {
                Cuenta cuenta = cuentaRepository.Get(movimiento.NumeroCuenta);
                DateTime actualDate = DateTime.Now;
                decimal cupoActual = 0;
                List<EstadoCuenta> movimientos = this.ConsultCupo(actualDate.Date, actualDate.Date.AddDays(1).AddTicks(-1), movimiento.NumeroCuenta);
                foreach (EstadoCuenta mov in movimientos)
                {
                    if (mov.Tipo == 0)
                    {
                        cupoActual = cupoActual + mov.Valor;
                    }
                    
                }
                if (movimiento.TipoMovimiento == 0) //debito
                {
                    cupoActual = cupoActual + movimiento.Valor;
                    if (cupoActual > 1000)
                    {
                        mensaje = "Cupo diario excedido.";
                        actualizar = false;
                    }
                    if (cuenta.SaldoDisponible == 0)
                    {
                        mensaje = "Saldo no disponible";
                        actualizar = false;
                    }
                    else if (cuenta.SaldoDisponible < movimiento.Valor)
                    {
                        mensaje = "Saldo insuficiente";
                        actualizar = false;
                    }
                    else
                    {
                        nuevoSaldo = cuenta.SaldoDisponible - movimiento.Valor;
                    }
                }
                else
                {
                    nuevoSaldo = cuenta.SaldoDisponible + movimiento.Valor;
                }
                if (actualizar)
                {
                    Cuenta cuenta1 = cuentaRepository.Get(movimiento.NumeroCuenta);
                    movimiento.Saldo = nuevoSaldo;
                    movimientoRepository.Insert(movimiento);
                    result = true;
                }
                
            }
            catch (Exception)
            {}
            return result;
        }
        public bool UpdateMovimiento(ref Movimiento movimiento, ref string mensaje)
        {
            try
            {
                movimientoRepository.Update(movimiento);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteMovimiento(int idMovimiento, ref string mensaje)
        {
            try
            {
                var movimiento = new Movimiento() { Id = idMovimiento};
                movimientoRepository.Delete(movimiento);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Movimiento FindMovimiento(int id)
        {
            try
            {
                Movimiento movimiento = movimientoRepository.Get(id);
                if (movimiento != null)
                {
                    return movimiento;
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
