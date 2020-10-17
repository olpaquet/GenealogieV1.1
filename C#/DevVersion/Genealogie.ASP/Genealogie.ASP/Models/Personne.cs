using Genealogie.ASP.Services;
using Genealogie.ASP.Services.API;
using Genealogie.Modeles.API.ASP.Modeles;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.ModelBinding;
using System.Web.Mvc;

namespace Genealogie.ASP.Models
{
    public class Personne : BPersonne
    {
        public string nomAffichage() { 
            
            { string ret = "";
                ret += (this.nom != null) ? this.nom.Trim() : "";
                ret += "";
                ret += (this.prenom != null) ? this.prenom.Trim() : "";
                ret = ret.Trim();
                string s = "";
                if (this.homme) s = "h";
                else s = "f";
                ret += $" {s}"
                    ;
                ret = ret.Trim();
                return ret;
            } 
        }
        public Personne Pere() {  return this.idPere==null?null:new PersonneServiceAPI().Donner((int)this.idPere);  }
        public Personne Mere() {  return this.idMere == null ? null : new PersonneServiceAPI().Donner((int)this.idMere);  }
        public IEnumerable<Personne> Enfants() {  return new PersonneServiceAPI().DonnerEnfants(this.id).OrderBy(j=>j.dateDeNaissance).ThenBy(j=>j.nom).ThenBy(j=>j.prenom);  }
        //public IEnumerable<Personne> enfants { get { return this.Enfants(); } }
        public Arbre Arbre() {  return new ArbreServiceAPI().Donner(this.idArbre);  }
        public Utilisateur Proprietaire() {  return new UtilisateurServiceAPI().Donner(this.Arbre().idCreateur);  }
    }



