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
    
    public partial class frmAfiliados : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmAfiliados()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Afiliado afiliado = new Afiliado();

            afiliado.Nombre = txtNombreAfiliado.Text;
            afiliado.Telefono = txtTelefono.Text;
            afiliado.CodigoPostal = txtCodigoPostal.Text;
            afiliado.Ciudad = txtCiudad.Text;
            afiliado.Calle = txtCalle.Text;
            afiliado.Porsentaje = txtPorsentaje.Text;
            afiliado.Activo = ckbActivo.Checked;
            afiliado.NumeroOrden = txtNumeroOrden.Text;
            afiliado.Correo = txtCorreo.Text;



            db.Afiliados.Add(afiliado);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dgvAfiliado.DataSource = db.Afiliados.ToList();
        }

        private void Afiliados_Load(object sender, EventArgs e)
        {
            dgvAfiliado.DataSource = db.Afiliados.ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
