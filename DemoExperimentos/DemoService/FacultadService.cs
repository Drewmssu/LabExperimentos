using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoDataLayer;
using Repository;

namespace DemoService
{
    public class FacultadService : IFacultadService
    {
        private readonly IFacultadRepository facultadRepository;

        public FacultadService()
        {
            this.facultadRepository = new EFFacultadRepository();
        }
        public IQueryable<Facultad> ListFacultad() => facultadRepository.Facultades;
    }
}
