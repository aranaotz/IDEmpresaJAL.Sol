using IDEmpresaJAL.BLL.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IDEmpresaJAL.BLL.Repository
{
    public class UtilidadesRepository : IUtilidadesRepository
    {
        public string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();

            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;

                byte[] resul = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in resul)
                {
                    sb.Append(b.ToString("x2"));
                }
            }

            return sb.ToString();
        }
    }
}
