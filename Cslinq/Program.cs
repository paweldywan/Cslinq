using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cslinq
{
    class Program
    {
        static void Main(string[] args)
        {
            _ = args;


            TestIEnumerable();

            WriteSeparator();

            TestExtensions();

            WriteSeparator();

            TestFunc();


            Console.ReadLine();
        }

        private static void TestIEnumerable()
        {
            IEnumerable<string> cities = new[] { "Ghent", "London", "Las Vegas", "Hyderabad" };

            IEnumerable<string> query = cities.Where(city => city.StartsWith("L"))
                                              .OrderByDescending(city => city.Length);


            foreach (var city in query)
            {
                Console.WriteLine(city);
            }
        }

        private static void WriteSeparator()
        {
            Console.WriteLine("---");
        }

        private static void TestExtensions()
        {
            DateTime date = new DateTime(2002, 8, 9);

            int daysTillEndOfMonth = date.DaysToEndOfMonth();

            Console.WriteLine(daysTillEndOfMonth);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0039:Use local function", Justification = "<Pending>")]
        private static void TestFunc()
        {
            Func<int, int> square = x => x * x;
            Func<int, int, int> add = (x, y) => x + y;
            Action<int> write = x => Console.WriteLine(x);

            write(square(add(1, 3)));
        }
    }

    public static class DateUtilities
    {
        public static int DaysToEndOfMonth(this DateTime date)
        {
            return DateTime.DaysInMonth(date.Year, date.Month) - date.Day;
        }
    }
}

namespace Extensions
{
    public static class FilterExtensions
    {
        public static IEnumerable<string> StringsThatStartWith(this IEnumerable<string> input, string start)
        {
            foreach (var s in input)
            {
                if (s.StartsWith(start))
                {
                    yield return s;
                }
            }
        }

        public static IEnumerable<T> Filter<T>(this IEnumerable<T> input, Func<T, bool> predicate)
        {
            foreach (var item in input)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }
}
