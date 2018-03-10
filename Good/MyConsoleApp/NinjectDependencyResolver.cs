using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
using ConsoleManager;

namespace MyConsoleApp
{
    public class NinjectDependencyResolver : NinjectModule
    {
        public override void Load()
        {
            Bind<IConsoleManager>().To<ConsoleManager.ConsoleManager>();
        }
    }
}
