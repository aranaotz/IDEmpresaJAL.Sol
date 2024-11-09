using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CTipoSolicitante
    {
        [Key]

        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100)]
        [Display(Name = "Tipo de solicitante")]
        public string? TipoSolicitante { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(500)]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }


        public string? FechaCreacion { get; set; }


        public bool Activo { get; set; } = true;
    }
}
