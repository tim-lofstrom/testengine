using InterfaceManager;
using Models.Testplan;
using System;
using System.Collections.Generic;

namespace Testplan
{
    public class Testplan : ITestplan
    {
        public List<string> GetResources()
        {
            return new List<string>()
            {
                @"C:\Users\tim\source\repos\TestEngine\ResourceExample\bin\Debug\netcoreapp3.1\ResourceExample.dll"
            };
        }

        public TestMethod GetTestplan()
        {
            TestMethod root = new TestMethod("ResourceExample.TestmethodExample");
            return root;
        }
    }
}
