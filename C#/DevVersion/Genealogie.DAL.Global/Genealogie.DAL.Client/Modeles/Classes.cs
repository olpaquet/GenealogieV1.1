using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Client.Modeles
{
    
    public class Abonnement
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
    public class Arbre
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
    public class Blocage
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
    }

    public class Conversation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
    }
    public class Couple
    {
        public int idPersonne { get; set; }
        public int idPartenaire { get; set; }
        public DateTime dateDebut { get; set; }
        public DateTime? dateFin { get; set; }
    }
    public class Message
    {
        public int Id { get; set; }
        public string Sujet { get; set; }
        public string Texte { get; set; }
        public int IdEmetteur { get; set; }
        public int IdConversation { get; set; }
    }
    public class MessageEfface
    {
        public int IdMessage { get; set; }
        public int IdEffaceur { get; set; }
        public DateTime? Date { get; set; }
    }
    public class MessageForum
    {
        public int Id { get; set; }
        public string Sujet { get; set; }
        public string Texte { get; set; }
        public int IdTheme { get; set; }
        public int IdPublicateur { get; set; }
        public DateTime? DatePublication { get; set; }
        public int Actif { get; set; }
    }
    public class MessageLu
    {
        public int IdMessage { get; set; }
        public int IdLecteur { get; set; }
        public DateTime? Date { get; set; }
    }
    public class Nouvelle
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public DateTime dateCreation { get; set; }
        public int idCreateur { get; set; }
        public bool actif { get; set; }
    }
    public class Personne
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
    public class Role
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
    }
    public class Theme
    {
        public int id { get; set; }
        public string titre { get; set; }
        public string description { get; set; }
        public bool actif { get; set; }
    }
    public class Utilisateur
    {
        public int id { get; set; }
        public string login { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public bool homme { get; set; }
        public string carteDePayement { get; set; }
        public string motDePasse { get; set; }
        /*public string PreSel { get; set; }
        public string PostSel { get; set; }*/
        public bool actif { get; set; }
        public string lRoles { get; set; }
    }
    public class UtilisateurAbonnement
    {
        public int idAbonne { get; set; }
        public int idAbonnement { get; set; }
        public DateTime dateAbonnement { get; set; }
        public string carteDePayement { get; set; }
    }
    public class UtilisateurNouvelle
    {
        public int idPublicateur { get; set; }
        public int idNouvelle { get; set; }
        public DateTime datePublication { get; set; }
    }
    public class UtilisateurRole
    {
        public int idUtilisateur { get; set; }
        public int idrole { get; set; }
    }


    

}
