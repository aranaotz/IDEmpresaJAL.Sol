using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.DAL.Data.Repository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.IoC.IRepository
{
    public interface IContenedorTrabajo : IDisposable
    {
        //aqui se van a agregar los diferentes depositorios
        //Gestion
        ICTipoSolicitanteRepository CTipoSolicitante { get; }
        ICDireccionGeneralRepository CDireccionGeneral { get; }
        //Roles
        ICRolRepository CRol {  get; }
        IRRolRecursoRepository RolRecurso { get; }
        ICRecursoRepository CRecurso { get; }
        ICRecursoContenedorRepository CRecursoContenedor { get; }
        //usuarios
        ITUsuarioRepository TUsuario { get; }
        ITUsuarioGeneralesRepository TUsuarioGenerales { get; }
        ITUsuarioSeguridadRepository TUsuarioSeguridad { get; }
        ITUsuarioSeguridadSolicitudRepository TUsuarioSeguridadSolicitud { get; }
        IRUsuarioRolRepository UsuarioRol { get; }

        //Catalogo de documentos

        ICDocumentosRepository CDocumentos { get; }
        ICDocumentosTipoRepository CDocumentosTipo { get; }
        ICDocumentosTipoCargaRepository CDocumentosTipoCarga { get; }
        ICDocumentosRequisitosRepository CDocumentosRequisitos { get; }

        //Categorías de apoyo siga
        ICCategoriasApoyoSIGARepository CCategorias { get; }
        ICCategoriasApoyoSIGA_TipoSolicitantesRepository CCategoriasTipoSolicitante {  get; }

        //catatolo de bancos
        ICBancaRepository CBanca { get; }

        //Programas y Convocatorias
        ITProgramasRepository TProgramas { get; }
        ITProgramasPartidasRepository TProgramasPartidas { get; }
        ICTipoProgramaRepository CTipoPrograma { get; }
        TProgramasObservacionesRepository TProgramasObservaciones { get; }    




        void Save();
    }
}
