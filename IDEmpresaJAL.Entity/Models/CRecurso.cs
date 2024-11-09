using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.Entity.Models
{
    public class CRecurso
    {

        //este modelo se maneja por base de datos

        [Key]
        public int Id { get; set; }

        public string? Recurso { get; set; }

        public string? Descripcion { get; set; }

        public string? UrlArea { get; set; }

        public string? UrlControlador { get; set; }

        public string? UrlAccion { get; set; }

        public string? Icono {  get; set; } 

        [ForeignKey("ContenedorId")]
        public CRecursoContenedor? Contenedor { get; set; }


    }
}
