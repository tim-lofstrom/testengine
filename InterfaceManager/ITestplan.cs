using Models.Testplan;
using System;
using System.Collections.Generic;

namespace InterfaceManager
{
    public interface ITestplan
    {
        TestMethod GetTestplan();
        List<string> GetResources();
    }
}
