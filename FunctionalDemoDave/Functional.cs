using System;

namespace FunctionalDemoDave
{
    public static class Functional
    {
        private static void Main()
        {
            // Action is a delegate. Doesn't return a value
            // delegating to an anyonymous function
            //Action blah = () => Console.WriteLine("asdf");

            // Composition
            Action runProcessing = () => RunProcessing(Log);
            runProcessing();

            // Composition without Log method - passing Action (delegate)
            //Action rp2 = () => RunProcessing(m => Console.WriteLine(m));

            //Action runProcessing = Compose();
        }

        public static void RunProcessing(Action<string> log)
        {
            log("test");
        }

        public static void Log(string message)
        {
            Console.WriteLine("log: {0}", message);
        }

        //public static Action Compose()
        //{
        //    return () => RunProcessing(Log);
        //}
    }
}
