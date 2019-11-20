using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace States
{
    public static class StatesTest 
    {
        public static void Test()
        {
            Tower tower = new Tower();

            tower.State.SetFire();
            tower.State.SetFire();
            tower.State.SetNormal();
            tower.State.SetHeal();
        }
    }

    public class Tower
    {
        public TowerState State { get; private set; }

        public Tower()
        {
            State = new NormalState(this);
        }

        public abstract class TowerState
        {
            protected Tower Tower { get; private set; }

            public TowerState(Tower tower)
            {
                this.Tower = tower ?? throw new Exception();
            }

            public abstract void SetNormal();
            public abstract void SetFire();
            public abstract void SetHeal();
        }

        public class NormalState : TowerState
        {
            public NormalState(Tower tower): base(tower) { }

            public override void SetFire()
            {
                Console.WriteLine("Переход в боевое состояние...");
                Tower.State = new FireState(Tower);
            }

            public override void SetHeal()
            {
                Console.WriteLine("Переход в состояние восстановления...");
                Tower.State = new HealState(Tower);
            }

            public override void SetNormal()
            {
                Console.WriteLine("Состояние уже является нормальным...");
            }
        }

        public class FireState : TowerState
        {
            public FireState(Tower tower) : base(tower) { }

            public override void SetFire()
            {
                Console.WriteLine("Состояние уже является боевым...");
            }

            public override void SetHeal()
            {
                Console.WriteLine("Переход в состояние восстановления...");
                Tower.State = new HealState(Tower);
            }

            public override void SetNormal()
            {
                Console.WriteLine("Переход в нормальное состояние...");
                Tower.State = new NormalState(Tower);
            }
        }

        public class HealState : TowerState
        {
            public HealState(Tower tower) : base(tower) { }

            public override void SetFire()
            {
                Console.WriteLine("Переход в боевое состояние...");
                Tower.State = new FireState(Tower);
            }

            public override void SetHeal()
            {
                Console.WriteLine("Состояние уже является состоянием восстановления...");
            }

            public override void SetNormal()
            {
                Console.WriteLine("Переход в нормальное состояние...");
                Tower.State = new NormalState(Tower);
            }
        }

    }
     
}
