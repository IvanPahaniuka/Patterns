using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    public static class Flyweight
    {
        public static void Test()
        {
            HouseFactory factory = new HouseFactory();
            Random random = new Random();

            for (int y = 0; y < 3; y++)
                for (int x = 0; x < 3; x++)
                {
                    HouseFactory.HOUSE_TYPES type = (HouseFactory.HOUSE_TYPES)random.Next(
                        0, Enum.GetValues(typeof(HouseFactory.HOUSE_TYPES)).Length);
                    factory.GetHouse(type).Build(x, y);
                }
        }
    }

    public abstract class House
    {
        public uint Stages { get; }

        public House(uint stages)
        {
            Stages = stages;
        }

        public abstract void Build(float x, float y);
    }

    public class BrickHouse : House
    {
        public BrickHouse(uint stages)
            : base(stages)
        {

        }

        public override void Build(float x, float y)
        {
            Console.WriteLine($"Кирпичный дом из {Stages} этажей построен в точке ({x}; {y})");
        }
    }

    public class WoodHouse : House
    {
        public WoodHouse(uint stages)
            : base(stages)
        {

        }

        public override void Build(float x, float y)
        {
            Console.WriteLine($"Деревянный дом из {Stages} этажей построен в точке ({x}; {y})");
        }
    }

    public class HouseFactory
    {
        public enum HOUSE_TYPES {
            WOOD,
            BRICK
        }; 

        protected Dictionary<HOUSE_TYPES, House> houses;

        public HouseFactory()
        {
            houses = new Dictionary<HOUSE_TYPES, House>();
            houses.Add(HOUSE_TYPES.WOOD, new WoodHouse(2));
            houses.Add(HOUSE_TYPES.BRICK, new BrickHouse(1));
        }

        public House GetHouse(HOUSE_TYPES type)
        {
            return houses.ContainsKey(type) ? houses[type] : null;
        }
    }
}
