using Genealogie.ASP.Services.API;
using Genealogie.ASP.Validation;
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
    public class Nouvelle : BNouvelle
    {
    }

    public class NouvelleIndex
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string titre { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        [DisplayName("Editeur")]
        public string createur { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("publication")]
        public DateTime dateCreation { get; set; }
        public bool actif { get; set; }

        public NouvelleIndex() { }
        public NouvelleIndex(Nouvelle e) { 
            this.actif = e.actif; this.description = e.description; this.titre = e.titre; this.id = e.id;
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            this.createur = usa.Donner(e.idCreateur).nomAffichage();
            this.dateCreation = e.dateCreation;
        
        }
    }

    public class NouvelleCreation
    {
        [Required]
        [MaxLength(50)]
        public string titre { get; set; }
        /*[Required]*/
        /*[MaxLength(100)]*/
        public int idCreateur { get; set; }
        public DateTime dateCreation { get; set; }
        [MaxLength(1000)]
        public string description { get; set; }

        public NouvelleCreation() { }
        public NouvelleCreation(Nouvelle e) { this.description = e.description; this.titre = e.titre; this.dateCreation = e.dateCreation; this.idCreateur = e.idCreateur; }
    }    
    

    public class NouvelleDetails
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }       

        public NouvelleDetails() { }
        public NouvelleDetails(Nouvelle e) {  this.description = e.description; this.titre = e.titre; this.id = e.id; }
    }
}