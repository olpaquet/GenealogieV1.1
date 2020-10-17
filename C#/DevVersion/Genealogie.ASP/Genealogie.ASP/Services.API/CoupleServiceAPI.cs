using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Genealogie.ASP.Services.API
{
    public class CoupleServiceAPI : BaseServiceAPI
    {
        public bool EstEnCouple(int idpersonne, int idpartenaire)
        {
            
            HttpResponseMessage reponse = _client.GetAsync($"Couple/EstEnCouple/").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return Convert.ToBoolean(x);
            throw new NotImplementedException();
        }

        public IEnumerable<int> Partenaires(int id)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Couple/Partenaires/{id}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsAsync<IEnumerable<int>>().Result;
            return x;
            throw new NotImplementedException();
        }

        public bool Creer(int idpersonne, int idpartenaire)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Couple/Creer/{idpersonne}/{idpartenaire}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return Convert.ToBoolean(x);
            throw new NotImplementedException();
        }

        public bool Supprimer(int idpersonne, int idpartenaire)
        {

            HttpResponseMessage reponse = _client.GetAsync($"Couple/Supprimer/{idpersonne}/{idpartenaire}").Result;
            if (!reponse.IsSuccessStatusCode)
            {
                throw new Exception("Echec de la réception de données.");
            }
            var x = reponse.Content.ReadAsStringAsync().Result;
            return Convert.ToBoolean(x);
            throw new NotImplementedException();
        }
    }
}