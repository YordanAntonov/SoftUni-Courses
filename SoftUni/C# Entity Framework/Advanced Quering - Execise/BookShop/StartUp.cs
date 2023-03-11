namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using System.Globalization;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            //int pages = int.Parse(Console.ReadLine());
            Console.WriteLine(GetMostRecentBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            bool hasParsed = Enum.TryParse(typeof(AgeRestriction), command, true, out object? ageRestrictionObj);
            AgeRestriction ageRestriction;

            if (hasParsed)
            {
                ageRestriction = (AgeRestriction)ageRestrictionObj;

                var bookTitles = context.Books.Where(b => b.AgeRestriction == ageRestriction).OrderBy(b => b.Title)
                    .Select(b => b.Title)
                    .ToList();

                return string.Join(Environment.NewLine, bookTitles);
            }

            return null;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            bool hasParsed = Enum.TryParse(typeof(EditionType), "Gold", true, out object? goldBookObj);
            EditionType goldBook;

            if (hasParsed)
            {
                goldBook = (EditionType)goldBookObj;

                var goldenBooks = context.Books.Where(gb => gb.Copies < 5000 && gb.EditionType == goldBook).OrderBy(b => b.BookId)
                   .Select(gb => gb.Title).ToList();

                return string.Join(Environment.NewLine, goldenBooks);
            }

            return null;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new();

            var books = context.Books.Where(b => b.Price > 40).Select(b => new
            {
                b.Title,
                b.Price
            }).OrderByDescending(b => b.Price).ToList();

            foreach ( var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year != year).OrderBy(b => b.BookId).Select(b => b.Title).AsNoTracking().ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] bookCategories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(b => b.ToLower()).ToArray();

            var books = context.Books.Where(b => b.BookCategories.Any(bc => bookCategories.Contains(bc.Category.Name.ToLower())))
            .OrderBy(b => b.Title)
            .Select(b => b.Title)
            .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            DateTime convertedDate = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books.Where(b => b.ReleaseDate < convertedDate)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                }).AsNoTracking().ToList();

            StringBuilder sb = new();

            foreach (var b in books)
            {
                sb.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {

            var authorNames = context.Authors.Where(a => a.FirstName.EndsWith(input))
                .OrderBy(a => a.FirstName)
                .ThenBy(a => a.LastName)
                .Select(a =>           
            $"{a.FirstName} {a.LastName}"
            ).AsNoTracking().ToList();

            StringBuilder sb = new();

            foreach (var a in authorNames)
            {
                sb.AppendLine(a);
            }

            return sb.ToString().TrimEnd();   
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            input = input.ToLower();
            var titles = context.Books.Where(b => b.Title.ToLower().Contains(input)).OrderBy(b => b.Title).Select(b => b).AsNoTracking().ToList();

            return string.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            input = input.ToLower();

            var booksAuthors = context.Books.Where(b => b.Author.LastName.ToLower().StartsWith(input))
                .OrderBy(b => b.BookId)
                .Select(b => $"{b.Title} ({b.Author.FirstName} {b.Author.LastName})")
                .AsNoTracking()
                .ToArray();

            return string.Join(Environment.NewLine, booksAuthors);
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int booksCount = context.Books
                .Where(b => b.Title.Length > lengthCheck).Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var copiesCount = context.Authors.Select(a => new
            {
                a.FirstName, 
                a.LastName,
                BookCopies = a.Books.Select(b => b.Copies).Sum()
            }).OrderByDescending(b => b.BookCopies).AsNoTracking().ToArray();

            StringBuilder sb = new();
            foreach (var a in copiesCount)
            {
                sb.AppendLine($"{a.FirstName} {a.LastName} - {a.BookCopies.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var booksCategoryProfit = context.Categories.Select(c => new
            {
                Category = c.Name,
                Sum = c.CategoryBooks.Select(b => b.Book.Price * b.Book.Copies).Sum()
            }).OrderByDescending(b => b.Sum).ThenBy(b => b.Category).AsNoTracking().ToList();

            StringBuilder sb = new();

            foreach (var b in booksCategoryProfit)
            {
                sb.AppendLine($"{b.Category} ${b.Sum:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
            => "--" + string.Join($"{Environment.NewLine}--", context.Categories
                .Select(c => new
                {
                    Name = c.Name,
                    BookCount = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .Count(),
                    TopThreeString = string.Join(Environment.NewLine, c.CategoryBooks
                        .Select(cb => cb.Book)
                        .OrderByDescending(b => b.ReleaseDate)
                        .Take(3)
                        .Select(b => b.ReleaseDate == null
                            ? $"{b.Title} ()"
                            : $"{b.Title} ({b.ReleaseDate.Value.Year})"))
                })
                // .OrderBy(c => c.BookCount) // Wrong Requirement - Judge wants sorting by Name
                .OrderBy(c => c.Name)
                .Select(c => $"{c.Name}{Environment.NewLine}{c.TopThreeString}"));

        public static void IncreasePrices(BookShopContext context)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year < 2010).ToArray();
            
            foreach (var book in books)
            {
                book.Price += 5;
            }

             context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                    .Where(b => b.Copies < 4200)
                    .ToArray();

            var removedBooks = books.Length;

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return removedBooks;
        }
    }
}


