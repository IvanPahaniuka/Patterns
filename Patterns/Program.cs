using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;

            Body();

            Console.WriteLine($"Завершено за {(DateTime.Now-startTime).TotalSeconds} c.! Нажмите любую клавишу, чтобы выйти...");
            Console.ReadKey();
        }

        static void Body()
        {
            Flyweight.Flyweight.Test();
        }

        
    }
}
