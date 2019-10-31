using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    //Тестовый класс
    public static class Factory
    {
        public static void Test()
        {
            ShowHouse(new RockHouseCreator());
            ShowHouse(new WoodHouseCreator());
        }

        public static void ShowHouse(HouseCreator creator)
        {
            House house = creator.Create();
            Console.WriteLine(house.Material);
        }
    }

    //Базовый Creator
    public abstract class HouseCreator
    {
        public abstract House Create();
    }

    //Конкретные Creator-ы
    public class RockHouseCreator : HouseCreator
    {
        public override House Create()
        {
            return Create(5);
        }

        public RockHouse Create(uint size)
        {
            return new RockHouse(size);
        }
    }

    public class WoodHouseCreator : HouseCreator
    {
        public override House Create()
        {
            return Create("Tree");
        }

        public WoodHouse Create(string wood)
        {
            return new WoodHouse(wood);
        }
    }

    //Конкретные продукты
    public class RockHouse : House
    {
        public uint RockSize { get; private set; }

        public override string Material => "Rock";



        public RockHouse(uint rockSize)
        {
            RockSize = rockSize;
        }
    }

    public class WoodHouse : House
    {
        private string woodMaterial;
        public override string Material => woodMaterial;

        public WoodHouse(string woodMaterial)
        {
            this.woodMaterial = woodMaterial;
        }
    }

    //Базовый продукт
    public abstract class House
    {
        public abstract string Material { get; }
    }
}
