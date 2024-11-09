using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICTipoSolicitanteRepository : IGenericRepository<CTipoSolicitante>
    {
        void Update(CTipoSolicitante entity);

        void UpdateDelete(CTipoSolicitante entity);
    }
}
