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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using System.IO;
using Domain;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using BarcodeLib;

namespace Kosturas.View

{
    public partial class prueba : Form
    {
        DataContextLocal db = new DataContextLocal();
        Byte[] dato;
        public prueba()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Ordenes.Where(q => q.OrdenId == 12).Select(t => new { t.OrdenId, t.CantidadPagada, t.CantidadRestante, t.TotalOrden }).ToList();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            To_pdf();
        }

        #region crearPDF
        private void To_pdf()
        {
            Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:";
            saveFileDialog1.Title = "Guardar Reporte";
            saveFileDialog1.DefaultExt = "pdf";
            saveFileDialog1.Filter = "pdf Files (*.pdf)|*.pdf| All Files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            string filename = "";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
            }

            if (filename.Trim() != "")
            {
                FileStream file = new FileStream(filename,
                FileMode.OpenOrCreate,
                FileAccess.ReadWrite,
                FileShare.ReadWrite);
                PdfWriter.GetInstance(doc, file);
                doc.Open();
                string remito = "Autorizo: OSVALDO SANTIAGO ESTRADA";
                string envio = "Fecha:" + DateTime.Now.ToString();

                Chunk chunk = new Chunk("Reporte de General Usuarios", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD));
                doc.Add(new Paragraph(chunk));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("Lagos de moreno Jalisco"));
                doc.Add(new Paragraph(remito));
                doc.Add(new Paragraph(envio));
                doc.Add(new Paragraph("------------------------------------------------------------------------------------------"));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("                       "));
                doc.Add(new Paragraph("                       "));
                GenerarDocumento(doc);
                doc.AddCreationDate();
                doc.Add(new Paragraph("______________________________________________", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
                doc.Add(new Paragraph("Firma", FontFactory.GetFont("ARIAL", 20, iTextSharp.text.Font.BOLD)));
                doc.Close();
                Process.Start(filename);//Esta parte se puede omitir, si solo se desea guardar el archivo, y que este no se ejecute al instante
            }

        }
        public void GenerarDocumento(Document document)
        {
            int i, j;
            PdfPTable datatable = new PdfPTable(dataGridView1.ColumnCount);
            datatable.DefaultCell.Padding = 3;
            float[] headerwidths = GetTamañoColumnas(dataGridView1);
            datatable.SetWidths(headerwidths);
            datatable.WidthPercentage = 100;
            datatable.DefaultCell.BorderWidth = 2;
            datatable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            for (i = 0; i < dataGridView1.ColumnCount; i++)
            {
                datatable.AddCell(dataGridView1.Columns[i].HeaderText);
            }
            datatable.HeaderRows = 1;
            datatable.DefaultCell.BorderWidth = 1;
            for (i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value != null)
                    {
                        datatable.AddCell(new Phrase(dataGridView1[j, i].Value.ToString()));//En esta parte, se esta agregando un renglon por cada registro en el datagrid
                    }
                }
                datatable.CompleteRow();
            }
            document.Add(datatable);
        }
        public float[] GetTamañoColumnas(DataGridView dg)
        {
            float[] values = new float[dg.ColumnCount];
            for (int i = 0; i < dg.ColumnCount; i++)
            {
                values[i] = (float)dg.Columns[i].Width;
            }
            return values;

        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {

            CodigoBarras sucursal = new CodigoBarras();

      
     
          
        

            var prueba = CodigoBarras();
      
        }

        public Bitmap codigo128(string _code, bool vertexto= true, int Height = 0)
        {
            var barcode = new BarcodeCodabar();
            barcode.StartStopText = true;
      
            barcode.Code = "A"+_code+"B";
        
            var bm = new System.Drawing.Bitmap(barcode.CreateDrawingImage(Color.Black, Color.White),200,30);
        
           var bmT = new Bitmap(bm.Width+300, bm.Height + 30);
                var g = Graphics.FromImage(bmT);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, bm.Width+300, bm.Height + 30);

            var pintarTexto = new System.Drawing.Font("Arial", 22);
            var brocha = (new SolidBrush(Color.Black));

            var stringSize = new SizeF();
            stringSize = g.MeasureString(_code, pintarTexto);
            var centrox = (bm.Width+250 - stringSize.Width) / 2;
            var x = centrox;
            var y = bm.Height;

            var drawformat = new StringFormat();
            drawformat.FormatFlags = StringFormatFlags.NoWrap;
                g.DrawImage(bm, 0, 0);

            var ncode = _code.Substring(0, _code.Length - 0);
            g.DrawString(ncode, pintarTexto, brocha, x, y, drawformat);


            // ConvertBitMapToByteArray(bmT);


            //string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\CodigosBarras\"; // <---
            //if (Directory.Exists(appPath) == false)                                              // <---
            //{                                                                                    // <---
            //    Directory.CreateDirectory(appPath);                                              // <---
            //}                                                                                    // <---

            //appPath += "1005.png";
            //bmT.Save(appPath, ImageFormat.Png);
            //return appPath;
            return bmT;
            
        }


        public string CodigoBarras()
        {
          BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
            barcode.IncludeLabel = true;
            pictureBox1.Image = barcode.Encode(BarcodeLib.TYPE.CODE128, "1005", Color.Black, Color.White, 300, 50);

            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\CodigosBarras\"; // <---
            if (Directory.Exists(appPath) == false)                                              // <---
            {                                                                                    // <---
                Directory.CreateDirectory(appPath);                                              // <---
            }                                                                                    // <---

            appPath += "1005.png";
            barcode.SaveImage(appPath,SaveTypes.PNG);
            //bmT.Save(appPath, ImageFormat.Png);
            return appPath;

        }

        public byte[] ConvertBitMapToByteArray(Bitmap bitmap)
        {
            byte[] result = null;

            if (bitmap != null)
            {
                MemoryStream stream = new MemoryStream();
                bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                Byte[] bytes = stream.ToArray();
                result = stream.ToArray();
                dato= result;
                //MemoryStream stream = new MemoryStream();
                //bitmap.Save(stream, bitmap.RawFormat);
                //result = stream.ToArray();
            }

            return result;
        }

        private void prueba_Load(object sender, EventArgs e)
        {
           
           
        }
    }
}
