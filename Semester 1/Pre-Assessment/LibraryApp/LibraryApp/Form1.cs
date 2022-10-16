using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryApp
{
    public partial class Form1 : Form
    {
        //instance variables
        Library library;

		public static string fileSelected;
		public static string pathBackup = @"D:\TempBackup.txt";
		
		public Form1()
        {
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
			library = new Library("The Amazing Fontys Library");
			FileStream fs = new FileStream(pathBackup, FileMode.OpenOrCreate);
            fs.Close();

			updateOverviewTabPageUI();
            placeInLibrary();  
        }

        public void WriteFile(Book b)
		{
			FileStream fsTemp = new FileStream(pathBackup, FileMode.Append, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fsTemp);

			var typeToString = b.typeOfBook.ToString();

			bw.Write(b.Title);
			bw.Write(b.Author);
			bw.Write(typeToString);

			bw.Close();
		}

        private static List<Book> ReadFile()
        {
			List<Book> bookList = new List<Book>();

			FileStream fs = new FileStream(fileSelected, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);

			while (br.BaseStream.Position < br.BaseStream.Length)
			{
                string title = br.ReadString();
                string author = br.ReadString();
                string type = br.ReadString();
				BookType bookType = (BookType)Enum.Parse(typeof(BookType), type);

                bookList.Add(new Book(title, author, bookType));
			}

            br.Close();

            return bookList;
		}

        //method to load information into the UI in the Overview tab page
        private void updateOverviewTabPageUI()
        {
            lbLibrary.Items.Clear();
            lbLibrary.Items.Add(library.name);
        }

        private void placeInLibrary()
		{
            foreach (Book book in library.GetAllBooks())
            {
                lbLibrary.Items.Add(book.GetInfo());
                lbLibrary.Tag = book;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string type = String.Empty;
            if (rbtnProgramming.Checked)
            {
                type = Enum.GetName(typeof(BookType), BookType.PROGRAMMING);
            }
            else if (rbtnDatabase.Checked)
            {
                type = Enum.GetName(typeof(BookType), BookType.DATABASE);
            }
            else
            {
                type = Enum.GetName(typeof(BookType), BookType.MISCELLANEOUS);
            }

            BookType bookType = (BookType)Enum.Parse(typeof(BookType), type);

            //create the book object
            Book newBook = new Book(tbTitle.Text, tbAuthor.Text, bookType);


            //add new book to the backend
            library.AddBook(newBook);
			WriteFile(newBook);

            //update UIs
            updateOverviewTabPageUI();
            placeInLibrary();

        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            updateOverviewTabPageUI();
            placeInLibrary();
        }

        private void btnShowBooksThatAre_Click(object sender, EventArgs e)
        {
            updateOverviewTabPageUI();
            if (rbtnAvailable.Checked == true)
            {
                foreach (Book book in library.GetAvailableBooks())
                {
                    lbLibrary.Items.Add(book.GetInfo());
                    lbLibrary.Tag = book;
                }
            }
            if (rbtnBorrowed.Checked == true)
			{
                foreach (Book book in library.GetBorrowedBooks())
                {
                    lbLibrary.Items.Add(book.GetInfo());
                    lbLibrary.Tag = book;
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            library.RemoveBook(Convert.ToInt32(tbId.Text));
            updateOverviewTabPageUI();
            placeInLibrary();

            // Empty binary file
            FileStream fs2 = new FileStream(pathBackup, FileMode.Create, FileAccess.Write);
            BinaryWriter bw2 = new BinaryWriter(fs2);

            // Refill binary file
            foreach (Book b in library.GetAllBooks())
            {
                bw2.Close();
                WriteFile(b);
            }

            // Its stored in backup, so store it in test

            bw2.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            var returnBook = library.GetBookById(Convert.ToInt32(tbId.Text));

            // If id does not exist
            if (returnBook == null)
			{
                MessageBox.Show("Sorry, no book with the specified Id");
            }
            else
			{
                if (returnBook.Borrowed == false)
                {
                    MessageBox.Show("A book can't be returned if it is not borrowed.");
                }
                else
                {
                    returnBook.Borrowed = false;
                    MessageBox.Show(returnBook.BorrowerInfo + " has returned the book");

                    // Open form to add borrower info
                    returnBook.BorrowerInfo = "No info";
                }
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            var returnBook = library.GetBookById(Convert.ToInt32(tbId.Text));

            if (returnBook == null)
            {
                MessageBox.Show("Sorry, no book with the specified Id");
            }
            else
			{
                if (returnBook.Borrowed == true)
                {
                    MessageBox.Show("Sorry, this book has already been borrowed by someone else.");
                }
                else
                {
                    returnBook.Borrowed = true;

                    // Open form to add borrower info
                    BorrowForm borrowerInfoForm = new BorrowForm(returnBook);
                    borrowerInfoForm.ShowDialog();
                }
            }
        }

        private void lbLibrary_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (lbLibrary.SelectedIndex == -1)
            {
                btnBorrow.Enabled = false;
                btnReturn.Enabled = false;
            }
            else
            {
                btnBorrow.Enabled = true;
                btnReturn.Enabled = true;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
			ChooseFileLocation chooseLocationForm = new ChooseFileLocation();
			chooseLocationForm.ShowDialog();

            string ReturnValue = chooseLocationForm.ReturnValue;
			ReturnValue = chooseLocationForm.tbFileLocation.Text;

			if (ReturnValue == "")
            {
                MessageBox.Show("No location given. Data not saved.");
				File.WriteAllText(pathBackup, string.Empty);
			} 
            else
            {
				FileStream fsBackup = new FileStream(pathBackup, FileMode.Open);
                FileStream fsSaveFile = new FileStream(ReturnValue, FileMode.Create);
				fsBackup.CopyTo(fsSaveFile);
				fsBackup.Flush();
				fsBackup.Close();

				// Empty backup
				File.WriteAllText(pathBackup, string.Empty);
			}
		}

        private void btnGetData_Click(object sender, EventArgs e)
        {
			
			using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
				openFileDialog1.InitialDirectory = "c:\\";
				openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
				openFileDialog1.FilterIndex = 2;
				openFileDialog1.RestoreDirectory = true;

				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					FileStream fs = new FileStream(pathBackup, FileMode.Create);
                    fs.Close();
					
					fileSelected = openFileDialog1.FileName;

					// Loading in data from Binary File
					foreach (Book b in ReadFile())
					{
						library.AddBook(b);
						WriteFile(b);
					}

                    //update UIs
                    placeInLibrary();
				}
			}
		}
    }
}
