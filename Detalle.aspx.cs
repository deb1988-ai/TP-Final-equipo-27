using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Caching;
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
        public List<Prioridad> ListaPrioridades { get; set; }
        public List<Motivo> ListaMotivos { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            Cliente cliente = new Cliente();
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            ListaIncidentes = incidenteNegocio.listarIncidentes();
            ListaPrioridades = prioridadNegocio.listarPrioridades();
            ListaMotivos = motivoNegocio.listarMotivos();
            ListaUsuarios = usuarioNegocio.listarUsuarios();

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
                            TimeSpan tiempoTranscurrido = DateTime.Now - item.FechaUltimaModificacion;
                            int diasTranscurridos = (int)tiempoTranscurrido.TotalDays;
                            lbIdIncidente.Text = incidente.IdIncidente.ToString();
                            lblDescripcion.Text = incidente.Descripcion;
                            lblResponsable.Text = incidente.Responsable.ToString();
                            lblPrioridad.Text = incidente.Prioridad.ToString();
                            lblmotivo.Text = incidente.Motivo.ToString();
                            lblCliente.Text = cliente.ToString();
                            lblFechaCreacion.Text = incidente.FechaCreacion.ToString();
                            lblDias.Text = diasTranscurridos.ToString();
                            ddlPrioridad.DataSource = ListaPrioridades;
                            ddlPrioridad.DataBind();
                            ddlPrioridad.DataTextField = "Descripcion";
                            ddlPrioridad.DataValueField = "IdPrioridad";
                            ddlPrioridad.Items.FindByText(incidente.Prioridad.Descripcion).Selected = true;
                            ddlMotivo.DataSource = ListaMotivos;
                            ddlMotivo.DataBind();
                            ddlMotivo.DataTextField = "motivo";
                            ddlMotivo.DataValueField = "Idmotivo";
                            ddlMotivo.Items.FindByText(incidente.Motivo.motivo).Selected = true;
                            /*ddlResponsable.DataSource = ListaUsuarios;
                            ddlResponsable.DataBind();
                            ddlResponsable.DataTextField = "LoginUsuario";
                            ddlResponsable.DataValueField = "idUsuario";*/
                            lblEstado.Text = incidente.Estado.ToString();
                            txtDescripcion.Text = incidente.Descripcion;

                            if (incidente.Estado.idEstado == 1)
                            {
                                lblEstado.Attributes["class"] = "card text-white bg-success mb-3";
                                
                            }
                            if(incidente.Estado.idEstado == 6)
                            {
                                ButtonResolver.Visible = false;
                            }
                            if (incidente.Estado.idEstado == 3)
                            {
                                ButtonCerrar.Visible = false;
                            }
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
            ddlPrioridad.Visible = true;
            lblPrioridad.Visible = false;

            ddlMotivo.Visible = true;
            lblmotivo.Visible = false;

            txtDescripcion.Visible = true;
            lblDescripcion.Visible = false;

            ButtonEditar.Visible = false;
            ButtonAceptar.Visible = true;

           /* if ((int)Session["TipoUsuario"] == 2)
            {
                ddlResponsable.Visible = true;
                lblResponsable.Visible = false;
            }*/
        }

        protected void ButtonResolver_Click(object sender, EventArgs e)
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            try
            {
                incidente.IdIncidente = IdIncidenteSeleccionado;
                incidenteNegocio.modificarEstado(incidente, 6);
                Response.Redirect("Detalle.aspx?id=" + IdIncidenteSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ButtonAceptar_Click(object sender, EventArgs e)
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            try
            {
                incidente.IdIncidente = IdIncidenteSeleccionado;
                incidente.Descripcion = txtDescripcion.Text;
                incidente.Motivo = new Motivo();
                incidente.Motivo.idMotivo = int.Parse(ddlMotivo.SelectedItem.Value);
                incidente.Prioridad = new Prioridad();
                incidente.Prioridad.IdPrioridad = int.Parse(ddlPrioridad.SelectedItem.Value);
                incidenteNegocio.modificar(incidente);

                Response.Redirect("Detalle.aspx?id=" + IdIncidenteSeleccionado);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void ButtonReabrir_Click(object sender, EventArgs e)
        {

        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            string url = "formularioCierre.aspx?id=" + IdIncidenteSeleccionado;
            Response.Write("<script>");
            Response.Write("window.open('" + url + "','ventanaEmergente','width=500,height=500');");
            Response.Write("</script>");
        }
    }
}