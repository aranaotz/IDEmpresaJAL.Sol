using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CBanca
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(255)]
        public string? Banca { get; set; }

        [MaxLength(1000)]
        public string? Descripcion { get; set; }

        public bool Activo { get; set; }
    }
}
