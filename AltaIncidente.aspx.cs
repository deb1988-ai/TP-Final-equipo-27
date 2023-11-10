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
        List<Usuario> listaUsuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            listaMotivos = motivoNegocio.listarMotivos();
            listaUsuarios = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.Cliente);

            ddlMotivo.DataSource = listaMotivos;
            ddlMotivo.DataBind();
            ddlMotivo.DataTextField = "motivo";
            ddlMotivo.DataValueField = "Idmotivo";
            ddlMotivo.DataBind();
            ddlCliente.DataSource = listaUsuarios;
            ddlCliente .DataBind();
            ddlCliente.DataTextField = "NombreCompleto";
            ddlCliente.DataBind();
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
                incidente.Responsable = new Usuario();
                incidente.Responsable.IdUsuario = ((Usuario)Session["Usuario"]).IdUsuario;

                incidenteNegocio.agregar(incidente);
            }
            catch {throw new Exception("No se pudo dar de alta el incidente");}
        }
    }
}