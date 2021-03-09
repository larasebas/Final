using Microsoft.EntityFrameworkCore;
using MidTerm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MidTerm
{
    public class BookStoreFunctions
    {
        public static List<Book> GetBookBytitle(string title)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.Where(x => x.BookTitle == title).ToList();
            }
        }

        public static Book GetBookById(int id)
        {
            using (var context = new SE407_BookStoreContext())
            {
                return context.Books.Find(id);
            }
        }

        public static List<Genre> GetAllGenres()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Genres.ToList();
            }
        }

        public static List<Author> GetAllAuthors()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Authors.ToList();
            }
        }

        public static Book GetFullBookById(int id)
        {
            using (var db = new SE407_BookStoreContext())
            {
                var book = db.Books
                    .Include(a => a.Author)
                    .Include(g => g.Genre)
                    .Where(b => b.BookId == id)
                    .FirstOrDefault();
                return book;
            }
        }

        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.ToList();
            }
        }

        public static List<Book> GetAllBooksByAuthorLast(string lastname)
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books
                    .Join(db.Authors,
                    m => m.AuthorId,
                    t => t.AuthorId,
                    (m, t) => new { M = m, T = t })
                    .Where(w => w.T.AuthorLast == lastname)
                    .Select(m => new Book
                    {
                        BookId = m.M.BookId,
                        BookTitle = m.M.BookTitle,
                        GenreId = m.M.GenreId,
                        AuthorId = m.M.GenreId,
                        YearOfRelease = m.M.YearOfRelease
                    }).ToList();
            }
        }

        public static List<Book> GetAllBooksFull()
        {
            using (var context = new SE407_BookStoreContext())
            {
                var books = context.Books
                    .Include(books => books.Author)
                    .Include(books => books.Genre)
                    .ToList();

                return books;
            }
        }


    }
}
