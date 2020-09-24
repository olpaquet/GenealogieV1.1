using Genealogie.ASP.Models;
/*using Genealogie.DAL.Global.Repository;*/
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
    public class ArbreServiceAPI : BaseServiceAPI /*, IArbreRepository<Arbre, int>*/
    {
        public bool Activer(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/Activer/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public int Creer(Arbre e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PostAsync($"Arbre/Creer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToInt32((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public bool Desactiver(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/Desactiver/{id}", null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return Convert.ToBoolean((reponse.Content.ReadAsStringAsync().Result));
            throw new NotImplementedException();
        }

        public IEnumerable<Arbre> Donner()
        {
            HttpResponseMessage reponse = _client.GetAsync($"Arbre/Donner/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Arbre>>().Result;
            throw new NotImplementedException();
        }

        public Arbre Donner(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Arbre/Donner/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<Arbre>().Result;
            throw new NotImplementedException();
        }

        public IEnumerable<Arbre> Donner(ObjetDonnerListe e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/Donner/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Arbre>>().Result;
            throw new NotImplementedException();
        }

        public int? DonnerParNom(string cherche, int createur)
        {
            string contenuJson = JsonConvert.SerializeObject(new ChercherPar { chercheString = cherche, chercheInt=createur  }, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/DonnerParNom/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            if (x == "null") return null;
            else return int.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }

        public bool Modifier(int id, Arbre e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/Modifier/{id}", contenu).Result;
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
            HttpResponseMessage reponse = _client.DeleteAsync($"Arbre/Supprimer/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
            throw new NotImplementedException();
        }

        public bool EstUtilisee(int id, string [] options)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Arbre/EstUtilisee/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return bool.Parse(reponse.Content.ReadAsStringAsync().Result);
            throw new NotImplementedException();
        }

        public IEnumerable<Arbre> DonnerParUtilisateur(int id)
        {
            HttpResponseMessage reponse = _client.GetAsync($"Arbre/DonnerParUtilisateur/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return reponse.Content.ReadAsAsync<IEnumerable<Arbre>>().Result;
            throw new NotImplementedException();
            
        }

        

        public IEnumerable<Arbre> Donner(IEnumerable<int> ie, string[] options = null)
        {
            throw new NotImplementedException();
        }

        public bool Debloquer(int id)
        {
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/Debloquer/{id}",null).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            return bool.Parse(reponse.Content.ReadAsStringAsync().Result);
        }

        public bool Bloquer(BlocageArbre e)
        {
            string contenuJson = JsonConvert.SerializeObject(e, Formatting.Indented);
            StringContent contenu = new StringContent(contenuJson, Encoding.UTF8, "application/json");
            HttpResponseMessage reponse = _client.PutAsync($"Arbre/Bloquer/", contenu).Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return bool.Parse(x);
        }
    }
}