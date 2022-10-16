using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApp
{
    public partial class BorrowForm : Form
    {
        private Book currentBook;
        public BorrowForm(Book book)
        {
            InitializeComponent();
            currentBook = book;

            lblBookInfo.Text = $"{"ID: " + currentBook.Id} {"Title: " + currentBook.Title} {"Author: " + currentBook.Id}, {"BookType: " + currentBook.typeOfBook}";
        }

        private void btnTryToBorrow_Click(object sender, EventArgs e)
        {
            currentBook.BorrowerInfo = tbBorrowerName.Text;
            MessageBox.Show("Successfully added " + currentBook.BorrowerInfo + " as the borrower of the book");
            this.Close();
        }
    }
}
