﻿using IDEmpresaJAL.Entity.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.DAL.Data.IRepository
{
    public interface ICBancaRepository: IGenericRepository<CBanca>
    {
        IEnumerable<SelectListItem> GetListaBanca();
    }
}
