using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryApp
{
    public enum BookType { PROGRAMMING, DATABASE, MISCELLANEOUS }

    public class Book
    {
        // Instance Variable
        private static int idSeeder = 99;
        public int id;
        private string title;
        private string author;
        private BookType bookType;
        private string borrowerInfo;
        private bool borrowed;

        // Properties
        public int Id { get{return id;} }
        public string Title { get{return title;} }
        public string Author { get{return author;} }
        public BookType typeOfBook { get{return bookType; } }
        public string BorrowerInfo { 
            get 
            {
                return borrowerInfo;
            }
            set
            {
                borrowerInfo = value;
            }
        }
        public bool Borrowed 
        {
			get
			{
				return borrowed;
			}
			set
			{
				borrowed = value;
			}
		}

        // Constructor
        public Book(string bookTitle, string bookAuthor, BookType TypeOfBook)
        {
            id = Interlocked.Increment(ref idSeeder);
            title = bookTitle;
            author = bookAuthor;
            bookType = TypeOfBook;
            Borrowed = false;
        }

        // Returns information about the book-item
        public string GetInfo()
		{
            if (Borrowed == false)
			{
                return $"{"ID: " + id} {"Title: " + title} {"Author: " + author}, {"BookType: " + bookType}";
            }
            else
			{
                return $"{"ID: " + id} {"Title: " + title} {"Author: " + author}, {"BookType: " + bookType}, {"Borrowed by: " + BorrowerInfo}";
            }
		}
    }
}
