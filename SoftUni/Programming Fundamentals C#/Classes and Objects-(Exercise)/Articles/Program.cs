using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articleInfo = Console.ReadLine().Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
            Article article = new Article(articleInfo[0], articleInfo[1], articleInfo[2]);
            int numOfEdits = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfEdits; i++)
            {
                string[] editCommand = Console.ReadLine().Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);
                string command = editCommand[0];
                string method = editCommand[1];

                switch (command)
                {
                    case "Edit":
                        article.Edit(method);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(method);
                        break;
                    case "Rename":
                        article.Rename(method);
                        break;
                }
            }
            Console.WriteLine(article);
        }

    }

    class Article
    {
        public Article (string title, string content, string author)
        {
            Title = title;

            Content = content;

            Author = author;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public string Edit(string content) => Content = content;

        public string ChangeAuthor(string author) => Author = author;

        public string Rename(string title) => Title = title;

        public override string ToString() => $"{Title} - {Content}: {Author}";
        



    }
}
