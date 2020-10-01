
using Genealogie.ASP.Services.API;
using Genealogie.ASP.Validation;
using Genealogie.Modeles.API.ASP.Modeles;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Models
{
    public class Arbre : BArbre
    {
        public IEnumerable<Personne> Personnes()
        {  return new PersonneServiceAPI().DonnerPourArbre(this.id);  }
        public int NombreDePersonnes()
        {  return Personnes().Count(); }
        public Blocage Blocage()
        {
            return this.idBlocage == null ? null : new BlocageServiceAPI().Donner((int)this.idBlocage);
        }
        public bool Bloque() {  return this.dateBlocage != null; }
        public Utilisateur Createur() {  return new UtilisateurServiceAPI().Donner(this.idCreateur);  }
        public Utilisateur Bloqueur() {  return (this.idBloqueur==null)?null:new UtilisateurServiceAPI().Donner((int)this.idBloqueur);}
}
    

    public class ArbreIndex
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        [DisplayName("Nombre de personnes dans l'arbre")]
        public int nombreDePersonnes { get; set; }
        [DisplayName("bloqué")]
        public bool bloque { get; set; }

        public string proprietaire { get; set; }
        public string blocage { get; set; }
        public int? idBlocage { get; set; }


        public ArbreIndex() { }
        public ArbreIndex(Arbre e) { this.bloque = e.Bloque(); this.description = e.description; this.nom = e.nom; this.id = e.id; this.nombreDePersonnes = e.NombreDePersonnes(); this.idBlocage = e.idBlocage; }
    }

    public class ArbreCreation
    {
        [Required]
        [MaxLength(50)]
        [NomUnique("Arbre", "nom", "idCreateur", EnumAction.CREER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        public int idCreateur { get; set; }

        public ArbreCreation() { }
        public ArbreCreation(Arbre e) { this.description = e.description; this.nom = e.nom;this.idCreateur = e.idCreateur; }
    }

    public class ArbreModification
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [NomUnique("Arbre", "nom", "idCreateur", EnumAction.MODIFIER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        public int idCreateur { get; set; }
        public ArbreModification() { }
        public ArbreModification(Arbre e) { this.description = e.description; this.nom = e.nom; this.id = e.id; this.idCreateur = e.idCreateur; }
    }

    public class ArbreDetails
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        [DisplayName("créateur")]
        public string createur { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de création")]
        public DateTime dateCreation { get; set; }
        [DisplayName("nombre de personnes dans l'arbre")]
        public int nombreDePersonnes { get; set; }
        [DisplayName("bloqueur")]
        public string bloqueur { get; set; }
        [DisplayName("blocage")]
        public string blocage { get; set; }
        [DisplayName("date de blocage")]
        public DateTime? dateBlocage { get; set; }

        public ArbreDetails() { }
        public ArbreDetails(Arbre e)
        {
            this.description = e.description; this.nom = e.nom; this.id = e.id;
            createur = e.Createur().nomAffichage();
            blocage = (e.idBlocage == null) ? "" :e.Blocage().nom;
            bloqueur = (e.idBloqueur == null) ? "" : e.Bloqueur().nom;
            dateBlocage = e.dateBlocage;
            dateCreation = e.dateCreation;

        }

        
    }
    public class FormBlocageArbre
    {
        
            public int id { get; set; }
            public string blocageChoisi { get; set; }
        public int idBlocage { get; set; }
        //public IList<SelectListItem> blocages { get; set; }
        public IEnumerable<Blocage> blocages { get; set; }



    }
}
