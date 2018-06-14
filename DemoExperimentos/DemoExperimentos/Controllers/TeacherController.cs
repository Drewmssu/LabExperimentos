using DemoDataLayer;
using DemoExperimentos.Helpers;
using DemoExperimentos.ViewModels.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace DemoExperimentos.Controllers
{
    public class TeacherController : BaseController
    {
        public ActionResult ListDocente(CargarDatosContext cargarDatosContext, string Filtro)
        {
            if (Session["UserId"] is null)
                return RedirectToAction("Login", "Login");

            var vm = new ListDocenteViewModel();
            vm.Fill(cargarDatosContext, Filtro);

            return View(vm);
        }

        public ActionResult AddEditDocente(CargarDatosContext cargarDatosContext, int? DocenteId)
        {
            if (Session["UserId"] is null)
                return RedirectToAction("Login", "Login");

            var vm = new AddEditDocenteViewModel();
            vm.Fill(cargarDatosContext, DocenteId);
            return View(vm);
        }

        [HttpPost]
        public ActionResult AddEditDocente(AddEditDocenteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                PostMessage(MessageType.Error, "Revise los campos");
                TryUpdateModel(model);
                return View(model);
            }

            try
            {
                using (var ts = new TransactionScope())
                {
                    var teacher = context.Docente.Find(model.DocenteId);

                    if (teacher is null)
                    {
                        teacher = new Docente();
                        teacher.Estado = ConstantHelper.Estado.ACTIVO;

                        context.Docente.Add(teacher);
                    }

                    teacher.Nombre = model.Nombre;
                    teacher.Apellido = model.Apellido;
                    teacher.DNI = model.DNI;
                    teacher.FechaNacimiento = model.FechaNacimiento;
                    teacher.Descripcion = model.Descripcion;
                    teacher.Sexo = model.Sexo;
                    teacher.Bonificacion = model.Bonificacion;
                    teacher.FacultadId = model.FacultadId;
                    teacher.UpdatedBy = (int)Session["UserId"];

                    context.SaveChanges();
                    ts.Complete();
                    PostMessage(MessageType.Success, "Cambios realizados satisfactoriamente");

                    return RedirectToAction("ListDocente", "Teacher");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                TryUpdateModel(model);
                PostMessage(MessageType.Error, "Ha ocurrido un error");
                return View(model);
            }
        }

        public PartialViewResult _DeleteDocente(int DocenteId)
        {
            var vm = new DeleteDocenteViewModel();
            vm.DocenteId = DocenteId;
            return PartialView(vm);
        }


        [HttpPost]
        public ActionResult DeleteDocente(DeleteDocenteViewModel model)
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    var teacher = context.Docente.Find(model.DocenteId);

                    if (teacher is null)
                        return null;

                    teacher.Estado = ConstantHelper.Estado.INACTIVO;

                    context.SaveChanges();
                    ts.Complete();
                    PostMessage(MessageType.Success, "Docente eliminado correctamente");

                    return RedirectToAction("ListDocente", "Teacher");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new EmptyResult();
            }
        }
    }
}