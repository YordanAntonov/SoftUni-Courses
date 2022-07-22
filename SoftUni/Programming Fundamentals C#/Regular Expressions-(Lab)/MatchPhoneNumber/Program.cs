using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"\+359(?<sep>[ \-])2\k<sep>[0-9]{3}\k<sep>[0-9]{4}\b";
            Regex regex = new Regex(pattern);

            MatchCollection match = Regex.Matches(input, pattern);

            Console.WriteLine(string.Join(", ", match));
        }
    }
}
