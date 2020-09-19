using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplittingTheBill.Interfaces;
using System.Reflection;
using Ninject.Modules;
using Ninject;
using Ninject.Parameters;

namespace SplittingTheBill
{
    class Program
    {
        static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            //Set the parameter
            IParameter parameterFileReader = new ConstructorArgument("fileReader", kernel.Get<IFilereader>());
            var expenseCalculator = kernel.Get<ICalculateExpense>(parameterFileReader);


            Console.WriteLine("Enter Filename");
            var lineRead = Console.ReadLine();
            if (!string.IsNullOrEmpty(lineRead))
            {
                expenseCalculator.CalculateExpenses(lineRead);
            }
            else
            {
                Console.WriteLine("Filename Entered Invalid");
            }
        }
    }
}

