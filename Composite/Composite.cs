using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public static class Composite
    {
        public static void Test()
        {
            Unit army = new Army();
            Unit subArmy1 = new Army();
            subArmy1.Add(new Military(10));
            subArmy1.Add(new Military(20));
            subArmy1.Add(new Military(1));
            army.Add(subArmy1);

            Unit subArmy2 = new Army();
            subArmy2.Add(new Military(13));
            subArmy2.Add(new Military(12));
            army.Add(subArmy2);

            army.Add(new Military(50));

            Console.WriteLine($"Army power: {army.Power}");
        }
    }

    public abstract class Unit
    {
        public abstract int Power { get; }

        public virtual void Add(Unit unit) { }
        public virtual void Remove(Unit unit) { }
    }

    public class Army: Unit
    {
        protected List<Unit> units = new List<Unit>();

        public override int Power
        {
            get
            {
                int res = 0;
                foreach (Unit unit in units)
                    res += unit.Power;
                return res;
            }
        }

        public override void Add(Unit unit)
        {
            units.Add(unit);
        }
        public override void Remove(Unit unit)
        {
            units.Remove(unit);
        }
    }

    public class Military : Unit
    {
        private int power = 0;
        public override int Power => power;

        public Military(int power)
        {
            this.power = power;
        }
    }
}
