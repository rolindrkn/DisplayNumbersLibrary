using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumbersLibrary
{
    public interface IDisplayNumbersWithCustomOptionsTask
    {
        IEnumerable<string> Execute(int uppBound, KeyValuePair<int, string>[] customOptions = null);
    }

    public class DisplayNumbersWithCustomOptionsTask : IDisplayNumbersWithCustomOptionsTask
    {
        public IEnumerable<string> Execute(int upperBound, KeyValuePair<int, string>[] customOptions)
        {
            var arrayToDisplay = new string[upperBound];

            for (int i = 1; i <= upperBound; i++)
            {
                var custom = false;

                foreach (var pair in customOptions)
                {
                    if (pair.Key != 0 && i % pair.Key == 0)
                    {
                        arrayToDisplay[i-1] += pair.Value + " ";
                        custom = true;
                    }
                }

                if (!custom)
                {
                    arrayToDisplay[i-1] = i.ToString();
                }
            }

            return arrayToDisplay;
        }
    }
}
