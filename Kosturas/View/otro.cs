using Microsoft.Reporting.WinForms;
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
    public partial class otro : Form
    {
        public int OrdenId { get; set; }
        public int DetalleId { get; set; }
        public otro(int idOrden = 0,int idDetalle=0)
        {
            DetalleId = idDetalle;
            OrdenId = idOrden;
            InitializeComponent();
        }

        private void otro_Load(object sender, EventArgs e)
        {
           

            try
            {

                this.sp_ReporteFActuradosTableAdapter1.Fill(this.dataSet11.sp_ReporteFActurados, DetalleId);
                ReportParameter report = new ReportParameter("Path", @"file://C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\" + OrdenId.ToString() +
                    ".png", true);
                this.reportViewer1.LocalReport.SetParameters(report);

                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();
                this.reportViewer1.RefreshReport();


            }
            catch (Exception ex)
            {

                ReportParameter report = new ReportParameter("Path", @"file://C:\Users\Erickxon\Desktop\Kosturas\Kosturas\bin\Debug\CodigosBarras\" + OrdenId.ToString() +
                   ".png", true);
                this.reportViewer1.LocalReport.SetParameters(report);


                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();
                this.reportViewer1.RefreshReport();
            }


        }
    }
}
