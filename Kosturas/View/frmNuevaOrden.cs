using Domain;
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
    public partial class frmNuevaOrden : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmNuevaOrden()
        {
            InitializeComponent();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void btnprueba_Click(object sender, EventArgs e)
        {
            this.txtPrecioTotal.Text ="Total:"+ "4000";
          
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();




            db.Clientes.Add(cliente);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
        }

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Prueba");

        }

        private void ckbasisnar_CheckedChanged(object sender, EventArgs e)
        {
            this.btnEnviar.Visible = true;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            ComboBox btr = sender as ComboBox;


            object id = btr.Name;
            id = btr.BackColor = Color.OliveDrab;
            id = btr.ForeColor = Color.White;
        //    this.comboBox1.BackColor = System.Drawing.Color.OliveDrab;
        //    this.comboBox1.ForeColor = System.Drawing.Color.White;
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
