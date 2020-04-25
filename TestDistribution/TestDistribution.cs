using InterfaceManager;
using System;

namespace TestDistribution
{
    public class TestDistribution : ITestDistribution
    {
        public bool Download()
        {
            Console.WriteLine("Downloading files...");
            return true;
        }
    }
}
