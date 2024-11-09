using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.TempData
{
    public class CategoriaSolicitanteTemp
    {
        public Guid Id { get; set; }

        public string TipoSolicitante { get; set; }

        public bool Seleccionado { get; set; }

    }
}
