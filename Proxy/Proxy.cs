using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public static class Proxy
    {
        public static void Test()
        {
            MagicBook magicBook = new MagicBook(
                new Page[] {
                    new Page(1, "ПЕРВАЯ ЧАСТЬ"),
                    new Page(2, "ВТОРАЯ ЧАСТЬ"),
                    new Page(3, "ТРЕТЬЯ ЧАСТЬ"),
                    new Page(4, "ЧЕТВЕРТАЯ ЧАСТЬ"),
                    new Page(5, "ПЯТАЯ ЧАСТЬ")
                });

            MagicBookProxy bookProxy = new MagicBookProxy(magicBook);


            Console.WriteLine($"Текст: {bookProxy.GetPage(2).Text}");
            Console.WriteLine($"Текст: {bookProxy.GetPage(3).Text}");
            Console.WriteLine($"Текст: {bookProxy.GetPage(2).Text}");
            Console.WriteLine($"Текст: {bookProxy.GetPage(5).Text}");
            Console.WriteLine($"Текст: {bookProxy.GetPage(5).Text}");
        }
    }

    public class Page
    {
        protected readonly uint number;
        protected readonly string text;

        public uint Number => number;
        public string Text => text;

        public Page(uint number, string text)
        {
            this.number = number;
            this.text = text;
        }
    } 

    public interface IBook
    {
        Page GetPage(uint number);
    }

    public class MagicBook : IBook
    {
        protected Page[] pages;

        public MagicBook(IEnumerable<Page> pages)
        {
            this.pages = pages.ToArray();
        }

        public Page GetPage(uint number)
        {
            Console.WriteLine($"Получение страницы {number} из книги");
            return pages.FirstOrDefault(x => x.Number == number);
        }
    }

    public class MagicBookProxy : IBook
    {
        protected List<Page> pages;
        
        public MagicBook MagicBook { get; private set; }

        public MagicBookProxy(MagicBook book)
        {
            MagicBook = book ?? throw new Exception();
            pages = new List<Page>();
        }

        public Page GetPage(uint number)
        {
            Console.WriteLine($"Получение страницы {number} из прокси-книги");
            Page page = pages.FirstOrDefault(x => x.Number == number);

            if (page == null && MagicBook != null)
            {
                page = MagicBook.GetPage(number);

                if (page != null)
                    pages.Add(page);
            }

            return page;
        }
    }
}
