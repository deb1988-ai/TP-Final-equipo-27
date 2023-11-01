using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                datos.setearConsulta("Select a.IdIncidente, a.idEstado, a.Descripcion, a.Idmotivo," +
                    "b.idEstado, b.estado," +
                    " c.Idmotivo, c.Descripcion " +
                    "From incidente a, estados b, motivo c " +
                    "where a.idEstado  = b.idEstado And a.Idmotivo  = c.Idmotivo");

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Incidente aux = new Incidente();
                    aux.IdIncidente = (int)datos.Lector["idIncidente"];
                    aux.Descripion = (string)datos.Lector["Descripcion"];
                    aux.estado = new Estado();
                    aux.Motivo = new Motivo();
                    aux.estado.idEstado = (int)datos.Lector["idEstado"];
                    aux.estado.estado = (string)datos.Lector["estado"];
                    aux.Motivo.idMotivo = (int)datos.Lector["Idmotivo"];
                    aux.Motivo.Descripcion = (string)datos.Lector["Descripcion"];

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
}
