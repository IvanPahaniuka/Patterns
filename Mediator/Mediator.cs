using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    public static class Mediator
    {
        public static void Test()
        {
            SiegeCommander commander = new SiegeCommander();

            Unit archers = new ArcherUnit(commander);
            Unit ram = new RamUnit(commander);
            Unit heavy = new HeavyUnit(commander);

            commander.ArcherUnit = archers;
            commander.RamUnit = ram;
            commander.HeavyUnit = heavy;

            archers.Send("Вражеские лучники уничтоженны, можно таранить!");
            ram.Send("Ворота уничтожены, можно заходить в крепость!");
            heavy.Send("В крепости остались лучники, нужна помощь!");

        }
    }

    public abstract class Commander
    {
        public abstract void Send(Unit sender, string msg);
    }

    public abstract class Unit
    {
        protected Commander commander;

        public Unit(Commander commander)
        {
            this.commander = commander;
        }

        public virtual void Send(string msg)
        {
            commander.Send(this, msg);
        }

        public abstract void Notify(string msg);
    }

    public class SiegeCommander: Commander
    {
        public Unit ArcherUnit { get; set; }
        public Unit RamUnit { get; set; }
        public Unit HeavyUnit { get; set; }

        public override void Send(Unit sender, string msg)
        {
            if (sender == ArcherUnit)
                RamUnit.Notify(msg);
            else if (sender == RamUnit)
                HeavyUnit.Notify(msg);
            else if (sender == HeavyUnit)
                ArcherUnit.Notify(msg);
        }
    }

    public class RamUnit : Unit
    {
        public RamUnit(Commander commander) : base(commander) { }

        public override void Notify(string msg)
        {
            Console.WriteLine($"Сообщение для тарана: {msg}");
        }
    }

    public class ArcherUnit : Unit
    {
        public ArcherUnit(Commander commander) : base(commander) { }

        public override void Notify(string msg)
        {
            Console.WriteLine($"Сообщение для лучников: {msg}");
        }
    }

    public class HeavyUnit : Unit
    {
        public HeavyUnit(Commander commander) : base(commander) { }

        public override void Notify(string msg)
        {
            Console.WriteLine($"Сообщение для пехоты: {msg}");
        }
    }


}
