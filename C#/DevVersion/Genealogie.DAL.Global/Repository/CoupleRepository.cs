using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class CoupleRepository : BaseRepository, ICoupleRepository<Personne>
    {
        private const string CONST_COUPLE_REQ = "select idpersonne, idpartenaire from couple";
        public bool Creer(int id1, int id2)
        {
            Commande com = new Commande("couple_cre", true);
            com.AjouterParametre("idpersonne", id1);
            com.AjouterParametre("idpartenaire", id2);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }

        public IEnumerable<int> Donner(int id1)
        {
            Commande com = new Commande($"{CONST_COUPLE_REQ} where idpersonne = @id");
            com.AjouterParametre("id", id1);
            return _connexion.ExecuterLecteur(com, j => (int)j["idpartenaire"] );
        }

        public bool EstEnCouple(int id1, int id2)
        {
            Commande com = new Commande($"select count(*) from couple where idpersonne = @idpersonne and idpartenaire = @idpartenaire");
            com.AjouterParametre("idpersonne", id1);
            com.AjouterParametre("idpartenaire", id2);
            return (int)_connexion.ExecuterScalaire(com)>0;
            throw new NotImplementedException();
        }

        public bool Supprimer(int id1, int id2)
        {
            Commande com = new Commande("couple_eff",true);
            com.AjouterParametre("idpersonne", id1);
            com.AjouterParametre("idpartenaire", id2);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }
    }
}
