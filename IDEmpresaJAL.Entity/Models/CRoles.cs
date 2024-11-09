using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CRoles
    {
        [Key]

        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Nombre del Rol")]
        public string? Rol { get; set; }

        public string? FechaCreacion { get; set; }


        public bool Activo { get; set; } = true;
    }
}
