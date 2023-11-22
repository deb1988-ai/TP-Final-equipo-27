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
    public partial class Clientes : System.Web.UI.Page
    {
        List<Usuario> listaUsuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            listaUsuarios = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.Cliente);

            dgvClientes.DataSource = listaUsuarios;
            dgvClientes.DataBind();
        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int IdCliente = Convert.ToInt32(e.CommandArgument.ToString());
                Response.Redirect("AltaUsuario.aspx?id=" + IdCliente);
            }
            if (e.CommandName == "btnEliminar")
            {
                int IdCliente = Convert.ToInt32(e.CommandArgument.ToString());
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                usuarioNegocio.EliminarUsuario(IdCliente);
                Response.Redirect("Clientes.aspx");
            }
        }

        protected void TextBoxNombre_DataBinding(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            GridViewRow row = (GridViewRow)textBox.NamingContainer;
            textBox.Text = DataBinder.Eval(row.DataItem, "DatosCliente.Nombre").ToString();
        }

        protected void dgvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("AltaUsuario.aspx?TipoUsuario=Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}