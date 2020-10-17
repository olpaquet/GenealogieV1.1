using Genealogie.ASP.Conversion;
using Genealogie.ASP.Models;
using Genealogie.ASP.Services.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
//using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization.Configuration;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestHT();
            //TestChecked();

            for (int jj = 1; jj < 250; jj++) {
                char s = Convert.ToChar(jj);
                 //Console.WriteLine($"{jj}:{s}");
            }

            //testarbre();
            testForm(8);

            Console.WriteLine("appuyez sur une touche pour quitter");
            Console.ReadKey();

            
        }


        private static void testarbre()
        {
            Personne papynorbert = new PersonneServiceAPI().Donner(28);
            
            Console.WriteLine($"prénom={papynorbert.prenom}");

            PersonneDansArbreIndividuel pdai = new PersonneDansArbreIndividuel(papynorbert, int.MaxValue);
            string coucou = monSuperHtml(pdai);
            Console.WriteLine(coucou);
            //Console.WriteLine( monHtml(pdai));
        }

        private static void TestHT()
        {
            Hashtable ht = new Hashtable();
            object o = new object();

            ht.Add(1, "coucou");
            ht.Add(o, o);

            foreach(DictionaryEntry dic in ht)
            {
                Console.WriteLine(dic.Key.ToString());
            }


        }
        private static string monSuperHtml(PersonneDansArbreIndividuel ppdai)
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
            if (ppdai.dateDeNaissance != null) ret += $"né le {((DateTime)ppdai.dateDeNaissance).ToString("D",CultureInfo.CreateSpecificCulture(cultureClub()))}";
            if (ppdai.dateDeDeces != null) ret += $"décédé le {((DateTime)ppdai.dateDeDeces).ToString("D",CultureInfo.CreateSpecificCulture(cultureClub()))}";
            ret += "</a>";
            if (ppdai.descendants.Count() > 0) ret += "<ul>";
            foreach(PersonneDansArbreIndividuel descendant in ppdai.descendants)
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

        private static void TestChecked()
        {
            int i = int.MaxValue;
            //int j = checked(i + 7);
            int j;
            checked
            {
                j = i + 10;

            }
            Console.WriteLine($"j={j}");
        }

        private static string cultureClub()
        {
            return ConfigurationManager.AppSettings["culture"].ToString();
        }

        private static void testForm(int id)
        {
            Personne maitre = new PersonneServiceAPI().Donner(28);
            Personne parent = null;
            FormArbre fa = new FormArbre(maitre, parent);
            //F2ormArbre f2a = new F2ormArbre(fa);
            var y = "x";
        }

    }


}
