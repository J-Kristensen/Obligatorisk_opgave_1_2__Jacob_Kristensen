using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Obligatorisk_opgave_1_2__Jacob_Kristensen
{
    public class BooksRepository
    {
        private List<Book> books = new List<Book>();
        private int nextId = 1;

        public BooksRepository() 
        {
            books.Add(new Book(nextId++, "Lord of the Rings", 50));;
            books.Add(new Book(nextId++, "Harry Potter", 100));
            books.Add(new Book(nextId++, "Hunger Games", 75));
            books.Add(new Book(nextId++, "The Hobbit", 25));
            books.Add(new Book(nextId++, "The Martian", 200));
        }
        /// <summary>
        /// Returns a list of books based on the price filter and order by
        /// </summary>
        /// <param name="Pricefilter">Used to filter the list by specific price</param>
        /// <param name="OrderBy">Used for sorting list by either Price or Title</param>
        /// <returns></returns>
        public List<Book> Get(int? Pricefilter = null,string? orderBy = null)
        {
            IEnumerable<Book> getBooks = new List<Book>(books);

            // Filter books by setting upper limit on price
            if (Pricefilter != null)
            {
                getBooks = getBooks.Where(b => b.Price < Pricefilter);
            }

            // Order by Title or Price
            if (orderBy != null)
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "title": 
                    case "title_asc":
                        getBooks = getBooks.OrderBy(m => m.Title);
                        break;
                    case "title_desc":
                        getBooks = getBooks.OrderByDescending(m => m.Title);
                        break;
                    case "price":
                    case "price_asc":
                        getBooks = getBooks.OrderBy(m => m.Price);
                        break;
                    case "price_desc":
                        getBooks = getBooks.OrderByDescending(m => m.Price);
                        break;
                    default:
                        break; // do nothing
                        throw new Exception("Unknown order by value: " + orderBy);
                }
            }

            return getBooks.ToList();
        }
        /// <summary>
        /// Returns a book that corresponds to the id parameter, if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Book Object</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Book? GetById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id must be greater than 0");
            }
            if (books.Exists(b => b.Id == id) == false)
            {
                return null;
            }
            return books.Find(b => b.Id == id);
        }
        /// <summary>
        /// Adds a New Book object to Repository and returns it
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Book Add(Book bookToAdd)
        {
            bookToAdd.ValidateBook();
            bookToAdd.Id = nextId++;
            books.Add(bookToAdd);
            return bookToAdd;
        }


        /// <summary>
        /// Deletes a Book object from Repository and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Book? Delete(int id)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id must be greater than 0");
            }
            if (books.Exists(b => b.Id == id) == false)
            {
                return null;
            }
            Book bookToDelete = books.Find(b => b.Id == id);
            books.Remove(bookToDelete);
            return bookToDelete;
        }

        /// <summary>
        /// Given a ID and a Book object, updates the Book object in the Repository and returns it
        /// </summary>
        /// <param name="id"></param>
        /// <param name="UpdatedBook"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Book? Update(int id, Book UpdatedBook)
        {
            if (id < 1)
            {
                throw new ArgumentOutOfRangeException("id must be greater than 0");
            }
            if (books.Exists(b => b.Id == id) == false)
            {
                return null;
            }
            UpdatedBook.ValidateBook();
            Book bookToUpdate = books.Find(b => b.Id == id);
            bookToUpdate.Title = UpdatedBook.Title;
            bookToUpdate.Price = UpdatedBook.Price;
            return bookToUpdate;

        }
    }

    }

