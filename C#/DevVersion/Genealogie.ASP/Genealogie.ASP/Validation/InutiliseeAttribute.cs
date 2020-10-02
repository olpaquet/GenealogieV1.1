using Genealogie.ASP.ServiceGeneral;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Validation
{
    public class InutiliseeAttribute : ValidationAttribute
    {

        private string _modele;
        public InutiliseeAttribute(string modele)
        {
            _modele = modele;
            ErrorMessage = "Cet enregistrement est utilisé. Impossible de le supprimer.";
        }

        protected override ValidationResult IsValid(object value, ValidationContext contexteVal)
        {
            bool b = true;
            Ob ob = new Ob();

            if (ExplorationObjet.Existe(contexteVal.ObjectInstance, "id")) ob.id = (int)ExplorationObjet.Valeur(contexteVal.ObjectInstance, "id");
            else b = false;            

            if (!b) { return new ValidationResult("Kolossale Error :("); }

            switch (_modele) 
            {
                case "Utilisateur":
                    b = !(new UtilisateurServiceAPI().EstUtilisee(ob.id));
                    break;
                case "Role":
                    b = !(new RoleServiceAPI().EstUtilisee(ob.id));
                    break;
                case "Theme":
                    b = !(new ThemeServiceAPI().EstUtilisee(ob.id));
                    break;
                case "Blocage":
                    b = !(new BlocageServiceAPI().EstUtilisee(ob.id));
                    break;
                case "Nouvelle":
                    b = !(new NouvelleServiceAPI().EstUtilisee(ob.id));
                    break;
                /*case "Arbre":
                    b = !(new ArbreServiceAPI().EstUtilisee(ob.id));
                    break;*/
                default:
                    return new ValidationResult("Kolossale Error :(");
                    break;
            }

            
            if (!b) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;

            /*base.IsValid(value, validationContext);*/

        }
        private class Ob
        {
            public int id { get; set; }
        }


    }
}