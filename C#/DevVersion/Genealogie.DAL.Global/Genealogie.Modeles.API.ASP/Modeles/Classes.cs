using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.Modeles.API.ASP.Modeles
{
    public abstract class BUtilisateur
    {
        public int id { get; set; }
        public string login { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public bool homme { get; set; }
        public string cartedepayement { get; set; }
        public string motDePasse { get; set; }
        /*public string PreSel { get; set; }
        public string PostSel { get; set; }*/
        public bool actif { get; set; }
        public string lRoles { get; set; }
    }

    public abstract class BTheme
    {
        public int id { get; set; }

        public string titre { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
    }

    public abstract class BUtilisateurRole
    {
        public int idUtilisateur { get; set; }
        public int idrole { get; set; }
    }

    public abstract class BRole
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
    }

    public abstract class BArbre
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public int idCreateur { get; set; }
        public DateTime dateCreation { get; set; }
        public int? idBlocage { get; set; }
        public int? idBloqueur { get; set; }
        public DateTime? dateBlocage { get; set; }
    }

    public abstract class BBlocage
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
    }

    public abstract class BPersonne
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public DateTime? dateDeDeces { get; set; }
        public bool homme { get; set; }
        public int idArbre { get; set; }
        public DateTime dateAjout { get; set; }
        public int? idPere { get; set; }
        public int? idMere { get; set; }
    }

    public abstract class BNouvelle
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public int idCreateur { get; set; }
        public DateTime dateCreation { get; set; }
        public bool actif { get; set; }
    }

    public abstract class BAbonnement
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public int duree { get; set; }
        public decimal prix { get; set; }
        public int nombreMaxArbres { get; set; }
        public int nombreMaxPersonnes { get; set; }
        public bool actif { get; set; }
    }

    public abstract class BCouple
    {
        public class Couple
        {
            public int idPersonne { get; set; }
            public int idPartenaire { get; set; }
            public DateTime dateDebut { get; set; }
            public DateTime? dateFin { get; set; }
        }
    }



    /******************/

    public abstract class BChercherPar
    {
        public string chercheString { get; set; }
        public int chercheInt { get; set; }

    }
}
