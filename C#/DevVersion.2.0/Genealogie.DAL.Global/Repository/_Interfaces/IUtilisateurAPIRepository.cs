using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IUtilisateurAPIRepository<TU>
    {
        TU Donner(string login, string motDePasse);
    }
}
