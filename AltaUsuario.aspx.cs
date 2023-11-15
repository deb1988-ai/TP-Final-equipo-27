using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_equipo_27
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarListas();
                if (Session["Usuario"] == null)
                {
                    lblPassword.Visible = false;
                    txtPassword.Visible = false;
                    lblLogin.Visible = false;
                    txtLogin.Visible = false;
                    ddlTiposUsuario.Items.Remove(ddlTiposUsuario.Items.FindByText("Administrador"));
                    ddlTiposUsuario.Items.Remove(ddlTiposUsuario.Items.FindByText("Telefonista"));
                    ddlTiposUsuario.Items.Remove(ddlTiposUsuario.Items.FindByText("Supervisor"));
                }

                if (Request.QueryString["id"] != null)
                {
                    int IdUsuarioSeleccionado = Convert.ToInt32(Request.QueryString["id"]);

                    Usuario usuario = new Usuario();
                    UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                    usuario = usuarioNegocio.ObtenerUsuario(IdUsuarioSeleccionado);
                    txtNombreCliente.Text = usuario.DatosPersonales.Nombre;
                    txtApellido.Text = usuario.DatosPersonales.Apellido;
                    txtEmail.Text = usuario.DatosPersonales.Email;
                    txtTelefono.Text = usuario.DatosPersonales.Telefono;
                    btnAgregar.Text = "Aceptar";
                    
                    if(usuario.TipoUsuario.IdTipoUsuario == 4)
                    {
                        lblPassword.Visible = false;
                        txtPassword.Visible = false;
                        lblLogin.Visible = false;
                        txtLogin.Visible = false;
                    }
                }
            }
        }

        private void LlenarListas()
        {
            List<TipoUsuario> listaTiposUsuario = new List<TipoUsuario>();
            TipoUsuarioNegocio tipoUsuarioNegocio = new TipoUsuarioNegocio();

            try
            {
                listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.Administrador, tipoUsuario = EnumTipoUsuario.Administrador.ToString() });
                listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.Telefonista, tipoUsuario = EnumTipoUsuario.Telefonista.ToString() });
                listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.Supervisor, tipoUsuario = EnumTipoUsuario.Supervisor.ToString() });
                listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.Cliente, tipoUsuario = EnumTipoUsuario.Cliente.ToString() });

                ddlTiposUsuario.DataSource = listaTiposUsuario;
                ddlTiposUsuario.DataTextField = "tipoUsuario";
                ddlTiposUsuario.DataValueField = "IdTipoUsuario";
                ddlTiposUsuario.DataBind();

            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PersonaNegocio personaNegocio = new PersonaNegocio();
            try
            {
                usuario.DatosPersonales = new Persona
                {
                    Nombre = txtNombreCliente.Text,
                    Apellido = txtApellido.Text,
                    Email = txtEmail.Text,
                    Telefono = txtTelefono.Text
                };

                usuario.TipoUsuario = new TipoUsuario();
                usuario.TipoUsuario.IdTipoUsuario = int.Parse(ddlTiposUsuario.SelectedItem.Value);
                usuario.Login = txtLogin.Text;
                usuario.Password = txtPassword.Text;

                if (Request.QueryString["id"] != null)
                {
                    int IdUsuarioSeleccionado = Convert.ToInt32(Request.QueryString["id"]);
                    Usuario aux = new Usuario();
                    aux = usuarioNegocio.ObtenerUsuario(IdUsuarioSeleccionado);
                    usuario.DatosPersonales.IdPersona = aux.DatosPersonales.IdPersona;
                    usuarioNegocio.ModificarUsuario(usuario);

                }
                else
                {
                    personaNegocio.CrearPersona(usuario.DatosPersonales);
                    usuario.DatosPersonales.IdPersona = personaNegocio.ObtenerUltimoIdPersona();

                    usuarioNegocio.CrearUsuario(usuario);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}