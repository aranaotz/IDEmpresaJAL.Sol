using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class RRolRecurso
    {

        [Key]
        public int Id { get; set; }

        public int RolId { get; set; }

        public int RecursoId { get; set; }

        [ForeignKey("RolId")]
        public CRoles? Rol { get; set; }

        [ForeignKey("RecursoId")]
        public CRecurso? Recurso { get; set; }

       
    }
}
