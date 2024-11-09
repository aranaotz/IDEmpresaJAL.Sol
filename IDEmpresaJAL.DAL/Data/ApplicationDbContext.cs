
using IDEmpresaJAL.Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base (options)
        {
        }
        //poner aqui todos los modelos que se vayan creando
        //gestion
        public DbSet<CTipoSolicitante> CTipoSolicitante { get; set; }
        public DbSet<CDireccionGeneral> CDireccionGeneral { get; set; }

        //Roles 
       
        public DbSet<CRoles> CRoles { get; set; }
        public DbSet<CRecurso> CRecurso { get; set; }
        public DbSet<CRecursoContenedor> CRecursoContenedor { get; set; }
        public DbSet<RRolRecurso> RRolRecurso { get; set; }

        //Usuarios
        public DbSet<TUsuario> TUsuario { get; set; }
        public DbSet<TUsuarioGenerales> TUsuarioGenerales { get; set; }
        public DbSet<TUsuarioSeguridad> TUsuarioSeguridad {  get; set; }
        public DbSet<TUsuarioSeguridadSolicitud> TUsuarioSeguridadSolicitud { get; set; }
        public DbSet<RUsuarioRol> RUsuarioRol { get; set; }

        //Catalogo de documentos
        public DbSet<CDocumentos> CDocumentos { get; set; }
        public DbSet<CDocumentosTipo> CDocumentosTipo { get; set; }
        public DbSet<CDocumentosTipoCarga> CDocumentosTipoCarga { get; set; }
        public DbSet<CDocumentosRequisitos> CDocumentosRequisitos { get; set; }

        //Categorías de apoyo SIGA
        public DbSet<CCategoriasApoyoSIGA> CCategorias {  get; set; }   
        public DbSet<CCategoriasApoyoSIGA_TipoSolicitantes> CCategoriasTipoSolicitante { get; set; }
        public DbSet<CTipoPrograma> CTipoPrograma { get; set; }
        public DbSet<CSistemas> CSistemas { get; set; }
        public DbSet<TProgramas> TProgramas { get; set; }
        public DbSet<TProgramasPartidas> TProgramasPartidas { get; set; }
        public DbSet<TProgramasEstatus> TProgramasEstatus { get; set; }
        public DbSet<TProgramasObservaciones> TProgramasObservaciones { get; set; }

        //Catálogo de instituciones bancarias
        public DbSet<CBanca> CBanca { get; set; }

    }
}
