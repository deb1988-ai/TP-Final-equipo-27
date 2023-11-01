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
}
