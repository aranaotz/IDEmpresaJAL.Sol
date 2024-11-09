using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CCategoriasApoyoSIGA
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DireccionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(500)]
        public string? Categoria { get; set; }

        public bool TieneEmpleados { get; set; }

        [Display(Name = "Desde")]
        //[Required(ErrorMessage = "Este campo es obligatorio")]
        //[Range(1, 1000,
        //ErrorMessage = "El valor debe estar entre {1} y {2}.")]
        public int? EmpleadosMin { get; set; } =0;

        [Display(Name = "Hasta")]
        //[Required(ErrorMessage = "Este campo es obligatorio")]
        //[Range(1, 1000,
        //ErrorMessage = "El valor debe estar entre {1} y {2}.")]
        public int? EmpleadosMax { get; set; } = 0;

        public string? FechaCreacion { get; set; }

        public bool Activo { get; set; }

        [ForeignKey("DireccionId")]
        public CDireccionGeneral? Direccion { get; set; }
    }
}
