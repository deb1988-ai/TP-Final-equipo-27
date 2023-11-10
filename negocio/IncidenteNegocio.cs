using dominio;
using System;
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

            try
            {
                datos.setearConsulta(@"select 
                                        i.IdIncidente, i.descripcion, i.fechaCreacion, i.fechaUltimaModificacion,
                                        ei.IdEstado,
                                        m.IdMotivo,
                                        uRes.IdUsuario as IdUsuarioResponsable,
                                        uCli.IdUsuario as IdUsuarioCliente
                                        from Incidentes i
                                        join EstadosIncidentes ei on ei.IdEstado = i.idEstado
                                        join Motivos m on m.IdMotivo = i.idMotivo
                                        join Usuarios uRes on ures.IdUsuario = i.idResponsable
                                        join Usuarios uCli on uCli.IdUsuario = i.idCliente");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["IdIncidente"];
                    aux.Descripion = (string)datos.Lector["descripcion"];
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

            try
            {
                datos.setearConsulta(@"select 
                                        i.IdIncidente, i.descripcion, i.fechaCreacion, i.fechaUltimaModificacion,
                                        ei.IdEstado,
                                        m.IdMotivo,
                                        uRes.IdUsuario as IdUsuarioResponsable,
                                        uCli.IdUsuario as IdUsuarioCliente
                                        from Incidentes i
                                        join EstadosIncidentes ei on ei.IdEstado = i.idEstado
                                        join Motivos m on m.IdMotivo = i.idMotivo
                                        join Usuarios uRes on ures.IdUsuario = i.idResponsable
                                        join Usuarios uCli on uCli.IdUsuario = i.idCliente
                                        where i.idResponsable = @idResponsable");
                datos.setearParametro("@idResponsable", idResponsable);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["IdIncidente"];
                    aux.Descripion = (string)datos.Lector["descripcion"];
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


        public void agregar(Incidente incidente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(@" insert into incidentes
                                        (descripcion,fechaCreacion,fechaUltimaModificacion,
                                        idestado,idMotivo,idResponsable,idCliente) values
                                        @descripcion, getdate(), getdate(),
                                        @idestado, @IdMotivo, @IdResponsable,@idcliente ");

                datos.setearParametro("@descripcion", incidente.Descripion);

                datos.setearParametro("@idestado", incidente.Estado.IdEstado);
                datos.setearParametro("@IdMotivo", incidente.Motivo.idMotivo);
                datos.setearParametro("@IdResponsable", incidente.Responsable.IdUsuario);
                datos.setearParametro("@idcliente", incidente.Cliente.IdUsuario);
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
    }
}
