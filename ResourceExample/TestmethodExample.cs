using Interfaces;
using System;

namespace ResourceExample
{
    public class TestmethodExample : ITestmethod
    {
        public TestmethodExample()
        {
        }

        public bool Run()
        {
            Console.WriteLine("Running");

            return true;
        }
    }
}
