using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Forms
{
    public partial class frmCP_RegistroSplit : System.Web.UI.Page
    {
        //variable publica por medio de la cual se instancia la capa de datos
        public Planilla_WCF servicio;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) { Response.Redirect("../Default.aspx"); }
            LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");
            LinkButton mpLinkButton = (LinkButton)mpLongView.FindControl("LoginTag");
            LinkButton mpLogoffButton = (LinkButton)mpLongView.FindControl("LogoffTag");
            mpLinkButton.Visible = false;
            mpLogoffButton.Visible = true;

            if (Session["Usuario"].Equals("Administrador") == false)
            {
                LinkButton mpLkbPlanillas = (LinkButton)mpLongView.FindControl("lkbPlanillas");
                LinkButton mpLkbPlazass = (LinkButton)mpLongView.FindControl("lkbPlazas");
                LinkButton mpLkbUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");

                mpLkbPlanillas.Visible = true;
                mpLkbPlazass.Visible = false;
                mpLkbUsuarios.Visible = false;
            }

            //se instancia la clase de base de datos
            servicio = new Planilla_WCF();
            CargarGrid();

        }

        #region Botonera
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var codigo = Int32.Parse(txtCodigo.Text);
            var nombre = txtNombre.Text;

            try
            {
                servicio.RegistrarSplit(codigo, nombre, null);
                CargarGrid();
                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
            }
            catch (Exception ex)
            {
                FailureText.Text = "Se presento un problema al procesar la información.";
                ErrorMessage.Visible = true;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            tbBtnSec.Visible = true;
            tbBtnPrinc.Visible = false;
            txtNombre.Enabled = true;
            txtCodigo.Enabled = true;
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            var codigo = Int32.Parse(txtCodigo.Text);
            var nombre = txtNombre.Text;
            var id = Int32.Parse(idSplit.Value);

            try
            {
                servicio.RegistrarSplit(codigo, nombre, id);
                CargarGrid();
                txtCodigo.Text = string.Empty;
                txtNombre.Text = string.Empty;
            }
            catch (Exception ex)
            {
                FailureText.Text = "Se presento un problema al procesar la información.";
                ErrorMessage.Visible = true;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Se limpian los textbox
            txtCodigo.Text = string.Empty;
            txtNombre.Text = string.Empty;

            //Se habilitan los mismos
            txtCodigo.Enabled = true;
            txtNombre.Enabled = true;

            //Se muestra la botonera principal
            tbBtnPrinc.Visible = true;
            btnRegistrar.Visible = true;
            btnModificar.Visible = false;

            //Se oculta la botonera secundaria
            tbBtnSec.Visible = false;
        }
        #endregion

        #region GridView
        protected void gvListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se deshabilita la botonera secundaria
            tbBtnSec.Visible = false;

            //Se habilita la botonera principal
            tbBtnPrinc.Visible = true;

            //Se realiza el manejo de botones de acuerdo a la acción
            btnRegistrar.Visible = false;
            btnModificar.Visible = true;

            //Se establecen los valores del elemento seleccionado en los respectivos textbox
            txtCodigo.Text = gvListado.Rows[gvListado.SelectedIndex].Cells[2].Text;
            txtNombre.Text = gvListado.Rows[gvListado.SelectedIndex].Cells[3].Text;
            idSplit.Value = gvListado.Rows[gvListado.SelectedIndex].Cells[1].Text;

            //Se deshabilitan los campos de texto
            txtNombre.Enabled = false;
            txtCodigo.Enabled = false;
        }

        protected void CargarGrid()
        {
            var datos = servicio.ObtenerSplits();
            if (datos.Rows.Count > 0)
            {
                gvListado.DataSource = datos;
                gvListado.DataBind();
            }
            else
            {
                DataTable table = new DataTable();
                table = null;
                gvListado.DataSource = table;
                gvListado.DataBind();

                //En caso de que la consulta no recupere datos se informa del problema.
                FailureText.Text = "No se han registrado Splits.";
                ErrorMessage.Visible = true;
            }
        }
        #endregion
    }
}