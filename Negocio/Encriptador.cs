using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Encriptador
    {
        public Encriptador()
        {
            Aes generador = Aes.Create();
            this.Key = Convert.ToBase64String(generador.Key);
            this.IV = Convert.ToBase64String(generador.IV);
        }

        public int Id { get; set; }

        public string Key { get; set; }

        public string IV { get; set; }
    }
}
