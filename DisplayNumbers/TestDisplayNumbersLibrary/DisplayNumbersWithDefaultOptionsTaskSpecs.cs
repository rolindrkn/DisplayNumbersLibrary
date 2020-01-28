using System.Collections.Generic;
using System.Linq;
using DisplayNumbersLibrary;
using NUnit.Framework;
using Rhino.Mocks;

namespace ClassLibrary1
{
    public class DisplayNumbersWithDefaultOptionsTaskSpecs
    {
        public class DisplayNumbersWithCustomOptionsTaskSpecs
        {
            [TestFixture]
            public class when_displaying_default_options : TestArrangement
            {
                private IDisplayNumbersWithDefaultOptionsTask sut;
                private int upperBound;
                private IEnumerable<string> result;

                [Test]
                public void it_should_return_an_empty_list()
                {
                    base.Run();
                    Assert.IsEmpty(result);
                }

                protected override void Arrange()
                {
                    sut = MockRepository.GenerateStub<DisplayNumbersWithDefaultOptionsTask>();
                    upperBound = 0;
                }

                protected override void Act()
                {
                    result = sut.Execute(upperBound).ToList();
                }
            }

            [TestFixture]
            public class when_displaying_default_with_custom_value : TestArrangement
            {
                private IDisplayNumbersWithDefaultOptionsTask sut;
                private int upperBound;
                private List<string> result;
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
                    Assert.AreEqual("fizz buzz", result[upperBound - 1]);
                }

                protected override void Arrange()
                {
                    sut = MockRepository.GenerateStub<DisplayNumbersWithDefaultOptionsTask>();
                    upperBound = 30;
                }

                protected override void Act()
                {
                    result = sut.Execute(upperBound).ToList();
                }
            }

            [TestFixture]
            public class when_displaying_custom_with_max_value : TestArrangement
            {
                private IDisplayNumbersWithDefaultOptionsTask sut;
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
                    Assert.AreEqual("Fizz Buzz", result[upperBound - 1]);
                }

                protected override void Arrange()
                {
                    sut = MockRepository.GenerateStub<DisplayNumbersWithDefaultOptionsTask>();
                    upperBound = MAX_VALUE;
                }

                protected override void Act()
                {
                    result = sut.Execute(upperBound).ToList();
                }
            }
        }
    }
}