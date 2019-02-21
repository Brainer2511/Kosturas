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
        Color ColorEntrada;
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
            try
            {
                this.lblCalcularCambio.Visible = false;
                this.lblCAmbio.Visible = false;
                this.lblresultado.Visible = false;
                this.txtCalcularCambio.Visible = false;
                var query = db.Ordenes.Where(q => q.OrdenId == OrdenId).ToList();
                if (query.Count > 0)
                {
                    this.txtMonto.Text = query.Last().CantidadRestante.ToString();
                }
                else { this.txtMonto.Text = "0"; this.btnAgregarPago.Enabled = true; }
                if (query.FirstOrDefault().CantidadRestante == 0) { this.btnAgregarPago.Enabled = false; }

                cbPagos.DataSource = db.MediosPago.ToList();
                cbPagos.DisplayMember = "FormaPago";
                cbPagos.ValueMember = "MedioPagoId";

                cbPagos.SelectedIndex = 0;
            }
            catch (Exception)
            {

               
            }

       


        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            try
            {
                frmPin pin = new frmPin();
                this.Opacity = 0.80;
                pin.ShowDialog();
                this.Opacity = 1;
                var query = db.Pagos.Where(q => q.OrdenId == OrdenId).ToList();
                if (query.Count > 0)
                {



                    var idPAgo = query.FirstOrDefault().PagoId;
                    Pagos pagos = db.Pagos.Find(idPAgo);
                    var MontoActual = query.Last().Monto;

                    pagos.MedioPagoId = int.Parse(cbPagos.SelectedValue.ToString());
                    pagos.OrdenId = OrdenId;
                    if (!string.IsNullOrEmpty(txtMonto.Text)) { pagos.Monto = MontoActual - double.Parse(txtMonto.Text); }
                    else { pagos.Monto = MontoActual - double.Parse("0"); }

                    db.Entry(pagos).State = EntityState.Modified;
                    db.SaveChanges();

                }
                Pagos pago = new Pagos();
                pago.Fecha = DateTime.Today;
                pago.EmpleadoRealizo = Program.Pin;
                pago.Monto = double.Parse(txtMonto.Text);

                pago.MedioPagoId = int.Parse(cbPagos.SelectedValue.ToString());
                pago.OrdenId = OrdenId;
                db.Pagos.Add(pago);
                db.SaveChanges();

                Ordenes orden = db.Ordenes.Find(OrdenId);
                orden.CantidadPagada = double.Parse(txtMonto.Text);
                orden.CantidadRestante = orden.CantidadRestante - double.Parse(txtMonto.Text);
                db.Entry(orden).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch (Exception)
            {

            }
            
          

        }

        private void cbPagos_SelectedIndexChanged(object sender, EventArgs e)
        {

           

                this.lblCalcularCambio.Visible = true;
                this.lblCAmbio.Visible = true;
                this.lblresultado.Visible = true;
                this.txtCalcularCambio.Visible = true;

        
        }

        private void btnCompletar_Click(object sender, EventArgs e)
        {

        
            this.Close();
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;
      
           
            ClickCambiarEstado();
        }

        private void btnCompletar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnCompletar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        void ClickCambiarEstado()
        {

            try
            {
                if (Program.Pin != null)
                {
                    var Mensaje = MessageBox.Show("Esta Seguro desea Completar Orden", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (Mensaje == DialogResult.Yes)
                    {


                        var Orden = db.Ordenes.Find(OrdenId);

                        Orden.Prendas.SelectMany(m => m.DetalleTareas).ToList().ForEach(w => { w.Estado = true; w.EmpleadoActualizo = Program.Pin; });


                        db.SaveChanges();


                    }




                }
            }
            catch (Exception)
            {

                throw;
            }


     




        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCalcularCambio_KeyPress(object sender, KeyPressEventArgs e)
        {
            String x = "";


            x = this.txtCalcularCambio.Text + e.KeyChar;

            if (e.KeyChar == '\b')
            {
                if (x.Length == 1)
                {
                    x = x.Remove(x.Length - 1);

                }
                else
                {
                    x = x.Remove(x.Length - 2);

                }
            }




            var total = int.Parse(this.txtMonto.Text);
            if (x != "")
            {
                var residuo = int.Parse(x);
                var Resultado = residuo - total;
                lblresultado.Text = Resultado.ToString();
            }
        }
    }
}
