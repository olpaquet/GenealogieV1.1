using Genealogie.DAL.Client.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            arbre(6);
            enfants(9); 
            Console.ReadKey();
        }
        private static void arbre(int id) { var xx = new ArbreService().DonnerParUtilisateur(id);
            var yy = "oooo";
        }
        private static void enfants(int id)
        {
            var x = new PersonneService().DonnerLesEnfants(id);
            var y = "o";
        }
    }
}
