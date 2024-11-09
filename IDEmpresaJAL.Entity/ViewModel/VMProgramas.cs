using IDEmpresaJAL.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.ViewModel
{
    public class VMProgramas
    {
        public TProgramas Programas { get; set; }

        public IEnumerable<SelectListItem>? ListaTipoPrograma { get; set; }

        public IEnumerable<SelectListItem>? ListaDireccionesGenerales { get; set; }

        public IEnumerable<SelectListItem>? ListaBanca { get; set; }
    }
}
