using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class RUsuarioRol
    {
        [Key]
        public int Id { get; set; }

        public Guid UsuarioId { get; set; }

        public int RolId { get; set; }

        [ForeignKey("UsuarioId")]
        public TUsuario? Usuario { get; set; }

        [ForeignKey("RolId")]
        public CRoles? Rol { get; set; }

    }
}
