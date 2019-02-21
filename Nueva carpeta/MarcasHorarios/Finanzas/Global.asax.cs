using Finanzas.Helpers;
using Finanzas.Infraestructura;
using System;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Finanzas
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Models.DataContextLocal, Migrations.Configuration>());
            CheckRolesAndSuperUser();
            CheckEstadoCivil();
            CheckHorarioRubro();
            CheckEstadoMarca();
            AutomapperWebProfile.Run();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
          
        }

        private void CheckEstadoMarca()
        {
            EstadoMarcaHelper.CheckEstadoMarcas();
        }

        private void CheckEstadoCivil()
        {
            EstadoCivilHelper.CheckEstadosCiviles();
        }

        private void CheckHorarioRubro()
        {
            HorarioRubroHelper.CheckHorarioRubros();
        }

        private void CheckRolesAndSuperUser()
        {
            UsersHelper.CheckRole("Administrador");
            UsersHelper.CheckRole("Supervisor");
            UsersHelper.CheckRole("Agente");
            UsersHelper.CheckSuperUser();
        }
    }
}
