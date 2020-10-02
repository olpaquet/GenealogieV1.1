using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class NouvelleRepository : BaseRepository, INouvelleRepository<Nouvelle>
    {
        private const string CONST_NOUVELLE_REQ = "select id,titre,description,idcreateur,datecreation, actif from nouvelle";

        public int Creer(Nouvelle e)
        {
            Commande com = new Commande("nouvelle_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("titre", e.titre);
            com.AjouterParametre("description", e.description);
            com.AjouterParametre("idcreateur", e.idcreateur);
            com.AjouterParametre("datecreation", e.datecreation);
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        public bool Modifier(int id, Nouvelle e)
        {
            Commande com = new Commande("nouvelle_mod", true);
            com.AjouterParametre("id", e.id);
            com.AjouterParametre("titre", e.titre);
            com.AjouterParametre("description", e.description);
            com.AjouterParametre("idcreateur", e.idcreateur);
            com.AjouterParametre("datecreation", e.datecreation);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Supprimer(int id)
        {
            Commande com = new Commande("nouvelle_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Activer(int id)
        {
            Commande com = new Commande("nouvelle_act", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Desactiver(int id)
        {
            Commande com = new Commande("nouvelle_desact", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public IEnumerable<Nouvelle> Donner()
        {
            Commande com = new Commande(CONST_NOUVELLE_REQ);
            return _connexion.ExecuterLecteur(com, x => x.VersNouvelle());
        }
        public Nouvelle Donner(int id)
        {
            Commande com = new Commande($"{CONST_NOUVELLE_REQ} where id=@id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, x => x.VersNouvelle()).SingleOrDefault();
        }
        public IEnumerable<Nouvelle> Donner(IEnumerable<int> ie, string[] options = null)
        {
            string requete = $"{CONST_NOUVELLE_REQ} where actif = 1";
            string clause = "";
            int c = 0;
            Dictionary<string, int> dp = new Dictionary<string, int>();
            if (ie != null)
            {
                foreach (int i in ie)
                {
                    c++;
                    clause += clause == "" ? "" : " or ";
                    clause += $"id = @i{c}";
                    dp.Add($"i{c}", i);
                }
            }
            if (c > 0) clause = $"or ({clause})";
            Commande com = new Commande($"{requete} {clause}");
            foreach (KeyValuePair<string, int> k in dp)
            {
                com.AjouterParametre(k.Key, k.Value);
            }
            return _connexion.ExecuterLecteur(com, j => j.VersNouvelle());
            throw new NotImplementedException();
        }
        
        public bool EstUtilisee(int id, string[] options)
        {
            return false;
            throw new NotImplementedException();
        }
        //throw new NotImplementedException();


    }
}
