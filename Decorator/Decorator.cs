using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public static class Decorator
    {
        public static void Test()
        {
            Sword epee = new Epee("Шпага");
            epee = new LongSword(epee);
            epee = new SharpenedSword(epee);
            Console.WriteLine(epee.ToString());

            Sword saber = new Saber("Сабля");
            saber = new ShortSword(saber);
            saber = new DullSword(saber);
            Console.WriteLine(saber.ToString());

            Sword broadsword = new Broadsword("Палаш");
            broadsword = new DullSword(broadsword);
            Console.WriteLine(broadsword);
        }
    }

    public abstract class Sword
    {
        public string Name { get; protected set; }
        public abstract int Cost { get; }
        public abstract float Damage { get; }
        public abstract float Distance { get; }

        public Sword(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"Sword name: {Name}; Cost: {Cost}; Damage: {Damage}; Distance {Distance}";
        }
    }

    public class Saber : Sword
    {
        public override int Cost => 120;
        public override float Damage => 20;
        public override float Distance => 10;

        public Saber(string name) 
            : base(name)
        { }
    }

    public class Broadsword : Sword
    {
        public override int Cost => 160;
        public override float Damage => 20;
        public override float Distance => 30;

        public Broadsword(string name)
            : base(name)
        { }
    }

    public class Epee : Sword
    {
        public override int Cost => 180;
        public override float Damage => 30;
        public override float Distance => 30;

        public Epee(string name)
            : base(name)
        { }
    }

    public class SwordDecorator : Sword
    {
        protected Sword sword;

        public override int Cost => sword.Cost;
        public override float Damage => sword.Damage;
        public override float Distance => sword.Distance;

        public SwordDecorator(string name, Sword sword)
            : base(name)
        {
            this.sword = sword;
        }
    }

    public class LongSword : SwordDecorator
    {
        public override int Cost => sword.Cost + 5;
        public override float Damage => sword.Damage;
        public override float Distance => sword.Distance + 3;

        public LongSword(Sword sword)
            : base($"{sword.Name}, длинный", sword)
        { }
    }

    public class ShortSword : SwordDecorator
    {
        public override int Cost => sword.Cost - 5;
        public override float Damage => sword.Damage;
        public override float Distance => sword.Distance - 3;

        public ShortSword(Sword sword)
            : base($"{sword.Name}, короткий", sword)
        { }
    }

    public class SharpenedSword : SwordDecorator
    {
        public override int Cost => sword.Cost + 5;
        public override float Damage => sword.Damage + 3;
        public override float Distance => sword.Distance;

        public SharpenedSword(Sword sword)
            : base($"{sword.Name}, заточенный", sword)
        { }
    }

    public class DullSword : SwordDecorator
    {
        public override int Cost => sword.Cost - 5;
        public override float Damage => sword.Damage - 3;
        public override float Distance => sword.Distance;

        public DullSword(Sword sword)
            : base($"{sword.Name}, тупой", sword)
        { }
    }
}
