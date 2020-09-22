using Genealogie.ASP.Models;
using Genealogie.ASP.Phrases;
using Genealogie.ASP.ServiceGeneral;
using Genealogie.ASP.Services.API;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Validation
{
    public class NomUniqueAttribute : ValidationAttribute
    {
        /*public override bool IsValid(object val)
        {
            RoleService s = new RoleService();
            Role r = s.DonnerParNom((string)val, 3).ToAsp();
            bool b = (s.DonnerParNom((string)val,3).ToAsp() == null);

            return (b);           

        }*/
        private EnumAction _action;
        private string _cherche;
        private string _chercheint;
        private string _modele;

        public NomUniqueAttribute(string modele, string cherche, string chercheint, EnumAction action)
        {
            _action = action;
            _modele = modele;
            _cherche = cherche;
            _chercheint = chercheint;
            
            switch (_modele)
            {
                case "Utilisateur":
                    ErrorMessage = Phrase.LoginExiste();

                    break;
                case "Theme":
                    ErrorMessage = Phrase.TitreExiste();
                    break;
                default:
                    ErrorMessage = Phrase.NomExiste();
                    break;                    
            }
            /*ErrorMessage = "Existe déjà...";*/
        }

        protected override ValidationResult IsValid(object value, ValidationContext contexteVal)
        {
            bool b = true;                       
            Ob ob = new Ob();

            ob.lit = (string)ExplorationObjet.Valeur(contexteVal.ObjectInstance, _cherche);


            try
            {
                if (ExplorationObjet.Existe(contexteVal.ObjectInstance, "id")) ob.id = (int?)ExplorationObjet.Valeur(contexteVal.ObjectInstance, "id");
                else ob.id = null;

            }
            catch (Exception)
            {
                return new ValidationResult("Kolossale Error :(");
                throw;
            }

            if (_action == EnumAction.CREER) ob.id = null;

            if (!(_chercheint == "") )
            {
                try
                {
                    if (ExplorationObjet.Existe(contexteVal.ObjectInstance, _chercheint)) ob.litint = (int)ExplorationObjet.Valeur(contexteVal.ObjectInstance, _chercheint);
                    else return new ValidationResult("Kolossale Error :(");
                }
                catch (Exception)
                {
                    return new ValidationResult("Kolossale Error :(");
                    throw;
                }
            }

            switch (_modele)
            {
                case "Utilisateur":
                    ob.res = new UtilisateurServiceAPI().DonnerParNom(ob.lit);
                    break;
                case "Role":
                    ob.res = new RoleServiceAPI().DonnerParNom(ob.lit);
                    break;
                case "Blocage":
                    ob.res = new BlocageServiceAPI().DonnerParNom(ob.lit);
                    break;
                case "Theme":
                    ob.res = new BlocageServiceAPI().DonnerParNom(ob.lit);
                    break;
                case "Abonnement":
                    ob.res = new AbonnementServiceAPI().DonnerParNom(ob.lit);
                    break;
                case "Arbre":
                    ob.res = new ArbreServiceAPI().DonnerParNom(ob.lit, ob.litint);
                    break;
                default:
                    b = false;
                    break;
            }           
            
            if (!b) { return new ValidationResult("Kolossale Error :("); }

            switch (_action)
            {
                case EnumAction.CREER:
                    if (ob.res != null ) b = false;
                    break;
                case EnumAction.MODIFIER:
                    if (!(ob.res == ob.id)) b = false;
                    break;
            }
            if (!b) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;

            /*base.IsValid(value, validationContext);*/

        }
        private class Ob
        {
            public EnumAction action { get; set; }
            public string lit { get; set; }
            public int litint { get; set; }
            public int? id { get; set; }
            public int? res { get; set; }
        }      

        
    }
}