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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtLogin.Focus();
            if (Session.Count != 0 & Session["Usuario"] != null)
            {
                Response.Redirect("Main.aspx", false);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                usuario.Login = txtLogin.Text;
                usuario.Password = txtPassword.Text;

                if (usuarioNegocio.Login(usuario))
                {
                    usuario = usuarioNegocio.ObtenerUsuarioLoginYPass(usuario.Login, usuario.Password);
                    Session.Add("Usuario", usuario);
                    Response.Redirect("Main.aspx", false);
                }
                else
                {
                    Session.Add("Error", "El mail o pass son incorrectos");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Default.aspx");
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AltaUsuario.aspx", false);

            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.Message);
            }
        }

        protected void linkBtnContraseña_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("Contraseña.aspx", false);
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.Message);
            }
        }
    }
}