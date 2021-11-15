using Microsoft.VisualStudio.TestTools.UnitTesting;
using mak1;
using System;
using System.Collections.Generic;
using System.Text;

namespace mak1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void CalculateTestPlus()
        {

            double n1 = 5;


            string operation = "+";


            double n2 = 7;

            double expected = 12;

            double actual = Calculator.Calculate(n1, n2, operation); //Проверяет, равны ли указанные объекты, и выдает исключение, если два объекта не равны.




            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CalculateTestMinus()
        {

            double n1 = 12;


            string operation = "-";


            double n2 = 7;

            double expected = 5;

            double actual = Calculator.Calculate(n1, n2, operation);

            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CalculateTestUmnojenie()
        {

            double n1 = 5;


            string operation = "*";


            double n2 = 5;

            double expected = 25;

            double actual = Calculator.Calculate(n1, n2, operation);




            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void CalculateTestDelenie()
        {

            double n1 = 10;


            string operation = "/";


            double n2 = 2;

            double expected = 5;

            double actual = Calculator.Calculate(n1, n2, operation);




            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        [ExpectedException (typeof(DivideByZeroException))]
        public void CalculateTestDelenieNaNull()
        {

            double n1 = 10;


            string operation = "/";
            

            double n2 = 0; 
            

            

            double actual = Calculator.Calculate(n1, n2, operation);




            
        }
    }
}
