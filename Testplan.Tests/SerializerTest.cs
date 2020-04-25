using Models.Testplan;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Testplan.Tests
{
    public class SerializerTest
    {

        [Test]
        public void SerializeTest()
        {
            TestMethod testMethod = new TestMethod("Ericsson.TM.TestMethod");
            testMethod.TestMethods.Add(new TestMethod("Ericssom.TM.Child"));

            string serialized = JsonConvert.SerializeObject(testMethod);

            Assert.Pass();
        }
    }
}