using System;
using System.Data.Entity;
using System.Linq;
using DemoDataLayer;

namespace Repository
{
    public class EFFacultadRepository : IFacultadRepository
    {
        private readonly ExperimentosEntities context = new ExperimentosEntities();
        public IQueryable<Facultad> Facultades
        { get { return context.Facultad; } }

        public Facultad Save(Facultad facultad)
        {
            if (facultad.Id == 0)
            {
                context.Facultad.Add(facultad);
            }
            else
            {
                context.Entry(facultad).State = EntityState.Modified;
            }

            context.SaveChanges();

            return facultad;
        }
    }
}
