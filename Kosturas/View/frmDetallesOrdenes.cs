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
    public partial class frmDetallesOrdenes : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmDetallesOrdenes()
        {
            InitializeComponent();
        }

        private void frmDetallesOrdenes_Load(object sender, EventArgs e)
        {

            this.btnActualizarPrenda.Visible = false;

            this.btnActualizarDetalleTarea.Visible = false;

            this.btnActualizarTarea.Visible = false;

            dvgRopa.DataSource = db.Prendas.Select(x => new { x.PrendaId, x.TipoRopa, x.piezas, x.NumeroPrenda}).ToList();
            dvgDetalle.DataSource = db.DetalleTareas.Select(x => new { x.DetalleTareaId, x.TareaId, x.DetalleTareas, x.NumeroDetalleTarea, x.Precio, x.TiempoRespuesta }).ToList();

          
            dgvTarea.DataSource = db.Tareas.Select(x => new { x.TareaId,x.PrendaId,x.ServiciosId, x.NombreTareas, x.Servicio.NombreServicio,x.NumeroTarea }).ToList();





            cmbTipoServicio.DataSource = db.Servicios.ToList();
            cmbTipoServicio.DisplayMember = "NombreServicio";
            cmbTipoServicio.ValueMember = "ServiciosId";

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
             Prenda prenda = new Prenda();

            prenda.Imagen = txtRuta.Text;
            prenda.TipoRopa = txtTipoRopa.Text;
            prenda.NumeroPrenda = txtNumeroPrenda.Text;
            prenda.piezas = txtPiezas.Text;
 
          

            db.Prendas.Add(prenda);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dvgRopa.DataSource = db.Prendas.Select(x => new { x.PrendaId, x.TipoRopa, x.piezas, x.NumeroPrenda }).ToList();

            dvgRopa.ClearSelection();
            dvgRopa.Rows[dvgRopa.Rows.Count - 1].Selected = true;
            var prendaid = int.Parse(dvgRopa.SelectedRows[0].Cells[0].Value.ToString());
            dgvTarea.DataSource = db.Tareas.Where(x => x.PrendaId==prendaid).ToList();


        }

        private void btnGuardarTarea_Click(object sender, EventArgs e)
        {
            Tarea tarea = new Tarea();
            var prendaid = int.Parse(dvgRopa.SelectedRows[0].Cells[0].Value.ToString());


            tarea.Imagen = txtRutaTareas.Text;
            tarea.NombreTareas = txtNombreTarea.Text;
            tarea.NumeroTarea = txtNumeroTarea.Text;
            tarea.PrendaId = prendaid;
            tarea.ServiciosId = int.Parse(cmbTipoServicio.SelectedValue.ToString());


            db.Tareas.Add(tarea);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");
            dgvTarea.DataSource = db.Tareas.Where(x => x.PrendaId == prendaid).Select(x=>new {x.TareaId,x.PrendaId,x.ServiciosId,x.NombreTareas,x.Servicio.NombreServicio,x.NumeroTarea }).ToList();
            dgvTarea.ClearSelection();
            dgvTarea.Rows[dgvTarea.Rows.Count - 1].Selected = true;

            var tareaid = int.Parse(dgvTarea.SelectedRows[0].Cells[0].Value.ToString());
            dvgDetalle.DataSource = db.DetalleTareas.Where(x => x.TareaId == tareaid).ToList();

        }

        private void btnGuardarDetalleTarea_Click(object sender, EventArgs e)
        {
            DetalleTarea detalleTarea = new DetalleTarea();
            var tareaid = int.Parse(dgvTarea.SelectedRows[0].Cells[0].Value.ToString());
            detalleTarea.Imagen = txtRutaDetallesTareas.Text;
            detalleTarea.DetalleTareas = txtDetalleTarea.Text;
            detalleTarea.NumeroDetalleTarea = txtNumeroDetalle.Text;
            detalleTarea.Precio = txtPrecio.Text;
            detalleTarea.TiempoRespuesta = txtTiempoRespuesta.Text;
            detalleTarea.TareaId = tareaid;


            db.DetalleTareas.Add(detalleTarea);
            db.SaveChanges();

            MessageBox.Show("Dato Insertado");

            dvgDetalle.DataSource = db.DetalleTareas.Where(x => x.TareaId == tareaid).Select(x => new { x.DetalleTareaId, x.TareaId, x.DetalleTareas, x.NumeroDetalleTarea, x.Precio, x.TiempoRespuesta }).ToList();

         
        }

        private void dvgRopa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

          }

        private void dgvTarea_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dvgDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnActualizarPrenda_Click(object sender, EventArgs e)
        {
            Prenda prenda = db.Prendas.Find(int.Parse(dvgRopa.SelectedRows[0].Cells[0].Value.ToString()));

            prenda.TipoRopa = txtTipoRopa.Text;
            prenda.NumeroPrenda = txtNumeroPrenda.Text;
            prenda.piezas = txtPiezas.Text;


            db.Entry(prenda).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Dato Actualizado");

            dvgRopa.DataSource = db.Prendas.ToList();
        }

        private void btnActualizarTarea_Click(object sender, EventArgs e)
        {
            Tarea tarea = db.Tareas.Find(int.Parse(dgvTarea.SelectedRows[0].Cells[0].Value.ToString()));

           var prendaid = int.Parse(dgvTarea.SelectedRows[0].Cells[2].Value.ToString());



            tarea.NombreTareas = txtNombreTarea.Text;
            tarea.NumeroTarea = txtNumeroTarea.Text;
            tarea.PrendaId = prendaid;
            tarea.ServiciosId = int.Parse(cmbTipoServicio.SelectedValue.ToString());

           

            db.Entry(tarea).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Dato Actualizado");

            dgvTarea.DataSource = db.Tareas.Select(x => new {x.TareaId,x.PrendaId, x.ServiciosId, x.NombreTareas, x.Servicio.NombreServicio,x.NumeroTarea }).ToList();

        }

        private void btnActualizarDetalleTarea_Click(object sender, EventArgs e)
        {
            DetalleTarea detalleTarea = db.DetalleTareas.Find(int.Parse(dvgDetalle.SelectedRows[0].Cells[0].Value.ToString()));

       


            detalleTarea.DetalleTareas = txtDetalleTarea.Text;
            detalleTarea.NumeroDetalleTarea = txtNumeroDetalle.Text;
            detalleTarea.Precio = txtPrecio.Text;
            detalleTarea.TiempoRespuesta = txtTiempoRespuesta.Text;



            db.Entry(detalleTarea).State = EntityState.Modified;
            db.SaveChanges();

            MessageBox.Show("Dato Actualizado");

            dvgDetalle.DataSource = db.DetalleTareas.ToList();
        }

        private void dvgRopa_SelectionChanged(object sender, EventArgs e)
        {
    

           

            

        }

        private void dvgRopa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
              int a = e.RowIndex;
            if (a != -1)
            {
                var prendaid = int.Parse(dvgRopa.SelectedRows[0].Cells[0].Value.ToString());
                Prenda prenda = db.Prendas.Find(prendaid);


                this.btnActualizarPrenda.Visible = true;
                this.btnGuardar.Visible = false;

                txtTipoRopa.Text = prenda.TipoRopa;
                txtNumeroPrenda.Text = prenda.NumeroPrenda;
                txtPiezas.Text = prenda.piezas;
                dgvTarea.DataSource = db.Tareas.Where(x => x.PrendaId == prendaid).Select(x => new {x.TareaId,x.PrendaId, x.ServiciosId, x.NombreTareas, x.Servicio.NombreServicio,x.NumeroTarea}).ToList();
                if (dgvTarea.SelectedRows.Count > 0)
                {


                    var tareaid = int.Parse(dgvTarea.SelectedRows[0].Cells[0].Value.ToString());
                    dvgDetalle.DataSource = db.DetalleTareas.Where(x => x.TareaId == tareaid).Select(x => new { x.DetalleTareaId,x.TareaId, x.DetalleTareas, x.NumeroDetalleTarea, x.Precio, x.TiempoRespuesta }).ToList();

                }
            }
        }

        private void dgvTarea_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (a != -1)
            {
                var tareaid = int.Parse(dgvTarea.SelectedRows[0].Cells[0].Value.ToString());
                Tarea tarea = db.Tareas.Find(tareaid);


                this.btnActualizarTarea.Visible = true;
                this.btnGuardarTarea.Visible = false;

                txtNombreTarea.Text = tarea.NombreTareas;
                txtNumeroTarea.Text = tarea.NumeroTarea;
                cmbTipoServicio.SelectedValue = tarea.ServiciosId;
                dvgDetalle.DataSource = db.DetalleTareas.Where(x => x.TareaId == tareaid).Select(x => new {x.DetalleTareaId, x.TareaId, x.DetalleTareas, x.NumeroDetalleTarea, x.Precio, x.TiempoRespuesta }).ToList();

            }
        }

        private void dvgDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int a = e.RowIndex;

            if (a != -1)
            {
                var detalleid = int.Parse(dvgDetalle.SelectedRows[0].Cells[0].Value.ToString());

                DetalleTarea detalle = db.DetalleTareas.Find(detalleid);

                this.btnActualizarDetalleTarea.Visible = true;
                this.btnGuardarDetalleTarea.Visible = false;

                txtDetalleTarea.Text = detalle.DetalleTareas;
                txtNumeroDetalle.Text = detalle.NumeroDetalleTarea;
                txtPrecio.Text = detalle.Precio;
                txtTiempoRespuesta.Text = detalle.TiempoRespuesta;
                
                dvgDetalle.DataSource = db.DetalleTareas.Select(x => new {x.DetalleTareaId, x.TareaId, x.DetalleTareas, x.NumeroDetalleTarea, x.Precio, x.TiempoRespuesta }).ToList();

            }
        }

        private void btnBorrarPrenda_Click(object sender, EventArgs e)
        {

            try
            {
                Prenda prenda = db.Prendas.Find(int.Parse(dvgRopa.SelectedRows[0].Cells[0].Value.ToString()));
                db.Prendas.Remove(prenda);
                db.SaveChanges();
                MessageBox.Show("Prenda Borrada");
                dvgRopa.DataSource = db.Prendas.Select(x => new { x.PrendaId, x.TipoRopa, x.piezas, x.NumeroPrenda }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("No Puede Borrar esta Prenda porque tiene datos Asociados");
                }
            
        }

        private void btnBorrarTarea_Click(object sender, EventArgs e)
        {

            try
            {
                Tarea tarea = db.Tareas.Find(int.Parse(dgvTarea.SelectedRows[0].Cells[0].Value.ToString()));
                db.Tareas.Remove(tarea);
                db.SaveChanges();
                MessageBox.Show("Tarea Borrada");
                dgvTarea.DataSource = db.Tareas.Select(x => new { x.TareaId, x.PrendaId, x.ServiciosId, x.NombreTareas, x.Servicio.NombreServicio, x.NumeroTarea }).ToList();
            }
            catch (Exception)
            {
                MessageBox.Show("No Puede Borrar esta Tarea porque tiene Datos Asociados");
            }
           

        }

        private void btnBorrarDetalle_Click(object sender, EventArgs e)
        {
            DetalleTarea detalleTarea = db.DetalleTareas.Find(int.Parse(dvgDetalle.SelectedRows[0].Cells[0].Value.ToString()));
            db.DetalleTareas.Remove(detalleTarea);
            db.SaveChanges();
            MessageBox.Show("Detalle Tarea Borrado");
            dvgDetalle.DataSource = db.DetalleTareas.Select(x => new { x.DetalleTareaId, x.TareaId, x.DetalleTareas, x.NumeroDetalleTarea, x.Precio, x.TiempoRespuesta }).ToList();

        }

        private void btnImagenTipoRopa_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
      

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRuta.Text = openFileDialog1.FileName;
            }
           
        }

        private void btnImagenTarea_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaTareas.Text = openFileDialog1.FileName;
            }
        }

        private void btnImagenDetalleTarea_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtRutaDetallesTareas.Text = openFileDialog1.FileName;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
