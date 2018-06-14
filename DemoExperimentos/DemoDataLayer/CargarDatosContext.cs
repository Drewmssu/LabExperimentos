using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDataLayer
{
    public class CargarDatosContext
    {
        public ExperimentosEntities context { get; set; } = new ExperimentosEntities();
    }
}
