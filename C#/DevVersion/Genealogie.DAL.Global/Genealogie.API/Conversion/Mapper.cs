using cl=Genealogie.DAL.Client.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genealogie.API.Models;

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
    }
}