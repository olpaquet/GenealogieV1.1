using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class ConversationRepository : BaseRepository, IConversationRepository<Conversation>
    {
        private const string CONST_CONVERSATION_REQ = "select id,date,sujet,texte,idemetteur,dateeffacement from Conversation";
        public int Creer(Conversation e)
        {
            Commande com = new Commande("Conversation_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("sujet",  e.sujet);
            com.AjouterParametre("texte", e.texte);
            com.AjouterParametre("idemetteur", e.idemetteur);
            
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        public bool Modifier(int id, Conversation e)
        {
            return false;
        }
        public bool Supprimer(int id)
        {
            return false;
        }
        
        public IEnumerable<Conversation> Donner()
        {
            Commande com = new Commande(CONST_CONVERSATION_REQ);
            return _connexion.ExecuterLecteur(com, x => x.VersConversation());
        }
        public Conversation Donner(int id)
        {
            Commande com = new Commande($"{CONST_CONVERSATION_REQ} where id=@id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, x => x.VersConversation()).SingleOrDefault();
        }

        public bool Detruire(int id)
        {
            Commande com = new Commande("Conversation_effacee", true);
            com.AjouterParametre("id", id);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }

        public IEnumerable<Conversation> DonnerParEmetteur(int id)
        {
            Commande com = new Commande($"{CONST_CONVERSATION_REQ} where idemetteur = @id and dateeffacement is null");
            com.AjouterParametre("id", id);
            
            return _connexion.ExecuterLecteur(com, j => j.VersConversation());
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id, string[] options)
        {
            return false;
            throw new NotImplementedException();
        }
    }
}
