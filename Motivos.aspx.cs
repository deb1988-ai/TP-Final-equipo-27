using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Final_equipo_27
{
    public partial class Motivos : System.Web.UI.Page
    {
        List<Motivo> listaMotivos = new List<Motivo>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrilla();
            }
        }

        protected void dgvMotivos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = dgvMotivos.Rows[index];
            Label lblMotivo = (Label)row.FindControl("lblMotivo");

            if (e.CommandName == "btnEditar")
            {           
                TextBox txtMotivo = (TextBox)row.FindControl("txtMotivo");
                LinkButton btnEditar = (LinkButton)row.FindControl("btnEditar");
                LinkButton btnEliminar = (LinkButton)row.FindControl("btnEliminar");
                LinkButton btnGuardar = (LinkButton)row.FindControl("btnGuardar");

                lblMotivo.Visible = false;
                txtMotivo.Visible = true;
                btnEditar.Visible = false;
                btnEliminar.Visible = false;
                btnGuardar.Visible = true;
            }
            else if (e.CommandName == "btnGuardar")
            {
                TextBox txtMotivo = (TextBox)row.FindControl("txtMotivo");
                int IdMotivo = Convert.ToInt32(dgvMotivos.DataKeys[index].Value);
                Motivo motivo = new Motivo { idMotivo = IdMotivo, motivo = txtMotivo.Text };

                MotivoNegocio motivoNegocio = new MotivoNegocio();
                motivoNegocio.Modificar(motivo);

                CargarGrilla();
            }
            if (e.CommandName == "btnEliminar")
            {
                int IdMotivo = Convert.ToInt32(dgvMotivos.DataKeys[index].Value);
                MotivoNegocio motivoNegocio = new MotivoNegocio();
                motivoNegocio.Eliminar(IdMotivo);

                CargarGrilla();
            }
        }
        private void CargarGrilla()
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            listaMotivos = motivoNegocio.listarMotivos();

            dgvMotivos.DataSource = listaMotivos;
            dgvMotivos.DataBind();
        }

        protected void btnAgregarMotivo_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBoxMotivos.Text.Length > 4)
                {
                    MotivoNegocio motivoNegocio = new MotivoNegocio();
                    Motivo motivo = new Motivo();
                    motivo.motivo = TextBoxMotivos.Text;
                    motivoNegocio.Agregar(motivo);
                    TextBoxMotivos.Text = "";
                    TextBoxMotivos.Visible = false;
                    btnAgregarMotivo.Visible = false;
                    btnAgregar.Visible = true;
                    lblErrorMotivo.Visible = false;
                    CargarGrilla();
                }
                else
                {
                    lblErrorMotivo.Visible = true;
                    lblErrorMotivo.Text = "Debe ingresar al menos 4 caracteres para el motivo.";
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            TextBoxMotivos.Visible = true;
            btnAgregarMotivo.Visible = true;
            btnAgregar.Visible = false;
        }
    }
}