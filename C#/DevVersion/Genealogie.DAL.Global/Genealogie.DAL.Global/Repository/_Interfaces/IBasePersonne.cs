using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IBasePersonne<TE>
    {
        IEnumerable<TE> Donner(int idArbre);
        TE Donner(int idArbre, int idPersonne);
        int Creer(TE e);
        bool Modifier(int id, TE e);
        bool Supprimer(int id);

    }
}
