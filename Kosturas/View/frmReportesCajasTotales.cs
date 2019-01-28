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
    public partial class frmReportesCajasTotales : Form
    {
        public frmReportesCajasTotales()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRegistros  registros = new frmRegistros();
            registros.Location = new Point(0, 140);
            registros.ShowDialog();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmReportesOrdenes registros = new frmReportesOrdenes();
            registros.Location = new Point(0, 135);
            registros.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            frmIngresos registros = new frmIngresos();
            registros.Location = new Point(50, 145);
            registros.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmReporteSMS registros = new frmReporteSMS();
            registros.Location = new Point(50, 145);
            registros.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
