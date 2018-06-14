using DemoExperimentos.ViewModels.Login;
using DemoLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoExperimentos.Controllers
{
    public class LoginController : BaseController
    {
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login", "Login");
        }
        public ActionResult Login()
        {
            var vm = new LoginViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    PostMessage(MessageType.Error, "Usuario y contraseña deben contar con 4 caracteres mínimo");
                    return View(model);
                }

                var password = CipherLogic.Encrypt(model.Password);
                var user = context.User.FirstOrDefault(x => x.Usuario == model.Username &&
                                                            x.Password == password);

                if (user != null)
                {
                    PostMessage(MessageType.Success, "Bienvenido");
                    Session["UserId"] = user.Id;

                    return RedirectToAction("ListDocente", "Teacher");
                }
                else
                {
                    PostMessage(MessageType.Error, "Usuario y/o Contraseña incorrectos");
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                PostMessage(MessageType.Error, "Intente de nuevo");
                TryUpdateModel(model);
                return View(model);
            }
        }
    }
}