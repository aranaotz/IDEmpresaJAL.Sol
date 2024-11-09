using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CTipoSolicitanteRepository : GenericRepository<CTipoSolicitante>, ICTipoSolicitanteRepository
    {
        private readonly ApplicationDbContext _context;

        public CTipoSolicitanteRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public void Update(CTipoSolicitante entity)
        {
            var objFromDb = _context.CTipoSolicitante.FirstOrDefault(ts => ts.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.TipoSolicitante = entity.TipoSolicitante;
                objFromDb.Descripcion = entity.Descripcion;
                objFromDb.FechaCreacion = entity.FechaCreacion;
            }
        }

        public void UpdateDelete(CTipoSolicitante entity)
        {
            var objFromDb = _context.CTipoSolicitante.FirstOrDefault(ts => ts.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.Activo = false;
            }
        }
    }
}
