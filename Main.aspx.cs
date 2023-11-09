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
        List<Incidente> ListaIncidentes = new List<Incidente>();
        protected void Page_Load(object sender, EventArgs e)
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            ListaIncidentes = incidenteNegocio.listarIncidentes();
            lblCantidad.Text = ListaIncidentes.Count.ToString();
            lblCantIncidentesUltmes.Text = incidenteNegocio.incidentesUltimoMes().ToString();
            int idClienteMasIncidentes = incidenteNegocio.clienteMasIncidentes();
            Cliente cliente = new Cliente();
            cliente = clienteNegocio.BuscarClientesID(idClienteMasIncidentes);
            lblClienteMasIncidentes.Text = cliente.ToString();
        }
    }
}