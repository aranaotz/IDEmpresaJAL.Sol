using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CDocumentosTipoCarga
    {

        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        public string TipoCarga { get; set; }

        [MaxLength(255)]
        public string ValidationExpression { get; set; }

        [MaxLength(255)]
        public string MensajeValidacion { get; set; }

        [MaxLength(255)]
        public string MensajeDescripcion { get; set; }
    }
}
