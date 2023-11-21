using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

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
            if (!IsPostBack)
            {
                Usuario usuario = new Usuario();
                usuario = (Usuario)Session["Usuario"];

                lblNombre.Text = usuario.DatosPersonales.Nombre;
                lblApellido.Text = usuario.DatosPersonales.Apellido;
                lblEmail.Text = usuario.DatosPersonales.Email;
                if (usuario.DatosPersonales.Telefono != null)
                {
                    lblTelefono.Text = usuario.DatosPersonales.Telefono;
                }
                else
                {
                    lblTelefono.Text = "Número de elefono no regitrado.";
                }

                lblPerfil.Text = usuario.TipoUsuario.tipoUsuario;
                lblLogin.Text = usuario.Login;
            }     
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {  
            lblNombre.Visible = false;
            lblApellido.Visible = false;
            lblEmail.Visible = false;
            lblTelefono.Visible = false;
            lblContraseña.Visible = false;

            txtNombre.Visible = true;
            txtNombre.Text = lblNombre.Text;
            txtApellido.Visible = true;
            txtApellido.Text = lblApellido.Text;
            txtEmail.Visible = true;
            txtEmail.Text = lblEmail.Text;
            txtTelefono.Visible = true;
            txtTelefono.Text = lblTelefono.Text;
            txtContraseña.Visible = true;
            txtContraseña.Text = lblContraseña.Text;

            btnEditar.Visible = false;
            btnAceptarCambios.Visible = true;
        }

        protected void btnAceptarCambios_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario aux = new Usuario();
            aux = (Usuario)Session["Usuario"];
            try
            {
                aux.DatosPersonales.Nombre = txtNombre.Text;
                aux.DatosPersonales.Apellido = txtApellido.Text;
                aux.DatosPersonales.Telefono = txtTelefono.Text;
                aux.DatosPersonales.Email = txtEmail.Text;

                usuarioNegocio.ModificarUsuario(aux);

                Response.Redirect("MiPerfil.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnMostrarContraseña_Click(object sender, ImageClickEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario = (Usuario)Session["Usuario"];

            btnMostrarContraseña.Visible = false;
            btnOcultarContraseña.Visible = true;

            if(lblContraseña.Visible == true)
            {
                lblContraseña.Text = usuario.Password;
                btnMostrarContraseña.ImageUrl = "~/Icons/hide.png";
            }
            else
            {
                txtContraseña.TextMode = TextBoxMode.SingleLine;
            }
                         
        }

        protected void btnOcultarContraseña_Click(object sender, ImageClickEventArgs e)
        {
            btnMostrarContraseña.Visible = true;
            btnOcultarContraseña.Visible = false;

            if (lblContraseña.Visible == true)
            {
                lblContraseña.Text = "************";
                btnMostrarContraseña.ImageUrl = "~/Icons/view.png";
            } else
            {
                txtContraseña.TextMode = TextBoxMode.Password;
            }
        }
    }
}