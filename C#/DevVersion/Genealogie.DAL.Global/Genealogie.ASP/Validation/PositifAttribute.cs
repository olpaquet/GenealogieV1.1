using Genealogie.ASP.Phrases;
using Genealogie.ASP.ServiceGeneral;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Validation
{
    public class PositifAttribute : ValidationAttribute
    {
        private string _nom;
        private EnumTypeDeDonnee _dt;
        private bool _zero;
        public PositifAttribute(string nom, EnumTypeDeDonnee dt, bool zero = true )
        {
            _nom = nom;
            _zero = zero;
            _dt = dt;
            ErrorMessage = (_zero) ? Phrase.NombrePositif() : Phrase.NombreStrictementPositif();                
        }

        protected override ValidationResult IsValid(object value, ValidationContext contexteVal)
        {
            bool b = true;


            try
            {
                var x = ExplorationObjet.Valeur(contexteVal.ObjectInstance, _nom);

                switch (_dt)
                {
                    case EnumTypeDeDonnee.DECIMAL:
                        b = Sup((decimal)x, _zero);
                        decimal y = (decimal)x;
                        break;
                    case EnumTypeDeDonnee.INT:
                        b = Sup((int)x, _zero);
                        break;
                    default:
                        b = false;
                        ErrorMessage = "Kolossale erreur";
                        break;

                }

            }
            catch (Exception)
            {

                b = false;
            }


            

            if (!b) return new ValidationResult(ErrorMessage);
            return ValidationResult.Success;

            /*base.IsValid(value, validationContext);*/

        }
        private static bool Sup(decimal y, bool zero) { return (zero) ? y >= 0 : y > 0; }
        private static bool Sup(int y, bool zero) { return (zero) ? y >= 0 : y > 0; }
    }
}