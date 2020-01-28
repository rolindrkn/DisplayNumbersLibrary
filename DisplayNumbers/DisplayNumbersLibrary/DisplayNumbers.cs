using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisplayNumbersLibrary
{
    public class DisplayNumbers
    {
        private readonly IDisplayNumbersWithCustomOptionsTask displayNumbersWithCustomOptionsTask;
        private IDisplayNumbersWithDefaultOptionsTask displayNumbersWithDefaultOptionsTask;


        public DisplayNumbers()
        {
            this.displayNumbersWithCustomOptionsTask = new DisplayNumbersWithCustomOptionsTask();
            this.displayNumbersWithDefaultOptionsTask = new DisplayNumbersWithDefaultOptionsTask();
        }

        public List<string> Display(int upperBound, KeyValuePair<int, string>[] customOptions = null)
        {
            try
            {
                if (upperBound < 1)
                {
                    throw new ArgumentException();
                }

                if (customOptions != null)
                {
                    return DisplayNumbersWithCustomOptions(upperBound, customOptions);
                }
                else
                {
                    return DisplayNumbersWithDefaultOptions(upperBound);
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("number entered cannot be less than one");
            }

            return null;
        }

        public string[] arrayToDisplay { get; set; }

        private List<string> DisplayNumbersWithCustomOptions(int upperBound, KeyValuePair<int, string>[] customOptions)
        {
            return displayNumbersWithCustomOptionsTask.Execute(upperBound, customOptions).ToList();
        }
        private List<string> DisplayNumbersWithDefaultOptions(int upperBound)
        {
            return displayNumbersWithDefaultOptionsTask.Execute(upperBound).ToList();
        }
    }

    internal class ArgumentException : Exception
    {
    }
}
