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
                PersonaNegocio personaNegocio = new PersonaNegocio();
                List<string> listaEmails = personaNegocio.ListarEmails();

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

                    if (usuario.TipoUsuario.IdTipoUsuario == (int)EnumTipoUsuario.CLIENTE)
                    {

                        ddlTiposUsuario.Items.Remove(ddlTiposUsuario.Items.FindByText("Administrador"));
                        ddlTiposUsuario.Items.Remove(ddlTiposUsuario.Items.FindByText("Telefonista"));
                        ddlTiposUsuario.Items.Remove(ddlTiposUsuario.Items.FindByText("Supervisor"));
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
                Usuario usuario = ((Usuario)Session["Usuario"]);
                
                listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.CLIENTE, tipoUsuario = EnumTipoUsuario.CLIENTE.ToString() });
                if (usuario != null) {
                    switch (usuario.TipoUsuario.IdTipoUsuario)
                    {
                        case (int)EnumTipoUsuario.TELEFONISTA:
                            listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.TELEFONISTA, tipoUsuario = EnumTipoUsuario.TELEFONISTA.ToString() });
                            break;

                        case (int)EnumTipoUsuario.SUPERVISOR:
                            listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.TELEFONISTA, tipoUsuario = EnumTipoUsuario.TELEFONISTA.ToString() });
                            listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.SUPERVISOR, tipoUsuario = EnumTipoUsuario.SUPERVISOR.ToString() });
                            break;
                        case (int)EnumTipoUsuario.ADMINISTRADOR:
                            listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.TELEFONISTA, tipoUsuario = EnumTipoUsuario.TELEFONISTA.ToString() });
                            listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.SUPERVISOR, tipoUsuario = EnumTipoUsuario.SUPERVISOR.ToString() });
                            listaTiposUsuario.Add(new TipoUsuario { IdTipoUsuario = (int)EnumTipoUsuario.ADMINISTRADOR, tipoUsuario = EnumTipoUsuario.ADMINISTRADOR.ToString() });
                            break;
                    }
                }
                else
                {
                    ddlTiposUsuario.Visible = false;
                    lblTiposUsuarios.Visible = false;
                }

                ddlTiposUsuario.DataSource = listaTiposUsuario;
                ddlTiposUsuario.DataTextField = "tipoUsuario";
                ddlTiposUsuario.DataValueField = "IdTipoUsuario";
                ddlTiposUsuario.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            PersonaNegocio personaNegocio = new PersonaNegocio();
            try
            {
                Page.Validate();
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
                    if (usuario.TipoUsuario.IdTipoUsuario == (int)EnumTipoUsuario.CLIENTE)
                    {
                        Response.Redirect("AltaIncidente.aspx");
                    }
                    else
                    {
                        Response.Redirect("Usuarios.aspx");
                    }
                }
                else
                {
                    if (Page.IsValid)
                    {
                        if (!personaNegocio.validarEmail(usuario.DatosPersonales.Email))
                        {

                        }
                        else { lblErrores.InnerText = "Ya hay otro usuario con ese mail"; }



                        //if (txtLogin.Visible == true)
                        //{
                        //    if (!usuarioNegocio.validarLogin(usuario.Login))
                        //    {
                        //        lblErrorLogin.Visible = true;
                        //    }
                        //    else
                        //    {
                        //        lblErrorLogin.Visible = false;
                        //    }
                        //    if (personaNegocio.validarEmail(usuario.DatosPersonales.Email) && usuarioNegocio.validarLogin(usuario.Login))
                        //    {
                        //        lblErrorEmail.Visible = false;
                        //        lblErrorLogin.Visible = false;

                        //        personaNegocio.CrearPersona(usuario.DatosPersonales);
                        //        usuario.DatosPersonales.IdPersona = personaNegocio.ObtenerUltimoIdPersona();
                        //        usuarioNegocio.CrearUsuario(usuario);
                        //        Response.Redirect("Usuarios.aspx", false);
                        //    }
                        //}
                        //else
                        //{
                        //    if (personaNegocio.validarEmail(usuario.DatosPersonales.Email))
                        //    {
                        //        lblErrorEmail.Visible = false;
                        //        lblErrorLogin.Visible = false;

                        //        personaNegocio.CrearPersona(usuario.DatosPersonales);
                        //        usuario.DatosPersonales.IdPersona = personaNegocio.ObtenerUltimoIdPersona();
                        //        usuarioNegocio.CrearUsuario(usuario);
                        //        Response.Redirect("Clientes.aspx", false);
                        //    }
                        //    else
                        //    {
                        //        lblErrorEmail.Visible = true;
                        //    }
                        //}
                    }

                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

    }
}