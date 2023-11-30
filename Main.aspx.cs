using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static dominio.EstadoIncidente;

namespace TP_Final_equipo_27
{
    public partial class _Default : Page
    {
        Usuario usuario = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Default.aspx");
                return;
            }

            Usuario usuarioLogueado = (Usuario)Session["Usuario"];
            if(usuarioLogueado.TipoUsuario.IdTipoUsuario == (int)EnumTipoUsuario.CLIENTE)
            {
                Response.Redirect("Incidentes.aspx");
                return;
            }
            LlenarDatos();
        }

        private void LlenarDatos()
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Incidente> ListaIncidentes = incidenteNegocio.listarIncidentes();
            int auxCantidad = 0;
            usuario = (Usuario)Session["Usuario"];

            if (usuario != null)
            {

                if (usuario.TipoUsuario.IdTipoUsuario == (int)EnumTipoUsuario.TELEFONISTA)
                {
                    foreach (Incidente item in ListaIncidentes)
                    {
                        if (item.Responsable != null && item.Responsable.IdUsuario == usuario.IdUsuario && item.Estado.IdEstado != (int)EnumEstadoIncidente.CERRADO)
                        {
                            auxCantidad++;
                        }
                    }
                }
                else
                {
                    foreach (Incidente item in ListaIncidentes)
                    {
                        if (item.Estado.IdEstado != (int)EnumEstadoIncidente.CERRADO)
                        {
                            auxCantidad++;
                        }
                    }
                }
            }

            lblCantidad.Text = auxCantidad.ToString();
            lblCantIncidentesUltmes.Text = incidenteNegocio.ObtenerCantidadIncidentesUltimoMes().ToString();
            int idClienteMasIncidentes = incidenteNegocio.ClienteMasIncidentes();
            Usuario cliente = new Usuario();
            cliente = usuarioNegocio.ObtenerUsuario(idClienteMasIncidentes);
            lblClienteMasIncidentes.Text = cliente.ToString();

        }
    }
}