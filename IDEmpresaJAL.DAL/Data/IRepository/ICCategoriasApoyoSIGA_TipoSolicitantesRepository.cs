using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICCategoriasApoyoSIGA_TipoSolicitantesRepository: IGenericRepository<CCategoriasApoyoSIGA_TipoSolicitantes>
    {

        void Update(CCategoriasApoyoSIGA_TipoSolicitantes entity);

        void UpdateDelete(CCategoriasApoyoSIGA_TipoSolicitantes entity);

    }
}
