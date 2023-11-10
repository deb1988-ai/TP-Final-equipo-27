using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class EstadoIncidente
    {
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public override string ToString()
        {
            return Estado;
        }
    }
}
