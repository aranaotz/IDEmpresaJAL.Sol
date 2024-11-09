using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
     public interface ICRecursoRepository : IGenericRepository<CRecurso>
    {
        void Update(CRecurso entity);

       
    }

    

}
