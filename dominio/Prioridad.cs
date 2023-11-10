using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Prioridad
    {
        public int IdPrioridad { get; set; }
        public string prioridad { get; set; }

        public override string ToString()
        {
            return prioridad;
        }
    }
}
