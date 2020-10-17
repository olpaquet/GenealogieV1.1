using Genealogie.ASP.Models;
using Genealogie.ASP.Services;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Conversion
{

    

    public static class Mapper
    {

        public static IList<string> VersFiche(this Personne p) { return ServPersonne.Fiche(p); }
        public static string VersNomPrenom(this Personne p)
        {
            return $"nom:{p.nom} prénom:{p.prenom}";
        }

        public static string VersAffichage(this Personne p)
        {
            string ret = "";
            string sexe = (p.homme) ? "homme" : "femme";

            ret = $"nom:{p.nom} prénom:{p.prenom} ({sexe})";
            string ddn = String.Format("{0:dd/MM/yyyy}", p.dateDeNaissance);
            string ddd = String.Format("{0:dd/MM/yyyy}", p.dateDeDeces);
            ret += $"\nné:{ddn} => mort:{ddd}";
            if (p.idPere != null) ret += $"Père:{new PersonneServiceAPI().Donner((int)p.idPere).VersNomPrenom()}";
            if (p.idMere != null) ret += $"Mère:{new PersonneServiceAPI().Donner((int)p.idMere).VersNomPrenom()}";
            
            return ret;
        }

        public static string VersListePypee(this IEnumerable<int> e) { if (e == null) { return null; }
            int compteur = 0;
            string ret = "";
            foreach (int i in e) { compteur++; ret = ret + (compteur != 1 ? "," : "") + i.ToString(); }
            return (ret == "") ? null : ret;

        }

        public static string VersSexe(this bool e) { return e ? "homme" : "femme"; }


        public static Utilisateur VersUtilisateur(this UtilisateurCreation e) { if (e == null) { return null; } return new Utilisateur { cartedepayement = e.cartedepayement, dateDeNaissance = e.dateDeNaissance, email = e.email, homme = e.homme, login = e.login, motDePasse = e.motDePasse, nom = e.nom, prenom = e.prenom }; }
        public static Utilisateur VersUtilisateur(this UtilisateurModification e) { if (e == null) { return null; } return new Utilisateur { cartedepayement = e.cartedepayement, dateDeNaissance = e.dateDeNaissance, email = e.email, homme = e.homme, login = e.login, nom = e.nom, prenom = e.prenom }; }
        /*public static Utilisateur VersUtilisateur(this UtilisateurDetails e) { if (e == null) { return null; } return new Utilisateur { actif=e.actif, cartedepayement=e.cartedepayement, dateDeNaissance=e.dateDeNaissance, email=e.email, homme=e.homme, id=e.id, login=e.login, nom=e.nom, prenom=e.prenom }; }*/
        public static Utilisateur VersUtilisateur(this UtilisateurEnregistrement e) { if (e == null) { return null; } return new Utilisateur { dateDeNaissance = e.dateDeNaissance, cartedepayement = e.cartedepayement, email = e.email, homme = e.homme, login = e.login, motDePasse = e.motDePasse, nom = e.nom, prenom = e.prenom }; }

        public static UtilisateurModification VersUtilisateurModification(this Utilisateur e) { if (e == null) { return null; } return new UtilisateurModification(e); }
        public static UtilisateurDetails VersUtilisateurDetails(this Utilisateur e) { if (e == null) { return null; } return new UtilisateurDetails { actif = e.actif, cartedepayement = e.cartedepayement, dateDeNaissance = e.dateDeNaissance, email = e.email, homme = e.homme, id = e.id, login = e.login, nom = e.nom, prenom = e.prenom }; }


        /*Role*/
        public static Role VersRole(this RoleCreation e) { if (e == null) { return null; } return new Role { description = e.description, nom = e.nom }; }
        public static Role VersRole(this RoleModification e) { if (e == null) { return null; } return new Role { id = e.id, description = e.description, nom = e.nom }; }
        /*public static Role VersRole(this RoleDetails e) { if (e == null) { return null; } return new Role { id=e.id, actif = e.actif, description = e.description, nom = e.nom }; }*/

        /*Blocage*/
        public static Blocage VersBlocage(this BlocageCreation e) { if (e == null) { return null; } return new Blocage { description = e.description, nom = e.nom }; }
        public static Blocage VersBlocage(this BlocageModification e) { if (e == null) { return null; } return new Blocage { id = e.id, description = e.description, nom = e.nom }; }
        public static Blocage VersBlocage(this BlocageDetails e) { if (e == null) { return null; } return new Blocage { id = e.id, actif = e.actif, description = e.description, nom = e.nom }; }

        /*Theme*/
        public static Theme VersTheme(this ThemeCreation e) { if (e == null) { return null; } return new Theme { description = e.description, titre = e.titre }; }
        public static Theme VersTheme(this ThemeModification e) { if (e == null) { return null; } return new Theme { id = e.id, description = e.description, titre = e.titre }; }
        public static Theme VersTheme(this ThemeDetails e) { if (e == null) { return null; } return new Theme { id = e.id, actif = e.actif, description = e.description, titre = e.titre }; }

        /*Nouvelle*/
        public static Nouvelle VersNouvelle(this NouvelleCreation e) { if (e == null) { return null; } return new Nouvelle { dateCreation = e.dateCreation, description = e.description, titre = e.titre, idCreateur = e.idCreateur }; }
        public static Nouvelle VersNouvelle(this NouvelleDetails e) { if (e == null) { return null; } return new Nouvelle { titre = e.titre, id = e.id, description = e.description }; }


        /*Abonnement*/
        public static Abonnement VersAbonnement(this AbonnementCreation e) { if (e == null) { return null; } return new Abonnement { description = e.description, nom = e.nom, prix = e.prix, nombreMaxPersonnes = e.nombreMaxPersonnes, nombreMaxArbres = e.nombreMaxArbres }; }
        public static Abonnement VersAbonnement(this AbonnementModification e) { if (e == null) { return null; } return new Abonnement { id = e.id, description = e.description, nom = e.nom, duree = e.duree, nombreMaxArbres = e.nombreMaxArbres, nombreMaxPersonnes = e.nombreMaxPersonnes, prix = e.prix }; }
        /*public static Abonnement VersAbonnement(this AbonnementDetails e) { if (e == null) { return null; } return new Abonnement { id = e.id, actif = e.actif, description = e.description, nom = e.nom, duree=e.duree, nombreMaxPersonnes=e.nombreMaxPersonnes, nombreMaxArbres=e.nombreMaxArbres, prix=e.prix }; }*/

        /*Arbre*/
        public static Arbre VersArbre(this ArbreCreation e)
        { if (e == null) { return null; } return new Arbre { nom = e.nom, description = e.description }; }
        public static Arbre VersArbre(this ArbreModification e)
        { if (e == null) { return null; } return new Arbre { id = e.id, nom = e.nom, description = e.description }; }
        /*public static Arbre VersArbre(this ArbreDetails e)
        {if (e == null) { return null; }return new Arbre{id = e.id,nom = e.nom,description = e.description};}*/

        /*Personne*/
        public static Personne VersPersonne(this PersonneCreation e) { if (e == null) { return null; }return new Personne {
            dateDeDeces = e.dateDeDeces, homme = e.homme, idArbre = e.idArbre, dateDeNaissance = e.dateDeNaissance, nom = e.nom, prenom = e.prenom,
            dateAjout = DateTime.Now
        }; }
        public static Personne VersPersonne(this PersonneModification e) { if (e == null) { return null; } return new Personne
        {
            dateDeDeces = e.dateDeDeces,
            dateDeNaissance = e.dateDeNaissance,
            homme=e.homme,
            nom = e.nom,
            prenom = e.prenom
        };  
        }



        /*Message*/
        public static Conversation VersConversation(this MessageCreation e) { if (e == null) { return null; } return new Conversation { date = DateTime.Now, idEmetteur = e.idEmetteur, sujet = e.sujet, texte = e.texte } ; }
    }
}