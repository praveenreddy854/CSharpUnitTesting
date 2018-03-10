using ConsoleManager;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp.Tests
{
    [TestFixture]
    public class ProgramManagerTests
    {
        #region Fields
        private ConsoleManagerStub consoleManager = null;
        private ProgramManager programManager = null;
        #endregion

        [SetUp]
        public void SetUp()
        {
            consoleManager = new ConsoleManagerStub();
            programManager = new ProgramManager(consoleManager);
        }

        [TearDown]
        public void TearDown()
        {
            programManager = null;
            consoleManager = null;
        }

        [TestCase("Ahmed Tarek")]
        [TestCase("")]
        [TestCase(" ")]
        public void RunWithInputAs1AndName(string name)
        {
            consoleManager.UserInputs.Enqueue("1");
            consoleManager.UserInputs.Enqueue(name);
            consoleManager.UserInputs.Enqueue(new ConsoleKeyInfo());

            List<string> expectedOutput = new List<string>();
            expectedOutput.Add("Welcome to my console app\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: ");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 1\r\nPlease enter your name: " + name + "\r\nHello " + name +"\r\n\r\nPress any key to exit... ");

            consoleManager.OutputsUpdated += (int outputEntryNumber) => {
                Assert.AreEqual(expectedOutput[outputEntryNumber - 1], consoleManager.ToString());
            };

            programManager.Run(new string[] { });
        }

        [TestCase("Ahmed Tarek")]
        [TestCase("")]
        [TestCase(" ")]
        public void RunWithInputAs2AndName(string name)
        {
            consoleManager.UserInputs.Enqueue("2");
            consoleManager.UserInputs.Enqueue(name);
            consoleManager.UserInputs.Enqueue(new ConsoleKeyInfo());

            List<string> expectedOutput = new List<string>();
            expectedOutput.Add("Welcome to my console app\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: ");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: ");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\nGoodbye " + name + "\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\nGoodbye " + name + "\r\n\r\n");
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: 2\r\nPlease enter your name: " + name + "\r\nGoodbye " + name + "\r\n\r\nPress any key to exit... ");

            consoleManager.OutputsUpdated += (int outputEntryNumber) => {
                Assert.AreEqual(expectedOutput[outputEntryNumber - 1], consoleManager.ToString());
            };

            programManager.Run(new string[] { });
        }

        [Test]
        public void RunShouldKeepTheMainMenuWhenInputIsNeither1Nor2()
        {
            consoleManager.UserInputs.Enqueue("any invalid input 1");
            consoleManager.UserInputs.Enqueue("any invalid input 2");
            consoleManager.UserInputs.Enqueue("Exit");

            List<string> expectedOutput = new List<string>();
            // initital menu
            expectedOutput.Add("Welcome to my console app\r\n"); // outputEntryNumber 1
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n"); // outputEntryNumber 2
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n"); // outputEntryNumber 3
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n"); // outputEntryNumber 4
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: "); // outputEntryNumber 5
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: any invalid input 1\r\n"); // outputEntryNumber 6

            // after first trial
            expectedOutput.Add(""); // outputEntryNumber 7
            expectedOutput.Add("Welcome to my console app\r\n"); // outputEntryNumber 8
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n"); // outputEntryNumber 9
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n"); // outputEntryNumber 10
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n"); // outputEntryNumber 11
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: "); // outputEntryNumber 12
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: any invalid input 2\r\n"); // outputEntryNumber 13

            // after second trial
            expectedOutput.Add(""); // outputEntryNumber 14
            expectedOutput.Add("Welcome to my console app\r\n"); // outputEntryNumber 15
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n"); // outputEntryNumber 16
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n"); // outputEntryNumber 17
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\n"); // outputEntryNumber 18
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: "); // outputEntryNumber 19
            expectedOutput.Add("Welcome to my console app\r\n[1] Say Hello?\r\n[2] Say Goodbye?\r\n\r\nPlease enter a valid choice: Exit\r\n"); // outputEntryNumber 20

            consoleManager.OutputsUpdated += (int outputEntryNumber) => {
                if ((outputEntryNumber - 1) < expectedOutput.Count)
                {
                    Assert.AreEqual(expectedOutput[outputEntryNumber - 1], consoleManager.ToString());
                }
            };

            programManager.Run(new string[] { });
        }
    }
}
