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
using static dominio.EstadoIncidente;

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

        public Usuario usuario = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            Usuario cliente = new Usuario();
            Usuario usuario = (Usuario)Session["Usuario"];

            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            UsuarioNegocio clienteNegocio = new UsuarioNegocio();
            
            ListaPrioridades = prioridadNegocio.ListarPrioridades();
            ListaMotivos = motivoNegocio.listarMotivos();
            ListaUsuarios = usuarioNegocio.listarUsuarios();

            if (Request.QueryString["id"] != null)
            {
                if (!IsPostBack)
                {
                    incidente = incidenteNegocio.ObtenerIncidente(IdIncidenteSeleccionado);

                    if(usuario.TipoUsuario.IdTipoUsuario == (int)EnumTipoUsuario.SUPERVISOR)
                    {
                        ButtonCambiarResponsable.Visible = true;
                    }

                    cliente = clienteNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);
                    TimeSpan tiempoTranscurrido = DateTime.Now - incidente.FechaUltimaModificacion;
                    int diasTranscurridos = (int)tiempoTranscurrido.TotalDays;

                    lbIdIncidente.Text = incidente.IdIncidente.ToString();
                    lblDescripcion.Text = incidente.Descripcion;
                    lblResponsable.Text = incidente.Responsable.ToString();
                    lblPrioridad.Text = incidente.Prioridad.ToString();
                    lblmotivo.Text = incidente.Motivo.ToString();
                    lblCliente.Text = cliente.ToString();
                    lblFechaCreacion.Text = incidente.FechaCreacion.ToString();
                    lblDias.Text = diasTranscurridos.ToString();
                    lblEstado.Text = incidente.Estado.ToString();
                    txtDescripcion.Text = incidente.Descripcion;
                    

                    ddlPrioridad.DataSource = ListaPrioridades;
                    ddlPrioridad.DataTextField = "prioridad";
                    ddlPrioridad.DataValueField = "IdPrioridad";
                    ddlPrioridad.DataBind();
                    ddlPrioridad.Items.FindByText(incidente.Prioridad.prioridad).Selected = true;

                    ddlMotivo.DataSource = ListaMotivos;
                    ddlMotivo.DataTextField = "motivo";
                    ddlMotivo.DataValueField = "idMotivo";
                    ddlMotivo.DataBind();
                    ddlMotivo.Items.FindByText(incidente.Motivo.motivo).Selected = true;

                    ddlResponsable.DataSource = ListaUsuarios;
                    ddlResponsable.DataTextField = "Login";
                    ddlResponsable.DataValueField = "IdUsuario";
                    ddlResponsable.DataBind();

                    if (incidente.Estado.IdEstado == (int)EnumEstadoIncidente.RESUELTO)
                    {
                        ButtonResolver.Visible = false;
                    }
                    if (incidente.Estado.IdEstado == (int)EnumEstadoIncidente.CERRADO)
                    {
                        ButtonCerrar.Visible = false;
                        lblCierre.Visible = true;
                        ButtonEditar.Visible = false;
                        ButtonCambiarResponsable.Visible = false;
                        ButtonResolver.Visible = false;
                        lblCierre.Text = incidente.comentarioCierre.ToString();
                        ButtonReabrirIncidente.Visible = true;
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
            usuario = (Usuario)Session["Usuario"];
            if (usuario.TipoUsuario.IdTipoUsuario == 3)
            {
                ButtonCambiarResponsable.Visible = false;
            }

            ddlPrioridad.Visible = true;
            lblPrioridad.Visible = false;

            ddlMotivo.Visible = true;
            lblmotivo.Visible = false;

            txtDescripcion.Visible = true;
            lblDescripcion.Visible = false;
            
            ButtonEditar.Visible = false;
            ButtonAceptar.Visible = true;
            ButtonResolver.Visible = false;
            ButtonCancelar.Visible = true;
            ButtonCerrarIncidente.Visible = false;
            ButtonCerrar.Visible = false;
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];
            if (usuario.TipoUsuario.IdTipoUsuario == 3)
            {
                ButtonCambiarResponsable.Visible = true;
            }

            ddlPrioridad.Visible = false;
            lblPrioridad.Visible = true;

            ddlMotivo.Visible = false;
            lblmotivo.Visible = true;

            txtDescripcion.Visible = false;
            lblDescripcion.Visible = true;

            ButtonEditar.Visible = true;
            ButtonAceptar.Visible = false;
            ButtonResolver.Visible = true;
            ButtonCancelar.Visible = false;
            ButtonCerrarIncidente.Visible = true;
            ButtonCerrar.Visible = false;
        }

        protected void ButtonResolver_Click(object sender, EventArgs e)
        {
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Incidente incidente;
            int IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            Usuario cliente;
            try
            {
                incidenteNegocio.ModificarEstado(IdIncidenteSeleccionado, 6);
                cliente = new Usuario();
                incidente = new Incidente();
                incidente = incidenteNegocio.ObtenerIncidente(IdIncidenteSeleccionado);

                cliente = usuarioNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);

                EmailService emailService = new EmailService();

                string asunto = "Incidente N°" + incidente.IdIncidente + " resuelto";

                string body = "Se ha resuelto el incidente N°" + incidente.IdIncidente + ".\n" +
                                  "Descripción: " + incidente.Descripcion + ".\n" +
                                  "Fecha de creación: " + incidente.FechaCreacion.ToString("dd-MM-yyyy") + ".\n" +
                                  "Fecha de resolución: " + DateTime.Now.ToString("dd-MM-yyyy");

                emailService.armarCorreo(cliente.DatosPersonales.Email, asunto, body);
                emailService.armarCorreo(((Usuario)Session["Usuario"]).DatosPersonales.Email, asunto, body);
                emailService.enviarEmail();

                Response.Redirect("Detalle.aspx?id=" + IdIncidenteSeleccionado, false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
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

                Response.Redirect("Detalle.aspx?id=" + IdIncidenteSeleccionado,false);
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ButtonReabrir_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = (Usuario)Session["Usuario"];

                if (txtPassword.Text == usuario.Password)
                {
                    IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
                    IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
                    incidenteNegocio.ModificarEstado(IdIncidenteSeleccionado, 4);
                    Incidente incidente = new Incidente();
                    incidente = incidenteNegocio.ObtenerIncidente(IdIncidenteSeleccionado);

                    Usuario cliente = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                    cliente = usuarioNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);

                    EmailService emailService = new EmailService();

                    string asunto = "Incidente N°" + IdIncidenteSeleccionado + " reabierto";

                    string body = "Se ha reabierto el incidente N°" + incidente.IdIncidente + ".\n" +
                                      "Descripción: " + incidente.Descripcion + ".\n" +
                                      "Comentario de cierre: " + incidente.comentarioCierre + ".\n" +
                                      "Fecha de creación: " + incidente.FechaCreacion.ToString("dd-MM-yyyy") + ".\n" +
                                      "Fecha de reapertura: " + DateTime.Now.ToString("dd-MM-yyyy");

                    emailService.armarCorreo(cliente.DatosPersonales.Email, asunto, body);
                    emailService.armarCorreo(((Usuario)Session["Usuario"]).DatosPersonales.Email, asunto, body);
                    emailService.enviarEmail();

                    Response.Redirect("Detalle.aspx?id=" + IdIncidenteSeleccionado, false);
                } else
                {
                    lblErrorCierre.Visible = true;
                    lblErrorCierre.Text = "Contraseña incorrecta.";
                }            
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            txtCierre.Visible = true;
            txtPassword.Visible = true;
            ButtonCerrarIncidente.Visible = true;
            ButtonCerrar.Visible = false;
            ButtonEditar.Enabled = false;
            ButtonCambiarResponsable.Enabled = false;
        }

        protected void ButtonCambiarResponsable_Click(object sender, EventArgs e)
        {
            ddlResponsable.Visible = true;
            lblResponsable.Visible = false;
            ButtonCambiarResponsable.Visible = false;
            ButtonAceptarResponsable.Visible = true;
        }

        protected void ButtonAceptarResponsable_Click(object sender, EventArgs e)
        {
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();
            try
            {
                int idNuevoResponsable;
                Usuario nuevoResponsable = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                if (int.TryParse(ddlResponsable.SelectedItem.Value, out idNuevoResponsable))
                {
                    incidenteNegocio.CambiarResponsable(IdIncidenteSeleccionado, idNuevoResponsable);
                    nuevoResponsable = usuarioNegocio.ObtenerUsuario(idNuevoResponsable);
                }

                CargarIncidente();

                ButtonAceptarResponsable.Visible = false;
                ButtonCambiarResponsable.Visible = true;
                lblResponsable.Visible = true;
                ddlResponsable.Visible = false;

                EmailService emailService = new EmailService();

                string asunto = "Incidente N°" + IdIncidenteSeleccionado;

                string body = "Se lo ha asignado como responsable del incidente N°" + incidente.IdIncidente + ".\n" +
                                  "Descripción: " + incidente.Descripcion + ".\n" +
                                  "Fecha de creación: " + incidente.FechaCreacion.ToString("dd-MM-yyyy") + ".\n" +
                                  "Fecha de asignación: " + DateTime.Today.ToString("dd-MM-yyyy");

                emailService.armarCorreo(nuevoResponsable.DatosPersonales.Email, asunto, body);
                emailService.enviarEmail();
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        private void CargarIncidente()
        {
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();         
            ListaIncidentes = incidenteNegocio.listarIncidentes();

            Usuario cliente = new Usuario();
            UsuarioNegocio clienteNegocio = new UsuarioNegocio();

            foreach (var item in ListaIncidentes)
            {
                if (IdIncidenteSeleccionado == item.IdIncidente)
                {
                    incidente = item;
                }
            }

            cliente = clienteNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);
            TimeSpan tiempoTranscurrido = DateTime.Now - incidente.FechaUltimaModificacion;
            int diasTranscurridos = (int)tiempoTranscurrido.TotalDays;

            lbIdIncidente.Text = incidente.IdIncidente.ToString();
            lblDescripcion.Text = incidente.Descripcion;
            lblResponsable.Text = incidente.Responsable.ToString();
            lblPrioridad.Text = incidente.Prioridad.ToString();
            lblmotivo.Text = incidente.Motivo.ToString();
            lblCliente.Text = cliente.ToString();
            lblFechaCreacion.Text = incidente.FechaCreacion.ToString();
            lblDias.Text = diasTranscurridos.ToString();
            lblEstado.Text = incidente.Estado.ToString();
        }

        protected void ButtonCerrarIncidente_Click(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["Usuario"];

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
            Usuario cliente;
            try
            {
                if (txtPassword.Text == usuario.Password && txtCierre.Text.Length > 10)
                {
                    IdIncidenteSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
                    IncidenteNegocio incidenteNegocio = new IncidenteNegocio();

                    incidente = incidenteNegocio.ObtenerIncidente(IdIncidenteSeleccionado);
                    incidente.IdIncidente = IdIncidenteSeleccionado;
                    incidente.comentarioCierre = txtCierre.Text;
                    incidenteNegocio.CerrarIncidente(IdIncidenteSeleccionado, txtCierre.Text);

                    cliente = new Usuario();
                    cliente = usuarioNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);

                    lblErrorCierre.Visible = false;
                    ButtonCerrarIncidente.Visible = false;

                    EmailService emailService = new EmailService();

                    string asunto = "Incidente N°" + incidente.IdIncidente + " cerrado";

                    string body = "Se ha resuelto el incidente N°" + incidente.IdIncidente + ".\n" +
                                      "Descripción: " + incidente.Descripcion + ".\n" +
                                      "Comentario de cierre: " + incidente.comentarioCierre + ".\n" +
                                      "Fecha de creación: " + incidente.FechaCreacion.ToString("dd-MM-yyyy") + ".\n" +
                                      "Fecha de cierre: " + DateTime.Now.ToString("dd-MM-yyyy");

                    emailService.armarCorreo(cliente.DatosPersonales.Email, asunto, body);
                    emailService.armarCorreo(((Usuario)Session["Usuario"]).DatosPersonales.Email, asunto, body);
                    emailService.enviarEmail();

                    Response.Redirect("Detalle.aspx?id=" + IdIncidenteSeleccionado,false);
                }
                else if (txtPassword.Text != usuario.Password && txtCierre.Text.Length < 10)
                {
                    lblErrorCierre.Visible = true;
                    lblErrorCierre.Text = "Contraseña incorrecta. Ingrese al menos 10 caracteres en el comentario de cierre.";
                }
                else if (txtCierre.Text.Length < 10)
                {
                    lblErrorCierre.Visible = true;
                    lblErrorCierre.Text = "Ingrese al menos 10 caracteres en el comentario de cierre.";
                }
                else if (txtPassword.Text != usuario.Password)
                {
                    lblErrorCierre.Visible = true;
                    lblErrorCierre.Text = "Contraseña incorrecta.";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }          
        }

        protected void ButtonReabrirIncidente_Click(object sender, EventArgs e)
        {
            txtPassword.Visible = true;
            ButtonReabrir.Visible = true;
            ButtonReabrirIncidente.Visible = false;
        }
    }
}