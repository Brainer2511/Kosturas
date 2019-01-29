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
    public partial class frmRegistros : Form
    {
        Color ColorEntrada;
        public frmRegistros()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void busToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCierreCaja cierreCaja = new frmCierreCaja();
            cierreCaja.Location = new Point(145, 140);
            cierreCaja.ShowDialog();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerCierreCajas cierreCaja = new frmVerCierreCajas();
            cierreCaja.Location = new Point(145, 140);
            cierreCaja.ShowDialog();
        }

        private void busToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            //MenuStrip btr = sender as MenuStrip;






            //object id = btr.Name;
            //ColorEntrada = btr.BackColor;
            //id = btr.BackColor = Color.FromArgb(238, 141, 88);
            //id = btr.ForeColor = Color.White;
        }

        private void busToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            //MenuStrip btr = sender as MenuStrip;



            //object id = btr.Name;
            //id = btr.BackColor = ColorEntrada;

            //id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
