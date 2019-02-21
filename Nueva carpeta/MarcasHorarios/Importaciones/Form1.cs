using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Domain;
using Importacion.Models;
using Importaciones.ViewModels;
using Microsoft.Office.Interop;

namespace Importacion
{
    public partial class Form1 : Form
    {
        DataContextLocal db = new DataContextLocal();

        public Form1()
        {           
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            
                lblMensaje.Text = "Procesando...";
                lblMensaje.ForeColor = System.Drawing.Color.Gray;

                OpenFileDialog openFileDialog1 = new OpenFileDialog();


                openFileDialog1.Title = "Buscar Importar";

                openFileDialog1.CheckFileExists = true;

                openFileDialog1.CheckPathExists = true;



                openFileDialog1.DefaultExt = ".xlsx";

                openFileDialog1.Filter = "Text files (*.xlsx)|*.xls|All files (*.*)|*.*";

                openFileDialog1.FilterIndex = 2;

                openFileDialog1.RestoreDirectory = true;



                openFileDialog1.ReadOnlyChecked = true;

                openFileDialog1.ShowReadOnly = true;



                if (openFileDialog1.ShowDialog() == DialogResult.OK)

                {

                    textBox1.Text = openFileDialog1.FileName;

                }
                if (openFileDialog1.FileName.EndsWith("xls") || openFileDialog1.FileName.EndsWith("xlsx"))
                {
                    //readv data file
                    Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook = application.Workbooks.Open(textBox1.Text);
                    Microsoft.Office.Interop.Excel.Worksheet worksheet = workbook.ActiveSheet;
                    Microsoft.Office.Interop.Excel.Range range = worksheet.UsedRange;
                    var fila = 0;
                try
                {
                    Marca marca = new Marca();
                    MarcaViewModelImport viewImport = new MarcaViewModelImport();

                    for (int row = 2; row <= range.Rows.Count; row++)
                    {
                        fila = row;
                        lblContador.Text = "(" + (row - 1).ToString() + "/" + (range.Rows.Count - 1).ToString() + ")";

                        var ubicacionId = FindUbicacionId(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 1]).Text);
                    
                        var personaId = FindPersonaId(((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 2]).Text, ubicacionId);

                        if (personaId>0)
                        {
                            marca.UbicacionId = ubicacionId;
                            marca.PersonaId = personaId;
                            viewImport.Fecha = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 3]).Text;
                            viewImport.HoraEntrada = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 4]).Text;
                            viewImport.HoraSalida = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 5]).Text;
                            viewImport.HoraOT = ((Microsoft.Office.Interop.Excel.Range)range.Cells[row, 6]).Text;

                            var persona = await db.Personas.FindAsync(marca.PersonaId);
                            marca = ToMarca(marca, viewImport);

                            //Ponemos estado normal en caso de que las horas sean las mismas
                            if (marca.HorasTrabajadas.Hours == persona.Puesto.Horas)
                                marca.EstadoMarcaId = 1;

                            db.Marcas.Add(marca);
                            db.SaveChanges();
                            
                            if (marca.HorasTrabajadas.Hours!=persona.Puesto.Horas)
                            {
                                var justificacion = new Justificacion
                                {
                                    FechaCreacion = DateTime.Now,
                                    SubordinadoId = personaId,
                                    SupervisorId = persona.SupervisorId,
                                };
                                db.Justificaciones.Add(justificacion);
                                await db.SaveChangesAsync();

                                var notificacion = new NotificacionPersona
                                {
                                    Activo = true,
                                    Fecha=DateTime.Now,
                                    Nota="Solicitud de Justificación " + persona.NombreCompleto,
                                    Titulo="Justificación",
                                    PersonaId=persona.SupervisorId.Value,                                    
                                };

                                db.NotificacionPersonas.Add(notificacion);
                                await db.SaveChangesAsync();
                            } 
                        }
                    }

                    range = null;
                    worksheet = null;
                    workbook.Close(false, Type.Missing, Type.Missing);

                    application.Quit();

                    KillExcel(application);

                    System.Runtime.InteropServices.Marshal.ReleaseComObject(application);
                    workbook = null;
                    application = null;

                    lblMensaje.Text = "Finalizado correctamente...";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                }
                catch (Exception ex)
                {

                    lblMensaje.Text = "Error por favor revise el archivo - Fila (" + fila + ")";
                    if (ex.InnerException != null)
                    {
                        lblMensaje.Text = (Char)13 + ex.InnerException.Message.ToString();
                        lblMensaje.ForeColor = System.Drawing.Color.Red;

                    }
                    else if (ex.Message != null)
                    {
                        lblMensaje.Text = (Char)13 + ex.Message.ToString();
                        lblMensaje.ForeColor = System.Drawing.Color.Red;

                    }
                }


            }
                else
                {
                    lblMensaje.Text = "El archivo no es correcto...";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;

                }
            
        }

        private Marca ToMarca(Marca marca, MarcaViewModelImport viewImport)
        {
            try
            {
                if (!string.IsNullOrEmpty(viewImport.Fecha))
                {
                    marca.Fecha = DateTime.Parse(viewImport.Fecha);
                }

                if (!string.IsNullOrEmpty(viewImport.HoraEntrada))
                {
                    marca.HoraEntrada = TimeSpan.Parse(viewImport.HoraEntrada);
                }

                if (!string.IsNullOrEmpty(viewImport.HoraSalida))
                {
                    marca.HoraSalida = TimeSpan.Parse(viewImport.HoraSalida);
                }

                if (!string.IsNullOrEmpty(viewImport.HoraOT))
                {
                    marca.HoraOT = TimeSpan.Parse(viewImport.HoraOT);
                }

                return marca;
            }
            catch (Exception)
            {

                return marca;
            }
        }

        private int FindUbicacionId(string text)
        {
            try
            {
                int ubicacionId = int.Parse(text);
                if (db.Ubicaciones.Where(u => u.UbicacionId==ubicacionId).Count()>0)
                {
                    return db.Ubicaciones.Where(u => u.UbicacionId == ubicacionId).FirstOrDefault().UbicacionId;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        private int FindPersonaId(string text, int ubicacionId)
        {
            try
            {
                string marca = text;
                marca = marca.TrimStart().TrimEnd();

                switch (ubicacionId)
                {
                    case 1:                        
                        if (db.Personas.Where(p => p.MarcaSP == marca).Count() > 0)
                        {
                            return db.Personas.Where(u => u.MarcaSP == marca).FirstOrDefault().PersonaId;
                        }
                        else
                        {
                            return 0;
                        }
                    default:
                        return 0;
                }               
            }
            catch (Exception)
            {

                return 0;
            }
        }             

        private static void KillExcel(Microsoft.Office.Interop.Excel.Application theApp)
        {
            int id = 0;
            IntPtr intptr = new IntPtr(theApp.Hwnd);
            System.Diagnostics.Process p = null;
            try
            {
                GetWindowThreadProcessId(intptr, out id);
                p = System.Diagnostics.Process.GetProcessById(id);
                if (p != null)
                {
                    p.Kill();
                    p.Dispose();
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

        [DllImport("User32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, out int ProcessId);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
