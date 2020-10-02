using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IMessageDestinationRepository<TE>:IBase2<TE>
    {
        bool Detruire(int idConversation, int idDestinataire);
        bool Lire(int idConversation, int idDestinataire);
        IEnumerable<TE> DonnerPourConversation(int idConversation);
        bool EstLu(int idConversation, int idDestinataire);
    }
}
