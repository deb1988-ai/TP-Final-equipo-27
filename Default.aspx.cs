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
                    lblMensaje.Text = "Usuario ingresado con exito.";
                    lblMensaje.Visible = true;
                    Response.Redirect("Main.aspx", false);
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                    lblMensaje.Text = "El usuario o password son incorrectos";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Error.aspx");
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
                Response.Redirect("Error.aspx");
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
                Response.Redirect("Error.aspx");
            }
        }
    }
}