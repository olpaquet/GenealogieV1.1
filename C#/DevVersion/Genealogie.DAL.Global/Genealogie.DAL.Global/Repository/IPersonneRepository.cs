using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IPersonneRepository<TE,RE>: IBasePersonne<TE>
    {
        IEnumerable<TE> Rechercher(RE e);
    }
}
