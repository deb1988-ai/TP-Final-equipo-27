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
    public partial class Usuarios : System.Web.UI.Page
    {
        List<Usuario> listaUsuarios = new List<Usuario>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Default.aspx");              
            }

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            listaUsuarios = usuarioNegocio.listarUsuarios();

            dgvUsuarios.DataSource = listaUsuarios;
            dgvUsuarios.DataBind();
        }

        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int IdUsuario = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("AltaUsuario.aspx?id=" + IdUsuario);
            }
            if (e.CommandName == "btnEliminar")
            {
                int IdUsuario = Convert.ToInt32(e.CommandArgument.ToString());
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.EliminarUsuario(IdUsuario);
                Response.Redirect("Usuarios.aspx",false);
            }
        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaUsuario.aspx", false);
        }
    }
}