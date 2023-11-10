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
        Usuario usuario = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                lblError.Text = "Error: No se encontraron datos de usuario en la sesión.";
                return;
            }

            usuario = (Usuario)Session["Usuario"];
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
           if (usuario.TipoUsuario.IdTipoUsuario == 1 || usuario.TipoUsuario.IdTipoUsuario == 3)
            {
                listaIncidentes = incidenteNegocio.listarIncidentes();
                dgvIncidentes.DataSource = listaIncidentes;
                dgvIncidentes.DataBind();
            }
            else if (usuario.TipoUsuario.IdTipoUsuario == 2)
            {
                listaIncidentes = incidenteNegocio.listarIncidentesPorResponsable(usuario.IdUsuario);
                dgvIncidentes.DataSource = listaIncidentes;
                dgvIncidentes.DataBind();
            }
        }

        protected void dgvIncidentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDetalle")
            {
                int IdIncidente = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Redirect("Detalle.aspx?id=" + IdIncidente);
            }
        }


    }
}