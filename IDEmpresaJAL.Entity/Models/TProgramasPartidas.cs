using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class TProgramasPartidas
    {

        [Key]
        public Guid Id { get; set; }

        public Guid ProgramaId { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(5)]
        [Display(Name = "Código")]
        public string? Componente { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(1000)]
        [Display(Name = "Descripción del componente")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Este campo es obligatorio")]
        [MaxLength(46)]
        [Display(Name = "Partida presupuestal 46 digitos")]
        public string? Partida { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "decimal(20,2)")]
        [RegularExpression(@"^(0|[1-9][0-9]{0,2})(\d{3})*(\.\d{1,2})?$", ErrorMessage = "El número registrado no es correcto, favor de revisar.")]
        [DisplayName("Monto")]
        public decimal Monto { get; set; }


        [Required(ErrorMessage = "Este campo es obligatorio")]
        [Column(TypeName = "decimal(20,2)")]
        [RegularExpression(@"^(0|[1-9][0-9]{0,2})(\d{3})*(\.\d{1,2})?$", ErrorMessage = "El número registrado no es correcto, favor de revisar.")]
        public decimal MontoDisponible { get; set; }

        [ForeignKey("ProgramaId")]
        public TProgramas? Programa { get; set; }
    }
}
