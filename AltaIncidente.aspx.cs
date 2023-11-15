using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            
            PrioridadNegocio prioridadNegocio = new PrioridadNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            
            listaPrioridades = prioridadNegocio.ListarPrioridades();
            listaUsuarios = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.Cliente);

            CargarMotivos();

            ddlCliente.DataSource = listaUsuarios;
            ddlCliente.DataTextField = "Login";
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
                incidente.Descripcion = txtDescripcion.Text;
                incidente.Motivo =  new Motivo();
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

                usuario = usuarioNegocio.ObtenerUsuario(incidente.Cliente.IdUsuario);

                string asunto = "Incidente N°" + incidente.IdIncidente;

                string body = "Se ha iniciado el incidente N°" + incidente.IdIncidente +
                              "Descripción: " + incidente.Descripcion + 
                              "Fecha de creación: " + incidente.FechaCreacion;

                incidenteNegocio.Agregar(incidente);

                emailService.armarCorreo(usuario.DatosPersonales.Email, asunto, body);
                emailService.armarCorreo(((Usuario)Session["Usuario"]).DatosPersonales.Email, asunto, body);

                int IdIncidente = incidenteNegocio.buscarUltimoIncidente();

                Response.Redirect("Detalle.aspx?id=" + IdIncidente);
            }
            catch {throw new Exception("No se pudo dar de alta el incidente");}
        }

        protected void ImageButtonAdd_Click(object sender, ImageClickEventArgs e)
        {
            TextBoxMotivos.Visible = true;
            btnAgregarMotivo.Visible = true;
            ImageButtonAdd.Visible = false;
        }

        protected void btnAgregarMotivo_Click(object sender, EventArgs e)
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            Motivo motivo = new Motivo();
            motivo.motivo = TextBoxMotivos.Text;
            motivoNegocio.Agregar(motivo);
            TextBoxMotivos.Visible = false;
            btnAgregarMotivo.Visible = false;
            ImageButtonAdd.Visible = true;
            CargarMotivos();
        }

        public void CargarMotivos()
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            listaMotivos = motivoNegocio.listarMotivos();
            ddlMotivo.DataSource = listaMotivos;
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "Idmotivo";
            ddlMotivo.DataBind();
        }
    }
}