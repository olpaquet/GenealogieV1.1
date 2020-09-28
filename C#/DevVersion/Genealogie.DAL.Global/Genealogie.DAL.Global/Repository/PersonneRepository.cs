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
    public class PersonneRepository : BaseRepository, IPersonneRepository<Personne,Recherche>
    {
        private const string CONST_VPERSONNE_REQ = "select id,nom,prenom,datedenaissance,datededeces,homme,idarbre,dateajout,idpere,idmere, idblocage, utilisateuractif from VPersonne";


        private const string CONST_PERSONNE_REQ = "select id,nom,prenom,datedenaissance,datededeces,homme,idarbre,dateajout,idpere,idmere from Personne";
        public int Creer(Personne e)
        {
            
            Commande com = new Commande("Personne_cre", true);
            com.AjouterParametre("id", 0, true);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("prenom", e.prenom);
            com.AjouterParametre("datedenaissance", e.datedenaissance);
            com.AjouterParametre("datededeces", e.datededeces);
            com.AjouterParametre("homme", e.homme);
            com.AjouterParametre("idarbre", e.idarbre);
            com.AjouterParametre("dateajout", e.dateajout);
            
            _connexion.ExecuterNonRequete(com);
            return (int)com.Parametres["id"].Valeur;
        }
        public IEnumerable<Personne> Donner()
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ}");
            
            return _connexion.ExecuterLecteur(com, s => s.VersPersonne());
            throw new NotImplementedException();
        }
        public Personne Donner(int id)
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ} where id = @id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, s => s.VersPersonne()).SingleOrDefault();
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerPourArbre(int idArbre)
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ} where idArbre = @idArbre");
            com.AjouterParametre("idArbre", idArbre);
            return _connexion.ExecuterLecteur(com, s => s.VersPersonne());
            throw new NotImplementedException();
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfants(int id)
        {
            Commande com = new Commande($"{CONST_PERSONNE_REQ} where idpere = @id or idmere = @id");
            com.AjouterParametre("id", id);
            return _connexion.ExecuterLecteur(com, f => f.VersPersonne());            
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Personne e)
        {
            Commande com = new Commande("Personne_mod", true);
            com.AjouterParametre("id", e.id);
            com.AjouterParametre("nom", e.nom);
            com.AjouterParametre("prenom", e.prenom);
            com.AjouterParametre("datedenaissance", e.datedenaissance);
            com.AjouterParametre("datededeces", e.datededeces);
            com.AjouterParametre("homme", e.homme);
            com.AjouterParametre("idarbre", e.idarbre);
            com.AjouterParametre("dateajout", e.dateajout);
            
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }
        private static string ajouterFiltre(string filtre, string ajout)
        {
            if (ajout.Trim() == "" || ajout == null) return filtre;
            return filtre + ((filtre == "") ? "" : " and ") + ajout;
        }
        public IEnumerable<Personne> Rechercher(Recherche e)
        {
            string requeteSql = $"{CONST_VPERSONNE_REQ} ";
            string filtreSql = "";
            string nomParam = "";
            Dictionary<string, object> dicoParametresRequete = new Dictionary<string, object>();

            nomParam = "utilisateuractif";
            dicoParametresRequete.Add(nomParam, 1);
            filtreSql = ajouterFiltre(filtreSql, $"{nomParam} = @{nomParam}");

            if (e.idCreateurExclu != null)
            {
                nomParam = "idcreateureclu";
                dicoParametresRequete.Add(nomParam, e.idCreateurExclu);
                filtreSql = ajouterFiltre(filtreSql, $"{nomParam} <> @{nomParam}");
            }
         

            if (e.dateDeDeces != null)
            {
                nomParam = "datededeces";
                dicoParametresRequete.Add(nomParam, e.dateDeDeces);
                filtreSql = ajouterFiltre(filtreSql, $"{nomParam} = @{nomParam}");
            }

            if (e.dateDeNaissance != null)
            {
                nomParam = "datedenaissance";
                dicoParametresRequete.Add(nomParam, e.dateDeDeces);
                filtreSql = ajouterFiltre(filtreSql, $"{nomParam} = @{nomParam}");
            }

            if (e.homme != null)
            {
                nomParam = "homme";
                dicoParametresRequete.Add(nomParam, e.homme);
                filtreSql = ajouterFiltre(filtreSql, $"homme = @{nomParam}");
            }

            if (e.nom != null)
            {
                nomParam = "nom";
                dicoParametresRequete.Add(nomParam, e.nom);
                filtreSql = ajouterFiltre(filtreSql, $"{nomParam} = @{nomParam}");
            }
            if (e.prenom != null)
            {
                nomParam = "prenom";
                dicoParametresRequete.Add(nomParam, e.prenom);
                filtreSql = ajouterFiltre(filtreSql, $"{nomParam} = @{nomParam}");
            }
            if (filtreSql != "") filtreSql = $" where {filtreSql}";


            Commande com = new Commande($"{requeteSql} {filtreSql}");
            foreach(KeyValuePair<string,object> p in dicoParametresRequete)
            {
                com.AjouterParametre(p.Key, p.Value);
            }

            return _connexion.ExecuterLecteur(com, i => i.VersPersonne()).OrderBy(j => j.idarbre);

            throw new NotImplementedException();
        }

        public bool Supprimer(int id)
        {
            Commande com = new Commande("Personne_eff", true);
            com.AjouterParametre("id", id);
            return (int)_connexion.ExecuterNonRequete(com) > 0;
        }

        public Personne DonnerPere(int id)
        {
            Personne p = new PersonneRepository().Donner(id);
            return (p == null) ? null : (p.idpere == null) ? null : new PersonneRepository().Donner((int)p.idpere);
        }
        
        public Personne DonnerMere(int id)
        {
            Personne p = new PersonneRepository().Donner(id);
            return (p == null) ? null : (p.idmere == null) ? null : new PersonneRepository().Donner((int)p.idmere);
        }

        public bool EstUtilisee(int id, string[] options)
        {
            Commande com = new Commande ( $"{CONST_PERSONNE_REQ} where idmere in (select id from personne)" );
            int i = _connexion.ExecuterLecteur(com, j => j.VersPersonne()).Count();
            if (i > 0) return true;
            
            com = new Commande($"{CONST_PERSONNE_REQ} where idpere in (select id from personne)");
            i = _connexion.ExecuterLecteur(com, j => j.VersPersonne()).Count();
            if (i > 0) return true;
            return false;
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerParenteesDirectesPossibles(int id)
        {
            int idArbre = new PersonneRepository().Donner(id).idarbre;
            List<Personne> interdictions = new List<Personne>();
            InterditsVersHaut(id, interdictions);
            InterditsVersBas(id, interdictions);


            return new PersonneRepository()
                .DonnerPourArbre(idArbre)
                .Where(k => !(interdictions.Select(j => j.id).Contains(k.id)))
                ;            
            
        }

        private static void InterditsVersHaut(int id, List<Personne> interdits)
        {
            
            Personne p = new PersonneRepository().Donner(id);
            AjIlistUnique(interdits, p);
            
            int? idpere = p.idpere;
            if (idpere != null){InterditsVersHaut((int)idpere, interdits);}
            int? idmere = p.idmere;
            if (idmere != null){InterditsVersHaut((int)idmere, interdits);}
        }

        private static void InterditsVersBas(int id, List<Personne> interdits)
        {
            IEnumerable<Personne> enfants = new PersonneRepository().DonnerEnfants(id);
            foreach(Personne pe in enfants)
            {
                AjIlistUnique(interdits, pe);
                InterditsVersBas(pe.id, interdits);
            }
        }



        private static void AjIlistUnique(List<Personne> interdits, Personne p)
        {
            if (interdits.Where(j => j.id == p.id).SingleOrDefault() != null) interdits.Add(p);
        }

        

        public bool AjouterEnfant(int id, int idEnfant)
        {
            Commande com = new Commande("enfant_cre",true);
            com.AjouterParametre("id", id);
            com.AjouterParametre("idenfant", idEnfant);
            return _connexion.ExecuterNonRequete(com)>0;
            throw new NotImplementedException();
        }

        public bool SupprimerEnfant(int id, int idEnfant)
        {
            Commande com = new Commande("enfant_eff",true);
            com.AjouterParametre("id", id);
            com.AjouterParametre("idenfant", idEnfant);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }

        public bool AjouterParent( int id,int idParent)
        {
            return new PersonneRepository().AjouterEnfant(idParent, id);
            throw new NotImplementedException();
        }

        public bool SupprimerPere(int id)
        {
            Commande com = new Commande("pere_eff", true);
            com.AjouterParametre("id", id);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }        

        public bool SupprimerMere(int id)
        {
            Commande com = new Commande("mere_eff", true);
            com.AjouterParametre("id", id);
            return _connexion.ExecuterNonRequete(com) > 0;
            throw new NotImplementedException();
        }
    }
}
