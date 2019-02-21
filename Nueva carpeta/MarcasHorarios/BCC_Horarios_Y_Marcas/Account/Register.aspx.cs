using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using BCC_Horarios_Y_Marcas.Models;
using System.Web.UI.WebControls;
using System.Threading;
using System.Text;
using System.Security.Cryptography;

namespace BCC_Horarios_Y_Marcas.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Usuario"] == null) { Response.Redirect("../Default.aspx"); }
            LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");
            LinkButton mpLinkButton = (LinkButton)mpLongView.FindControl("LoginTag");
            LinkButton mpLogoffButton = (LinkButton)mpLongView.FindControl("LogoffTag");
            mpLinkButton.Visible = false;
            mpLogoffButton.Visible = true;
            lblMensaje.Visible = false;
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            //var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            //var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
            //IdentityResult result = manager.Create(user, Password.Text);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
            //    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //}
            //else 
            //{
            //    ErrorMessage.Text = result.Errors.FirstOrDefault();
            //}

            lblMensaje.Visible = false;

            var ad = new Planilla_WCF();
            var oUsuario = new Usuario();
            oUsuario.email = Email.Text; //txtUsuario.Text;
            oUsuario.password = GenerarNuevoHash(Password.Text); //txtContrasena.Text;
            oUsuario.ConfirmPass = ConfirmPassword.Text; //txtNombre.Text;
            //oUsuario.EsAdmin = ckAdmin.Checked;
            ad.RegistrarUsuario(oUsuario);
            Email.Text = "";
            Password.Text = "";
            ConfirmPassword.Text = "";
            //ckAdmin.Checked = false;
            Email.Text = string.Empty;
            Password.Text = string.Empty;
            ConfirmPassword.Text = string.Empty;
            lblMensaje.Visible = true;
        }

        /// <summary>
        /// Crear una nueva Clave Hash
        /// </summary>
        /// <param name="valorDigitado"></param>
        /// <returns></returns>
        public static string GenerarNuevoHash(string valorDigitado)
        {
            var nuevoValorHash = NuevoHash(valorDigitado);
            var valorByte = Encoding.ASCII.GetBytes(nuevoValorHash);
            nuevoValorHash = string.Empty;
            for (var i = 0; i <= valorByte.Length - 1; i++)
                nuevoValorHash = nuevoValorHash + valorByte[i];

            return nuevoValorHash;
        }

        /// <summary>
        /// Permite crear un nuevo Hash utilizando el sistema criptográfico Hash 512 de Microsoft        
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        public static string NuevoHash(string clave)
        {
            var sha = new SHA512Managed();

            SHA512.Create();
            var nuevoHashStr = clave;
            var nuevoHash = Encoding.ASCII.GetBytes(nuevoHashStr);

            var hashProcesado = sha.ComputeHash(nuevoHash);
            return Encoding.ASCII.GetString(hashProcesado);
        }
    }
}