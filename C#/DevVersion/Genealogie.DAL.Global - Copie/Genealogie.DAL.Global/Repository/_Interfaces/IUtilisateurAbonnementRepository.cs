using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IUtilisateurAbonnementRepository<TE, TR, TU> : IBase2<TE>, IAdmin
    {
        IEnumerable<TR> DonnerAbonnementsParUtilisateur(int idutilisateur);
        IEnumerable<TU> DonnerUtilisateursParAbonnement(int idabonnement);

    }
}
