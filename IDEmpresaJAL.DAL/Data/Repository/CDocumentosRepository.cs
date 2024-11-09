using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CDocumentosRepository : GenericRepository<CDocumentos>, ICDocumentosRepository
    {
        private readonly ApplicationDbContext _context;

        public CDocumentosRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public List<CDocumentosTemp> ListaDocumentos(Guid id)
        {
            var result = _context.CDocumentos
                .Where(t1=> t1.Activo == true && t1.DireccionId == id)
                .Select( t1=> new CDocumentosTemp
                {
                   Id = t1.Id,
                   Documento = t1.Documento,
                   Descripcion = t1.Descripcion,
                   TipoDocumento= t1.TipoDocumento.TipoDocumento,
                   TipoCarga = t1.TipoCarga.TipoCarga

                }).ToList();

            return result;
        }

        public void Update(CDocumentos entity)
        {
            var objFromDB = _context.CDocumentos.FirstOrDefault(d=> d.Id == entity.Id);
            if (objFromDB != null) 
            {
                objFromDB.Documento= entity.Documento;
                objFromDB.Descripcion =entity.Descripcion;
                objFromDB.TipoDocumentoId = entity.TipoDocumentoId;
                objFromDB.TipoCargaId = entity.TipoCargaId;
                objFromDB.Nacional =entity.Nacional;
                objFromDB.Obligoatorio =entity.Obligoatorio;    
            }
        }

        public void UpdateDelete(CDocumentos entity)
        {
            var objFromDB = _context.CDocumentos.FirstOrDefault(d => d.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Activo = false;
            }
        }
    }
}
