using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IAdmin
    {
        bool EstAdmin(int id);
        bool EstAdminNouvelle(int id);
        bool EstAdminForum(int id);
        bool EstAdminMessage(int id);
    }
}
