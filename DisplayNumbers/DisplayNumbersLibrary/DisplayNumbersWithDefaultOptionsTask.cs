using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumbersLibrary
{
    public class DisplayNumbersWithDefaultOptionsTask : IDisplayNumbersTask
    {
        private const int MAX_VALUE = 125000000;
        public List<string> Execute(int upperBound, Dictionary<int, string> customOptions = null)
        {
            if (upperBound == 0)
                throw new ArgumentException("upper bound has to be at least 1");
            
            if(upperBound > MAX_VALUE)
                throw new ArgumentException("upper bound has to be less than or equal to 250,000,000");

            return CreateDefaultList(upperBound);
        }

        private static List<string> CreateDefaultList(int upperBound)
        {
            var listToDisplay = new List<string>();
            for (int i = 1; i <= upperBound; i++)
            {
                listToDisplay.Add(string.Empty);

                if (i % 3 == 0 && i % 5 == 0)
                {
                    listToDisplay[i - 1] = "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    listToDisplay[i - 1] = "Fizz";
                }
                else if (i % 5 == 0)
                {
                    listToDisplay[i - 1] = "Buzz";
                }
                else
                {
                    listToDisplay[i - 1] = i.ToString();
                }
            }

            return listToDisplay;
        }
    }
}
