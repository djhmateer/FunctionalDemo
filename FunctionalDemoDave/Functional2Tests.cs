using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FunctionalDemoDave
{
    public class Functional2Tests
    {
        [Fact]
        public void FunctionalTest()
        {
            // arrange
            var expectedCustomer = "ellie";
            var expectedReportBody = "ellie done!";

            // mocking out getCustomers
            Func<IEnumerable<string>> getCustomers =
                () => new[] { expectedCustomer };

            Func<string, string> createReport = customer => expectedCustomer;

            Action<string> log = m => Console.WriteLine(m);

            // act
            Functional2.RunProcessing(log, getCustomers, createReport);

            // assert
            //Assert.Equal(expectedCustomer.Email, actualToAddress);
            //Assert.Equal(expectedReportBody, actualBody);
        }
    }
}
