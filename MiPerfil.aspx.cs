using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TP_Final_equipo_27
{
    public partial class MiPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];

            lblNombre.Text = usuario.DatosPersonales.Nombre;
            lblApellido.Text = usuario.DatosPersonales.Apellido;
            lblEmail.Text = usuario.DatosPersonales.Email;
            if(usuario.DatosPersonales.Telefono != null)
            {
                lblTelefono.Text = usuario.DatosPersonales.Telefono;
            } else
            {
                lblTelefono.Text = "Número de elefono no regitrado.";
            }
            
            lblPerfil.Text = usuario.TipoUsuario.tipoUsuario;
            lblLogin.Text = usuario.Login;
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}