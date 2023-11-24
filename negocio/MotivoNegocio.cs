using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class MotivoNegocio
    {
        public List<Motivo> listarMotivos()
        {
            List<Motivo> lista = new List<Motivo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select Idmotivo, motivo From motivos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Motivo aux = new Motivo();
                    aux.idMotivo = (int)datos.Lector["Idmotivo"];
                    aux.motivo = (string)datos.Lector["motivo"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch {throw new Exception("No se pudieron listar los motivos");}
            finally
            {
                datos.cerrarConexion();
            }
        }

        public Motivo ObtenerMotivo(int idMotivo)
        {
            AccesoDatos datos = new AccesoDatos();
            Motivo aux;
            try
            {
                datos.setearConsulta("Select idmotivo, motivo from motivos where idmotivo = @idMotivo");
                datos.setearParametro("@idMotivo", idMotivo);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    aux = new Motivo();
                    aux.idMotivo = (int)datos.Lector["idmotivo"];
                    aux.motivo = (string)datos.Lector["motivo"];
                    return aux;
                }
                throw new Exception("No se encontro el motivo en base de datos");
            }
            catch { throw new Exception("No se encontro el motivo en base de datos"); }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void Agregar(Motivo motivo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@" insert into Motivos
                                        (motivo) values
                                        (@motivo)");

                datos.setearParametro("@motivo", motivo.motivo);
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

        public void Modificar(Motivo motivo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Motivos set motivo = @motivo where IdMotivo =@idMotivo");
                datos.setearParametro("@idMotivo", motivo.idMotivo);
                datos.setearParametro("@motivo", motivo.motivo);
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

        public void Eliminar(int idMotivo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from Motivos where IdMotivo =@idMotivo");
                datos.setearParametro("@idMotivo", idMotivo);
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

        public bool ExisteMotivo(string motivo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM motivos WHERE motivo = @motivo");
                datos.setearParametro("@motivo", motivo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(datos.Lector[0]);
                    return cantidad > 0;
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
