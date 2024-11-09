using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ITProgramasRepository :IGenericRepository<TProgramas>
    {
        void Update(TProgramas entity);

        void UpdateVoBo(TProgramas entity);

        
    }
}
