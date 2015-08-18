using System;

namespace FunctionalDemoDave
{
    public static class ObjectOriented
    {
        static void Main()
        {
            var processor = CompositionRoot.Compose();
            processor.RunProcessing("file.csv");
        }
    }

    public static class CompositionRoot
    {
        public static Processor Compose()
        {
            ILogger log = new Logger();
            Processor processor = new Processor(log);
            return processor;
        }
    }

    public class Processor : IProcessor
    {
        private readonly ILogger _log;
        public Processor(ILogger log)
        {
            _log = log;
        }

        public void RunProcessing(string arg)
        {
            _log.Log("test");
        }
    }

    public interface IProcessor
    {
        void RunProcessing(string arg);
    }

    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("log: {0}", message);
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

   
}