using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoExperimentos.ViewModels.Login
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Este campo es requerido")]
        [MinLength(4)]
        [Display(Name = "Nombre")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Este campo es requerido")]
        [DataType(DataType.Password)]
        [MinLength(4)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; } = string.Empty;
    }
}