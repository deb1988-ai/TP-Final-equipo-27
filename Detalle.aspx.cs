using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_equipo_27
{
    public partial class Detalle : System.Web.UI.Page
    {
        public int IdIncidenteSeleccionado { get; set; }

        public Incidente incidente = new Incidente();
        public List<Incidente> ListaIncidentes { get; set; }
        public List<Usuario> ListaUsuarios { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            Cliente cliente = new Cliente();
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            ListaIncidentes = incidenteNegocio.listarIncidentes();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    foreach (var item in ListaIncidentes)
                    {
                        if (IdIncidenteSeleccionado == item.IdIncidente)
                        {
                            incidente = item;
                            cliente = clienteNegocio.BuscarClientesID(item.Cliente.IdCliente);
                            lbIdIncidente.Text = incidente.IdIncidente.ToString();
                            lblDescripcion.Text = incidente.Descripcion;
                            lblResponsable.Text = incidente.Responsable.ToString();
                            lblPrioridad.Text = incidente.Prioridad.ToString();
                            lblmotivo.Text = incidente.Motivo.ToString();
                            lblCliente.Text = cliente.ToString();
                        }
                    }
                }
            }
            else
            {
                lblError.Text = "Incidente no encontrado.";
                Response.Redirect("Default.aspx");
            }
        }

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonResolver_Click(object sender, EventArgs e)
        {

        }
    }
}