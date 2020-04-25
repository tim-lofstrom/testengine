using InterfaceManager;
using Interfaces;
using Models.Testplan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestEngine
{
    class Program
    {
        public static List<Assembly> Assemblies { get; private set; } = new List<Assembly>();

        static void Main(string[] args)
        {
            Console.WriteLine("Test Engine Starting");

            Manager.Initialize();

            Console.WriteLine("Test Engine Initialized");

            Manager.TestDistribution.Download();

            Console.WriteLine("Test Engine Downloaded Files");

            List<string> resources = Manager.Testplan.GetResources();

            Console.WriteLine("Test Engine Loading Resources");

            InitializeResources(resources);

            TestMethod testMethod = Manager.Testplan.GetTestplan();

            Console.WriteLine("Test Engine Executing Testplan");

            Execute(testMethod);

        }

        private static void InitializeResources(List<string> resources)
        {
            foreach (string resource in resources)
            {
                Assembly assembly = Assembly.LoadFrom(resource);
                Assemblies.Add(assembly);
            }
        }

        private static void Execute(TestMethod testMethod)
        {
            ExecuteSingle(testMethod);

            foreach (TestMethod child in testMethod.TestMethods)
            {
                Execute(child);
            }
        }

        private static void ExecuteSingle(TestMethod testMethod)
        {
            ITestmethod tm = ResolveTestmethod(testMethod.Classname);
            tm.Run();
        }

        private static ITestmethod ResolveTestmethod(string classname)
        {
            foreach (Assembly assembly in Assemblies)
            {
                foreach (Type type in assembly.ExportedTypes)
                {
                    if (type.GetInterfaces().Any(i => i == typeof(ITestmethod)) &&
                        type.FullName.Equals(classname))
                    {
                        return (ITestmethod)Activator.CreateInstance(type);
                    }
                }
            }

            return null;
        }
    }
}
