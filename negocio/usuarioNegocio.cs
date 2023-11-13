using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listarUsuarios(int? idTipoUsuario = null)
        {
            List<Usuario> lista = new List<Usuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string sql = @" select
                                u.IdUsuario,u.login,u.password,
                                tu.IdTipoUsuario,tu.tipoUsuario,
                                p.Idpersona,p.nombre,p.apellido,p.email,p.telefono
                                from Usuarios u
                                join Personas p on u.idPersona = p.Idpersona
                                join TiposUsuarios tu on tu.IdTipoUsuario = ";

                if (idTipoUsuario != null) {
                    sql += " @idtipousuario";
                    datos.setearParametro("@idtipousuario", idTipoUsuario);
                } else
                {
                    sql += " u.idTipoUsuario";                 
                }

                datos.setearConsulta(sql);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["IdUsuario"];
                    if (datos.Lector["login"] == DBNull.Value)
                    {
                    }
                    else
                    {
                        aux.Login = (string)datos.Lector["login"];
                    }
                    if (datos.Lector["password"] == DBNull.Value)
                    {
                    }
                    else
                    {
                        aux.Password = (string)datos.Lector["password"];
                    }
            
                    aux.TipoUsuario = new TipoUsuario();
                    aux.TipoUsuario.IdTipoUsuario = (int)datos.Lector["IdTipoUsuario"];
                    aux.TipoUsuario.tipoUsuario = (string)datos.Lector["tipoUsuario"];
                    aux.DatosPersonales = new Persona();
                    aux.DatosPersonales.IdPersona = (int)datos.Lector["Idpersona"];
                    aux.DatosPersonales.Nombre = (string)datos.Lector["nombre"];
                    aux.DatosPersonales.Apellido = (string)datos.Lector["apellido"];
                    aux.DatosPersonales.Email = (string)datos.Lector["email"];
                    aux.DatosPersonales.Telefono = (string)datos.Lector["telefono"];

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


        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select idUsuario, login, password from usuarios Where login = @login And password = @password");
                datos.setearParametro("@login", usuario.Login);
                datos.setearParametro("@password", usuario.Password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
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

        public Usuario ObtenerUsuario(int idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();
            PersonaNegocio personaNegocio = new PersonaNegocio();   
            Usuario aux;
            try
            {
                datos.setearConsulta("select idusuario, login, password, idTipoUsuario, idPersona from usuarios where idusuario = @idusuario");
                datos.setearParametro("@idusuario", idUsuario);
                datos.ejecutarLectura();
                if (datos.Lector.Read()) {
                    aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["idusuario"];
                    aux.Login = (string)datos.Lector["login"];
                    aux.Password = (string)datos.Lector["password"];

                    aux.TipoUsuario = new TipoUsuario();
                    aux.TipoUsuario = tipoUsuarioNegocio.ObtenerTipoUsuario((int)datos.Lector["idTipoUsuario"]);

                    aux.DatosPersonales = new Persona();
                    aux.DatosPersonales = personaNegocio.ObtenerPersona((int)datos.Lector["idPersona"]);

                    return aux;
                }
                throw new Exception("No se encontro el usuario en base de datos");
            }
            catch {throw new Exception("No se encontro el usuario en base de datos");}

            finally { datos.cerrarConexion();}
        }

        public void CrearUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("insert into usuarios(login,password,idtipousuario,idpersona)values(@login,@password,@idtipousuario,@idpersona)");
                datos.setearParametro("login", usuario.Login);
                datos.setearParametro("password", usuario.Password);
                datos.setearParametro("idtipousuario", usuario.TipoUsuario.IdTipoUsuario);
                datos.setearParametro("idpersona", usuario.DatosPersonales.IdPersona);

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

        public Usuario ObtenerUsuarioLoginYPass(string login, string password)
        {
            AccesoDatos datos = new AccesoDatos();
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();
            PersonaNegocio personaNegocio = new PersonaNegocio();
            Usuario aux;
            try
            {
                datos.setearConsulta("select idusuario, login, password, idTipoUsuario, idPersona from usuarios where login = @login and password = @password");
                datos.setearParametro("@login", login);
                datos.setearParametro("@password", password);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux = new Usuario();
                    aux.IdUsuario = (int)datos.Lector["idusuario"];
                    aux.Login = (string)datos.Lector["login"];
                    aux.Password = (string)datos.Lector["password"];

                    aux.TipoUsuario = new TipoUsuario();
                    aux.TipoUsuario = tipoUsuarioNegocio.ObtenerTipoUsuario((int)datos.Lector["idTipoUsuario"]);

                    aux.DatosPersonales = new Persona();
                    aux.DatosPersonales = personaNegocio.ObtenerPersona((int)datos.Lector["idPersona"]);

                    return aux;
                }
                throw new Exception("No se encontro el usuario en base de datos");
            }
            catch { throw new Exception("No se encontro el usuario en base de datos"); }

            finally { datos.cerrarConexion(); }
        }

    }
}
