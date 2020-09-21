using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class Recherche
    {
        public int? arbreExclu { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public bool? homme { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public DateTime? dateDeDeces { get; set; }
    }

    
}
