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
    public partial class Contraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                EmailService emailService = new EmailService();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                PersonaNegocio personaNegocio = new PersonaNegocio();

                Usuario aux = usuarioNegocio.ObtenerIDyPassword(txtUsuario.Text);
                aux.DatosPersonales.Email = personaNegocio.ObtenerMail(aux.DatosPersonales.IdPersona);

                string asunto = "Contraseña usuario" + txtUsuario.Text;

                string body = "Su contraseña es: " + aux.Password;

                emailService.armarCorreo(aux.DatosPersonales.Email, asunto, body);
                emailService.enviarEmail();

                lblMensaje.Text = "Contraseña enviada.";
                btnEnviar.Enabled = false;
                lblMensaje.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
        }
    }
}