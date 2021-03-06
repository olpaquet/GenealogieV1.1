﻿using Genealogie.ASP.Models;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Securite
{ 

    public static class SessionUtilisateur
    {
        public static Utilisateur Utilisateur
        {
            
            get { if (HttpContext.Current.Session["utilisateur"] == null) return null; 
                return (Utilisateur)HttpContext.Current.Session["utilisateur"]; }
            set
            {

                HttpContext.Current.Session["Utilisateur"] = value;
                if (value == null)
                {
                    HttpContext.Current.Session["id"] = null;
                    HttpContext.Current.Session["nomaffichage"] = null;
                    HttpContext.Current.Session["admin"] = null;
                }
                else
                {
                    HttpContext.Current.Session["id"] = ((Utilisateur)value).id;
                    HttpContext.Current.Session["nomaffichage"] = ((Utilisateur)value).nomAffichage();
                    HttpContext.Current.Session["admin"] = ((Utilisateur)value).estAdmin()?"1":null;
                    var x = ((Utilisateur)value).estAdmin();
                }


                arbres = (value==null)?new List<Arbre>():new ArbreServiceAPI().DonnerParUtilisateur(Utilisateur.id).ToList();
                roles = (value == null) ? new List<Role>() : new UtilisateurRoleServiceAPI().DonnerRolesParUtilisateur(Utilisateur.id).ToList();
            }
        }

        public static int? id { get { return (int)HttpContext.Current.Session["id"]; } }
        public static string nomAffichage { get { return (string)HttpContext.Current.Session["nomaffichage"]; } }

        public static void AssignerUtilisateur(Utilisateur u)
        {
            SessionUtilisateur.Utilisateur = u;
        }
        public static void AssignerUtilisateur() { SessionUtilisateur.Utilisateur = null; }

        public static bool EstAdmin()
        {
            if (SessionUtilisateur.Utilisateur == null) return false;
            return SessionUtilisateur.Utilisateur.estAdmin();
        }

        public static bool Anonyme()
        {
            if (SessionUtilisateur.Utilisateur == null) return true;
            return false;
        }

        public static bool Connecte() { return !SessionUtilisateur.Anonyme(); }


        /* hors httpcontext */
        public static IList<Arbre> arbres;
        public static IList<Role> roles;
        
    }






}