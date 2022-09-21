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
    public sealed class ClienteRepository: GenericRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(TestDBContext context) : base(context)
        {
        }

        public Cliente Get(string identifcacion)
        {
            return (Cliente)TestDBContext.Clientes.Where(a => a.Identificacion == identifcacion).FirstOrDefault();
        }


        public TestDBContext TestDBContext
        {
            get { return Context as TestDBContext; }
        }
    }
}
