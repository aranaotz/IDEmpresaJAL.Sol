using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.ViewModel
{
    public class VMLogin
    {
        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? usuario { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public string? password { get; set; }

        

    }
}
