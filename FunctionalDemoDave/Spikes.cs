using System;

namespace FunctionalDemoDave
{
    public static class Spikes
    {
        static void Main()
        {
            // Action is a delegate. Doesn't return a value
            // lambda expression - an anonymous function/delegate..method with no declaration
            Action note = () => Console.WriteLine("hello");
            note();
            // an anonymous method
            Action note2 = delegate { Console.WriteLine("hello"); };
            // lambda
            Action note3 = () => Note3();
            // method group
            Action note4 = Note3;

            // taking a parameter
            Action<string> log = message => Console.WriteLine("action alert: {0}", message);
            log("here");

            // anonymous method
            Action<string> log2 = delegate(string x) { Console.WriteLine("action alert: {0}", x); };

            Action<string> log3 = message => Log3(message);
            log3("log3 test");

            // method group
            Action<string> log4 = Log4;
            log4("log4 test");
        }

        private static void Log4(string x)
        {
            Console.WriteLine("action alert: {0}", x);
        }

        private static void Log3(string x)
        {
            Console.WriteLine("action alert: {0}", x);
        }

        private static void Note3()
        {
            Console.WriteLine("hello");
        }
    }
}
