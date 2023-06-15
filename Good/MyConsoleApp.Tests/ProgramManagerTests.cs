
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;

namespace MyConsoleApp.Tests
{
    [TestClass]
    public class ProgramManagerTests
    {
        
        [TestMethod]
        public void SampleTest()
        {
            // Deserialize People.json file to Array of Person
            Person[] people = JsonConvert.DeserializeObject<Person[]>(File.ReadAllText("./People.json"));
        }

    }
}
