using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Descendant
    {
        public int id { get; set; }
        public Personne parent { get; set; }
        public Personne enfant { get; set; }
        
    }
}