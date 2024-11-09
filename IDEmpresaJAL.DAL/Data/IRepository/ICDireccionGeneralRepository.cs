using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICDireccionGeneralRepository : IGenericRepository<CDireccionGeneral>
    {
        void Update(CDireccionGeneral entity);

        void UpdateDelete(CDireccionGeneral entity);

        IEnumerable<SelectListItem> GetListaDirecciones();

        IEnumerable<SelectListItem> GetListaDireccionesPrograma(Guid direccion_id);
    }
}
