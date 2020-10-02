using Genealogie.ASP.Models;
using Genealogie.ASP.Phrases;
using Genealogie.ASP.ServiceGeneral;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Validation
{
    public class MotDePasseConfirmeAttribute : ValidationAttribute
    {
        /*public override bool IsValid(object val)
        {
            RoleService s = new RoleService();
            Role r = s.DonnerParNom((string)val, 3).ToAsp();
            bool b = (s.DonnerParNom((string)val,3).ToAsp() == null);

            return (b);           

        }*/
        
        public MotDePasseConfirmeAttribute()
        {
            ErrorMessage = Phrase.MotDePasseConfirme();
        }

        protected override ValidationResult IsValid(object value, ValidationContext contexteVal)
        {
            bool b = true;
            

            if (!(ExplorationObjet.Existe(contexteVal.ObjectInstance, "motDePasse") || ExplorationObjet.Existe(contexteVal.ObjectInstance, "motDePasseConfirmation"))) b = false;
            if (!b) return new ValidationResult("Grosse erreur");

            string motDePasse = (string)ExplorationObjet.Valeur(contexteVal.ObjectInstance, "motDePasse");
            string motDePasseConfirme = (string)ExplorationObjet.Valeur(contexteVal.ObjectInstance, "motDePasseConfirmation");

            b = motDePasse == motDePasseConfirme;

            if (!b) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;

            /*base.IsValid(value, validationContext);*/

        }
        

        


    }
}