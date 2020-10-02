using Genealogie.ASP.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class NouveauMotDePasse
    {
        public string login { get; set; }
        [Required]
        [MaxLength(50)]
        [DataType(DataType.Password)]
        [DisplayName("ancien mot de passe")]
        public string ancienMotDePasse { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(50)]
        [DisplayName("nouveau mot de passe")]
        public string motDePasse { get; set; }
        [DataType(DataType.Password)]
        [MotDePasseConfirme]
        [DisplayName("confirmation du mot de passe")]
        [Required]
        [MaxLength(50)]        
        public string motDePasseConfirmation { get; set; }
    }
}