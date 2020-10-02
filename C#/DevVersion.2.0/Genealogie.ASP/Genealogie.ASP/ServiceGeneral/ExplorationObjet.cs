using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.ServiceGeneral
{
    public static class ExplorationObjet
    {
        public static bool Existe(object o, string nompropriete)
        {
            foreach (var prop in o.GetType().GetProperties()) { if (prop.Name == nompropriete) return true; }
            return false;

        }
        public static object Valeur(object o, string nompropriete)
        {
            foreach (var prop in o.GetType().GetProperties()) { if (prop.Name == nompropriete) return prop.GetValue(o, null); }
            return null;

        }
    }
}