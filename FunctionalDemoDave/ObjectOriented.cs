namespace FunctionalDemoDave
{
    public static class ObjectOriented
    {
        static void Main()
        {
            // OO
            ILog log = new Log();
            // Dependency
            IProcessor processor = new Processor(log);
            // Argument
            processor.Do("file.csv");
        }
    }

    public class Processor : IProcessor
    {
        public Processor(ILog log) { }

        public void Do(string arg) { }
    }

    public class Log : ILog { }


    public interface ILog { }

    public interface IProcessor
    {
        void Do(string arg);
    }
}