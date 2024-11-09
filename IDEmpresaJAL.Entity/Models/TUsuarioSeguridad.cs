using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TUsuarioSeguridad
    {
        [Key]
        public int Id { get; set; }

        public Guid UsuarioId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(300)]
        public string? Password { get; set; }

      

        public string? FechaCreacion { get; set; }

        [ForeignKey("UsuarioId")]
        public TUsuario? Usuario { get; set; }
    }
}
