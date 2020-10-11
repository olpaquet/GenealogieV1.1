using System;
using System.Collections.Generic;
using System.Configuration;
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

        internal static string cultureClub()
        {
            return ConfigurationManager.AppSettings["culture"].ToString();
        }
    }
}