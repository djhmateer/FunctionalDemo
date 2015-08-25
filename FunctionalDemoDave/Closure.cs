using System;
using System.Collections.Generic;

namespace FunctionalDemoDave
{
    public static class Closure
    {
        private static void Main()
        {
            Console.Out.WriteLine("Closure test");

            // this is creating a closure
            // we are creating a Function that returns a string
            // not acutally running it.  
            // so when this goes out of scope (ie if we return IEnumerable<Customer> from Functional test
            // will exptectedCustomer still be first@sea.com?? yes
            // because the variable has been closed over.
            //Func<string> x = DoSomething();
            string x = DoSomething().Invoke();

            Console.Out.WriteLine($"x is {x}");
        }

        static Func<string> DoSomething()
        {
            string thing = "asdf";
            Func<string> getThingFunction = () => thing;
            return getThingFunction;
        }
    }
}
