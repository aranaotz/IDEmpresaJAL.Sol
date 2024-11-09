using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using IDEmpresaJAL.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class RUsuarioRolRepository : GenericRepository<RUsuarioRol>, IRUsuarioRolRepository
    {
        private readonly ApplicationDbContext _context;

        public RUsuarioRolRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;   
        }

        public List<MenuTemp> ListaMenu(Guid usuarioId)
        {
            var query1 = (from t1 in _context.RUsuarioRol
                         join t2 in _context.RRolRecurso on t1.RolId equals t2.RolId into rolRecursoGroup
                         from t2 in rolRecursoGroup.DefaultIfEmpty()
                         join t3 in _context.CRecurso on t2.RecursoId equals t3.Id into recursoGroup
                         from t3 in recursoGroup.DefaultIfEmpty()
                         join t4 in _context.CRecursoContenedor on t3.Contenedor.Id equals t4.Id into contenedorGroup
                         from t4 in contenedorGroup.DefaultIfEmpty()
                         where t1.UsuarioId == usuarioId
                         select new MenuTemp
                         {
                             N = 1,
                             ContenedorId = t4.Id.ToString(),
                             Contenedor = t4.Contenedor,
                             IconoContenedor = t4.Icono,
                             RecursoId = "",
                             Recurso = "",
                             Area = "",
                             Controlador = "",
                             Accion = "",
                             IconoRecurso = "",
                             ContenedorPadre = t4.Id.ToString()
                         }).Distinct();

            var query2 = from t1 in _context.RUsuarioRol
                         join t2 in _context.RRolRecurso on t1.RolId equals t2.RolId into rolRecursoGroup
                         from t2 in rolRecursoGroup.DefaultIfEmpty()
                         join t3 in _context.CRecurso on t2.RecursoId equals t3.Id into recursoGroup
                         from t3 in recursoGroup.DefaultIfEmpty()
                         where t1.UsuarioId == usuarioId
                         select new MenuTemp
                         {
                             N = 2,
                             ContenedorId = "",
                             Contenedor = "",
                             IconoContenedor = "",
                             RecursoId = t3.Id.ToString(),
                             Recurso = t3.Recurso,
                             Area = t3.UrlArea,
                             Controlador = t3.UrlControlador,
                             Accion = t3.UrlAccion,
                             IconoRecurso = t3.Icono,
                             ContenedorPadre = t3.Contenedor.Id.ToString()
                         };

            var combinedQuery = query1.Union(query2).OrderBy(a=> a.ContenedorPadre);

            var result = combinedQuery.ToList();

            return result.Select(x => new MenuTemp
            {
                N = x.N,
                ContenedorId = x.ContenedorId,
                Contenedor = x.Contenedor,
                IconoContenedor = x.IconoContenedor,
                RecursoId = x.RecursoId,
                Recurso = x.Recurso,
                Area = x.Area,
                Controlador = x.Controlador,
                Accion = x.Accion,
                IconoRecurso = x.IconoRecurso,
                ContenedorPadre = x.ContenedorPadre
            }).ToList();

        }

       

        public void Update(RUsuarioRol entity)
        {
            //no se actualiza

        }

        public void UpdateDelete(RUsuarioRol entity)
        {
            //no se actualiza
        }
    }
}
