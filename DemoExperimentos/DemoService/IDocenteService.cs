using DemoDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoService
{
    public interface IDocenteService
    {
        IQueryable<Docente> ListDocente();
        IQueryable<Docente> ListDocenteByLastName(string lastName);
        Docente AddDocente(Docente docente);
        Docente DeleteDocente(int docenteId);
        Docente FindDocente(int docenteId);
    }
}
