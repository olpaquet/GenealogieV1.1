using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestHT();
            TestChecked();

            Console.WriteLine("appuyez sur une touche pour quitter");
            Console.ReadKey();

            
        }

        private static void TestHT()
        {
            Hashtable ht = new Hashtable();
            object o = new object();

            ht.Add(1, "coucou");
            ht.Add(o, o);

            foreach(DictionaryEntry dic in ht)
            {
                Console.WriteLine(dic.Key.ToString());
            }


        }

        private static void TestChecked()
        {
            int i = int.MaxValue;
            //int j = checked(i + 7);
            int j;
            checked
            {
                j = i + 10;

            }
            Console.WriteLine($"j={j}");
        }


    }


}
