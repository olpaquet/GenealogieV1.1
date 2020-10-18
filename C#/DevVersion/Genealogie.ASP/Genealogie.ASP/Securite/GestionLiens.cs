using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Securite
{
    public static class Retour
    {
        public static string LeRetour
        {
            get
            {
                return HttpContext.Current.Session["LeRetour"] == null ? "" : HttpContext.Current.Session["LeRetour"].ToString();
            }
            set
            {
                HttpContext.Current.Session["LeRetour"] = value;
            }
        }
        public static string Controleur
        {
            get
            {
                return HttpContext.Current.Session["RetourControleur"] == null ? "" : HttpContext.Current.Session["RetourControleur"].ToString();
            }
            set
            {
                HttpContext.Current.Session["RetourControleur"] = value;
            }
        }
        public static string Action
        {
            get
            {
                return HttpContext.Current.Session["RetourAction"] == null ? "" : HttpContext.Current.Session["RetourAction"].ToString();
            }
            set
            {
                HttpContext.Current.Session["RetourAction"] = value;
            }
        }
        public static object ValeurRouteId
        {
            get
            {
                return HttpContext.Current.Session["RetourId"] == null ? "" : HttpContext.Current.Session["RetourId"].ToString();
            }
            set
            {
                HttpContext.Current.Session["RetourId"] = value;
            }
        }

        public static object ValeurRouteId2
        {
            get
            {
                return HttpContext.Current.Session["RetourId2"] == null ? "" : HttpContext.Current.Session["RetourId2"].ToString();
            }
            set
            {
                HttpContext.Current.Session["RetourId2"] = value;
            }

        }

        public static void InitialiseRetour(string controleur, string action, int? id1, int? id2)
        {
            Retour.LeRetour = "le retour";
            Retour.Action = action;
            Retour.Controleur = controleur;
            Retour.ValeurRouteId = id1;
            Retour.ValeurRouteId2 = id2;
        }

        public static void VideRetour()
        {
            Retour.LeRetour = null;
            Retour.Action = "";
            Retour.Controleur = "";
            Retour.ValeurRouteId = null;
            Retour.ValeurRouteId2 = null;
        }
    }
}