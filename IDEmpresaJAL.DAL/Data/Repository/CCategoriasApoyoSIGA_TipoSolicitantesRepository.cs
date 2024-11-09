using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class CCategoriasApoyoSIGA_TipoSolicitantesRepository: GenericRepository<CCategoriasApoyoSIGA_TipoSolicitantes>, ICCategoriasApoyoSIGA_TipoSolicitantesRepository
    {
        private readonly ApplicationDbContext _context;

        public CCategoriasApoyoSIGA_TipoSolicitantesRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(CCategoriasApoyoSIGA_TipoSolicitantes entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateDelete(CCategoriasApoyoSIGA_TipoSolicitantes entity)
        {
            throw new NotImplementedException();
        }
    }
}
