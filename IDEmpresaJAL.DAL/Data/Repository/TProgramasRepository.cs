using IDEmpresaJAL.DAL.Data.IRepository;
using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.Repository
{
    public class TProgramasRepository : GenericRepository<TProgramas>, ITProgramasRepository
    {
        private readonly ApplicationDbContext _context;

        public TProgramasRepository(ApplicationDbContext context):base(context) 
        {
            _context = context;
        }

        public void Update(TProgramas entity)
        {
            var objFromDB = _context.TProgramas.FirstOrDefault(x=> x.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.Nombre = entity.Nombre;
                objFromDB.TipoProgramaId = entity.TipoProgramaId;
                objFromDB.DireccionGeneralId = entity.DireccionGeneralId;
                objFromDB.ObjetivoGeneral= entity.ObjetivoGeneral;
                objFromDB.PermiteMultiplesProyectos= entity.PermiteMultiplesProyectos;
                objFromDB.PermiteMultiplesConvocatorias = entity.PermiteMultiplesConvocatorias;
                objFromDB.BancaId = entity.BancaId;
                objFromDB.Numcuenta= entity.Numcuenta;
                objFromDB.CLABE = entity.CLABE;
                objFromDB.Presupuesto = entity.Presupuesto;
                objFromDB.ClavePresupuestaria = entity.ClavePresupuestaria;
                objFromDB.CodigoDenominacion = entity.CodigoDenominacion;
                objFromDB.ClaveProgramaPresupuestal = entity.ClaveProgramaPresupuestal;
                objFromDB.DescripcionPartida = entity.DescripcionPartida;
                objFromDB.FechaInicio = entity.FechaInicio;
                objFromDB.FechaFin= entity.FechaFin;
                objFromDB.Color=entity.Color;
                objFromDB.EstatusProgramaId = entity.EstatusProgramaId;

            }
        }

        public void UpdateVoBo(TProgramas entity)
        {
            var objFromDB = _context.TProgramas.FirstOrDefault(x => x.Id == entity.Id);
            if (objFromDB != null)
            {
                objFromDB.VoBoArea = entity.VoBoArea;
                objFromDB.VoBoPlaneacion = entity.VoBoPlaneacion;
                objFromDB.EstatusProgramaId = entity.EstatusProgramaId;
            }
        }

       
    }
}
