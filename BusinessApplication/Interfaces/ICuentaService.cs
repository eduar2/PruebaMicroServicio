using Core.Domains;
using System.Collections.Generic;

namespace BusinessApplication.Interfaces
{
    public interface ICuentaService
    {
        List<Cuenta> ConsultCuentas();
        bool CreateCuenta(ref Cuenta cuenta, ref string mensaje);
        bool UpdateCuenta(ref Cuenta cuenta, ref string mensaje);
        bool DeleteCuenta(string numeroCuenta, ref string mensaje);
        Cuenta FindCuenta(string numeroCuenta);
    }
}
