using CsvHelper;
using MidTerm.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace midTermConsole
{
    class OutputHelper
    {

        public void WriteToConsole(List<Book> books)
        {
            Console.WriteLine("List of Books:");
            foreach (var b in books)
            {
                Console.WriteLine($"BookId: {b.BookId}\tTitle: {b.BookTitle}\tRelease Year: {b.YearOfRelease}");
            }
        }

        public void WriteBookToConsole(Book b)
        {
            Console.WriteLine($"Book found by Title: {b.BookId}");
            Console.WriteLine($"Title:  {b.BookTitle}");
        }

        public void WriteToCSV(List<Book> books)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(books);
            }
        }
        public void WriteBookToCSV(Book b)
        {
            using (var writer = new StreamWriter(@"..\file.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(b.BookTitle);
            }
        }


    }
}
