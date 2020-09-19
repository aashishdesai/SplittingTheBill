using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplittingTheBill.Interfaces
{
    interface ICalculateExpense
    {
        void CalculateExpenses(string lineRead);
    }
}
