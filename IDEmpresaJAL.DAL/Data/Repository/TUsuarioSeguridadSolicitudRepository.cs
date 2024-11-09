using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class TUsuarioSeguridadSolicitudRepository : GenericRepository<TUsuarioSeguridadSolicitud>, ITUsuarioSeguridadSolicitudRepository
    {
        private readonly ApplicationDbContext _context;

        public TUsuarioSeguridadSolicitudRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

       

        public void Update(TUsuarioSeguridadSolicitud entity)
        {
            var objFromDB = _context.TUsuarioSeguridadSolicitud.FirstOrDefault(us => us.UsuarioId == entity.UsuarioId);
            if (objFromDB != null) 
            {
                objFromDB.Request = entity.Request;
                objFromDB.FechaRegistro = entity.FechaRegistro;
                objFromDB.FechaCaducidad= entity.FechaCaducidad;    
                objFromDB.Usada = entity.Usada;
                objFromDB.Funcion= entity.Funcion;
            }
        }

        public void UpdateDelete(TUsuarioSeguridadSolicitud entity)
        {
            var objFromDB = _context.TUsuarioSeguridadSolicitud.FirstOrDefault(us => us.UsuarioId == entity.UsuarioId);
            if (objFromDB != null)
            {
                //no hay método para desactivar
            }
        }
    }
}
