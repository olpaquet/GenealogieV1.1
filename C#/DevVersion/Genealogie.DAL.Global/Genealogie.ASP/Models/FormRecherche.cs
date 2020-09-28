using Genealogie.ASP.Services.API;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class FormRecherche
    {
        public int? idCreateurExclu { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public bool? homme { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public DateTime? dateDeDeces { get; set; }

        public IList<Personne> personnes { get; set; }

        public FormRecherche() { }
        public FormRecherche(string nom)
        {
            Recherche rec = new Recherche();
            rec.nom = nom;
            this.personnes = new FormRecherche(rec).personnes;

        }
        
        public FormRecherche(Recherche rec)
        {
            this.nom = rec.nom;
            this.prenom = rec.prenom;
            this.homme = rec.homme;
            this.dateDeDeces = rec.dateDeDeces;
            this.dateDeNaissance = rec.dateDeNaissance;

            this.personnes = new PersonneServiceAPI().Rechercher(rec)
                .OrderBy(k=>k.nom).ThenBy(k=>k.prenom).ThenBy(k=>k.dateDeNaissance)
                .ToList();
        }
    }
}