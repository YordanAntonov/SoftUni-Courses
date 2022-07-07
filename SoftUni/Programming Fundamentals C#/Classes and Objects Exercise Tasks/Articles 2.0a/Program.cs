using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles_2._0a
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();
            int numOfEntries = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfEntries; i++)
            {
                string[] entries = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                Article article = new Article(entries[0], entries[1], entries[2]);
                articles.Add(article);
            }


            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }

    }
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;

            Content = content;

            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }


        public override string ToString() => $"{Title} - {Content}: {Author}";




    }

}
