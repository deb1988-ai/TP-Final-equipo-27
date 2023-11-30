using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static dominio.EstadoIncidente;

namespace TP_Final_equipo_27
{
    public partial class AltaIncidente : System.Web.UI.Page
    {
        List<Motivo> listaMotivos = new List<Motivo>();
        List<Prioridad> listaPrioridades = new List<Prioridad>();
        List<Usuario> listaUsuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Usuario"] == null)
                {
                    Response.Redirect("Default.aspx");
                }

                llenarListas();
            }
        }

        private void llenarListas()
        {
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();

            listaPrioridades = prioridadNegocio.ListarPrioridades();
            listaUsuarios = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.CLIENTE);
            listaMotivos = motivoNegocio.listarMotivos();

            CargarMotivos();
            ddlMotivo.DataSource = listaMotivos;
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "Idmotivo";
            ddlMotivo.DataBind();

            ddlCliente.DataSource = listaUsuarios;
            ddlCliente.DataTextField = "NombreCompleto";
            ddlCliente.DataValueField = "IdUsuario";
            ddlCliente.DataBind();

            ddlPrioridad.DataSource = listaPrioridades;
            ddlPrioridad.DataTextField = "prioridad";
            ddlPrioridad.DataValueField = "IdPrioridad";
            ddlPrioridad.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            Usuario usuarioLogueado = (Usuario)Session["Usuario"];
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                if(txtDescripcion.Text.Length >= 10) 
                {
                    incidente.Descripcion = txtDescripcion.Text;
                    incidente.Motivo = new Motivo();
                    incidente.Motivo.idMotivo = int.Parse(ddlMotivo.SelectedItem.Value);

                    EmailService emailService = new EmailService();

                    if(usuarioLogueado.TipoUsuario.IdTipoUsuario != (int)EnumTipoUsuario.CLIENTE)
                    {
                        incidente.Responsable = new Usuario();
                        incidente.Responsable.IdUsuario = usuarioLogueado.IdUsuario;
                        incidente.Prioridad = new Prioridad();
                        incidente.Prioridad.IdPrioridad = int.Parse(ddlPrioridad.SelectedItem.Value);
                        incidente.Cliente = new Usuario();
                        incidente.Cliente.IdUsuario = int.Parse(ddlCliente.SelectedItem.Value);
                    }
                    else // Cuando el usuario logueado es cliente tomo ese cliente como creador de la incidencia
                    { 
                        incidente.Responsable = null;
                        incidente.Prioridad = null;
                        incidente.Cliente = (Usuario)Session["Usuario"];
                    }
                    incidente.Estado = new EstadoIncidente();
                    incidente.Estado.IdEstado = (int)EnumEstadoIncidente.ABIERTO;
                    incidente.FechaCreacion = DateTime.Now;

                    incidenteNegocio.Agregar(incidente);
                    incidente.IdIncidente = incidenteNegocio.buscarUltimoIncidente();

                    incidente.Cliente = usuarioNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario); ;
                    EnvioMailIncidenteAlta(incidente,usuarioLogueado,incidente.Cliente);

                    Response.Redirect("Detalle.aspx?id=" + incidente.IdIncidente,false);
                }
                else
                {
                    lblErrorDescripción.Text = "Debe ingresar al menos 10 caracteres en la descripción.";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }
        
        public void EnvioMailIncidenteAlta(Incidente incidente, Usuario usuarioLogueado, Usuario cliente)
        {
            EmailService emailService = new EmailService();

            string asunto = "Incidente N°" + incidente.IdIncidente;

            string body = $@"Se ha iniciado el incidente N° {incidente.IdIncidente}
                          Descripción: {incidente.Descripcion}
                          Fecha de creación: {incidente.FechaCreacion.ToString("dd-MM-yyyy")}
                          Cliente: {cliente.DatosPersonales.Nombre}, {cliente.DatosPersonales.Apellido}";

            emailService.armarCorreo(usuarioLogueado.DatosPersonales.Email, asunto, body);
            emailService.armarCorreo(cliente.DatosPersonales.Email, asunto, body);
            emailService.enviarEmail();
        }

        protected void ImageButtonAdd_Click(object sender, ImageClickEventArgs e)
        {
            TextBoxMotivos.Visible = true;
            btnAgregarMotivo.Visible = true;
            ImageButtonAdd.Visible = false;
            btnCancelar.Visible = true;
        }

        protected void btnAgregarMotivo_Click(object sender, EventArgs e)
        {
            try
            {
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                Motivo motivo = new Motivo();
                motivo.motivo = TextBoxMotivos.Text;
                lblErrorMotivo.Visible = false;
                if (motivoNegocio.ExisteMotivo(motivo.motivo) == true)
                {
                    lblErrorMotivo.Text = "Ya existe un motivo con la misma descripción.";
                    lblErrorMotivo.Visible = true;
                }
                else
                {  
                    motivoNegocio.Agregar(motivo);
                    TextBoxMotivos.Text = "";
                    TextBoxMotivos.Visible = false;
                    btnAgregarMotivo.Visible = false;
                    ImageButtonAdd.Visible = true;
                    CargarMotivos();
                }                  
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        public void CargarMotivos()
        {
            try
            {
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                listaMotivos = motivoNegocio.listarMotivos();
                ddlMotivo.DataSource = listaMotivos;
                ddlMotivo.DataTextField = "motivo";
                ddlMotivo.DataValueField = "Idmotivo";
                ddlMotivo.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            TextBoxMotivos.Visible = false;
            btnAgregarMotivo.Visible = false;
            ImageButtonAdd.Visible = true;
            btnCancelar.Visible = false;
            lblErrorMotivo.Visible = false;
        }
    }
}