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
using System.Data.SqlClient;

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

                var connectionString = "Data Source=SQL5030.site4now.net; Initial Catalog=DB_A27AB6_djarquin01;User Id=DB_A27AB6_djarquin01_admin;Password=Shenlong123;";


                SqlConnection conx = new SqlConnection(connectionString);
                String  spconsulta;

                spconsulta = "sp_ReporteFActurados";
                SqlDataAdapter sql = new SqlDataAdapter(spconsulta,conx);
                conx.Open();
                sql.SelectCommand.CommandType = CommandType.StoredProcedure;
                sql.SelectCommand.Parameters.Add("@idOrden", SqlDbType.Int).Value=OrdenId;



                DataTable data = new DataTable("Prueba");
               
                sql.Fill(data);

               if(data.Rows.Count > 0)
                {

                }
                //this.sp_ReporteFActuradosTableAdapter.Connection = conx;
               // this.sp_ReporteFActuradosTableAdapter.Fill(this.DataSet5.sp_ReporteFActurados, OrdenId);
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("DataSet5",data));


                // DataSet3.sp_ReporteFActurados.Fill,GetData(OrdenId);
                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();




                this.reportViewer1.LocalReport.Refresh();
                conx.Close();
            }
            catch (Exception ex)
            {



                this.reportViewer1.RefreshReport();
                //AutoPrintCls autoprintme = new AutoPrintCls(reportViewer1.LocalReport);
                //autoprintme.Print();

            }
            // TODO: esta línea de código carga datos en la tabla 'DataSet1.sp_ReporteFActura' Puede moverla o quitarla según sea necesario.






            
        }
    }
}
