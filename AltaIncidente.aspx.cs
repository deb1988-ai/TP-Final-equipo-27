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

namespace TP_Final_equipo_27
{
    public partial class AltaIncidente : System.Web.UI.Page
    {
        List<Motivo> listaMotivos = new List<Motivo>();
        List<Prioridad> listaPrioridades = new List<Prioridad>();
        List<Usuario> listaUsuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }

            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            
            listaPrioridades = prioridadNegocio.ListarPrioridades();
            listaUsuarios = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.Cliente);

            CargarMotivos();

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
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                if(txtDescripcion.Text.Length >= 10) 
                {
                    incidente.Descripcion = txtDescripcion.Text;
                    incidente.Motivo = new Motivo();
                    incidente.Motivo.idMotivo = int.Parse(ddlMotivo.SelectedItem.Value);

                    EmailService emailService = new EmailService();

                    incidente.Responsable = new Usuario();
                    incidente.Responsable.IdUsuario = ((Usuario)Session["Usuario"]).IdUsuario;
                    incidente.Prioridad = new Prioridad();
                    incidente.Prioridad.IdPrioridad = int.Parse(ddlPrioridad.SelectedItem.Value);
                    incidente.Cliente = new Usuario();
                    incidente.Cliente.IdUsuario = int.Parse(ddlCliente.SelectedItem.Value);
                    incidente.Estado = new EstadoIncidente();
                    incidente.Estado.IdEstado = 1;

                    incidente.IdIncidente = incidenteNegocio.buscarUltimoIncidente();
                    incidente.FechaCreacion = DateTime.Now;

                    usuario = usuarioNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);

                    string asunto = "Incidente N°" + incidente.IdIncidente;

                    string body = "Se ha iniciado el incidente N°" + incidente.IdIncidente + ".\n" +
                                  "Descripción: " + incidente.Descripcion + ".\n" +
                                  "Fecha de creación: " + incidente.FechaCreacion.ToString("dd-MM-yyyy");

                    incidenteNegocio.Agregar(incidente);

                    emailService.armarCorreo(usuario.DatosPersonales.Email, asunto, body);
                    emailService.armarCorreo(((Usuario)Session["Usuario"]).DatosPersonales.Email, asunto, body);
                    emailService.enviarEmail();

                    int IdIncidente = incidenteNegocio.buscarUltimoIncidente();

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