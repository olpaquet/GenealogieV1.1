using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IPersonneRepository<TE,RE,TEE>: IBasePersonne<TE>
    {
        IEnumerable<TE> Rechercher(RE e);

        IEnumerable<TE> DonnerEnfants(int idPere, int idMere);
        IEnumerable<TE> DonnerEnfantsSansMere(int idPere);
        IEnumerable<TE> DonnerEnfantsSansPere(int idMere);
        IEnumerable<TE> DonnerEnfantsSurs(int id, bool pere);
        IEnumerable<TEE> DonnerLesEnfants(int id);
    }
}
