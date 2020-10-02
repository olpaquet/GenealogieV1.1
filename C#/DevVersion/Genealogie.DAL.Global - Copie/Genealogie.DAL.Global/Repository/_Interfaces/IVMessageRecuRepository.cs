using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IVMessageRecuRepository<TE>
    {
        IEnumerable<TE> DonnerPourDestinataire(int id);
        IEnumerable<TE> DonnerPoubellePourDestinataire(int id);
        IEnumerable<TE> DonnerConversationComplete(int id);
        IEnumerable<TE> Donner(int idConvesation, int idDestinataire);
    }
}
