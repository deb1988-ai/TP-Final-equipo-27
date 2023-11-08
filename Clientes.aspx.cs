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
        List<Cliente> listaClientes = new List<Cliente>();
        protected void Page_Load(object sender, EventArgs e)
        {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                listaClientes = clienteNegocio.listarClientes();
            
                dgvClientes.DataSource = listaClientes;
                dgvClientes.DataBind();

        }

        protected void dgvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnEditar")
            {
                int IdCliente = Convert.ToInt32(e.CommandArgument.ToString());
                
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {

            //btnEditar.Enabled = false;
           // btnAceptar.Enabled = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void TextBoxNombre_DataBinding(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            GridViewRow row = (GridViewRow)textBox.NamingContainer;
            textBox.Text = DataBinder.Eval(row.DataItem, "DatosCliente.Nombre").ToString();
        }

        protected void dgvClientes_RowEditing(object sender, GridViewEditEventArgs e)
        {
            /*dgvClientes.EditIndex = e.NewEditIndex;
            dgvClientes.DataBind();
            GridViewRow row = dgvClientes.Rows[e.NewEditIndex];
            TextBox textBox = (TextBox)row.FindControl("TextBoxNombre");
            BoundField boundField = ;
            textBox.Text = DataBinder.Eval(row.DataItem, boundField.DataField).ToString();
            textBox.Visible = true;
            boundField.Visible = false;*/
            
        }

        protected void ButtonAgregar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            try
            {
                cliente.DatosCliente = new Persona();
                cliente.DatosCliente.Nombre = TextBoxNombre.Text;
                cliente.DatosCliente.Apellido = TextBoxApellido.Text;
                cliente.DatosCliente.Telefono = TextBoxTelefono.Text;
                cliente.DatosCliente.Email = TextBoxEmail.Text;

                clienteNegocio.AgregarCliente(cliente);
                Response.Redirect("Clientes.aspx");
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}