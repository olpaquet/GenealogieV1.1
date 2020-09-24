using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IArbreRepository<TE,TVar2, TBl> : IBase<TE>, IAct<TE>, IParNom2<TVar2>
    {
        IEnumerable<TE> DonnerParUtilisateur(int idutilisateur);
        bool Bloquer(TBl e);
        bool Debloquer(int id);
    }
}
