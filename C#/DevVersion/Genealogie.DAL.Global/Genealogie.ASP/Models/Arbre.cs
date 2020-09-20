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

namespace Genealogie.ASP.Models
{
    public class Arbre : BArbre
    {
        public int nombreDePersonnes { get { return 1; } }
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
        

        public ArbreIndex() { }
        public ArbreIndex(Arbre e) {  this.description = e.description; this.nom = e.nom; this.id = e.id; this.nombreDePersonnes = e.nombreDePersonnes; this.bloque = e.dateBlocage != null; }
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

        public ArbreCreation() { }
        public ArbreCreation(Arbre e) { this.description = e.description; this.nom = e.nom; }
    }

    public class ArbreModification
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [NomUnique("Arbre","nom","idCreateur",EnumAction.MODIFIER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }

        public ArbreModification() { }
        public ArbreModification(Arbre e) { this.description = e.description; this.nom = e.nom; this.id = e.id; }
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
        public ArbreDetails(Arbre e) { this.description = e.description; this.nom = e.nom; this.id = e.id;
            createur = new UtilisateurServiceAPI().Donner(e.idCreateur).nomAffichage();
            blocage = (e.idBlocage==null)?"":new BlocageServiceAPI().Donner((int)e.idBlocage).nom;
            bloqueur = (e.idBloqueur==null)?"":new UtilisateurServiceAPI().Donner((int)e.idBloqueur).nom;
            dateBlocage = e.dateBlocage;
            dateCreation = e.dateCreation;

        }
    }
}