using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class usuarioNegocio
    {
        public List<usuario> listarUsuarios()
        {
            List<usuario> lista = new List<usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select * From usuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario aux = new usuario();
                    aux.IdUsuario = (int)datos.Lector["idUsuario"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Apellido = (string)datos.Lector["Apellido"];
                    aux.email = (string)datos.Lector["email"];
                    aux.loginUsuario = (string)datos.Lector["loginusuario"];
                    aux.password = (string)datos.Lector["password"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select idUsuario, Nombre, Apellido, email, loginusuario, password, idTipoUsuario from usuario Where email = @email And password = @password");
                datos.setearParametro("@email", usuario.email);
                datos.setearParametro("@password", usuario.password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    usuario.IdUsuario = (int)datos.Lector["idUsuario"];
                    ;
                    if (!(datos.Lector["Nombre"] is DBNull))
                        usuario.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Apellido"] is DBNull))
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


    }
}
