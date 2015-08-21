using System;
using Xunit;

namespace FunctionalDemoDave
{
    public class FunctionalSimpleTests
    {
        // 2. Testing the main function - GetProcessing which has 4 dependencies 
        // mocking out the dependencies, and testing what this main function
        // does to it's dependencies
        [Fact]
        public void RunProcessingShouldLog()
        {
            // mocking out RunProcessing's 4 dependencies
            // Action is a delegate which doesn't return a value
            // Passing in an anonymous function which does nothing
            string actualMessage = "";
            Action<string> log = x => actualMessage = x;

            // compose.  Action is a delegate - doesn't return anything
            Action runProcessing = () => Functional.RunProcessing(log);
            runProcessing();

            // Testing if RunProcessing calls our mock Log function
            Assert.Equal("test", actualMessage); 
        }
    }
}
