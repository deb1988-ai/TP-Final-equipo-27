using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace negocio
{
    public class IncidenteNegocio
    {
        public List<Incidente> listarIncidentes()
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();

            try
            {
                datos.setearConsulta(@"select 
                                        i.IdIncidente, i.descripcion, i.fechaCreacion, i.fechaUltimaModificacion, i.IdPrioridad, i.comentarioCierre,
                                        ei.IdEstado,
                                        m.IdMotivo,                                      
                                        uRes.IdUsuario as IdUsuarioResponsable,
                                        uCli.IdUsuario as IdUsuarioCliente
                                        from Incidentes i
                                        join EstadosIncidentes ei on ei.IdEstado = i.idEstado
                                        join Motivos m on m.IdMotivo = i.idMotivo
                                        join Usuarios uRes on ures.IdUsuario = i.idResponsable
                                        join Usuarios uCli on uCli.IdUsuario = i.idCliente
                                        join prioridades pr on pr.IdPrioridad = i.IdPrioridad");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["IdIncidente"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaUltimaModificacion = (DateTime)datos.Lector["FechaUltimaModificacion"];
                    if (datos.Lector["comentarioCierre"] == DBNull.Value)
                    {
                    }
                    else
                    {
                        aux.comentarioCierre = (string)datos.Lector["comentarioCierre"];
                    }

                    aux.Estado = new EstadoIncidente();
                    aux.Estado = estadoNegocio.ObtenerEstado((int)datos.Lector["idEstado"]);

                    aux.Motivo = new Motivo();
                    aux.Motivo = motivoNegocio.ObtenerMotivo((int)datos.Lector["Idmotivo"]);

                    aux.Responsable = new Usuario();
                    aux.Responsable = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioResponsable"]);

                    aux.Cliente = new Usuario();
                    aux.Cliente = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioCliente"]);

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad = prioridadNegocio.ObtenerPrioridad((int)datos.Lector["IdPrioridad"]);

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
        public List<Incidente> listarIncidentesPorResponsable(int idResponsable)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();

            try
            {
                datos.setearConsulta(@"select 
                                        i.IdIncidente, i.descripcion, i.fechaCreacion, i.fechaUltimaModificacion, i.IdPrioridad, 
                                        ei.IdEstado,
                                        m.IdMotivo,
                                        uRes.IdUsuario as IdUsuarioResponsable,
                                        uCli.IdUsuario as IdUsuarioCliente
                                        from Incidentes i
                                        join EstadosIncidentes ei on ei.IdEstado = i.idEstado
                                        join Motivos m on m.IdMotivo = i.idMotivo
                                        join prioridades pr on pr.IdPrioridad = i.IdPrioridad
                                        join Usuarios uRes on ures.IdUsuario = i.idResponsable
                                        join Usuarios uCli on uCli.IdUsuario = i.idCliente
                                        where i.idResponsable = @idResponsable");
                datos.setearParametro("@idResponsable", idResponsable);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["IdIncidente"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaUltimaModificacion = (DateTime)datos.Lector["FechaUltimaModificacion"];

                    aux.Estado = new EstadoIncidente();
                    aux.Estado = estadoNegocio.ObtenerEstado((int)datos.Lector["idEstado"]);

                    aux.Motivo = new Motivo();
                    aux.Motivo = motivoNegocio.ObtenerMotivo((int)datos.Lector["Idmotivo"]);

                    aux.Responsable = new Usuario();
                    aux.Responsable = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioResponsable"]);

                    aux.Cliente = new Usuario();
                    aux.Cliente = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioCliente"]);

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad = prioridadNegocio.ObtenerPrioridad((int)datos.Lector["IdPrioridad"]);

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
        public List<Incidente> listarIncidentesPorCliente(int idCliente)
        {
            List<Incidente> lista = new List<Incidente>();
            AccesoDatos datos = new AccesoDatos();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();

            try
            {
                datos.setearConsulta(@"select 
                                        i.IdIncidente, i.descripcion, i.fechaCreacion, i.fechaUltimaModificacion, i.IdPrioridad, 
                                        ei.IdEstado,
                                        m.IdMotivo,
                                        uRes.IdUsuario as IdUsuarioResponsable,
                                        uCli.IdUsuario as IdUsuarioCliente
                                        from Incidentes i
                                        join EstadosIncidentes ei on ei.IdEstado = i.idEstado
                                        join Motivos m on m.IdMotivo = i.idMotivo
                                        join prioridades pr on pr.IdPrioridad = i.IdPrioridad
                                        join Usuarios uRes on ures.IdUsuario = i.idResponsable
                                        join Usuarios uCli on uCli.IdUsuario = i.idCliente
                                        where i.idCliente = @idCliente");
                datos.setearParametro("@idCliente", idCliente);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["IdIncidente"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaUltimaModificacion = (DateTime)datos.Lector["FechaUltimaModificacion"];

                    aux.Estado = new EstadoIncidente();
                    aux.Estado = estadoNegocio.ObtenerEstado((int)datos.Lector["idEstado"]);

                    aux.Motivo = new Motivo();
                    aux.Motivo = motivoNegocio.ObtenerMotivo((int)datos.Lector["Idmotivo"]);

                    aux.Responsable = new Usuario();
                    aux.Responsable = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioResponsable"]);

                    aux.Cliente = new Usuario();
                    aux.Cliente = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioCliente"]);

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad = prioridadNegocio.ObtenerPrioridad((int)datos.Lector["IdPrioridad"]);

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
        public void Agregar(Incidente incidente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@"insert into Incidentes
                                        (descripcion,fechaCreacion,fechaUltimaModificacion,
                                        idEstado,idMotivo,idResponsable,idCliente,Idprioridad) values
                                        (@descripcion, getdate(), getdate(),
                                        @idestado, @IdMotivo, @IdResponsable,@idcliente, @idprioridad)");

                datos.setearParametro("@descripcion", incidente.Descripcion);

                datos.setearParametro("@idestado", incidente.Estado.IdEstado);
                datos.setearParametro("@IdMotivo", incidente.Motivo.idMotivo);
                datos.setearParametro("@IdResponsable", incidente.Responsable.IdUsuario);
                datos.setearParametro("@idcliente", incidente.Cliente.IdUsuario);
                datos.setearParametro("@idprioridad", incidente.Prioridad.IdPrioridad);
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
        public void modificar(Incidente incidente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update incidentes set idEstado = 2, Descripcion = @descripcion, Idmotivo = @idmotivo, IdPrioridad = @idPrioridad, fechaUltimaModificacion = getdate() where IdIncidente = @idIncidente");
                datos.setearParametro("@idIncidente", incidente.IdIncidente);
                datos.setearParametro("@descripcion", incidente.Descripcion);
                datos.setearParametro("@idmotivo", incidente.Motivo.idMotivo);
                datos.setearParametro("@IdPrioridad", incidente.Prioridad.IdPrioridad);
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
        public int ObtenerCantidadIncidentesUltimoMes()
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = 0;
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM incidentes WHERE FechaCreacion >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0)");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    cantidad = (int)datos.Lector[0];
                }
                datos.cerrarConexion();
                return cantidad;
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
        public int ClienteMasIncidentes()
        {
            AccesoDatos datos = new AccesoDatos();
            int idCliente = 0;
            try
            {
                datos.setearConsulta("SELECT TOP 1 IdCliente AS Incidentes, COUNT(*) FROM incidentes GROUP BY IdCliente ORDER BY Incidentes DESC");
                datos.ejecutarLectura();
                if (datos.Lector.Read())        
                {
                    idCliente = (int)datos.Lector[0];
                }
                datos.cerrarConexion();

                return idCliente;
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
        public void ModificarEstado(int idIncidente, int idEstado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update incidentes set idestado = @idestado, fechaUltimaModificacion = getdate() where idincidente = @idincidente");
                datos.setearParametro("@idestado", idEstado);
                datos.setearParametro("@idincidente", idIncidente);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CambiarResponsable(int idIncidente, int idResponsable)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Incidentes set idResponsable = @idresponsable, fechaUltimaModificacion = getdate(), idEstado = 5 where IdIncidente = @idIncidente");
                datos.setearParametro("@idresponsable", idResponsable);
                datos.setearParametro("@idIncidente", idIncidente);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void CerrarIncidente(int idIncidente, string comentario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("update Incidentes set comentarioCierre = @comentariocierre, fechaUltimaModificacion = getdate(), idEstado = 3 where IdIncidente = @idIncidente");
                datos.setearParametro("@comentariocierre", comentario);
                datos.setearParametro("@idIncidente", idIncidente);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int buscarUltimoIncidente()
        {
            AccesoDatos datos = new AccesoDatos();
            int aux;
            try
            {
                datos.setearConsulta("select top 1 IdIncidente from Incidentes order by IdIncidente desc");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    aux = (int)datos.Lector["IdIncidente"]; ;
                    return aux;
                }
                else { throw new Exception("No se encontro el incidente en base de datos"); }
            }
            catch { throw new Exception("No se encontro el incidente en base de datos"); }

            finally { datos.cerrarConexion(); }
        }
        public Incidente ObtenerIncidente(int idIncidente)
        {
            AccesoDatos datos = new AccesoDatos();
            EstadoNegocio estadoNegocio = new EstadoNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();

            try
            {
                datos.setearConsulta(@"select 
                                        i.IdIncidente, i.descripcion, i.fechaCreacion, i.fechaUltimaModificacion, i.IdPrioridad, i.comentarioCierre,
                                        ei.IdEstado,
                                        m.IdMotivo,                                      
                                        uRes.IdUsuario as IdUsuarioResponsable,
                                        uCli.IdUsuario as IdUsuarioCliente
                                        from Incidentes i
                                        join EstadosIncidentes ei on ei.IdEstado = i.idEstado
                                        join Motivos m on m.IdMotivo = i.idMotivo
                                        join Usuarios uRes on ures.IdUsuario = i.idResponsable
                                        join Usuarios uCli on uCli.IdUsuario = i.idCliente
                                        join prioridades pr on pr.IdPrioridad = i.IdPrioridad
                                        where IdIncidente=@idIncidente");
                datos.setearParametro("@idIncidente", idIncidente);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["IdIncidente"];
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaUltimaModificacion = (DateTime)datos.Lector["FechaUltimaModificacion"];
                    if (datos.Lector["comentarioCierre"] == DBNull.Value)
                    {
                    }
                    else
                    {
                        aux.comentarioCierre = (string)datos.Lector["comentarioCierre"];
                    }

                    aux.Estado = new EstadoIncidente();
                    aux.Estado = estadoNegocio.ObtenerEstado((int)datos.Lector["idEstado"]);

                    aux.Motivo = new Motivo();
                    aux.Motivo = motivoNegocio.ObtenerMotivo((int)datos.Lector["Idmotivo"]);

                    aux.Responsable = new Usuario();
                    aux.Responsable = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioResponsable"]);

                    aux.Cliente = new Usuario();
                    aux.Cliente = usuarioNegocio.ObtenerUsuario((int)datos.Lector["IdUsuarioCliente"]);

                    aux.Prioridad = new Prioridad();
                    aux.Prioridad = prioridadNegocio.ObtenerPrioridad((int)datos.Lector["IdPrioridad"]);

                    return aux;
                }
                else { throw new Exception("No se encontro el incidente en base de datos"); }
            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }
    }
}
