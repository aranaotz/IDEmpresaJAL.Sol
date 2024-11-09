using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class TProgramasObservacionesRepository : GenericRepository<TProgramasObservaciones>, ITProgramasObservacionesRepository
    {
        private readonly ApplicationDbContext _context;

        public TProgramasObservacionesRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(TProgramasObservaciones entity)
        {
            var objFromDB= _context.TProgramasObservaciones.FirstOrDefault(x=> x.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Observaciones = entity.Observaciones;
            }
        }

        public void UpdateDelete(TProgramasObservaciones entity)
        {
            var objFromDB = _context.TProgramasObservaciones.FirstOrDefault(x => x.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Activo = false;
            }
        }
    }
}
