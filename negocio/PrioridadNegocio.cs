﻿using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class PrioridadNegocio
    {
        public List<Prioridad> ListarPrioridades()
        {
            List<Prioridad> lista = new List<Prioridad>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select IdPrioridad, Prioridad From prioridades");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Prioridad aux = new Prioridad();
                    aux.IdPrioridad = (int)datos.Lector["IdPrioridad"];
                    aux.prioridad = (string)datos.Lector["Prioridad"];
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
