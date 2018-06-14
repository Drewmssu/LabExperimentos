using DemoDataLayer;
using System.Linq;

namespace Repository
{
    public interface IFacultadRepository
    {
        IQueryable<Facultad> Facultades { get; }
        Facultad Save(Facultad facultad);
    }
}
