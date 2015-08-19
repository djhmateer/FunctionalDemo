using System;
using System.Collections.Generic;

namespace FunctionalDemoDave
{
    public static class Functional2
    {
        private static void Main()
        {
            Action runProcessing = () => RunProcessing(Log, GetCustomers, CreateReport);
            runProcessing();
        }

        public static void RunProcessing(
            Action<string> log,
            Func<IEnumerable<string>> getCustomers,
            Func<string, string> createReport)
        {
            log("test");
            var customers = getCustomers();
            foreach (var customer in customers)
            {
                log(customer);
                var report = createReport(customer);
                log(report);
            }
        }

        public static string CreateReport(string customerName)
        {
            return customerName + " done!";
        }

        public static IEnumerable<string> GetCustomers()
        {
            yield return "dave";
            yield return "bob";
            yield return "alice";
        }

        public static void Log(string message)
        {
            Console.WriteLine("log: {0}", message);
        }
    }
}
