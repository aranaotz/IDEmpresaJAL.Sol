using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TProgramas
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(500)]
        [DisplayName("Nombre del programa presupuestario")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int TipoProgramaId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public Guid DireccionGeneralId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(2500)]
        [DisplayName("Objetivo general")]
        public string? ObjetivoGeneral { get; set; }

        [DisplayName("Permitir multiples proyectos activos dentro de la misma convocatoria")]
        public bool PermiteMultiplesProyectos { get; set; }

        [DisplayName("Permitir que los solicitantes a esta convocatoria también tengan folios en otras convocatorias")]
        public bool PermiteMultiplesConvocatorias { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        public int BancaId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(20)]
        [DisplayName("Número de cuenta")]
        public string? Numcuenta { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(20)]
        [DisplayName("CLABE interbancaria")]
        public string? CLABE { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "decimal(20,2)")]
        [RegularExpression(@"^(0|[1-9][0-9]{0,2})(\d{3})*(\.\d{1,2})?$", ErrorMessage = "El número registrado no es correcto, favor de revisar.")]
        [DisplayName("Presupuesto autorizado")]
        public decimal Presupuesto { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50)]

        [DisplayName("Clave presupuestaria")]
        public string? ClavePresupuestaria { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(10)]
        [DisplayName("Código de denominación")]
        public string? CodigoDenominacion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50)]
        [DisplayName("Clave programa presupuestario")]
        public string? ClaveProgramaPresupuestal { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(1000)]
        [DisplayName("Descripción denominación de partida presupuestaria")]
        public string? DescripcionPartida { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Fecha de inicio")]
        public string? FechaInicio { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [DisplayName("Fecha de fin")]
        public string? FechaFin { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(50)]
        [DisplayName("Selecciona el color del programa")]
        public string? Color { get; set; }

        public string? FechaCreacion { get; set; }

        [MaxLength(4)]
        public string? Anio { get; set; }

        public int SistemaId { get; set; }

        public bool VoBoArea { get; set; }

        public bool VoBoPlaneacion { get; set; }

        public int EstatusProgramaId { get; set; }

        [ForeignKey("TipoProgramaId")]
        public CTipoPrograma? TipoPrograma { get; set; }

        [ForeignKey("DireccionGeneralId")]
        public CDireccionGeneral? DireccionGeneral { get; set; }

        [ForeignKey("BancaId")]
        public CBanca? Banca { get; set; }

        [ForeignKey("SistemaId")]
        public CSistemas? Sistema { get; set; }

        [ForeignKey("EstatusProgramaId")]
        public TProgramasEstatus? EstatusPograma { get; set; }

    }
}
