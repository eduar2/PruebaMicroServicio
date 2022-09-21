using Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IClienteRepository: IGenericRepository<Cliente>
    {

        Cliente Get(string identificacion);
        

    }
}
