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
    public partial class AltaIncidente : System.Web.UI.Page
    {
        List<Motivo> listaMotivos = new List<Motivo>();
        protected void Page_Load(object sender, EventArgs e)
        {
            MotivoNegocio motivoNegocio = new MotivoNegocio();
            listaMotivos = motivoNegocio.listarMotivos();

            DropDownListMotivo.DataSource = listaMotivos;
            DropDownListMotivo.DataBind();
            DropDownListMotivo.DataTextField = "motivo";
            DropDownListMotivo.DataValueField = "Idmotivo";
            DropDownListMotivo.DataBind();
        }
    }
}