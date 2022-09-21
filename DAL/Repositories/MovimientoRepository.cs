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
    public sealed class MovimientoRepository: GenericRepository<Movimiento>, IMovimientoRepository
    {
        public MovimientoRepository(TestDBContext context) : base(context)
        {
        }

        
        public TestDBContext TestDBContext
        {
            get { return Context as TestDBContext; }
        }
    }
}
