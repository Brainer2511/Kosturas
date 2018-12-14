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
    public partial class CorreosSMSFacturas : Form
    {
        public CorreosSMSFacturas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            this.btnGuardar.BackColor = System.Drawing.Color.OliveDrab;
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {

            this.btnGuardar.BackColor = System.Drawing.SystemColors.Control;
            this.btnGuardar.ForeColor = System.Drawing.Color.Black;
        }
    }
}
