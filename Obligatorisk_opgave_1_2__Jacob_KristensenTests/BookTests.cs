using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_opgave_1_2__Jacob_Kristensen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_opgave_1_2__Jacob_Kristensen.Tests
{
    [TestClass()]
    public class BookTests
    {
        /// <summary>
        /// Test to see if the ToString method returns the correct string
        /// </summary>
        [TestMethod()]
        public void ToStringTest()
        {
            Book ToStringBook = new Book(1,"Lord of the Rings", 50);
            Assert.AreEqual("Id: 1, Title: Lord of the Rings, Price: 50", ToStringBook.ToString());
        }


        /// <summary>
        /// Test to see if a title value is set correctly
        /// </summary>
        [TestMethod()]
        public void ValidateTitleTestCorrect()
        {
            Book ValidateTitleBook = new Book(1, "Lord of the Rings", 50);

            Assert.AreEqual("Lord of the Rings", ValidateTitleBook.Title);

            Assert.IsFalse(ValidateTitleBook.Title == "Hunger Games");  
        }



        /// <summary>
        /// Test to show that the ValidateTitle method throws an exception when the title is null
        /// </summary>
        [TestMethod()]
        public void ValidateTitleTestTooShort()
        {
            Book ValidateTitleBook = new Book(1, "H", 50);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ValidateTitleBook.ValidateTitle());
        }


        /// <summary>
        /// Test to show that the ValidateTitle method throws an exception when the title is null
        /// </summary>
        [TestMethod()]
        public void ValidateTitleTestNull()
        {
            Book ValidateTitleBook = new Book();
            ValidateTitleBook.Title = null;
            ValidateTitleBook.Id = 1;
            ValidateTitleBook.Price = 50;
            Assert.ThrowsException<ArgumentNullException>(() => ValidateTitleBook.ValidateTitle());
        }

        /// <summary>
        /// Test to see if the price value is set correctly
        /// </summary>
        [TestMethod()]
        public void ValidatePriceTestCorrect()
        {
            Book ValidatePriceBook = new Book(1, "Lord of the Rings", 50);
            Assert.AreEqual(50, ValidatePriceBook.Price);
            Assert.IsFalse(ValidatePriceBook.Price == 100);
        }



        /// <summary>
        /// Runs test with edge cases to see if the price value is set correctly
        /// </summary>
        [TestMethod()]
        public void PriceEdgeCases()
        {
            Book PriceEdgeCasesBook = new Book(1, "Lord of the Rings", 0);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => PriceEdgeCasesBook.ValidatePrice());
            Assert.IsFalse(PriceEdgeCasesBook.Price == 1);
            Book PriceEdgeCasesBook2 = new Book(1, "Lord of the Rings", 1200);
            PriceEdgeCasesBook2.ValidatePrice();
            Assert.AreEqual(1200, PriceEdgeCasesBook2.Price);
            Assert.IsFalse(PriceEdgeCasesBook2.Price == 1201);
        }

        
        /// <summary>
        /// Runs test with negative value to see if the ValidatePrice method throws an exception using edge cases. 
        /// </summary>
        [TestMethod()]
        public void ValidatePriceTestTooLow()
        {
            Book ValidatePriceBook = new Book(1, "Lord of the Rings", -1);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ValidatePriceBook.ValidatePrice());
        }


        /// <summary>
        /// Runs test with value above 1200 to see if the ValidatePrice method throws an exception
        /// </summary>
        [TestMethod()]
        public void ValidatePriceTestTooHigh()
        {
            Book ValidatePriceBook = new Book(1, "Lord of the Rings", 1201);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => ValidatePriceBook.ValidatePrice());
        }
       
      /// Given that ValidateBook only consists of the two methods ValidateTitle and ValidatePrice, which have been tested, there is currently not a seperate test for this method.


       
    }
}