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
                datos.setearConsulta("Select Idmotivo, motivo From motivo");
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
