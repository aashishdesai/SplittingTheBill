using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SplittingTheBill;
using SplittingTheBill.Interfaces;
using System.Collections.Generic;

namespace SplittingTheBillUnitTests
{
    [TestClass]
    public class TripExpenseTests
    {
        [TestMethod]
        public void CalculateExpenses_ShouldInvokeReadFile_WhenReadLine()
        {
            //Arrange
            IList<CampingTrip> trips = new List<CampingTrip>();
            var fileReader = new Mock<IFilereader>();
            fileReader.Setup(x => x.ReadFile(It.IsAny<string>())).Returns(trips);

            //Act
            var expenseCalculator = new TripExpense(fileReader.Object);
            expenseCalculator.CalculateExpenses("anystring");

            //Assert
            fileReader.Verify(m => m.ReadFile(It.IsAny<string>()), Times.Once());

        }
    }
}
