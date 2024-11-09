using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CRecursoContenedor
    {
        [Key]
        public int Id { get; set; }

        public string? Contenedor { get; set; }

        public string? Icono { get; set; }

      
        public bool Activo { get; set; }
    }
}
