using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
            this.btnActualizar.Visible = false;
            dgvAfiliado.DataSource = db.Afiliados.ToList();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Afiliado afiliado = db.Afiliados.Find(int.Parse(dgvAfiliado.SelectedRows[0].Cells[0].Value.ToString()));
        
            afiliado.Nombre = txtNombreAfiliado.Text;
            afiliado.Telefono = txtTelefono.Text;
            afiliado.CodigoPostal = txtCodigoPostal.Text;
            afiliado.Ciudad = txtCiudad.Text;
            afiliado.Calle = txtCalle.Text;
            afiliado.Porsentaje = txtPorsentaje.Text;
            afiliado.Activo = ckbActivo.Checked;
            afiliado.NumeroOrden = txtNumeroOrden.Text;
            afiliado.Correo = txtCorreo.Text;

            db.Entry(afiliado).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Afiliado Actualizado");

            dgvAfiliado.DataSource = db.Afiliados.ToList();
        }

        private void dgvAfiliado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (a != -1)
            {

                this.btnActualizar.Visible = true;
                this.btnGuardar.Visible = false;


                txtNombreAfiliado.Text = dgvAfiliado.SelectedRows[0].Cells[1].Value.ToString();
                txtTelefono.Text = dgvAfiliado.SelectedRows[0].Cells[2].Value.ToString();
                txtCodigoPostal.Text = dgvAfiliado.SelectedRows[0].Cells[3].Value.ToString();
                txtCiudad.Text = dgvAfiliado.SelectedRows[0].Cells[4].Value.ToString();
                txtCalle.Text = dgvAfiliado.SelectedRows[0].Cells[5].Value.ToString();
                txtPorsentaje.Text = dgvAfiliado.SelectedRows[0].Cells[6].Value.ToString();
                txtNumeroOrden.Text = dgvAfiliado.SelectedRows[0].Cells[8].Value.ToString();
                txtCorreo.Text = dgvAfiliado.SelectedRows[0].Cells[9].Value.ToString();

                var check = dgvAfiliado.SelectedRows[0].Cells[7].Value.ToString();
                if (check == "True")
                {
                    ckbActivo.Checked = true;
                }
                else
                {
                    ckbActivo.Checked = false;
                }



            }
        }
    }
}
