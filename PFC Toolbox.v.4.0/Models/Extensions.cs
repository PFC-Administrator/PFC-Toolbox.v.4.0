using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace PFC_Toolbox.v._4._0.Extensions
{
    public static class Extensions
    {
        public static string GetCreatedBy(this System.Security.Principal.IPrincipal usr)
        {
            var CreatedBy = ((ClaimsIdentity)usr.Identity).FindFirst("CreatedBy");
            if (CreatedBy != null)
                return CreatedBy.Value;

            return "";
        }

    }
}