using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BCC_Horarios_Y_Marcas
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");

            LinkButton mpLkbPlanillas = (LinkButton)mpLongView.FindControl("lkbPlanillas");
            //LinkButton mpLkbPlazass = (LinkButton)mpLongView.FindControl("lkbPlazas");
            LinkButton mpLkbUsuarios = (LinkButton)mpLongView.FindControl("lkbUsuarios");

            mpLkbPlanillas.Visible = false;
            //mpLkbPlazass.Visible = false;
            mpLkbUsuarios.Visible = false;

            //LoginView mpLongView = (LoginView)Master.FindControl("LoginView1");
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
        }
    }
}