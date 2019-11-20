using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    public static class Bridge
    {
        public static void Test()
        {
            ScarableEnemy enemy = new ScarableEnemy();
            OrcImplementor orcImplementor = new OrcImplementor();
            ElfImplementor elfImplementor = new ElfImplementor();

            enemy.Attack("Федя");

            enemy.Implementor = orcImplementor;
            enemy.Attack("Федя");

            enemy.Implementor = elfImplementor;
            enemy.Attack("Федя");

            enemy.RunAway();
        }
    }

    public abstract class Enemy
    {
        private EnemyImplementor implementor;
        public EnemyImplementor Implementor {
            get => implementor;
            set => implementor = value ?? new EmptyEnemyImplementor();
        }

        public Enemy():
            this(null)
        { }

        public Enemy(EnemyImplementor implementor)
        {
            Implementor = implementor;
        }

        public void Attack(string hero)
        {
            implementor.Attack(hero);
        }

       
    }

    public abstract class EnemyImplementor
    {
        public abstract void Attack(string hero);
    }

    public class EmptyEnemyImplementor : EnemyImplementor
    {
        public override void Attack(string hero)
        {
            Console.WriteLine($"Пустышка атакует героя {hero}");
        }
    }

    public class ElfImplementor: EnemyImplementor
    {
        public override void Attack(string hero)
        {
            Console.WriteLine($"Эльф атакует героя {hero}");
        }
    }

    public class OrcImplementor : EnemyImplementor
    {
        public override void Attack(string hero)
        {
            Console.WriteLine($"Орк атакует героя {hero}");
        }
    }

    public class ScarableEnemy: Enemy
    {
        public void RunAway()
        {
            Console.WriteLine("Враг убегает!");
        }
    }
}
