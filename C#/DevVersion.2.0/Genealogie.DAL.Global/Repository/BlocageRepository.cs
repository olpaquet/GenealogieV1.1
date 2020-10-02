﻿using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class BlocageRepository : BaseRepository, IBlocageRepository<Blocage>
    {
        private const string CONST_BLOCAGE_REQ = "select id,nom,description,actif from Blocage";
        public int Creer(Blocage e)
        {
            Commande com = new Commande("Blocage_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("description", e.description);
            
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        public bool Modifier(int id, Blocage e)
        {
            Commande com = new Commande("Blocage_mod", true);
            com.AjouterParametre("id", 0);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("description", e.description);
            
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Supprimer(int id)
        {
            Commande com = new Commande("Blocage_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Activer(int id)
        {
            Commande com = new Commande("Blocage_act", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Desactiver(int id)
        {
            Commande com = new Commande("Blocage_desact", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public IEnumerable<Blocage> Donner()
        {
            Commande com = new Commande(CONST_BLOCAGE_REQ);
            return _connexion.ExecuterLecteur(com, x => x.VersBlocage());
        }
        public Blocage Donner(int id)
        {
            Commande com = new Commande($"{CONST_BLOCAGE_REQ} where id=@id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, x => x.VersBlocage()).SingleOrDefault();
        }
        public IEnumerable<Blocage> Donner(IEnumerable<int> ie, string[] options = null)
        {
            string requete = $"{CONST_BLOCAGE_REQ} where actif = 1";
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
            return _connexion.ExecuterLecteur(com, j => j.VersBlocage());
            throw new NotImplementedException();
        }
        public int? DonnerParNom(string nom)
        {
            if (nom == null) return null;
            Commande com = new Commande($"{CONST_BLOCAGE_REQ} where nom = @nom");
            com.AjouterParametre("nom", nom);
            Blocage e = _connexion.ExecuterLecteur(com, j => j.VersBlocage()).SingleOrDefault();
            return (e == null) ? (int?)null : e.id;
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return false;
            throw new NotImplementedException();
        }
        //throw new NotImplementedException();

    }
}
