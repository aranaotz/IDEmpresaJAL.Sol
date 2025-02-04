﻿using IDEmpresaJAL.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ITUsuarioSeguridadRepository : IGenericRepository<TUsuarioSeguridad>
    {
        void Update(TUsuarioSeguridad entity);

        void UpdateDelete(TUsuarioSeguridad entity);

        TUsuarioSeguridad GetByRequest(string request);

       
    }
}
