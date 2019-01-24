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
    public partial class CompletarAgregarPago : Form
    {
        DataContextLocal db = new DataContextLocal();
        public int OrdenId { get; set; }
       // private Ordenes abono = new Ordenes();
        private Pagos abono = new Pagos();
        public CompletarAgregarPago(int ordenId=0)
        {

            OrdenId = ordenId;
           
            InitializeComponent();
        }

        private void txtPin_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CompletarAgregarPago_Load(object sender, EventArgs e)
        {


            this.lblCalcularCambio.Visible = false;
            this.lblCAmbio.Visible = false;
            this.lblresultado.Visible = false;
            this.txtCalcularCambio.Visible = false;
            var query = db.Pagos.Where(q => q.OrdenId == OrdenId).ToList();
            this.txtMonto.Text =query.Last().Monto.ToString();
            
            cbPagos.DataSource = db.MediosPago.ToList();
            cbPagos.DisplayMember = "FormaPago";
            cbPagos.ValueMember = "MedioPagoId";

            cbPagos.SelectedIndex = 1;
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;
            var query = db.Pagos.Where(q => q.OrdenId == OrdenId).ToList();
            var idPAgo = query.FirstOrDefault().PagoId;
            Pagos pago = new Pagos();
            pago.Fecha = DateTime.Today;
            pago.EmpleadoRealizo = Program.Pin;
            var MontoActual = query.Last().Monto;
            pago.Monto = MontoActual-double.Parse(txtCalcularCambio.Text);
            pago.MedioPagoId = int.Parse(cbPagos.SelectedValue.ToString());
            pago.OrdenId = OrdenId;
            db.Pagos.Add(pago);
            db.SaveChanges();

        }

        private void cbPagos_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbPagos.SelectedIndex == 0)
            {

                this.lblCalcularCambio.Visible = true;
                this.lblCAmbio.Visible = true;
                this.lblresultado.Visible = true;
                this.txtCalcularCambio.Visible = true;

            }
            else
            {

                this.lblCalcularCambio.Visible = false;
                this.lblCAmbio.Visible = false;
                this.lblresultado.Visible = false;
                this.txtCalcularCambio.Visible = false;
            }
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;
            var query = db.Pagos.Where(q => q.OrdenId == OrdenId).ToList();
            var idPAgo = query.FirstOrDefault().PagoId;
            Pagos pago = new Pagos();
            pago.Fecha = DateTime.Today;
            pago.EmpleadoRealizo = Program.Pin;
            var MontoActual = query.Last().Monto;
            pago.Monto = MontoActual - double.Parse(txtCalcularCambio.Text);
            pago.MedioPagoId = int.Parse(cbPagos.SelectedValue.ToString());
            pago.OrdenId = OrdenId;
            db.Pagos.Add(pago);
            db.SaveChanges();
        }
    }
}
