using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumbersLibrary
{
    public interface IDisplayNumbersTask
    {
//        List<List<string>> Execute(int uppBound, KeyValuePair<int, string>[] customOptions = null);
        List<string> Execute(int uppBound, Dictionary<int,string> customOptions = null);
    }

    public class DisplayNumbersWithCustomOptionsTask : IDisplayNumbersTask
    {
        private const int MAX_VALUE = 125000000;
        public List<string> Execute(int upperBound, Dictionary<int,string> customOptions = null)
        {
            if (upperBound == 0)
                throw new ArgumentException("upper bound has to be at least 1");
            
            if(upperBound > MAX_VALUE)
                throw new ArgumentException("upper bound has to be less than or equal to 250,000,000");
            
            if(customOptions?.Count > upperBound)
                throw new ArgumentException("custom options lenght shouldn't be greater than upper bound");
            
            if (customOptions == null)
            {
                return CreateNumberList(upperBound);
            }
            return CreateCustomList(upperBound, customOptions);
        }

        private static List<string> CreateCustomList(int upperBound, Dictionary<int,string> customOptions)
        {
            var listToDisplay = new List<string>();
            
            for (int i = 1; i <= upperBound; i++)
            {
                var custom = false;
                listToDisplay.Add(string.Empty);

                foreach (var pair in customOptions)
                {
                    if (pair.Key != 0 && i % pair.Key == 0)
                    {
                        listToDisplay[i - 1] += pair.Value;
                        custom = true;
                    }
                }

                if (!custom)
                {
                    listToDisplay[i - 1] = i.ToString();
                }
            }

            return listToDisplay;
        }

        private static List<string> CreateNumberList(int upperBound)
        {
            var intList = Enumerable.Range(1, upperBound).ToList();
            return intList.ConvertAll<string>(x => x.ToString());
        }
    }
}
