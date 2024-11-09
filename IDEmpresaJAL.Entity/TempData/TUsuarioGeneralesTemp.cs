using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.TempData
{
    public class TUsuarioGeneralesTemp
    {
        public Guid UsuarioId { get; set; }

        public string RFC { get; set; }

        public string Usuario { get; set; }

        public string CorreoElectronico { get; set; }

        public string NombreDireccion { get; set; }

        public bool Activo { get; set; }
    }
}
