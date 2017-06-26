using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Regeh
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
           
            var copyInput = input;

            var matches = new List<string>();
            var closeBracketIndex = input.IndexOf("]");

            while (closeBracketIndex > 0)
            {


                var openBracketIndex = input.Substring(0, closeBracketIndex).LastIndexOf("[");

                if (openBracketIndex >= 0)
                {
                    matches.Add(input.Substring(0, closeBracketIndex).Substring(openBracketIndex + 1));
                }
                input = input.Substring(closeBracketIndex+1);
                closeBracketIndex = input.IndexOf("]");

            }
            var numbers = new List<int>();
            foreach (var m in matches)
            {
                var regex = new Regex(@"\w+<(\d+)REGEH(\d+)>\w+");
                if (regex.IsMatch(m))
                {
                    var match = regex.Match(m);
                    numbers.Add(int.Parse(match.Groups[1].Value));
                    numbers.Add(int.Parse(match.Groups[2].Value));
                }
            }
            int count = 0;
            foreach (var number in numbers)
            {
                count += number;
                Console.WriteLine(count % copyInput.Length);
                Console.Write(copyInput[count % copyInput.Length]);

            }
            Console.WriteLine();
           

        }
    }
}
