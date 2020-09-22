using Genealogie.ASP.Services.API;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        public int idArbre { get; set; }

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
            this.idArbre = e.idArbre;
            this.enfants = new PersonneServiceAPI().DonnerEnfants(this.id).ToList();
        }



    }

    public class PersonneCreation
    {
        public string nom { get; set; }
        [DisplayName("prénom")]
        public string prenom { get; set; }
        public bool homme { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de naissance")]
        public DateTime? dateDeNaissance { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de décès")]
        public DateTime? dateDeDeces { get; set; }

        public int idArbre { get; set; }
        /*public IList<SelectListItem> SLIEnfants { get; set; }
        public IList<SelectListItem> SLIPere { get; set; }
        public IList<SelectListItem> SLIMere { get; set; }*/

        public PersonneCreation() { }
        

    }

    public class PersonneModification
    {
        public string nom { get; set; }
        [DisplayName("prénom")]
        public string prenom { get; set; }
        public bool homme { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de naissance")]
        public DateTime? dateDeNaissance { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de décès")]
        public DateTime? dateDeDeces { get; set; }

        public PersonneModification() { }
        public PersonneModification(Personne e)
        {
            this.dateDeDeces = e.dateDeDeces;
            this.dateDeNaissance = e.dateDeNaissance;
            this.homme = e.homme;
            this.nom = e.nom;
            this.prenom = e.prenom;            
        }
    }
}