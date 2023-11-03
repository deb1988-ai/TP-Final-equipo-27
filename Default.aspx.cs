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

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario();
            UsuarioNegocio userNegocio = new UsuarioNegocio();

            try
            {
                user.Email = txtUser.Text;
                user.Password = txtPass.Text;

                if (userNegocio.Login(user))
                {
                    Session.Add("Usuario", user);
                    Response.Redirect("Main.aspx",false);
                }
                else
                {
                    Session.Add("Error", "El mail o pass son incorrectos");
                }
            }
            catch(Exception ex)
            {
                Session.Add("Error", ex.Message);
                Response.Redirect("Default.aspx");
            }
        }
    }
}