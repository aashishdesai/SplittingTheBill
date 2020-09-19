using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SplittingTheBill.Interfaces;

namespace SplittingTheBill
{
    public class TextFileWriter : IFilewriter
    {
        private string FileName { get; set; }

        public TextFileWriter(string fileName)
        {
            FileName = fileName;
        }

        public void WriteFile(IList<CampingTrip> trips)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), @"File\" + FileName + ".out");
            using (TextWriter tw = new StreamWriter(path))
            {
                foreach (CampingTrip trip in trips)
                {
                    WritePesonExpense(trip, tw);
                    tw.WriteLine("");
                }
            }
        }

        private void WritePesonExpense(CampingTrip trip, TextWriter tw)
        {
            for (var person = 1; person <= trip.NumberOfPeople; person++)
            {
                tw.WriteLine(trip.GetAmountOwedPerPerson(person) > 0 ? "$" + trip.GetAmountOwedPerPerson(person).ToString() : string.Format("(${0})", Math.Abs(trip.GetAmountOwedPerPerson(person)).ToString()));
            }
        }
    }
}
