using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class usuario
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string loginUsuario { get; set; }
        public string email { get; set; }
        public TipoDeUsuario TipoDeUsuario { get; set; }      
    }
}
