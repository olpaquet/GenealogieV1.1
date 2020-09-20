using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class PersonneRepository : BaseRepository, IPersonneRepository<Personne>
    {
        private const string CONST_PERSONNE_REQ = "select id,nom,prenom,datedenaissance,datededeces,homme,idarbre,dateajout,idpere,idmere from Personne";
        public int Creer(Personne e)
        {
            Commande com = new Commande("Personne_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("prenom", e.prenom);
            com.AjouterParametre("datedenaissance", e.datedenaissance);
            com.AjouterParametre("datededeces", e.datededeces);
            com.AjouterParametre("homme", e.homme);
            com.AjouterParametre("idarbre", e.idarbre);
            com.AjouterParametre("dateajout", e.dateajout);
            com.AjouterParametre("idpere", e.idpere);
            com.AjouterParametre("idmere", e.idmere);
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }

        public IEnumerable<Personne> Donner(int idArbre)
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ} where idArbre = @idArbre");
            com.AjouterParametre("idArbre", idArbre);
            return _connexion.ExecuterLecteur(com, s => s.VersPersonne());
            throw new NotImplementedException();
        }

        public Personne Donner(int idArbre, int idPersonne)
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ} where idArbre = @idArbre and id = @id");
            com.AjouterParametre("idArbre", idArbre);
            com.AjouterParametre("id", idPersonne);
            return _connexion.ExecuterLecteur(com, s => s.VersPersonne()).SingleOrDefault();
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfants(int id)
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ} where idpere = @id or idmere = @id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, f => f.VersPersonne());            
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Personne e)
        {
            Commande com = new Commande("Personne_mod", true);
            com.AjouterParametre("id", e.id);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("prenom", e.prenom);
            com.AjouterParametre("datedenaissance", e.datedenaissance);
            com.AjouterParametre("datededeces", e.datededeces);
            com.AjouterParametre("homme", e.homme);
            com.AjouterParametre("idarbre", e.idarbre);
            com.AjouterParametre("dateajout", e.dateajout);
            com.AjouterParametre("idpere", e.idpere);
            com.AjouterParametre("idmere", e.idmere);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Supprimer(int id)
        {
            Commande com = new Commande("Personne_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
    }
}
