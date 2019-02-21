using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");
            //LinkButton mpLkbPersonal = (LinkButton)mpLongView.FindControl("lkbPersonal");
            //LinkButton mpLkbCargaDatos = (LinkButton)mpLongView.FindControl("lkbCargaDatos");
            //LinkButton mpLkbUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");
            //LinkButton mpLkbProgramacion = (LinkButton)mpLongView.FindControl("lkbProgramacion");
            //LinkButton mpLkbJefaturas = (LinkButton)mpLongView.FindControl("lkbJefaturas");

            //mpLkbPersonal.Visible = false;
            //mpLkbCargaDatos.Visible = false;
            //mpLkbUsuarios.Visible = false;
            //mpLkbProgramacion.Visible = false;
            //mpLkbJefaturas.Visible = false;

            LinkButton mpLkbPlanillas = (LinkButton)mpLongView.FindControl("lkbPlanillas");
            //LinkButton mpLkbPlazass = (LinkButton)mpLongView.FindControl("lkbPlazas");
            LinkButton mpLkbUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");

            mpLkbPlanillas.Visible = false;
            //mpLkbPlazass.Visible = false;
            mpLkbUsuarios.Visible = false;

            if (!IsPostBack)
            {
                Session.Abandon();
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
                Response.Cache.SetCacheability(HttpCacheability.ServerAndNoCache);
                Response.Cache.SetAllowResponseInBrowserHistory(false);
                Response.Cache.SetNoStore();
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            FailureText.Text = string.Empty;
            ErrorMessage.Visible = false;
            try
            {
                var bll = new Planilla_WCF();
                var oUsuario = new Usuario();

                oUsuario.email = Email.Text;
                oUsuario.password = GenerarNuevoHash(Password.Text);

                var valido = bll.validarUsuario(ref oUsuario);

                if (valido == 1)
                {
                    registrarSesion(oUsuario);
                    Session["Usuario"] = "Administrador";
                    Session["DatosUsuario"] = oUsuario;
                    Session["idPersona"] = oUsuario.idPersona;
                    Session["idUsuario"] = oUsuario.idUsuario;
                    Response.Redirect("../Forms/frmListadoPersonal.aspx");
                }
                else if (valido == 2)
                {
                    registrarSesion(oUsuario);
                    Session["Usuario"] = "Usuario";
                    Session["DatosUsuario"] = oUsuario;
                    Session["idPersona"] = oUsuario.idPersona;
                    Session["idUsuario"] = oUsuario.idUsuario;
                    //Response.Redirect("../Forms/frmListadoPersonal.aspx");
                    if (oUsuario.departamento == 2)
                    {
                        Session["Usuario"] = "Usuario WFM";
                        Response.Redirect("../Forms/frmCargaDatos.aspx");
                    }
                    else //if (oUsuario.departamento == )
                    {
                        Session["Usuario"] = "Usuario Supervisor";
                        Response.Redirect("../Forms/frmControlAsistencia.aspx");
                    }
                    //else
                    //{
                    //    Session["Usuario"] = "Usuario Reporte";
                    //    Response.Redirect("../frmReporte.aspx");
                    //}
                }
                else
                {
                    FailureText.Text = "Intento invalido, revise sus credenciales.";
                    ErrorMessage.Visible = true;
                }
            }
            catch (Exception ex)
            {
                FailureText.Text = "Intento invalido, revise sus credenciales.";
                ErrorMessage.Visible = true;
            }
        }

        private void registrarSesion(Usuario oUsuario)
        {
            try
            {
                var bll = new Planilla_WCF();
                var idSesion = bll.RegistrarSesion(oUsuario);
                Session["idSesion"] = idSesion;
            }
            catch (Exception ex)
            {
                FailureText.Text = "Se presentó un problema a lo interno del sistema. Por favor intentelo nuevamente!";
                ErrorMessage.Visible = true;
            }
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

        //protected void LogIn(object sender, EventArgs e)
        //{
        //    if (IsValid)
        //    {
        //        // Validate the user password
        //        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        //        var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

        //        // This doen't count login failures towards account lockout
        //        // To enable password failures to trigger lockout, change to shouldLockout: true
        //        var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

        //        switch (result)
        //        {
        //            case SignInStatus.Success:
        //                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
        //                break;
        //            case SignInStatus.LockedOut:
        //                Response.Redirect("/Account/Lockout");
        //                break;
        //            case SignInStatus.RequiresVerification:
        //                Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
        //                                                Request.QueryString["ReturnUrl"],
        //                                                RememberMe.Checked),
        //                                  true);
        //                break;
        //            case SignInStatus.Failure:
        //            default:
        //                FailureText.Text = "Invalid login attempt";
        //                ErrorMessage.Visible = true;
        //                break;
        //        }
        //    }
        //}
    }
}