using Genealogie.ASP.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Services
{
    public static class ServPersonne
    {
        public static IList<string> Fiche(Personne p)
        {
            IList<string> fiche = new List<string>();

            if (p == null || p.id==0) 
            {
                string unknown = "Inconnu(e)";
                fiche.Add($"{unknown}");
                return fiche;
            }
            string f = "";
            
            f += p.prenom.Trim();
            f += " ";
            f += p.nom.Trim();
            f = f.Trim();
            f += p.homme ? "(homme)" : "(femme)";
            
            fiche.Add(f);

            if (p.dateDeNaissance != null) { fiche.Add($"né le {((DateTime)p.dateDeNaissance).ToString("D", CultureInfo.CreateSpecificCulture(DesDates.cultureClub()))}"); }
            if (p.dateDeDeces != null) { fiche.Add($"décédé le {((DateTime)p.dateDeDeces).ToString("D", CultureInfo.CreateSpecificCulture(DesDates.cultureClub()))}"); }
            return fiche;
        }
    }
}