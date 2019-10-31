using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class LazySingleton
    {
        private static readonly Lazy<LazySingleton> lazy = 
            new Lazy<LazySingleton>(() => new LazySingleton());

        public string Name { get; private set; } = "test";

        private LazySingleton()
        {
            Console.WriteLine($"Created: {DateTime.Now}");
        }

        #region Test
        public static void Test()
        {
            Console.WriteLine($"Name: {LazySingleton.GetInstance().Name}");
        }
        #endregion

        public static LazySingleton GetInstance()
        {
            Console.WriteLine($"GET_INSTANCE: {DateTime.Now}");
            return lazy.Value;
        }


    }
}
