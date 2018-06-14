using DemoDataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoExperimentos.ViewModels.Teacher
{
    public class AddEditDocenteViewModel
    {
        public int? DocenteId { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo requerido")]
        public string Apellido { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "DNI debe contar con 8 dígitos")]
        public string DNI { get; set; } = string.Empty;
        [Required(ErrorMessage = "Campo requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Seleccione una opción")]
        public string Sexo { get; set; } = string.Empty;
        [Display(Name = "Bonificación")]
        public bool Bonificacion { get; set; } = false;
        [Required(ErrorMessage = "Seleccione una facultad")]
        [Display(Name = "Facultad")]
        public int FacultadId { get; set; }

        public List<Facultad> LstFacultad { get; set; } = new List<Facultad>();

        internal void Fill(CargarDatosContext cargarDatosContext, int? docenteId)
        {
            var teacher = cargarDatosContext.context.Docente.Find(docenteId);

            if (teacher != null)
            {
                this.DocenteId = teacher.Id;
                this.Nombre = teacher.Nombre;
                this.Apellido = teacher.Apellido;
                this.Descripcion = teacher.Descripcion;
                this.FechaNacimiento = teacher.FechaNacimiento;
                this.Sexo = teacher.Sexo;
                this.DNI = teacher.DNI;
                this.FacultadId = teacher.FacultadId;
            }

            this.LstFacultad = cargarDatosContext.context.Facultad.ToList();
        }
    }
}