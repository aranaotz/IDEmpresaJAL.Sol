using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using IDEmpresaJAL.Entity.TempData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CRecursoRepository : GenericRepository<CRecurso>, ICRecursoRepository
    {
        private readonly ApplicationDbContext _context;

        public CRecursoRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

        
    

        public void Update(CRecurso entity)
        {
            //no hay metodo para actualizarlo
        }
    }
}
