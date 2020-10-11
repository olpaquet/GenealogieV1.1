using Genealogie.ASP.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Services
{
    public class DessinerArbre
    {
        public static string monSuperHtml(PersonneDansArbreIndividuel ppdai)
        {
            string ret = monHtml(ppdai);
            string classe = Convert.ToChar(34) + "arbre" + Convert.ToChar(34);
            ret = $"<div class={classe}><ul>{ret}</ul></div>";

            return ret;
        }
        private static string monHtml(PersonneDansArbreIndividuel ppdai)
        {
            string ret = "";
            string alaligne = Environment.NewLine;
            alaligne = "";

            //if (yeswecan || ppdai.descendants.Count()>0)
            //ret += $"{alaligne}<ul>";


            ret += $"{alaligne}<li>";
            string sexe = ppdai.homme ? "homme" : "femme";
            string lien = $"{Convert.ToChar(34)}#{Convert.ToChar(34)}";
            Console.WriteLine(lien);
            ret += $"<a href={lien}><p>{ppdai.prenom} {ppdai.nom} ({sexe})</p>";
            if (ppdai.dateDeNaissance != null) ret += $"né le {((DateTime)ppdai.dateDeNaissance).ToString("D", CultureInfo.CreateSpecificCulture(DesDates.cultureClub()))}";
            if (ppdai.dateDeDeces != null) ret += $"décédé le {((DateTime)ppdai.dateDeDeces).ToString("D", CultureInfo.CreateSpecificCulture(DesDates.cultureClub()))}";
            ret += "</a>";
            if (ppdai.descendants.Count() > 0) ret += "<ul>";
            foreach (PersonneDansArbreIndividuel descendant in ppdai.descendants)
            {
                //{Environment.NewLine}
                ret += $"{alaligne}{monHtml(descendant)}";
            }
            ret += $"{Environment.NewLine}";
            if (ppdai.descendants.Count() > 0) ret += "</ul>";

            //if (yeswecan || ppdai.descendants.Count() > 0)
            ret += $"{alaligne}</li>";

            return ret;
        }
    }
}