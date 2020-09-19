using Genealogie.Modeles.API.ASP.Modeles;
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
        
    }

    public class ArbreIndex
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        [DisplayName("bloqué")]
        public bool bloque { get; set; }
        

        public ArbreIndex() { }
        public ArbreIndex(Arbre e) {  this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    public class ArbreCreation
    {
        [Required]
        [MaxLength(50)]
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
        public int idCreateur { get; set; }
        [DisplayName("blocage")]
        public int? idBlocage { get; set; }
        [DisplayName("bloqueur")]
        public int? idBloqueur { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de création")]
        public DateTime dateCreation { get; set; }
        [DisplayName("bloqué")]
        public bool bloque { get; set; }

        public ArbreDetails() { }
        public ArbreDetails(Arbre e) { this.description = e.description; this.nom = e.nom; this.id = e.id;
            idCreateur = e.idCreateur; idBlocage = e.idBlocage; idBloqueur = e.idBloqueur; dateCreation = e.dateCreation;

        }
    }
}