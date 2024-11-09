using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using IDEmpresaJAL.Entity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ITUsuarioRepository : IGenericRepository<TUsuario>
    {
        void Update(TUsuario entity);

        void UpdateDelete(TUsuario entity);

        

    }
}
