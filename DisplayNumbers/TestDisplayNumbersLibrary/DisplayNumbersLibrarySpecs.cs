using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DisplayNumbersLibrary;
using NUnit.Framework;
using Rhino.Mocks;

namespace ClassLibrary1
{
    public class DisplayNumbersLibrarySpecs
    {
        [TestFixture]
        public class when_displaying_numbers_with_an_upper_bound_less_than_one : TestArrangement
        {
            private DisplayNumbers sut;
            private List<string> result;
            private IDisplayNumbersTask displayNumbersWithDefaultTask, displayNumbersWithCustomTask;
            private int upperBound;

            [Test]
            public void it_should_return_null()
            
            {
                Arrange();
                Assert.Throws<ArgumentException>(() => sut.GetList(upperBound));
            }

            protected override void Arrange()
            {
                upperBound = 0;
                sut = MockRepository.GenerateStub<DisplayNumbers>(new DisplayNumbersWithCustomOptionsTask());
            }
        }
        
        [TestFixture]
        public class when_displaying_numbers_with_an_upper_bound_greater_than_Max : TestArrangement
        {
            private DisplayNumbers sut;
            private List<string> result;
            private IDisplayNumbersTask displayNumbersWithDefaultTask, displayNumbersWithCustomTask;
            private int upperBound;
            private const int MAX_VALUE = 125000000;

            [Test]
            public void it_should_return_null()
            {
                Arrange();
                Assert.Throws<ArgumentException>(() => sut.GetList(upperBound));
            }

            protected override void Arrange()
            {
                upperBound = MAX_VALUE + 1;
                sut = MockRepository.GenerateStub<DisplayNumbers>(new DisplayNumbersWithCustomOptionsTask());
            }
        }
        
        [TestFixture]
        public class when_displaying_numbers_at_max_upper_bound : TestArrangement
        {
            private DisplayNumbers sut;
            private const int MAX_VALUE = 125000000;
            private List<string> result;
            private IDisplayNumbersTask displayNumbersWithDefaultTask;
            private int upperBound;
            private List<string> resultList;

            [Test]
            public void it_should_return_the_correct_amount_of_data()
            {
                Run();
                Assert.AreEqual(result.Count, MAX_VALUE);
            }

            protected override void Arrange()
            {
                upperBound = MAX_VALUE;
                resultList = new List<string>();
                displayNumbersWithDefaultTask = new DisplayNumbersWithDefaultOptionsTask();
                sut = MockRepository.GenerateStub<DisplayNumbers>(displayNumbersWithDefaultTask);
            }
            
            protected override void Act()
            {
                result = sut.GetList(upperBound);
            }
        }

        [TestFixture]
        public class when_displaying_numbers_with_the_default_options : TestArrangement
        {
            private DisplayNumbers sut;
            private int maxValue;
            private List<string> result;
            private IDisplayNumbersTask displayNumbersWithDefaultTask;
            private int upperBound;
            private List<string> resultList;

            [Test]
            public void it_should_return_the_correct_amount_of_data()
            {
                base.Run();
                Assert.AreEqual(result.Count, upperBound);
            }
            
            [Test]
            public void it_should_return_the_correct_data()
            {
                base.Run();
                Assert.AreEqual(result, resultList);
            }

            protected override void Arrange()
            {
                upperBound = 5;
                resultList = new List<string>()
                {
                    "1", "2", "Fizz", "4", "Buzz"
                };
                sut = MockRepository.GenerateStub<DisplayNumbers>(new DisplayNumbersWithDefaultOptionsTask());
            }
            
            protected override void Act()
            {
                result = sut.GetList(upperBound);
            }
        }

        [TestFixture]
        public class when_displaying_numbers_with_the_custom_options : TestArrangement
        {
            private DisplayNumbers sut;
            private List<string> result;
            private int upperBound;
            private Dictionary<int, string> customOptions;
            private List<string> resultList;

            [Test]
             public void it_should_return_the_correct_amount_of_data()
             {
                 base.Run();
                 Assert.AreEqual(result.Count(), upperBound);
             }
             
             [Test]
             public void it_should_return_the_correct_data()
             {
                 base.Run();
                 Assert.AreEqual(result, resultList);
             }

            protected override void Arrange()
            {
                upperBound = 5;
                resultList = new List<string>()
                {
                    "Jean", "JeanLuc", "Jean", "JeanLucPicard", "Jean"
                };
                customOptions = new Dictionary<int, string>();
                customOptions.Add(1, "Jean");
                customOptions.Add(2, "Luc");
                customOptions.Add(4, "Picard");
                
                sut = MockRepository.GenerateStub<DisplayNumbers>(new DisplayNumbersWithCustomOptionsTask());
            }
            
            protected override void Act()
            {
                result = sut.GetList(upperBound, customOptions);
            }
        }
    }
}