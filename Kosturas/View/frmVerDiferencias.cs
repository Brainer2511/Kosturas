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
    public partial class frmVerDiferencias : Form
    {
        public int CierreId { get; set; }
        private CierreCaja cierre = new CierreCaja();
        DataContextLocal db = new DataContextLocal();
        public frmVerDiferencias(int cierreId = 0)
        {
            CierreId = cierreId;
            cierre = db.CierreCajas.Find(cierreId);
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerDiferencias_Load(object sender, EventArgs e)
        {
            try
            {
                lblEfectivo.Text = cierre.CantidadActualEfectivo;
                lblIngresosEfectivo.Text = cierre.CantidadIngresoEfectivo;
                lblTotalEfectivo.Text = cierre.DiferenciaEfectivo;

                lblTarjeta.Text = cierre.CantidadActualTarjetas;
                lblIngresosTarjeta.Text = cierre.CantidadIngresoTarjetas;
                lblTotalTarjetas.Text = cierre.DiferenciaTarjetas;

                lblCheque.Text = cierre.CantidadActualCheques;
                lblIngresosCheque.Text = cierre.CantidadIngresoCheques;
                lblTotalCheque.Text = cierre.DiferenciaCheques;

                lblTransActual.Text = cierre.CantidadActualTransferencia;
                lblTranferencia.Text = cierre.CantidadIngresoTransferencia;
                lblTotalTransfer.Text = cierre.DiferenciaTransferencia;

                lblOtroActual.Text = cierre.CantidadActualOtros;
                lblIngresosOtros.Text = cierre.CantidadIngresoOtros;
                lblTotalOtros.Text = cierre.DiferenciaOtros;

                lblTotalActual.Text = (double.Parse(lblEfectivo.Text) +
       double.Parse(lblTarjeta.Text) +
       double.Parse(lblCheque.Text) +
       double.Parse(lblTransActual.Text) +
       double.Parse(lblOtroActual.Text) + ",00");

                lblTotalIngresos.Text = (double.Parse(lblIngresosEfectivo.Text) +
       double.Parse(lblIngresosTarjeta.Text) +
       double.Parse(lblIngresosCheque.Text) +
       double.Parse(lblTranferencia.Text) +
       double.Parse(lblIngresosOtros.Text) + ",00");

                lblTotalDiferencias.Text = (double.Parse(lblTotalEfectivo.Text) +
       double.Parse(lblTotalTarjetas.Text) +
       double.Parse(lblTotalCheque.Text) +
       double.Parse(lblTotalTransfer.Text) +
       double.Parse(lblTotalOtros.Text) + ",00");
            }
            catch (Exception)
            {
                
            }
            


        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
