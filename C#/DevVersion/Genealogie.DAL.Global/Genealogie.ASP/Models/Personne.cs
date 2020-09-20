using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Personne : BPersonne
    {
    }

    public class PersonneIndex
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        [DisplayName("date de naissance")]
        public DateTime? dateDeNaissance { get; set; }
        [DisplayName("date de décès")]
        public DateTime? dateDeDeces { get; set; }
        public bool homme { get; set; }
        [DisplayName("ajout")]
        public DateTime dateAjout { get; set; }
        public Personne pere { get; set; }
        public Personne mere { get; set; }

        public PersonneIndex() { }
        public PersonneIndex(Personne e)
        {
            this.id = e.id;
            this.homme = e.homme;
            this.dateAjout = e.dateAjout;
            this.dateDeDeces = e.dateDeDeces;
            this.dateDeNaissance = e.dateDeNaissance;
            this.pere = (e.idPere == null) ? (new Personne { nom = "père inconnu",homme=true }) : new Personne { nom = "Papa",homme=true };
            this.mere = (e.idMere == null) ? new Personne { nom = "mère inconnue", homme = false } : new Personne { nom = "Maman", homme = false };
            this.nom = e.nom;
            this.prenom = e.prenom;

        }
    }


}