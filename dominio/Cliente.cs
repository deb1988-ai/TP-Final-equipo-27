using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public Persona DatosCliente { get; set; }

        public string NombreCompleto
        {
            get { return DatosCliente.Nombre + " " + DatosCliente.Apellido; }
        }

        public override string ToString()
        {
            return DatosCliente.Apellido + ", " + DatosCliente.Nombre;
        }
    }
}
