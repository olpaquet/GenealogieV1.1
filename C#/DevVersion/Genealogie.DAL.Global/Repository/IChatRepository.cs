using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IChatRepository<TE>: IAct<TE>
    {
        IEnumerable<TE> Donner();
        TE Donner(int id);
        IEnumerable<TE> Donner(DateTime aPartirDe);
        IEnumerable<TE> Donner(int idUtilisateur, DateTime? aPartirDe = null);
        int Creer(TE e);
    }
}
