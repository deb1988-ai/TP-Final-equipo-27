using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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

                if (usuario.TipoUsuario.IdTipoUsuario == 2)
                {
                    foreach (Incidente item in ListaIncidentes)
                    {
                        if (item.Responsable.IdUsuario == usuario.IdUsuario && item.Estado.IdEstado != 3)
                        {
                            auxCantidad++;
                        }
                    }
                }
                else
                {
                    foreach (Incidente item in ListaIncidentes)
                    {
                        if (item.Estado.IdEstado != 3)
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