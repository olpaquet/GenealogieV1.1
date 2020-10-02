using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testreflexion
{
    class Program
    {
        static void Main(string[] args)
        {
            Ob ob = new Ob { id = 1, nom = "le nom" };
            explorer(ob,"no");
            explorer(ob, "nom");

            Console.ReadKey();
        }
        private class Ob
        {
            public int id { get; set; }
            public string nom { get; set; }
        }
        private static void explorer(object o, string nomprop)
        {
            bool trouve = false;
            foreach(var prop in o.GetType().GetProperties())
            {
                if (prop.Name == nomprop) { Console.WriteLine($"{prop.Name} .. {prop.GetValue(o, null)}"); trouve = true; }
            }
            if (!trouve) Console.WriteLine($"{nomprop} n'existe pas");
        }


        /*
         * 
         * Foo foo = new Foo {A = 1, B = "abc"};
foreach(var prop in foo.GetType().GetProperties()) {
       Console.WriteLine("{0}={1}", prop.Name, prop.GetValue(foo, null));
}
         * */
    }
}
