using Discount;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class CalculactionUnitTest
    {
        [TestMethod]
        public void Count4_Cost1150()
        {
            int result = 7;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(4, 1150);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Count8_Cost2370()
        {
            int result = 14;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(8, 2370);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Count11_Cost2642()
        {
            int result = 20;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(11,2642);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Count25_Cost5674()
        {
            int result = 26;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(25, 5674);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void Count3_Cost600()
        {
            int result = 6;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(3, 600);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void WrongCount()
        {
            int result = -1;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(-2, 2642);

            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void WrongCost()
        {
            int result = -1;

            DiscountCalculation calc = new DiscountCalculation();
            int actual = calc.GetDiscount(5, -2456);

            Assert.AreEqual(result, actual);
        }
    }
}
