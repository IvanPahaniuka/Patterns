using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    //Тестовый класс
    public static class TemplateTest
    {
        public static void Test()
        {
            Hunting hunting = new Elf();
            hunting.Hunt();

            hunting = new Orc();
            hunting.Hunt();
        }
    }

    //Базовый класс метода охоты
    public abstract class Hunting
    {
        public void Hunt()
        {
            GetWeapon();
            HuntStart();
            ComeBack();
        }

        public abstract void GetWeapon();
        public abstract void HuntStart();
        public abstract void ComeBack();
    }

    //Конкретные классы охоты
    public class Elf: Hunting
    {
        public override void GetWeapon()
        {
            Console.WriteLine("Elf hunting: took the bow");
        }

        public override void HuntStart()
        {
            Console.WriteLine("Elf hunting: hunting with bow");
        }

        public override void ComeBack()
        {
            Console.WriteLine("Elf come back");
        }
    }

    public class Orc : Hunting
    {
        public override void GetWeapon()
        {
            Console.WriteLine("Orc hunting: took the sword");
        }

        public override void HuntStart()
        {
            Console.WriteLine("Orc hunting: hunting with sword");
        }

        public override void ComeBack()
        {
            Console.WriteLine("Orc come back");
        }
    }
}
