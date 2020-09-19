using Genealogie.ASP.Services.API;
using Genealogie.ASP.Validation;
using Genealogie.Modeles.API.ASP.Modeles;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Role : BRole
    {
        public bool EstUtilisee 
        { 
            get 
            {
                RoleServiceAPI rsa = new RoleServiceAPI();
                return rsa.EstUtilisee(this.id);
            }  
        }
    }

    public class RoleIndex
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
        
        public bool EstUtilisee { get; set; }

        public RoleIndex() { }
        public RoleIndex(Role e) { this.actif = e.actif; this.description = e.description; this.nom = e.nom; this.id = e.id; this.EstUtilisee = e.EstUtilisee; }
    }

    public class RoleCreation
    {
        [Required]
        [MaxLength(50)]
        [NomUnique("Role","nom",EnumAction.CREER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        

        public RoleCreation() { }
        public RoleCreation(Role e) {  this.description = e.description; this.nom = e.nom;  }
    }

    public class RoleModification
    {
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        [NomUnique("Role","nom",EnumAction.MODIFIER)]
        public string nom { get; set; }
        [Required]
        [MaxLength(1000)]
        public string description { get; set; }
        

        public RoleModification() { }
        public RoleModification(Role e) { this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    public class RoleDetails
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }

        public RoleDetails() { }
        public RoleDetails(Role e) { this.actif = e.actif; this.description = e.description; this.nom = e.nom; this.id = e.id; }
    }

    
    public class RoleSuppression 
    {
        
        public int id { get; set; }
        [Inutilisee("Role")]
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
        public RoleSuppression() { }
        public RoleSuppression(Role e)  { id = e.id; nom = e.nom; description = e.description; actif = e.actif; }
    }


}