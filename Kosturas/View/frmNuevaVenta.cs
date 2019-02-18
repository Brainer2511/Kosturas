using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;
using Twilio.Rest.Api.V2010.Account;
using Kosturas.Model;

namespace Kosturas.View
{

    public partial class frmNuevaVenta : Form
    {
        public DataContextLocal db = new DataContextLocal();
        public frmNuevaVenta()
        {
            InitializeComponent();
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            //var numero = "ACa5ca880203f0929633ed8ef860fa2c26";
            //var Texto = "7ff3ff5137fe3cdda3a828c3ffa13044";//+&text=Texto+"
            var numero = "60618451";
            var Texto = "Pruebadfghrtyuidytfugiouytryuiopiuytretyuiopuytrewrty" +
                "uiopuytrewtyuiopuytrewtyuioyytrewtyuioyytrehgsghjgdfhjshdjgfhgh" +
                "sdfghjjfdhfgfghjfgfdhjg" +
                "sdafghjdfghjlkghfj" +
                "dfghjfdgshj" +
                "jsdghjfsdhgjgfhdsjhgjsfdhgjfdshgjgfhghgsf";//+&text=Texto+"
            //var detino= "+50684097899";
            //var otra = "+1 940 539 9871";
            var detino = "whatsapp:+50687987290";
            var otra = "whatsapp:+14155238886";
            //Twilio.TwilioClient.Init(numero, Texto);
            //// Twilio.Clients.TwilioRestClient client = new Twilio.Clients.TwilioRestClient(numero, Texto);
            //var mensaje = MessageResource.Create(
            //    body: "Hola Soy Brainer",
            //    from: new Twilio.Types.PhoneNumber(otra),
            //    to:new Twilio.Types.PhoneNumber(detino)
            //    );

             //System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=506"+numero+"&text="+Texto);
           // "whatsapp://send?text=Hello%2C%20World!
            System.Diagnostics.Process.Start("https://web.whatsapp.com/send?phone=506" + numero + "&text=" + Texto);
            //WhatsApp whats = new WhatsApp(numero, "869826022919748=", "",false,false);

            //whats.OnConnectSuccess += () =>
            //{
            //    MessageBox.Show("Conectado con Whatsapp");

            //    whats.OnLoginSuccess += (phoneNumber, data) =>
            //    {
            //        whats.SendMessage(detino, Texto);
            //        MessageBox.Show("mensaje enviado");
            //    };
            //    whats.OnLoginFailed += (data) =>
            //    {
            //        MessageBox.Show("Login Fallo", data);

            //    };
            //    whats.Login();
            //};

            //whats.OnConnectFailed += (ex) =>
            //{
            //    MessageBox.Show("Conexion Fayo",ex.Message);
            //};

        }

        private void btnvacio_Click(object sender, EventArgs e)
        {
            var Email = db.Templeis.FirstOrDefault().TempleiEmail;
         //   Email=Email.Replace("{ClientName}","Brainer").Replace
        }
    }
}
