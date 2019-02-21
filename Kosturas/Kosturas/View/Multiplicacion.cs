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
        Color ColorEntrada;
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

        private void btnAceptar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnAceptar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
