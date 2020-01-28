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
        public class when_displaying_numbers_with_an_upper_bound_greater_less_than_one : TestArrangement
        {
            private DisplayNumbers sut;
            private IEnumerable<string> result;
            private IDisplayNumbersWithDefaultOptionsTask displayNumbersWithDefaultTask;
            private IDisplayNumbersWithCustomOptionsTask displayNumbersWithCustomOptionsWithCustomTask;
            private int upperBound;

            [Test]
            public void it_should_return_null()
            {
                base.Run();
                Assert.IsNull(result);
            }

            [Test]
            public void it_should_not_call_display_numbers_with_default_options_task()
            {
                base.Run();
                displayNumbersWithDefaultTask.AssertWasNotCalled(x => x.Execute(upperBound));
                
            }

            [Test]
            public void it_should_not_call_display_numbers_with_custom_options_task()
            {
                base.Run();
                displayNumbersWithCustomOptionsWithCustomTask.AssertWasNotCalled(x => x.Execute(upperBound, null));
            }

            protected override void Arrange()
            {
                upperBound = 0;
                displayNumbersWithDefaultTask = MockRepository.GenerateStub<IDisplayNumbersWithDefaultOptionsTask>();
                displayNumbersWithCustomOptionsWithCustomTask = MockRepository.GenerateStub<IDisplayNumbersWithCustomOptionsTask>();
                sut = MockRepository.GenerateStub<DisplayNumbers>();
            }
            
            protected override void Act()
            {
                result = sut.Display(upperBound);
            }
        }
        
        //TODO What is the max array size???
        [TestFixture]
        public class when_displaying_numbers_at_max_upper_bound : TestArrangement
        {
            private DisplayNumbers sut;
            private const int MAX_VALUE = 214748364;
            private IEnumerable<string> result;
            private IDisplayNumbersWithDefaultOptionsTask displayNumbersWithDefaultTask;
            private IDisplayNumbersWithCustomOptionsTask displayNumbersWithCustomOptionsWithCustomTask;
            private int upperBound;
            private KeyValuePair<int, string>[] customOptions;

            [Test]
            public void it_should_return_the_correct_amount_of_data()
            {
                base.Run();
                Assert.AreEqual(result.Count(), MAX_VALUE);
            }

            [Test]
            public void it_should_call_display_numbers_with_default_options_task()
            {
                base.Run();
                displayNumbersWithDefaultTask.AssertWasNotCalled(x => x.Execute(MAX_VALUE));
                
            }

            [Test]
            public void it_should_not_call_display_numbers_with_custom_options_task()
            {
                base.Run();
                displayNumbersWithCustomOptionsWithCustomTask.AssertWasCalled(x => x.Execute(MAX_VALUE, customOptions));
            }

            protected override void Arrange()
            {
                upperBound = MAX_VALUE;
                var array = new string[MAX_VALUE];
                customOptions = new KeyValuePair<int, string>[1];
                displayNumbersWithDefaultTask = MockRepository.GenerateStub<IDisplayNumbersWithDefaultOptionsTask>();
                displayNumbersWithCustomOptionsWithCustomTask = MockRepository.GenerateStub<IDisplayNumbersWithCustomOptionsTask>();
                sut = MockRepository.GenerateStub<DisplayNumbers>();
                displayNumbersWithCustomOptionsWithCustomTask.Stub(x => x.Execute(MAX_VALUE, customOptions)).Return(array);
            }
            
            protected override void Act()
            {
                result = sut.Display(upperBound, customOptions);
            }
        }

        [TestFixture]
        public class when_displaying_numbers_with_the_default_options : TestArrangement
        {
            private DisplayNumbers sut;
            private int maxValue;
            private IEnumerable<string> result;
            private IDisplayNumbersWithDefaultOptionsTask displayNumbersWithDefaultTask;
            private IDisplayNumbersWithCustomOptionsTask displayNumbersWithCustomOptionsWithCustomTask;
            private int upperBound;

            [Test]
            public void it_should_return_the_correct_amount_of_data()
            {
                base.Run();
                Assert.AreEqual(result.Count(), upperBound);
            }

            [Test]
            public void it_should_call_display_numbers_with_default_options_task()
            {
                base.Run();
                displayNumbersWithDefaultTask.AssertWasCalled(x => x.Execute(upperBound));
                
            }

            [Test]
            public void it_should_not_call_display_numbers_with_custom_options_task()
            {
                base.Run();
                displayNumbersWithCustomOptionsWithCustomTask.AssertWasNotCalled(x => x.Execute(upperBound, null));
            }

            protected override void Arrange()
            {
                upperBound = 25;
                string[] array = new string[upperBound];
                displayNumbersWithDefaultTask = MockRepository.GenerateStub<IDisplayNumbersWithDefaultOptionsTask>();
                displayNumbersWithCustomOptionsWithCustomTask = MockRepository.GenerateStub<IDisplayNumbersWithCustomOptionsTask>();
                sut = MockRepository.GenerateStub<DisplayNumbers>();
                displayNumbersWithDefaultTask.Stub(x => x.Execute(upperBound)).Return(array);
            }
            
            protected override void Act()
            {
                result = sut.Display(upperBound);
            }
        }

        [TestFixture]
        public class when_displaying_numbers_with_the_custom_options : TestArrangement
        {
            private DisplayNumbers sut;
            private int maxValue;
            private IEnumerable<string> result;
            private IDisplayNumbersWithDefaultOptionsTask displayNumbersWithDefaultTask;
            private IDisplayNumbersWithCustomOptionsTask displayNumbersWithCustomOptionsWithCustomTask;
            private int upperBound;
            private KeyValuePair<int, string>[] customOptions;

            [Test]
            public void it_should_return_the_correct_amount_of_data()
            {
                base.Run();
                Assert.AreEqual(result.Count(), upperBound);
            }

            [Test]
            public void it_should_call_display_numbers_with_default_options_task()
            {
                base.Run();
                displayNumbersWithDefaultTask.AssertWasNotCalled(x => x.Execute(upperBound));
                
            }

            [Test]
            public void it_should_not_call_display_numbers_with_custom_options_task()
            {
                base.Run();
                displayNumbersWithCustomOptionsWithCustomTask.AssertWasCalled(x => x.Execute(Arg.Is(25), Arg<KeyValuePair<int, string>[]>.Is.Anything));
            }

            protected override void Arrange()
            {
                upperBound = 25;
                var array = new string[upperBound];
                customOptions = new KeyValuePair<int, string>[1];
                displayNumbersWithDefaultTask = MockRepository.GenerateStub<IDisplayNumbersWithDefaultOptionsTask>();
                displayNumbersWithCustomOptionsWithCustomTask = MockRepository.GenerateStub<IDisplayNumbersWithCustomOptionsTask>();
                sut = MockRepository.GenerateStub<DisplayNumbers>();
                displayNumbersWithCustomOptionsWithCustomTask.Stub(x => x.Execute(Arg.Is(25), Arg<KeyValuePair<int, string>[]>.Is.Anything)).Return(array);
            }
            
            protected override void Act()
            {
                result = sut.Display(upperBound, customOptions);
            }
        }
    }
}