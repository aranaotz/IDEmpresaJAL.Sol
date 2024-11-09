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
    public class CDocumentosTipoCargaRepositoty : GenericRepository<CDocumentosTipoCarga>, ICDocumentosTipoCargaRepository
    {
        private readonly ApplicationDbContext _context;

        public CDocumentosTipoCargaRepositoty(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetListaTipoCarga()
        {
            return _context.CDocumentosTipoCarga
                .Select(item => new SelectListItem
                {
                    Text= item.TipoCarga,
                    Value= item.Id.ToString()
                });
        }

        public void Update(CDocumentosTipoCarga entity)
        {
            //no se necesita
        }
    }
}
