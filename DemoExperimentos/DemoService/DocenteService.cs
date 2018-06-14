using DemoDataLayer;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoService
{
    public class DocenteService : IDocenteService
    {
        private readonly IDocenteRepository docenteRepository;
        public DocenteService()
        {
            this.docenteRepository = new EFDocenteRepository();
        }
        public IQueryable<Docente> ListDocente() => docenteRepository.Docentes;

        public IQueryable<Docente> ListDocenteByLastName(string lastName) => docenteRepository.DocentesByLastName(lastName);

        public Docente AddDocente(Docente docente) => docenteRepository.Save(docente);

        public Docente FindDocente(int docenteId) => docenteRepository.FindOne(docenteId);

        public Docente DeleteDocente(int docenteId)
        {
            var docente = docenteRepository.FindOne(docenteId);
            docente.Estado = "INA";
            return docenteRepository.Save(docente);
        }

    }
}
