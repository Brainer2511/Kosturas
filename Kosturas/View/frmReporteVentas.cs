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
    public partial class frmReporteVentas : Form
    {
        Color ColorEntrada;
        public frmReporteVentas()
        {
            InitializeComponent();
        }

        private void frmReporteVentas_Load(object sender, EventArgs e)
        {
            var a = DateTime.Today;// dtDesde.Value.ToShortDateString();

            var b = DateTime.Today;// dtpHasta.Value.ToShortDateString();


            this.txtDesde.Text = a.ToShortDateString();
            this.txtHasta.Text = b.ToShortDateString();
        }

        private void btnVerOrdenes_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnVerOrdenes_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {

            var a = dtDesde.Value.ToShortDateString();



            this.txtDesde.Text = a;

        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {

            var b = dtpHasta.Value.ToShortDateString();


            this.txtHasta.Text = b;
        }
    }
}
