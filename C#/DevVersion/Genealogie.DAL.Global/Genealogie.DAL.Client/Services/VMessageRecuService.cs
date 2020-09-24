using Genealogie.DAL.Client.Modeles;
using gl = Genealogie.DAL.Global.Modeles;
using Genealogie.DAL.Global.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Genealogie.DAL.Client.Conversion;

namespace Genealogie.DAL.Client.Services
{
    public class VMessageRecuService : IVMessageRecuRepository<VMessageRecu>
    {

        private IVMessageRecuRepository<gl.VMessageRecu> _rep;

        public VMessageRecuService() { this._rep = new VMessageRecuRepository(); }

        public IEnumerable<VMessageRecu> Donner(int idConvesation, int idDestinataire)
        {
            return _rep.Donner(idConvesation, idDestinataire).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<VMessageRecu> DonnerPoubellePourDestinataire(int id)
        {
            return _rep.DonnerPoubellePourDestinataire(id).Select(j => j.VersClient());
            throw new NotImplementedException();
        }

        public IEnumerable<VMessageRecu> DonnerPourDestinataire(int id)
        {
            return _rep.DonnerPourDestinataire(id).Select(j => j.VersClient());
            throw new NotImplementedException();
        }
    }
}
