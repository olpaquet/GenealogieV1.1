using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class AbonnementRepository : BaseRepository, IAbonnementRepository<Abonnement>
    {
        private const string CONST_ABONNEMENT_REQ = "select id,nom,description,duree,prix,nombremaxarbres,nombremaxpersonnes,actif from Abonnement";
        public int Creer(Abonnement e)
        {
            Commande com = new Commande("abonnement_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("description", e.description);
            com.AjouterParametre("duree", e.duree);
            com.AjouterParametre("prix", e.prix);
            com.AjouterParametre("nombremaxarbres", e.nombremaxarbres);
            com.AjouterParametre("nombremaxpersonnes", e.nombremaxpersonnes);
            
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        public bool Modifier(int id, Abonnement e)
        {
            Commande com = new Commande("abonnement_mod", true);
            com.AjouterParametre("id", e.id);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("description", e.description);
            com.AjouterParametre("duree", e.duree);
            com.AjouterParametre("prix", e.prix);
            com.AjouterParametre("nombremaxarbres", e.nombremaxarbres);
            com.AjouterParametre("nombremaxpersonnes", e.nombremaxpersonnes);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Supprimer(int id)
        {
            Commande com = new Commande("Abonnement_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Activer(int id)
        {
            Commande com = new Commande("Abonnement_act", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Desactiver(int id)
        {
            Commande com = new Commande("Abonnement_desact", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public IEnumerable<Abonnement> Donner()
        {
            Commande com = new Commande(CONST_ABONNEMENT_REQ);
            return _connexion.ExecuterLecteur(com, x => x.VersAbonnement());
        }
        public Abonnement Donner(int id)
        {
            Commande com = new Commande($"{CONST_ABONNEMENT_REQ} where id=@id");
            com.AjouterParametre("id", id);
            var xx = _connexion.ExecuterLecteur(com, x => x.VersAbonnement()).SingleOrDefault();

            return xx;

        }
        public IEnumerable<Abonnement> Donner(IEnumerable<int> ie, string[] options = null)
        {
            string requete = $"{CONST_ABONNEMENT_REQ} where actif = 1";
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
            return _connexion.ExecuterLecteur(com, j => j.VersAbonnement());
            throw new NotImplementedException();
        }
        public int? DonnerParNom(string nom)
        {
            if (nom == null) return null;
            Commande com = new Commande($"{CONST_ABONNEMENT_REQ} where nom = @nom");
            com.AjouterParametre("nom", nom);
            Abonnement e = _connexion.ExecuterLecteur(com, j => j.VersAbonnement()).SingleOrDefault();
            return (e == null) ? (int?)null : (int?)e.id;
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return false;
            throw new NotImplementedException();
        }
        //throw new NotImplementedException();

    }
}
