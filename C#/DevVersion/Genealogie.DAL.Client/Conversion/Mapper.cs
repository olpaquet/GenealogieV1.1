using gl=Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Text;
using Genealogie.DAL.Client.Modeles;

namespace Genealogie.DAL.Client.Conversion
{
    public static class Mapper
    {
        public static Role VersClient(this gl.Role e) { if (e == null) { return null; } return new Role { id = e.id, nom = e.nom, description = e.description, actif = e.actif==1?true:false }; }
        public static gl.Role VersGlobal(this Role e) { if (e == null) { return null; } return new gl.Role {id=e.id,nom=e.nom,description=e.description,actif=e.actif?1:0 }; }

        public static Utilisateur VersClient(this gl.Utilisateur e) { if (e == null) { return null; } return new Utilisateur { id = e.id, actif = e.actif == 1 ? true : false, carteDePayement = e.cartedepayement, dateDeNaissance = e.datedenaissance, email = e.email, homme = e.homme==1?true:false, login = e.login, motDePasse = e.motdepasse, nom = e.nom, /*PostSel = e.postsel,*/ prenom = e.prenom/*, PreSel = e.presel*/, lRoles=e.lroles }; }
        public static gl.Utilisateur VersGlobal(this Utilisateur e) { if (e == null) { return null; } return new gl.Utilisateur { id = e.id, actif = e.actif?1:0, cartedepayement = e.carteDePayement, datedenaissance = e.dateDeNaissance, email = e.email, homme = e.homme?1:0, login = e.login, motdepasse = e.motDePasse, nom = e.nom, /*postsel = e.PostSel,*/ prenom = e.prenom/*, presel = e.PreSel*/, lroles=e.lRoles }; }

        public static UtilisateurRole VersClient(this gl.UtilisateurRole e) { if (e == null) return null; return new UtilisateurRole {idUtilisateur=e.idutilisateur,idrole=e.idrole }; }
        public static gl.UtilisateurRole VersGlobal(this UtilisateurRole e) { if (e == null) return null; return new gl.UtilisateurRole {idutilisateur=e.idUtilisateur,idrole=e.idrole}; }

        public static Arbre VersClient(this gl.Arbre e) { if (e == null) return null; return new Arbre { dateBlocage=e.dateblocage, dateCreation=e.datecreation, description=e.description, id=e.id, idBlocage=e.idblocage, idBloqueur=e.idbloqueur, idCreateur=e.idcreateur, nom=e.nom}; }
        public static gl.Arbre VersGlobal(this Arbre e) { if (e == null) return null; return new gl.Arbre {dateblocage=e.dateBlocage, datecreation=e.dateCreation, description=e.description, id=e.id, idblocage=e.idBlocage, idbloqueur=e.idBloqueur, idcreateur=e.idCreateur, nom=e.nom }; }

        public static Blocage VersClient(this gl.Blocage e) { if (e == null) { return null; } return new Blocage { id = e.id, nom = e.nom, description = e.description, actif = e.actif == 1 ? true : false }; }
        public static gl.Blocage VersGlobal(this Blocage e) { if (e == null) { return null; } return new gl.Blocage { id = e.id, nom = e.nom, description = e.description, actif = e.actif ? 1 : 0 }; }

        public static Chat VersClient(this gl.Chat e) { if (e == null) return null; return new Chat { actif = e.actif==1?true:false, date = e.date, id = e.id, idUtilisateur = e.idutilisateur, message = e.message }; }
        public static gl.Chat VersGlobal(this Chat e) { if (e == null) return null; return new gl.Chat { actif=e.actif?1:0, date=e.date, id=e.id, idutilisateur=e.idUtilisateur, message=e.message }; }
        public static Theme VersClient(this gl.Theme e) { if (e == null) { return null; } return new Theme { id = e.id, description = e.description, titre = e.titre, actif = e.actif == 1 ? true : false }; }
        public static gl.Theme VersGlobal(this Theme e) { if (e == null) { return null; } return new gl.Theme { id = e.id, description = e.description, titre = e.titre, actif = e.actif ? 1 : 0 }; }

