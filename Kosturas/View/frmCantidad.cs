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
    public partial class frmCantidad : Form
    {
        public frmCantidad()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
            this.Close();
            mensaje1.Opacity = 1;
            mensaje1.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
            this.Close();
            mensaje1.Opacity = 1;
            mensaje1.Show();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
          
         //   mensaje1.label5.Text = this.txtCantidad.Text;
            this.Close();
            mensaje1.Opacity = 1;
            mensaje1.Show();
           
        }
    }
}
