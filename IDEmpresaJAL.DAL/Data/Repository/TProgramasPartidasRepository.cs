using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class TProgramasPartidasRepository : GenericRepository<TProgramasPartidas>, ITProgramasPartidasRepository
    {
        private readonly ApplicationDbContext _context;

        public TProgramasPartidasRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(TProgramasPartidas entity)
        {
            var objFromDb= _context.TProgramasPartidas.FirstOrDefault(x=> x.Id == entity.Id);
            if (objFromDb != null)
            {
                objFromDb.Componente = entity.Componente;
                objFromDb.Partida = entity.Partida;
                objFromDb.Descripcion = entity.Descripcion;
                objFromDb.Monto = entity.Monto;
            }
        }

        
    }
}
