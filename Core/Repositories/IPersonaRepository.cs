using Core.Domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repositories
{
    public interface IPersonaRepository: IGenericRepository<Persona>
    {

        Persona Get(string identificacion);
    }
}
