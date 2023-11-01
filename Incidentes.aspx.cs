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
    public partial class Contact : Page
    {
        List<Incidente> listaIncidentes = new List<Incidente>();
        protected void Page_Load(object sender, EventArgs e)
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            listaIncidentes = incidenteNegocio.listarIncidentes();

            dgvIncidentes.DataSource = listaIncidentes;
            dgvIncidentes.DataBind();
        }

        protected void dgvIncidentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}