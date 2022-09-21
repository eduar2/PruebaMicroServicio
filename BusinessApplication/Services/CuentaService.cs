using BusinessApplication.Interfaces;
using Core.Domains;
using Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessApplication.Services
{
    public sealed class CuentaService : ICuentaService
    {
        private readonly ICuentaRepository cuentaRepository;
        public CuentaService(ICuentaRepository cuentaRepository)
        {
            this.cuentaRepository = cuentaRepository;
        }
        public List<Cuenta> ConsultCuentas()
        {
            try
            {
                string mensaje = null;
                IEnumerable<Cuenta> result = cuentaRepository.GetAll();
                if (result == null) throw new Exception(mensaje);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Cuenta FindCuenta (string numeroCuenta)
        {
            try
            {
                Cuenta cuenta = cuentaRepository.Get(numeroCuenta);
                if (cuenta != null)
                {
                    return cuenta;
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
        public bool CreateCuenta(ref Cuenta cuenta, ref string mensaje)
        {
            try
            {
                cuentaRepository.Insert(cuenta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateCuenta(ref Cuenta cuenta, ref string mensaje)
        {
            try
            {
                cuentaRepository.Update(cuenta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCuenta(string numeroCuenta, ref string mensaje)
        {
            try
            {
                var cuenta = new Cuenta() { NumeroCuenta = numeroCuenta };
                cuentaRepository.Delete(cuenta);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
