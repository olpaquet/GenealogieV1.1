using System;
using System.Collections.Generic;
using System.Text;

namespace Genealogie.DAL.Global.Repository
{
    public interface IBasePersonne<TE>
    {
        int Creer(TE e);
        bool Modifier(int id, TE e);
        bool Supprimer(int id);

        IEnumerable<TE> Donner();
        TE Donner(int id);

        IEnumerable<TE> DonnerEnfants(int id);
        TE DonnerPere(int id);
        TE DonnerMere(int id);
        IEnumerable<TE> DonnerParenteesDirectesPossibles(int id);
        

        bool EstUtilisee(int id, string[] options);


        IEnumerable<TE> DonnerPourArbre(int idArbre);
        

        bool AjouterEnfant(int id,int idEnfant);
        bool SupprimerEnfant(int id, int idEnfant);
        bool AjouterParent(int id, int idParent);
        bool SupprimerPere(int id);
        bool SupprimerMere(int id);


    }
}
