using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Theme : BTheme
    {        
    }

    public class ThemeIndex
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string titre { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        public bool actif { get; set; }

        public ThemeIndex() { }
        public ThemeIndex(Theme e) { this.actif = e.actif; this.description = e.description; this.titre = e.titre; this.id = e.id; }
    }

    public class ThemeCreation
    {
        [Required]
        [MaxLength(50)]
        public string titre { get; set; }
        [Required]
        [MaxLength(100)]
        public string description { get; set; }


        public ThemeCreation() { }
        public ThemeCreation(Theme e) { this.description = e.description; this.titre = e.titre; }
    }

    public class ThemeModification
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string titre { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }


        public ThemeModification() { }
        public ThemeModification(Theme e) { this.description = e.description; this.titre = e.titre; this.id = e.id; }
    }

    public class ThemeDetails
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }

        public ThemeDetails() { }
        public ThemeDetails(Theme e) { this.actif = e.actif; this.description = e.description; this.titre = e.titre; this.id = e.id; }
    }


}