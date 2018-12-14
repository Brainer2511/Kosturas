using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class frmMedioPagos : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmMedioPagos()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MediosPago mediopago = new MediosPago();

            mediopago.FormaPago = txtFormaPago.Text;
            mediopago.CodigosCuentas = txtCodigoCuentas.Text;
            mediopago.VisualizarOrden = txtVirualisarOrden.Text;
            mediopago.TipoMedio = cmbMedioPago.SelectedItem.ToString();
            mediopago.AbrirCajon = ckbAbrirCAjon.Checked;
            mediopago.IncluirTotal = ckbIncluirtotal.Checked;



            db.MediosPago.Add(mediopago);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dvgMediosPago.DataSource = db.MediosPago.ToList();
        }

        private void frmMedioPagos_Load(object sender, EventArgs e)
        {
            dvgMediosPago.DataSource = db.MediosPago.ToList();
            cmbMedioPago.Items.Add("Efectivo");
            cmbMedioPago.Items.Add("Tarjeta");
            cmbMedioPago.Items.Add("Cheque");
            cmbMedioPago.Items.Add("Transferencia Bancaria");
            cmbMedioPago.Items.Add("Otros");
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
