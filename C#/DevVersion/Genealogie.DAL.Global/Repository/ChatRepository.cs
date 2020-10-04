using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class ChatRepository : BaseRepository, IChatRepository<Chat>
    {
        private const string CONST_Chat_REQ = "select id,idutilisateur,message,date,actif from Chat";
        public int Creer(Chat e)
        {
            Commande com = new Commande("Chat_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("idutilisateur", e.idutilisateur);
            com.AjouterParametre("message", e.message);
            com.AjouterParametre("date", e.date);
            com.AjouterParametre("actif", e.actif);
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        /*public bool Modifier(int id, Chat e)
        {
            Commande com = new Commande("Chat_mod", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("idutilisateur", e.idutilisateur);
            com.AjouterParametre("message", e.message);
            com.AjouterParametre("date", e.date);
            com.AjouterParametre("actif", e.actif); ...
return (int)_connexion.ExecuterNonRequete(com) > 0;
        }*/
        /*public bool Supprimer(int id)
        {
            Commande com = new Commande("Chat_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }*/
        public bool Activer(int id)
        {
            Commande com = new Commande("Chat_act", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public bool Desactiver(int id)
        {
            Commande com = new Commande("Chat_desact", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        public IEnumerable<Chat> Donner()
        {
            Commande com = new Commande(CONST_Chat_REQ);
            return _connexion.ExecuterLecteur(com, x => x.VersChat());
        }
        public Chat Donner(int id)
        {
            Commande com = new Commande($"{CONST_Chat_REQ} where id=@id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, x => x.VersChat()).SingleOrDefault();
        }

        public IEnumerable<Chat> Donner(DateTime aPartirDe)
        {
            Commande com = new Commande($"{CONST_Chat_REQ} where date >= @date");
            com.AjouterParametre("date", aPartirDe);
            return _connexion.ExecuterLecteur(com, x => x.VersChat());
            throw new NotImplementedException();
        }

        public IEnumerable<Chat> Donner(int idUtilisateur, DateTime? aPartirDe = null)
        {
            string sqlRequete = $"{CONST_Chat_REQ} where id = @id";
            if (aPartirDe != null) sqlRequete += " and date >= @date";

            Commande com = new Commande(sqlRequete);
            com.AjouterParametre("id", idUtilisateur);
            if (aPartirDe != null) com.AjouterParametre("date", aPartirDe);

            return _connexion.ExecuterLecteur(com, x => x.VersChat());
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        /*inutile*/
        public IEnumerable<Chat> Donner(IEnumerable<int> ie, string[] options = null)
        {
           string requete = $"{CONST_Chat_REQ} where actif = 1";
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
           return _connexion.ExecuterLecteur(com, j => j.VersChat());
           throw new NotImplementedException();
        }


    }
}
