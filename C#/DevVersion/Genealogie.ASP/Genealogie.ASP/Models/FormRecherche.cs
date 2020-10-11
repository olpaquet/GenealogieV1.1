using Genealogie.ASP.Services.API;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class FormRecherche
    {
        public int? idCreateurExclu { get; set; }
        public string nom { get; set; }

        [DisplayName("prénom")]
        public string prenom { get; set; }
        public bool? homme { get; set; }
        [DisplayName("date de naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateDeNaissance { get; set; }
        [DisplayName("date de décès")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateDeDeces { get; set; }

        public IList<PersonneIndex> personnes { get; set; }

        public FormRecherche() { }
        public FormRecherche(string nom)
        {
            Recherche rec = new Recherche();
            rec.nom = nom;
            this.personnes = new FormRecherche(rec).personnes;

        }
        
        public FormRecherche(Recherche rec)
        {
            this.nom = rec.nom;
            this.prenom = rec.prenom;
            this.homme = rec.homme;
            this.dateDeDeces = rec.dateDeDeces;
            this.dateDeNaissance = rec.dateDeNaissance;

            this.personnes = new PersonneServiceAPI().Rechercher(rec)
                .Select(j => new PersonneIndex(j,true,true))
                .OrderBy(m => m.nomProprietaire)
                .ThenBy(j => j.nomArbre)
                .ToList();
        }
    }
}