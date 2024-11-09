using IDEmpresaJAL.DAL.Data.Repository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICCategoriasApoyoSIGARepository : IGenericRepository<CCategoriasApoyoSIGA>
    {
        void Update(CCategoriasApoyoSIGA entity);

        void UpdateDelete(CCategoriasApoyoSIGA entity);

        List<CategoriaSolicitanteTemp> ListaSolicitantes(Guid CategoairaID);
    }
}
