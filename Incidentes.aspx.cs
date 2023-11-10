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
           /* if (Session.Count !=0 && (int)Session["TipoUsuario"] <= 2)
            {
                listaIncidentes = incidenteNegocio.listarIncidentes();
                dgvIncidentes.DataSource = listaIncidentes;
                dgvIncidentes.DataBind();
            }
            else if (Session.Count != 0 && (int)Session["TipoUsuario"] == 3)
            {
                int idTelefonista = (int)Session["IdUsuario"];
                listaIncidentes = incidenteNegocio.listarIncidentesPorResponsable(idTelefonista);
                dgvIncidentes.DataSource = listaIncidentes;
                dgvIncidentes.DataBind();
            }
            //borrar este else cuando se modifique lo que se guarda en session al loguearse
            else
            {
                listaIncidentes = incidenteNegocio.listarIncidentes();
                dgvIncidentes.DataSource = listaIncidentes;
                dgvIncidentes.DataBind();
            }*/
            listaIncidentes = incidenteNegocio.listarIncidentes();
            dgvIncidentes.DataSource = listaIncidentes;
            dgvIncidentes.DataBind();
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