using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IArbreRepository<TE,TVar2> : IBase<TE>, IAct<TE>, IParNom2<TVar2>
    {
    }
}
