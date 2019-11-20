using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Memento
{
    public static class Memento
    {
        public static void Test()
        {
            Hero hero = new Hero(3, 5);
            GameHistory gameHistory = new GameHistory();
            gameHistory.History.Push(hero.Save());

            hero.Shoot();
            gameHistory.History.Push(hero.Save());

            hero.Damage();
            hero.Shoot();
            hero.Shoot();
            gameHistory.History.Push(hero.Save());

            hero.Damage();
            hero.Damage();
            hero.Damage();

            hero.Load(gameHistory.History.Peek());

            hero.Damage();
            hero.Shoot();
            gameHistory.History.Pop();
            hero.Load(gameHistory.History.Peek());

        }
    }

    public class Hero
    {
        public uint Lives { get; private set; } = 0;
        public uint Arrows { get; private set; } = 0;

        public Hero(uint lives, uint arrows)
        {
            Lives = lives;
            Arrows = arrows;
        }

        public void Shoot()
        {
            if (Arrows > 0)
            {
                Arrows--;
                Console.WriteLine($"Производим выстрел. Осталось {Arrows} стрел");
            }
            else
                Console.WriteLine($"Стрел больше нет");
        }

        public void Damage()
        {
            if (Lives > 0)
            {
                Lives--;
                Console.WriteLine($"Ранение. Осталось {Lives} жизней");
            }
            else
                Console.WriteLine($"Мертв");
        }

        public HeroMemento Save()
        {
            Console.WriteLine($"Сохранение игры. Параметры: {Lives} жизней, {Arrows} стрел");
            return new HeroMemento(Lives, Arrows);
        }

        public void Load(HeroMemento memento)
        {
            Arrows = memento.Arrows;
            Lives = memento.Lives;
            Console.WriteLine($"Восстановление игры. Параметры: {Lives} жизней, {Arrows} стрел");
        }
    }

    public class HeroMemento
    {
        public uint Lives { get; private set; }
        public uint Arrows { get; private set; }

        public HeroMemento(uint lives, uint arrows)
        {
            Lives = lives;
            Arrows = arrows;
        }
    }

    public class GameHistory
    {
        public Stack<HeroMemento> History { get; private set; } = 
            new Stack<HeroMemento>();
    }
}
