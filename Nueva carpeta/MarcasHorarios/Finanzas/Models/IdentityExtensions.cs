using Domain;
using Finanzas.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Matricula.Models
{
    public static class IdentityExtensions
    {
        public static int GetPersonaId(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("EmpleadoId");
            // Test for null to avoid issues during local testing
            return UsersHelper.Persona(claim.Value);
        }
       
    }
}