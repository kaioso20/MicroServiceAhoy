using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroServiceAhoy.Model.Usuario
{
    public class RecoverPass
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public string NovaSenha { get; set; }
        public string confirmNovaSenha { get; set; }
    }
}
