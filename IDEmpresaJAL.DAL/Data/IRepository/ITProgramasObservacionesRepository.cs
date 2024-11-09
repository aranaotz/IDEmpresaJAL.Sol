using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ITProgramasObservacionesRepository: IGenericRepository<TProgramasObservaciones>
    {
        void Update(TProgramasObservaciones entity);

        void UpdateDelete(TProgramasObservaciones entity);

    }
}
