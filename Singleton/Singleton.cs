using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{

    public class Singleton
    {
        public DateTime Date { get; private set; }
        public static int Value = 228;

        private Singleton()
        {
            Date = DateTime.Now;
            Console.WriteLine($"Singleton created: {Date}");
        }

        #region Test
        public static void Test()
        {
            Console.WriteLine($"Value: {Value}");
            Console.WriteLine($"Date: { Singleton.GetInstance().Date}");
        }
        #endregion

        public static Singleton GetInstance()
        {
            Console.WriteLine($"GET_INSTANSE: {DateTime.Now}");
            System.Threading.Thread.Sleep(500);
            return PrivateSingleton.singleton;
        }

        private class PrivateSingleton
        {
            static PrivateSingleton()
            {
            }

            internal static readonly Singleton singleton = new Singleton();
        }
    }
}
