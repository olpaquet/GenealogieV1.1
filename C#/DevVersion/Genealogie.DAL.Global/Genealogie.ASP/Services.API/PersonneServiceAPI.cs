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
        public IEnumerable<Personne> DonnerParArbre(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Personne/DonnerParArbre/{id}").Result;
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

        public IEnumerable<Personne> Rechercher(Recherche e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/Chercher/",contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;
            throw new NotImplementedException();
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

        public IEnumerable<Personne> DonnerParenteesDirectesPossibles(int id, int idArbre)
        {
            string contenuJson = JsonConvert.SerializeObject(new ControleurPersonneRecherche { idArbre=idArbre, idPersonne=id }, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Personne/DonnerParenteesDirectesPossibles/{id}",contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<Personne>>().Result;
            return x;

        }
    }
}
 