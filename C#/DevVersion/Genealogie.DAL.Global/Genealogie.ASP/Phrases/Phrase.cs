using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Phrases
{
    public class Phrase
    {
        public static string Max(int i) { string s = i>1?"s":""; return $"Pas plus de {i} caractère{s}"; }
    }
}