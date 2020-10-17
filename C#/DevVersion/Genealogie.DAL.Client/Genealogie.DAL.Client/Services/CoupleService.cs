using Genealogie.DAL.Client.Modeles;
using gl=Genealogie.DAL.Global.Modeles;
using System;
using System.Collections.Generic;
using System.Text;
using Genealogie.DAL.Global.Repository;

namespace Genealogie.DAL.Client.Services
{
    public class CoupleService : ICoupleRepository<Personne>
    {
        private ICoupleRepository<gl.Personne> _rep;

        public CoupleService()
        {
            _rep = new CoupleRepository();
        }

        public bool Creer(int id1, int id2)
        {
            return _rep.Creer(id1, id2);
            throw new NotImplementedException();
        }

        public IEnumerable<int> Donner(int id1)
        {
            return _rep.Donner(id1);
            throw new NotImplementedException();
        }

        public bool EstEnCouple(int id1, int id2)
        {
            return _rep.EstEnCouple(id1, id2);
            throw new NotImplementedException();
        }

        public bool Supprimer(int id1, int id2)
        {
            return _rep.Supprimer(id1, id2);
            throw new NotImplementedException();
        }
    }
}
