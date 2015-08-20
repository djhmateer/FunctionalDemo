using System;
using System.Collections.Generic;
using Xunit;

namespace FunctionalDemoDave
{
    public class Functional2Tests
    {
        // Testing the static functions which have no dependecies
        [Fact]
        public void CreateReportShouldReturnCorrect()
        {
            string result = Functional2.CreateReport("dave");
            Assert.Equal("dave done!", result);
        }

        // The heart of the application..single function that has 3 dependencies 
        // mocking out the dependencies
        [Fact]
        public void RunProcessingShouldSendCorrectEmailBody()
        {
            // arrange
            var expectedCustomer = "ellie";
            var expectedReportBody = "ellie done!";

            // mocking out RunProcessing's 3 dependencies
            // Action is a delegate - doesn't return.  
            // Pass in a function
            Action<string> log = m => Console.WriteLine(m);

            // Func input of a string, returns ellie done!  
            Func<string, string> createReport = x => expectedReportBody;

            // Func with no input, delegating to an anonymous function, 
            // returning an array of 1 string - ellie
            Func<IEnumerable<string>> getCustomers = () => new[] { expectedCustomer };

            // Action is a delegate - doesn't return anything
            // we're going to test whether RunProcessing sets the body to "ellie done"
            var actualToAddress = "";
            var actualBody = "";
            Action<string, string> sendEmail = (toAddress, body) =>
            {
                actualToAddress = toAddress;
                actualBody = body;
            };

            Functional2.RunProcessing(log, getCustomers, createReport, sendEmail);

            // assert - test it runs the sendEmail function properly
            Assert.Equal(expectedReportBody, actualBody);
        }

        [Fact]
        public void RunProcessingShouldLog()
        {
            List<string> listOfLogEntries = new List<string>();
            // Action is a delegate - doesn't return.  
            Action<string> log = m => listOfLogEntries.Add(m);

            // Func input of a string, returns string.. 
            Func<string, string> createReport = x => x + " report test";

            // Func with no input, delegating to an anonymous function, 
            // returning an array of 1 string
            Func<IEnumerable<string>> getCustomers = () => new[] { "ellie" };

            Action<string, string> sendEmail = (toAddress, body) =>{};

            Functional2.RunProcessing(log, getCustomers, createReport, sendEmail);

            // assert logging in working
            Assert.Equal(3, listOfLogEntries.Count);
            Assert.Equal("test", listOfLogEntries[0]);
            Assert.Equal("ellie", listOfLogEntries[1]);
            Assert.Equal("ellie report test", listOfLogEntries[2]);
        }
    }
}
