using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Davaleba
{
    public class Book
    {
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public int Isbn { get; set; }
        public int BookCreateDate { get; set; }
    }

    class FictionBook : Book
    {
        public int Ganre { get; set; }
    }

    class NonFictionBook : Book
    {
        public int Ganre { get; set; }
    }


    public class Library<T>
    {
        public Library(User user, Book book)
        {
            Users = new List<User>();
            Books = new List<Book>();
            Users.Add(user);
            Books.Add(book);
        }
        public Library(User[] user, Book[] book)
        {
            Users = user.ToList();
            Books = book.ToList();
        }

        public List<User> Users { get; set; }
        public List<Book> Books { get; set; }


        public bool AddUser(User user)
        {
            if (Users.Contains(user))
            {
                return false;
            }
            else
            {
                Users.Add(user);
                return true;
            }
        }


        public void Addbook(Book book, User user)
        {
            if (AddUser(user) == false)
            {


                foreach (var item in Books)
                {

                    if (book.Equals(item))
                    {
                        Console.WriteLine("whe alredy have this book");
                    }
                    else
                    {
                        Books.Add(book);
                        Console.WriteLine("book added");
                    }
                }

            }
            else
            {
                AddUser(user);
                Console.WriteLine("user alredy added");
                Addbook(book, user);
            }
        }
    }
    public class User
    {
        public string UserName { get; set; }
        public string Pasword { get; set; }
        public string Email { get; set; }
    }




    class Program
    {
        static void Main(string[] args)
        {
            var user = new User[] {
            new User{UserName="beka",Pasword="123",Email="112"}
            };


            Book[] book = new Book[] {
                new Book{ BookAuthor="book",BookName="123",BookCreateDate=12,Isbn=12}
            };

            var library = new Library<string>(user, book);
        }
    }


}