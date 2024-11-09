using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CSistemas
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100)]
        public string? Sistema { get; set; }

        [MaxLength(255)]
        public string? RutaImagen { get; set; }

        [MaxLength(4)]
        public string? TamanoImagen { get; set; }

        [MaxLength(100)]
        public string? DescripcionImagen { get; set; }

        public bool MensajeVisible { get; set; }

        
        public string? Mensaje { get; set; }

        public bool Activo { get; set; }

        [MaxLength(20)]
        public string? Session { get; set; }
    }
}
