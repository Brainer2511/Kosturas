using Domain;
using Kosturas.Model;
using Kosturas.ViewModels;
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
    public partial class frmCierreCaja : Form
    {
        DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public List<OrdenViewModel> listaCierres = new List<OrdenViewModel>();
        double Total = 0;
        double TotalSAldo = 0;
        double MontoCaja = 0;
        public int MedioPagoId { get; set; }
        public frmCierreCaja()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRestablecerBilletes_Click(object sender, EventArgs e)
        {
             this.txt5.Text ="0";
            this.lbl5.Text = "= 0,00";

            this.txt10.Text = "0";
            this.lbl10.Text = "= 0,00";

            this.txt25.Text = "0";
            this.lbl25.Text = "= 0,00";

            this.txt50.Text = "0";
            this.lbl50.Text = "= 0,00";

            this.txt100.Text = "0";
            this.lbl100.Text = "= 0,00";

            this.txt500.Text = "0";
            this.lbl500.Text = "= 0,00";

            this.txt1000.Text = "0";
            this.lbl1000.Text = "= 0,00";

            this.txt2000.Text = "0";
            this.lbl2000.Text = "= 0,00";

            this.txt5000.Text = "0";
            this.lbl5000.Text = "= 0,00";

            this.txt10000.Text = "0";
            this.lbl10000.Text = "= 0,00";

            this.txt20000.Text = "0";
            this.lbl20000.Text = "= 0,00";

            this.txt50000.Text = "0";
            this.lbl50000.Text = "= 0,00";
        }

        private void txt5_KeyPress(object sender, KeyPressEventArgs e)
      {
            string x = "";


            x = this.txt5.Text + e.KeyChar;

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




            if (x != "")
            {

                var residuo = int.Parse(x);
                var Resultado = residuo * 5;
                lbl5.Text = "=" + Resultado.ToString() + ",00";

                Sumatoria();
            }

        }

        private void txt10_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt10.Text + e.KeyChar;

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




            if (x != "")
            {
              
                var residuo = int.Parse(x);
                var Resultado = residuo * 10;
                lbl10.Text = "=" + Resultado.ToString() + ",00";

                Sumatoria();
            }
        }

        private void txt25_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt25.Text + e.KeyChar;

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




            if (x != "")
            {
             
                var residuo = int.Parse(x);
                var Resultado = residuo * 25;
                lbl25.Text = "=" + Resultado.ToString() + ",00";
                Sumatoria();
            }
        }

        private void txt50_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt50.Text + e.KeyChar;

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




            if (x != "")
            {
              
                var residuo = int.Parse(x);
                var Resultado = residuo * 50;
                lbl50.Text = "=" + Resultado.ToString() + ",00";

                Sumatoria();
            }
        }

        private void txt100_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt100.Text + e.KeyChar;

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




            if (x != "")
            {
             
                var residuo = int.Parse(x);
                var Resultado = residuo * 100;
                lbl100.Text = "=" + Resultado.ToString() + ",00";

                Sumatoria();
            }
        }

        private void txt500_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt500.Text + e.KeyChar;

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




            if (x != "")
            {
              
                var residuo = int.Parse(x);
                var Resultado = residuo * 500;
                lbl500.Text = "=" + Resultado.ToString() + ",00";
                Sumatoria();
            }
        }

        private void txt1000_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt1000.Text + e.KeyChar;

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




            if (x != "")
            {
              
                var residuo = int.Parse(x);
                var Resultado = residuo * 1000;
                lbl1000.Text = "=" + Resultado.ToString() + ",00";

                Sumatoria();
            }
        }

        private void txt2000_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt2000.Text + e.KeyChar;

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




            if (x != "")
            {
                if (x == "0")
                {


                    TotalSAldo = TotalSAldo - double.Parse((lbl2000.Text).Remove(0, 1));
                    Total = Total + double.Parse((lbl2000.Text).Remove(0, 1));
                }
                var residuo = int.Parse(x);
                var Resultado = residuo * 2000;
                lbl2000.Text = "=" + Resultado.ToString() + ",00";
                Sumatoria();
            }
        }

        private void txt5000_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt5000.Text + e.KeyChar;

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




            if (x != "")
            {
               
                var residuo = int.Parse(x);
                var Resultado = residuo * 5000;
                lbl5000.Text = "=" + Resultado.ToString() + ",00";
                Sumatoria();
               
            }
        }

        private void txt10000_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt10000.Text + e.KeyChar;

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




            if (x != "")
            {
              
                var residuo = int.Parse(x);
                var Resultado = residuo * 10000;
                lbl10000.Text = "=" + Resultado.ToString() + ",00";


                Sumatoria();
            }
        }

        private void txt20000_KeyPress(object sender, KeyPressEventArgs e)
      {
            string x = "";


            x = this.txt20000.Text + e.KeyChar;

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




            if (x != "")
            {
                var residuo = int.Parse(x);
                var Resultado = residuo * 20000;
                lbl20000.Text = "=" + Resultado.ToString() + ",00";


                Sumatoria();
            }
        }

        private void txt50000_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txt50000.Text + e.KeyChar;

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




            if (x != "")
            {
               
                var residuo = int.Parse(x);
                var Resultado = residuo * 50000;
                lbl50000.Text = "=" + Resultado.ToString() + ",00";
                Sumatoria();
            }
        }

        private void txtMontoCaja_KeyPress(object sender, KeyPressEventArgs e)
        {
            string x = "";


            x = this.txtMontoCaja.Text + e.KeyChar;

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




            if (x != "")
           {
             
                txtMontoEfectivo.Text ="-"+ x.ToString() + ",00";
                lblTotalCaja.Text = "-" + x.ToString() + ",00";
                lblTotalEfectivo.Text = x.ToString() + ",00";

            }
            var a = DateTime.Today.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            var Pagos = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).ToList();

            foreach (var item in Pagos)
            {
                if (item.MedioPagoId == 1)
                {

                    lblTotalEfectivo.Text = (double.Parse(lblIngresosEfectivo.Text) + double.Parse(x)).ToString() + ",00";

                }
                if (item.MedioPagoId == 3)
                {
                    lblTotalTarjetas.Text = (double.Parse(lblIngresosTarjeta.Text)).ToString() + ",00";
                }
            }
       

            lblTotalCajaVentas.Text = (double.Parse(lblIngresosEfectivo.Text) +
               double.Parse(lblIngresosTarjeta.Text) +
               double.Parse(lblIngresosCheque.Text) +
               double.Parse(lblTranferencia.Text) +
               double.Parse(lblIngresosOtros.Text) + double.Parse(x)).ToString() + ",00";
        }

        void Sumatoria()
        {
            if (this.txtMontoCaja.Text == "")
            {
                MontoCaja = 0;
            }
            else
            { MontoCaja = double.Parse(this.txtMontoCaja.Text); }


            this.lblSaldoCaja.Text = (double.Parse((lbl5.Text).Remove(0, 1)) +
                double.Parse((lbl10.Text).Remove(0, 1)) +
                double.Parse((lbl25.Text).Remove(0, 1)) +
                double.Parse((lbl50.Text).Remove(0, 1)) +
                double.Parse((lbl100.Text).Remove(0, 1)) +
                double.Parse((lbl500.Text).Remove(0, 1)) +
                double.Parse((lbl1000.Text).Remove(0, 1))
                + double.Parse((lbl2000.Text).Remove(0, 1)) +
                double.Parse((lbl5000.Text).Remove(0, 1)) +
                double.Parse((lbl10000.Text).Remove(0, 1)) +
                double.Parse((lbl20000.Text).Remove(0, 1))
                + double.Parse((lbl50000.Text).Remove(0, 1))).ToString() + ",00";
            var Sumatoria = double.Parse(lblSaldoCaja.Text);
            var ResultadoDatos = Sumatoria - MontoCaja;
            this.txtMontoEfectivo.Text = ResultadoDatos + ",00";
            this.lblTotalCaja.Text = ResultadoDatos + ",00";
        }

        private void CierreCaja_Load(object sender, EventArgs e)
        {

         
             var a =DateTime.Today.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = a + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);



            //dgvPagos.DataSource = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).Select(t => new { t.MediosPago.FormaPago, t.Monto }).ToList();
          //  var Pagos= db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).ToList();

            var query = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta)
             .GroupBy(q => new { q.MedioPagoId, q.MediosPago.FormaPago, q.Fecha, })
             .Select(x => new { MedioPagoId = x.Key.MedioPagoId, Fecha = x.Key.Fecha, MedioPago = x.Key.FormaPago, Total = x.Sum(q => q.Monto) })
             .ToList();
            dgvPagos.DataSource = query.Select(t => new { t.MedioPago, t.Total }).ToList();

            //foreach (var item in Pagos)
            //{
            //    if (item.MedioPagoId==1)
            //    {

            //        lblIngresosEfectivo.Text = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta&&q.MedioPagoId==1).Sum(w=>w.Monto).ToString() + ",00";
            //        lblTotalVentas.Text = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).Sum(w => w.Monto).ToString() + ",00";
            //    }
            //    if (item.MedioPagoId == 3)
            //    {
            //        lblIngresosTarjeta.Text = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta && q.MedioPagoId == 3).Sum(w => w.Monto).ToString() + ",00";
            //        lblTotalVentas.Text= db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).Sum(w => w.Monto).ToString() + ",00";
            //    }
            //}
            foreach (var itemdos in query.ToList())

            {
                if (itemdos.MedioPagoId == 1) { lblIngresosEfectivo.Text = itemdos.Total.ToString(); lblVerDetalleEfectivo.Name = itemdos.MedioPagoId.ToString(); }
                if (itemdos.MedioPagoId == 3) { lblIngresosTarjeta.Text = itemdos.Total.ToString(); lblVerDetalleTarjeta.Name = itemdos.MedioPagoId.ToString(); }
              
            }
            lblTotalVentas.Text = db.Pagos.Where(q => q.Fecha >= fdesde && q.Fecha <= fhasta).Sum(w => w.Monto).ToString() + ",00";
            txtMontoEfectivo.Text = "-" + txtMontoCaja.Text + ",00";
            lblTotalCaja.Text = "-" + txtMontoCaja.Text + ",00";
            lblTotalEfectivo.Text = txtMontoCaja.Text + ",00";

            lblTotalEfectivo.Text = (double.Parse(lblIngresosEfectivo.Text) + double.Parse(txtMontoCaja.Text)).ToString() + ",00";
            lblTotalTarjetas.Text = (double.Parse(lblIngresosTarjeta.Text)).ToString() + ",00";
            lblTotalCajaVentas.Text = (double.Parse(lblTotalVentas.Text) + double.Parse(txtMontoCaja.Text)).ToString() + ",00";
        }

        private void label53_Click(object sender, EventArgs e)
        {
          
            frmVerOrdenes ordenes = new frmVerOrdenes();
            ordenes.Location = new Point(560,550);
            ordenes.ShowDialog();
        }

        private void lblVerDetalleTarjeta_Click(object sender, EventArgs e)
        {
            Label btr = sender as Label;






            var id = int.Parse(btr.Name);
            frmVerDetalles  detalles = new frmVerDetalles(id);
            detalles.Location = new Point(560, 550);
            detalles.ShowDialog();
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            frmPin pin = new frmPin();
            this.Opacity = 0.80;
            pin.ShowDialog();
            this.Opacity = 1;

            CierreCaja cierre = new CierreCaja();

            cierre.MontoInicial = double.Parse(txtMontoCaja.Text);
            cierre.FechaApertura = DateTime.Today;
            cierre.FechaCierre = DateTime.Today;
            cierre.TotalDiferencia = double.Parse(txtMontoEfectivo.Text);
            cierre.Notas = txtNotas.Text;
            cierre.EmpleadoCerro = Program.Pin;

            cierre.CantidadMonedas5 = txt5.Text;
            cierre.CantidadMonedas10 = txt10.Text;
            cierre.CantidadMonedas25 = txt25.Text;
            cierre.CantidadMonedas50 = txt50.Text;
            cierre.CantidadMonedas100 = txt100.Text;
            cierre.CantidadMonedas500 = txt500.Text;

            cierre.CantidadBilletes1000 = txt1000.Text;
            cierre.CantidadBilletes2000 = txt2000.Text;
            cierre.CantidadBilletes5000 = txt5000.Text;
            cierre.CantidadBilletes10000 = txt10000.Text;
            cierre.CantidadBilletes20000 = txt20000.Text;
            cierre.CantidadBilletes50000 = txt50000.Text;

            cierre.CantidadActualEfectivo = lblIngresosEfectivo.Text;
            cierre.CantidadIngresoEfectivo = lblIngresosEfectivo.Text;
            cierre.DiferenciaEfectivo= txtMontoEfectivo.Text;

            cierre.CantidadActualTarjetas = lblIngresosTarjeta.Text;
            cierre.CantidadIngresoTarjetas = lblIngresosTarjeta.Text;
            cierre.DiferenciaTarjetas = txtMontoTarjeta.Text;

            cierre.CantidadActualCheques = lblIngresosCheque.Text;
            cierre.CantidadIngresoCheques = lblIngresosCheque.Text;
            cierre.DiferenciaCheques = txtMontoCheque.Text;

            cierre.CantidadActualTransferencia = lblTranferencia.Text;
            cierre.CantidadIngresoTransferencia = lblTranferencia.Text;
            cierre.DiferenciaTransferencia = txtTransferencia.Text;

            cierre.CantidadActualOtros = lblIngresosOtros.Text;
            cierre.CantidadIngresoOtros = lblIngresosOtros.Text;
            cierre.DiferenciaOtros = txtOtro.Text;


            db.CierreCajas.Add(cierre);
            db.SaveChanges();


            this.Close();
        }

        private void btnActualizaRegistros_MouseEnter(object sender, EventArgs e)
        {

            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnActualizaRegistros_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void lblVerDetalleEfectivo_Click(object sender, EventArgs e)
        {
            Label btr = sender as Label;






            var id = int.Parse(btr.Name);
            frmVerDetalles detalles = new frmVerDetalles(id);
            detalles.Location = new Point(560, 550);
            detalles.ShowDialog();
        }
    }
}
