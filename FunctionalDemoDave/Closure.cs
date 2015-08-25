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
            //string x = DoSomething().Invoke();
            //Console.Out.WriteLine($"x is {x}");

            // Action is a delegate which doesn't return a value
            //Action action = CreateAction();

            ////Here we can see that the action returned by CreateAction still has access to the counter variable,
            ////and can indeed increment it, even though CreateAction itself has finished.
            //action();
            //action();

            // Func with an input of int, delegating to a function, 
            // returning an int

            // setting up state of function
            //Func<int, int> fn2 = GetMultiplier(2);

            ////var fn3 = GetMultiplier(3);
            //Console.WriteLine(fn2(2));  //outputs 4
            //Console.WriteLine(fn2(3));  //outputs 6
            //Console.WriteLine(fn3(2));  //outputs 6
            //Console.WriteLine(fn3(3));  //outputs 9

            //Action a = GiveMeAction();
            //a(); // i = 1
            //a(); // i = 2
            //a();

            // A delegate that accepts a string and returns a string
            //Func<string, string> myFunc = delegate (string var1)
            //{
            //    return "some value";
            //};

            //string myVar = myFunc("something");
            //Console.Out.WriteLine($"myVar is {myVar}");
            var inc = GetAFunc();
            Console.WriteLine(inc(5));
            Console.WriteLine(inc(6));
        }

        // returns a function which takes a int and returns an int
        public static Func<int, int> GetAFunc()
        {
            var myVar = 1;
            Func<int, int> inc = delegate (int i)
            {
                myVar++;
                return i + myVar;
            };
            return inc;
        }

        static Action GiveMeAction()
        {
            Action ret = null;
            int i = 0;
            ret += delegate
            {
                Console.Out.WriteLine("First method " + i++);
            };

            ret += delegate
            {
                Console.Out.WriteLine("Second method " + i++);
            };
            // Returning a chain of delegates
            return ret;
        }

        static Func<int, int> GetMultiplier(int a)
        {
            int multiplier = a;
            Func<int, int> multiplierFunction = delegate(int b)
            {
                return multiplier * b;
            };
            return multiplierFunction;
        }

        //static Action CreateAction()
        //{
        //    int counter = 0;
        //    Action a = delegate
        //    {
        //        counter++;
        //        Console.WriteLine("counter={0}", counter);
        //    };
        //    return a;
        //}

        //static Action CreateAction()
        //{
        //    int counter = 0;
        //    return delegate
        //    {
        //        // Yes, it could be done in one statement; 
        //        // but it is clearer like this.
        //        counter++;
        //        Console.WriteLine("counter={0}", counter);
        //    };
        //}

        //static Func<string> DoSomething()
        //{
        //    string thing = "asdf";
        //    Func<string> getThingFunction = () => thing;
        //    return getThingFunction;
        //}
    }
}
