using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CDocumentosRequisitos
    {
        [Key]
        public Guid Id { get; set; }

        public Guid DocumentoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(1000)]
        public string Requisito { get; set; }

        public string? FechaCreacion { get; set; }

        public bool Activo { get; set; }


        [ForeignKey("DocumentoId")]
        public CDocumentos? Documento { get; set; }
    }
}
