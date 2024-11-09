using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CRecursoContenedorRepository : GenericRepository<CRecursoContenedor>, ICRecursoContenedorRepository
    {
        private readonly ApplicationDbContext _context;

        public CRecursoContenedorRepository(ApplicationDbContext context):base(context) 
        {
            _context= context;  
        }

        public void Update(CRecursoContenedor entity)
        {
            //no hay metodo
        }
    }
}
