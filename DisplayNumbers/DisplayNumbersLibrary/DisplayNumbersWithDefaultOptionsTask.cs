using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumbersLibrary
{
    public interface IDisplayNumbersWithDefaultOptionsTask
    {
        string[] Execute(int upperBound);
    }

    public class DisplayNumbersWithDefaultOptionsTask : IDisplayNumbersWithDefaultOptionsTask
    {
        public string[] Execute(int upperBound)
        {
            var arrayToDisplay = new string[upperBound];

            for (int i = 1; i <= upperBound; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    arrayToDisplay[i-1] = "fizz buzz";
                }
                else if (i % 3 == 0)
                {
                    arrayToDisplay[i-1] = "fizz";
                }
                else if (i % 5 == 0)
                {
                    arrayToDisplay[i-1] = "buzz";
                }
                else
                {
                    arrayToDisplay[i-1] = i.ToString();
                }
            }

            return arrayToDisplay;
        }
    }
}
