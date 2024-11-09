using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICDocumentosRepository : IGenericRepository<CDocumentos>
    {
        void Update(CDocumentos entity);

        void UpdateDelete(CDocumentos entity);

        List<CDocumentosTemp> ListaDocumentos(Guid id);
    }
}
