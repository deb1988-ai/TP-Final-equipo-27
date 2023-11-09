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
        List<Cliente> listaClientes = new List<Cliente>();
        List<Prioridad> listaPrioridades = new List<Prioridad>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            listaMotivos = motivoNegocio.listarMotivos();
            listaClientes = clienteNegocio.listarClientes();
            listaPrioridades = prioridadNegocio.listarPrioridades();

            ddlMotivo.DataSource = listaMotivos;
            ddlMotivo.DataBind();
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "Idmotivo";
            ddlMotivo.DataBind();
            ddlCliente.DataSource = listaClientes;
            ddlCliente .DataBind();
            ddlCliente.DataTextField = "NombreCompleto";
            ddlCliente.DataValueField = "IdCliente";
            ddlCliente.DataBind();
            ddlPrioridad.DataSource = listaPrioridades;
            ddlPrioridad .DataBind();
            ddlPrioridad.DataTextField = "Descripcion";
            ddlPrioridad.DataValueField = "IdPrioridad";
            ddlPrioridad.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();

            try
            {
                incidente.Descripcion = txtDescripcion.Text;
                incidente.Motivo =  new Motivo();
                incidente.Motivo.idMotivo = int.Parse(ddlMotivo.SelectedItem.Value);
                incidente.Responsable = new Usuario();
                incidente.Responsable.IdUsuario = ((Usuario)Session["Usuario"]).IdUsuario;
                incidente.Prioridad = new Prioridad();
                incidente.Prioridad.IdPrioridad = int.Parse(ddlPrioridad.SelectedItem.Value);
                incidente.Cliente = new Cliente();
                incidente.Cliente.IdCliente = int.Parse(ddlCliente.SelectedItem.Value);

                incidenteNegocio.Agregar(incidente);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}