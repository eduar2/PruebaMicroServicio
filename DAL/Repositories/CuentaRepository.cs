using System;
using System.Collections.Generic;
using System.Text;
using Core.Repositories;
using Core.Domains;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DAL.Repositories
{
    public sealed class CuentaRepository: GenericRepository<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(TestDBContext context) : base(context)
        {
        }

        public Cuenta GetMovimientosOfCuenta(string numeroCuenta)
        {
            return TestDBContext.Cuentas.Include(a => a.Movimientos).SingleOrDefault(a => a.NumeroCuenta == numeroCuenta);
        }

        public Cuenta Get(string numeroCuenta)
        {
            return (Cuenta)TestDBContext.Cuentas.Where(a => a.NumeroCuenta == numeroCuenta).FirstOrDefault();
        }
        public TestDBContext TestDBContext
        {
            get { return Context as TestDBContext; }
        }
    }
}
