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

            try
            {
                datos.setearConsulta("Select a.IdIncidente, a.idEstado, a.Descripcion, a.Idmotivo, a.IdResponsable, a.FechaCreacion, a.FechaUltimaModificacion, a.IdPrioridad, a.IdCliente, " +
                    "b.idEstado, b.estado, " +
                    "c.Idmotivo, c.motivo, " +
                    "d.IdPrioridad, d.Prioridad, " +
                    "e.idUsuario, e.Nombre, e.Apellido " +
                    "From incidente a, estados b, motivo c, prioridad d, usuario e " +
                    "where a.idEstado  = b.idEstado And a.Idmotivo  = c.Idmotivo And a.IdPrioridad = d.IdPrioridad And a.IdResponsable = e.idUsuario");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["idIncidente"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = new Estado();
                    aux.Motivo = new Motivo();
                    aux.Prioridad = new Prioridad();
                    aux.Responsable = new Usuario();
                    aux.Cliente = new Cliente();
                    aux.Estado.idEstado = (int)datos.Lector["idEstado"];
                    aux.Estado.estado = (string)datos.Lector["estado"];
                    aux.Prioridad.IdPrioridad = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    aux.Responsable.IdUsuario = (int)datos.Lector["IdResponsable"];
                    aux.Responsable.Nombre = (string)datos.Lector["Nombre"];
                    aux.Responsable.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Motivo.idMotivo = (int)datos.Lector["Idmotivo"];    
                    aux.Motivo.motivo = (string)datos.Lector["motivo"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaUltimaModificacion = (DateTime)datos.Lector["FechaUltimaModificacion"];

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

            try
            {
                datos.setearConsulta("Select a.IdIncidente, a.idEstado, a.Descripcion, a.Idmotivo, a.IdResponsable, a.IdCliente, a.IdPrioridad, a.FechaCreacion, a.FechaUltimaModificacion," +
                    " b.idEstado, b.estado," +
                    " c.Idmotivo, c.motivo," +
                    " d.IdPrioridad, d.Prioridad," +
                    " e.idUsuario, e.Nombre, e.Apellido, " +
                    "From incidente a, estados b, motivo c, usuario d " +
                    "where a.idEstado  = b.idEstado And a.Idmotivo  = c.Idmotivo And a.IdPrioridad = d.IdPrioridad And a.IdResponsable = @idResponsable And e.idUsuario = @idResponsable");
                datos.setearParametro("@idResponsable", idResponsable);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["idIncidente"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Estado = new Estado();
                    aux.Motivo = new Motivo();
                    aux.Prioridad = new Prioridad();
                    aux.Responsable = new Usuario();
                    aux.Cliente = new Cliente();
                    aux.Estado.idEstado = (int)datos.Lector["idEstado"];
                    aux.Estado.estado = (string)datos.Lector["estado"];
                    aux.Prioridad.IdPrioridad = (int)datos.Lector["IdPrioridad"];
                    aux.Prioridad.Descripcion = (string)datos.Lector["Prioridad"];
                    aux.Responsable.IdUsuario = (int)datos.Lector["IdResponsable"];
                    aux.Responsable.Nombre = (string)datos.Lector["Nombre"];
                    aux.Responsable.Apellido = (string)datos.Lector["Apellido"];
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Motivo.idMotivo = (int)datos.Lector["Idmotivo"];
                    aux.Motivo.motivo = (string)datos.Lector["motivo"];
                    aux.FechaCreacion = (DateTime)datos.Lector["FechaCreacion"];
                    aux.FechaUltimaModificacion = (DateTime)datos.Lector["FechaUltimaModificacion"];

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
                datos.setearConsulta("Insert into incidente (idEstado, Descripcion, Idmotivo, IdResponsable, IdCliente, IdPrioridad, fechaCreacion, FechaUltimaModificacion)values(1, @descripcion, @IdMotivo, @IdResponsable, @IdCliente, @IdPrioridad, getdate(), getdate())");
                datos.setearParametro("@descripcion", incidente.Descripcion);
                datos.setearParametro("@IdMotivo", incidente.Motivo.idMotivo);
                datos.setearParametro("@IdResponsable", incidente.Responsable.IdUsuario);
                datos.setearParametro("@IdCliente", incidente.Cliente.IdCliente);
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

        public void modificarEstado(Incidente incidente, int nuevoEstado)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update incidente set idEstado = @Idestado, FechaUltimaModificacion = getdate() where IdIncidente = @idIncidente");
                datos.setearParametro("@idIncidente", incidente.IdIncidente);
                datos.setearParametro("@Idestado", nuevoEstado);
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

        public void modificarDescripcion(Incidente incidente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update incidente set Descripcion = @descripion  idEstado = 3, FechaUltimaModificacion = getdate() where IdIncidente = @idIncidente");
                datos.setearParametro("@idIncidente", incidente.IdIncidente);
                datos.setearParametro("@descripion", incidente.Descripcion);
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
                datos.setearConsulta("update incidente set idEstado = 2, Descripcion = @descripcion, Idmotivo = @idmotivo, IdPrioridad = @idPrioridad, FechaUltimaModificacion = getdate() where IdIncidente = @idIncidente");
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

        public void asignar(Incidente incidente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update incidente set idEstado = 5, idUsuario = @idusuario FechaUltimaModificacion = getdate() where IdIncidente = @idIncidente");
                datos.setearParametro("@idusuario", incidente.Responsable.IdUsuario);
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

        public void cerrar(Incidente incidente)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update incidente set idEstado = 3, ComentarioCierre=@comentario, FechaUltimaModificacion = getdate() where IdIncidente = @idIncidente");
                datos.setearParametro("@idusuario", incidente.Responsable.IdUsuario);
                datos.setearParametro("@comentario", incidente.comentarioCierre);
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

        public int incidentesUltimoMes()
        {
            AccesoDatos datos = new AccesoDatos();
            int cantidad = 0;
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM incidente WHERE FechaCreacion >= DATEADD(month, DATEDIFF(month, 0, GETDATE()) - 1, 0)");
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

        public int clienteMasIncidentes()
        {
            AccesoDatos datos = new AccesoDatos();
            int idCliente = 0;
            try
            {
                datos.setearConsulta("SELECT TOP 1 IdCliente AS Incidentes, COUNT(*) FROM incidente GROUP BY IdCliente ORDER BY Incidentes DESC");
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

    }
}
