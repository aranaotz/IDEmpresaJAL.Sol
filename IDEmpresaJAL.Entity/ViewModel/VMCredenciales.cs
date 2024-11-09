using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.ViewModel
{
     public class VMCredenciales
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MultipleRegExAttribute1(@"^.{8,}$", ErrorMessage ="La contraseña debe tener por lo menos 8 caracteres")]
        [MultipleRegExAttribute2(@"^(?=.*?[0-9]).{8,}$", ErrorMessage = "La contraseña debe tener por lo menos un dígito (0 a 9)")]
        [MultipleRegExAttribute3(@"^(?=.*?[A-Z]).{8,}$", ErrorMessage = "La contraseña debe tener por lo menos una letra mayúscula")]
        [MultipleRegExAttribute4(@"^(?=.*?[a-z]).{8,}$", ErrorMessage = "La contraseña debe tener por lo menos una letra minúscula")]
        [MultipleRegExAttribute5(@"^(?=(?:.*[@$?¡\-_]){1})\S{8,}$", ErrorMessage = "La contraseña debe tener por lo menos un carácter especial (No espacios)")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Compare(nameof(Password), ErrorMessage = "Las contraseñas no coinciden")]
       
        public string? ConfirmPassword { get; set; }

        public string? request { get; set; }

        
    }

    public class MultipleRegExAttribute1 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute1(string pattern) : base(pattern) { }
    }

    public class MultipleRegExAttribute2 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute2(string pattern) : base(pattern) { }
    }

    public class MultipleRegExAttribute3 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute3(string pattern) : base(pattern) { }
    }

    public class MultipleRegExAttribute4 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute4(string pattern) : base(pattern) { }
    }

    public class MultipleRegExAttribute5 : RegularExpressionAttribute
    {
        public MultipleRegExAttribute5(string pattern) : base(pattern) { }
    }

}
