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
    public partial class frmOfertas : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmOfertas()
        {
            InitializeComponent();
        }

        private void frmOfertas_Load(object sender, EventArgs e)
        {
            dvgOfertas.DataSource = db.Ofertas.ToList();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Ofertas oferta = new Ofertas();

            oferta.NumeroOferta = txtNumeroOferta.Text;
            oferta.Descripcion = txtDescripcion.Text;
            oferta.DescuentoPorsentaje = txtDescuento.Text;
            oferta.ImporteDescuento = txtImporte.Text;
            oferta.Habilitar = ckbHabilitar.Checked;


            db.Ofertas.Add(oferta);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dvgOfertas.DataSource = db.Ofertas.ToList();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
