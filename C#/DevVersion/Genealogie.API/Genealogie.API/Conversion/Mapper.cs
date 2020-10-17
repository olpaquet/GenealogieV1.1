using cl=Genealogie.DAL.Client.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genealogie.API.Models;
using System.Runtime.CompilerServices;

namespace Genealogie.API.Conversion
{
    public static class Mapper
    {
        public static Utilisateur VersAPI(this cl.Utilisateur e) { if (e == null) { return null; } return new Utilisateur { id = e.id, actif = e.actif, cartedepayement = e.carteDePayement, dateDeNaissance = e.dateDeNaissance, email = e.email, homme = e.homme, login = e.login, motDePasse = e.motDePasse, nom = e.nom, /*PostSel = e.postsel,*/ prenom = e.prenom/*, PreSel = e.presel*/, lRoles=e.lRoles }; }
        public static cl.Utilisateur VersClient(this Utilisateur e) { if (e == null) { return null; } return new cl.Utilisateur { id = e.id, actif = e.actif, carteDePayement = e.cartedepayement, dateDeNaissance = e.dateDeNaissance, email = e.email, homme = e.homme, login = e.login, motDePasse = e.motDePasse, nom = e.nom, /*postsel = e.PostSel,*/ prenom = e.prenom/*, presel = e.PreSel*/, lRoles=e.lRoles }; }

        public static Role VersAPI(this cl.Role e) { if (e == null) return null; return new Role {id=e.id, actif=e.actif, description=e.description, nom=e.nom }; }
        public static cl.Role VersClient(this Role e) { if (e == null) return null; return new cl.Role { id = e.id, actif = e.actif, description = e.description, nom = e.nom }; }

        public static Blocage VersAPI(this cl.Blocage e) { if(e==null) { return null; } return new Blocage { actif=e.actif, description=e.description, id=e.id, nom=e.nom }; }
        public static cl.Blocage VersClient(this Blocage e) { if (e == null) { return null; } return new cl.Blocage { actif = e.actif, description = e.description, id = e.id, nom = e.nom }; }

        public static Theme VersAPI(this cl.Theme e) { if (e == null) { return null; } return new Theme { actif = e.actif, description = e.description, id = e.id, titre = e.titre }; }
        public static cl.Theme VersClient(this Theme e) { if (e == null) { return null; } return new cl.Theme { actif = e.actif, description = e.description, id = e.id, titre = e.titre }; }

        public static Nouvelle VersAPI(this cl.Nouvelle e) { if (e == null) { return null; } return new Nouvelle { actif = e.actif, description = e.description, id = e.id, titre = e.titre, dateCreation=e.dateCreation, idCreateur=e.idCreateur }; }
        public static cl.Nouvelle VersClient(this Nouvelle e) { if (e == null) { return null; } return new cl.Nouvelle { actif = e.actif, description = e.description, id = e.id, titre = e.titre, dateCreation=e.dateCreation, idCreateur=e.idCreateur }; }

        public static Abonnement VersAPI(this cl.Abonnement e) { if (e == null) { return null; } return new Abonnement { actif = e.actif, description = e.description, id = e.id, nom = e.nom, duree=e.duree,  nombreMaxArbres=e.nombreMaxArbres, nombreMaxPersonnes=e.nombreMaxPersonnes, prix=e.prix }; }
        public static cl.Abonnement VersClient(this Abonnement e) { if (e == null) { return null; } return new cl.Abonnement { actif = e.actif, description = e.description, id = e.id, nom = e.nom, duree = e.duree, nombreMaxArbres = e.nombreMaxArbres, nombreMaxPersonnes = e.nombreMaxPersonnes, prix = e.prix }; }

        public static Arbre VersAPI(this cl.Arbre e) { if (e == null) { return null; } return new Arbre { dateBlocage = e.dateBlocage, dateCreation=e.dateCreation, description=e.description, id=e.id, idBlocage=e.idBlocage, idBloqueur=e.idBloqueur, idCreateur=e.idCreateur, nom=e.nom }; }
        public static cl.Arbre VersClient(this Arbre e) { if (e == null) { return null; } return new cl.Arbre { dateBlocage = e.dateBlocage, dateCreation = e.dateCreation, description = e.description, id = e.id, idBlocage = e.idBlocage, idBloqueur = e.idBloqueur, idCreateur = e.idCreateur, nom = e.nom }; }

