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
    public sealed class EstadoCuentaRepository: GenericRepository<EstadoCuenta>, IEstadoCuentaRepository
    {
        public EstadoCuentaRepository(TestDBContext context) : base(context)
        {
        }

        public IEnumerable<EstadoCuenta> GetMovimientosPorFechaCliente(string identificacion, DateTime fechaInicial, DateTime fechaFinal)
        {
             return TestDBContext.EstadoCuentas.Where(a => a.Identificacion == identificacion && a.Fecha >= fechaInicial && a.Fecha <= fechaFinal);
        }

        public IEnumerable<EstadoCuenta> ConsultaCupo(string cuenta, DateTime fechaInicial, DateTime fechaFinal)
        {
            return TestDBContext.EstadoCuentas.Where(a => a.NumeroCuenta== cuenta && a.Fecha >= fechaInicial && a.Fecha <= fechaFinal);
        }


        public TestDBContext TestDBContext
        {
            get { return Context as TestDBContext; }
        }
    }
}
