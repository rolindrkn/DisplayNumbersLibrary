using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumbersLibrary
{
    public class DisplayNumbers
    {
        private readonly IDisplayNumbersTask displayNumbersTask;
        private const int MAX_VALUE = 125000000;

        public DisplayNumbers(IDisplayNumbersTask displayNumbersTask)
        {
            this.displayNumbersTask = displayNumbersTask;
        }

        public void WriteToConsole(int upperBound, Dictionary<int, string> customOptions = null)
        {
            ListToDisplay = GetList(upperBound, customOptions);
            try
            {
                foreach (var number in ListToDisplay)
                {
                    Console.WriteLine(number);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        public List<string> GetList(int upperBound, Dictionary<int, string> customOptions = null)
        {
            if (upperBound < 1 || upperBound > MAX_VALUE)
            {
                throw new ArgumentException("upperBound has to be at least 1 or less than 125000000");
            }

            ListToDisplay = displayNumbersTask.Execute(upperBound, customOptions);

            return ListToDisplay;
        }

        public List<string> ListToDisplay { get; set; }
    }
}
