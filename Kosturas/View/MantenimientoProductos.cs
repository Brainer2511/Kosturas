using BarcodeLib;
using Domain;
using Kosturas.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kosturas.View
{
    public partial class MantenimientoProductos : Form
    {
        Color ColorEntrada;
        public DataContextLocal db = new DataContextLocal();
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
                {
                    Productos productos = new Productos();

                    productos.CodigoId = int.Parse(txtCodigo.Text);
                    productos.Nombre = txtNombre.Text;
                    productos.Categoria = txtCategoria.Text;
                    productos.Provedor = txtProveedor.Text;
                    productos.PrecioCompra = double.Parse(txtPrecioCompra.Text);
                    productos.PrecioVenta = double.Parse(txtPrecioVenta.Text);
                    productos.Cantidad = double.Parse(txtCantidadInventario.Text);
                    var Codigo = CodigoBarras(int.Parse(txtCodigo.Text));
                    productos.Imagen = Codigo;

                    db.Productos.Add(productos);
                    db.SaveChanges();

                    dvgProductos.DataSource = db.Productos.ToList();
                }
            }
            catch (Exception)
            {
                
            }

           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
                {
                    Productos productos = db.Productos.Find(int.Parse(txtCodigo.Text));

                    productos.CodigoId = int.Parse(txtCodigo.Text);
                    productos.Nombre = txtNombre.Text;
                    productos.Provedor = txtProveedor.Text;
                    productos.PrecioCompra = double.Parse(txtPrecioCompra.Text);
                    productos.PrecioVenta = double.Parse(txtPrecioVenta.Text);
                    productos.Categoria = txtCategoria.Text;
                    productos.Cantidad = double.Parse(txtCantidadInventario.Text);
                    var Codigo = CodigoBarras(int.Parse(txtCodigo.Text));
                    productos.Imagen = Codigo;
                    db.Entry(productos).State = EntityState.Modified;
                    db.SaveChanges();

                    MessageBox.Show("Producto Actualizado");

                    dvgProductos.DataSource = db.Productos.ToList();
                }
            }
            catch (Exception)
            {

              
            }

          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCodigo.Text.Trim()))
                {

                    Productos productos = db.Productos.Find(int.Parse(txtNombre.Text));
                    db.Productos.Remove(productos);
                    db.SaveChanges();
                    dvgProductos.DataSource = db.Productos.ToList();
                }
            }
            catch (Exception)
            {

            }

          
        }

        public string CodigoBarras(int idCodigoProducto)
        {
            try
            {
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                barcode.IncludeLabel = true;
                barcode.Encode(BarcodeLib.TYPE.CODE128, idCodigoProducto.ToString(), Color.Black, Color.White, 300, 50);

                string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\CodigosBarrasProductos\"; // <---
                if (Directory.Exists(appPath) == false)                                              // <---
                {                                                                                    // <---
                    Directory.CreateDirectory(appPath);                                              // <---
                }                                                                                    // <---

                appPath += idCodigoProducto.ToString() + ".png";
                barcode.SaveImage(appPath, SaveTypes.PNG);

                return appPath;
            }
            catch (Exception)
            {

                return string.Empty;
            }
       

        }

        private void dvgProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtNombre.Text = dvgProductos.SelectedRows[0].Cells[0].Value.ToString();
                txtCodigo.Text = dvgProductos.SelectedRows[0].Cells[1].Value.ToString();
                txtCategoria.Text = dvgProductos.SelectedRows[0].Cells[2].Value.ToString();
                txtProveedor.Text = dvgProductos.SelectedRows[0].Cells[3].Value.ToString();
                txtPrecioCompra.Text = dvgProductos.SelectedRows[0].Cells[4].Value.ToString();
                txtPrecioVenta.Text = dvgProductos.SelectedRows[0].Cells[5].Value.ToString();
                txtCantidadInventario.Text = dvgProductos.SelectedRows[0].Cells[6].Value.ToString();
            }
            catch (Exception)
            {

              
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

        private void txtCodigo_Validated(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigo.Text.Trim()))
            {
                MessageBox.Show("El Codigo Producto Es un Dato Obligatorio");
                txtCodigo.Text = "";
                txtCodigo.Focus();

            }
        }
    }
}
