using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.ViewModel
{
    public class VMRecurso
    {
        public CRoles RolesEntity { get; set; }

        public List<RRolRecursoTemp> ListaRecursos { get; set; }


        public RRolRecurso RRolRecurso { get; set; }
    }
}
