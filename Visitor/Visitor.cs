using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    public static class Visitor
    {
        public static void Test()
        {
            Baggages baggages = new Baggages();
            baggages.AddRange(new IBaggage[] {
                new Hero("Alex"),
                new Hero("Jack"),
                new Pet("Snup"),
                new Hero("Mary"),
                new Pet("Fox")});

            IVisitable shop1 = new Armourer();
            IVisitable shop2 = new Currier();

            baggages.Accept(shop1);
            baggages.Accept(shop2);
        }
    }

    public class Baggages : List<IBaggage>, IBaggage
    {
        public void Accept(IVisitable visitable)
        {
            foreach (IBaggage baggage in this)
                baggage.Accept(visitable);
        }
    }

    public interface IBaggage
    {
        void Accept(IVisitable visitable);
    }

    public class Hero: IBaggage
    {
        public string Name { get; private set; }

        public Hero(string name)
        {
            Name = name;
        }

        public void Accept(IVisitable visitable)
        {
            visitable.HeroVisit(this);
        }
    }

    public class Pet: IBaggage
    {
        public string Name { get; private set; }

        public Pet(string name)
        {
            Name = name;
        }

        public void Accept(IVisitable visitable)
        {
            visitable.PetVisit(this);
        }
    }

    public interface IVisitable
    {
        void HeroVisit(Hero hero);
        void PetVisit(Pet pet);
    }

    public class Armourer : IVisitable
    {
        public void HeroVisit(Hero hero)
        {
            Console.WriteLine($"Оружейника посетил герой {hero.Name}");
        }

        public void PetVisit(Pet pet)
        {
            Console.WriteLine($"Оружейника посетил питомец {pet.Name}");
        }
    }

    public class Currier: IVisitable
    {
        public void HeroVisit(Hero hero)
        {
            Console.WriteLine($"Кожевника посетил герой {hero.Name}");
        }

        public void PetVisit(Pet pet)
        {
            Console.WriteLine($"Кожевника посетил питомец {pet.Name}");
        }
    }
}
