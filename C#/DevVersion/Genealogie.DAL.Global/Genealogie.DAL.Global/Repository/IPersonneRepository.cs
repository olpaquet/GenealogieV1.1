using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IPersonneRepository<TE,RE>: IBase<TE>
    {
        IEnumerable<TE> DonnerEnfants(int id);
        TE DonnerPere(int id);
        TE DonnerMere(int id);
        IEnumerable<TE> DonnerParArbre(int idArbre);
        IEnumerable<TE> DonnerParenteesDirectesPossibles(int id, int idArbre);
        IEnumerable<TE> Rechercher(RE e);
    }
}
