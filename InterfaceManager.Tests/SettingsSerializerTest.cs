using NUnit.Framework;
using System.IO;

namespace InterfaceManager.Tests
{
    public class SettingsSerializerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Serialize()
        {
            string tp = "../../../../Testplan/bin/Debug/netstandard2.0/Testplan.dll";
            string tpPath = Path.GetFullPath(tp);
            if (!File.Exists(tpPath))
            {
                throw new System.Exception("Path do not exist");
            }


            Settings.Instance.ITestplan = tpPath; 

            string dist = "../../../../TestDistribution/bin/Debug/netstandard2.0/TestDistribution.dll"; ;
            string distPath = Path.GetFullPath(dist);

            if(!File.Exists(distPath))
            {
                throw new System.Exception("Path do not exist");
            }
            Settings.Instance.ITestDistribution = distPath;

            Settings.Instance.Save();
            
            Assert.Pass();
        }
    }
}