using IDEmpresaJAL.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.ViewModel
{
    public class VMCDocumentos
    {
        public CDocumentos Documentos { get; set; }

        public Guid DireccionGeneralId { get; set; }

        public IEnumerable<SelectListItem> ListaTipoDocumento { get; set; }

        public IEnumerable<SelectListItem> ListaTipoCarga {  get; set; }

        
    }
}
