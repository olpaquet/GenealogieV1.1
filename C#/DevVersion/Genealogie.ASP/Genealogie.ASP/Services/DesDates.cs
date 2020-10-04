using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Services
{
    public static class DesDates
    {
        public static DateTime AjouterMois(this DateTime d, int nbMois)
        {
            return d.AddMonths(nbMois);
        }
    }
}