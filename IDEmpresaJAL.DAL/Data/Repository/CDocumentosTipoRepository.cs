using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CDocumentosTipoRepository : GenericRepository<CDocumentosTipo>, ICDocumentosTipoRepository
    {
        private readonly ApplicationDbContext _context;

        public CDocumentosTipoRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListaTipoDocumento(bool tiene_programas)
        {
           
            if (tiene_programas)
            {
                return _context.CDocumentosTipo
                .Where(item => item.Activo == true)
                .Where(item => item.Id !=1)
                .Select(item => new SelectListItem()
                {
                    Text = item.TipoDocumento,
                    Value = item.Id.ToString()
                });
            }
            else
            {
                return _context.CDocumentosTipo
                .Where(item => item.Activo == true)
                 .Where(item => item.Id == 1)
                .Select(item => new SelectListItem()
                {
                    Text = item.TipoDocumento,
                    Value = item.Id.ToString()
                });
            }

             
             
        }

        public void Update(CDocumentosTipo entity)
        {
            //no se necesita
        }

        public void UpdateDelete(CDocumentosTipo entity)
        {
            //no se necesita
        }
    }
}
