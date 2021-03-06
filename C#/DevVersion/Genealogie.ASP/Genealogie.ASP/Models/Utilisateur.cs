﻿

using Genealogie.ASP.Phrases;
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
    public class Utilisateur : BUtilisateur
    {        
        public IEnumerable<Role> roles { get { UtilisateurServiceAPI usa = new UtilisateurServiceAPI(); return usa.DonnerRoles(this.id); } }
        public int nombreDeRoles() { return this.roles.Count(); }
        public string nomAffichage() { string pr = this.prenom ?? ""; return $"{pr.Trim()} {this.nom.Trim()}".Trim(); }
        public bool estAdmin() { UtilisateurServiceAPI usa = new UtilisateurServiceAPI(); return usa.EstAdmin(this.id); }
        public int nombreDArbres { get { return new ArbreServiceAPI().DonnerParUtilisateur(this.id).Count(); } }
        public int nombreDePersonnes { get {
                int nb = 0;
                foreach (Arbre a in new ArbreServiceAPI().DonnerParUtilisateur(this.id)) 
                { nb += new PersonneServiceAPI().DonnerPourArbre(a.id).Count(); }
                return nb;
            } }
    }

    public class UtilisateurIndex
    {
        public int id { get; set; }
        
        [DisplayName("identifiant")]
        public string login { get; set; }
        public string nom { get; set; }
        [MaxLength(50)]
        [DisplayName("prénom")]
        public string prenom { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(200)]
        public string email { get; set; }
        public bool actif { get; set; }
        public int nombreDeRoles { get; set; }

        public UtilisateurIndex() { }
        public UtilisateurIndex(Utilisateur e)
        {
            id = e.id; login = e.login; nom = e.nom; prenom = e.prenom; email = e.email;            
            actif = e.actif; nombreDeRoles = e.nombreDeRoles();
        }
    }

    public class UtilisateurDetails
    {
        public int id { get; set; }        
        [DisplayName("identifiant")]
        public string login { get; set; }
        public string nom { get; set; }
        [DisplayName("prénom")]
        public string prenom { get; set; }
        public string email { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? dateDeNaissance { get; set; }
        public bool homme { get; set; }
        [DisplayName("carte de payement")]
        public string cartedepayement { get; set; }
        /*public string PreSel { get; set; }
        public string PostSel { get; set; }*/
        public bool actif { get; set; }

        public IList<SelectListItem> SLIRoles { get; set; }

        public UtilisateurDetails() { }
        public UtilisateurDetails(Utilisateur e)
        {
            id = e.id; login = e.login; nom = e.nom; prenom = e.prenom; email = e.email;
            dateDeNaissance = e.dateDeNaissance; homme = e.homme; cartedepayement = e.cartedepayement;
            actif = e.actif;
        }                
    }

    public class UtilisateurConnexion
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("identifiant")]
        public string login { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [DisplayName("mot de passe")]
        public string motDePasse { get; set; }        
    }

    public class UtilisateurEnregistrement
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("identifiant")]
        public string login { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom { get; set; }
        [MaxLength(50)]
        [DisplayName("prénom")]
        public string prenom { get; set; }
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }
        [DisplayName("date de naissance")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime? dateDeNaissance { get; set; }
        public bool homme { get; set; }
        [MaxLength(50)]
        [DisplayName("carte de payement")]
        public string cartedepayement { get; set; }
        [MaxLength(50)]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("mot de passe")]
        public string motDePasse { get; set; }
        [MaxLength(50)]
        [Required]
        [DataType(DataType.Password)]
        [MotDePasseConfirme]
        [DisplayName("confirmation du mot de passe")]
        public string motDePasseConfirmation { get; set; }

    }

    public class UtilisateurCreation
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [DisplayName("identifiant")]
        [NomUnique("Utilisateur","login","",EnumAction.CREER)]
        public string login { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom { get; set; }
        [MaxLength(50)]
        public string prenom { get; set; }
        [MaxLength(200)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string email { get; set; }
        [DisplayName("date de naissance")]
        [DataType(DataType.Date)]
        public DateTime? dateDeNaissance { get; set; }
        public bool homme { get; set; }
        [MaxLength(50)]
        [DisplayName("carte de payement")]
        public string cartedepayement { get; set; }
        [MaxLength(50)]
        [Required]
        [DataType(DataType.Password)]
        public string motDePasse { get; set; }
        [MaxLength(50)]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("confirmation du mot de passe")]
        [MotDePasseConfirme]
        public string motDePasseConfirmation { get; set; }
        /*public string PreSel { get; set; }
        public string PostSel { get; set; }*/
        public IList<SelectListItem> SLIRoles { get; set; }

    }

    public class UtilisateurModification
    {

        [DisplayName("identifiant")]
        public string login { get; set; }
        [Required]
        [MaxLength(50)]
        public string nom { get; set; }
        [MaxLength(50)]
        public string prenom { get; set; }
        [MaxLength(200)]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayName("date de naissance")]
        public DateTime? dateDeNaissance { get; set; }
        public bool homme { get; set; }
        [MaxLength(50)]
        public string cartedepayement { get; set; }
        public IList<SelectListItem> SLIRoles { get; set; }

        public UtilisateurModification() { }
        public UtilisateurModification(Utilisateur u) 
        {
            this.cartedepayement = u.cartedepayement;
            this.dateDeNaissance = u.dateDeNaissance;
            this.email = u.email;
            this.homme = u.homme;
            this.prenom = u.prenom;
            this.login = u.login;
            this.nom = u.nom;
            
        }

        public class UtilisateurSuppression : UtilisateurDetails
        {
            [Inutilisee("Utilisateur")]
            public UtilisateurSuppression() : base() { }
            public UtilisateurSuppression(Utilisateur u) : base(u) { }
        }
    }

}