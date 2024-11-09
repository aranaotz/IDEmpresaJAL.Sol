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
    public class TUsuarioRepository : GenericRepository<TUsuario>, ITUsuarioRepository
    {
        private readonly ApplicationDbContext _context;

        public TUsuarioRepository(ApplicationDbContext context): base(context)
        {
            _context = context;
        }

       

        public void Update(TUsuario entity)
        {
            var objFromDB = _context.TUsuario.FirstOrDefault(u => u.Id == entity.Id);
            if (objFromDB != null) 
            {
                objFromDB.Usuario = entity.Usuario;
                objFromDB.Activo = true;
            }
        }

        public void UpdateDelete(TUsuario entity)
        {
            var objFromDB = _context.TUsuario.FirstOrDefault(u => u.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Activo=false;
            }
        }
    }
}
