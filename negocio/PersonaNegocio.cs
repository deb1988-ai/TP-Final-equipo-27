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

        public string ObtenerMail(int Idpersona)
        {
            AccesoDatos datos = new AccesoDatos();

            string aux;
            try
            {
                datos.setearConsulta("select email from Personas where Idpersona=@idpersona");
                datos.setearParametro("@idPersona", Idpersona);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = (string)datos.Lector["email"];
                    return aux;
                }
                else { throw new Exception("No se encontro el mail en base de datos"); }
            }
            catch { throw new Exception("No se encontro el mail en base de datos"); }

            finally { datos.cerrarConexion(); }
        }

        public bool validarEmail(string email)
        {
            AccesoDatos datos = new AccesoDatos();

            int cantidad = 0;
            try
            {
                datos.setearConsulta("SELECT CASE WHEN EXISTS (SELECT 1 FROM Personas WHERE email = @email)"
                                 + " THEN 1 ELSE 0 END");
                datos.setearParametro("@email", email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector[0];
                }
                datos.cerrarConexion();
                if (cantidad == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
