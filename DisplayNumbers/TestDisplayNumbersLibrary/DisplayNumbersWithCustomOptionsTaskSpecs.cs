using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using DisplayNumbersLibrary;
using NUnit.Framework;
using Rhino.Mocks;

namespace ClassLibrary1
{
    public class DisplayNumbersWithCustomOptionsTaskSpecs
    {
        [TestFixture]
        public class when_displaying_custom_options_with_upper_bound_zero : TestArrangement
        {
            private IDisplayNumbersTask sut;
            private int upperBound;
            private List<string> result;
            private Dictionary<int, string> customOptions;
            private ArgumentException error;

            [Test]
            public void it_should_not_return_anything()
            {
                base.Run();
                Assert.IsNull(result);
            }

            [Test]
            public void it_should_have_thrown_an_error()
            {
                Arrange();
                Assert.Throws<ArgumentException>(() => sut.Execute(upperBound, customOptions));
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 0;
                customOptions = new Dictionary<int, string>();
                customOptions.Add(2, "Jean");
                customOptions.Add(3, "Luc");
                customOptions.Add(5, "Picard");
            }

            protected override void Act()
            {
                try
                {
                    result = sut.Execute(upperBound, customOptions);
                }
                catch (ArgumentException e){}
            }
        }
        
        [TestFixture]
        public class when_displaying_custom_with_custom_value_with_upper_bound_less_than_max : TestArrangement
        {
            private IDisplayNumbersTask sut;
            private int upperBound;
            private List<string> result;
            private Dictionary<int, string> customOptions;
            private const int MAX_VALUE = 125000000;

            [Test]
            public void it_should_not_return_an_empty_list()
            {
                base.Run();
                Assert.IsNotEmpty(result);
                Assert.IsNotNull(result);
            }

            [Test]
            public void it_should_return_data_with_the_correct_length()
            {
                base.Run();
                Assert.AreEqual(result.Count(), upperBound);
            }
            [Test]
            public void it_should_return_the_correct_data()
            {
                base.Run();
                Assert.AreEqual("JeanLucPicard", result[upperBound-1]);
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 30;
                customOptions = new Dictionary<int, string>();
                customOptions.Add(2, "Jean");
                customOptions.Add(3, "Luc");
                customOptions.Add(5, "Picard");
            }

            protected override void Act()
            {
                result = sut.Execute(upperBound, customOptions).ToList();
            }
        }
        
        [TestFixture]
        public class when_displaying_with_custom_value_with_upper_bound_greater_than_max : TestArrangement
        {
            private IDisplayNumbersTask sut;
            private int upperBound;
            private List<string> result;
            private Dictionary<int, string> customOptions;
            private const int MAX_VALUE = 125000000;

            [Test]
            public void it_should_return_null()
            {
                base.Run();
                Assert.IsNull(result);
            }

            [Test]
            public void it_should_have_thrown_an_exception()
            {
                Arrange();
                Assert.Throws<ArgumentException>(() => sut.Execute(upperBound, customOptions));
            }
            
            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = MAX_VALUE + 1;
                customOptions = new Dictionary<int, string>();
                customOptions.Add(2, "Jean");
                customOptions.Add(3, "Luc");
                customOptions.Add(5, "Picard");
            }

            protected override void Act()
            {
                try
                {
                    result = sut.Execute(upperBound, customOptions).ToList();
                }
                catch(Exception e){}
            }
        }
        
        [TestFixture]
        public class when_displaying_custom_with_no_custom_options : TestArrangement
        {
            private IDisplayNumbersTask sut;
            private int upperBound;
            private List<string> result;
            private Dictionary<int, string> customOptions;
            private List<string> expectedList;
            private const int MAX_VALUE = 125000000;

            [Test]
            public void it_should_not_return_null()
            {
                base.Run();
                Assert.IsNotEmpty(result);
            }

            [Test]
            public void it_should_return_a_list_with_the_correct_length()
            {
                base.Run();
                Assert.AreEqual(result.Count, upperBound);
            }

            [Test]
            public void it_should_return_the_correct_list()
            {
                base.Run();
                Assert.AreEqual(result, expectedList);
            }
            
            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 10;
                expectedList = Enumerable.Range(1, upperBound).ToList().ConvertAll<string>(x => x.ToString());
            }

            protected override void Act()
            {
                result = sut.Execute(upperBound, customOptions).ToList();
            }
        }
        
        [TestFixture]
        public class when_displaying_custom_with_custom_options_length_equal_upper_bound : TestArrangement
        {
            private IDisplayNumbersTask sut;
            private int upperBound;
            private List<string> result;
            private Dictionary<int, string> customOptions;
            private List<string> expectedList;
            private const int MAX_VALUE = 125000000;

            [Test]
            public void it_should_not_return_null()
            {
                base.Run();
                Assert.IsNotEmpty(result);
            }

            [Test]
            public void it_should_return_a_list_with_the_correct_length()
            {
                base.Run();
                Assert.AreEqual(result.Count, upperBound);
            }

            [Test]
            public void it_should_return_the_correct_list()
            {
                base.Run();
                Assert.AreEqual(result, expectedList);
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 3;
                customOptions = new Dictionary<int, string>();
                customOptions.Add(1, "One");
                customOptions.Add(2, "Two");
                customOptions.Add(3, "Three");
                expectedList = new List<string>() {"One", "OneTwo", "OneThree"};
            }

            protected override void Act()
            {
                result = sut.Execute(upperBound, customOptions).ToList();
            }
        }
        
        [TestFixture]
        public class when_displaying_custom_with_custom_options_length_greater_than_upper_bound : TestArrangement
        {
            private IDisplayNumbersTask sut;
            private int upperBound;
            private List<string> result;
            private Dictionary<int, string> customOptions;
            private List<string> expectedList;
            private const int MAX_VALUE = 125000000;

            [Test]
            public void it_should_not_return_null()
            {
                base.Run();
                Assert.IsNull(result);
            }

            [Test]
            public void it_should_return_the_correct_list()
            {
                Arrange();
                Assert.Throws<ArgumentException>(() => sut.Execute(upperBound, customOptions));
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 3;
                customOptions = new Dictionary<int, string>();
                customOptions.Add(1, "One");
                customOptions.Add(2, "Two");
                customOptions.Add(3, "Three");
                customOptions.Add(4, "Four");
                expectedList = new List<string>() {"One", "OneTwo", "OneThree"};
            }

            protected override void Act()
            {
                try
                {
                    result = sut.Execute(upperBound, customOptions).ToList();
                }
                catch(Exception e){}
            }
        }
    }
}