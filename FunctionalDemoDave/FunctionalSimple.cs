using System;

namespace FunctionalDemoDave
{
    public static class Functional
    {
        // Action is a delegate. Doesn't return a value
        // delegating to an anyonymous function
        // Action blah = () => Console.WriteLine("asdf");

        // Composition passing Action (delegate)
        // Action rp2 = () => RunProcessing(m => Console.WriteLine(m));

        // Action runProcessing = Compose();

        // Composition
        // Lambda expression is an anonymous function/delegate
        //    method with no declaration

        // What are we closing over / closure?

        private static void Main()
        {
            // Action is a delegate.  Doesn't return a value.  Delegating to an anonymous method
            Action runProcessing = () => RunProcessing(Log);
            runProcessing();
        }

        public static void RunProcessing(Action<string> log)
        {
            log("test");
        }

        public static void Log(string message)
        {
            Console.WriteLine("log: {0}", message);
        }
    }
}
