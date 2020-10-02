using Genealogie.ASP.Validation;
using Genealogie.Modeles.API.ASP.Modeles;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Abonnement : BAbonnement 
    {

    }
    /*
     * public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public int duree { get; set; }
        public decimal prix { get; set; }
        public int nombreMaxArbres { get; set; }
        public int nombreMaxPersonnes { get; set; }
        public bool actif { get; set; }
        */

    public class AbonnementIndex
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }

        public AbonnementIndex() { }
        public AbonnementIndex(Abonnement e) { this.actif = e.actif; this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    public class AbonnementCreation
    {
        [Required]
        [MaxLength(50)]
        [NomUnique("Abonnement", "nom","", EnumAction.CREER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        [DisplayName("durée (jours)*")]
        [Positif("duree", EnumTypeDeDonnee.INT, true)]
        public int duree { get; set; }
        [Positif("prix", EnumTypeDeDonnee.DECIMAL, true)]
        public decimal prix { get; set; }
        [Positif("nombreMaxArbres", EnumTypeDeDonnee.INT, true)]
        [DisplayName("Nombre maximal d'arbres*")]
        public int nombreMaxArbres { get; set; }
        [Positif("nombreMaxPersonnes", EnumTypeDeDonnee.INT, true)]
        [DisplayName("Nombre maximal de personnes*")]
        public int nombreMaxPersonnes { get; set; }


        public AbonnementCreation() { }
        public AbonnementCreation(Abonnement e) { this.description = e.description; this.nom = e.nom; this.prix = e.prix; }
    }

    public class AbonnementModification
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [NomUnique("Abonnement", "nom", "",EnumAction.MODIFIER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        [Positif("duree", EnumTypeDeDonnee.INT, true)]
        [DisplayName("durée (jours)*")]
        public int duree { get; set; }
        [Positif("prix", EnumTypeDeDonnee.DECIMAL, true)]
        public decimal prix { get; set; }
        [Positif("nombreMaxArbres", EnumTypeDeDonnee.INT, true)]
        [DisplayName("Nombre maximal d'arbres*")]
        public int nombreMaxArbres { get; set; }
        [Positif("nombreMaxPersonnes", EnumTypeDeDonnee.INT, true)]
        [DisplayName("Nombre maximal de personnes")]
        public int nombreMaxPersonnes { get; set; }
        
        public AbonnementModification() { }
        public AbonnementModification(Abonnement e)
        {
            
            id = e.id; nom = e.nom; description = e.description; duree = e.duree; 
            prix = e.prix;
            nombreMaxArbres = e.nombreMaxArbres; nombreMaxPersonnes = e.nombreMaxPersonnes; 
        }
    }

    public class AbonnementDetails
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        [DisplayName("durée")]
        public int duree { get; set; }
        public decimal prix { get; set; }
        [DisplayName("Nombre maximal d'arbres")]
        public int nombreMaxArbres { get; set; }
        [DisplayName("Nombre maximal de personnes")]
        public int nombreMaxPersonnes { get; set; }
        public bool actif { get; set; }
        

        public AbonnementDetails() { }
        public AbonnementDetails(Abonnement e) 
        { 
            id = e.id; nom = e.nom; description = e.description; duree = e.duree; prix = e.prix;
            nombreMaxArbres = e.nombreMaxArbres; nombreMaxPersonnes = e.nombreMaxPersonnes; actif = e.actif;
        }
    }
}