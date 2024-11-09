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
    public class CCategoriasApoyoSIGARepository: GenericRepository<CCategoriasApoyoSIGA> , ICCategoriasApoyoSIGARepository
    {
        private readonly ApplicationDbContext _context;

        public CCategoriasApoyoSIGARepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public List<CategoriaSolicitanteTemp> ListaSolicitantes(Guid CategoairaID)
        {
            var result = from t1 in _context.CTipoSolicitante
                         join t2 in _context.CCategoriasTipoSolicitante
                         on new { TipoSolicitanteId = t1.Id, CategoriaId = CategoairaID }
                         equals new { TipoSolicitanteId = t2.TipoSolicitanteId, CategoriaId = t2.CategoriaId } into gj
                         from subT2 in gj.DefaultIfEmpty() // Left join
                         orderby t1.FechaCreacion
                         select new CategoriaSolicitanteTemp
                         {
                             Id= t1.Id,
                             TipoSolicitante= t1.TipoSolicitante,
                             Seleccionado = subT2 != null
                         };

            return result.ToList();
        }

        public void Update(CCategoriasApoyoSIGA entity)
        {
            var objFromDB = _context.CCategorias.FirstOrDefault(x=> x.Id == entity.Id);
            if (objFromDB != null) 
            {
                objFromDB.Categoria = entity.Categoria;
                objFromDB.TieneEmpleados = entity.TieneEmpleados;
                objFromDB.EmpleadosMin=entity.EmpleadosMin;
                objFromDB.EmpleadosMax=entity.EmpleadosMax;
            }
        }

        public void UpdateDelete(CCategoriasApoyoSIGA entity)
        {
            var objFromDB = _context.CCategorias.FirstOrDefault(x => x.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Activo = false;
            }
        }
    }
}
