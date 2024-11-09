using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CDocumentosRequisitosRepository : GenericRepository<CDocumentosRequisitos>, ICDocumentosRequisitosRepository
    {
        private readonly ApplicationDbContext _context;

        public CDocumentosRequisitosRepository(ApplicationDbContext context): base(context)
        {
            _context= context;
        }

        public void Update(CDocumentosRequisitos entity)
        {
            var objFromDB = _context.CDocumentosRequisitos.FirstOrDefault(r=> r.Id==entity.Id);
            if (objFromDB != null) 
            {
                objFromDB.Requisito = entity.Requisito;
            }
        }

        public void UpdateDelete(CDocumentosRequisitos entity)
        {
            var objFromDB = _context.CDocumentosRequisitos.FirstOrDefault(r => r.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Activo = false;
            }
        }
    }
}
