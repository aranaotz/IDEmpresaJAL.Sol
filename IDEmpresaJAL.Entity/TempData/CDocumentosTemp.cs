using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.TempData
{
    public class CDocumentosTemp
    {
        public Guid Id { get; set; }

        public string Documento { get; set; }

        public string Descripcion { get; set; }

        public string TipoDocumento { get; set; }

        public string TipoCarga { get; set; }
    }
}
