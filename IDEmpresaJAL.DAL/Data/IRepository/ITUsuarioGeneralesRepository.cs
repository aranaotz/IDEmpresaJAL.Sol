using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ITUsuarioGeneralesRepository: IGenericRepository<TUsuarioGenerales>
    {
        void Update(TUsuarioGenerales entity);

        void UpdateDelete(TUsuarioGenerales entity);

        List<TUsuarioGeneralesTemp> ListaUsuarios();

        List<RUsuarioRolTemp> ListaRoles(Guid UsuarioId);
    }
}
