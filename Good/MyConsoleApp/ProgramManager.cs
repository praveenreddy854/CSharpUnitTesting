using ConsoleManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyConsoleApp
{
    public class ProgramManager
    {
        #region Fields
        private IConsoleManager consoleManager = null;
        #endregion

        #region Constructors
        public ProgramManager(IConsoleManager consoleManager)
        {
            this.consoleManager = consoleManager;
        }
        #endregion

        #region Methods
        public void Run(string[] args)
        {
            string input = string.Empty;

            do
            {
                consoleManager.WriteLine("Welcome to my console app");
                consoleManager.WriteLine("[1] Say Hello?");
                consoleManager.WriteLine("[2] Say Goodbye?");
                consoleManager.WriteLine("");
                consoleManager.Write("Please enter a valid choice: ");

                input = consoleManager.ReadLine();

                if (input == "1" || input == "2")
                {
                    consoleManager.Write("Please enter your name: ");
                    string name = consoleManager.ReadLine();

                    if (input == "1")
                    {
                        consoleManager.WriteLine("Hello " + name);
                    }
                    else
                    {
                        consoleManager.WriteLine("Goodbye " + name);
                    }

                    consoleManager.WriteLine("");
                    consoleManager.Write("Press any key to exit... ");
                    consoleManager.ReadKey();
                }
                else
                {
                    consoleManager.Clear();
                }
            }
            while (input != "1" && input != "2" && input != "Exit");
        }
        #endregion
    }
}
