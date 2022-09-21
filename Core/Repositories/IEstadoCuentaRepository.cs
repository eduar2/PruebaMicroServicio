using Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IEstadoCuentaRepository: IGenericRepository<EstadoCuenta>
    {

        IEnumerable<EstadoCuenta> GetMovimientosPorFechaCliente(string identificacion, DateTime fechaInicial, DateTime fechaFinal);

        IEnumerable<EstadoCuenta> ConsultaCupo(string cuenta, DateTime fechaInicial, DateTime fechaFinal);

    }
}
