using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    class Library
    {
        // Instance variables
        private List<Book> books = new List<Book>();

        // Properties
        public string name;

        // Constructors
        public Library(string libraryName)
		{
            name = libraryName;
        }

        public void AddBook(Book book)
		{
            books.Add(book);
        }

        public bool RemoveBook(int id)
		{
            bool bookId = books.Any(b => b.Id == id);

            if (bookId)
			{
                books.RemoveAll(b => b.Id == id);
                return true;
            }

            MessageBox.Show("Sorry, no book with the specified ID.");
            return false;
        }

        public Book GetBookById(int id)
		{
            bool bookId = books.Any(b => b.Id == id);

            if (bookId)
			{
                return books.First(x => x.Id == id);
			}
            return null;
        }

        public List<Book> GetAllBooks()
		{
            return books;
        }

		public List<Book> GetAvailableBooks()
		{
            List<Book> availableBooks = new List<Book>();

			foreach (Book book in books)
			{
				if (book.Borrowed == false)
				{
                    availableBooks.Add(book);
				}
			}
            return availableBooks;
        }

		public List<Book> GetBorrowedBooks()
		{
            List<Book> borrowedBooks = new List<Book>();

            foreach (Book book in books)
            {
                if (book.Borrowed == true)
                {
                    borrowedBooks.Add(book);
                }
            }
            return borrowedBooks;
        }
	}
}
