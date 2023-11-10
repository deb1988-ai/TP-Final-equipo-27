using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class TipoUsuario
    {
        public int IdTipoUsuario { get; set; }
        public string tipoUsuario { get; set; }
    }



    public enum EnumTipoUsuario
    {
        Administrador = 1,
        Telefonista,
        Supervisor,
        Cliente
    }
}
