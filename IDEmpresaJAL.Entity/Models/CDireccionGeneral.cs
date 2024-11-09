using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CDireccionGeneral
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100)]
        [Display(Name = "Nombre de la Dirección o Área")]
        public string? NombreDireccion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Nombre de la persona encargada")]
        [MaxLength(100)]
        public string? NombreEncargado { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Especifica el cargo de la persona encargada")]
        [MaxLength(100)]
        public string? EncargadoCargo { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Especifica el correo electrónico de la persona encargada")]
        [MaxLength(100)]
        public string? EncargadoCorreo { get; set; }

        [Display(Name = "Tiene programas a su cargo")]
        public bool TieneProgramas { get; set; }

        public string? FechaCreacion { get; set; }


        public bool Activo { get; set; } = true;
    }
}
