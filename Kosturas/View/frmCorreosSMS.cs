using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class frmCorreosSMS : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmCorreosSMS()
        {
            InitializeComponent();
        }

        private void frmCorreosSMS_Load(object sender, EventArgs e)
        {

            try
            {
                ConfiguracionEnvioCorreos configuracion = db.ConfiguracionEnvios.Find(1);

                txtNombre.Text = configuracion.NombreEmpresa;
                txtEncabezado.Text = configuracion.Emcabezado;
                txtDirecionRecibo.Text = configuracion.Dirrecion;
                txtHorario.Text = configuracion.Horario;
                txtPiePagina.Text = configuracion.PiePagina;
                txtDirecionLinea1.Text = configuracion.DirrecionLinea1;
                txtDirecionLinea2.Text = configuracion.DirrecionLinea2;
                txtTelefono.Text = configuracion.Telefono;
                txtSitioWeb.Text = configuracion.PaginaWeb;
                txtNumeroEmpresa.Text = configuracion.NumeroEmpresa;
                txtMontoCaja.Text = configuracion.MontoInicialCaja.ToString();
                txtMontoOrdenes.Text = configuracion.CantidadDineroPorHora.ToString();
                txtSTP.Text = configuracion.STPMinutos;
                txtCorreo.Text = configuracion.CorreoEmpresa;
                txtSMS.Text = configuracion.SMSEmpresa;
                ckbCorreo.Checked = configuracion.ActivoCorreo;
                ckbSMS.Checked = configuracion.ActivoSMS;
            }
            catch (Exception)
            {

            }
          

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                ConfiguracionEnvioCorreos configuracion = db.ConfiguracionEnvios.Find(1);

                configuracion.NombreEmpresa = txtNombre.Text;
                configuracion.Emcabezado = txtEncabezado.Text;
                configuracion.Dirrecion = txtDirecionRecibo.Text;
                configuracion.Horario = txtHorario.Text;
                configuracion.PiePagina = txtPiePagina.Text;
                configuracion.DirrecionLinea1 = txtDirecionLinea1.Text;
                configuracion.DirrecionLinea2 = txtDirecionLinea2.Text;
                configuracion.Telefono = txtTelefono.Text;
                configuracion.PaginaWeb = txtSitioWeb.Text;
                configuracion.NumeroEmpresa = txtNumeroEmpresa.Text;
                configuracion.MontoInicialCaja = double.Parse(txtMontoCaja.Text);
                configuracion.CantidadDineroPorHora = double.Parse(txtMontoOrdenes.Text);
                configuracion.STPMinutos = txtSTP.Text;
                configuracion.CorreoEmpresa = txtCorreo.Text;
                configuracion.SMSEmpresa = txtSMS.Text;
                configuracion.ActivoCorreo = ckbCorreo.Checked;
                configuracion.ActivoSMS = ckbSMS.Checked;


                db.Entry(configuracion).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Dato Actualizado");
            }
            catch (Exception)
            {
                
            }
          

        }
    }
}
