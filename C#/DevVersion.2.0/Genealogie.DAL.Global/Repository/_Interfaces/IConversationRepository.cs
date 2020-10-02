using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IConversationRepository<TE>: IBase<TE>
    {
        bool Detruire(int id);
        IEnumerable<TE> DonnerParEmetteur(int id);
        

    }
}
