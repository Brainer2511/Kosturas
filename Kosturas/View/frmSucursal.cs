
using Domain;
using Kosturas.Model;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class frmSucursal : Form
    {
        Color ColorEntrada;
        public DataContextLocal db = new DataContextLocal();
        
        public frmSucursal()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Sucursal sucursal = new Sucursal();

            sucursal.Nombre = txtNombre.Text;
            sucursal.Activa = ckbActivo.Checked;

            db.Sucursales.Add(sucursal);
            db.SaveChanges();

            listSucursales.DataSource = db.Sucursales.ToList();
        }

        private void frmSucursal_Load(object sender, EventArgs e)
        {
            listSucursales.DataSource = db.Sucursales.ToList();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Sucursal sucursal = db.Sucursales.Find(int.Parse(txtSucursalId.Text));

            sucursal.Nombre = txtNombre.Text;
            sucursal.Activa = ckbActivo.Checked;

            db.Entry(sucursal).State=EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Dato Actualizado");

            listSucursales.DataSource = db.Sucursales.ToList();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Sucursal sucursal = db.Sucursales.Find(int.Parse(txtSucursalId.Text));
            db.Sucursales.Remove(sucursal);
            db.SaveChanges();
            listSucursales.DataSource = db.Sucursales.ToList();
        }

        private void listSucursales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSucursalId.Text = listSucursales.SelectedRows[0].Cells[0].Value.ToString();
            txtNombre.Text = listSucursales.SelectedRows[0].Cells[1].Value.ToString();
            var check= listSucursales.SelectedRows[0].Cells[2].Value.ToString();
            if (check=="True")
            {
                ckbActivo.Checked=true;
            }
            else
            {
                ckbActivo.Checked = false;
            }
        }

        private void btnGuardar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;






            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;



            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
