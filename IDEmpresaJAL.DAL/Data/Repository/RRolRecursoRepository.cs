using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class RRolRecursoRepository : GenericRepository<RRolRecurso>, IRRolRecursoRepository
    {
        private readonly ApplicationDbContext _context;

        public RRolRecursoRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;   
        }

        public void Update(RRolRecurso entity)
        {
            var objFromDb = _context.RRolRecurso.FirstOrDefault(r => r.Id == entity.Id);
        }
    }
}
