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

    }
}
