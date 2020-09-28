using Genealogie.DAL.Global.Repository;
using Services;
using System;
using System.Collections.Generic;
using System.Text;


namespace Genealogie.DAL.Client.Services
{
    public class UtilisateurAPIService : IUtilisateurAPIRepository<UtilisateurAPI>
    {
        private IUtilisateurAPIRepository<UtilisateurAPI> _rep;

        public UtilisateurAPIService() { this._rep = new UtilisateurAPIRepository(); }

        public UtilisateurAPI Donner(string login, string motDePasse)
        {
            return _rep.Donner(login, motDePasse);
            throw new NotImplementedException();
        }
    }
}
