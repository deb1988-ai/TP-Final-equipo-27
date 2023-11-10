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
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarListas();
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
                    Email = txtApellido.Text,
                    Telefono = txtTelefono.Text
                };

                usuario.TipoUsuario = new TipoUsuario();
                usuario.TipoUsuario.IdTipoUsuario = int.Parse(ddlTiposUsuario.SelectedItem.Value);
                usuario.Login = txtLogin.Text;
                usuario.Password = txtPassword.Text;

                personaNegocio.CrearPersona(usuario.DatosPersonales);
                usuario.DatosPersonales.IdPersona = personaNegocio.ObtenerUltimoIdPersona();

                usuarioNegocio.CrearUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}