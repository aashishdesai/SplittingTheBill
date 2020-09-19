using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Ninject;
using SplittingTheBill.Interfaces;

namespace SplittingTheBill
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICalculateExpense>().To<TripExpense>();
            Bind<IFilereader>().To<TextFileReader>();
        }
    }
}
