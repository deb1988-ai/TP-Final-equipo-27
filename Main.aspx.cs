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
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarDatos();
        }

        private void LlenarDatos()
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Incidente>  ListaIncidentes = incidenteNegocio.listarIncidentes();

            lblCantidad.Text = ListaIncidentes.Count.ToString();
            lblCantIncidentesUltmes.Text = incidenteNegocio.ObtenerCantidadIncidentesUltimoMes().ToString();
            int idClienteMasIncidentes = incidenteNegocio.ClienteMasIncidentes();
            Usuario cliente = new Usuario();
            cliente = usuarioNegocio.ObtenerUsuario(idClienteMasIncidentes);
            lblClienteMasIncidentes.Text = cliente.ToString();

        }
    }
}