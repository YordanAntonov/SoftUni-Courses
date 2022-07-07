using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articles_2._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                List<Article> articles = new List<Article>();

                
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



}
    }
}
