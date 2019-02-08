using Kosturas.Model;
using Kosturas.ViewModels;
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
    public partial class frmOrdenesPorCliente : Form
    {

        DataContextLocal db = new DataContextLocal();
        public List<OrdenViewModel> listaOrdenes = new List<OrdenViewModel>();
        int rowCount = 0;
        Color ColorEntrada;
        public int ClienteId { get; set; }
        public DateTime Fechadesde { get; set; }
        public DateTime Fechahasta { get; set; }
        public frmOrdenesPorCliente(int clienteId, DateTime fechadesde, DateTime fechahasta)
        {
            ClienteId = clienteId;
            Fechadesde = fechadesde;
            Fechahasta = fechahasta;
            InitializeComponent();
        }

        private void frmOrdenesPorCliente_Load(object sender, EventArgs e)
        {
            cargarOrdenesCliente();
            //var a = DateTime.Today.ToShortDateString();
            //var desde = a + " 00:00";
            //var hasta = a + " 23:59";
            //var fdesde = DateTime.Parse(desde);
            //var fhasta = DateTime.Parse(hasta);

            //var query= (from q in db.Ordenes
            //where q.FeEnt >= fdesde && q.FeEnt <= fhasta && q.ClienteId == ClienteId
            //select new
            //{ OrdenId = q.OrdenId, Fecha = q.FeEnt, Total = q.TotalOrden,
            //    CantidadPagada = q.CantidadPagada,
            //    Prendas = q.Prendas}
            //    )
            //    .Select(u=>new {
            //        OrdenId = u.OrdenId,
            //        Fecha = u.Fecha,
            //        Total = u.Total,
            //        CantidadPagada = u.CantidadPagada,
            //        Subtotal = u.Prendas.SelectMany(r => r.DetalleTareas).Sum(w => w.Subtotal)
            //    }).ToList(); 

            //var query= db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta && q.ClienteId == ClienteId).Select(t => new { OrdenId= t.OrdenId, Fecha = t.FeEnt,Total= t.TotalOrden,CantidadPagada= t.CantidadPagada,Subtotal=t.Prendas.SelectMany(q=>q.DetalleTareas).Sum(q=>q.Subtotal)}).ToList();
            //query;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        void cargarOrdenesCliente()
        {

            var a = Fechadesde.ToShortDateString();
            var b = Fechahasta.ToShortDateString();
            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            var query = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta && q.ClienteId == ClienteId).ToList();



            var Colores = true;
            foreach (var itemdos in query)

            {

                var OrdenView = new OrdenViewModel();
             
                OrdenView.Panel.Size = new Size(920, 30);
                OrdenView.Panel.MouseEnter += new EventHandler(Mouseover);
                OrdenView.Panel.MouseLeave += new EventHandler(Mouseleave);
                if (Colores == true)
                {
                    OrdenView.Panel.BackColor = Color.White;
                    Colores = false;
                }
                else
                {
                    OrdenView.Panel.BackColor = Color.WhiteSmoke;
                    Colores = true;
                }

                OrdenView.Panel.Name = itemdos.OrdenId.ToString();

                OrdenView.lblId.Text = itemdos.OrdenId.ToString();
               
                OrdenView.lblId.Location = new Point(0, 0);
                OrdenView.lblId.Size = new Size(100, 20);


                OrdenView.lblNombre.Text = itemdos.FechaEnt.ToString();
               
                OrdenView.lblNombre.Size = new Size(120, 20);
                OrdenView.lblNombre.Location = new Point(110, 0);


                OrdenView.lblFechaEntrada.Text = itemdos.TotalOrden.ToString();
                
                OrdenView.lblFechaEntrada.Size = new Size(105, 20);
                OrdenView.lblFechaEntrada.Location = new Point(255, 0);


                OrdenView.lblLocalizacion.Text = itemdos.Prendas.SelectMany(q=>q.DetalleTareas).Sum(q=>q.Subtotal).ToString();
              
                OrdenView.lblLocalizacion.Location = new Point(405, 0);
                OrdenView.lblLocalizacion.Size = new Size(100, 20);


                OrdenView.lblHoraEntrada.Text = itemdos.CantidadPagada.ToString();
               
                OrdenView.lblHoraEntrada.Location = new Point(515, 0);
                OrdenView.lblHoraEntrada.Size = new Size(100, 20);

                OrdenView.lblTotal.Text = itemdos.CantidadRestante.ToString();
               
                OrdenView.lblTotal.Location = new Point(625, 0);
                OrdenView.lblTotal.Size = new Size(70, 20);

                OrdenView.lblMontoPagado.Text = itemdos.FechaSalida.ToString();
                
                OrdenView.lblMontoPagado.Location = new Point(810, 0);
                OrdenView.lblMontoPagado.Size = new Size(100, 20);

          
                if (itemdos.Prendas.FirstOrDefault().DetalleTareas.FirstOrDefault().Estado == true)
                {
                    OrdenView.lblEstado.Text = "Si";

                    OrdenView.lblEstado.Location = new Point(715, 0);
                   
                    OrdenView.lblEstado.Size = new Size(90, 20);

                }
                else
                {
                    OrdenView.lblEstado.Text = "No";

                    OrdenView.lblEstado.Location = new Point(715, 0);
                   
                    OrdenView.lblEstado.Size = new Size(90, 20);

                }






                OrdenView.Panel.Controls.Add(OrdenView.lblId);
                OrdenView.Panel.Controls.Add(OrdenView.lblNombre);
                OrdenView.Panel.Controls.Add(OrdenView.lblLocalizacion);
                OrdenView.Panel.Controls.Add(OrdenView.lblFechaEntrada);

                OrdenView.Panel.Controls.Add(OrdenView.lblHoraEntrada);
                OrdenView.Panel.Controls.Add(OrdenView.lblTotal);
                OrdenView.Panel.Controls.Add(OrdenView.lblMontoPagado);
              
                OrdenView.Panel.Controls.Add(OrdenView.lblEstado);


                AutoMapper.Mapper.Map(itemdos, OrdenView);
                listaOrdenes.Add(OrdenView);
                rowCount += 1;
                tblDetalleOrdenesClientes.RowCount = rowCount;
                this.tblDetalleOrdenesClientes.Controls.Add(listaOrdenes.Last().Panel, 0, rowCount);



            }

        }

        void Mouseover(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;
            ColorEntrada = btr.BackColor;




            object id = btr.Name;

            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;


        }
        void Mouseleave(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;

        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            Button btr = sender as Button;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
            id = btr.BackColor = Color.FromArgb(238, 141, 88);
            id = btr.ForeColor = Color.White;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            Button btr = sender as Button;


            object id = btr.Name;
            id = btr.BackColor = ColorEntrada;

            id = btr.ForeColor = System.Drawing.Color.Black;
        }
    }
}
