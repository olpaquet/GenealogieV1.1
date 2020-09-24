using Genealogie.DAL.Global.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            int i = new ConversationRepository().DonnerParEmetteur(1).Count();
            Console.WriteLine($"# {i}");
            Console.ReadKey();

        }
    }
}
