using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class EstadoNegocio
    {

        public EstadoIncidente ObtenerEstado(int idEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            EstadoIncidente aux;
            try
            {
                datos.setearConsulta("Select IdEstado, estado from estadosIncidentes where idEstado = @idestado");
                datos.setearParametro("@idestado", idEstado);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux = new EstadoIncidente();
                    aux.IdEstado = (int)datos.Lector["IdEstado"];
                    aux.Estado = (string)datos.Lector["estado"];
                    return aux;
                }
                throw new Exception("No se encontro el estado en base de datos");
            }
            catch {throw new Exception("No se encontro el estado en base de datos");}
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
