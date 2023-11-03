using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Incidente
    {
        public int IdIncidente { get; set; }
        public Motivo Motivo { get; set; }
        public string Descripion { get; set; }
        public Estado estado { get; set; }
        public usuario responsable { get; set; }
    }
}
