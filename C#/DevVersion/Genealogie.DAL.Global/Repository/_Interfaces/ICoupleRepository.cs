using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface ICoupleRepository<PE>
    {
        bool Creer(int id1, int id2);
        bool Supprimer(int id1, int id2);
        
        IEnumerable<int> Donner(int id1);
        bool EstEnCouple(int id1, int id2);

    }
}
