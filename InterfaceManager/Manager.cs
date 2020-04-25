using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InterfaceManager
{
    public static class Manager
    {
        public static ITestDistribution TestDistribution { get; set; }
        public static ITestplan Testplan { get; set; }

        public static void Initialize()
        {
            Testplan = (ITestplan)InitializeType(Settings.Instance.ITestplan, typeof(ITestplan));
            TestDistribution = (ITestDistribution)InitializeType(Settings.Instance.ITestDistribution, typeof(ITestDistribution));
        }

        private static object InitializeType(string typeString, Type initializeType)
        {
            var assembly = Assembly.LoadFrom(typeString);

            foreach (Type type in assembly.ExportedTypes)
            {
                if (type.GetInterfaces().Any(i => i == initializeType))
                {
                    return Activator.CreateInstance(type);
                }
            }

            return null;
        }
    }
}
