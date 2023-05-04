using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {

        public class FilterObject
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public int? Isbn { get; set; }
            public DateTime? Date { get; set; }

        }
        public abstract class Book
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public int Isbn { get; set; }
            public DateTime? Date { get; set; }

        }
        public class Fictionbook : Book
        {
            public string Ganre { get; set; }

        }
        public class NonFictionBook : Book
        {
            public string Ganre { get; set; }
        }

        public class library<TBook, TUser> where TBook : Book
        {

            private List<TBook> _books;
            private Dictionary<string, TUser> _user;
            public library()
            {
                _books = new List<TBook>();
                _user = new Dictionary<string, TUser>();
            }

            public void EddBook(TBook book)
            {

                foreach (var item in _books)
                {

                    if (_books.Equals(book))
                    {
                        Console.WriteLine("whe alredy have this book");
                    }
                    else
                    {
                        _books.Add(book);
                        Console.WriteLine("Done");
                    }
                }
            }
            public void EddUser(string Name, TUser user)
            {
                if (_user.Values.Equals(user))
                {
                    Console.WriteLine("you alredy are user");
                }
                else
                {
                    _user.Add(Name, user);
                }
            }

            public void DeleteUser(string name, TUser user)
            {
                if (_user.Values.Contains(user))
                {
                    _user.Remove(name);
                }
                else
                {
                    _user.Add(name, user);
                }
            }
            public void FilterBook(FilterObject filter)
            {

                if (!string.IsNullOrEmpty(filter.Name))
                {
                    _books = _books.Where(b => b.Name == filter.Name).ToList();
                    foreach (var item in _books)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (!string.IsNullOrEmpty(filter.Author))
                {
                    _books = _books.Where(x => x.Author == filter.Author).ToList();
                    foreach (var item in _books)
                    {
                        Console.WriteLine(item);
                    }
                }
                else if (!string.IsNullOrEmpty(filter.Date.ToString()))
                {
                    _books = _books.Where(x => x.Author == filter.Date.ToString()).ToList();
                    foreach (var item in _books)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Console.WriteLine("0 book");
                }
            }
        }
        public class User
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
        };
        static void Main(string[] args)
        {
            var NonFictionBook = new NonFictionBook();
            var User = new User();
            var library = new library<NonFictionBook, User>();
        }
    }
}