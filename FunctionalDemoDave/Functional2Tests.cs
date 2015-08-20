using System;
using System.Collections.Generic;
using Xunit;

namespace FunctionalDemoDave
{
    public class Functional2Tests
    {
        // Testing the static functions which have no dependecies
        [Fact]
        public void CreateDaveReportShouldReturnDaveDone()
        {
            string result = Functional2.CreateReport("dave");
            Assert.Equal("dave done!", result);
        }

        // Single function has 4 dependencies 
        // mocking out the dependencies, and testing what this orchestration function
        // does to it's dependencies
        [Fact]
        public void RunProcessingShouldSendCorrectEmailBody()
        {
            // mocking out RunProcessing's 4 dependencies
            // Action is a delegate which doesn't return a value
            // Passing in an anonymous function
            Action<string> log = m => Console.WriteLine(m);

            // Func input of a string, delegating to anonymous function, returning ellie done!  
            Func<string, string> createReport = x => "ellie done";

            // Func with no input, delegating to an anonymous function, 
            // returning an array of 1 string - ellie
            Func<IEnumerable<string>> getCustomers = () => new[] { "ellie" };

            // Action is a delegate - doesn't return anything
            // we're going to test whether RunProcessing calls createReport
            // which sets the body to "ellie done"
            var actualBody = "";
            Action<string, string> sendEmail = (toAddress, body) =>
            {
                actualBody = body;
            };

            // compose.  Action is a delegate - doesn't return anything
            Action runProcessing = () => Functional2.RunProcessing(log, getCustomers, createReport, sendEmail);
            // run
            runProcessing();
            // assert - testing if RunProcessing runs the sendEmail function properly
            Assert.Equal("ellie done", actualBody);
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

        [Fact]
        public void RunProcessingShouldSendMultipleCorrectEmailBodies()
        {
            Action<string> log = m => Console.WriteLine(m);
            Func<string, string> createReport = customer => customer + " done";
            Func<IEnumerable<string>> getCustomers = () => new[] { "ellie", "bob" };

            List<string> actualBodyList = new List<string>();
            Action<string, string> sendEmail = (toAddress, body) => actualBodyList.Add(body);

            Functional2.RunProcessing(log, getCustomers, createReport, sendEmail);

            Assert.Equal("ellie done", actualBodyList[0]);
            Assert.Equal("bob done", actualBodyList[1]);
        }
    }
}
