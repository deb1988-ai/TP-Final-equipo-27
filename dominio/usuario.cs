using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Persona DatosPersonales { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return DatosPersonales.Nombre + " " + DatosPersonales.Apellido;
        }
        public string NombreCompleto
        {
            get
            {
                return DatosPersonales.Apellido + ", " + DatosPersonales.Nombre;
            }
        }

    }
}
