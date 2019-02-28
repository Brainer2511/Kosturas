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
    public partial class Login : Form
    {
        public DataContextLocal db = new DataContextLocal();
        Color ColorEntrada;
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                var consulta = from p in db.Usuarios
                               where p.Nombre == txtUsuario.Text
                               && p.Clave == txtClave.Text
                               select p;

                if (consulta.Any())

                {
                    
                    MessageBox.Show("Bienvenido");
                    frmPrincipal principal = new frmPrincipal();
                    principal.ShowDialog();
                     this.Close();
                }
                else
                {

                    MessageBox.Show("Usuario o Contraseña invalidos");
                    txtUsuario.Clear();
                    txtClave.Clear();
                }
            }
            catch (Exception)
            {

              
            }
            
          
        }

        private void Login_Load(object sender, EventArgs e)
        {
        
        }

        private void btnIngresar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
