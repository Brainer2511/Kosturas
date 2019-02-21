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
    public partial class frmPin : Form
    {

        DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public frmPin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var consulta = from p in db.Empleados
                           where p.Clave == txtPin.Text
                         
                          select p;
            Program.Pin = consulta.FirstOrDefault().Nombre;
            if (consulta.Any())

            {
               
                this.Close();
                if (Program.abrirform == 1) { 
                frmEmpleado empleado = new frmEmpleado();
                
                empleado.ShowDialog();
                }
                else if (Program.abrirform == 2)
                {
                    this.Close();
                    frmPrincipal frm = new frmPrincipal();
                    frm.Opacity = 1;
                    frm.Show();

                    frmMantenimientos mantenimientos = new frmMantenimientos();
                 
                    mantenimientos.Location = new Point(0, 150);
                    mantenimientos.ShowDialog();
                }
                else if (Program.abrirform == 3)
                {
                    this.Close();
              
         

                }
            }
            else
            {

                MessageBox.Show("Pin incorrecto");
                txtPin.Clear();
               
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void btnCancelar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;

        }

        private void btnCancelar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
