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

                string password = usuarioNegocio.ObtenerPassword(txtUsuario.Text);

                string asunto = "Contraseña usuario" + txtUsuario.Text;

                string body = "Su contraseña es: " + password;

                lblMensaje.Text = "Contraseña enviada.";
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
            }
        }
    }
}