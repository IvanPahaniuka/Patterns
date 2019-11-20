using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    //Тестовый класс
    public static class IteratorTest
    {
        public static void Test()
        {
            Mob[] mobs = new Mob[] { new Mob("Elf"), new Mob("Orc"), new Mob("Bandit") };
            Spawner spawner = new Spawner(mobs);

            spawner.ForEach(
                x => Console.WriteLine($"Mob name: {x.Name}"));
        }
    }

    //Класс моба
    public class Mob
    {
        public string Name { get; private set; } = "";
        
        public Mob(string name)
        {
            Name = name;
        }
    }

    //Конкретный класс IMobNumerable 
    //Генератор мобов
    public class Spawner: IMobNumerable
    {
        private Mob[] mobs;

        public Mob this[int index] => mobs[index];
        public int Count => mobs.Length;

        public Spawner(Mob[] mobs)
        {
            this.mobs = mobs;
        }

        public IMobIterator GetIterator()
        {
            return new SpawnerIterator(mobs);
        }
    }

    //Конкретный класс IMobIterator
    //Итератор мобов
    public class SpawnerIterator : IMobIterator
    {
        private Mob[] mobs;
        private int index = -1;

        public SpawnerIterator(Mob[] mobs)
        {
            this.mobs = mobs;
        }

        public bool HasNext()
        {
            return index + 1 < mobs.Length; 
        }

        public Mob Next()
        {
            return mobs[++index];
        }

        public void Reset()
        {
            index = -1;
        }
    }

    public interface IMobIterator
    {
        bool HasNext();
        Mob Next();
        void Reset();
    }

    public interface IMobNumerable
    {
        Mob this[int index] { get; }
        int Count { get; }
        IMobIterator GetIterator();
    }

    //Расширения
    public static class MobNumerableExtention
    {
        public static void ForEach(this IMobNumerable numerable, Action<Mob> action)
        {
            IMobIterator iterator = numerable.GetIterator();
            while (iterator.HasNext())
                action(iterator.Next());

            iterator.Reset();
        }
    }
}
