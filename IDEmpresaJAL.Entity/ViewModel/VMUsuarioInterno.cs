using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using IDEmpresaJAL.Entity.TempData;

namespace IDEmpresaJAL.Entity.ViewModel
{
    public class VMUsuarioInterno
    {
        public TUsuario? Usuario { get; set; }

        public TUsuarioGenerales Generales { get; set; }

        public IEnumerable<SelectListItem>? ListaDirecciones { get; set; }

        public List<RUsuarioRolTemp> ListaRoles { get; set; }
    }
}
