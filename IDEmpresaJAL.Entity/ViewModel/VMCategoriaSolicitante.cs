using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.ViewModel
{
    public class VMCategoriaSolicitante
    {
        public CCategoriasApoyoSIGA CategoriaEntity { get; set; }

        public List<CategoriaSolicitanteTemp> ListaSolicitante { get; set; }

        public CCategoriasApoyoSIGA_TipoSolicitantes? CategoriaSolicitanteEntity { get; set; }
    }
}
