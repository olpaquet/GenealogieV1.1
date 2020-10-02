﻿using Genealogie.ASP.Services.API;
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
        public string nomAffichage() { 
            
            { string ret = "";
                ret += (this.nom != null) ? this.nom.Trim() : "";
                ret += "";
                ret += (this.prenom != null) ? this.prenom.Trim() : "";
                ret = ret.Trim();
                string s = "";
                if (this.homme) s = "h";
                else s = "f";
                ret += $" {s}"
                    ;
                ret = ret.Trim();
                return ret;
            } 
        }
        public Personne Pere() {  return this.idPere==null?null:new PersonneServiceAPI().Donner((int)this.idPere);  }
        public Personne Mere() {  return this.idMere == null ? null : new PersonneServiceAPI().Donner((int)this.idMere);  }
        public IEnumerable<Personne> Enfants() {  return new PersonneServiceAPI().DonnerEnfants(this.id);  }
        public Arbre Arbre() {  return new ArbreServiceAPI().Donner(this.idArbre);  }
        public Utilisateur Proprietaire() {  return new UtilisateurServiceAPI().Donner(this.Arbre().idCreateur);  }
    }

    public class PersonneIndex
    {
        public int id { get; set; }
        public string nomAffichage { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        [DisplayName("date de naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateDeNaissance { get; set; }
        [DisplayName("date de décès")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateDeDeces { get; set; }
        public bool homme { get; set; }
        [DisplayName("ajout")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}")]
        [DataType(DataType.DateTime)]
        public DateTime dateAjout { get; set; }
        public PersonneIndex pere { get; set; }
        public PersonneIndex mere { get; set; }
        public IList<PersonneIndex> enfants { get; set; }
        public int idArbre { get; set; }
        public string nomArbre { get; set; }
        public string nomProprietaire { get; set; }

        public PersonneIndex() { }
        public PersonneIndex(Personne e, bool calcul=true)
        
        {
            this.id = e.id;
            this.homme = e.homme;
            this.dateAjout = e.dateAjout;
            this.dateDeDeces = e.dateDeDeces;
            this.dateDeNaissance = e.dateDeNaissance;
            this.pere = e.idPere==null?null:new PersonneIndex( e.Pere(),false);
            this.mere = e.idMere==null?null:new PersonneIndex(e.Mere(),false);
            this.nom = e.nom;
            this.prenom = e.prenom;
            this.idArbre = e.idArbre;

            this.nomAffichage = e.nomAffichage();

            if (calcul)
            {
                this.enfants = e.Enfants()
                .Select(j=>new PersonneIndex(j,false))
                .ToList();

                this.nomArbre = e.Arbre().nom;
                this.nomProprietaire = e.Proprietaire().nomAffichage();
            }
            else
            {
                this.enfants = new List<PersonneIndex>();
                
            }

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
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateDeNaissance { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de décès")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
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

    public class PersonneAjouterEnfant
    {
        public int  id { get; set; }
        public int  idArbre { get; set; }
        [DisplayName("parent")]
        public string Parent { get; set; }
        public int machin { get; set; }

        public IList<SelectListItem> enfants { get; set; }
    }

    public class FormAjouterParent 
    {
        public int idParent { get; set; }
        public int idArbre { get; set; }
        public IList<SelectListItem> parents { get; set; }
    }


}