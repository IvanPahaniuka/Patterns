using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    public static class ChainOfResponsibilityTest
    {
        public static void Test()
        {
            TowerReceiver receiver = new TowerReceiver(false, false, true);

            
            TowerHandler handler3 = new CalmHandler();
            TowerHandler handler2 = new FireHandler { Successor = handler3 };
            TowerHandler handler1 = new HealHandler { Successor = handler2 };

            handler1.Handle(receiver);
        }
    }

    public class TowerReceiver
    {
        public bool Calm { get; private set; }
        public bool Heal { get; private set; }
        public bool Fire { get; private set; }

        public TowerReceiver(bool calm, bool heal, bool fire)
        {
            Calm = calm;
            Heal = heal;
            Fire = fire;
        }
    }

    public abstract class TowerHandler
    {
        public TowerHandler Successor { get; set; }

        public abstract void Handle(TowerReceiver receiver);
    }

    public class FireHandler : TowerHandler
    {
        public override void Handle(TowerReceiver receiver)
        {
            if (receiver.Fire)
                Console.WriteLine("Огонь!!");
            else
                Successor?.Handle(receiver); 
        }
    }

    public class HealHandler : TowerHandler
    {
        public override void Handle(TowerReceiver receiver)
        {
            if (receiver.Heal)
                Console.WriteLine("Лечим");
            else
                Successor?.Handle(receiver);
        }
    }

    public class CalmHandler : TowerHandler
    {
        public override void Handle(TowerReceiver receiver)
        {
            if (receiver.Calm)
                Console.WriteLine("Ждем");
            else
                Successor?.Handle(receiver);
        }
    }
}
