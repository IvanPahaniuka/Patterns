using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    public static class Adapter
    {
        public static void Test()
        {
            Sailor sailor = new Sailor();

            Boat boat = new Boat();
            sailor.Travel(boat);

            Horse horse = new Horse();
            sailor.Travel(new HorseToBoatAdapter(horse));
        }
    }

    public class Sailor
    {
        public void Travel(IBoat boat)
        {
            boat.Sail();
        }
    }

    public interface IBoat
    {
        void Sail();
    }

    public class Boat: IBoat
    {
        public void Sail()
        {
            Console.WriteLine("Лодка отплывает");
        }
    }

    public interface IAnimal
    {
        void Move();
    }

    public class Horse: IAnimal
    {
        public void Move()
        {
            Console.WriteLine("Лошадь движется");
        }
    }

    public class HorseToBoatAdapter: IBoat
    {
        private Horse horse;

        public HorseToBoatAdapter(Horse horse)
        {
            if (horse == null)
                throw new Exception();

            this.horse = horse;
        }

        public void Sail()
        {
            horse.Move();
        }
    }
}
