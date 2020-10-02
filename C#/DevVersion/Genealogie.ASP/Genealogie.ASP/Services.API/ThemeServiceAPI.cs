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
    public class ThemeServiceAPI : BaseServiceAPI /*, IThemeRepository<Theme>*/
    {
        public bool Activer(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Theme/Activer/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public int Creer(Theme e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Theme/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToInt32((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public bool Desactiver(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Theme/Desactiver/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public IEnumerable<Theme> Donner()
        {
            HttpResponseMessage reponse = _client.GetAsync($"Theme/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Theme>>().Result;
            throw new NotImplementedException();
        }

        public Theme Donner(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Theme/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<Theme>().Result;
            throw new NotImplementedException();
        }

        public IEnumerable<Theme> Donner(ObjetDonnerListe e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Theme/Donner/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Theme>>().Result;
            throw new NotImplementedException();
        }

        public int? DonnerParNom(string cherche)
        {
            string contenuJson = JsonConvert.SerializeObject(new ChercherPar { chercheString = cherche }, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Theme/DonnerParNom/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            if (x == "null") return null;
            else return int.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Theme e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Theme/Modifier/{id}", contenu).Result;
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
            HttpResponseMessage reponse = _client.DeleteAsync($"Theme/Supprimer/{id}").Result;
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
            HttpResponseMessage reponse = _client.GetAsync($"Theme/EstUtilisee/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return bool.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }
    }
}