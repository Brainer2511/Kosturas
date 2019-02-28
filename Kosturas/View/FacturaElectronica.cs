using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using Kosturas.API;
using Kosturas.Model;

namespace Kosturas.View
{
    public partial class FacturaElectronica : Form
    {

        DataContextLocal db = new DataContextLocal();
        public FacturaElectronica()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {

    


            ApiService api = new ApiService();
           await api.Facturar();
        }

        public class Rootobject
        {
            public bool success { get; set; }
            public Data data { get; set; }
        }

        public class Data
        {
            public int id { get; set; }
            public string username { get; set; }
            public string nombre { get; set; }
            public string auth_key { get; set; }
            public string password_hash { get; set; }
            public string password_reset_token { get; set; }
            public string email { get; set; }
            public int status { get; set; }
            public int created_at { get; set; }
            public int updated_at { get; set; }
            public string access_token { get; set; }
        }


       
        async void resultado()
        {

            IEnumerable<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>()
            {
new KeyValuePair<string, string>("username","3101708154"),
new KeyValuePair<string, string>("password","pruebas")
            };

            HttpContent content = new FormUrlEncodedContent(keys);
            var url = "http://costulatam.facturaelectronicacrc.com/api/web/site/login";

            HttpClient cliente = new HttpClient();
            var prueba = await cliente.PostAsync(url, content);
            HttpResponseMessage response = await cliente.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await response.Content.ReadAsStringAsync();

                Rootobject data = JsonConvert.DeserializeObject<Rootobject>(respuesta);

                var id = data.data.id;
                var token = data.data.access_token;

            

               
            }






        }
        public void DataSetToJson()
        {
            DataSet dataSet = new DataSet("dataSet");
            dataSet.Namespace = "NetFrameWork";

            DataTable TableId = new DataTable();
            TableId.Namespace= "Prueba";
            DataColumn ColunmId = new DataColumn("user_id", typeof(int));

            TableId.Columns.Add(ColunmId);
            DataRow rows = TableId.NewRow();

            rows[0] = 14;
            TableId.Rows.Add(rows);
            DataTable Factura = new DataTable();

            DataColumn EncabezadoFactura1 = new DataColumn("condicion_venta", typeof(char));
            DataColumn EncabezadoFactura2 = new DataColumn("medio_pago", typeof(char));
            DataColumn EncabezadoFactura3 = new DataColumn("moneda", typeof(char));
            DataColumn EncabezadoFactura4 = new DataColumn("tipo_cambio", typeof(decimal));
            DataColumn EncabezadoFactura5 = new DataColumn("receptor_nombre", typeof(string));
            DataColumn EncabezadoFactura6 = new DataColumn("receptor_tipo_identificacion", typeof(char));
            DataColumn EncabezadoFactura7 = new DataColumn("receptor_numero_identificacion", typeof(string));
            DataColumn EncabezadoFactura8 = new DataColumn("receptor_provincia", typeof(int));
            DataColumn EncabezadoFactura9 = new DataColumn("receptor_canton", typeof(int));
            DataColumn EncabezadoFactura10 = new DataColumn("receptor_distrito", typeof(int));
            DataColumn EncabezadoFactura11 = new DataColumn("receptor_otras_senas", typeof(string));
            DataColumn EncabezadoFactura12 = new DataColumn("receptor_telefono", typeof(int));
            DataColumn EncabezadoFactura13 = new DataColumn("receptor_email", typeof(string));



            

            Factura.Columns.Add(EncabezadoFactura1);
            Factura.Columns.Add(EncabezadoFactura2);
            Factura.Columns.Add(EncabezadoFactura3);
            Factura.Columns.Add(EncabezadoFactura4);
            Factura.Columns.Add(EncabezadoFactura5);
            Factura.Columns.Add(EncabezadoFactura6);
            Factura.Columns.Add(EncabezadoFactura7);
            Factura.Columns.Add(EncabezadoFactura8);
            Factura.Columns.Add(EncabezadoFactura9);
            Factura.Columns.Add(EncabezadoFactura10);
            Factura.Columns.Add(EncabezadoFactura11);
            Factura.Columns.Add(EncabezadoFactura12);
            Factura.Columns.Add(EncabezadoFactura13);
            DataRow FacturaRows = Factura.NewRow();

            FacturaRows[0] = '1';
            FacturaRows[1] = '1';
            FacturaRows[2] = '1';
            FacturaRows[3] = 18.8;
            FacturaRows[4] = "Brainer";
            FacturaRows[5] = '1';
            FacturaRows[6] = "206680137";
            FacturaRows[7] = 2;
            FacturaRows[8] = 3;
            FacturaRows[9] = 20308;
            FacturaRows[10] = "San Juan ";
            FacturaRows[11] = 84097899;
            FacturaRows[12] = "branerhidalgo@gmail.com";
            Factura.Rows.Add(FacturaRows);
            

            DataTable DetalleFactura = new DataTable();

            DataColumn DetalleFactura1 = new DataColumn("codigo", typeof(string));
            DataColumn DetalleFactura2 = new DataColumn("cantidad", typeof(decimal));
            DataColumn DetalleFactura3 = new DataColumn("precio_unitario", typeof(decimal));
            DataColumn DetalleFactura4 = new DataColumn("unidad_medida_codigo", typeof(string));
            DataColumn DetalleFactura5 = new DataColumn("detalle", typeof(string));
            DataColumn DetalleFactura6 = new DataColumn("monto_descuento", typeof(decimal));
            DataColumn DetalleFactura7 = new DataColumn("naturaleza_descuento", typeof(string));
            DataColumn DetalleFactura8 = new DataColumn("impuesto_codigo", typeof(string));
            DataColumn DetalleFactura9 = new DataColumn("impuesto_tarifa", typeof(decimal));
            DataColumn DetalleFactura10 = new DataColumn("tipo_documento_exoneracion", typeof(string));
            DataColumn DetalleFactura11 = new DataColumn("num_documento_exoneracion", typeof(string));
            DataColumn DetalleFactura12 = new DataColumn("nombre_institucion_emite_exoneracion", typeof(string));
            DataColumn DetalleFactura13 = new DataColumn("fecha_emision_exoneracion", typeof(DateTime));
            DataColumn DetalleFactura14 = new DataColumn("monto_impuesto_exonerado", typeof(decimal));
            DataColumn DetalleFactura15 = new DataColumn("porcentaje_compra_exoneracion", typeof(int));
            DataColumn DetalleFactura16 = new DataColumn("impuesto_incluido", typeof(int));



            DetalleFactura.Columns.Add(DetalleFactura1);
            DetalleFactura.Columns.Add(DetalleFactura2);
            DetalleFactura.Columns.Add(DetalleFactura3);
            DetalleFactura.Columns.Add(DetalleFactura4);
            DetalleFactura.Columns.Add(DetalleFactura5);
            DetalleFactura.Columns.Add(DetalleFactura6);
            DetalleFactura.Columns.Add(DetalleFactura7);
            DetalleFactura.Columns.Add(DetalleFactura8);
            DetalleFactura.Columns.Add(DetalleFactura9);
            DetalleFactura.Columns.Add(DetalleFactura10);
            DetalleFactura.Columns.Add(DetalleFactura11);
            DetalleFactura.Columns.Add(DetalleFactura12);
            DetalleFactura.Columns.Add(DetalleFactura13);
            DetalleFactura.Columns.Add(DetalleFactura14);
            DetalleFactura.Columns.Add(DetalleFactura15);
            DetalleFactura.Columns.Add(DetalleFactura16);
            DataRow Detalle = DetalleFactura.NewRow();

            Detalle[0] = "01";
            Detalle[1] = 15;
            Detalle[2] = 15;
            Detalle[3] = "01";
            Detalle[4] = "Prueba";
            Detalle[5] = 0;
            Detalle[6] = "0";
            Detalle[7] = "0";
            Detalle[8] = 0;
            Detalle[9] = "";
            Detalle[10] = "";
            Detalle[11] = "";
            Detalle[12] = DateTime.Today;
            Detalle[13] = 0;
            Detalle[14] = 0;
            Detalle[15] = 0;


            DetalleFactura.Rows.Add(Detalle);



        
            dataSet.Tables.Add(TableId);
            dataSet.Tables.Add(Factura);
            dataSet.Tables.Add(DetalleFactura);


            dataSet.AcceptChanges();




           


            var pruebas = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            resultadodos(pruebas);
            textBox1.Text = pruebas;



        }

        async void resultadodos(string json)
        {


            IEnumerable<KeyValuePair<string, string>> keys = new List<KeyValuePair<string, string>>()
            {
new KeyValuePair<string, string>("setHeaders(Authorization)","OXSSgZkl8UKVcOdOZC3PlygkG8KOo2c3"),
new KeyValuePair<string, string>("auth_key","OXSSgZkl8UKVcOdOZC3PlygkG8KOo2c3"),
new KeyValuePair<string, string>(json,json)
            };

            HttpContent content = new FormUrlEncodedContent(keys);
            var url = "http://costulatam.facturaelectronicacrc.com/api/web/site/login";

            HttpClient cliente = new HttpClient();
            var prueba = await cliente.PostAsync(url, content);
            HttpResponseMessage response = await cliente.PostAsync(url, content);

            if (response.IsSuccessStatusCode)
            {
                var respuesta = await response.Content.ReadAsStringAsync();









        var list = JsonConvert.DeserializeObject(respuesta);
                //textBox1.Text = respuesta;


            }






}


    }
}