        public static Nouvelle VersClient(this gl.Nouvelle e) { if (e == null) { return null; } return new Nouvelle { id = e.id, description = e.description, titre = e.titre, actif = e.actif == 1 ? true : false, dateCreation=e.datecreation, idCreateur=e.idcreateur }; }
        public static gl.Nouvelle VersGlobal(this Nouvelle e) { if (e == null) { return null; } return new gl.Nouvelle { id = e.id, description = e.description, titre = e.titre, actif = e.actif ? 1 : 0, idcreateur=e.idCreateur, datecreation=e.dateCreation }; }

        public static Abonnement VersClient(this gl.Abonnement e) { if (e == null) { return null; } return new Abonnement { id = e.id, actif = e.actif == 1 ? true : false, description=e.description, duree=e.duree, nom=e.nom, nombreMaxArbres=e.nombremaxarbres, nombreMaxPersonnes=e.nombremaxpersonnes, prix=e.prix}; }
        public static gl.Abonnement VersGlobal(this Abonnement e) { if (e == null) { return null; } return new gl.Abonnement { id = e.id, actif = e.actif ? 1 : 0, description=e.description, duree=e.duree, nom=e.nom, nombremaxarbres=e.nombreMaxArbres, nombremaxpersonnes=e.nombreMaxPersonnes, prix=e.prix}; }

        public static Personne VersClient(this gl.Personne e) { if (e == null) { return null; }return new Personne { dateAjout=e.dateajout, dateDeDeces=e.datededeces, dateDeNaissance=e.datedenaissance, homme=(e.homme==1)?true:false, id=e.id, idArbre=e.idarbre, idMere=e.idmere, idPere=e.idpere, nom=e.nom, prenom=e.prenom }; }
        public static gl.Personne VersGlobal(this Personne e) { if (e == null) { return null; }return new gl.Personne { dateajout=e.dateAjout, datededeces=e.dateDeDeces, datedenaissance=e.dateDeNaissance, homme=e.homme?1:0, id=e.id, idarbre=e.idArbre, idmere=e.idMere, idpere=e.idPere, nom=e.nom, prenom=e.prenom}; }

        public static Conversation VersClient(this gl.Conversation e) { if (e == null) { return null; } return new Conversation { date=e.date, dateEffacement=e.dateeffacement, id=e.id, idEmetteur=e.idemetteur, sujet=e.sujet, texte=e.texte}; }
        public static gl.Conversation VersGlobal(this Conversation e) { if (e == null) { return null; } return new gl.Conversation { date = e.date, dateeffacement = e.dateEffacement, id = e.id, idemetteur = e.idEmetteur, sujet = e.sujet, texte = e.texte }; }

        public static VMessageRecu VersClient(this gl.VMessageRecu e) { if (e == null) { return null; } return new VMessageRecu { date=e.date, dateEffacement=e.dateeffacement, dateLecture=e.datelecture, id=e.id, idDestinataire=e.iddestinataire, idEmetteur=e.idemetteur, sujet=e.sujet, texte=e.texte}; }
        public static gl.VMessageRecu VersGlobal(this VMessageRecu e) { if (e == null) { return null; } return new gl.VMessageRecu { date = e.date, dateeffacement = e.dateEffacement, datelecture = e.dateLecture, id = e.id, iddestinataire = e.idDestinataire, idemetteur = e.idEmetteur, sujet = e.sujet, texte = e.texte }; }

        public static MessageDestination VersClient(this gl.MessageDestination e) { if (e == null) { return null; } return new MessageDestination { dateEffacement=e.dateeffacement, dateLecture=e.datelecture, idConversation=e.idconversation, idDestinataire=e.iddestinataire}; }
        public static gl.MessageDestination VersGlobal(this MessageDestination e) { if (e == null) { return null; } return new gl.MessageDestination { dateeffacement = e.dateEffacement, datelecture = e.dateLecture, idconversation = e.idConversation, iddestinataire = e.idDestinataire }; }
    }
}
