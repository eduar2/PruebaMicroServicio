using Core.Domains;
using System.Collections.Generic;

namespace BusinessApplication.Interfaces
{
    public interface IPersonaService
    {
        bool CreatePersona(ref Persona persona, ref string mensaje);
        bool UpdatePersona(ref Persona persona, ref string mensaje);
        bool DeletePersona(string identificacion, ref string mensaje);
        List<Persona> ConsultPersonas();

        public Persona FindPersona(string identificacion);

        public Persona FindPersona(int id);
    }
}
