using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TUsuarioGenerales
    {

        [Key]
        public int Id { get; set; }

        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Primer apellido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50)]
        [Display(Name = "Segundo apellido")]
        public string SegundoApellido { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30)]
        [Display(Name = "RFC")]
        public string RFC { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(100)]
        [EmailAddress(ErrorMessage = "No parece un correo válido")]
        [Display(Name = "Correo electrónico")]

        public string? CorreoElectronico { get; set; }

        public string? FechaCreacion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Guid DireccionGeneralId { get; set; }

        [ForeignKey("UsuarioId")]
        public TUsuario? Usuario { get; set; }

        [ForeignKey("DireccionGeneralId")]
        public CDireccionGeneral? DireccionGeneral { get; set; }

    }
}
