using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IPersonneRepository<TE>: IBasePersonne<TE>
    {
        IEnumerable<TE> DonnerEnfants(int id);
    }
}
