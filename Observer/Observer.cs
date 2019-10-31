using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public static class ObserverTest
    {
        public static void Test()
        {
            Spawner spawner = new Spawner();

            Hero hero1 = new Hero();
            Hero hero2 = new Hero();
            Mob mob = new Mob();

            spawner.AddObserver(mob);
            spawner.AddObserver(hero1);
            spawner.AddObserver(hero2);

            spawner.Update();
        }
    }

    public class Spawner : IObserveble
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void Update()
        {
            Console.WriteLine("A mob has been spawned!");
            foreach (IObserver observer in observers)
                observer.Update();
        }
    }

    public interface IObserveble
    {
        void AddObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void Update();
    }

    public interface IObserver
    {
        void Update();
    }

    public class Hero: IObserver
    {
        public void Update()
        {
            Console.WriteLine("A hero has found a mob!");
        }
    }

    public class Mob : IObserver
    {
        public void Update()
        {
            Console.WriteLine("A mob has found a mob!");
        }
    }
}
