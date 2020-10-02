using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Conversion;
using Genealogie.DAL.Global.Modeles;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public class UtilisateurAPIRepository : BaseRepository, IUtilisateurAPIRepository<UtilisateurAPI>
    {
        public const string CONST_UTILISATEURAPI_REQ = "select login, dom from utilisateurapi";
        public UtilisateurAPI Donner(string login, string motDePasse)
        {
            Commande com = new Commande($"{CONST_UTILISATEURAPI_REQ} where login = @login and dbo.ConstruireHMotdepasse(@motdepasse, presel,postsel) = motdepasse");
            com.AjouterParametre("login", login);
            com.AjouterParametre("motdepasse", motDePasse);
            UtilisateurAPI x = _connexion.ExecuterLecteur(com, j => j.VersUtilisateurAPI()).SingleOrDefault();
            return x;
            throw new NotImplementedException();
        }
    }
}
