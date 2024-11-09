using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CDocumentosTipo
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string TipoDocumento { get; set; }

        public bool Activo { get; set; }
    }
}
