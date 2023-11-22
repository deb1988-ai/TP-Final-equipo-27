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
    public partial class Contact : Page
    {
        List<Incidente> listaIncidentes = new List<Incidente>();
        Usuario usuario = new Usuario();
        public string FiltroSeleccionado { get; set; }
        public int ResponsableSeleccionado { get; set; }
        public int ClienteSeleccionado { get; set; }
        public int MesSeleccionado { get; set; }
        public int AnioSeleccionado { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null)
            {
                lblError.Text = "Error: No se encontraron datos de usuario en la sesión.";
                Response.Redirect("Default.aspx");
                return;
            }

            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            List<Usuario> listaUsuarios = new List<Usuario>();
            List<Usuario> listaClientes = new List<Usuario>();
            List<Incidente> ListaFiltrada = new List<Incidente>();

            listaUsuarios = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.Telefonista);
            listaClientes = usuarioNegocio.listarUsuarios((int)EnumTipoUsuario.Cliente);

            FiltroSeleccionado = Request.QueryString["Filtro"];


            if (Request.QueryString["Responsable"] != null)
            {
                ResponsableSeleccionado = Convert.ToInt32(Request.QueryString["Responsable"]);
            }
            if (Request.QueryString["Fecha"] != null && Request.QueryString["Anio"] != null)
            {
                MesSeleccionado = Convert.ToInt32(Request.QueryString["Fecha"]);
                AnioSeleccionado = Convert.ToInt32(Request.QueryString["Anio"]);
            }
            if (Request.QueryString["Cliente"] != null)
            {
                ClienteSeleccionado = Convert.ToInt32(Request.QueryString["Cliente"]);
            }

            IncidenteNegocio incidenteNegocio = new IncidenteNegocio();

            usuario = (Usuario)Session["Usuario"];

            if (!IsPostBack)
            {
                ListItem item0 = new ListItem("--------", "0");               
                ListItem item1 = new ListItem("Fecha", "1");
                ListItem item2 = new ListItem("Cliente", "2");
           
                DropDownListFiltro.Items.Add(item0);
                DropDownListFiltro.Items.Add(item1);
                DropDownListFiltro.Items.Add(item2);

                if (usuario.TipoUsuario.IdTipoUsuario == 1 || usuario.TipoUsuario.IdTipoUsuario == 3)
                {
                    ListItem item3 = new ListItem("Responsable", "3");
                    DropDownListFiltro.Items.Add(item3);
                }

                ddlClientes.DataSource = listaClientes;      
                ddlClientes.DataTextField = "NombreCompleto";
                ddlClientes.DataValueField = "IdUsuario";
                ddlClientes.DataBind();

                ddlResponsable.DataSource = listaUsuarios;
                ddlResponsable.DataTextField = "NombreCompleto";
                ddlResponsable.DataValueField = "IdUsuario";
                ddlResponsable.DataBind();

                if (usuario.TipoUsuario.IdTipoUsuario == 1 || usuario.TipoUsuario.IdTipoUsuario == 3)
                {
                    listaIncidentes = incidenteNegocio.listarIncidentes();
                    dgvIncidentes.DataSource = listaIncidentes;
                    dgvIncidentes.DataBind();
                }
                else if (usuario.TipoUsuario.IdTipoUsuario == 2)
                {
                    listaIncidentes = incidenteNegocio.listarIncidentesPorResponsable(usuario.IdUsuario);
                    dgvIncidentes.DataSource = listaIncidentes;
                    dgvIncidentes.DataBind();
                }

                List<DateTime> listaFechas = new List<DateTime>();

                foreach (var item in listaIncidentes)
                {
                    DateTime fechaCreacion = item.FechaCreacion;
                    listaFechas.Add(fechaCreacion);
                }

                List<int> mesesUnicos = listaFechas.GroupBy(fecha => fecha.Month).Select(grupo => grupo.Key).ToList();
                List<int> aniosUnicos = listaFechas.GroupBy(fecha => fecha.Year).Select(grupo => grupo.Key).ToList();

                ddlFechaMes.DataSource = mesesUnicos;
                ddlFechaMes.DataBind();
                ddlFechaAnio.DataSource = aniosUnicos;
                ddlFechaAnio.DataBind();

                if (Request.QueryString["Filtro"] != null)
                {
                    if (FiltroSeleccionado == "1")
                    {
                        for (int i = 0; i < listaIncidentes.Count; i++)
                        {
                            if (listaIncidentes[i].FechaCreacion.Month == MesSeleccionado && listaIncidentes[i].FechaCreacion.Year == AnioSeleccionado)
                            {
                                ListaFiltrada.Add(listaIncidentes[i]);
                            }
                        }
                    }
                    else if (FiltroSeleccionado == "2")
                    {
                        for (int i = 0; i < listaIncidentes.Count; i++)
                        {
                            if (listaIncidentes[i].Cliente.IdUsuario == ClienteSeleccionado)
                            {
                                ListaFiltrada.Add(listaIncidentes[i]);
                            }
                        }
                    }
                    else if (FiltroSeleccionado == "3")
                    { 
                        for (int i = 0; i < listaIncidentes.Count; i++)
                        {
                            if (listaIncidentes[i].Responsable.IdUsuario == ResponsableSeleccionado)
                            {
                                ListaFiltrada.Add(listaIncidentes[i]);
                            }
                        }
                    }
                    dgvIncidentes.DataSource = ListaFiltrada;
                    dgvIncidentes.DataBind();
                }
            }
        }

        protected void dgvIncidentes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "btnDetalle")
            {
                int IdIncidente = Convert.ToInt32(e.CommandArgument.ToString());

                Response.Redirect("Detalle.aspx?id=" + IdIncidente);
            }
        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            string filtro = DropDownListFiltro.SelectedIndex.ToString();

            if (DropDownListFiltro.SelectedIndex == 1)
            {
                string opcionMes = ddlFechaMes.SelectedItem.ToString();
                string opcionAnio = ddlFechaAnio.SelectedItem.ToString();
                Response.Redirect("Incidentes.aspx?Filtro=" + filtro + "&Fecha=" + opcionMes + "&Anio=" + opcionAnio, false);
            }
            else if (DropDownListFiltro.SelectedIndex == 2)
            {
                string opcion = ddlClientes.SelectedItem.Value.ToString();

                Response.Redirect("Incidentes.aspx?Filtro=" + filtro + "&Cliente=" + opcion, false);
            }
            else if (DropDownListFiltro.SelectedIndex == 3)
            {       
                string opcion = ddlResponsable.SelectedItem.Value.ToString();

                Response.Redirect("Incidentes.aspx?Filtro=" + filtro + "&Responsable=" + opcion, false);
            }
        }

        protected void ddlClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddlResponsable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownListFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFechaAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void ddlFechaMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}