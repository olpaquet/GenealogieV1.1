using Genealogie.ASP.Validation;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Services;
using System.Web.Mvc;

namespace Genealogie.ASP.Models
{
    public class Blocage : BBlocage{}

    public class BlocageIndex
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }

        public BlocageIndex() { }
        public BlocageIndex(Blocage e) { this.actif = e.actif; this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    public class BlocageCreation
    {
        [Required]
        [MaxLength(50)]
        [NomUnique("Blocage","nom","",EnumAction.CREER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(50)]
        public string description { get; set; }


        public BlocageCreation() { }
        public BlocageCreation(Blocage e) { this.description = e.description; this.nom = e.nom; }
    }

    public class BlocageModification
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [NomUnique("Blocage", "nom","", EnumAction.MODIFIER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(50)]
        public string description { get; set; }


        public BlocageModification() { }
        public BlocageModification(Blocage e) { this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    public class BlocageDetails
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }

        public BlocageDetails() { }
        public BlocageDetails(Blocage e) { this.actif = e.actif; this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    
}