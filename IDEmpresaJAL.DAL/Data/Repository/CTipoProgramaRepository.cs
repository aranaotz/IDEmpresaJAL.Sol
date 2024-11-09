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
    public class CTipoProgramaRepository : GenericRepository<CTipoPrograma>, ICTipoProgramaRepository
    {
        private readonly ApplicationDbContext _context;
        public CTipoProgramaRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<SelectListItem> GetTipoPrograma()
        {
            var query = _context.CTipoPrograma
                .Select(item=> new SelectListItem()
                {
                    Text = item.TipoPrograma,
                    Value = item.Id.ToString()
                }
                );
            return query;
        }
    }
}
