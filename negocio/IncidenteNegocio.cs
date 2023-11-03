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
                datos.setearConsulta("Select a.IdIncidente, a.idEstado, a.Descripcion, a.Idmotivo, a.IdResponsable, " +
                    "b.idEstado, b.estado," +
                    " c.Idmotivo, c.motivo," +
                    " d.idUsuario, d.Nombre, d.Apellido " +
                    "From incidente a, estados b, motivo c, usuario d " +
                    "where a.idEstado  = b.idEstado And a.Idmotivo  = c.Idmotivo And a.IdResponsable = d.idUsuario");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["idIncidente"];
                    aux.Descripion = (string)datos.Lector["Descripcion"];  
                    aux.estado = new Estado();
                    aux.Motivo = new Motivo();
                    aux.responsable = new Usuario();
                    aux.estado.idEstado = (int)datos.Lector["idEstado"];
                    aux.responsable.IdUsuario = (int)datos.Lector["IdResponsable"];
                    aux.responsable.Nombre = (string)datos.Lector["Nombre"];
                    aux.responsable.Apellido = (string)datos.Lector["Apellido"];
                    aux.estado.estado = (string)datos.Lector["estado"];
                    aux.Motivo.idMotivo = (int)datos.Lector["Idmotivo"];
                    aux.Motivo.motivo = (string)datos.Lector["motivo"];

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
                datos.setearConsulta("Insert into incidente (idEstado, Descripcion, Idmotivo, IdResponsable)values(1, @descripcion, @IdMotivo, @IdResponsable)");
                datos.setearParametro("@descripcion", incidente.Descripion);
                datos.setearParametro("@IdMotivo", incidente.Motivo.idMotivo);
                datos.setearParametro("@IdResponsable", incidente.responsable.IdUsuario);
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
