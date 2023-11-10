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
    public partial class formularioCierre : System.Web.UI.Page
    {
        public int IdIncidenteSeleccionado { get; set; }
        public Incidente incidente = new Incidente();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            incidente.IdIncidente = IdIncidenteSeleccionado;
            incidente.comentarioCierre = TextBoxCierre.Text;
        }
    }
}