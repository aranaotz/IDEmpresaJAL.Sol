using IDEmpresaJAL.BLL.IRepository;
using IDEmpresaJAL.DAL.Data;
using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.DAL.Data.Repository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.IoC.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.IoC.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _context;

        public ContenedorTrabajo(ApplicationDbContext context)
        {
            _context = context;
            //Aregegar repositorios
            //Gestion
            CTipoSolicitante = new CTipoSolicitanteRepository(_context);
            CDireccionGeneral =  new CDireccionGeneralRepository(_context);
            //roles
            CRol = new CRolRepository(_context);
            RolRecurso = new RRolRecursoRepository(_context);
            CRecurso = new CRecursoRepository(_context);
            CRecursoContenedor = new CRecursoContenedorRepository(_context);
            //usuarios
            TUsuario = new TUsuarioRepository(_context);
            TUsuarioGenerales = new TUsuarioGeneralesRepository(_context);
            TUsuarioSeguridad = new TUsuarioSeguridadRepository(_context);
            TUsuarioSeguridadSolicitud = new TUsuarioSeguridadSolicitudRepository(_context);
            UsuarioRol = new RUsuarioRolRepository(_context);

            //Catalogo de documentos
            CDocumentos = new CDocumentosRepository(_context);
            CDocumentosTipo = new CDocumentosTipoRepository(_context);
            CDocumentosTipoCarga = new CDocumentosTipoCargaRepositoty(_context);
            CDocumentosRequisitos = new CDocumentosRequisitosRepository(_context);

            //Categorías de apoyo
            CCategorias = new CCategoriasApoyoSIGARepository(_context);
            CCategoriasTipoSolicitante = new CCategoriasApoyoSIGA_TipoSolicitantesRepository(_context);

            //catálogo de bancos
            CBanca =  new CBancaRepository(_context);

            //Programas y convocatorias
            TProgramas = new TProgramasRepository(_context);
            TProgramasPartidas = new TProgramasPartidasRepository(_context);
            CTipoPrograma =  new CTipoProgramaRepository(_context);
            TProgramasObservaciones = new TProgramasObservacionesRepository(_context);
           
        }

        public ICTipoSolicitanteRepository CTipoSolicitante { get; private set; }

        public ICDireccionGeneralRepository CDireccionGeneral { get; private set; }

        public ICRolRepository CRol { get; private set; }

        public IRRolRecursoRepository RolRecurso { get; private set; }

        public ITUsuarioRepository TUsuario { get; private set; }

        public ITUsuarioGeneralesRepository TUsuarioGenerales { get; private set; }

        public ITUsuarioSeguridadRepository TUsuarioSeguridad { get; private set; }

        public ITUsuarioSeguridadSolicitudRepository TUsuarioSeguridadSolicitud { get; private set; }

        public IRUsuarioRolRepository UsuarioRol { get; private set; }

        public IUtilidadesRepository Utilidades { get; private set; }

        public ICRecursoRepository CRecurso { get; private set; }

        public ICRecursoContenedorRepository CRecursoContenedor { get; private set; }

        public ICDocumentosRepository CDocumentos { get; private set; }

        public ICDocumentosTipoRepository CDocumentosTipo { get; private set; }

        public ICDocumentosTipoCargaRepository CDocumentosTipoCarga { get; private set; }

        public ICDocumentosRequisitosRepository CDocumentosRequisitos { get; private set; }

        public ICCategoriasApoyoSIGARepository CCategorias { get; private set; }

        public ICCategoriasApoyoSIGA_TipoSolicitantesRepository CCategoriasTipoSolicitante { get; private set; }

        public ITProgramasRepository TProgramas { get; private set; }

        public ICTipoProgramaRepository CTipoPrograma { get; private set; }

        public ICBancaRepository CBanca { get; private set; }

        public ITProgramasPartidasRepository TProgramasPartidas {  get; private set; }

        public TProgramasObservacionesRepository TProgramasObservaciones { get; private set; }

       

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
           _context?.Dispose();
        }
    }
}
