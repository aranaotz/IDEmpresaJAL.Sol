using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TUsuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(30)]
        public string? Usuario { get; set; }

        public bool Activo { get; set; } = false;
    }
}
