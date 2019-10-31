using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    //Тестовый класс
    public static class PrototypeTest
    {
        public static void Test()
        {
            EnemyPrototype enemy1 = new Orc(1, 2, "Sword");
            EnemyPrototype enemy2 = enemy1.Clone();
            enemy2.Damage = 10;

            EnemyPrototype enemy3 = new Elf(3, 1, 1.1f);
            enemy1 = enemy3.Clone();
            enemy1.Health = 2;

            Console.WriteLine($"Enemy1: Damage: {enemy1.Damage}; Health: {enemy1.Health}");
            Console.WriteLine($"Enemy2: Damage: {enemy2.Damage}; Health: {enemy2.Health}");
            Console.WriteLine($"Enemy3: Damage: {enemy3.Damage}; Health: {enemy3.Health}");
        }
    }

    //Базовый прототип
    public abstract class EnemyPrototype
    {
        public uint Damage { get; set; }
        public uint Health { get; set; }

        public EnemyPrototype(uint damage, uint health)
        {
            Damage = damage;
            Health = health;
        }

        public abstract EnemyPrototype Clone();
    }

    //Конкретные прототипы
    public class Orc: EnemyPrototype
    {
        public string Weapon { get; set; }
        
        public Orc(uint damage, uint health, string weapon): 
            base(damage, health)
        {
            Weapon = weapon;
        }

        public override EnemyPrototype Clone()
        {
            return new Orc(Damage, Health, Weapon);
        }
    }

    public class Elf : EnemyPrototype
    {
        public float Speed { get; set; }

        public Elf(uint damage, uint health, float speed) :
            base(damage, health)
        {
            Speed = speed; ;
        }

        public override EnemyPrototype Clone()
        {
            return new Elf(Damage, Health, Speed);
        }
    }
}
