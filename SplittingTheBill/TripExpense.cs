using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplittingTheBill.Interfaces;

namespace SplittingTheBill
{
    public class TripExpense : ICalculateExpense
    {
        static string filePath;
        private IFilereader FileReader { get; set; }
        private IFilewriter FileWriter { get; set; }

        public TripExpense(IFilereader fileReader)
        {
            FileReader = fileReader;
        }

        public void CalculateExpenses(string lineRead)
        {
            try
            {
                filePath = lineRead;

                var campingTrips = FileReader.ReadFile(filePath);
                if (campingTrips != null && campingTrips.Count > 0)
                {
                    FileWriter = new TextFileWriter(filePath);
                    FileWriter.WriteFile(campingTrips);
                }
                else
                {
                    Console.WriteLine("No trips found in file or file not found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error processing file");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
