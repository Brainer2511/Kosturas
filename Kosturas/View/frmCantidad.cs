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
        Color ColorEntrada;
        public frmCantidad()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
                this.Close();
                mensaje1.Opacity = 1;
                mensaje1.Show();
            }
            catch (Exception)
            {

               
            }
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
                this.Close();
                mensaje1.Opacity = 1;
                mensaje1.Show();
            }
            catch (Exception)
            {

            }

            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 mensaje1 = (Form1)Application.OpenForms["Form1"];
                mensaje1.lblCantidad.Text = this.txtCantidad.Text;

                this.Close();
                mensaje1.Opacity = 1;
                mensaje1.Show();
            }
            catch (Exception)
            {
                
            }

          
           
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
