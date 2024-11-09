using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICRolRepository:  IGenericRepository<CRoles>
    {
        public void Update(CRoles crol);

        public void UpdateDelete(CRoles crol);

        List<RRolRecursoTemp> ListaRecursos(int RolID);
    }
}
