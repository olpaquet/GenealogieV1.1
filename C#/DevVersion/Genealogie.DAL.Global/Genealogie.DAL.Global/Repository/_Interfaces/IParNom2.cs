using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IParNom2<TVar2>
    {
        int? DonnerParNom(string cherche, TVar2 prop);

        
    }
}
