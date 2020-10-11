using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{




public class Example
    {
        public static void Main()
        {
            // Display the header.
            Console.WriteLine("{0,-53}{1}", "CULTURE", "SPECIFIC CULTURE");

            // Get each neutral culture in the .NET Framework.
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.NeutralCultures);
            // Sort the returned array by name.
            Array.Sort<CultureInfo>(cultures, new NamePropertyComparer<CultureInfo>());

            // Determine the specific culture associated with each neutral culture.
            foreach (var culture in cultures)
            {
                Console.Write("{0,-12} {1,-40}", culture.Name, culture.EnglishName);
                try
                {
                    Console.WriteLine("{0}", CultureInfo.CreateSpecificCulture(culture.Name).Name);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("(no associated specific culture)");
                }
            }


            DateTime date1 = new DateTime(2008, 4, 10);
            Console.WriteLine(date1.ToString("D",
                              CultureInfo.CreateSpecificCulture("fr-FR")));
            // Displays Thursday, April 10, 2008
            Console.WriteLine(date1.ToString("D",
                              CultureInfo.CreateSpecificCulture("pt-BR")));
            // Displays quinta-feira, 10 de abril de 2008
            Console.WriteLine(date1.ToString("D",
                              CultureInfo.CreateSpecificCulture("es-MX")));
            Console.ReadLine();
        }
    }

    public class NamePropertyComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            if (x == null)
                if (y == null)
                    return 0;
                else
                    return -1;

            PropertyInfo pX = x.GetType().GetProperty("Name");
            PropertyInfo pY = y.GetType().GetProperty("Name");
            return String.Compare((string)pX.GetValue(x, null), (string)pY.GetValue(y, null));
        }
    }
}
