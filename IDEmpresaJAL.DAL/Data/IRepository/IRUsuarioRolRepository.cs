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
    public interface IRUsuarioRolRepository : IGenericRepository<RUsuarioRol>
    {
        void Update(RUsuarioRol entity);

        void UpdateDelete(RUsuarioRol entity);

        List<MenuTemp> ListaMenu(Guid usuarioId);

       
    }
}
