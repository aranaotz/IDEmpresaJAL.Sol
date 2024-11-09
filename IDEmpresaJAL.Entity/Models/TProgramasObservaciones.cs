using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TProgramasObservaciones
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProgramaId { get; set; }

        [Required(ErrorMessage ="Este campo es obligatorio")]
        [MaxLength(1000)]
        public string? Observaciones { get; set; }

        public string? FechaCreacion { get; set; }

        public bool Activo { get; set; }

        [ForeignKey("ProgramaId")]
        public TProgramas? Programa { get; set; }
    }
}
