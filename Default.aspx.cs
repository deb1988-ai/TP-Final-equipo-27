﻿using dominio;
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
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            try
            {
                usuario.Login = txtUser.Text;
                usuario.Password = txtPass.Text;

                if (usuarioNegocio.Login(usuario))
                {
                    usuario =  usuarioNegocio.ObtenerUsuarioLoginYPass(usuario.Login, usuario.Password);
                    Session.Add("Usuario", usuario);
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

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            // redirect al alta de usuario o popup
        }
    }
}