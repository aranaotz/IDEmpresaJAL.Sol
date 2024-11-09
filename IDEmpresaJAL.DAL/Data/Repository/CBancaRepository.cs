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
    public class CBancaRepository: GenericRepository<CBanca>, ICBancaRepository
    {
        private readonly ApplicationDbContext _context;

        public CBancaRepository(ApplicationDbContext context): base(context) 
        {
            _context= context;
        }

        public IEnumerable<SelectListItem> GetListaBanca()
        {
            var query = _context.CBanca
                .Where(x => x.Activo == true)
                .Select(item=> new SelectListItem()
                {
                    Text = item.Banca,
                    Value = item.Id.ToString()
                });
            return query;
        }
    }
}
