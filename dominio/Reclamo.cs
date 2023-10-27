using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Reclamo
    {
        public int IdReclamo { get; set; }

        public Motivo IdMotivo { get; set; }
        public string Descripion { get; set; }

        public Area Area { get; set; }

    }
}
