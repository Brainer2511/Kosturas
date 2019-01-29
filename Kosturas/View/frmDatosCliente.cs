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
    public partial class frmDatosCliente : Form
    {
        DataContextLocal db = new DataContextLocal();
        int rowCount = 0;
        Color ColorEntrada;
        public List<OrdenViewModel> listaClientes = new List<OrdenViewModel>();
        public frmDatosCliente()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDatosCliente_Load(object sender, EventArgs e)
        {
            var a = DateTime.Today.ToShortDateString();// dtDesde.Value.ToShortDateString();

            var b = DateTime.Today.ToShortDateString();// dtpHasta.Value.ToShortDateString();


            this.txtDesde.Text = a;
            this.txtHasta.Text = b;
        }

        private void dtDesde_ValueChanged(object sender, EventArgs e)
        {
            var a = dtDesde.Value.ToShortDateString();



            this.txtDesde.Text = a;
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            var b = dtpHasta.Value.ToShortDateString();


            this.txtHasta.Text = b;
        }

        private void btnVerOrdenes_Click(object sender, EventArgs e)
        {
            var a = this.txtDesde.Text;


            var b = this.txtHasta.Text;

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtDesde.Text = a;
            this.txtHasta.Text = b;

            CargarReporteClientes(a, b);
        }
        void CargarReporteClientes(string a, string b)
        {
            BorrarPanelReporteClientes();


            listaClientes = new List<OrdenViewModel>();







            rowCount = 0;
            var Colores = true;

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);



            var query = db.Ordenes.Where(q => q.FeEnt >= fdesde && q.FeEnt <= fhasta)

               .ToList();




            foreach (var itemdos in query.ToList())

            {

                var panelViewSMS = new OrdenViewModel();




                panelViewSMS.Panel.Name = itemdos.OrdenId.ToString();
                panelViewSMS.Panel.BackColor = Color.Yellow;
                panelViewSMS.Panel.MouseEnter += new EventHandler(Mouseover);
                panelViewSMS.Panel.MouseLeave += new EventHandler(Mouseleave);
                panelViewSMS.Panel.Size = new Size(1265, 30);
                if (Colores == true)
                {
                    panelViewSMS.Panel.BackColor = Color.White;
                    Colores = false;
                }
                else
                {
                    panelViewSMS.Panel.BackColor = Color.WhiteSmoke;
                    Colores = true;
                }

                panelViewSMS.lblId.Text = itemdos.Cliente.Nombre.ToString();


                panelViewSMS.lblNombre.Text = itemdos.Cliente.TelefonoPrincipal.ToString();

                panelViewSMS.lblNombre.Location = new Point(140, 8);
                panelViewSMS.lblNombre.Size = new Size(100, 25);



                panelViewSMS.lblHoraEntrada.Text = itemdos.Cliente.TelefonoDos;

                panelViewSMS.lblHoraEntrada.Size = new Size(100, 25);
                panelViewSMS.lblHoraEntrada.Location = new Point(280, 8);



                panelViewSMS.lblLocalizacion.Text = itemdos.Cliente.Telefonotres.ToString();

                panelViewSMS.lblLocalizacion.Size = new Size(100, 25);
                panelViewSMS.lblLocalizacion.Location = new Point(430, 8);


                panelViewSMS.lblFechaEntrada.Text = itemdos.Cliente.Email.ToString();

                panelViewSMS.lblFechaEntrada.Location = new Point(570, 8);
                panelViewSMS.lblFechaEntrada.Size = new Size(130, 25);


                panelViewSMS.lblMontoPagado.Text = itemdos.TotalOrden.ToString();

                panelViewSMS.lblMontoPagado.Name = itemdos.OrdenId.ToString();

                panelViewSMS.lblMontoPagado.Size = new Size(120, 25);
                panelViewSMS.lblMontoPagado.Location = new Point(710, 8);


                panelViewSMS.lblTotal.Text = itemdos.Cliente.Visitas.ToString();

                panelViewSMS.lblTotal.Location = new Point(855, 8);
                panelViewSMS.lblTotal.Size = new Size(100, 25);

                if (itemdos.Pagos.Count > 0)
                {
                    panelViewSMS.lblMontoRestante.Text = itemdos.Pagos.FirstOrDefault().Puntos.ToString();

                    panelViewSMS.lblMontoRestante.Location = new Point(990, 8);
                    panelViewSMS.lblMontoRestante.Size = new Size(100, 25);
                }
                else
                {
                    panelViewSMS.lblMontoRestante.Text = "0";

                    panelViewSMS.lblMontoRestante.Location = new Point(990, 8);
                    panelViewSMS.lblMontoRestante.Size = new Size(100, 25);
                }
                panelViewSMS.lblEstado.Text = itemdos.Cliente.Notas.ToString();

                panelViewSMS.lblEstado.Location = new Point(1130, 8);
                panelViewSMS.lblEstado.Size = new Size(130, 25);








                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblId);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblFechaEntrada);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblHoraEntrada);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblLocalizacion);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblNombre);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblEstado);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblMontoRestante);
                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblTotal);

                panelViewSMS.Panel.Controls.Add(panelViewSMS.lblMontoPagado);



                listaClientes.Add(panelViewSMS);
                rowCount += 1;
                tblDetalleSMS.RowCount = rowCount;
                this.tblDetalleSMS.Controls.Add(listaClientes.Last().Panel, 0, rowCount);




            }

        }

        private void BorrarPanelReporteClientes()
        {
            var totaldos = tblDetalleSMS.Controls.Count;
            var litdos = tblDetalleSMS.Controls.OfType<Button>();
            for (int i = 0; i < totaldos; i++)
            {
                tblDetalleSMS.Controls.Remove(tblDetalleSMS.Controls[0]);
            }

        }
        void Mouseover(object sender, EventArgs e)
        {
            Panel btr = sender as Panel;




            object id = btr.Name;
            ColorEntrada = btr.BackColor;
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

    }
}
