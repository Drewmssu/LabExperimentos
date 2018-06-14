using DemoDataLayer;
using System.Linq;

namespace Repository
{
    public interface IDocenteRepository
    {
        IQueryable<Docente> Docentes { get; }
        IQueryable<Docente> DocentesByLastName(string lastName);
        Docente Save(Docente docente);
        Docente FindOne(int docenteId);
    }
}
