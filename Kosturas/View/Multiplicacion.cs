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
    public partial class Multiplicacion : Form
    {
        public Multiplicacion()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
        
            var a = mensaje1.txtPrecioTotal.Text;
            var b = this.txtCantidadDos.Text;
            var c = int.Parse(a) * int.Parse(b);
            mensaje1.txtPrecioTotal.Text =c.ToString();
            this.Close();

        }
    }
}
