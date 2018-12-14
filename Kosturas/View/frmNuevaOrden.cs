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

            cliente.Nombre = txtNombre.Text;
            cliente.TelefonoPrincipal = txttelefonoprincipal.Text;
            cliente.TelefonoDos = txttelefonodos.Text;
            cliente.Telefonotres = txttelefonotres.Text;
            cliente.Abreviatura = cmbabreviatura.SelectedIndex.ToString();
            cliente.Calle = txtCalle.Text;
            cliente.Ciudad = txtCiudad.Text;
            cliente.Codigopostal = txtCodigoPostal.Text;
            cliente.Email = txtEmail.Text;
            cliente.Notas = txtNotas.Text;
            cliente.TotalOrden = txtPrecioTotal.Text;



            db.Clientes.Add(cliente);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
        }

        private void frmNuevaOrden_Load(object sender, EventArgs e)
        {
            cmbabreviatura.Items.Add("Titulo");
            cmbabreviatura.Items.Add("Sr");
            cmbabreviatura.Items.Add("Sra");
            cmbabreviatura.Items.Add("Srita");
            this.btnEnviar.Visible = true;

        }

        private void ckbasisnar_CheckedChanged(object sender, EventArgs e)
        {
            this.btnEnviar.Visible = true;
        }
    }
}
