using IDEmpresaJAL.DAL.Data.IRepository;

using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class TUsuarioSeguridadRepository : GenericRepository<TUsuarioSeguridad>, ITUsuarioSeguridadRepository
    {

        private readonly ApplicationDbContext _context;
       

        public TUsuarioSeguridadRepository(ApplicationDbContext context) : base(context) 
        {
            _context = context;
        }

        public TUsuarioSeguridad GetByRequest(string request)
        {
            return _dbSet.Find(request);
        }

       

        public void Update(TUsuarioSeguridad entity)
        {
            var objFromDB = _context.TUsuarioSeguridad.FirstOrDefault(ts => ts.UsuarioId == entity.UsuarioId);
            if (objFromDB != null) 
            { 
                objFromDB.Password = entity.Password;
                objFromDB.FechaCreacion = entity.FechaCreacion;
            }
        }

        public void UpdateDelete(TUsuarioSeguridad entity)
        {
            var objFromDB = _context.TUsuarioSeguridad.FirstOrDefault(ts => ts.Id == entity.Id);
            if (objFromDB != null)
            {
                //no tiene metodo para desactivar
            }
        }
    }
}
