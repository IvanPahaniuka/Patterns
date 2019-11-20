using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public static class Facade
    {
        public static void Test()
        {
            FortressFacade facade = new FortressFacade(
                new TowerSystem(), 
                new WallSystem(),
                new GunsSystem());

            facade.Build();
            facade.Fire();
        }
    }

    public class FortressFacade
    {
        protected TowerSystem towerSystem;
        protected WallSystem wallSystem;
        protected GunsSystem gunsSystem;

        public FortressFacade(TowerSystem towerSystem, WallSystem wallSystem, GunsSystem gunsSystem)
        {
            this.towerSystem = towerSystem;
            this.wallSystem = wallSystem;
            this.gunsSystem = gunsSystem;
        }

        public void Build()
        {
            towerSystem.Build();
            wallSystem.Build();
            gunsSystem.Build();
            Console.WriteLine("Крепость построенна");
        }

        public void Fire()
        {
            gunsSystem.Fire();
        }
    }

    public class TowerSystem
    {
        public void Build()
        {
            Console.WriteLine("Башни построенны");
        }
    }

    public class WallSystem
    {
        public void Build()
        {
            Console.WriteLine("Стены построенны");
        }
    }

    public class GunsSystem
    {
        public void Build()
        {
            Console.WriteLine("Пушки установленны");
        }

        public void Fire()
        {
            Console.WriteLine("Огонь!");
        }
    }
}
