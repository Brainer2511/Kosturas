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
    public partial class EditarOrdenes : Form
    {

        Color ColorEntrada;
        public DataContextLocal db = new DataContextLocal();
        public EditarOrdenes()
        {
            InitializeComponent();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Pagos pago = db.Pagos.Find(int.Parse(txtIdOrden.Text));

                pago.Monto = double.Parse(txtMonto.Text);
                pago.MedioPagoId = int.Parse(cmbMedioPago.SelectedValue.ToString());
                pago.EmpleadoRealizo = CmbEmpleado.SelectedValue.ToString();
                db.Entry(pago).State = EntityState.Modified;
                db.SaveChanges();

                MessageBox.Show("Pago Actualizado");

                listPagos.DataSource = db.Pagos.Where(q => q.Fecha == DateTime.Today).Select(q => new { q.PagoId, q.Fecha, q.Monto, q.MediosPago.FormaPago, q.EmpleadoRealizo }).ToList();

            }
            catch (Exception)
            {

               
            }

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                Pagos pago = db.Pagos.Find(int.Parse(txtIdOrden.Text));
                db.Pagos.Remove(pago);
                db.SaveChanges();
                MessageBox.Show("Pago Borrado");
                listPagos.DataSource = db.Pagos.Where(q => q.Fecha == DateTime.Today).Select(q => new { q.PagoId, q.Fecha, q.Monto, q.MediosPago.FormaPago, q.EmpleadoRealizo }).ToList();

            }
            catch (Exception)
            {

                
            }

           
        }

        private void EditarOrdenes_Load(object sender, EventArgs e)
        {

            try
            {
                btnBorrar.Visible = false;
                btnModificar.Visible = false;
                cmbMedioPago.DataSource = db.MediosPago.ToList();
                cmbMedioPago.DisplayMember = "FormaPago";
                cmbMedioPago.ValueMember = "MedioPagoId";

                CmbEmpleado.DataSource = db.Empleados.ToList();
                CmbEmpleado.DisplayMember = "Nombre";
                CmbEmpleado.ValueMember = "Nombre";

                listPagos.DataSource = db.Pagos.Where(q => q.Fecha == DateTime.Today).Select(q => new { q.PagoId, q.Fecha, q.Monto, q.MediosPago.FormaPago, q.EmpleadoRealizo }).ToList();

            }
            catch (Exception)
            {
                
            }

               }

        private void btnModificar_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void btnModificar_MouseLeave(object sender, EventArgs e)
        {

            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }

        private void listPagos_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void listPagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int a = e.RowIndex;

                if (a != -1)
                {
                    btnBorrar.Visible = true;
                    btnModificar.Visible = true;


                    txtIdOrden.Text = listPagos.SelectedRows[0].Cells[0].Value.ToString();
                    txtMonto.Text = listPagos.SelectedRows[0].Cells[2].Value.ToString();
                    cmbMedioPago.Text = listPagos.SelectedRows[0].Cells[3].Value.ToString();
                    CmbEmpleado.Text = listPagos.SelectedRows[0].Cells[4].Value.ToString();
                }
            }
            catch (Exception)
            {
                
            }
        
        }
    }
}
