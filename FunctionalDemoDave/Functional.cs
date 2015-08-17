using System;

namespace FunctionalDemoDave
{
    public static class Functional
    {
        static void Main()
        {
            Console.WriteLine("Hello world functional");
            // Functional
            DoProcessing(new Log(), "file.csv");
        }

        // Dependencies and method arguments are arguments applied at different times
        public static void DoProcessing(ILog log, string arg)
        { }
    }
}
