using System;

namespace FunctionalDemoDave
{
    public static class Functional
    {
        static void Main()
        {
            // Action takes parameters but doesn't return
            // () is a lambda..
            Action note = () => Console.WriteLine("hello");
            // an anonymous method
            Action note2 = delegate { Console.WriteLine("hello"); };
            // lambda
            Action note3 = () => Note3();
            // or named static method which returns void
            Action note4 = Note3;

            // taking a parameter
            Action<string> log = message => Console.WriteLine("action alert: {0}", message);
            log("here");

            // anonymous method
            Action<string> log2 = delegate(string x) { Console.WriteLine("action alert: {0}", x); };

            Action<string> log3 = message => Log3(message);
            log3("log3 test");

            // method group (don't need to pass message as its implied)
            Action<string> log4 = Log3;
            log4("log4 test");






            // How to give ILog dependency at composition time
            // and argument where it is required in application logic?

            //var log = new Log();

            //Action asdf = () => Asdf(arg => DoProcessing(log, arg));
            //DoProcessing(new Log(), "file.csv");
        }

        private static void Log3(string x)
        {
            Console.WriteLine("action alert: {0}", x);
        }

        private static void Note3()
        {
            Console.WriteLine("hello");
        }

        // Dependencies and method arguments are arguments applied at different times
        //public static void DoProcessing(ILog log, string arg)
        //{ }
    }


}
