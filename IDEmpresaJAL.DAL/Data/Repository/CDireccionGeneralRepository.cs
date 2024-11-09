using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CDireccionGeneralRepository : GenericRepository<CDireccionGeneral>, ICDireccionGeneralRepository
    {
        private readonly ApplicationDbContext _context;

        public CDireccionGeneralRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListaDirecciones()
        {
            var query=  _context.CDireccionGeneral
                .Where(item => item.Activo == true)
                .Select(item => new SelectListItem()
                {
                    Text= item.NombreDireccion,
                    Value=item.Id.ToString()
                }
                );
            return query;
        }

        public IEnumerable<SelectListItem> GetListaDireccionesPrograma(Guid direccion_id)
        {
            var query = _context.CDireccionGeneral
                .Where(item => item.Activo == true && item.Id == direccion_id)
                .Select(item => new SelectListItem()
                {
                    Text = item.NombreDireccion,
                    Value = item.Id.ToString()
                }
                );
            return query;
        }

        public void Update(CDireccionGeneral entity)
        {
            var objFromDB = _context.CDireccionGeneral.FirstOrDefault(d => d.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.NombreDireccion = entity.NombreDireccion;
                objFromDB.NombreEncargado = entity.NombreEncargado;
                objFromDB.EncargadoCargo = entity.EncargadoCargo;
                objFromDB.EncargadoCorreo = entity.EncargadoCorreo;
                objFromDB.TieneProgramas = entity.TieneProgramas;
                
            }
        }

        public void UpdateDelete(CDireccionGeneral entity)
        {
            var objFromDB = _context.CDireccionGeneral.FirstOrDefault(d => d.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Activo = false;
            }
        }
    }
}
