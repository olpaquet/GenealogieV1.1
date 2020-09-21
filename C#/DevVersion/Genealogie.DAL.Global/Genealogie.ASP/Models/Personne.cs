using Genealogie.ASP.Services.API;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public IList<Personne> enfants { get; set; }

        public PersonneIndex() { }
        public PersonneIndex(Personne e)
        {
            this.id = e.id;
            this.homme = e.homme;
            this.dateAjout = e.dateAjout;
            this.dateDeDeces = e.dateDeDeces;
            this.dateDeNaissance = e.dateDeNaissance;
            this.pere = (e.idPere == null) ? null : (new PersonneServiceAPI().DonnerPere(this.id));
            this.mere = (e.idMere == null) ? null : (new PersonneServiceAPI().DonnerMere(this.id));
            this.nom = e.nom;
            this.prenom = e.prenom;
            this.enfants = new PersonneServiceAPI().DonnerEnfants(this.id).ToList();
        }

        public class PersonneCreation
        {
            public int id { get; set; }
            public string nom { get; set; }
            [DisplayName("prénom")]
            public string prenom { get; set; }
            public bool homme { get; set; }
            public DateTime? dateDeNaissance { get; set; }
            public DateTime? dateDeDeces { get; set; }

            public IList<SelectListItem> SLIEnfants { get; set; }
            public IList<SelectListItem> SLIPere { get; set; }
            public IList<SelectListItem> SLIMere { get; set; }

            public PersonneCreation(Personne p)
            {
                
            }
        }

    }


}