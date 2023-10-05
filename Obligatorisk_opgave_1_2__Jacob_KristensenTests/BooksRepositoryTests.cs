using Microsoft.VisualStudio.TestTools.UnitTesting;
using Obligatorisk_opgave_1_2__Jacob_Kristensen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Obligatorisk_opgave_1_2__Jacob_Kristensen.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {

        // Test to see if the GetById gets the correct book
        [TestMethod()]
        public void GetByIdSuccess()
        {
            BooksRepository GetByIdSuccess = new BooksRepository();

            Book Correct = new Book(1, "Lord of the Rings", 50);

            Book? gottenBook = GetByIdSuccess.GetById(1);

            Assert.AreEqual(Correct.ToString(), gottenBook.ToString());
        }
        
        [TestMethod()]
        public void GetByIdFail()
        {
            BooksRepository GetByIdFail = new BooksRepository();
            Book Correct = new Book(1, "Lord of the Rings", 50);
            Book? gottenBook = GetByIdFail.GetById(2);
            Assert.AreNotEqual(Correct.ToString(), gottenBook.ToString());
        }
        // see if exception is thrown when id is 0
        [TestMethod()]
        public void GetIdZero()
        {
            BooksRepository GetIdDoesntExist = new BooksRepository();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => GetIdDoesntExist.GetById(0));
        }
        // See if Null is returned when id doesnt exist
        [TestMethod()]
        public void GetIdDoesntExist()
        {
            BooksRepository GetIdDoesntExist = new BooksRepository();
            Assert.IsNull(GetIdDoesntExist.GetById(100));
            
        }

        // Add a book to the list and return the book
        [TestMethod()]
        public void AddBook()
        {
            BooksRepository AddBook = new BooksRepository();
            Book book = new Book(8, "The Hunger Games", 50);
            Assert.AreEqual(AddBook.Add(book), book);
        }

        // Delete a book from the repository and return the book
        [TestMethod()]
        public void DeleteBookSuccess()
        {
            BooksRepository DeleteBook = new BooksRepository();
            Book book = new Book(6, "The Hunger Games", 50);
            DeleteBook.Add(book);
            Assert.AreEqual(DeleteBook.Delete(6), book);
        }
        // Test to see if the Delete method throws an exception when the id is too low
        [TestMethod()]
        public void DeleteBookFailIdTooLow()
        {
            BooksRepository DeleteBook = new BooksRepository();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => DeleteBook.Delete(0));
        }
        // Test to see if the Delete method throws an exception when the id doesnt exist
        [TestMethod()]
        public void DeleteBookFailIdDoesntExist()
        {
            BooksRepository DeleteBook = new BooksRepository();
            Assert.IsNull (DeleteBook.Delete(110));
        }




        }
    }
