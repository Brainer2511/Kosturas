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
    public partial class frmVerCierreCajas : Form
    {
        DataContextLocal db = new DataContextLocal();
        int rowCount = 0;
        public List<OrdenViewModel> listaCierres = new List<OrdenViewModel>();
        public frmVerCierreCajas()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmVerCierreCajas_Load(object sender, EventArgs e)
        {

            var a = dtDesde.Value.ToShortDateString();

            var b = dtpHasta.Value.ToShortDateString();

       
            this.txtDesde.Text = a;
            this.txtHasta.Text = b;
        }

        private void btnActualizaRegistros_Click(object sender, EventArgs e)
        {

            var a = dtDesde.Value.ToShortDateString();

            var b = dtpHasta.Value.ToShortDateString();

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
            this.txtDesde.Text = a;
            this.txtHasta.Text = b;

            ClickCargarCierres(a,b);



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

        void ClickCargarCierres(string a,string b)
        {
           

            listaCierres = new List<OrdenViewModel>();
           


            


            var Colores = true;

            rowCount = 0;
        

            var desde = a + " 00:00";
            var hasta = b + " 23:59";
            var fdesde = DateTime.Parse(desde);
            var fhasta = DateTime.Parse(hasta);
           
            var query = db.CierreCajas.Where(q => q.FechaApertura >= fdesde && q.FechaCierre <= fhasta).ToList();



            foreach (var itemdos in query.ToList())

            {

                    var panelViewCierre = new OrdenViewModel();




                panelViewCierre.Panel.Name = itemdos.CierreId.ToString();


                if (Colores == true)
                {
                    panelViewCierre.Panel.BackColor = Color.White;
                    Colores = false;
                }
                else
                {
                    panelViewCierre.Panel.BackColor = Color.WhiteSmoke;
                    Colores = true;
                }

                panelViewCierre.lblId.Text = itemdos.MontoInicial.ToString();
                panelViewCierre.lblFechaEntrada.Text = itemdos.FechaApertura.ToString();
                panelViewCierre.lblHoraEntrada.Text = itemdos.FechaCierre.ToString();
                panelViewCierre.lblLocalizacion.Text = itemdos.TotalDiferencia.ToString();
                panelViewCierre.lblNombre.Text = itemdos.EmpleadoCerro.ToString();
                panelViewCierre.lblTotal.Text = itemdos.Notas.ToString();



                panelViewCierre.lblMontoPagado.Text = "Ver Monedas Y Billetes";
                panelViewCierre.lblMontoPagado.Name = itemdos.CierreId.ToString();
                panelViewCierre.lblMontoPagado.Click += new EventHandler(ClickCargarMonedas);

                panelViewCierre.lblMontoRestante.Text = "Ver Actual/Ingresos/ Diferencias";
                panelViewCierre.lblMontoRestante.Name = itemdos.CierreId.ToString();
                panelViewCierre.lblMontoRestante.Click += new EventHandler(ClickCargarDiferencias);



                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblId);
                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblFechaEntrada);
                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblHoraEntrada);
                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblLocalizacion);
                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblNombre);
                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblTotal);

                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblMontoRestante);
                panelViewCierre.Panel.Controls.Add(panelViewCierre.lblMontoPagado);

                

                    listaCierres.Add(panelViewCierre);
                    rowCount += 1;
                tlpCierresCajas.RowCount = rowCount;
               this.tlpCierresCajas.Controls.Add(listaCierres.Last().Panel, 0, rowCount);

             


            }

        }
        void ClickCargarMonedas(object sender, EventArgs e)
        {

            Label btn = sender as Label;
            var id = int.Parse(btn.Name);

            frmMonedasBilletes monedasBilletes = new frmMonedasBilletes(id);
            monedasBilletes.Location = new Point(122,140);
            monedasBilletes.ShowDialog();
        }
        void ClickCargarDiferencias(object sender, EventArgs e)
        {
            Label btn = sender as Label;
            var id = int.Parse(btn.Name);

            frmVerDiferencias diferencias = new frmVerDiferencias(id);
            diferencias.Location = new Point(122, 140);
            diferencias.ShowDialog();
        }
        private void dgvCierresCajas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            int a = e.RowIndex;

            if (a != -1)
            {

               
              


            }
        }
    }
}
