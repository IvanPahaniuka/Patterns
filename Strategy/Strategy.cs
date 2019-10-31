using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    public static class StrategyTest
    {
        public static void Test()
        {
            Hero hero = new Hero("Ivan", new DistanceAttack());
            hero.Attack("Orc");
            hero.Attack("Elf");

            hero.attack = new CloseAttack();
            hero.Attack("Elf");
        }
    }


    public class Hero
    {
        protected string name;
        public IAttack attack { private get; set; }

        public Hero(string name, IAttack attack)
        {
            this.name = name;
            this.attack = attack;
        }
            

        public void Attack(string target)
        {
            attack.Attack(target);
        }
    }

    public class CloseAttack : IAttack
    {

        public string Target { get; private set; }

        public void Attack(string target)
        {
            Target = target;

            Console.WriteLine($"Close attack! Target: {Target}");
        }
    }

    public class DistanceAttack : IAttack
    {
        public int Distance { get; private set; }
        public string Target { get; private set; }

        public void Attack(string target)
        {
            Target = target;

            if (target == "Orc")
                Distance = 10;
            else
                Distance = 5;

            Console.WriteLine($"Distance attack! Distance: {Distance}; Target: {Target}");
        }
    }

    public interface IAttack
    {
        void Attack(string target);
    }
}
