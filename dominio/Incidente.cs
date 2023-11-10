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
        public string Descripcion { get; set; }
        public EstadoIncidente Estado { get; set; }
        public Prioridad Prioridad { get; set; }
        public Usuario Responsable { get; set; }
        public Usuario Cliente { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }
    }
}
