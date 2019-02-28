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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Kosturas
{
    public partial class frmReporteFactura : Form
    {
        DataContextLocal db = new DataContextLocal();
        public int OrdenId { get; set; }
        public frmReporteFactura(int idOrden)
        {
            OrdenId = idOrden;
            InitializeComponent();
        }

        private void frmReporteFactura_Load(object sender, EventArgs e)
        {
            try
            {
                this.sp_ReporteFActuradosTableAdapter.Fill(this.DataSet5.sp_ReporteFActurados, OrdenId);
            
               // DataSet3.sp_ReporteFActurados.Fill,GetData(OrdenId);
                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();


            }
            catch (Exception ex)
            {
            //    AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
            //    autoprintme.Print();
            
            }
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.sp_ReporteFActura' Puede moverla o quitarla según sea necesario.









            this.reportViewer1.RefreshReport();
        }
    }
}
