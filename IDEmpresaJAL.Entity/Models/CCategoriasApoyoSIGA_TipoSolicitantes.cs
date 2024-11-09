using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CCategoriasApoyoSIGA_TipoSolicitantes
    {
        [Key]
        public int Id { get; set; }

        public Guid CategoriaId { get; set; }

        public Guid TipoSolicitanteId { get; set; }

        [ForeignKey("CategoriaId")]
        public CCategoriasApoyoSIGA? Categoria { get; set; }

        [ForeignKey("TipoSolicitanteId")]
        public CTipoSolicitante? TipoSolicitante { get; set; }
    }
}
