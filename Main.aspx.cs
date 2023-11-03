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
            ListaIncidentes = incidenteNegocio.listarIncidentes();
            lblCantidad.Text = ListaIncidentes.Count.ToString();
        }
    }
}