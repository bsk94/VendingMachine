using Microsoft.VisualStudio.TestTools.UnitTesting;
using VendingMachine;
using System;
using System.Collections.Generic;
using System.Text;

namespace VendingMachine.Tests
{
    [TestClass()]
    public class DrinkTests
    {
        [TestMethod()]
        public void ConstructorTest()
        {
            var testDrink = new Drink("Coffee;1");

            Assert.AreEqual("Coffee", testDrink.Name);
            Assert.AreEqual(1, testDrink.Price);
        }

        [TestMethod()]
        public void ReturnAsButtonTextTest()
        {
            var testDrink = new Drink("Espresso;8");

            Assert.AreEqual("Espresso  8zł", testDrink.ReturnAsButtonText());
        }
    }
}