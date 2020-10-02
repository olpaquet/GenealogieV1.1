using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Genealogie.DAL.Global.Repository
{
    public class MessageDestinationRepository : BaseRepository, IMessageDestinationRepository<MessageDestination>
    {
        private const string CONST_MESSAGEDESTINATION_REQ = "select idconversation,iddestinataire,datelecture,dateeffacement from MessageDestination";
        public bool Creer(int idConversation, int idDestinataire, MessageDestination e)
        {
            Commande com = new Commande("messagedestination_cre", true);
            com.AjouterParametre("idconversation", idConversation);
            com.AjouterParametre("iddestinataire", idDestinataire);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }

        public bool Detruire(int idConversation, int idDestinataire)
        {
            Commande com = new Commande("messagedestination_efface", true);
            com.AjouterParametre("idconversation", idConversation);
            com.AjouterParametre("iddestinataire", idDestinataire);
            return _connexion.ExecuterNonRequete(com) >= 0;
            
            throw new NotImplementedException();
        }

        public IEnumerable<MessageDestination> Donner()
        {
            Commande com = new Commande($"{CONST_MESSAGEDESTINATION_REQ}");
            return _connexion.ExecuterLecteur(com, j => j.VersMessageDestination());

            throw new NotImplementedException();
        }

        public MessageDestination Donner(int idConversation, int idDestinataire)
        {
            Commande com = new Commande($"{CONST_MESSAGEDESTINATION_REQ} where idconversation = @idconversation and iddestinataire = @iddestinataire");
            com.AjouterParametre("iddestinataire", idDestinataire);
            com.AjouterParametre("idconversation", idConversation);
            return _connexion.ExecuterLecteur(com, j => j.VersMessageDestination()).SingleOrDefault();
            throw new NotImplementedException();
        }

        public IEnumerable<MessageDestination> DonnerPourConversation(int idConversation)
        {
            Commande com = new Commande($"{CONST_MESSAGEDESTINATION_REQ} where idconversation = @idconversation");
            com.AjouterParametre("idconversation", idConversation);
            return _connexion.ExecuterLecteur(com, k => k.VersMessageDestination());
            throw new NotImplementedException();
        }

        public bool EstLu(int idConversation, int idDestinataire)
        {
            Commande com = new Commande($"select count (*) from ({CONST_MESSAGEDESTINATION_REQ} where idconversation = @idconversation and iddestinataire = @iddestinataire and datelecture is not null) x");
            com.AjouterParametre("idconversation", idConversation);
            com.AjouterParametre("iddestinataire", idDestinataire);
            return (int)_connexion.ExecuterScalaire(com) == 1;            
            throw new NotImplementedException();
        }

        public bool Lire(int idConversation, int idDestinataire)
        {
            Commande com = new Commande("messagedestination_lu",true);
            com.AjouterParametre("idconversation", idConversation);
            com.AjouterParametre("iddestinataire", idDestinataire);
            return _connexion.ExecuterNonRequete(com) >= 0;
            throw new NotImplementedException();
        }

        public bool Modifier(int id1, int id2, MessageDestination e)
        {
            return false;
            throw new NotImplementedException();
        }

        public bool Supprimer(int id1, int id2)
        {
            return false;
            throw new NotImplementedException();
        }
    }
}
