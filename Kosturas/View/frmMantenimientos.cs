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
    public partial class frmMantenimientos : Form
    {
        public frmMantenimientos()
        {
            InitializeComponent();
        }

        private void opcionesDeOrdenesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void detallesOrdesnesToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServicios servicios = new frmServicios();
            servicios.Location = new Point(173, 150);
            servicios.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmPrincipal frm = new frmPrincipal();
            frm.Opacity = 1;
            frm.Show();
        }

        private void ñjnkjnjnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetallesOrdenes detallesOrdenes = new frmDetallesOrdenes();
            detallesOrdenes.Location = new Point(173, 150);
            detallesOrdenes.ShowDialog();
        }

        private void njkjnkToolStripMenuItem_Click(object sender, EventArgs e)
        {
          //  frm
        }

        private void sdgtfhyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedioPagos medioPagos = new frmMedioPagos();
            medioPagos.Location = new Point(173, 150);
            medioPagos.ShowDialog();
        }

        private void hfgghjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOfertas ofertas = new frmOfertas();
            ofertas.Location = new Point(173, 150);
            ofertas.ShowDialog();
        }

        private void hgffggfhjhgfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmImpresionesAutomaticas impresionesAutomaticas = new frmImpresionesAutomaticas();
            impresionesAutomaticas.Location = new Point(173, 150);
            impresionesAutomaticas.ShowDialog();
        }

        private void treretyytToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOpcionesOrdenes opcionesOrdenes = new frmOpcionesOrdenes();
            opcionesOrdenes.Location = new Point(173, 150);
            opcionesOrdenes.ShowDialog();
        }

        private void erreyytreyretToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAfiliados afiliados = new frmAfiliados();
            afiliados.Location = new Point(173, 150);
            afiliados.ShowDialog();
        }

        private void retreretetrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CorreosSMSFacturas correosSMS = new CorreosSMSFacturas();
            correosSMS.Location = new Point(173, 150);
            correosSMS.ShowDialog();
        }

        private void tretretertreToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmSeguimientos seguimientos = new frmSeguimientos();
            seguimientos.Location = new Point(173, 150);
            seguimientos.ShowDialog();
        }
    }
}
