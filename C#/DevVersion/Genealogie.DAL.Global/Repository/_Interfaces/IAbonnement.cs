using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IAbonnementRepository<Abonnement> : IBase<Abonnement>, IAct<Abonnement>, IParNom
    {
    }

}