        public static Personne VersAPI(this cl.Personne e) { if (e == null) { return null; }return new Personne { dateDeNaissance=e.dateDeNaissance, dateAjout=e.dateAjout, dateDeDeces=e.dateDeDeces, homme=e.homme, id=e.id, idArbre=e.idArbre, idMere=e.idMere, idPere=e.idPere, nom=e.nom, prenom=e.prenom  }; }
        public static cl.Personne VersClient(this Personne e){ if (e == null) { return null; } return new cl.Personne { dateDeNaissance = e.dateDeNaissance, dateAjout = e.dateAjout, dateDeDeces = e.dateDeDeces, homme = e.homme, id = e.id, idArbre = e.idArbre, idMere = e.idMere, idPere = e.idPere, nom = e.nom, prenom = e.prenom }; }


        public static MessageDestination VersAPI(this cl.MessageDestination e) { if (e == null) { return null; } return new MessageDestination { dateEffacement=e.dateEffacement, dateLecture=e.dateLecture, idConversation=e.idConversation, idDestinataire=e.idDestinataire  }; }
        public static cl.MessageDestination VersClient(this MessageDestination e) { if (e == null) { return null; } return new cl.MessageDestination { dateEffacement = e.dateEffacement, dateLecture = e.dateLecture, idConversation = e.idConversation, idDestinataire = e.idDestinataire }; }

        public static Conversation VersAPI(this cl.Conversation e) { if (e == null) { return null; } return new Conversation { date=e.date, dateEffacement=e.dateEffacement, id=e.id, idEmetteur=e.idEmetteur, sujet=e.sujet, texte=e.texte}; }
        public static cl.Conversation VersClient(this Conversation e) { if (e == null) { return null; } return new cl.Conversation { date = e.date, dateEffacement = e.dateEffacement, id = e.id, idEmetteur = e.idEmetteur, sujet = e.sujet, texte = e.texte }; }

        public static VMessageRecu VersAPI(this cl.VMessageRecu e) { if (e == null) { return null; } return new VMessageRecu { date=e.date, dateEffacement=e.date, dateLecture=e.dateLecture, id=e.id, idDestinataire=e.idDestinataire, idEmetteur=e.idEmetteur, sujet=e.sujet, texte=e.texte}; }
        public static cl.VMessageRecu VersClient(this VMessageRecu e) { if (e == null) { return null; } return new cl.VMessageRecu { date = e.date, dateEffacement = e.date, dateLecture = e.dateLecture, id = e.id, idDestinataire = e.idDestinataire, idEmetteur = e.idEmetteur, sujet = e.sujet, texte = e.texte }; }


        public static cl.Chat VersClient(this Chat e) { if (e == null) return null; return new cl.Chat { date=e.date, id=e.id, idUtilisateur=e.idEmetteur, message=e.message, actif=e.actif }; }

        public static Chat VersAPI(this cl.Chat e) { if (e == null) return null; return new Chat { date = e.date, id = e.id, idEmetteur=e.idUtilisateur, message = e.message, actif = e.actif }; }
        /*public static MessageDestination VersAPI(this cl.MessageDestination e) { if (e == null) { return null; } return new MessageDestination { dateEffacement=e.dateEffacement, dateLecture=e.dateLecture, idConversation=e.idConversation, idDestinataire=e.idDestinataire}; }
        public static cl.MessageDestination VersClient(this MessageDestination e) { if (e == null) { return null; } return new cl.MessageDestination { dateEffacement = e.dateEffacement, dateLecture = e.dateLecture, idConversation = e.idConversation, idDestinataire = e.idDestinataire }; }*/

        public static Descendant VersAPI(this cl.Descendant e) { if (e == null) return null; return new Descendant { enfant=e.enfant.VersAPI(), parent=e.parent.VersAPI(), id=e.id }; }
    }
}