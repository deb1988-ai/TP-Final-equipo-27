using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PersonaNegocio
    {
        public void CrearPersona(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(@"insert into personas
                                        (nombre, apellido,email,telefono) values
                                        (@nombre,@apellido,@email,@telefono)");

                datos.setearParametro("@nombre", persona.Nombre);
                datos.setearParametro("@apellido", persona.Apellido);
                datos.setearParametro("@email", persona.Email);
                datos.setearParametro("@telefono", persona.Telefono);

                datos.ejecutarAccion();
                datos.cerrarConexion();

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

        public void ModificarPersona(Persona persona)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"update personas
                                        set Nombre = @nombre,
                                        Apellido = @apellido,
                                        Email = @email,
                                        Telefono = @telefono
                                        where IdPersona = @idPersona");
                datos.setearParametro("@nombre", persona.Nombre);
                datos.setearParametro("@apellido", persona.Apellido);
                datos.setearParametro("@email", persona.Email);
                datos.setearParametro("@telefono", persona.Telefono);
                datos.setearParametro("@idPersona", persona.IdPersona);
                datos.ejecutarAccion();
                datos.cerrarConexion();
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

        public Persona ObtenerPersona(int idPersona)
        {
            AccesoDatos datos = new AccesoDatos();
            Persona aux;
            try
            {
                datos.setearConsulta("select idPersona,nombre,apellido,email,telefono from personas where idPersona = @idpersona");
                datos.setearParametro("@idPersona", idPersona);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = new Persona();
                    aux.IdPersona = (int)datos.Lector["idPersona"]; ;
                    aux.Nombre = (string)datos.Lector["nombre"]; ;
                    aux.Apellido = (string)datos.Lector["apellido"]; ;
                    aux.Email = (string)datos.Lector["email"]; ;
                    aux.Telefono = (string)datos.Lector["telefono"]; ;
                    return aux;
                }
                else { throw new Exception("No se encontro la persona en base de datos"); }
            }
            catch { throw new Exception("No se encontro la persona en base de datos"); }

            finally { datos.cerrarConexion(); }
        }
        public int ObtenerUltimoIdPersona()
        {
            AccesoDatos datos = new AccesoDatos();
            int aux;
            try
            {
                datos.setearConsulta("select top 1 idPersona from personas order by idpersona desc");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = (int)datos.Lector["idPersona"]; ;
                    return aux;
                }
                else { throw new Exception("No se encontro la persona en base de datos"); }
            }
            catch { throw new Exception("No se encontro la persona en base de datos"); }

            finally { datos.cerrarConexion(); }
        }
    }
}
