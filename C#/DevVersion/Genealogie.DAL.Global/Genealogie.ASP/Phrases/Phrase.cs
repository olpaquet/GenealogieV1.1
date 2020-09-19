using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Phrases
{
    public class Phrase
    {
        public static string Max(int i) { string s = i>1?"s":""; return $"Pas plus de {i} caractère{s}"; }

        public static string LoginExiste() { return $"Cet identifiant existe déjà."; }
        public static string NomExiste() { return $"Ce nom existe déjà."; }
        public static string TitreExiste() { return $"Ce titre existe déjà."; }
        public static string MotDePasseConfirme() { return $"Les deux mots de passe ne sont pas identiques."; }
    }
}