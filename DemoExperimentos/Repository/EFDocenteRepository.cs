using System.Data.Entity;
using System.Linq;
using DemoDataLayer;

namespace Repository
{
    public class EFDocenteRepository : IDocenteRepository
    {
        private readonly ExperimentosEntities context = new ExperimentosEntities();
        public IQueryable<Docente> Docentes
        { get { return context.Docente.Where(x => x.Estado == "ACT"); } }

        public IQueryable<Docente> DocentesByLastName(string lastName)
        {
            return context.Docente.Where(x => x.Estado == "ACT" &&
                                              x.Apellido == lastName);
        }
        public Docente FindOne(int docenteId)
        {
            return docenteId > 0 ? context.Docente.FirstOrDefault(x => x.Id == docenteId) : null;
        }

        public Docente Save(Docente docente)
        {
            if (docente.Id == 0)
            {
                docente.Estado = "ACT";
                context.Docente.Add(docente);
            }
            else
            {
                context.Entry(docente).State = EntityState.Modified;
            }

            context.SaveChanges();

            return docente;
        }
    }
}
