using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class FormRecherche
    {
        public int? arbreExclu { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public bool? homme { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public DateTime? dateDeDeces { get; set; }

        


    }
}