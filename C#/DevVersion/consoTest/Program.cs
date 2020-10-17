using BoiteAOutil.DB.Standard;
using Genealogie.DAL.Global.Modeles;
using Genealogie.DAL.Global.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace consoTest
{
    class Program
    {
        static void Main(string[] args)
        {

            arbre(6);

            testenfants(9);

            Console.ReadKey();        
        }
       
        private static void arbre(int idprop)
        {
            IEnumerable<Arbre> xxxx = new ArbreRepository().DonnerParUtilisateur(idprop);
            Console.WriteLine($"le nombre d'arbres = {xxxx.Count()}");
            var z = "ll";
        }
        private static void testenfants(int id)
        {
            

            IEnumerable<Descendant> oo = new PersonneRepository().DonnerLesEnfants(id);

            Console.WriteLine($"le nombre d'enfants = {oo.Count()}");

            Console.WriteLine("****");


        }


    }
}
