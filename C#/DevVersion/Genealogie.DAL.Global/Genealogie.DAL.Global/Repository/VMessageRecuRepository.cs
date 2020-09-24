using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class VMessageRecuRepository : BaseRepository, IVMessageRecuRepository<VMessageRecu>
    {
        private const string CONST_VMESSAGERECU_REQ = "select id, date, sujet, texte, idemetteur, iddestinataire, datelecture, dateeffacement from VMessageRecu"; 

        public IEnumerable<VMessageRecu> Donner(int idConversation, int idDestinataire)
        {
            Commande com = new Commande($"{CONST_VMESSAGERECU_REQ} where idconversation = @idconversation and iddestinataire = @iddestinataire");
            com.AjouterParametre("idconversation", idConversation);
            com.AjouterParametre("iddestinataire", idDestinataire);
            return _connexion.ExecuterLecteur(com, j => j.VersVMessageRecu());
            throw new NotImplementedException();
        }

        public IEnumerable<VMessageRecu> DonnerPoubellePourDestinataire(int id)
        {
            Commande com = new Commande($"{CONST_VMESSAGERECU_REQ} where iddestinataire = @iddestinataire and datelecture is not null");
            com.AjouterParametre("iddestinataire", id);
            return _connexion.ExecuterLecteur(com, j => j.VersVMessageRecu());
            throw new NotImplementedException();
        }

        public IEnumerable<VMessageRecu> DonnerPourDestinataire(int id)
        {
            Commande com = new Commande($"{CONST_VMESSAGERECU_REQ} where iddestinataire = @iddestinataire and datelecture is null");
            com.AjouterParametre("iddestinataire", id);
            return _connexion.ExecuterLecteur(com, j => j.VersVMessageRecu());
            throw new NotImplementedException();
            throw new NotImplementedException();
        }
    }
}