    public class PersonneIndex
    {
        public int id { get; set; }
        public string nomAffichage { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        [DisplayName("date de naissance")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateDeNaissance { get; set; }
        [DisplayName("date de décès")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? dateDeDeces { get; set; }
        public bool homme { get; set; }
        [DisplayName("ajout")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy hh:mm:ss}")]
        [DataType(DataType.DateTime)]
        public DateTime dateAjout { get; set; }
        public PersonneIndex pere { get; set; }
        public PersonneIndex mere { get; set; }
        public IList<PersonneIndex> enfants { get; set; }
        public int idArbre { get; set; }
        public string nomArbre { get; set; }
        public string nomProprietaire { get; set; }

        public PersonneIndex() { }
        public PersonneIndex(Personne e, bool calculenfants, bool calculparents)
        
        {
            this.id = e.id;
            this.homme = e.homme;
            this.dateAjout = e.dateAjout;
            this.dateDeDeces = e.dateDeDeces;
            this.dateDeNaissance = e.dateDeNaissance;
            this.pere = e.idPere==null?null:new PersonneIndex( e.Pere(),false,false);
            this.mere = e.idMere==null?null:new PersonneIndex(e.Mere(),false,false);
            this.nom = e.nom;
            this.prenom = e.prenom;
            this.idArbre = e.idArbre;

            this.nomAffichage = e.nomAffichage();

            if (calculenfants)
            {
                this.enfants = e.Enfants()
                .Select(j=>new PersonneIndex(j,true,false))
                .ToList();

                this.nomArbre = e.Arbre().nom;
                this.nomProprietaire = e.Proprietaire().nomAffichage();
            }
            else
            {
                this.enfants = new List<PersonneIndex>();
                
            }

        }



    }

    public class PersonneCreation
    {
        public string nom { get; set; }
        [DisplayName("prénom")]
        public string prenom { get; set; }
        public bool homme { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de naissance")]
        public DateTime? dateDeNaissance { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de décès")]
        public DateTime? dateDeDeces { get; set; }

        public int idArbre { get; set; }
        /*public IList<SelectListItem> SLIEnfants { get; set; }
        public IList<SelectListItem> SLIPere { get; set; }
        public IList<SelectListItem> SLIMere { get; set; }*/

        public PersonneCreation() { }
        

    }

    public class PersonneModification
    {
        public string nom { get; set; }
        [DisplayName("prénom")]
        public string prenom { get; set; }
        public bool homme { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de naissance")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateDeNaissance { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("date de décès")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? dateDeDeces { get; set; }

        public PersonneModification() { }
        public PersonneModification(Personne e)
        {
            this.dateDeDeces = e.dateDeDeces;
            this.dateDeNaissance = e.dateDeNaissance;
            this.homme = e.homme;
            this.nom = e.nom;
            this.prenom = e.prenom;            
        }
    }

    public class PersonneAjouterEnfant
    {
        public int  id { get; set; }
        public int  idArbre { get; set; }
        [DisplayName("parent")]
        public string Parent { get; set; }
        public int machin { get; set; }

        public IList<SelectListItem> enfants { get; set; }
    }

    public class FormAjouterParent 
    {
        public int idParent { get; set; }
        public int idArbre { get; set; }
        public IList<SelectListItem> parents { get; set; }
    }


    public class PersonneDansArbreIndividuel
    {
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public bool homme { get; set; }
        public int? idPere { get; set; }
        public int? idMere { get; set; }
        public IList<string> fiche { get; set; }
        public DateTime? dateDeNaissance { get; set; }
        public DateTime? dateDeDeces { get; set; }
        public DateTime dateAjout { get; set; }
        public IList<PersonneDansArbreIndividuel> descendants { get; set; }


        

        public PersonneDansArbreIndividuel(Personne p, int pbas = int.MaxValue)
        {
            this.id = p.id;
            this.nom = p.nom;
            this.prenom = p.prenom;
            this.homme = p.homme;
            this.dateAjout = p.dateAjout;
            this.dateDeDeces = p.dateDeDeces;
            this.dateDeNaissance = p.dateDeNaissance;
            this.idPere = p.idPere;
            this.idMere = p.idMere;

            int limite = (pbas == int.MaxValue) ? int.MaxValue : pbas - 1;
            this.descendants = new List<PersonneDansArbreIndividuel>();
            if (limite > 0)
            {
                IEnumerable<Personne> leskids = p.Enfants();
                if (leskids != null && leskids.Count()!= 0)
                foreach(Personne pp in leskids)
                {
                    this.descendants.Add(new PersonneDansArbreIndividuel(pp, limite));
                }
                

            }

            /* fiche */
            this.fiche = ServPersonne.Fiche(p);
        }
    }

    public class F2ormArbre
    {
        public Personne maitre { get; set; }
        public Personne parent { get; set; }
        public IList<Personne> couples { get; set; }
        public IList<string> fiche { get; set; }
        public IDictionary<int, IList<string>> fichespartenaire { get; set; }
        public IDictionary<Personne, IList<FormArbre>> descendants { get; set; }

        public F2ormArbre() { }
        public F2ormArbre(Personne p, Personne parent, int pbas = int.MaxValue)
        {            

        }

    }
    public class FormArbre
    {
        public Personne parent { get; set; }
        public Personne maitre { get; set; }
        public IList<Personne> couples { get; set; }
        
        public IList<string> fiche { get; set; }

        public IDictionary<int, IList<string>> fichespartenaire { get; set; }
        public IList<FormArbre> descendants { get; set; }

        public IDictionary<Personne, IList<FormArbre>> dXescendants = new Dictionary<Personne, IList<FormArbre>>();

        public FormArbre() { }
        
        public FormArbre(Personne p, Personne parent, int pbas = int.MaxValue)
        {
            this.fiche = ServPersonne.Fiche(p);
            this.parent = parent;
            this.maitre = p;
            
            int limite = pbas == int.MaxValue ? int.MaxValue : pbas--;

            IEnumerable<Personne> sescouples = new CoupleServiceAPI().Partenaires(p.id).Select(j => new PersonneServiceAPI().Donner(j)).ToList();
            //if (couples == null) couples = new List<Personne>();
            this.couples = new List<Personne>();
            

            this.descendants = new List<FormArbre>();
            this.dXescendants = new Dictionary<Personne, IList<FormArbre>>();
            IEnumerable<Descendant> prog = new PersonneServiceAPI().DonnerLesEnfants(p.id).OrderBy(j=>j.parent==null?int.MaxValue:j.parent.id).ThenBy(j=>j.enfant==null?int.MaxValue:j.enfant.id);
            if (pbas > 0)
            {
                int memParentId = -1;
                IList<FormArbre> d = new List<FormArbre>();
                foreach (Descendant desc in prog)
                {
                    if (memParentId != (desc.parent==null?0:desc.parent.id)) 
                    {
                        d = new List<FormArbre>();
                        memParentId = desc.parent==null?0:desc.parent.id; 
                        this.couples.Add(desc.parent==null?new Personne {id=0 }:desc.parent);
                        var y = "oo";
                        d.Add(new FormArbre(desc.enfant, desc.parent, limite));
                        dXescendants.Add(desc.parent==null?new Personne { id = 0 }:desc.parent, d);
                    }
                    else d.Add(new FormArbre(desc.enfant, desc.parent, limite));
                    descendants.Add(new FormArbre(new PersonneServiceAPI().Donner(desc.enfant.id) , desc.parent, limite));
                }
                IEnumerable<Personne> tempCouple = couples;
                foreach (Personne pp in sescouples.Where(j => !tempCouple.Select(k=>k.id).Contains(j.id)))
                {
                    this.couples.Add(pp);
                    //descendants.Add(new FormArbre(pp, null, limite));
                }
            }
            if (pbas == 0)
            {
                foreach (Personne pp in sescouples)
                {
                    descendants.Add(new FormArbre(this.maitre, new PersonneServiceAPI().Donner(pp.id), -1));
                    IList<FormArbre> xx = new List<FormArbre>();
                    
                }
                this.couples = sescouples.ToList();
            }

            this.fichespartenaire = new Dictionary<int, IList<string>>();
            foreach (Personne pp in couples)
            {
                this.fichespartenaire.Add(pp.id, ServPersonne.Fiche(pp));
            }
            descendants.OrderBy(j => j.maitre.id);
            
            
        }
    }

    public class xArbrePourVue
    {
        public string html { get; set; }
        public StringBuilder sbHtml { get; set; }
        public xArbrePourVue(PersonneDansArbreIndividuel p)
        {
            this.html = DessinerArbre.monSuperHtml(p);
            this.sbHtml = new StringBuilder(this.html);
           
        }
    }

}