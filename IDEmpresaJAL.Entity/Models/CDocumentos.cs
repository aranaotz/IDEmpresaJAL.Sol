using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CDocumentos
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(500)]
        public string Documento { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Display(Name = "Descripción")]
        [MaxLength(2000)]
        public string Descripcion { get; set; }

        public Guid DireccionId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int TipoDocumentoId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int TipoCargaId { get; set; }

        public bool Obligoatorio { get; set; }

        public bool Nacional { get; set; }

        public string? FechaCreacion { get; set; }

        public bool Activo { get; set; }

        [ForeignKey("DireccionId")]
        public CDireccionGeneral? DireccionGeneral { get; set; }

        [ForeignKey("TipoDocumentoId")]
        public CDocumentosTipo? TipoDocumento { get; set; }

        [ForeignKey("TipoCargaId")]
        public CDocumentosTipoCarga? TipoCarga { get; set; }
    }
}
