using Genealogie.ASP.Models;
using Genealogie.Modeles.API.ASP.Modeles;
using Newtonsoft.Json;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Genealogie.ASP.Services.API
{
    public class PersonneServiceAPI : BaseServiceAPI
    {

        /*ControleurPersonneRecherche*/
        public IEnumerable<Personne> DonnerPourArbre(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerPourArbre/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;
            throw new NotImplementedException();
        }
        public Personne Donner(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<Personne>().Result;
            return x;
        }

        

        public IEnumerable<Personne> DonnerEnfants(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerEnfants/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerEnfants(int id, int id2)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerEnfants/{id}/{id2}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;

        }

        public Personne DonnerPere(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerPere/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<Personne>().Result;
            return x;
            throw new NotImplementedException();
        }

        public Personne DonnerMere(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerMere/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<Personne>().Result;
            return x;
            throw new NotImplementedException();
        }

        public IEnumerable<Personne> DonnerParenteesDirectesPossibles(int id)
        {
            
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerParenteesDirectesPossibles/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;

        }

        public int Creer(Personne p)
        {
            string contenuJson = JsonConvert.SerializeObject(p, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Personne/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return int.Parse(x);
        }


        public bool AjouterEnfant(ParentEnfant e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/AjouterEnfant/", contenu).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        
        public bool SupprimerEnfant(ParentEnfant e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/SupprimerEnfant/", contenu).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }
       
        public bool AjouterParent(ParentEnfant e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/AjouterParent/", contenu).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        
        public bool SupprimerPere(int id)
        {
            
            HttpResponseMessage reponse = _client.PutAsync($"Personne/SupprimerPere/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }
        
        public bool SupprimerMere(int id)
        {
            
            HttpResponseMessage reponse = _client.PutAsync($"Personne/SupprimerMere/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public bool Modifier(int id, Personne p)
        {
            string contenuJson = JsonConvert.SerializeObject(p, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/Modifier/{id}", contenu).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }

        public IEnumerable<Personne> Rechercher(Recherche rec)
        {
          
            string contenuJson = JsonConvert.SerializeObject(rec, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/Rechercher/", contenu).Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;
          
        }

        public bool Supprimer(int id)
        {

            HttpResponseMessage reponse = _client.DeleteAsync($"Personne/Supprimer/{id}").Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }


        public IEnumerable<Personne> DonnerEnfantsSansMere(int idPere)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerEnfantsSansMere/{idPere}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;

        }
        public IEnumerable<Personne> DonnerEnfantsSansPere(int idMere)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerEnfantsSansPere/{idMere}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;

        }

        public IEnumerable<Personne> DonnerEnfantsSurs(int id, bool pere)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerEnfantsSurs/{id}/{pere}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;

        }

        public IEnumerable<Descendant> DonnerLesEnfants(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerLesEnfants/{id}").Result;
            if (!reponse.IsSuccessStatusCode) { throw new Exception("Echec de la réception de données."); }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Descendant>>().Result;
            return x;
        }

    }
}
 