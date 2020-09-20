using Genealogie.ASP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace Genealogie.ASP.Services.API
{
    public class AbonnementServiceAPI : BaseServiceAPI /*, IAbonnementRepository<Abonnement>*/
    {
        public bool Activer(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Abonnement/Activer/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public int Creer(Abonnement e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Abonnement/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToInt32((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public bool Desactiver(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Abonnement/Desactiver/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public IEnumerable<Abonnement> Donner()
        {
            HttpResponseMessage reponse = _client.GetAsync($"Abonnement/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Abonnement>>().Result;
            throw new NotImplementedException();
        }

        public Abonnement Donner(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Abonnement/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<Abonnement>().Result;
            return reponse.Content.ReadAsAsync<Abonnement>().Result;
            throw new NotImplementedException();
        }

        public IEnumerable<Abonnement> Donner(ObjetDonnerListe e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Abonnement/Donner/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Abonnement>>().Result;
            throw new NotImplementedException();
        }

        public int? DonnerParNom(string cherche)
        {
            string contenuJson = JsonConvert.SerializeObject(new ChercherPar { chercheString = cherche }, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Abonnement/DonnerParNom/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            if (x == "null") return null;
            else return int.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Abonnement e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Abonnement/Modifier/{id}", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
            throw new NotImplementedException();
        }

        public bool Supprimer(int id)
        {
            HttpResponseMessage reponse = _client.DeleteAsync($"Abonnement/Supprimer/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Abonnement/EstUtilisee/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return bool.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }
    }
}