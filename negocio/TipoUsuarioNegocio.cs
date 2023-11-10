using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class TipoUsuarioNegocio
    {
        public TipoUsuario ObtenerTipoUsuario(int idTipoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            TipoUsuario aux;
            try
            {
                datos.setearConsulta("Select idTipoUsuario, tipousuario from tiposusuarios where idTipoUsuario = @idTipoUsuario");
                datos.setearParametro("@idTipoUsuario", idTipoUsuario);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux = new TipoUsuario();
                    aux.IdTipoUsuario = (int)datos.Lector["idTipoUsuario"];
                    aux.tipoUsuario = (string)datos.Lector["tipousuario"];
                    return aux;
                }
                throw new Exception("No se encontro el tipo usuario en base de datos");
            }
            catch { throw new Exception("No se encontro el tipo usuario en base de datos"); }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
