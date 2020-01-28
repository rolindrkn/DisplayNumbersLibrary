using System;
using System.Collections.Generic;
using System.Linq;
using DisplayNumbersLibrary;
using NUnit.Framework;
using Rhino.Mocks;

namespace ClassLibrary1
{
    public class DisplayNumbersWithCustomOptionsTaskSpecs
    {
        [TestFixture]
        public class when_displaying_custom_options : TestArrangement
        {
            private IDisplayNumbersWithCustomOptionsTask sut;
            private int upperBound;
            private IEnumerable<string> result;
            private KeyValuePair<int, string>[] customOptions;

            [Test]
            public void it_should_return_an_empty_list()
            {
                base.Run();
                Assert.IsEmpty(result);
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 0;
                customOptions = new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(2, "Jean"), 
                    new KeyValuePair<int, string>(3, "Luc"),
                    new KeyValuePair<int, string>(5, "Picard")
                };
            }

            protected override void Act()
            {
                result = sut.Execute(upperBound, customOptions);
            }
        }
        
        [TestFixture]
        public class when_displaying_custom_with_custom_value : TestArrangement
        {
            private IDisplayNumbersWithCustomOptionsTask sut;
            private int upperBound;
            private List<string> result;
            private KeyValuePair<int, string>[] customOptions;
            private const int MAX_VALUE = int.MaxValue;

            [Test]
            public void it_should_not_return_an_empty_list()
            {
                base.Run();
                Assert.IsNotEmpty(result);
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
                Assert.AreEqual("Jean Luc Picard ", result[upperBound-1]);
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = 30;
                customOptions = new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(2, "Jean"), 
                    new KeyValuePair<int, string>(3, "Luc"),
                    new KeyValuePair<int, string>(5, "Picard")
                };
            }

            protected override void Act()
            {
                result = sut.Execute(upperBound, customOptions).ToList();
            }
        }
        
        [TestFixture]
        public class when_displaying_custom_with_max_value : TestArrangement
        {
            private IDisplayNumbersWithCustomOptionsTask sut;
            private int upperBound;
            private List<string> result;
            private KeyValuePair<int, string>[] customOptions;
            private const int MAX_VALUE = Int32.MaxValue;

            [Test]
            public void it_should_not_return_an_empty_list()
            {
                base.Run();
                Assert.IsNotEmpty(result);
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
                Assert.AreEqual("Jean Luc Picard ", result[upperBound-1]);
            }

            protected override void Arrange()
            {
                sut = MockRepository.GenerateStub<DisplayNumbersWithCustomOptionsTask>();
                upperBound = MAX_VALUE;
                customOptions = new KeyValuePair<int, string>[]
                {
                    new KeyValuePair<int, string>(2, "Jean"), 
                    new KeyValuePair<int, string>(3, "Luc"),
                    new KeyValuePair<int, string>(5, "Picard")
                };
            }

            protected override void Act()
            {
                result = sut.Execute(upperBound, customOptions).ToList();
            }
        }
    }
}