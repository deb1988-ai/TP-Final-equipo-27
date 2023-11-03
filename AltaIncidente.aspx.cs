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
    public partial class AltaIncidente : System.Web.UI.Page
    {
        List<Motivo> listaMotivos = new List<Motivo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            listaMotivos = motivoNegocio.listarMotivos();

            ddlMotivo.DataSource = listaMotivos;
            ddlMotivo.DataBind();
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "Idmotivo";
            ddlMotivo.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();

            try
            {
                incidente.Descripion = txtDescripcion.Text;
                incidente.Motivo =  new Motivo();
                incidente.Motivo.idMotivo = int.Parse(ddlMotivo.SelectedItem.Value);
                incidente.responsable = new Usuario();
                incidente.responsable.IdUsuario = ((Usuario)Session["Usuario"]).IdUsuario;

                incidenteNegocio.agregar(incidente);
            }
            catch(Exception ex)
            {

            }
        }
    }
}