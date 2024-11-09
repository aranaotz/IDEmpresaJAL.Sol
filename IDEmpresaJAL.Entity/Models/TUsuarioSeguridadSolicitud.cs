using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TUsuarioSeguridadSolicitud
    {
        [Key]
        public int Id { get; set; }

        public Guid UsuarioId { get; set; }

        public string? Request { get; set; }

        public string? FechaRegistro { get; set; }

        public string? FechaCaducidad { get; set; }

        public bool Usada { get; set; } = false;

        public int Funcion { get; set; }

        [ForeignKey("UsuarioId")]
        public TUsuario? Usuario { get; set; }
    }
}
