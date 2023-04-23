using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace HomeWork4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tasl 1");
            string input = "23 * 45 =";
            var regexpLeft = new Regex(@"\d+\s*(\+|\-|\*|\/)");
            var regexpRigth = new Regex(@"(\+|\-|\*|\/)\s*\d+");
            var regNumber = new Regex(@"\d+");
            var regexpOperation = new Regex(@"(\+|\-|\*|\/)");
            MatchCollection matchesLeft = regexpLeft.Matches(input);
            MatchCollection matchesRigth = regexpRigth.Matches(input);
            foreach (Match match in matchesLeft)
            {
                Console.WriteLine("Левый операнд и операция : "
                    + match.ToString());
                MatchCollection numberLeft =
                    regNumber.Matches(match.ToString());
                Console.WriteLine("Левый операнд : "
                    + numberLeft[0]);
            }
            foreach (Match match in matchesRigth)
            {
                Console.WriteLine("Правый операнд и операция : "
                    + match.ToString());
                MatchCollection numberRigth =
                    regNumber.Matches(match.ToString());
                Console.WriteLine("Правый операнд : "
                    + numberRigth[0]);
                Console.ReadLine();
            }
        }
    }
}
