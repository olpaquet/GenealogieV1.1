using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class ArbreRepository : BaseRepository, IArbreRepository<Arbre, int, BlocageArbre>
    {
        private const string CONST_ARBRE_REQ = "select id,nom,description,idcreateur,datecreation,idblocage,idbloqueur,dateblocage from Arbre";
        public int Creer(Arbre e)
        {
            Commande com = new Commande("Arbre_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("description", e.description);
            com.AjouterParametre("idcreateur", e.idcreateur);
            com.AjouterParametre("datecreation", DateTime.Now);
            
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        public bool Modifier(int id, Arbre e)
        {
            Commande com = new Commande("Arbre_mod", true);
            com.AjouterParametre("id", id);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("description", e.description);            
            
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Supprimer(int id)
        {
            Commande com = new Commande("Arbre_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Activer(int id)
        {
            Commande com = new Commande("Arbre_act", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Desactiver(int id)
        {
            Commande com = new Commande("Arbre_desact", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public IEnumerable<Arbre> Donner()
        {
            Commande com = new Commande(CONST_ARBRE_REQ);
            return _connexion.ExecuterLecteur(com, x => x.VersArbre());
        }
        public Arbre Donner(int id)
        {
            Commande com = new Commande($"{CONST_ARBRE_REQ} where id=@id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, x => x.VersArbre()).SingleOrDefault();
        }
        public IEnumerable<Arbre> Donner(IEnumerable<int> ie, string[] options = null)
        {
            string requete = $"{CONST_ARBRE_REQ} where actif = 1";
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
            return _connexion.ExecuterLecteur(com, j => j.VersArbre());
            throw new NotImplementedException();
        }
        public int? DonnerParNom(string nom, int idcreateur)
        {
            if (nom == null) return null;
            Commande com = new Commande($"{CONST_ARBRE_REQ} where nom = @nom and idcreateur = @idcreateur");
            com.AjouterParametre("nom", nom);
            com.AjouterParametre("idcreateur", idcreateur);
            Arbre e = _connexion.ExecuterLecteur(com, j => j.VersArbre()).SingleOrDefault();
            return (e == null) ? (int?)null : (int?)e.id;
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return false;
            throw new NotImplementedException();
        }

        public IEnumerable<Arbre> DonnerParUtilisateur(int idutilisateur)
        {
            Commande com = new Commande($"{CONST_ARBRE_REQ} where idcreateur = @idcreateur");
            com.AjouterParametre("idcreateur", idutilisateur);
            return _connexion.ExecuterLecteur(com, j => j.VersArbre());
            throw new NotImplementedException();
        }

        public bool Debloquer(int id)
        {
            Commande com = new Commande("arbre_debloquer", true);
            com.AjouterParametre("id", id);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }

        public bool Bloquer(BlocageArbre e)
        {
            Commande com = new Commande("arbre_bloquer", true);
            com.AjouterParametre("id", e.id);
            com.AjouterParametre("idbloqueur", e.idBloqueur);
            com.AjouterParametre("idblocage", e.idBlocage);
            com.AjouterParametre("dateblocage", DateTime.Now);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }
        //throw new NotImplementedException();
        //throw new NotImplementedException();

    }
}
