using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.BLL.IRepository
{
    public interface IUtilidadesRepository
    {
        string ConvertirSha256(string texto);
    }
}
