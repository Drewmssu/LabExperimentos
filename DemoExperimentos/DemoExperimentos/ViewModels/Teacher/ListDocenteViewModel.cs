using DemoDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DemoExperimentos.Helpers;

namespace DemoExperimentos.ViewModels.Teacher
{
    public class ListDocenteViewModel
    {
        public string Filtro { get; set; } = string.Empty;
        public List<Docente> LstDocente { get; set; } = new List<Docente>();

        internal void Fill(CargarDatosContext cargarDatosContext, string filtro)
        {
            this.Filtro = filtro;
            var query = cargarDatosContext.context.Docente.Where(x => x.Estado == ConstantHelper.Estado.ACTIVO).AsQueryable();

            if (!string.IsNullOrEmpty(this.Filtro))
            {
                foreach (var element in this.Filtro.Split(' '))
                {
                    query = query.Where(x => x.Apellido.Contains(element));
                }
            }

            this.LstDocente = query.OrderByDescending(x => x.Apellido).ToList();
        }
    }
}