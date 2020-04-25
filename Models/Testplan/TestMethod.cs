using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Testplan
{
    public class TestMethod
    {
        public string Classname { get; set; }

        public List<TestMethod> TestMethods { get; set; }

        public TestMethod(string classname)
        {
            Classname = classname;
            TestMethods = new List<TestMethod>();
        }
    }
}
