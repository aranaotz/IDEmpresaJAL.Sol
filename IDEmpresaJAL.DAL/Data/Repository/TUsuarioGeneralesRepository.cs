using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using IDEmpresaJAL.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class TUsuarioGeneralesRepository : GenericRepository<TUsuarioGenerales>, ITUsuarioGeneralesRepository
    {
        private readonly ApplicationDbContext _context;

        public TUsuarioGeneralesRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public List<RUsuarioRolTemp> ListaRoles(Guid UsuarioId)
        {
            var query = from t1 in _context.CRoles
                        where t1.Activo == true
                        join t2 in _context.RUsuarioRol
                        .Where(r => r.UsuarioId == UsuarioId) on t1.Id equals t2.RolId into joined
                        from t2 in joined.DefaultIfEmpty()
                        select new RUsuarioRolTemp
                        {
                            Id = t1.Id,
                            Rol = t1.Rol,
                            Seleccionado = t2 != null
                        };

            return query.ToList();
        }

        public List<TUsuarioGeneralesTemp> ListaUsuarios()
        {
            var query = from t1 in _context.TUsuarioGenerales
                         join t2 in _context.CDireccionGeneral
                         on t1.DireccionGeneralId equals t2.Id into t2Group
                         from t2 in t2Group.DefaultIfEmpty()
                         join t3 in _context.TUsuario on t1.UsuarioId equals t3.Id into t3Group
                         from t3 in t3Group.DefaultIfEmpty()
                         select new TUsuarioGeneralesTemp
                         {
                             UsuarioId= t1.UsuarioId,
                             RFC= t1.RFC,
                             Usuario = t1.Nombre + " " + t1.PrimerApellido + " " + t1.SegundoApellido,
                             CorreoElectronico= t1.CorreoElectronico,
                             NombreDireccion = t2.NombreDireccion,
                             Activo = t3.Activo
                         };

            return query.ToList();

        }

        public void Update(TUsuarioGenerales entity)
        {
            var objFromDB = _context.TUsuarioGenerales.FirstOrDefault(u=> u.UsuarioId == entity.UsuarioId);
            if (objFromDB != null) 
            {
                objFromDB.Nombre = entity.Nombre;
                objFromDB.PrimerApellido = entity.PrimerApellido;   
                objFromDB.SegundoApellido = entity.SegundoApellido; 
                objFromDB.RFC=entity.RFC;   
                objFromDB.CorreoElectronico = entity.CorreoElectronico;
                objFromDB.FechaCreacion = entity.FechaCreacion;
                objFromDB.DireccionGeneralId = entity.DireccionGeneralId;
            }
        }

        public void UpdateDelete(TUsuarioGenerales entity)
        {
            var objFromDB = _context.TUsuarioGenerales.FirstOrDefault(u => u.Id == entity.Id);
            if (objFromDB != null)
            {
                //no hay metodo para desactivar
            }
        }

        

    }
}
