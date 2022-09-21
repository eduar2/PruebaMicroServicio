using Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface ICuentaRepository: IGenericRepository<Cuenta>
    {
        Cuenta Get(string numeroCuenta);
    }
}
