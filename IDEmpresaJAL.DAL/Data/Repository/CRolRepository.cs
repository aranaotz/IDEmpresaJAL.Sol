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
    public class CRolRepository : GenericRepository<CRoles>, ICRolRepository
    {
        private readonly ApplicationDbContext _context;

        public CRolRepository(ApplicationDbContext context): base(context) 
        {
            _context = context;
        }

        public List<RRolRecursoTemp> ListaRecursos(int RolID)
        {
            var recursos = from t1 in _context.CRecurso
                           join t2 in (from rr in _context.RRolRecurso
                                       where rr.Rol.Id == RolID
                                       select rr) on t1.Id equals t2.Recurso.Id into gj
                           from subT2 in gj.DefaultIfEmpty()
                           orderby t1.Contenedor, t1.Id
                           select new RRolRecursoTemp
                           {
                               Id = t1.Id,
                               Recurso = t1.Recurso,
                               Seleccionado = subT2 != null
                           };
            
            return recursos.ToList();
        }

        public void Update(CRoles crol)
        {
            var objFromDB = _context.CRoles.FirstOrDefault(r => r.Id == crol.Id);
            if (objFromDB != null)
            {
                objFromDB.Rol = crol.Rol;
                
            }
        }

        public void UpdateDelete(CRoles crol)
        {
            var objFromDB = _context.CRoles.FirstOrDefault(r => r.Id == crol.Id);
            if (objFromDB != null)
            {

                objFromDB.Activo = false;
            }
        }
    }
}
