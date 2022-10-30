namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            //int year = int.Parse(Console.ReadLine());
            Console.WriteLine(GetGoldenBooks(db)); 
        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageResc;
            bool same = Enum.TryParse(command, true, out ageResc);
            var titles = context.Books.Where(x => x.AgeRestriction.Equals(ageResc))
                .OrderBy(x => x.Title)
                .Select(x => x.Title)
                .AsNoTracking()
                .ToList();
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine(item);
            return build.ToString().TrimEnd();
        }
        public static string GetGoldenBooks(BookShopContext context)
        {
            EditionType ageResc;
            bool same = Enum.TryParse("Gold", true, out ageResc);
            var titles = context.Books.Where(x => x.Copies<5000 && x.EditionType.Equals(ageResc))
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .AsNoTracking()
                .ToList();
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine(item);
            return build.ToString().TrimEnd();
        }
        public static string GetBooksByPrice(BookShopContext context)
        {
            var titles = context.Books.Where(x => x.Price>40)
                .Select(x => new { x.Title, x.Price })
                .OrderByDescending(x => x.Price)
                .ToList();
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine($"{item.Title} - ${item.Price:f2}");
            return build.ToString().TrimEnd();
        }
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var titles = context.Books.Where(x => x.ReleaseDate.Value.Year!=year)
                .OrderBy(x => x.BookId)
                .Select(x => x.Title)
                .ToList();
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine(item);
            return build.ToString().TrimEnd();
        }
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
             HashSet<string> genres = input.ToLower().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToHashSet();
             Func<Book, bool> checker = x =>
             {
                 foreach (var item in x.BookCategories)
                 {
                     if (genres.Contains(item.Category.Name.ToLower())) return true;
                 }
                 return false;
             };
             var titles = context.Books.ToList().Where(x => checker(x))
                 .OrderBy(x => x.Title)
                 .Select(x => x.Title);
           //var titles = context.Books
           //    .Select(x => new
           //    {
           //        x.Title,
           //        Category = x.BookCategories.Select(x => x.Category).First()
           //    }).ToList().Where(x => genres.Contains(x.Category.Name.ToLower()))
           //.Select(x => x.Title)
           //.OrderBy(x => x);
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine(item);
            return build.ToString().TrimEnd();
        }
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dataaa = date.Split('-').Select(int.Parse).ToList();
            DateTime data = new DateTime(dataaa[2], dataaa[1], dataaa[0]);
            var titles = context.Books
                .OrderByDescending(x => x.ReleaseDate)
                .Where(x => DateTime.Compare(x.ReleaseDate.Value, data)<0)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                }).ToList();
            ;
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine($"{item.Title} - {item.EditionType.ToString()} - ${item.Price:f2}");
            return build.ToString().TrimEnd();
        }
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var titles = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => $"{x.FirstName} {x.LastName}")
                .ToList()
                .OrderBy(x => x);
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine(item);
            return build.ToString().TrimEnd();
        }
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var titles = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .Select(x => x.Title).ToList().OrderBy(x => x);
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine(item);
            return build.ToString().TrimEnd();
        }
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var titles = context.Books.Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new 
                {
                    x.Title,
                    AuthorName = $"{x.Author.FirstName} {x.Author.LastName}"
                })
                .ToList();
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine($"{item.Title} ({item.AuthorName})");
            return build.ToString().TrimEnd();
        }
        public static int CountBooks(BookShopContext context, int lengthCheck) => context.Books
            .Where(x => x.Title.Length > lengthCheck).Count();
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var titles = context.Authors.Select(x => new
            {
                AuthorName = $"{x.FirstName} {x.LastName}",
                BookCopies = x.Books.Sum(x => x.Copies)
            }).ToList().OrderByDescending(x => x.BookCopies);
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine($"{item.AuthorName} - {item.BookCopies}");
            return build.ToString().TrimEnd();
        }
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var titles = context.Categories.Select(x => new
            {
                x.Name,
                Sales = x.CategoryBooks.Select(x => new
                {
                    BookPrice = x.Book.Price,
                    BookCopies = x.Book.Copies
                }).Sum(x => x.BookCopies*x.BookPrice)
            }).ToList().OrderByDescending(x => x.Sales).ThenBy(x => x.Name);
            StringBuilder build = new StringBuilder();
            foreach (var item in titles) build.AppendLine($"{item.Name} ${item.Sales:f2}");
            return build.ToString().TrimEnd();
        }
        public static string GetMostRecentBooks(BookShopContext context)
        {
            var titles = context.Categories.Select(x => new
            {
                x.Name,
                Top = x.CategoryBooks.Select(x => x.Book)
                .OrderByDescending(x => x.ReleaseDate)
                .Take(3)
                .ToList()
            }).OrderBy(x => x.Name).ToList();
            StringBuilder build = new StringBuilder();
            foreach (var item in titles)
            {
                build.AppendLine($"--{item.Name}");
                foreach (var book in item.Top) build.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
            }
            return build.ToString().TrimEnd();
        }
        public static void IncreasePrices(BookShopContext context)
        {
            var titles = context.Books.Where(x => x.ReleaseDate.Value.Year<2010).ToList();
            foreach (var item in titles) item.Price += 5;
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var titles = context.Books.Where(x => x.Copies < 4200).ToList();
            context.Books.RemoveRange(titles);
            context.SaveChanges();
            return titles.Count;
        }
    }
}
